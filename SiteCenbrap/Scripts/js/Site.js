jQuery.fn.exists = function () { return this.length > 0; }

function checkScroll() {

    var startY = $('.topo').height() * 1; //The point where the navbar changes in px

    if ($(window).scrollTop() > startY) {
        $('.topo').addClass("scrolled");
    } else {
        $('.topo').removeClass("scrolled");
    }
}

if ($('.topo').length > 0) {
    $(window).on("scroll load resize", function () {
        checkScroll();
    });
}

var filtro = /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$/i;

function EnterProximoCampo(item1, item2) {
    $(item1).keypress(function (e) {
        if (e.which == 13 || e.which == 9) {
            $(item2).focus();
        }
    });
}

function isDate(value) {
    var dateFormat;
    if (toString.call(value) === '[object Date]') {
        return true;
    }
    if (typeof value.replace === 'function') {
        value.replace(/^\s+|\s+$/gm, '');
    }
    dateFormat = /(^\d{1,4}[\.|\\/|-]\d{1,2}[\.|\\/|-]\d{1,4})(\s*(?:0?[1-9]:[0-5]|1(?=[012])\d:[0-5])\d\s*[ap]m)?$/;
    return dateFormat.test(value);
}

var largura = 0;
var largura1 = 0;
var banner;

$(document).ready(function () {

    $(window).on('beforeunload', function () {
        $(window).scrollTop(0);
    });

    if ($(".div-formulario-cursos").exists()) {
        //AbrirForm();
    }

    if ($("#mapa-cidade").exists()) {
        largura1 = $("#mapa-cidade").parent().width();
    }

    if ($(".banner").exists() && $(window).width() > 768) {
        $(".banner").height(500);
    }

    banner = setInterval(bannerRotator, 5000);

    if ($(".mapa .img-responsive").exists()) {
        $(".mapa-esquerda").height($(".mapa .img-responsive").height());
    }

    $("#newsletter").keypress(function (e) {
        if (e.which == 13 || e.which == 9) {
            Newsletter();
        }
    });

    $("#newletter_ok").click(function () {
        Newsletter();
    });

    $("#LigamosNome, #LigamosEmail").keypress(function (e) {
        if (e.which == 13 || e.which == 9) {
            Ligamos();
        }
    });

    $("#LigamosTelefone").keypress(function (e) {
        if (e.which == 13 || e.which == 9)
            Ligamos();
        else {

            var variavel = $("#LigamosTelefone").val();

            variavel = variavel.replace(/\D/g, '');
            $("#LigamosTelefone").val(variavel);
            if (variavel.length === 10 || variavel.length === 11) {
                if (variavel.length === 11) {
                    variavel = variavel.replace(/^(\d{2})(\d{5})(\d{4})/, '($1)$2-$3');
                } else {
                    variavel = variavel.replace(/^(\d{2})(\d{4})(\d{4})/, '($1)$2-$3');
                }
                $("#LigamosTelefone").val(variavel);
            }
        }
    })

    $("#LigamosTelefone").keyup(function (e) {
        if (e.which == 13 || e.which == 9)
            Ligamos();
        else {

            var variavel = $("#LigamosTelefone").val();

            variavel = variavel.replace(/\D/g, '');
            $("#LigamosTelefone").val(variavel);
            if (variavel.length === 10 || variavel.length === 11) {
                if (variavel.length === 11) {
                    variavel = variavel.replace(/^(\d{2})(\d{5})(\d{4})/, '($1)$2-$3');
                } else {
                    variavel = variavel.replace(/^(\d{2})(\d{4})(\d{4})/, '($1)$2-$3');
                }
                $("#LigamosTelefone").val(variavel);
            }
        }
    });

    $("#LigamosOk").click(function () {
        Ligamos();
    });

    $(".portal-aluno").click(function () {
        Modal('/Acesso/', 0, 'Portal do aluno');
    });

    //    $(".ms-drop").css("width", largura + "px");
    $(".mapa-esquerda .ms-drop").css("width", largura1 + "px");

    $('.banner-msg, .sobreCenbrap, .mapa, .Cursos, .Ligamos, .ProximasAulasCanal, .Eventos').addClass("escondido").viewportChecker({
        classToAdd: 'visivel animated fadeIn',
        offset: 100
    });

    $("#Cidade-OK").click(function () {
        var cidade = $("#mapa-cidade").val();

        if (cidade != "" && cidade != "null" && cidade != null && cidade != undefined)
            window.location = "/Cidades/" + cidade + "/";
    });

    //Cursos banner
    if ($(".cursos-banner").exists() && $(window).width() > 768) {
        $(".cursos-banner").height(300);

        //$(".cursos-banner .btn-pos").css("marginTop", 100);
    }

});

$(".banner .arrow_left").click(function (event) {
    event.stopPropagation();
    bannerMove(-1);
});

$(".banner .arrow_right").click(function (event) {
    event.stopPropagation();
    bannerMove(1);
});

$(".banner").click(function (event) {
    location.href = $(".banner").not(".hide").attr("link");
});

function bannerMove(p) {
    clearInterval(banner);
    var pos = $(".banner").not(".hide").attr("position");
    $(".banner[position='" + pos + "']").addClass("hide");
    pos = parseInt(pos) + parseInt(p);
    var max = $(".banner").length;
    if (pos > max) { pos = 1; }
    if (pos < 1) { pos = max; }
    $(".banner[position='" + pos + "']").removeClass("hide");
    banner = setInterval(bannerRotator, 5000);

//    var pos = $(".banner").attr("position");
//    pos = parseInt(pos) + parseInt(p);
//    if (pos > 8) { pos = 1; }
//    if (pos < 1) { pos = 8; }
//    $(".banner").attr("position", pos);
//    $(".banner").css("background-image", "url('../Images/banners/" + pos + ".jpg?1')");
//    clearInterval(banner);
//    if (pos == 1) { $(".banner").attr("link", "Turma/EADPPTPED1") }
//    if (pos == 2) { $(".banner").attr("link", "Turma/IMMT4GYN") }
//    if (pos == 3) { $(".banner").attr("link", "Conheca") }
//    if (pos == 4) { $(".banner").attr("link", "Cursos/Nutrologia") }
//    if (pos == 5) { $(".banner").attr("link", "Cursos/EstimulacaoMagneticaTranscraniana") }
//    if (pos == 6) { $(".banner").attr("link", "Turma/EADPPTEN1") }
//    if (pos == 7) { $(".banner").attr("link", "Conheca") }
//    if (pos == 8) { $(".banner").attr("link", "Turma/EADPPTMT6") }
//    banner = setInterval(bannerRotator, 5000);
}

function bannerRotator() {
    var pos = $(".banner").not(".hide").attr("position");
    $(".banner[position='" + pos + "']").addClass("hide");
    pos = parseInt(pos) + 1;
    var max = $(".banner").length;
    if (pos > max) { pos = 1; }
    if (pos < 1) { pos = max; }
    $(".banner[position='" + pos + "']").removeClass("hide");

//    var pos = $(".banner").attr("position");
//    pos = parseInt(pos) + 1;
//    if (pos > 8) { pos = 1; }
//    if (pos == 1) { $(".banner").attr("link", "Turma/EADPPTPED1") }
//    if (pos == 2) { $(".banner").attr("link", "Turma/IMMT4GYN") }
//    if (pos == 3) { $(".banner").attr("link", "Conheca") }
//    if (pos == 4) { $(".banner").attr("link", "Cursos/Nutrologia") }
//    if (pos == 5) { $(".banner").attr("link", "Cursos/EstimulacaoMagneticaTranscraniana") }
//    if (pos == 6) { $(".banner").attr("link", "Turma/EADPPTEN1") }
//    if (pos == 7) { $(".banner").attr("link", "Conheca") }
//    if (pos == 8) { $(".banner").attr("link", "Turma/EADPPTMT6") }
//    $(".banner").attr("position", pos);
//    $(".banner").css("background-image", "url('../Images/banners/" + pos + ".jpg?1')");
}

function Form() {

    if ($(".formulario-cursos").exists()) {
        if ($("#form_cidade").exists()) {
            largura = $("#form_cidade").parent().width();
        }
        FormTopo(false);
        Selects("#form_cidade", "");
        Selects("#form_curso", "");
        Selects("#mapa-cidade", "");

        FormPosition();
        FormTipo(0);
    }

}

function FormPosition() {
    $('html, body').animate({
        scrollTop: 0
    }, 800);
}

function AbrirForm(shake) {

    //pagina inicial
    if ($(".div-formulario-cursos").exists()) {
        $.ajax({
            type: "POST",
            url: "/Home/Formulario/",
            dataType: "html",
            traditional: true,
            success: function (msg) {
                $(".div-formulario-cursos").html(msg);
                if (shake == 1) {
                    $(".div-formulario-cursos").effect("shake");
                }
                Form();

            }
        });
    }
    //pagina internas
    else {
        if ($("#CollapseCursos .formulario-cursos").exists()) {
            $("#CollapseCursos").collapse('toggle');
            FormPosition();
        } else {
            $.ajax({
                type: "POST",
                url: "/Home/Formulario/",
                dataType: "html",
                traditional: true,
                success: function (msg) {
                    $("#CollapseCursos").html(msg).collapse('toggle');
                    Form();
                }
            });
        }

    }
}

function GerarBoleto(id, curso) {
    $.ajax({
        type: "POST",
        url: "/Inscricao/Boleto/",
        data: { id: id, curso: curso },
        dataType: "json",
        traditional: true,
        success: function (msg) {

            $("#MsgLink").html("<a class='btn btn-success btn-lg' href='" + msg.link + "'>CLIQUE AQUI PARA VISUALIZAR O BOLETO</a>");

        }
    });
}

function GerarCartao(id, curso) {
    $.ajax({
        type: "POST",
        url: "/Inscricao/Cartao/",
        data: { id: id, curso: curso },
        dataType: "json",
        traditional: true,
        success: function (msg) {
            $("#MsgLink").html("<a class='btn btn-success btn-lg' href='" + msg.link + "'>CLIQUE AQUI PARA IR AO SITE DA CIELO E REALIZAR O PAGAMENTO SEGURO COM CARTÃO</a>");
        }
    });
}

function ConverterData(value) {
    return new Date(parseInt(value.substr(6)));
}

function DataJson(value) {
    dia = value.getDate();
    mes = (value.getMonth() + 1);
    ano = value.getFullYear();

    if (dia.length == 1)
        dia = "0" + dia;

    if (mes.length == 1)
        mes = "0" + mes;

    return dia + "/" + mes + "/" + ano;
}

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

function Newsletter() {

    $(".newsletter-span").html('');

    var email = $("#newsletter").val();

    if (filtro.test(email)) {
        $.ajax({
            type: "POST",
            url: "/Home/Newsletter/",
            data: { email: email },
            dataType: "json",
            traditional: true,
            success: function (msg) {

                $(".newsletter-span").html('<span class="alert alert-success">Incluído com sucesso!</span>');
                setTimeout("$('.newsletter-span').html('')", 2000);

                var data_array = [
                    { name: 'email', value: email },
                    { name: 'identificador', value: 'FormRecebaNovidades' },
                    { name: 'token_rdstation', value: 'f82d8f17ef68b5b28c0b60fb3d2995bf' },
                    { name: 'traffic_source', value: getCookie("__trf.src") }
                ];

                RdIntegration.post(data_array, function () { });
            }
        });

    } else {
        $(".newsletter-span").html('<span class="alert alert-danger">Preencha o e-mail</span>');

        setTimeout("$('.newsletter-span').html('')", 2000);

    }

}

function Ligamos() {

    $("#LigamosErro").html('');

    var nome = $("#LigamosNome").val();
    var email = $("#LigamosEmail").val();
    var telefone = $("#LigamosTelefone").val();

    if (filtro.test(email) && nome.length > 2 && (telefone.length == 13 || telefone.length == 14)) {
        $.ajax({
            type: "POST",
            url: "/Home/Ligamos/",
            data: { nome: nome, email: email, telefone: telefone },
            dataType: "json",
            traditional: true,
            success: function (msg) {

                $("#LigamosErro").addClass("alert alert-success").html('Incluído com sucesso!');
                setTimeout("$('#LigamosErro').html('').removeClass()", 2000);

                var data_array = [
                    { name: 'email', value: email },
                    { name: 'identificador', value: 'LigamosParaVoceHome' },
                    { name: 'token_rdstation', value: 'f82d8f17ef68b5b28c0b60fb3d2995bf' },
                    { name: 'nome', value: nome }
                ];

                RdIntegration.post(data_array, function () { });
            }
        });

    } else {
        $("#LigamosErro").addClass("alert alert-danger").html('Preencha o nome, e-mail e telefone corretamente.');

        setTimeout("$('#LigamosErro').html('').removeClass()", 2000);
    }

}

function Modal(url, id, title) {

    $.ajax({
        type: "POST",
        url: url,
        data: { id: id },
        dataType: "html",
        traditional: true,
        success: function (msg) {

            //$(".modal-title").html(title);
            $("#myModal1 .modal-body").html(msg);
            $("#myModal1").modal();

        }
    });

}

function FormTipo(tipo) {
    tipo = parseInt(tipo);
    $(".form-tipo").val(tipo);
    $(".form-cidade").val(0);
    $(".form-curso").val(0);

    if ($("#pos-graduacao").hasClass("btn-tipo-active")) {
        $("#pos-graduacao").removeClass("btn-tipo-active").addClass("btn-tipo");
    }
    if ($("#workshop").hasClass("btn-tipo-active")) {
        $("#workshop").removeClass("btn-tipo-active").addClass("btn-tipo");
    }
    if ($("#ead").hasClass("btn-tipo-active")) {
        $("#ead").removeClass("btn-tipo-active").addClass("btn-tipo");
    }

    if (tipo == 0) {
        $("#pos-graduacao").addClass("btn-tipo-active").removeClass("btn-tipo");
        $(".div-cidade").show();
        $(".div-cidade .ms-choice").addClass("bgGray");
        $(".div-curso .ms-choice").removeClass("bgGray");
    }
    if (tipo == 1) {
        $("#workshop").addClass("btn-tipo-active").removeClass("btn-tipo");
        $(".div-cidade").show();
        $(".div-cidade .ms-choice").addClass("bgGray");
        $(".div-curso .ms-choice").removeClass("bgGray");
    }
    if (tipo == 2) {
        $("#ead").addClass("btn-tipo-active").removeClass("btn-tipo");
        $(".div-cidade").hide();
        $(".div-curso .ms-choice").addClass("bgGray");
    }

    FormTopo(false);
}

function FormTopo(abrir) {

    tipo = $(".form-tipo").val();
    cidade = $(".form-cidade").val();
    curso = $(".form-curso").val();

    $.ajax({
        type: "POST",
        url: "/Home/Form",
        data: { tipo: tipo, cidade: cidade, curso: curso },
        dataType: "json",
        traditional: true,
        success: function (json) {
            var txt = "";
            for (var i = 0; i < json.cidades.length; i++) {
                txt += "<option value='" + json.cidades[i].id + "'";
                if (json.cidades[i].id == cidade)
                    txt += " selected"
                txt += ">" + json.cidades[i].titulo + "</option>";
            }
            $("#form_cidade").html(txt);
            Selects("#form_cidade", cidade);
            txt = "";
            temp = "";
            for (var i = 0; i < json.cursos.length; i++) {

                data_inicio = ConverterData(json.cursos[i].data_inicio);
                ativo = json.cursos[i].ativo;

                if (tipo == 2) {
                    if (temp != json.cursos[i].grupoead) {
                        if (temp != "") {
                            txt += "</optgroup>";
                        }
                        txt += "<optgroup label='" + json.cursos[i].grupoead + "'>";
                        temp = json.cursos[i].grupoead;
                    }
                }

                txt += "<option value='" + json.cursos[i].id + "'";
                if (json.cursos[i].id == curso)
                    txt += " selected"
                txt += " codTurma='" + json.cursos[i].codTurma + "'>" + json.cursos[i].titulo;

                if (data_inicio < new Date()) {
                    txt += " - Turma em andamento iniciada em " + DataJson(data_inicio) + "";
                } else {
                    if (json.cursos[i].inicio_confirmado) {
                        txt += " - Início confirmado para " + DataJson(data_inicio) + "";
                    } else {
                        if (ativo == 1) {
                            txt += " - Início previsto para " + DataJson(data_inicio) + "";
                        } else {
                            txt += " - Faça sua pré-reserva";
                        }
                    }
                }
                if (json.cursos[i].ultimas_vagas) {
                    txt += " - Últimas vagas ";
                }
                txt += "</option>";

            }

            if (tipo == 2) {
                txt += "</optgroup>";
            }

            $("#form_curso").html(txt);

            Selects("#form_curso", curso);


        }
    });

}

function Curso(id) {
    if (id != null && id != "")
        window.location = "/Curso/" + id + "/";
}

function CursoCod(cod) {
    if (cod != null && cod != "")
        window.location = "/Turma/" + cod + "/";
}

function Selects(campo, valores) {

    if (valores != null && valores != '') {
        $(campo).val(valores);
    }

    $(campo).multipleSelect({
        filter: true,
        single: true,
        multiple: false,
        keepOpen: false,
        placeholder: $(campo).attr("title"),
        width: $(campo).parent().width(),
        height: 34,
        onClose: function () {
            if (($(campo).val() != null && $(campo).val() != '')) {
                $(campo.replace("#", ".").replace("_", "-")).val($(campo).multipleSelect("getSelects"));

                if (campo == "#form_curso") {
                    CursoCod($("#form_curso option[value='" + $(campo.replace("#", ".").replace("_", "-")).val() + "']").attr("codTurma"));
                    //Curso($(campo.replace("#", ".").replace("_", "-")).val());
                }
                else {
                    FormTopo(true);
                    $(".div-cidade .ms-choice").removeClass("bgGray");
                    $(".div-curso .ms-choice").addClass("bgGray");
                }
            }
        }
    });
}

function showModal(c, e) {
    $("#myModal2 .modal-body").html("Carregando conteúdo ...");
    $("#myModal2 .modal-body").load("/Curso/" + c + "/ .IconeCursos, .tabs, .Disciplinas, .professores, .Investimento", function () {
        $("#myModal2 .tabs-header a").click(function () {
            var p = $(this).attr("aria-controls") - 1;
            $("#myModal2 .tabs-header a").each(function (i) {
                if (i == p) { $(this).addClass('active'); } else { $(this).removeClass('active'); }
            })
        });
    });
    $("#myModal2").modal();
    e.stopPropagation();
    return false;
}

function collapseMenu() {
    if ($('.navbar-toggle').css('display') == 'block') { $('.navbar-toggle').click(); }
}