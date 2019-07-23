$(document).ready(function () {

    $("a.btn-faq").click(function () {
        $("a.btn-faq").removeClass('active');
    });

});

function selecionaCurso(val) {
    if (val == "") {
        removeOptions(document.getElementById("lista_cidades"));
        var opt = document.createElement('option');
        opt.value = "";
        opt.innerHTML = "-- Nenhum curso selecionado --";
        document.getElementById("lista_cidades").appendChild(opt);
        $("#lista_cursos").addClass("input_azul");
        $("#lista_cidades").removeClass("input_azul");
    } else {
        $.ajax({
            type: "POST",
            url: "/FAQ/Cidades/",
            data: { curso: val },
            dataType: "json",
            traditional: true,
            success: function (msg) {
                removeOptions(document.getElementById("lista_cidades"));
                var opt = document.createElement('option');
                opt.value = "";
                opt.innerHTML = "-- Selecione o curso --";
                document.getElementById("lista_cidades").appendChild(opt);
                $.each(msg, function (index, value) {
                    var opt = document.createElement('option');
                    opt.value = value.titulo1;
                    opt.innerHTML = value.cidade;
                    document.getElementById("lista_cidades").appendChild(opt);
                });
                $("#lista_cursos").removeClass("input_azul");
                $("#lista_cidades").addClass("input_azul");
                $("#lista_cidades").focus();
            }
        });
    }
}

function abreCursoTurma(val) {
    if (val != "") {
        location.href = "/Turma/" + val + "/";
    }
}

function removeOptions(selectbox) {
    var i;
    for (i = selectbox.options.length - 1; i >= 0; i--) {
        selectbox.remove(i);
    }
}