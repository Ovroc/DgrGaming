using DgrGaming.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DgrGaming.Pagina
{
    public partial class VerPublicacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Publicacao = Request.QueryString["Publicacao"];

            nPublicacao p = new nPublicacao();

            p = GetPublicaco(Convert.ToInt32(Publicacao));

            p.AcrescentaAcesso(Convert.ToInt32(Publicacao));

            PublicacaoId.InnerText = Publicacao;
            pTitulo.InnerText = p.TituloPublicacao;
            liData.InnerText = "Criado em " + p.DataPublicacao;
            liAutor.InnerText = "Postado por " + p.AutorPublicacao;
            pConteudo.InnerText = p.ConteudoPublicacao;

            DefineMidia(p);
            DefineSecao(p);
        }

        public nPublicacao GetPublicaco(int ID)
        {
            nPublicacao P = new nPublicacao();

            P.BuscarPublicacao(ID);

            return P;
        }

        public void DefineSecao(nPublicacao p)
        {
            if (p.CategoriaPublicacao == "artigo")
            {
                spanCategoria.InnerText = "Artigo";
                spanCategoria.Attributes.Add("class", "badge badge-warning");
            }
            else if (p.CategoriaPublicacao == "podcast")
            {
                spanCategoria.InnerText = "Podcast";
                spanCategoria.Attributes.Add("class", "badge badge-success");
            }
            else
            {
                spanCategoria.InnerText = "Video";
                spanCategoria.Attributes.Add("class", "badge badge-info");
            }
        }

        public void DefineMidia(nPublicacao p)
        {
            string tagMidia = "";

            if (p.CategoriaPublicacao == "artigo")
            {
                tagMidia = $"<img class='img-fluid imgPublicacao pt-2 pb-2 mx-auto d-block' alt='Mídia' width='460' height='345' src=../Midia/{p.IdPublicacao}.jpg>";
            }
            else if (p.CategoriaPublicacao == "podcast")
            {
                tagMidia = $"<div class='row'><div class='col pl-auto pr-auto pt-2 pb-2 d-block'><audio controls><source src=../Midia/{p.IdPublicacao}.mp3 type=audio/mpeg></audio></div></div";
            }
            else
            {
                tagMidia = $"<div class='embed-responsive embed-responsive-16by9'><iframe class='embed-responsive-item' src={p.MidiaPublicacao} allowfullscreen></iframe></div>";
            }

            divMidia.InnerHtml = tagMidia;
        }

        [WebMethod]
        public static string Avaliacao(string publicacao, string voto)
        {
            nPublicacao p = new nPublicacao();

            p.AvaliarPublicacao(publicacao, voto);

            return "Seu voto foi computado";
        }
    }
}