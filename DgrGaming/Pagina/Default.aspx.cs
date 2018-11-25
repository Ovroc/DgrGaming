using DgrGaming.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DgrGaming.Pagina
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        [WebMethod]
        public static List<nPublicacao> Show()
        {
            nPublicacao p = new nPublicacao();
            DataTable d = p.PublicacoesFeed();

            List<nPublicacao> ListP = new List<nPublicacao>();

            for (int i = 0; i < d.Rows.Count; i++)
            {
                nPublicacao publicacao = new nPublicacao
                {
                    IdPublicacao = Convert.ToInt32(d.Rows[i]["idpublicacao"].ToString()),
                    TituloPublicacao = d.Rows[i]["titulo"].ToString(),
                    DataPublicacao = d.Rows[i]["data"].ToString()
                };

                ListP.Add(publicacao);
            }

            return ListP;
        }

        [WebMethod]
        public static List<nPublicacao> BuscaPublicacao(string pesquisa, string categoria)
        {
            nPublicacao p = new nPublicacao();

            DataTable d = p.Busca(pesquisa, categoria);

            List<nPublicacao> ListP = new List<nPublicacao>();

            for (int i = 0; i < d.Rows.Count; i++)
            {
                nPublicacao publicacao = new nPublicacao
                {
                    IdPublicacao = Convert.ToInt32(d.Rows[i]["idpublicacao"].ToString()),
                    TituloPublicacao = d.Rows[i]["titulo"].ToString(),
                    DataPublicacao = d.Rows[i]["data"].ToString()
                };

                ListP.Add(publicacao);
            }

            return ListP;
        }

        [WebMethod]
        public static List<nPublicacao> BuscaMais(string opcao)
        {
            nPublicacao p = new nPublicacao();
            DataTable d = new DataTable();

            if (opcao == "1")
            {
                d = p.PublicacoesFeedMaisLidas();
            }
            else if (opcao == "2")
            {
                d = p.PublicacoesFeedMelhoresAvaliadas();
            }

            List<nPublicacao> ListP = new List<nPublicacao>();

            for (int i = 0; i < d.Rows.Count; i++)
            {
                nPublicacao publicacao = new nPublicacao
                {
                    IdPublicacao = Convert.ToInt32(d.Rows[i]["idpublicacao"].ToString()),
                    TituloPublicacao = d.Rows[i]["titulo"].ToString(),
                    DataPublicacao = d.Rows[i]["data"].ToString()
                };

                ListP.Add(publicacao);
            }

            return ListP;
        }
    }
}