$(document).ready(function () {


    $("#btnEnviar").click(function () {
        Enviar();
    })

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

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function Enviar(){

    var nome = $("#nome").val();
    var email = $("#email").val();
    var telefone = $("#telefone").val();
    var curso = $("#curso").val();
    var cidade = $("#cidade").val();
    var assunto = $("#assunto").val();
    var texto = $("#texto").val();

    var erro = false;
    var erroMsg = "";

    if (nome.length < 2) {
        erro = true;
        erroMsg += "Nome";
    }

    if (!filtro.test(email)) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg = "E-mail";
    }

    if (telefone == "" && (telefone.length != 13 || telefone.length != 14)) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "Telefone";
    }

    if (assunto.length < 2) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "Assunto";
    }

    if (texto.length < 2) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "Texto";
    }

    if (!erro) {

        $.ajax({
            type: "POST",
            url: "/Home/FaleConoscoEnviar/",
            data: { nome: nome, email: email, telefone: telefone, curso: curso, cidade: cidade, assunto: assunto, texto: texto },
            dataType: "json",
            traditional: true,
            success: function (msg) {

                $("#erroMsg").addClass("alert alert-success").html('Enviado com sucesso!');
                setTimeout("$('#erroMsg').html('').removeClass()", 2000);

                var data_array = [
                    { name: 'email', value: email },
                    { name: 'identificador', value: 'FaleConosco' },
                    { name: 'token_rdstation', value: 'f82d8f17ef68b5b28c0b60fb3d2995bf' },
                    { name: 'nome', value: nome },
                    { name: 'cidade', value: cidade },
                    { name: 'traffic_source', value: getCookie("__trf.src") }
                ];

                console.log("RdIntegration");

                RdIntegration.post(data_array, function () { });
            }
        });

    } else {
        $("#erroMsg").addClass("alert alert-danger").html('Preencha o ' + erroMsg + ' corretamente.');

        setTimeout("$('#erroMsg').html('').removeClass()", 2000);
    }
}