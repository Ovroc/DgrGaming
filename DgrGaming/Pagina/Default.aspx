<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina/DGR.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DgrGaming.Pagina.Default" %>

<asp:Content ID="Cabecalho" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/default.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="CorpoDefault" ContentPlaceHolderID="Conteudo" runat="server">
    <div class="dgrBusca">
        <div class="container">
            <div class="row MenuBusca">
                <div class="col-6">
                    <div class="row no-gutters pl-3">
                        <div class="col">
                            <input class="form-control form-control-sm" type="search" placeholder="Buscar" runat="server" id="txBuscar">
                        </div>
                        <div class="col-auto  ml-2">
                            <button class="btn btn-light btn-sm border-light border-left-0 btn-busca" type="button" onclick="buscar()">
                                <i class="fa fa-search busca"></i>
                            </button>
                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <div>
                        <div class="custom-control custom-radio custom-control-inline">
                            <input type="radio" id="rb1" name="optCategoria" value="todas" class="custom-control-input" checked="checked">
                            <label class="custom-control-label dgrNavBar" for="rb1">Todas</label>
                        </div>
                        <div class="custom-control custom-radio custom-control-inline">
                            <input type="radio" id="rb2" name="optCategoria" value="podcast" class="custom-control-input">
                            <label class="custom-control-label dgrNavBar" for="rb2">Podcast</label>
                        </div>
                        <div class="custom-control custom-radio custom-control-inline">
                            <input type="radio" id="rb3" name="optCategoria" value="video" class="custom-control-input">
                            <label class="custom-control-label dgrNavBar" for="rb3">Video</label>
                        </div>
                        <div class="custom-control custom-radio custom-control-inline">
                            <input type="radio" id="rb4" name="optCategoria" value="artigo" class="custom-control-input">
                            <label class="custom-control-label dgrNavBar" for="rb4">Artigo</label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <hr />
    <h3 class="dgrTituloApresentacao pt-4 ml-5" id="hApresentacaoTitulo">Publicações</h3>
    <!-- Feed de publicações gerada no codebehind e redenrizada no arquivo Default.js-->
    <div class="pt-5">
        <div id="divFeedPublicacoes"></div>
    </div>
</asp:Content>
