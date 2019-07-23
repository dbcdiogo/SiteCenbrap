using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Cron_nfeDB
    {
        public void Alterar(Cron_nfe variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE cron_nfe SET situacao = @situacao, texto = @texto WHERE cron_nfe_id = @cron_nfe_id");
                query.SetParameter("situacao", variavel.situacao)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("cron_nfe_id", variavel.cron_nfe_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(string xml, int situacao, string texto)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE cron_nfe SET situacao = @situacao, texto = @texto WHERE xml = @xml");
                query.SetParameter("situacao", situacao)
                    .SetParameter("texto", texto)
                    .SetParameter("xml", xml);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Cron_nfe> Listar()
        {
            try
            {
                List<Cron_nfe> dataLote = new List<Cron_nfe>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(cron_nfe_id, 0) as cron_nfe_id, isnull(entrada, 0) as entrada, isnull(data, '01/01/1900') as data, isnull(situacao, 0) as situacao, isnull(texto, '') as texto, isnull(xml, '') as xml FROM cron_nfe");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Cron_nfe(Convert.ToInt32(reader["cron_nfe_id"]), new Entrada() { codigo = Convert.ToInt32(reader["cron_nfe_id"]) }, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["situacao"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["xml"])));
                }
                reader.Close();
                session.Close();

                return dataLote;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Cron_nfe> Aguardando()
        {
            try
            {
                List<Cron_nfe> dataLote = new List<Cron_nfe>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT isnull(cron_nfe_id, 0) as cron_nfe_id, isnull(entrada, 0) as entrada, isnull(data, '01/01/1900') as data, isnull(situacao, 0) as situacao, isnull(texto, '') as texto, isnull(xml, '') as xml FROM cron_nfe WHERE situacao = 0 and exists (select * from entrada where entrada.codigo = cron_nfe.entrada and (entrada.nota_fiscal is null OR entrada.nota_fiscal = ''))");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Cron_nfe(Convert.ToInt32(reader["cron_nfe_id"]), new Entrada() { codigo = Convert.ToInt32(reader["cron_nfe_id"]) }, Convert.ToDateTime(reader["data"]), Convert.ToInt32(reader["situacao"]), Convert.ToString(reader["texto"]), Convert.ToString(reader["xml"])));
                }
                reader.Close();
                session.Close();

                return dataLote;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
