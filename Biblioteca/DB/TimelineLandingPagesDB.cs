using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelineLandingPageDB
    {

        public int Salvar(TimelineLandingPage variavel)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_landingpage (flacao, txredirecionaurl, txdownload, flagradecimento, txagradecimento, txlink, txtitulo, txdescricao, flnotificar, idemailnotificar, flemailagradecimento, txremetente, idemailremetente, txassunto, idmensagem, tximagem, txtitulorede, txdescricaorede, txhtml) output INSERTED.idlandingpage VALUES (@flacao, @txredirecionaurl, @txdownload, @flagradecimento, @txagradecimento, @txlink, @txtitulo, @txdescricao, @flnotificar, @idemailnotificar, @flemailagradecimento, @txremetente, @idemailremetente, @txassunto, @idmensagem, @tximagem, @txtitulorede, @txdescricaorede, @txhtml) ");
                query.SetParameter("flacao", variavel.acao_form)
                    .SetParameter("txredirecionaurl", variavel.acao_form_url)
                    .SetParameter("txdownload", variavel.txdownload)
                    .SetParameter("flagradecimento", variavel.agradecimento)
                    .SetParameter("txagradecimento", variavel.agradecimento_msg)
                    .SetParameter("txlink", variavel.link_permanente)
                    .SetParameter("txtitulo", variavel.titulo)
                    .SetParameter("txdescricao", variavel.descricao)
                    .SetParameter("flnotificar", variavel.notificar)
                    .SetParameter("idemailnotificar", variavel.notificar_email)
                    .SetParameter("flemailagradecimento", variavel.enviar_email)
                    .SetParameter("txremetente", variavel.remetente)
                    .SetParameter("idemailremetente", variavel.email_remetente)
                    .SetParameter("txassunto", variavel.assunto)
                    .SetParameter("idmensagem", variavel.mensagem)
                    .SetParameter("tximagem", variavel.tximagem)
                    .SetParameter("txtitulorede", variavel.titulo_redes)
                    .SetParameter("txdescricaorede", variavel.descricao_redes)                    
                    .SetParameter("txhtml", variavel.txhtml);
                    id = query.ExecuteScalar();
                    session.Close();
                    return id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(TimelineLandingPage variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE mailing_landingpage SET flacao = @flacao, txredirecionaurl = @txredirecionaurl, txdownload = @txdownload, flagradecimento = @flagradecimento, txagradecimento = @txagradecimento, txlink = @txlink, txtitulo = @txtitulo, txdescricao = @txdescricao, flnotificar = @flnotificar, idemailnotificar = @idemailnotificar, flemailagradecimento = @flemailagradecimento, txremetente = @txremetente, idemailremetente = @idemailremetente, txassunto = @txassunto, idmensagem = @idmensagem, tximagem = @tximagem, txtitulorede = @txtitulorede, txdescricaorede = @txdescricaorede, txhtml = @txhtml WHERE idlandingpage = @idlandingpage");
                    query.SetParameter("flacao", variavel.acao_form)
                    .SetParameter("txredirecionaurl", variavel.acao_form_url)
                    .SetParameter("txdownload", variavel.txdownload)
                    .SetParameter("flagradecimento", variavel.agradecimento)
                    .SetParameter("txagradecimento", variavel.agradecimento_msg)
                    .SetParameter("txlink", variavel.link_permanente)
                    .SetParameter("txtitulo", variavel.titulo)
                    .SetParameter("txdescricao", variavel.descricao)
                    .SetParameter("flnotificar", variavel.notificar)
                    .SetParameter("idemailnotificar", variavel.notificar_email)
                    .SetParameter("flemailagradecimento", variavel.enviar_email)
                    .SetParameter("txremetente", variavel.remetente)
                    .SetParameter("idemailremetente", variavel.email_remetente)
                    .SetParameter("txassunto", variavel.assunto)
                    .SetParameter("idmensagem", variavel.mensagem)
                    .SetParameter("tximagem", variavel.tximagem)
                    .SetParameter("txtitulorede", variavel.titulo_redes)
                    .SetParameter("txdescricaorede", variavel.descricao_redes)
                    .SetParameter("txhtml", variavel.txhtml)
                    .SetParameter("idlandingpage", variavel.idlandingpage);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(int idlandingpage)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_landingpage WHERE idlandingpage = @idlandingpage ");
                query.SetParameter("idlandingpage", idlandingpage);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int Total()
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM mailing_landingpage");
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public int Total(string txtitulo = "")
        {
            int r = 0;
            DBSession session = new DBSession();
            Query quey = session.CreateQuery("SELECT count(*) as total FROM mailing_landingpage WHERE txtitulo like '%" + txtitulo.Replace(" ", "%") + "%'");
            quey.SetParameter("txtitulo", txtitulo);
            IDataReader reader = quey.ExecuteQuery();
            if (reader.Read())
            {
                r = Convert.ToInt32(reader["total"]);
            }
            reader.Close();
            session.Close();
            return r;
        }

        public List<TimelineLandingPage> Listar(int pagina = 1)
        {
            try
            {
                List<TimelineLandingPage> dataLote = new List<TimelineLandingPage>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_landingpage ORDER BY txtitulo OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new TimelineLandingPage(Convert.ToInt32(reader["idlandingpage"]), Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["txlink"])));
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

        public List<TimelineLandingPage> Listar(int pagina = 1, string txtitulo = "")
        {
            try
            {
                List<TimelineLandingPage> dataLote = new List<TimelineLandingPage>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_landingpage WHERE txtitulo like '%" + txtitulo.Replace(" ", "%") + "%' ORDER BY txtitulo OFFSET 10 * (@pagina - 1) ROWS FETCH NEXT 10 ROWS ONLY");
                quey.SetParameter("pagina", pagina);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new TimelineLandingPage(Convert.ToInt32(reader["idlandingpage"]), Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["txlink"])));
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

        public TimelineLandingPage Buscar(int idlandingpage)
        {
            try
            {
                TimelineLandingPage lp = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_landingpage WHERE idlandingpage = @idlandingpage");
                quey.SetParameter("idlandingpage", idlandingpage);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    lp = new TimelineLandingPage(Convert.ToInt32(reader["idlandingpage"]), Convert.ToString(reader["flacao"]), Convert.ToString(reader["txredirecionaurl"]), Convert.ToString(reader["txdownload"]), Convert.ToInt32(reader["flagradecimento"]), Convert.ToString(reader["txagradecimento"]), Convert.ToString(reader["txlink"]), Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["txdescricao"]), Convert.ToInt32(reader["flnotificar"]), Convert.ToInt32(reader["idemailnotificar"]), Convert.ToInt32(reader["flemailagradecimento"]), Convert.ToString(reader["txremetente"]), Convert.ToInt32(reader["idemailremetente"]), Convert.ToString(reader["txassunto"]), Convert.ToInt32(reader["idmensagem"]), Convert.ToString(reader["tximagem"]), Convert.ToString(reader["txtitulorede"]), Convert.ToString(reader["txdescricaorede"]), Convert.ToString(reader["txhtml"]));
                }
                reader.Close();
                session.Close();

                return lp;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TimelineLandingPage Buscar(string link)
        {
            try
            {
                TimelineLandingPage lp = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_landingpage WHERE txlink = @txlink");
                quey.SetParameter("txlink", link);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    lp = new TimelineLandingPage(Convert.ToInt32(reader["idlandingpage"]), Convert.ToString(reader["flacao"]), Convert.ToString(reader["txredirecionaurl"]), Convert.ToString(reader["txdownload"]), Convert.ToInt32(reader["flagradecimento"]), Convert.ToString(reader["txagradecimento"]), Convert.ToString(reader["txlink"]), Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["txdescricao"]), Convert.ToInt32(reader["flnotificar"]), Convert.ToInt32(reader["idemailnotificar"]), Convert.ToInt32(reader["flemailagradecimento"]), Convert.ToString(reader["txremetente"]), Convert.ToInt32(reader["idemailremetente"]), Convert.ToString(reader["txassunto"]), Convert.ToInt32(reader["idmensagem"]), Convert.ToString(reader["tximagem"]), Convert.ToString(reader["txtitulorede"]), Convert.ToString(reader["txdescricaorede"]), Convert.ToString(reader["txhtml"]));
                }
                reader.Close();
                session.Close();

                return lp;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<LandingPageTemplate> ListarTemplates()
        {
            try
            {
                List<LandingPageTemplate> dataLote = new List<LandingPageTemplate>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_landingpage_templates order by txtemplate");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new LandingPageTemplate(Convert.ToInt32(reader["idtemplate"]), Convert.ToString(reader["txtemplate"]), Convert.ToString(reader["txhtml"])));
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

        public LandingPageTemplate BuscarTemplate(int id)
        {
            try
            {
                LandingPageTemplate template = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_landingpage_templates WHERE idtemplate = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    template = new LandingPageTemplate(Convert.ToInt32(reader["idtemplate"]), Convert.ToString(reader["txtemplate"]), Convert.ToString(reader["txhtml"]));
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

        public List<LandingPageFormulario> ListarFormulario(int id)
        {
            try
            {
                List<LandingPageFormulario> dataLote = new List<LandingPageFormulario>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM mailing_landingpage_formulario where idlandingpage = @id order by nrordem");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    dataLote.Add(new LandingPageFormulario(Convert.ToInt32(reader["idform"]), Convert.ToInt32(reader["idlandingpage"]), Convert.ToString(reader["txform"]), Convert.ToInt32(reader["fltipo"]), Convert.ToInt32(reader["nrordem"])));
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

        public void AlterarFormulario(int idform, string txform, int nrordem)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE mailing_landingpage_formulario SET txform = @txform, nrordem = @nrordem WHERE idform = @idform");
                query.SetParameter("idform", idform)
                .SetParameter("txform", txform)
                .SetParameter("nrordem", nrordem);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public int IncluirFormulario(int idlandingpage, string txform, int fltipo, int nrordem)
        {
            try
            {
                int id = 0;
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_landingpage_formulario (idlandingpage, txform, fltipo, nrordem) output INSERTED.idform VALUES (@idlandingpage, @txform, @fltipo, @nrordem)");
                query.SetParameter("idlandingpage", idlandingpage)
                .SetParameter("txform", txform)
                .SetParameter("fltipo", fltipo)
                .SetParameter("nrordem", nrordem);
                id = query.ExecuteScalar();
                session.Close();
                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void ExcluirFormulario(string ids)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_landingpage_formulario WHERE idform not in (" + ids + ") ");
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void ExcluirLandingPageFormulario(int id)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_landingpage_formulario WHERE idlandingpage = @id");
                query.SetParameter("id", id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

    }
}
