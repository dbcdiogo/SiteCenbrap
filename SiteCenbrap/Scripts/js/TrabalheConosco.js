$(document).ready(function () {


    $("#btnEnviar").click(function () {
        Enviar();
    });

    $("#btnLimpar").click(function () {
        $(".form-horizontal input,select,textarea").val("");
    });

    $("#telefone").keyup(function (e) {
        var variavel = $("#telefone").val();

        variavel = variavel.replace(/\D/g, '');
        $("#telefone").val(variavel);
        if (variavel.length === 10 || variavel.length === 11) {
            if (variavel.length === 11) {
                variavel = variavel.replace(/^(\d{2})(\d{5})(\d{4})/, '($1)$2-$3');
            } else {
                variavel = variavel.replace(/^(\d{2})(\d{4})(\d{4})/, '($1)$2-$3');
            }
            $("#telefone").val(variavel);
        } 
    });
});



function Enviar() {

    var nome = $("#nome").val();
    var cidade = $("#cidade").val();
    var estado = $("#estado").val();
    var email = $("#email").val();
    var telefone = $("#telefone").val();
    var funcao = $("#funcao").val();
    var escolaridade = $("#escolaridade").val();
    var graduado = $("#graduado").val();
    var objetivo = $("#objetivo").val();

    var erro = false;
    var erroMsg = "";

    if (nome.length < 2) {
        erro = true;
        erroMsg += "Nome";
    }

    if (cidade == "") {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "Cidade";
    }

    if (!filtro.test(email)) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "E-mail";
    }

    if (telefone == "" && (telefone.length != 13 || telefone.length != 14)) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "Telefone";

        if (escolaridade == "") {
            erro = true;
            if (erroMsg != "")
                erroMsg += ", ";
            erroMsg += "Escolaridade";
        }

        if (objetivo == "") {
            erro = true;
            if (erroMsg != "")
                erroMsg += ", ";
            erroMsg += "Objetivo / Experiência Profissional";
        }
    }

    if (!erro) {

        $.ajax({
            type: "POST",
            url: "/Conheca/TrabalheConoscoEnviar/",
            data: { nome: nome, email: email, telefone: telefone, estado: estado, cidade: cidade, funcao: funcao, escolaridade: escolaridade, graduado: graduado, objetivo: objetivo },
            dataType: "json",
            traditional: true,
            success: function (msg) {

                $("#erroMsg").addClass("alert alert-success").html('Enviado com sucesso!');
                setTimeout("$('#erroMsg').html('').removeClass()", 2000);

                
            }
        });

    } else {
        $("#erroMsg").addClass("alert alert-danger").html('Preencha o ' + erroMsg + ' corretamente.');

        setTimeout("$('#erroMsg').html('').removeClass()", 2000);
    }
}