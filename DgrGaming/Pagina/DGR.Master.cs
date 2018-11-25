using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DgrGaming.Negocio;

namespace DgrGaming.Pagina
{
    public partial class DGR : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["S_nomeUsuario"] != null && !string.IsNullOrEmpty(Session["S_nomeUsuario"].ToString()))
                {
                    divAdministrador.Visible = true;
                    divVisitante.Visible = false;
                    lbBoasVindas.InnerText = "Olá " + Session["S_nomeUsuario"].ToString() + " !";
                }
                else
                {
                    divAdministrador.Visible = false;
                    divVisitante.Visible = true;
                }
            }
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            nUsuario nUsuario = new nUsuario
            {
                EmailUsuario = tbEmail.Text,
                SenhaUsuario = tbSenha.Text
            };

            string nomeUsuario = nUsuario.ConsultaLogin(nUsuario.EmailUsuario, nUsuario.SenhaUsuario);

            if (nomeUsuario == "")
            {
                Response.Redirect("Default.aspx");
            }

            int idUsuario = nUsuario.ConsultaIdUsuario(nUsuario.EmailUsuario, nUsuario.SenhaUsuario);

            Session["S_nomeUsuario"] = nomeUsuario;
            Session["I_idUsuario"] = idUsuario;

            Response.Redirect("Default.aspx");
        }

        protected void btSair_Click(object sender, EventArgs e)
        {
            Session["S_nomeUsuario"] = null;
            Session["I_idUsuario"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}