$(document).ready(function () {

    $("#Continuar").click(function () {
        Continuar();
    });
    
    $("#cep").keyup(function () {
        if ($(this).val().length == 9) {
            $.ajax({
                type: "POST",
                url: "/Inscreva/CEP/",
                data: { cep: $(this).val() },
                dataType: "json",
                traditional: true,
                success: function (retorno) {
                    if (retorno.endereco != '') {
                        $("#endereco").val(retorno.endereco);
                        $("#bairro").val(retorno.bairro);
                        $("#cidade").val(retorno.cidade);
                        $("#estado").val(retorno.estado);
                        $("#endereco, #bairro, #cidade, #estado").attr("readonly", true);
                    } else {
                        $("#endereco, #bairro, #cidade, #estado").attr("readonly", false);
                    }
                }
            });
        }
    });

});

function Continuar() {

    var cep = $("#cep").val();
    var endereco = $("#endereco").val();
    var numero = $("#numero").val();
    var complemento = $("#complemento").val();
    var bairro = $("#bairro").val();
    var cidade = $("#cidade").val();
    var estado = $("#estado").val();

    var erro = false;
    var erroMsg = "";

    if (cep.length < 2) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "CEP";
    }

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

    if (!erro) {
        //endereco += ", " + numero + ". " + complemento;
        $("#ContinuarErro").addClass("alert alert-warning").html('Aguarde...');
        $.ajax({
            type: "POST",
            url: "/Inscreva/CompletarFinalizar/",
            data: { aluno: $("#aluno").val(), cep: cep, endereco: endereco, bairro: bairro, cidade: cidade, estado: estado, numero: numero, complemento: complemento },
            dataType: "json",
            traditional: true,
            success: function (retorno) {
                if (retorno.erro) {
                    $("#ContinuarErro").addClass("alert alert-danger").html(retorno.mensagem);
               } else {
                    $("#ContinuarErro").addClass("alert alert-success").html(retorno.mensagem);
                    window.location = "/Inscreva/Contrato/" + $("#curso_codigo").val() + "/" + $("#aluno").val();
                }
            }
        });
    } else {
        $("#ContinuarErro").addClass("alert alert-danger").html('Preencha ' + erroMsg + ' corretamente.');
        scrollToBottom('ContinuarErro')
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