using DgrGaming.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DgrGaming.Pagina
{
    public partial class Publicacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["S_nomeUsuario"] != null && !String.IsNullOrEmpty(Session["S_nomeUsuario"].ToString()))
            {

                if (ddlCategoria.SelectedValue == "video")
                {
                    divMidiaVideo.Visible = true;
                    divMidia.Visible = false;
                }
                else
                {
                    divMidiaVideo.Visible = false;
                    divMidia.Visible = true;
                }

                if (Session["S_idPublicacao"] != null && !String.IsNullOrEmpty(Session["S_idPublicacao"].ToString()))
                {

                    Recupera();

                    btSalvarPublicacao.Visible = false;
                    btAlterarPublicacao.Visible = true;
                    ddlCategoria.CssClass = "form-control form-control-sm";
                    ddlCategoria.Enabled = false;

                    tbOperacao.InnerText = "Alterar Publicação";

                    Session["S_idPublicacao"] = null;
                }
                else
                {
                    btSalvarPublicacao.Visible = true;
                    btAlterarPublicacao.Visible = false;

                    tbOperacao.InnerText = "Incluir Publicação";
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

            nPublicacao p = new nPublicacao();

            i = Convert.ToInt32(Session["S_idPublicacao"]);

            p.BuscarPublicacao(i);

            lbId.InnerText = Session["S_idPublicacao"].ToString();
            tbTitulo.Value = p.TituloPublicacao;
            taConteudo.Value = p.ConteudoPublicacao;
            tbUrl.Value = p.MidiaPublicacao;

            if (p.CategoriaPublicacao == "video")
            {
                divMidiaVideo.Visible = true;
                divMidia.Visible = false;
                ddlCategoria.SelectedIndex = 1;


            }
            else if (p.CategoriaPublicacao == "artigo")
            {
                divMidia.Visible = true;
                divMidiaVideo.Visible = false;
                ddlCategoria.SelectedIndex = 2;
            }
            else
            {
                divMidia.Visible = true;
                divMidiaVideo.Visible = false;
                ddlCategoria.SelectedIndex = 3;
            }

        }

        protected void btSalvarPublicacao_Click(object sender, EventArgs e)
        {
            nPublicacao p = new nPublicacao();

            p.TituloPublicacao = tbTitulo.Value;
            p.AutorPublicacao = Session["I_idUsuario"].ToString();
            p.DataPublicacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            p.ConteudoPublicacao = taConteudo.Value;
            p.CategoriaPublicacao = ddlCategoria.SelectedValue;

            if (ddlCategoria.SelectedValue == "video")
            {
                p.MidiaPublicacao = tbUrl.Value;
                p.Salvar();
            }
            else
            {
                p.Salvar();
                ControlaMidia("inclusao");
            }

            Response.Redirect("Default.aspx");
        }

        protected void btAlterarPublicacao_Click(object sender, EventArgs e)
        {
            nPublicacao p = new nPublicacao();

            p.IdPublicacao = Convert.ToInt32(lbId.InnerText);
            p.TituloPublicacao = tbTitulo.Value;
            p.AutorPublicacao = Session["I_idUsuario"].ToString();
            p.DataPublicacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            p.ConteudoPublicacao = taConteudo.Value;
            p.MidiaPublicacao = tbUrl.Value;
            p.CategoriaPublicacao = ddlCategoria.SelectedValue;

            if (chSituacao.Checked)
            {
                p.SituacaoPublicacao = "S";
            }
            else
            {
                p.SituacaoPublicacao = "N";
            }

            if (fu_arquivoUpload.HasFile)
            {
                ControlaMidia("alteracao", p.IdPublicacao);
            }

            p.Atualizar();

            Response.Redirect("Default.aspx");
        }

        public void ControlaMidia(string tipo, int idpublicacao = 0)
        {

            nPublicacao p = new nPublicacao();

            string idMidia = "";

            if (tipo == "inclusao")
            {
                idMidia = p.BuscaUltimaPublicacao();

            }
            else if (tipo == "alteracao")
            {
                p.BuscarPublicacao(idpublicacao);
                idMidia = p.IdPublicacao.ToString();
            }


            if (ddlCategoria.SelectedValue == "artigo")
            {
                string caminhoArq = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoArquivo"] + @"\" + idMidia + ".jpg";
                fu_arquivoUpload.SaveAs(caminhoArq);
            }
            else if (ddlCategoria.SelectedValue == "podcast")
            {
                string caminhoArq = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoArquivo"] + @"\" + idMidia + ".mp3";
                fu_arquivoUpload.SaveAs(caminhoArq);
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoria.SelectedValue == "video")
            {
                divMidiaVideo.Visible = true;
                divMidia.Visible = false;
            }
            else
            {
                divMidiaVideo.Visible = false;
                divMidia.Visible = true;
            }
        }
    }
}