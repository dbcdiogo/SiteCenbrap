using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class WhatsappDB
    {
        public void Salvar(Envio_Whatsapp variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO envio_whatsapp (idaluno, txcelular, dtcadastro, dtenvio, txmensagem, txarquivo) VALUES (@idaluno, @txcelular, @dtcadastro, @dtenvio, @txmensagem, @txarquivo) ");
                query.SetParameter("idaluno", variavel.idaluno)
                    .SetParameter("txcelular", variavel.txcelular)
                    .SetParameter("dtcadastro", variavel.dtcadastro)
                    .SetParameter("dtenvio", variavel.dtenvio)
                    .SetParameter("txmensagem", variavel.txmensagem)
                    .SetParameter("txarquivo", variavel.txarquivo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void AlterarEnviado(Envio_Whatsapp variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE envio_whatsapp SET dtenviado = @dtenviado WHERE idmensagem = @idmensagem");
                query.SetParameter("idmensagem", variavel.idmensagem)
                    .SetParameter("dtenviado", variavel.dtenviado);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Envio_Whatsapp> Listar()
        {
            try
            {
                List<Envio_Whatsapp> lista = new List<Envio_Whatsapp>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select * from envio_whatsapp where dtenviado is null and dtenvio <= getdate() and datediff(hour, dtenvio, getdate()) < 24");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    lista.Add(new Envio_Whatsapp(Convert.ToInt32(reader["idmensagem"]), Convert.ToString(reader["txcelular"]), Convert.ToString(reader["txmensagem"])));
                }
                reader.Close();
                session.Close();

                return lista;
            }
            catch (Exception error)
            {
                throw error;
            }

        }
    }
}
