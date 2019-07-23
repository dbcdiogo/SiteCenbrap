$(document).ready(function () {

    $("#CadastroOk").click(function () {
        CadastroOk();
    });

    $("#CadastradoEntrar").click(function () {
        CadastradoEntrar();
    });

    $("#CadastradoEsqueceu").click(function () {
        $("#form_envio").toggle();
    });

    $("#CadastroEnviaSenha").click(function () {
        CadastroEnviaSenha();
    })

    $("#cep").keyup(function () {
        if ($(this).val().length == 9) {
            $.ajax({
                type: "POST",
                url: "/Inscreva/CEP/",
                data: { cep: $(this).val() },
                dataType: "json",
                traditional: true,
                success: function (retorno) {
                    $("#cep1, #cep2, #cep3, #cep4, #cep5, #cep6").removeClass("hide");
                    if (retorno.endereco != '') {
                        $("#endereco").val(retorno.endereco);
                        $("#bairro").val(retorno.bairro);
                        $("#cidade").val(retorno.cidade);
                        $("#estado").val(retorno.estado);
                        $("#endereco, #bairro, #cidade, #estado").attr("readonly", false);
                        $("#errorcep").html("");
                    } else {
                        $("#endereco").val("");
                        $("#bairro").val("");
                        $("#cidade").val("");
                        $("#estado").val("");
                        $("#endereco, #bairro, #cidade, #estado").attr("readonly", false);
                        $("#errorcep").html("CEP não encontrado");
                    }
                }
            });
        } else {
            $("#errorcep").html("");
        }
    });

});

function CadastroEnviaSenha() {
    var email = $("#email_envio").val();

    var erro = false;
    var erroMsg = "";

    if (email.length < 5) {
        erro = true;
        erroMsg += "E-mail";
    }

    $("#CadastradoErro").removeClass().html('');

    if (!erro) {
        $.ajax({
            type: "POST",
            url: "/Inscreva/Esqueceu/",
            data: { esqueceu: email },
            dataType: "json",
            traditional: true,
            success: function (retorno) {
                if (retorno.retorno == 0) {
                    $("#CadastradoErro").addClass("alert alert-danger").html(retorno.mensagem);
                } else {
                    $("#CadastradoErro").addClass("alert alert-success").html('Enviado para o e-mail cadastrado.');
                }
            }
        });
    } else {
        $("#CadastradoErro").addClass("alert alert-danger").html('Preencha ' + erroMsg + ' corretamente.');
    }

}

function CadastradoEntrar() {

    var login = $("#CadastradoLogin").val();
    var senha = $("#CadastradoSenha").val();
    
    var erro = false;
    var erroMsg = "";

    $("#CadastradoErro").removeClass().html('');

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
        $("#CadastradoErro").addClass("alert alert-warning").html('Aguarde...');
        $.ajax({
            type: "POST",
            url: "/Inscreva/Login/",
            data: { login: login, senha: senha },
            dataType: "json",
            traditional: true,
            success: function (retorno) {
                if (retorno.retorno == 0) {
                    $("#CadastradoErro").addClass("alert alert-danger").html(retorno.mensagem);
                } else {
                    tags = $("#titulo_curso_link").val() + ", " + $("#cidade_link").val();
                    var data_array = [
                        { name: 'email', value: retorno.link },
                        { name: 'identificador', value: 'Inscricao' },
                        { name: 'token_rdstation', value: 'f82d8f17ef68b5b28c0b60fb3d2995bf' },
                        { name: 'tags', value: tags }
                    ];

                    RdIntegration.post(data_array, function () { });
                }
                if (retorno.retorno == 1){
                    $("#CadastradoErro").addClass("alert alert-success").html(retorno.mensagem);
                    //window.location = "/Turma/" + $("#curso_codigo").val() + "/Contrato/" + retorno.id;
                    window.location = "/Inscreva/Contrato/" + $("#curso_codigo").val() + "/" + retorno.id;
                }
                if (retorno.retorno == 2) {
                    $("#CadastradoErro").addClass("alert alert-success").html(retorno.mensagem);
                    //window.location = "/Turma/" + $("#curso_codigo").val() + "/Completar/" + retorno.id;
                    window.location = "/Inscreva/Completar/" + $("#curso_codigo").val() + "/" + retorno.id;
                }
            }
        });

    } else {
        $("#CadastradoErro").addClass("alert alert-danger").html('Preencha ' + erroMsg + ' corretamente.');
    }
}

function CadastroOk() {

    var nome = $("#nome").val();
    var cpf = $("#cpf").val();
    var sexo = $("#sexo").val();
    var email = $("#email").val();
    var emailc = $("#emailc").val();
    var ddd = $("#ddd_celular").val();
    var celular = $("#celular").val();

    var erro = false;
    var erroMsg = "";

    if (nome.length < 2) {
        erro = true;
        erroMsg += "Nome completo";
    } else {
        if (nome.indexOf(" ") < 0) {
            erro = true;
            erroMsg += "Nome completo com sobrenome";
        }
    }

    if (cpf.length < 2) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "CPF";
    }

    if (sexo.length < 2) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "Sexo";
    }

    if (!filtro.test(email)) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "E-mail";
    }

    if (!filtro.test(emailc)) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "Confirmar E-mail";
    }

    if (email != emailc) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "E-mail e confirmação devem ser iguais";
    }

    if ((ddd.length < 2) || (celular.length < 8)) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "Celular com DDD";
    }

    if ($("#rg").length) {
        var rg = $("#rg").val();
        var rg_emissor = $("#rg_emissor").val();
        var data_nascimento = $("#data_nascimento").val();
        var cep = $("#cep").val();
        var endereco = $("#endereco").val();
        var bairro = $("#bairro").val();
        var cidade = $("#cidade").val();
        var estado = $("#estado").val();
        var numero = $("#numero").val();
        var complemento = $("#complemento").val();
        var conheceu = $("#conheceu").val();
        var numero = $("#numero").val();
        var complemento = $("#complemento").val();

        if (rg.length < 2) {
            erro = true;
            if (erroMsg != "")
                erroMsg += ", ";
            erroMsg += "RG";
        }

        if (rg_emissor.length < 2) {
            erro = true;
            if (erroMsg != "")
                erroMsg += ", ";
            erroMsg += "RG Emissor";
        }

        if (data_nascimento.length < 2) {
            erro = true;
            if (erroMsg != "")
                erroMsg += ", ";
            erroMsg += "Data de Nascimento";
        }

        if (cep.length < 2) {
            erro = true;
            if (erroMsg != "")
                erroMsg += ", ";
            erroMsg += "CEP";
        }

        if (!$("#cep1").hasClass("hide")) {
            if (endereco.length < 2) {
                erro = true;
                if (erroMsg != "")
                    erroMsg += ", ";
                erroMsg += "Endereço";
            }
            if (bairro.length < 2) {
                erro = true;
                if (erroMsg != "")
                    erroMsg += ", ";
                erroMsg += "Bairro";
            }
            if (cidade.length < 2) {
                erro = true;
                if (erroMsg != "")
                    erroMsg += ", ";
                erroMsg += "Cidade";
            }
            if (estado.length < 2) {
                erro = true;
                if (erroMsg != "")
                    erroMsg += ", ";
                erroMsg += "Estado";
            }
            if (numero.length < 1) {
                erro = true;
                if (erroMsg != "")
                    erroMsg += ", ";
                erroMsg += "Número";
            }
        }

        if (conheceu.length < 2) {
            erro = true;
            if (erroMsg != "")
                erroMsg += ", ";
            erroMsg += "Como nos conheceu";
        }

        //if (numero.length >= 1) {
        //    $("#endereco").val($("#endereco").val() + ', ' + numero);
        //}

        //if (complemento.length >= 1) {
        //    $("#endereco").val($("#endereco").val() + ', ' + complemento);
        //}
    }

    if (!erro) {
        $("#CadastradoErro2").addClass("alert alert-warning").html('Aguarde...');
        $.ajax({
            type: "POST",
            url: "/Inscreva/Cadastro/",
            data: $('.matricula-direita .row :input').serialize(),
            dataType: "json",
            traditional: true,
            success: function (retorno) {
                if (retorno.erro) {
                    $("#CadastradoErro2").addClass("alert alert-danger").html(retorno.mensagem);
                } else {
                    tags = $("#titulo_curso_link").val() + ", " + $("#cidade_link").val();
                    var data_array = [
                        { name: 'email', value: email },
                        { name: 'identificador', value: 'Inscricao' },
                        { name: 'token_rdstation', value: 'f82d8f17ef68b5b28c0b60fb3d2995bf' },
                        { name: 'nome', value: nome },
                        { name: 'tags', value: tags }
                    ];

                    RdIntegration.post(data_array, function () { });

                    $("#CadastradoErro2").addClass("alert alert-success").html(retorno.mensagem);
                    window.location = "/Inscreva/Contrato/" + $("#curso").val() + "/" + retorno.id;
                }
            }
        });
    } else {
        $("#CadastradoErro2").addClass("alert alert-danger").html('Preencha ' + erroMsg + ' corretamente.');
        scrollToBottom('CadastradoErro2')
    }
}

function scrollToBottom(id) {
    div_height = $("#" + id).height();
    div_offset = $("#" + id).offset().top;
    window_height = $(window).height();
    $('html,body').animate({
        scrollTop: div_offset - window_height + div_height
    }, 'slow');
}

