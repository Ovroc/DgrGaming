using DgrGaming.Entidade;
using DgrGaming.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DgrGaming.Negocio
{
    public class nUsuario : eUsuario
    {
        public void Salvar()
        {
            string query = $"INSERT INTO usuario(email, nome_usuario, senha) VALUES ('{EmailUsuario}','{NomeUsuario}','{SenhaUsuario}')";
            Conexao.ModificarTabela(query);
        }

        public void Atualizar()
        {
            string query = $"UPDATE usuario SET email = '{EmailUsuario}', nome_usuario = '{NomeUsuario}', senha = '{SenhaUsuario}' WHERE idusuario = {IdUsuario}";
            Conexao.ModificarTabela(query);
        }

        public void Excluir()
        {
            string query = $"UPDATE usuario SET ativo = 'N' WHERE idusuario = {IdUsuario}";
            Conexao.ModificarTabela(query);
        }

        public string ConsultaLogin(string email, string senha)
        {
            string senhaEncriptografada = Encriptacao.Encriptar(senha);

            string query = $"SELECT nome_usuario FROM usuario WHERE email = '{email}' AND senha = '{senhaEncriptografada}';";

            string d = Conexao.CarregarNomeUsuario(query);

            return d;
        }

        public int ConsultaIdUsuario(string email, string senha)
        {
            string senhaEncriptografada = Encriptacao.Encriptar(senha);

            string query = $"SELECT idusuario FROM usuario WHERE email = '{email}' AND senha = '{senhaEncriptografada}';";

            int d = Conexao.CarregarIdUsuario(query);

            return d;
        }

        public nUsuario BuscarUsuario(int id)
        {
            string query = $"SELECT * FROM usuario WHERE idusuario = {id}";

            DataTable d = Conexao.CarregarTabela(query);

            nUsuario u = new nUsuario();

            IdUsuario = Convert.ToInt32(d.Rows[0]["idusuario"]);
            EmailUsuario = d.Rows[0]["email"].ToString();
            NomeUsuario = d.Rows[0]["nome_usuario"].ToString();
            SituacaoUsuario = d.Rows[0]["ativo"].ToString();

            return u;
        }

        public DataTable ConsultarUsuario()
        {
            string query = "SELECT idusuario,email, nome_usuario, " +
                " case" +
                " when usuario.ativo = 'S' then 'Ativo' " +
                " when usuario.ativo = 'N' then 'Inativo' " +
                " end as ativo " +
                " FROM usuario;";

            DataTable d = Conexao.CarregarTabela(query);

            return d;
        }
    }
}