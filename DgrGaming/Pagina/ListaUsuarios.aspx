<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina/DGR.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="DgrGaming.Pagina.ListaUsuarios" %>

<asp:Content ID="Cabecalho" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/listausuarios.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="CorpoListaUsuario" ContentPlaceHolderID="Conteudo" runat="server">
    <div class="containerListaUsuario">
        <div class="container">
            <div class="row">
                <div class="col-10">
                    <h3>Lista de Autores</h3>
                </div>
                <div class="col-2">
                    <asp:Button ID="btNovoUsuario" runat="server" Text="Novo Autor" class="btn btn-success" OnClick="btNovoUsuario_Click" />
                </div>
            </div>
            <div class="row">
                <div class="TabelaUsuario">
                    <asp:GridView ID="gvUsuarios" runat="server" class="table table-bordered table-hover table-responsive-sm" AutoGenerateColumns="false" OnLoad="gvUsuarios_Load" OnRowCommand="gvUsuarios_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="AUTOR" DataField="nome_usuario" />
                            <asp:BoundField HeaderText="EMAIL" DataField="email" />
                            <asp:BoundField HeaderText="SITUAÇÃO" DataField="ativo" />

                            <asp:TemplateField HeaderText="OPERAÇÕES">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col">
                                            <asp:LinkButton ID="Editar" runat="server" CommandName="Editar" ToolTip="Editar Autor" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idusuario")%>'><h6><i class="fa fa-pencil OptEditar"></i></h6></asp:LinkButton>
                                        </div>
                                        <div class="col">
                                            <asp:LinkButton ID="Excluir" runat="server" CommandName="Excluir" ToolTip="Excluir Autor" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idusuario")%>'><h6><i class="fa fa-trash OptExcluir"></i></h6></asp:LinkButton>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
