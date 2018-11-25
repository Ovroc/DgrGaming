using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DgrGaming.Entidade
{
    public class ePublicacao
    {
        public int IdPublicacao { get; set; }
        public string TituloPublicacao { get; set; }
        public string DescricaoPublicacao { get; set; }
        public string AutorPublicacao { get; set; }
        public string DataPublicacao { get; set; }
        public string ConteudoPublicacao { get; set; }
        public string MidiaPublicacao { get; set; }
        public string SituacaoPublicacao { get; set; }
        public string CategoriaPublicacao { get; set; }
    }
}