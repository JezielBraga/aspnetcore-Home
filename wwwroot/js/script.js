//Exibe Cadastros
$("#in-cad").click(function () {
    $("#mod-cad").css("display", "block");
});

if ($("#senhaId").val() > 0)
    $("#mod-cad").css("display", "block");

$("#out-cad").click(function () {
    $("#mod-cad").css("display", "none");
});

//Confirma exclusão de item
$(".exc").click(function () {
    return confirm("Deseja realmente excluir isso?");
});


/***********************  RESUMO  ******************/
//MOEDAS
if ($("#receita").val() != undefined &&
    $("#despesas").val() != undefined) {

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

    $("#saldoF").val(salF)
}

//EVENTOS
if ($("#usr").val() != null) {
    const $usrs = document.querySelector("#usr");

    $usrs.addEventListener('change', (e) => {
        e.preventDefault();

        let id = $("#usr").serialize();
        $.post('/conta/totrec', id, (resp) => {


            console.log(resp);

            //Atual
            let atuP = resp.totSaldo;
            let atuF = atuP.toLocaleString("pt-BR", {
                style: "currency", currency: "BRL"
            });

            $("#atualF").val(atuF);

            //Receita
            let recP = resp.totReceita;
            let recF = recP.toLocaleString("pt-BR", {
                style: "currency", currency: "BRL"
            });

            $("#receitaF").val(recF);


            //Despesas
            let desP = resp.totDespesas;
            let desF = desP.toLocaleString("pt-BR", {
                style: "currency", currency: "BRL"
            });

            $("#despesasF").val(desF);

            //Saldo
            let sal = atuP + recP - desP;
            let salF = sal.toLocaleString("pt-BR", {
                style: "currency", currency: "BRL"
            });

            $("#saldoF").val(salF)



            console.log(id)
            console.log(recP);
        })
    })
}




$("#atualF").click(function () {
    //Atual
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
$("#recpg").click(function () {
    window.location = "/Conta/Receita";
});

$("#despg").click(function () {
    window.location = "/Conta/Despesas";
});

/***************  RECEITA & DESPESAS  **************/
//MOEDAS
//Listas e Detalhes
$(".valorF").each(function () {
    let val = $(this).html().replace(",", ".");
    let valP = parseFloat(val);
    let valF = valP.toLocaleString("pt-BR", {
        style: "currency", currency: "BRL"
    });

    $(this).html(valF);
});

//Na Alteração
let val = $("#valor").val().replace(",", ".");
let valP = parseFloat(val);
let valF = valP.toLocaleString("pt-BR", {
    style: "currency", currency: "BRL"
});

if (valP > 0)
    $("#valorF").val(valF);

//EVENTOS
//No cadastro e Alteração
$("#valorF").click(function () {
    $(this).val("");
});

$("#valorF").blur(function () {
    if ($(this).val() != "") {
        let val = $(this).val();

        $("#valor").val(val);

        let valP = parseFloat(val.replace(",", "."));
        let valF = valP.toLocaleString("pt-BR", {
            style: "currency", currency: "BRL"
        });

        $(this).val(valF);
    } else {
        let val = parseFloat($("#valor").val());
        let valF = val.toLocaleString("pt-BR", {
            style: "currency", currency: "BRL"
        });

        $("#valorF").val(valF);
    }
});

if ($("#quit").is(":checked"))
    $("#dataQuit").css("display", "block");

$("#quit").click(function () {
    $("#dataQuit").css("display", "block");
});

$("#aber").click(function () {
    $("#dataQuit").css("display", "none");
});

$("#out-cad").on("click", function () {
    $("#receita input").val("");
});

/**********************  DETALHES  *****************/
