<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina/DGR.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="DgrGaming.Pagina.Usuario" %>
<asp:Content ID="Cabecalho" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/formulario.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="CorpoUsuario" ContentPlaceHolderID="Conteudo" runat="server">
    <div class="containerFormulario">
        <div class="DgrContainer">
            <div class="container">
                <div class="col Formulario">
                    <h3 id="tbOperacao" runat="server"></h3>
                    <label id="lbId" runat="server" visible="false"></label>
                    <div class="form-row">
                        <div class="col-6">
                            <div class="form-group">
                                <label for="Conteudo_tbNome">NOME</label>
                                <input type="text" placeholder="Nome do autor" maxlength="100" id="tbNome" runat="server" class="form-control form-control-sm" required="required" />
                            </div>
                        </div>
                        <div class="col-1"></div>
                        <div class="col-1">
                            <label>SITUAÇÃO</label>
                            <div class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" runat="server" checked="checked" id="chSituacao">
                                <label class="custom-control-label" for="Conteudo_chSituacao">Ativo</label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="Conteudo_tbemail">E-MAIL</label>
                        <input type="email" placeholder="Informe o Email" maxlength="150" id="tbemail" runat="server" class="form-control form-control-sm" required="required" />
                    </div>
                    <div class="form-group">
                        <label for="Conteudo_tbSenha">SENHA</label>
                        <input type="password" placeholder="Informe a senha de acesso" id="tbSenha" runat="server" class="form-control form-control-sm" required="required" />
                    </div>
                    <div class="row">
                        <div class="col-6">
                            <asp:Button ID="btSalvarUsuario" runat="server" Text="Salvar" class="btn btn-info" OnClick="btSalvarUsuario_Click" />
                            <asp:Button ID="btAlterarUsuario" runat="server" Text="Salvar" class="btn btn-info" OnClick="btAlterarUsuario_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

