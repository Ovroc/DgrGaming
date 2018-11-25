<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina/DGR.Master" AutoEventWireup="true" CodeBehind="ListaPublicacoes.aspx.cs" Inherits="DgrGaming.Pagina.ListaPublicacoes" %>
<asp:Content ID="Cabecalho" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/listapublicacoes.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="CorpoListaPublicacao" ContentPlaceHolderID="Conteudo" runat="server">
    <div class="containerListaPublicacao">
        <div class="container">
            <div class="row pr-3">
                <div class="col">
                    <h3>Lista de Publicações</h3>
                </div>
                <div class="col-md-auto"></div>
                <div class="col col-lg-2 p-0">
                    <asp:Button ID="btNovaPublicacao" runat="server" Text="Nova Publicação" class="btn btn-success" OnClick="btNovaPublicacao_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col TabelaPublicacao">
                    <asp:GridView ID="gvPublicacoes" runat="server" class="table table-bordered table-hover table-responsive-sm table-sm" AutoGenerateColumns="False" OnLoad="gvPublicacoes_Load" OnRowCommand="gvPublicacoes_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="PUBLICACÃO" DataField="titulo" />
                            <asp:BoundField HeaderText="AUTOR" DataField="autor" />
                            <asp:BoundField HeaderText="DATA" DataField="data" />
                            <asp:BoundField HeaderText="SITUAÇÃO" DataField="ativo" />

                            <asp:TemplateField HeaderText="OPERAÇÕES">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col">
                                            <asp:LinkButton ID="Editar" runat="server" CommandName="Editar" ToolTip="Editar Publicação" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idpublicacao")%>'><h6><i class="fa fa-pencil OptEditar"></i></h6></asp:LinkButton>
                                        </div>
                                        <div class="col">
                                            <asp:LinkButton ID="Excluir" runat="server" CommandName="Excluir" ToolTip="Excluir Publicação" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idpublicacao")%>'><h6><i class="fa fa-trash OptExcluir"></i></h6></asp:LinkButton>
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
