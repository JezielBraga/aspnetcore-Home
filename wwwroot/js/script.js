
/*************************  RESUMO  **********************/
if ($("#resumo").val() === "") {

    //MOEDAS
    //Atual
    let atu = $("#atual").val().replace(",", ".");
    let atuP = parseFloat(atu);
    let atuF = (atuP).toLocaleString("pt-BR", {
        style: "currency", currency: "BRL"
    });

    $("#atualF").val(atuF);

    //Receita
    let rec = $("#receita").val().replace(",", ".");
    let recP = parseFloat(rec);
    let recF = recP.toLocaleString("pt-BR", {
        style: "currency", currency: "BRL"
    });

    $("#receitaF").val(recF);

    //Despesas
    let des = $("#despesas").val().replace(",", ".");
    let desP = parseFloat(des);
    let desF = desP.toLocaleString("pt-BR", {
        style: "currency", currency: "BRL"
    });

    $("#despesasF").val(desF);

    //Saldo
    let sal = atuP + recP - desP;
    let salF = sal.toLocaleString("pt-BR", {
        style: "currency", currency: "BRL"
    });

    $("#saldoF").val(salF);

    //EVENTOS
    //Atual
    $("#atualF").click(function () {
        $(this).val("");
    });

    $("#atualF").blur(function () {
        //Atual
        let atuIn = ($(this).val() == "")
            ? "0" : $(this).val();

        let atuInN = atuIn.replace(",", ".");
        let atuN = $("#atual").val().replace(",", ".");
        let atuP = parseFloat(atuInN) + parseFloat(atuN);
        let atuF = atuP.toLocaleString("pt-BR", {
            style: "currency", currency: "BRL"
        });

        $(this).val(atuF);

        //Receita
        let rec = $("#receita").val().replace(",", ".");
        let recP = parseFloat(rec);
        let recF = recP.toLocaleString("pt-BR", {
            style: "currency", currency: "BRL"
        });

        $("#receitaF").val(recF);

        //Despesas
        let des = $("#despesas").val().replace(",", ".");
        let desP = parseFloat(des);
        let desF = desP.toLocaleString("pt-BR", {
            style: "currency", currency: "BRL"
        });

        $("#despesasF").val(desF);

        //Saldo
        let salP = atuP + recP - desP;
        let salF = salP.toLocaleString("pt-BR", {
            style: "currency", currency: "BRL"
        });

        $("#saldoF").val(salF)
    })

    //NAVEGAÇÃO
    $("#recpg").click(() => {
        window.location = "/Conta/Receita";
    });

    $("#despg").click(() => {
        window.location = "/Conta/Despesas";
    });
}

/************************* DETALHES **********************/
if ($("#detalhes").val() === "") {

    //Em Alteração
    if ($("#senhaId").val() > 0)
        $("#mod-cad").css("display", "block");

    if ($("#quit").is(":checked"))
        $("#dataQuit").css("display", "block");

    //EVENTOS
    //Em Alteração
    $("#valorF").click(function () {
        let val = $("#valor").val().replace(".", ",");
        $(this).val(val);
    });

    $("#valorF").blur(function () {
        if ($(this).val() != "") {
            $("#valor").val($("#valorF").val());

            let val = $("#valorF").val().replace(",", ".");
            let valP = parseFloat(val);
            let valF = valP.toLocaleString("pt-BR", {
                style: "currency", currency: "BRL"
            });

            $(this).val(valF);

        } else {
            let val = $("#valor").val().replace(",", ".");
            let valP = parseFloat(val);
            let valF = valP.toLocaleString("pt-BR", {
                style: "currency", currency: "BRL"
            });

            $(this).val(valF);
        }
    });
}

/***********************  GLOBAL  ************************/
//Converte em Moeda
$(".valorF").each(paraMoeda);
$("#valor").each(paraMoeda);

//Aplica filtro
$("#usrId").on('change', Refina);
$("#dataVenc").on('change', Refina);

//EVENTOS
//Exibe Cadastro-Alteração
$("#in-cad").click(() => {
    $("#mod-cad").css("display", "block");
});

//Oculta Cadastro-Alteração
$("#out-cad").click(() => {
    $("#mod-cad").css("display", "none");
});

//Exibe Input Data de Quitação
$("#quit").click(() => {
    $("#dataQuit").css("display", "block");
});

//Oculta Input Data de Quitação
$("#aber").click(() => {
    $("#dataQuit").css("display", "none");
});

/*$("#out-cad").click(() => {
    $("#receita input").val("");
});*/

//Confirma exclusão de item
$(".exc").click(() => {
    return confirm("Deseja realmente excluir isso?");
});

//FUNÇÕES
//Formata Moeda
function paraMoeda() {

    //Na lista e em Detalhes
    let val = $(this).html().replace(",", ".");
    let valP = parseFloat(val);
    let valF = valP.toLocaleString("pt-BR", {
        style: "currency", currency: "BRL"
    });

    $(this).html(valF);

    //Na Alteração
    if ($("#valor").val() != undefined) {
        let val = $(this).val().replace(",", ".");
        let valP = parseFloat(val);
        let valF = valP.toLocaleString("pt-BR", {
            style: "currency", currency: "BRL"
        });

        $("#valorF").val(valF);
    }
}

//Refina pesquisa
function Refina() {

    if ($("#resumo").val() === "") {
        let filtro = $("#filtro").serialize();
        $.post('/conta/filtro', filtro, (result) => {

            //Atual
            let atuP = result.totSaldo;
            let atuF = atuP.toLocaleString("pt-BR", {
                style: "currency", currency: "BRL"
            });

            $("#atualF").val(atuF);

            //Receita
            let recP = result.totReceita;
            let recF = recP.toLocaleString("pt-BR", {
                style: "currency", currency: "BRL"
            });

            $("#receitaF").val(recF);

            //Despesas
            let desP = result.totDespesas;
            let desF = desP.toLocaleString("pt-BR", {
                style: "currency", currency: "BRL"
            });

            $("#despesasF").val(desF);

            //Saldo
            let sal = atuP + recP - desP;
            let salF = sal.toLocaleString("pt-BR", {
                style: "currency", currency: "BRL"
            });

            $("#saldoF").val(salF);
        })

    } else {
        $(".usr").each(testaUsuario);
        $(".data").each(testaData);
    }
}

function testaUsuario() {
    let parent = this.closest(".conta");
    let usr = $("#usrId").val();

    if (usr > 0) {
        if (this.value != usr) {
            //parent.classList.add("d-none");
            parent.classList.add("hides");
        } else {
            //parent.classList.remove("d-none");
            parent.classList.remove("hides");
        }
    } else {
        parent.classList.remove("hides");
    }
}

function testaData() {
    let strData = this.value;
    let day = strData[0] + strData[1];
    let month = strData[3] + strData[4];
    let year =
        strData[6] + strData[7] + strData[8] + strData[9];

    let dataCont = new Date(year, (month - 1), day);
    let dataInfo = new Date($("#dataVenc").val());

    dataInfo.setHours(dataInfo.getHours() + 3);

    let parent = this.closest(".conta");

    if (dataCont > dataInfo) {
        parent.classList.add("d-none");
    } else {
        parent.classList.remove("d-none");
    }
}