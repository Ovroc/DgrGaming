using DgrGaming.Entidade;
using DgrGaming.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DgrGaming.Negocio
{
    public class nPublicacao : ePublicacao
    {
        public void Salvar()
        {
            string query = $"INSERT INTO publicacao (titulo, autor, data, conteudo, midia, ativo, categoria) VALUES ('{TituloPublicacao}','{AutorPublicacao}','{DataPublicacao}','{ConteudoPublicacao}','{MidiaPublicacao}','S','{CategoriaPublicacao}')";
            Conexao.ModificarTabela(query);
        }

        public void Atualizar()
        {
            string query = $"UPDATE publicacao SET titulo = '{TituloPublicacao}', autor = '{AutorPublicacao}', data = '{DataPublicacao}', conteudo = '{ConteudoPublicacao}', midia = '{MidiaPublicacao}', ativo = '{SituacaoPublicacao}', categoria = '{CategoriaPublicacao}' WHERE idpublicacao = {IdPublicacao}";
            Conexao.ModificarTabela(query);
        }

        public void Excluir()
        {
            string query = $"UPDATE publicacao SET ativo = 'N' WHERE idpublicacao = {IdPublicacao}";
            Conexao.ModificarTabela(query);
        }

        public DataTable ConsultarPublicacao()
        {
            string query = "SELECT idpublicacao,titulo, usuario.nome_usuario as autor,data,conteudo,midia,categoria," +
                            "case" +
                                " when publicacao.ativo = 'S' then 'Ativo' " +
                                " when publicacao.ativo = 'N' then 'Inativo '" +
                            " end as ativo " +
                            "FROM publicacao inner join usuario on publicacao.autor = usuario.idusuario";

            DataTable d = Conexao.CarregarTabela(query);

            return d;
        }

        public DataTable PublicacoesFeed()
        {
            string query = "SELECT * FROM publicacao WHERE ativo = 'S'";

            DataTable d = Conexao.CarregarTabela(query);

            return d;
        }

        public nPublicacao BuscarPublicacao(int id)
        {
            string query = $"select usuario.nome_usuario, publicacao.*from publicacao inner join usuario on publicacao.autor = usuario.idusuario WHERE idpublicacao = {id}";

            DataTable d = Conexao.CarregarTabela(query);

            nPublicacao p = new nPublicacao();

            IdPublicacao = Convert.ToInt32(d.Rows[0]["idpublicacao"]);
            TituloPublicacao = d.Rows[0]["titulo"].ToString();
            AutorPublicacao = d.Rows[0]["nome_usuario"].ToString();
            DataPublicacao = d.Rows[0]["data"].ToString();
            ConteudoPublicacao = d.Rows[0]["conteudo"].ToString();
            MidiaPublicacao = d.Rows[0]["midia"].ToString();
            SituacaoPublicacao = d.Rows[0]["ativo"].ToString();
            CategoriaPublicacao = d.Rows[0]["categoria"].ToString();

            return p;
        }

        public DataTable Busca(string busca, string categoria)
        {
            string query = "";

            if (categoria == "todas")
            {
                query = $"SELECT * FROM publicacao WHERE titulo LIKE '%{busca}%' and ativo = 'S'";
            }
            else
            {
                query = $"SELECT * FROM publicacao WHERE titulo LIKE '%{busca}%' and categoria = '{categoria}' and ativo = 'S'";
            }

            DataTable d = Conexao.CarregarTabela(query);

            return d;
        }

        public void AcrescentaAcesso(int idpublicacao)
        {
            string query = $"INSERT INTO publicacao_acessos (publicacao, acessos) VALUES ({idpublicacao}, 1)";
            Conexao.ModificarTabela(query);
        }

        public void AvaliarPublicacao(string id, string avaliacao)
        {
            string query = $"INSERT INTO publicacao_avaliacao(publicacao, avaliacao) VALUES ({id},{avaliacao});";
            Conexao.ModificarTabela(query);
        }

        public DataTable PublicacoesFeedMaisLidas()
        {
            string query = "select sum(publicacao_acessos.acessos), publicacao.* from publicacao inner join publicacao_acessos" +
                " on publicacao.idpublicacao = publicacao_acessos.publicacao where ativo = 'S'" +
                "group by publicacao_acessos.publicacao order by sum(publicacao_acessos.acessos) desc";

            DataTable d = Conexao.CarregarTabela(query);

            return d;
        }

        public DataTable PublicacoesFeedMelhoresAvaliadas()
        {
            string query = "select avg(publicacao_avaliacao.avaliacao), publicacao.* from publicacao inner join publicacao_avaliacao" +
                " on publicacao.idpublicacao = publicacao_avaliacao.publicacao where ativo = 'S' group by publicacao_avaliacao.publicacao" +
                " order by avg(publicacao_avaliacao.avaliacao) desc ";

            DataTable d = Conexao.CarregarTabela(query);

            return d;
        }

        public string BuscaUltimaPublicacao()
        {
            string query = "SELECT MAX(idpublicacao) as idpublicacao FROM publicacao";

            DataTable d =  Conexao.CarregarTabela(query);

            string p = d.Rows[0]["idpublicacao"].ToString();

            return p;
        }
    }
}