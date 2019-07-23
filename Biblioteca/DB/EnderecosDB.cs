using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class EnderecosDB
    {
        public Enderecos Buscar(string cep)
        {
            try
            {
                Enderecos endereco = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select * from enderecos where cep = @cep");
                quey.SetParameter("cep", cep);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    endereco = new Enderecos(Convert.ToInt32(reader["id"]), Convert.ToString(reader["cep"]), Convert.ToString(reader["uf"]), Convert.ToString(reader["cidade"]), Convert.ToString(reader["bairro"]), Convert.ToString(reader["logradouro"]), Convert.ToString(reader["latitude"]), Convert.ToString(reader["longitude"]), Convert.ToInt32(reader["ibge_cod_uf"]), Convert.ToInt32(reader["ibge_cod_cidade"]), Convert.ToString(reader["area_cidade_km2"]), Convert.ToInt32(reader["ddd"]));
                }
                reader.Close();
                session.Close();

                return endereco;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
       
    }
}
