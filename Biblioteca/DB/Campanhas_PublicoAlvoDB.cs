using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Campanhas_PublicoAlvoDB
    {

        public void Salvar(Campanhas_PublicoAlvo publico)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_campanhas_publicoalvo (idcampanha, tipo, idcampanharef) VALUES (@campanha, @tipo, @campanharef) ");
                query.SetParameter("campanha", publico.idcampanha);
                query.SetParameter("tipo", publico.fltipo);
                query.SetParameter("campanharef", publico.idcampanharef);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void SalvarPublicoAlvoCurso(Campanhas_PublicoAlvo_Cursos publico)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_campanhas_cursos_envio (idcampanha, idtitulo, idcurso, fltipo) VALUES (@campanha, @titulo, @curso, @tipo) ");
                query.SetParameter("campanha", publico.idcampanha);
                query.SetParameter("titulo", publico.idtitulo);
                query.SetParameter("curso", publico.idcurso);
                query.SetParameter("tipo", publico.fltipo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void SalvarExclusoesCurso(Campanhas_PublicoAlvo_Cursos publico)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_campanhas_exclusoes (idcampanha, idtitulo, idcurso, fltipo) VALUES (@campanha, @titulo, @curso, @tipo) ");
                query.SetParameter("campanha", publico.idcampanha);
                query.SetParameter("titulo", publico.idtitulo);
                query.SetParameter("curso", publico.idcurso);
                query.SetParameter("tipo", publico.fltipo);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void ExcluirPublicoAlvoCurso(int id = 0)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM  mailing_campanhas_cursos_envio where idcampanha = @campanha");
                query.SetParameter("campanha", id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void ExcluirExclusoesCurso(int id = 0)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM  mailing_campanhas_exclusoes where idcampanha = @campanha");
                query.SetParameter("campanha", id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void ExcluirPublicoAlvo(int id = 0)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM  mailing_campanhas_publicoalvo where idcampanha = @campanha");
                query.SetParameter("campanha", id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Campanhas_PublicoAlvo Buscar(int id)
        {
            try
            {
                Campanhas_PublicoAlvo publico = new Campanhas_PublicoAlvo();
                DBSession session = new DBSession();
                Query query = session.CreateQuery("select * from mailing_campanhas_publicoalvo where idcampanha = @campanha");
                query.SetParameter("campanha", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    publico = new Campanhas_PublicoAlvo(Convert.ToInt32(reader["idcampanha"]), Convert.ToInt32(reader["tipo"]), Convert.ToInt32(reader["idcampanharef"]));
                }
                reader.Close();
                session.Close();

                return publico;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Campanhas_PublicoAlvo_Cursos> Listar(int id)
        {
            try
            {
                List<Campanhas_PublicoAlvo_Cursos> publico = new List<Campanhas_PublicoAlvo_Cursos>();
                DBSession session = new DBSession();
                Query query = session.CreateQuery("select m.idcampanha, m.idtitulo, m.idcurso, m.fltipo, tc.titulo, concat(c.titulo1, ' - ', c.titulo) as turma from mailing_campanhas_cursos_envio m inner join titulo_curso tc on tc.codigo = idtitulo left join curso c on c.codigo = m.idcurso where m.idcampanha = @campanha");
                query.SetParameter("campanha", id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    publico.Add(new Campanhas_PublicoAlvo_Cursos(Convert.ToInt32(reader["idcampanha"]), Convert.ToInt32(reader["idtitulo"]), Convert.ToInt32(reader["idcurso"]), Convert.ToString(reader["fltipo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["turma"])));
                }
                reader.Close();
                session.Close();

                return publico;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public List<Campanhas_PublicoAlvo_Cursos> ListarExclusoes(int id)
        {
            try
            {
                List<Campanhas_PublicoAlvo_Cursos> publico = new List<Campanhas_PublicoAlvo_Cursos>();
                DBSession session = new DBSession();
                Query query = session.CreateQuery("select m.idcampanha, m.idtitulo, m.idcurso, m.fltipo, tc.titulo, concat(c.titulo1, ' - ', c.titulo) as turma from mailing_campanhas_exclusoes m inner join titulo_curso tc on tc.codigo = idtitulo left join curso c on c.codigo = m.idcurso where m.idcampanha = @campanha");
                query.SetParameter("campanha", id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    publico.Add(new Campanhas_PublicoAlvo_Cursos(Convert.ToInt32(reader["idcampanha"]), Convert.ToInt32(reader["idtitulo"]), Convert.ToInt32(reader["idcurso"]), Convert.ToString(reader["fltipo"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["turma"])));
                }
                reader.Close();
                session.Close();

                return publico;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public int Existe(int id)
        {
            try
            {
                int idcampanha = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("select * from mailing_campanhas_publicoalvo where idcampanha = @campanha");
                query.SetParameter("campanha", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    idcampanha = Convert.ToInt32(reader["idcampanha"]);
                }
                reader.Close();
                session.Close();

                return idcampanha;
            }
            catch (Exception error)
            {
                throw error;
            }

        }     

    }
}
