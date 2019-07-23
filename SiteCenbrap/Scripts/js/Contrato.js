function GerarBoleto(id, curso) {
    if ($("#termo_aceite").is(":not(:checked)")) { alert("Para prosseguir com a inscrição, é preciso aceitar os Termos de Ciência e Compromisso e a Política de Privacidade"); return false; }
    if (!$("#dv_cupom").hasClass("hide")) {
        if ($("#termo_cupom").is(":not(:checked)")) { alert("Para prosseguir com a inscrição, é preciso aceitar o Regulamento para utilização do cupom de Desconto"); return false; }
    }
    $.ajax({
        type: "POST",
        url: "/Inscreva/Boleto/",
        data: { id: id, curso: curso, cupom: $("#cupomDesconto").val() },
        dataType: "json",
        traditional: true,
        success: function (msg) {
            //window.location = msg.link;
            $("#MsgLink").html("<a class='btn btn-success btn-lg' onclick=\"return gtag_report_conversion('" + msg.link + "');\" href='" + msg.link + "'>CLIQUE AQUI PARA VISUALIZAR O BOLETO</a>");
        }
    });
}

function GerarCartao(id, curso) {
    if ($("#termo_aceite").is(":not(:checked)")) { alert("Para prosseguir com a inscrição, é preciso aceitar os Termos de Ciência e Compromisso e a Política de Privacidade"); return false; }
    $.ajax({
        type: "POST",
        url: "/Inscreva/Cartao/",
        data: { id: id, curso: curso },
        dataType: "json",
        traditional: true,
        success: function (msg) {
            //window.location = msg.link;
            $("#MsgLink").html("<a class='btn btn-success btn-lg' onclick=\"return gtag_report_conversion('" + msg.link + "');\" href='" + msg.link + "'>CLIQUE AQUI PARA IR AO SITE DA CIELO E REALIZAR O PAGAMENTO SEGURO COM CARTÃO</a>");
        }
    });
}

function GerarPagseguro(id, curso) {
    if ($("#termo_aceite").is(":not(:checked)")) { alert("Para prosseguir com a inscrição, é preciso aceitar os Termos de Ciência e Compromisso e a Política de Privacidade"); return false; }
    $.ajax({
        type: "POST",
        url: "/Inscreva/Pagseguro/",
        data: { id: id, curso: curso },
        dataType: "json",
        traditional: true,
        success: function (msg) {
            //window.location = msg.link;
            $("#MsgLink").html("<a class='btn btn-success btn-lg' onclick=\"return gtag_report_conversion('" + msg.link + "');\" href='" + msg.link + "'>CLIQUE AQUI PARA IR AO AMBIENTE DO PAGSEGURO E REALIZAR O PAGAMENTO COM CARTÃO</a>");
        }
    });
}

function aplicarCupom() {
    cupom = $("#cupomDesconto").val();
    aluno = $("#aluno_id").val();
    if (cupom == "") {
        alert("Informe o código do cupom");
        $("#dv_cupom").addClass("hide");
        $("#resultadocupom").html("");
        $("#vl1").removeClass("riscado");
        $("#vl2").html("");
        $("#termo_cupom").checked("false");
    } else {
        $.ajax({
            type: "POST",
            url: "/Inscreva/CupomDesconto/",
            data: { cupom: cupom, aluno: aluno },
            dataType: "json",
            traditional: true,
            success: function (msg) {
                if (msg == 1) {
                    $("#dv_cupom").removeClass("hide");
                    $("#resultadocupom").html("<font color='green'>Cupom 20% de desconto</font>");
                    $("#vl1").addClass("riscado");
                    valor = (parseFloat($("#vl1").html()) * 20) / 100;
                    $("#vl2").html((parseFloat($("#vl1").html()) - parseFloat(valor)).toFixed(2).replace(".",","));
                } else {
                    if (msg == 2) {
                        $("#dv_cupom").addClass("hide");
                        $("#resultadocupom").html("<font color='red'>Cupom já utilizado</font>");
                        $("#vl1").removeClass("riscado");
                        $("#vl2").html("");
                        $("#termo_cupom").checked("false");
                    } else {
                        $("#dv_cupom").addClass("hide");
                        $("#resultadocupom").html("<font color='red'>Cupom inválido</font>");
                        $("#vl1").removeClass("riscado");
                        $("#vl2").html("");
                        $("#termo_cupom").checked("false");
                    }
                }
            }
        });
    }
}

function showModalContrato(c) {

    cupom = "Regulamento Cupom de desconto #PPP2019<br><Br>";
    cupom += "<p style='text-align:justify'><b>1. Das condições de participação no Programa Primeira Pós 2019:</b><Br>";
    cupom += "1.1.O cupom de desconto #PPP2019, que dá acesso ao Programa Primeira Pós 2019, aplica-se aos inscritos, graduados em Medicina em curso devidamente reconhecido pelo MEC, cuja data de colação de grau seja de até noventa dias anteriores à efetivação da matrícula no site www.cenbrap.com.br.<Br>";
    cupom += "1.2.Graduados em Medicina no exterior que apresentarem a devida convalidação do diploma, datada de até noventa dias anteriores à efetivação da matrícula, também farão jus ao benefício do cupom #PPP2019.<Br>";
    cupom += "<b>2. Do benefício:</b><Br>";
    cupom += "2.1 O cupom #PPP2019 dará direito exclusivamente aos matriculados que se enquadrarem no item 1.1 ou 1.2 de desconto de 20 % sobre o valor total do curso, incluindo a taxa de matrícula vigente.<Br>";
    cupom += "2.2 O cupom é válido para matrícula em apenas um curso de pós-graduação da Faculdade CENBRAP.<Br>";
    cupom += "<b>3. Da efetivação da matrícula:</b><Br>";
    cupom += "3.1 Entende-se por efetivação da matrícula, o inscrito que preencher corretamente todos os campos solicitados nas páginas do site, concordar com o Termo de Compromisso e Contrato de Prestação de Serviços, efetuar o pagamento da matrícula e apresentar documento comprobatório da data de colação de grau (ou convalidação do diploma) no primeiro dia de aula.<Br>";
    cupom += "3.2 O supracitado prazo de 90 dias contar-se-á, em dias corridos, a partir da data de colação de grau (ou convalidação do diploma) até a data de quitação do pagamento da matrícula, independente da data de início do curso.<Br>";
    cupom += "<b>4. Da documentação comprobatória:</b><Br>";
    cupom += "4.1 Para fins de comprovação, serão aceitos somente fotocópias do diploma de graduação emitido por faculdade de Medicina reconhecida pelo MEC (ou documento reconhecido no Brasil para fins de convalidação de diploma estrangeiro) ou declaração de conclusão de curso emitida pela respectiva faculdade de Medicina reconhecida pelo MEC, em papel timbrado.<Br>";
    cupom += "<b>5. Da nulidade do cupom de desconto:</b><Br>";
    cupom += "5.1 Matriculado que apresentar data de colação de grau (ou convalidação) igual ou superior a 91 (noventa e um) dias da data de quitação do pagamento da matrícula não fará jus ao desconto.<Br>";
    cupom += "5.2 Matriculado que apresentar data de colação de grau (ou convalidação) igual ou superior a 91 (noventa e um) dias da data de quitação do pagamento da matrícula e tiver feito o respectivo pagamento utilizando o cupom de desconto #PPP2019 perderá automaticamente todos os benefícios do Programa Primeira Pós 2019, além de ser cobrado pela diferença de valor aplicada na taxa matrícula.<Br>";
    cupom += "5.3 Matriculado que porventura apresentar documentação falsa e/ou inidônea, perderá todos os benefícios Programa Primeira Pós 2019, ficará obrigado ao ressarcimento de todos os descontos já obtidos, além de estar sujeito às condenações judiciais cabíveis e demais sanções previstas em lei.</p>";


    $("#myModal2 .modal-body").html("Carregando conteúdo ...");
    if (c == 1) { $("#myModal2 .modal-body").html($(".contrato").html()); }
    if (c == 2) { $("#myModal2 .modal-body").load("/PoliticaPrivacidade/ .PoliticaPrivacidade"); }
    if (c == 3) { $("#myModal2 .modal-body").html(cupom); }
    $("#myModal2").modal();
}

function gtag_report_conversion(url) { var callback = function () { if (typeof (url) != 'undefined') { window.location = url; } }; gtag('event', 'conversion', { 'send_to': 'AW-985863459/nU6VCL_1gYwBEKOqjNYD', 'event_callback': callback }); return false; }

