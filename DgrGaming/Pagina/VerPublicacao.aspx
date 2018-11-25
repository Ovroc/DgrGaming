<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina/DGR.Master" AutoEventWireup="true" CodeBehind="VerPublicacao.aspx.cs" Inherits="DgrGaming.Pagina.VerPublicacao" %>
<asp:Content ID="Cabecalho" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/verpublucacao.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="CorpoVerPublicacao" ContentPlaceHolderID="Conteudo" runat="server">
    <div class="containerVerPublicacao">
        <div>
            <div class="list-inline">
                <h1 class="tituloPublicacao" id="pTitulo" runat="server"></h1>
                <span id="spanCategoria" runat="server" class="badge badge-secondary p-2"></span>
            </div>
            <ul class="list-inline text-muted dadosPublicacao p-2">
                <li class="list-inline-item" id="liData" runat="server"></li>
                <li class="list-inline-item" id="liAutor" runat="server"></li>
            </ul>
            <div>
                <p class="ConteudoPublicacao lead text-justify" id="pConteudo" runat="server"></p>
            </div>
            <div id="divMidia" runat="server"></div>
        </div>
        <span id="PublicacaoId" runat="server" class="BgOff"></span>
        <div>
            <div id="Avaliacao">
                <div class="votacaoPublicacao">
                    <span onclick="starRating(5)"><i class="fa fa-star"></i></span>
                    <span onclick="starRating(4)"><i class="fa fa-star"></i></span>
                    <span onclick="starRating(3)"><i class="fa fa-star"></i></span>
                    <span onclick="starRating(2)"><i class="fa fa-star"></i></span>
                    <span onclick="starRating(1)"><i class="fa fa-star"></i></span>
                </div>
            </div>
            <div id="MsgVotacaoPublicacao">
            </div>
        </div>
        <%-- API de comentários Disqus --%>
        <div class="pt-5" id="disqus_thread"></div>
    </div>
    <%-- Disqus Js--%>
    <script>
        (function () {
            var d = document, s = d.createElement('script');
            s.src = 'https://dgrgaming.disqus.com/embed.js';
            s.setAttribute('data-timestamp', +new Date());
            (d.head || d.body).appendChild(s);
        })();
    </script>
    <noscript>Please enable JavaScript to view the <a href="https://disqus.com/?ref_noscript">comments powered by Disqus.</a></noscript>
</asp:Content>
