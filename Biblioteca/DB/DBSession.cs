using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace Biblioteca.DB
{
    public class Query
    {
        private IDbCommand comando;
        public Query(String sql, IDbConnection connection)
        {
            comando = connection.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandTimeout = 600;
            comando.CommandText = sql;
        }
        public void ExecuteUpdate()
        {
            comando.ExecuteNonQuery();
        }
        public IDataReader ExecuteQuery()
        {
            return comando.ExecuteReader();
        }
        public Query SetParameter(String nome, object valor)
        {
            var parametro = comando.CreateParameter();
            parametro.ParameterName = nome;
            parametro.Value = valor;
            comando.Parameters.Add(parametro);
            return this;
        }
        public int ExecuteScalar()
        {
            return Convert.ToInt32(comando.ExecuteScalar());
        }
    }

    public class DBSession
    {
        private IDbConnection conexao;
        public DBSession()
        {
            string conec = "";
            conec = "Data Source=201.16.212.229; Initial Catalog=cenbrap; User ID=cenbrap; Password=Mendanha2015; Language=Portuguese;  Max Pool Size=10000; Database=cenbrap";
            //conec = "Data Source=cenbrap.com.br; Initial Catalog=cenbrap; User ID=cenbrap; Password=Mendanha2015; Language=Portuguese;  Max Pool Size=10000; Database=cenbrap";
            conexao = new SqlConnection(conec);

            conexao.Open();
        }
        public void Close()
        {
            conexao.Close();
        }
        public Query CreateQuery(String sql)
        {
            return new Query(sql, conexao);
        }
    }
}
