using DgrGaming.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DgrGaming.Pagina
{
    public partial class ListaPublicacoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["S_nomeUsuario"] != null && !String.IsNullOrEmpty(Session["S_nomeUsuario"].ToString()))
            {

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void gvPublicacoes_Load(object sender, EventArgs e)
        {
            nPublicacao p = new nPublicacao();
            DataTable d = p.ConsultarPublicacao();

            gvPublicacoes.DataSource = d;
            gvPublicacoes.DataBind();
        }

        protected void gvPublicacoes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Session["S_idPublicacao"] = e.CommandArgument;

                Response.Redirect("Publicacao.aspx");
            }
            else if (e.CommandName == "Excluir")
            {
                nPublicacao p = new nPublicacao
                {
                    IdPublicacao = Convert.ToInt32(e.CommandArgument)
                };

                p.Excluir();

                Response.Redirect("ListaPublicacoes.aspx");
            }
        }

        protected void btNovaPublicacao_Click(object sender, EventArgs e)
        {
            Response.Redirect("Publicacao.aspx");
        }
    }
}