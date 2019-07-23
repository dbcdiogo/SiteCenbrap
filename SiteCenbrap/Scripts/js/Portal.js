$(document).ready(function () {

    $("#portal-entrar").click(function () {
        PortalEntrar();
    });

    $("#portal-login").keypress(function (e) {
        if (e.which == 13 || e.which == 9) {
            $("#portal-senha").focus();
        }
    });

    $("#portal-senha").keypress(function (e) {
        if (e.which == 13 || e.which == 9) {
            PortalEntrar();
        }
    });

});

function PortalEntrar() {

    var login = $("#portal-login").val();
    var senha = $("#portal-senha").val();
    
    var erro = false;
    var erroMsg = "";

    $("#portal-erro").removeClass().html('');

    if (login.length < 2) {
        erro = true;
        erroMsg += "Login";
    }

    if (senha.length < 2) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "Senha";
    }

    if (!erro) {
        $("#portal-erro").addClass("alert alert-warning").html('Aguarde...');
        $.ajax({
            type: "POST",
            url: "/Acesso/Login/",
            data: { login: login, senha: senha },
            dataType: "json",
            traditional: true,
            success: function (retorno) {
                if (retorno.retorno == 0) {
                    $("#portal-erro").addClass("alert alert-danger").html(retorno.mensagem);
                } else {
                    $("#portal-erro").addClass("alert alert-success").html(retorno.mensagem);
                    //window.location = "https://www.cenbrap.com.br/Portal/";
                    window.location = "https://portal.cenbrap.com.br/";

                }
            }
        });

    } else {
        $("#portal-erro").addClass("alert alert-danger").html('Preencha ' + erroMsg + ' corretamente.');
    }
}
