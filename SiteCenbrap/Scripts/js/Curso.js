$(document).ready(function () {

    $(".tabs-header a").click(function () {
        var p = $(this).attr("aria-controls") - 1;
        $(".tabs-header a").each(function (i) {
            if (i == p) { $(this).addClass('active'); } else { $(this).removeClass('active'); }
        })
    });

    //$('.cursos-banner').css('background-image', 'url(/Cursos/banner/' + $('.cursos-banner').attr('codigo') + '/?tamanho=' + $(window).width() + ')');

    $(".cursos-banner").css("background-image", "url('../../Images/cidades/" + $(".cursos-banner").attr("cidade") + ".jpg')");

});

function CopyLink() {
    $('#tempurl').removeClass('hide');
    var copyText = document.getElementById("tempurl");
    copyText.select();
    document.execCommand("copy");
    alert("URL copiada: " + copyText.value);
    $('#tempurl').addClass('hide');
}