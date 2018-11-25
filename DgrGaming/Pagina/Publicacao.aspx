<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina/DGR.Master" AutoEventWireup="true" CodeBehind="Publicacao.aspx.cs" Inherits="DgrGaming.Pagina.Publicacao" %>

<asp:Content ID="Cabecalho" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/formulario.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="CorpoPublicacao" ContentPlaceHolderID="Conteudo" runat="server">
    <div class="containerFormulario">
        <div class="container">
            <div class="col Formulario">
                <h3 id="tbOperacao" runat="server"></h3>
                <label id="lbId" runat="server" visible="false"></label>
                <div class="form-row">
                    <div class="col-6">
                        <label for="Conteudo_tbTitulo">TÍTULO</label>
                        <input type="text" placeholder="Título da Publicação" maxlength="100" id="tbTitulo" runat="server" class="form-control form-control-sm" required="required" />
                    </div>
                    <div class="col-2">
                        <div class="form-group">
                            <label for="Conteudo_ddlCategoria">CATEGORIA</label>
                            <asp:DropDownList ID="ddlCategoria" runat="server" class="form-control form-control-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                                <asp:ListItem Value="podcast" Text="Podcast" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="video" Text="Video"></asp:ListItem>
                                <asp:ListItem Value="artigo" Text="Artigo"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-1"></div>
                    <div class="col-1">
                        <label>SITUAÇÃO</label>
                        <div class="custom-control custom-checkbox">
                            <input type="checkbox" class="custom-control-input" runat="server" checked="checked" id="chSituacao">
                            <label class="custom-control-label" for="Conteudo_chSituacao">Ativa</label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="Conteudo_taConteudo">CONTEÚDO</label>
                    <textarea rows="4" cols="50" placeholder="Conteúdo da publicação" id="taConteudo" runat="server" class="form-control form-control-sm" required="required"></textarea>
                </div>
                <div class="form-group" id="divMidiaVideo" runat="server">
                    <label for="Conteudo_tbUrl">LINK MÍDIA</label>
                    <input type="text" placeholder="Url da mídia" id="tbUrl" runat="server" class="form-control form-control-sm" required="required" />
                </div>
                <div class="form-group" id="divMidia" runat="server">
                    <asp:FileUpload ID="fu_arquivoUpload" CssClass="btn btn-outline-dark btn-sm" runat="server" />
                </div>
                <div class="row">
                    <div class="col-6">
                        <asp:Button ID="btSalvarPublicacao" runat="server" Text="Salvar" class="btn btn-info" OnClick="btSalvarPublicacao_Click" />
                        <asp:Button ID="btAlterarPublicacao" runat="server" Text="Salvar" class="btn btn-info" OnClick="btAlterarPublicacao_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
