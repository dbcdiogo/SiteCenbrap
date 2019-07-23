using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class MensagensDB
    {
        public void Salvar(Mensagens variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_mensagens (txtitulo, txtexto, txjson, txidentificador, idcategoria) VALUES (@titulo, @texto, @json, @identificador, @idcategoria) ");
                query.SetParameter("titulo", variavel.titulo)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("json", variavel.txjson)
                    .SetParameter("identificador", variavel.identificador)
                    .SetParameter("idcategoria", variavel.idcategoria.idcategoria);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Mensagens variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE mailing_mensagens SET txidentificador = @identificador, txtitulo = @titulo, txtexto = @texto, txjson = @json, idcategoria = @idcategoria WHERE idmensagem = @id");
                query.SetParameter("titulo", variavel.titulo)
                    .SetParameter("texto", variavel.texto)
                    .SetParameter("id", variavel.idmensagem)
                    .SetParameter("json", variavel.txjson)
                    .SetParameter("identificador", variavel.identificador)
                    .SetParameter("idcategoria", variavel.idcategoria.idcategoria);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Mensagens variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_mensagens WHERE idmensagem = @id");
                query.SetParameter("id", variavel.idmensagem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Mensagens Buscar(int id)
        {
            try
            {
                Mensagens mensagem = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_mensagens WHERE idmensagem = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    mensagem = new Mensagens(Convert.ToInt32(reader["idmensagem"]), Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["txtexto"]), Convert.ToString(reader["txjson"]), Convert.ToString(reader["txidentificador"]), Convert.ToInt32(reader["idcategoria"]));
                }
                reader.Close();
                session.Close();

                return mensagem;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public Mensagens Buscar(string titulo)
        {
            try
            {
                Mensagens mensagem = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_mensagens WHERE txtitulo = @titulo");
                quey.SetParameter("titulo", titulo);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    mensagem = new Mensagens(Convert.ToInt32(reader["idmensagem"]), Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["txtexto"]), Convert.ToString(reader["txjson"]), Convert.ToString(reader["txidentificador"]), Convert.ToInt32(reader["idcategoria"]));
                }
                reader.Close();
                session.Close();

                return mensagem;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Mensagens> Listar(int pagina = 1, string titulo = "", int categoria = 0)
        {
            try
            {
                List<Mensagens> dataLote = new List<Mensagens>();

                DBSession session = new DBSession();
                String qry;

                qry = "SELECT * FROM (SELECT mm.idcategoria, mm.idmensagem, mm.txtitulo, mm.txidentificador, isnull((select top 1 dtenvio from mailing_campanhas mc left join mailing_campanhas_agendamento mca on mca.idcampanha = mc.idcampanha where mc.idmensagem = mm.idmensagem order by dtenvio desc),'1900-01-01') as dtenvio FROM mailing_mensagens mm WHERE 1 = 1 ";
                if (titulo != "")
                {
                    qry += "and (mm.txtitulo like '%" + titulo.Replace(" ", "%") + "%' OR mm.txidentificador like '%" + titulo.Replace(" ", "%") + "%') ";
                }
                if (categoria != 0)
                {
                    qry += "and idcategoria = " + categoria + " ";
                }
                qry += ") AS T ORDER BY t.dtenvio desc, t.txtitulo OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY";

                Query quey = session.CreateQuery(qry);
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Mensagens(Convert.ToInt32(reader["idmensagem"]), Convert.ToString(reader["txtitulo"]), Convert.ToDateTime(reader["dtenvio"]), Convert.ToString(reader["txidentificador"]), Convert.ToInt32(reader["idcategoria"])));
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

        public int Total(string titulo = "", int categoria = 0)
        {
            int r = 0;
            DBSession session = new DBSession();
            String qry;
            qry = "SELECT count(*) as total FROM mailing_mensagens WHERE 1 = 1 ";
            if (titulo != "")
            {
                qry += "and (txtitulo like '%" + titulo.Replace(" ", "%") + "%' OR txidentificador like '%" + titulo.Replace(" ", "%") + "%') ";
            }
            if (categoria != 0)
            {
                qry += "and idcategoria = " + categoria + " ";
            }
            Query quey = session.CreateQuery(qry);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public List<Mensagens> Listar()
        {
            try
            {
                List<Mensagens> dataLote = new List<Mensagens>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT mm.idmensagem, mm.txtitulo, mm.txidentificador, isnull(mca.dtenvio,'1900-01-01') as dtenvio, mm.idcategoria FROM mailing_mensagens mm left join mailing_campanhas mc on mc.idmensagem = mm.idmensagem left join mailing_campanhas_agendamento mca on mca.idcampanha = mc.idcampanha ORDER BY mca.dtenvio desc, mm.txtitulo");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Mensagens(Convert.ToInt32(reader["idmensagem"]), Convert.ToString(reader["txtitulo"]), Convert.ToDateTime(reader["dtenvio"]), Convert.ToString(reader["txidentificador"]), Convert.ToInt32(reader["idcategoria"])));
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

        public List<Mensagens> ListarMensagens(int idcategoria = 0)
        {
            try
            {
                List<Mensagens> dataLote = new List<Mensagens>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT mm.idmensagem, mm.txtitulo, mm.txidentificador, isnull(mca.dtenvio,'1900-01-01') as dtenvio, mm.idcategoria FROM mailing_mensagens mm left join mailing_campanhas mc on mc.idmensagem = mm.idmensagem left join mailing_campanhas_agendamento mca on mca.idcampanha = mc.idcampanha WHERE mm.idcategoria = @idcategoria ORDER BY mca.dtenvio desc, mm.txtitulo");
                quey.SetParameter("idcategoria", idcategoria);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Mensagens(Convert.ToInt32(reader["idmensagem"]), Convert.ToString(reader["txtitulo"]), Convert.ToDateTime(reader["dtenvio"]), Convert.ToString(reader["txidentificador"]), Convert.ToInt32(reader["idcategoria"])));
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

        public List<Mensagens> ListarMensagensResumido(int idcategoria = 0)
        {
            try
            {
                List<Mensagens> dataLote = new List<Mensagens>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT mm.idmensagem, mm.txidentificador, isnull(mca.dtenvio,'1900-01-01') as dtenvio FROM mailing_mensagens mm left join mailing_campanhas mc on mc.idmensagem = mm.idmensagem left join mailing_campanhas_agendamento mca on mca.idcampanha = mc.idcampanha WHERE mm.idcategoria = @idcategoria ORDER BY mca.dtenvio desc, mm.txtitulo");
                quey.SetParameter("idcategoria", idcategoria);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new Mensagens(Convert.ToInt32(reader["idmensagem"]), Convert.ToDateTime(reader["dtenvio"]), Convert.ToString(reader["txidentificador"])));
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

        public void SalvarTemplate(MensagensTemplate variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_templates (txtemplate, txhtml, flpadrao, txjson) VALUES (@template, @html, @padrao, @json) ");
                query.SetParameter("template", variavel.txtemplate)
                    .SetParameter("html", variavel.txhtml)
                    .SetParameter("padrao", variavel.flpadrao)
                    .SetParameter("json", variavel.txjson);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void AlterarTemplate(MensagensTemplate variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE mailing_templates set txtemplate = @template, txhtml = @html, txjson = @json WHERE idtemplate = @ident ");
                query.SetParameter("ident", variavel.idtemplate)
                    .SetParameter("template", variavel.txtemplate)
                    .SetParameter("html", variavel.txhtml)
                    .SetParameter("json", variavel.txjson);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public MensagensTemplate BuscarTemplate(int id)
        {
            try
            {
                MensagensTemplate template = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_templates WHERE idtemplate = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    template = new MensagensTemplate(Convert.ToInt32(reader["idtemplate"]), Convert.ToString(reader["txtemplate"]), Convert.ToString(reader["txhtml"]), Convert.ToBoolean(reader["flpadrao"]), Convert.ToString(reader["txjson"]));
                }
                reader.Close();
                session.Close();

                return template;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<MensagensTemplate> ListarTemplates(int padrao = 0)
        {
            try
            {
                List<MensagensTemplate> dataLote = new List<MensagensTemplate>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_templates where flpadrao = @padrao order by txtemplate");
                quey.SetParameter("padrao", padrao);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new MensagensTemplate(Convert.ToInt32(reader["idtemplate"]), Convert.ToString(reader["txtemplate"]), Convert.ToString(reader["txhtml"]), Convert.ToBoolean(reader["flpadrao"]), Convert.ToString(reader["txjson"])));
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

        public void ExcluirModelo(int id = 0)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_templates WHERE idtemplate = @id");
                query.SetParameter("id", id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<MensagensCategoria> ListarCategorias(int pagina = 1)
        {
            try
            {
                List<MensagensCategoria> dataLote = new List<MensagensCategoria>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * from mailing_mensagens_categorias order by txcategoria");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new MensagensCategoria(Convert.ToInt32(reader["idcategoria"]), Convert.ToString(reader["txcategoria"])));
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

        public MensagensCategoria BuscaCategoria(int id)
        {
            try
            {
                MensagensCategoria mensagem = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_mensagens_categorias WHERE idcategoria = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    mensagem = new MensagensCategoria(Convert.ToInt32(reader["idcategoria"]), Convert.ToString(reader["txcategoria"]));
                }
                reader.Close();
                session.Close();

                return mensagem;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }
}
