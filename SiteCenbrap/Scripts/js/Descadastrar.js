$(document).ready(function () {
    $("#btn_enviar_descadastrar").click(function () {
        GravarDescadastrar();
    });      

});

function GravarDescadastrar() {
    $("#ContinuarErro").addClass("alert alert-warning").html('Aguarde...');

    var form = $("#form-desc");
    var postData = form.serialize();

    var checkBoxData = form.find('input[type=checkbox]:not(:checked)').map(function () {
        return encodeURIComponent(this.name) + '= 0';
    }).get().join('&');

    if (checkBoxData) {
        postData += "&" + checkBoxData;
    }

    $.ajax({
        type: "POST",
        url: '/Home/DescadastrarGravar/',
        data: postData,
        dataType: "json",
        traditional: true,
        success: function (json) {
            $("#ContinuarErro").addClass("alert alert-warning").html('Alteração realizada com sucesso');
        }
    });
}

function marcaTudo(chk) {
    if (chk) {
        $('input:checkbox[id^="mail_curso_"]').each(function () { this.checked = true; });
    }
}