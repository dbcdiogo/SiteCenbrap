$(document).ready(function () {

    $(".CursosSel .column").on("click", "li:not(.title)", function () {
        var t = $(this).closest("div").attr("column-type");
        var v = $(this).attr("value");
        var r = $(this).attr("turma");

        if (t == "TipoCursos") {
            $(".CursosSel .column:nth-child(1) li:not(.title)").each(function () { (v == $(this).attr("value") ? $(this).addClass("select-item") : $(this).removeClass("select-item")); })
        }
        if (t == "Cidades") {
            $(".CursosSel .column:nth-child(2) li:not(.title)").each(function () { (v == $(this).attr("value") ? $(this).addClass("select-item") : $(this).removeClass("select-item")); })
        }
        if (t == "Cursos") {                        
            $(".CursosSel .column:nth-child(3) li:not(.title)").each(function () { (v == $(this).attr("value") ? $(this).addClass("select-item") : $(this).removeClass("select-item")); })                        
        }

        var v1 = -1;
        var v2 = 0;
        var v3 = 0;

        v1 = $(".CursosSel .column:nth-child(1) li.select-item").attr("value");
        v2 = $(".CursosSel .column:nth-child(2) li.select-item").attr("value");
        v3 = $(".CursosSel .column:nth-child(3) li.select-item").attr("value");

        if (t == "Turmas") {
            location.href = "/Turma/" + r;
            //location.href = "/Inscreva/" + v;
        } else {
            $.ajax({
                type: "POST",
                url: "/Inscreva/" + t + "/",
                data: { id: v1, id2: v2, id3: v3 },
                dataType: "json",
                traditional: true,
                success: function (data) {                    
                    selTipoCurso(data);
                }
            });
        }
    });

});

function selTipoCurso(data) {
    var j = JSON.stringify(data);    
    $.each(data, function (key, item) {
        if (key == "cidades") {
            $(".CursosSel .column:nth-child(2) li:not(.title)").each(function () { $(this).remove(); })
            $.each(JSON.parse(JSON.stringify(item.Data)), function (key, item2) {
                $(".CursosSel .column:nth-child(2) ul").append("<li value='" + item2.id + "'>" + item2.titulo + "</li>");
            });
        }
        if (key == "cursos") {
            $(".CursosSel .column:nth-child(3) li:not(.title)").each(function () { $(this).remove(); })            
            $.each(JSON.parse(JSON.stringify(item.Data)), function (key, item2) {
                $(".CursosSel .column:nth-child(3) ul").append("<li value='" + item2.id + "'>" + item2.titulo + "</li>");
            });
        }
        if (key == "turmas") {
            $(".CursosSel .column:nth-child(4) li:not(.title)").each(function () { $(this).remove(); })
            $.each(JSON.parse(JSON.stringify(item.Data)), function (key, item2) {
                txt = "<li turma='" + item2.codTurma + "' value='" + item2.id + "'>" + item2.titulo + "<br />";
                if (item.ativo == 0) {
                    txt += "Me informe ao abrirem as matrículas <br />";
                }
                //txt += "<label onclick='showModal(" + item2.id + ", event)'>Mais detalhes</label></li > ";
                $(".CursosSel .column:nth-child(4) ul").append(txt);
                //$(".CursosSel .column:nth-child(4) ul").append("<li value='" + item2.id + "'><span onclick='showModal(" + item2.id + ", event);' class='glyphicon glyphicon-plus' title='Veja mais sobre o curso'></span>" + item2.titulo + "</li>");
            });
        }
    });    
}

