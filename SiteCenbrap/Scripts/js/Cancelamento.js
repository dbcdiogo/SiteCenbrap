$(document).ready(function () {

    $("#btn_enviar_comunicado").click(function () {
        EnviarComunicado();
    });
    
    
});

function mudaCurso(v) {
    if (v > 0) {
        $("input[name=idtipo][value=2]").prop("checked", true);
    }
}

function dados() {
    $("input[name=idtipo][value=3]").prop("checked", true);
}

function limpa(i) {
    if (i == 1) { $('#dados').val(''); $('#idcurso').val(0); }
    if (i == 2) { $('#dados').val(''); }
    if (i == 3) { $('#idcurso').val(0); }
    if (i == 4) { $('#dados').val(''); $('#idcurso').val(0); }
}

function EnviarComunicado() {

    var tipo = $("#idtipo:checked").val();
    var curso = $("#idcurso").val();
    var dados = $("#dados").val();
    var codturma = $("#codturma").val();
    var codaluno = $("#codaluno").val();

    var erro = false;
    var erroMsg = "";

    if ((tipo == 2) && (curso == 0)) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "Selecione o curso!";
    }

    if ((tipo == 3) && (dados.length == "")) {
        erro = true;
        if (erroMsg != "")
            erroMsg += ", ";
        erroMsg += "Informe os dados para reembolso!";
    }    

    if (!erro) {
        $("#ContinuarErro").addClass("alert alert-warning").html('Aguarde...');
        $.ajax({
            type: "POST",
            url: "/Home/CancelamentoFinalizar/",
            data: { tipo: tipo, curso: curso, dados: dados, turma: codturma, aluno: codaluno },
            dataType: "json",
            traditional: true,
            success: function (retorno) {
                $("#ContinuarErro").addClass("alert alert-success").html(retorno);
            }
        });
    } else {
        $("#ContinuarErro").addClass("alert alert-danger").html(erroMsg);
        scrollToBottom('ContinuarErro')
    }
}
