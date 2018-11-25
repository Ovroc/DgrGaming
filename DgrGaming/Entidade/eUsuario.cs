using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DgrGaming.Entidade
{
    public class eUsuario
    {
        public int IdUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public string SituacaoUsuario { get; set; }
    }
}