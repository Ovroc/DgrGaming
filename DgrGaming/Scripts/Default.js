$(document).ready(function () {
    show();
});

function show() {
    $.ajax({
        url: "Default.aspx/Show",
        datatype: "json",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (p) {
            if (p.d.length > 0) {
                for (var i = 0; i < p.d.length; i++) {
                    var list = ['<div class="dgrItemPublicacao ml-5" id=' + p.d[i].IdPublicacao + '><div><a id="Titulo" class="dgrPublicacao" onclick="View(' + p.d[i].IdPublicacao + ')">' + p.d[i].TituloPublicacao + '</a></div><div><small class="text-muted" id="Data">' + p.d[i].DataPublicacao + '</small></div></div><hr/><br/>'];
                    $("#divFeedPublicacoes").append(list);
                }
            }
        }
    });
}

function buscar() {

    let pesq = $("#Conteudo_txBuscar").val();
    let cat = $("input[name='optCategoria']:checked").val();
    var list = [];

    $.ajax({
        type: "POST",
        url: "Default.aspx/BuscaPublicacao",
        datatype: "json",
        data: "{pesquisa: '" + pesq + "', categoria: '" + cat + "'}",
        contentType: "application/json; charset=utf-8",
        success: function (p) {
            if (p.d.length > 0) {
                $("#divFeedPublicacoes").empty();

                if (cat !== 'todas') {
                    $("#hApresentacaoTitulo").html(`Publicações da categoria ${cat}:`);
                } else {
                    $("#hApresentacaoTitulo").html('Publicações');
                }

                for (var i = 0; i < p.d.length; i++) {
                    list = ['<div class="dgrItemPublicacao ml-5" id=' + p.d[i].IdPublicacao + '><div><a id="Titulo" class="dgrPublicacao" onclick="View(' + p.d[i].IdPublicacao + ')">' + p.d[i].TituloPublicacao + '</a></div><div><small class="text-muted" id="Data">' + p.d[i].DataPublicacao + '</small></div></div><hr/><br/>'];
                    $("#divFeedPublicacoes").append(list);

                    $("#Conteudo_txBuscar").val('');
                }
            } else {
                $("#divFeedPublicacoes").empty();
                $("#hApresentacaoTitulo").empty();

                list = ['<div><a class="Ops ml-5 ">Ops..! Não existem publicações relacionadas a sua pesquisa.</a></div><hr/><br/>'];

                $("#divFeedPublicacoes").append(list);

                $("#Conteudo_txBuscar").val('');
            }
        }
    });
}


function buscarMais(opt) {

    $.ajax({
        type: "POST",
        url: "Default.aspx/BuscaMais",
        datatype: "json",
        data: "{opcao: '" + opt + "'}",
        contentType: "application/json; charset=utf-8",
        success: function (p) {
            $("#divFeedPublicacoes").empty();
            if (p.d.length > 0) {

                if (opt == '1') {
                    $("#hApresentacaoTitulo").empty();
                    $("#hApresentacaoTitulo").html('Publicações Mais acessadas');

                } else if (opt == '2') {
                    $("#hApresentacaoTitulo").empty();
                    $("#hApresentacaoTitulo").html('Publicações Melhores Avaliadas');
                }
                for (var i = 0; i < p.d.length; i++) {
                    var list = ['<div class="dgrItemPublicacao ml-5" id=' + p.d[i].IdPublicacao + '><div><a id="Titulo" class="dgrPublicacao" onclick="View(' + p.d[i].IdPublicacao + ')">' + p.d[i].TituloPublicacao + '</a></div><div><small class="text-muted" id="Data">' + p.d[i].DataPublicacao + '</small></div></div><hr/><br/>'];
                    $("#divFeedPublicacoes").append(list);
                }
            }
        }
    });
}

function View(id) {
    window.location.replace(`VerPublicacao.aspx?Publicacao=${id}`);
}

function starRating(vt) {

    let idpublicacao = $("#Conteudo_PublicacaoId").text();

    $("#Avaliacao").empty();

    $.ajax({
        type: "POST",
        url: "VerPublicacao.aspx/Avaliacao",
        datatype: "json",
        data: "{publicacao:'" + idpublicacao + "', voto:'" + vt + "'}",
        contentType: "application/json; charset=utf-8",
        success: function (p) {
            var list = ['<blockquote class="blockquote"><p class="mb-0">Obrigado por avaliar ! :)</p></blockquote>'];

            $("#MsgVotacaoPublicacao").append(list);
        }
    });
}

