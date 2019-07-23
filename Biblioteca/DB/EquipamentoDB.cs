using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using System.Data;

namespace Biblioteca.DB
{
    public class EquipamentoDB
    {
        public void Salvar(Equipamento equipamento)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO equipamento (titulo, imagem) VALUES (@titulo, @imagem) ");
                query.SetParameter("titulo", equipamento.titulo)
                    .SetParameter("imagem", equipamento.imagem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Equipamento equipamento)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE equipamento SET titulo = @titulo, imagem = @imagem WHERE codigo = @codigo");
                query.SetParameter("titulo", equipamento.titulo)
                    .SetParameter("imagem", equipamento.imagem)
                    .SetParameter("codigo", equipamento.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Equipamento equipamento)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM equipamento WHERE codigo = @codigo; DELETE FROM cidade_equipamento WHERE equipamento = @codigo;");
                query.SetParameter("codigo", equipamento.codigo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Equipamento Buscar(int codigo)
        {
            try
            {
                Equipamento equipamento = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM equipamento WHERE codigo = @codigo");
                quey.SetParameter("codigo", codigo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    equipamento = new Equipamento(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["imagem"]));
                }
                reader.Close();
                session.Close();

                return equipamento;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Equipamento> Listar()
        {
            try
            {
                List<Equipamento> equipamento = new List<Equipamento>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM equipamento ORDER BY titulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    equipamento.Add(new Equipamento(Convert.ToInt32(reader["codigo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["imagem"])));
                }
                reader.Close();
                session.Close();

                return equipamento;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
