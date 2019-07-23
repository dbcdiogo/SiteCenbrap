$(document).ready(function () {

    $("#categoria").multipleSelect({
        filter: true,
        single: true,
        multiple: false,
        keepOpen: false,
        placeholder: "Categoria",
        width: $("#categoria").parent().width(),
        height: 34,
        onClose: function () {
            window.location = "/Blog/?categoria=" + $("#categoria").val();
        }
    });

    $("#busca").change(function () {
        window.location = "/Blog/?busca=" + $("#busca").val();
    });

});

function mudaCategoria(v) {
    window.location = "/Blog/?categoria=" + v;
}
