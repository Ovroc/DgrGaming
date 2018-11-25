using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DgrGaming.Util
{
    public class Conexao
    {
        private static readonly string stringConexao = "SERVER=localhost;DATABASE=dgrgaming;UID=root;Password=1234;SslMode=none;";

        private static MySqlConnection conexao = new MySqlConnection(stringConexao);

        private static void AbrirConexao() => conexao.Open();

        private static void FecharConexao() => conexao.Close();

        public static void ModificarTabela(string query)
        {
            AbrirConexao();

            MySqlCommand comando = new MySqlCommand(query, conexao);

            comando.ExecuteNonQuery();

            FecharConexao();
        }

        public static DataTable CarregarTabela(string query)
        {
            AbrirConexao();

            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataReader dataReader = comando.ExecuteReader();
            DataTable resultado = new DataTable();

            resultado.Load(dataReader);

            FecharConexao();

            return resultado;
        }

        public static string CarregarNomeUsuario(string query)
        {
            string nomeUsuario = "";

            AbrirConexao();

            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataReader dataReader = comando.ExecuteReader();
            dataReader.Read();

            if (dataReader.HasRows)
            {
                nomeUsuario = dataReader["nome_usuario"].ToString();
            }


            FecharConexao();

            return nomeUsuario;
        }

        public static int CarregarIdUsuario(string query)
        {
            AbrirConexao();

            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataReader dataReader = comando.ExecuteReader();
            dataReader.Read();

            int idUsuario = Convert.ToInt32(dataReader["idusuario"]);

            FecharConexao();

            return idUsuario;
        }
    }
}