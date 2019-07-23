$(document).ready(function () {
    
    //if ($(".cursos-banner").exists() && $(window).width() > 768) {
    //    $(".cursos-banner").height($(window).height() - 150);
    //}

    $('.div_mec, .div-pq-pos, .sobreCenbrap, .Cursos, .Contato, .ProximasAulasCanal, .Eventos').addClass("escondido").viewportChecker({
        classToAdd: 'visivel animated fadeIn',
        offset: 100
    });

    $("#newletter_ok").click(function () {
        Newsletter();
    });

    $("#ContatoNome, #ContatoEmail").keypress(function (e) {
        if (e.which == 13 || e.which == 9) {
            Contato();
        }
    });

    $("#ContatoTelefone").keypress(function (e) {
        if (e.which == 13 || e.which == 9)
            Contato();
        else {

            var variavel = $("#ContatoTelefone").val();

            variavel = variavel.replace(/\D/g, '');
            $("#ContatoTelefone").val(variavel);
            if (variavel.length === 10 || variavel.length === 11) {
                if (variavel.length === 11) {
                    variavel = variavel.replace(/^(\d{2})(\d{5})(\d{4})/, '($1)$2-$3');
                } else {
                    variavel = variavel.replace(/^(\d{2})(\d{4})(\d{4})/, '($1)$2-$3');
                }
                $("#ContatoTelefone").val(variavel);
            }
        }
    })

    $("#ContatoTelefone").keyup(function (e) {
        if (e.which == 13 || e.which == 9)
            Contato();
        else {

            var variavel = $("#ContatoTelefone").val();

            variavel = variavel.replace(/\D/g, '');
            $("#ContatoTelefone").val(variavel);
            if (variavel.length === 10 || variavel.length === 11) {
                if (variavel.length === 11) {
                    variavel = variavel.replace(/^(\d{2})(\d{5})(\d{4})/, '($1)$2-$3');
                } else {
                    variavel = variavel.replace(/^(\d{2})(\d{4})(\d{4})/, '($1)$2-$3');
                }
                $("#ContatoTelefone").val(variavel);
            }
        }
    });

    $("#ContatoOk").click(function () {
        Contato();
    });

});

function Contato() {

    $("#ContatoErro").html('');

    var nome = $("#ContatoNome").val();
    var email = $("#ContatoEmail").val();
    var telefone = $("#ContatoTelefone").val();
    var mensagem = $("#ContatoMensagem").val();

    if (filtro.test(email) && nome.length > 2 && (telefone.length == 13 || telefone.length == 14) && mensagem.length > 2) {
        $.ajax({
            type: "POST",
            url: "/Home/Contato/",
            data: { nome: nome, email: email, telefone: telefone, mensagem: mensagem },
            dataType: "json",
            traditional: true,
            success: function (msg) {

                $("#ContatoErro").addClass("alert alert-success").html('Incluído com sucesso!');
                setTimeout("$('#ContatoErro').html('').removeClass()", 2000);

            }
        });

    } else {
        $("#ContatoErro").addClass("alert alert-danger").html('Preencha o nome, e-mail, telefone e mensagem corretamente.');

        setTimeout("$('#ContatoErro').html('').removeClass()", 2000);
    }

}
