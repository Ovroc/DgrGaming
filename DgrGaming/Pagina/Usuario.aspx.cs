using DgrGaming.Negocio;
using DgrGaming.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DgrGaming.Pagina
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["S_nomeUsuario"] != null && !String.IsNullOrEmpty(Session["S_nomeUsuario"].ToString()))
            {
                if (Session["S_idUsuario"] != null && !String.IsNullOrEmpty(Session["S_idUsuario"].ToString()))
                {

                    Recupera();

                    btSalvarUsuario.Visible = false;
                    btAlterarUsuario.Visible = true;

                    tbOperacao.InnerText = "Alteração de Autor";

                    Session["S_idUsuario"] = null;
                }
                else
                {
                    btSalvarUsuario.Visible = true;
                    btAlterarUsuario.Visible = false;

                    tbOperacao.InnerText = "Incluir Autor";
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Recupera()
        {
            int i;

            nUsuario u = new nUsuario();

            i = Convert.ToInt32(Session["S_idUsuario"]);

            u.BuscarUsuario(i);

            lbId.InnerText = Session["S_idUsuario"].ToString();
            tbNome.Value = u.NomeUsuario;
            tbemail.Value = u.EmailUsuario;
        }

        protected void btSalvarUsuario_Click(object sender, EventArgs e)
        {
            string senhaEncriptografada = Encriptacao.Encriptar(tbSenha.Value);

            nUsuario u = new nUsuario
            {

                EmailUsuario = tbemail.Value,
                NomeUsuario = tbNome.Value,
                SenhaUsuario = senhaEncriptografada
            };

            u.Salvar();

            Response.Redirect("Default.aspx");
        }

        protected void btAlterarUsuario_Click(object sender, EventArgs e)
        {
            nUsuario u = new nUsuario();

            u.IdUsuario = Convert.ToInt32(lbId.InnerText);
            u.EmailUsuario = tbemail.Value;
            u.NomeUsuario = tbNome.Value;
            u.SenhaUsuario = tbSenha.Value;

            if (chSituacao.Checked)
            {
                u.SituacaoUsuario = "S";
            }
            else
            {
                u.SituacaoUsuario = "N";
            }

            u.Atualizar();

            Response.Redirect("Default.aspx");
        }
    }
}