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
    public partial class ListaUsuarios : System.Web.UI.Page
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

        protected void btNovoUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuario.aspx");
        }

        protected void gvUsuarios_Load(object sender, EventArgs e)
        {
            nUsuario u = new nUsuario();
            DataTable d = u.ConsultarUsuario();

            gvUsuarios.DataSource = d;
            gvUsuarios.DataBind();
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Session["S_idUsuario"] = e.CommandArgument;

                Response.Redirect("Usuario.aspx");
            }
            else if (e.CommandName == "Excluir")
            {
                nUsuario u = new nUsuario
                {
                    IdUsuario = Convert.ToInt32(e.CommandArgument)
                };

                u.Excluir();

                Response.Redirect("ListaUsuarios.aspx");
            }
        }
    }
}