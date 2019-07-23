using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class EnviadoDB
    {
        public void Salvar(Enviado variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_enviados (idcampanha, txtitulo, txtexto, txpara, dtdata, idemail, flenviado, dtenviado, nrprioridade, dtenviarapartir) VALUES (@idcampanha, @txtitulo, @txtexto, @txpara, @dtdata, @idemail, @flenviado, @dtenviado, @nrprioridade, @dtenviarapartir) ");
                query.SetParameter("idcampanha", variavel.idcampanha.idcampanha)
                .SetParameter("txtitulo", variavel.txtitulo)
                .SetParameter("txtexto", variavel.txtexto)
                .SetParameter("txpara", variavel.txpara)
                .SetParameter("dtdata", variavel.dtdata)
                .SetParameter("idemail", variavel.idemail.idemail)
                .SetParameter("flenviado", variavel.flenviado)
                .SetParameter("dtenviado", variavel.dtenviado)
                .SetParameter("nrprioridade", variavel.nrprioridade)
                .SetParameter("dtenviarapartir", variavel.dtenviarapartir);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public int SalvarRetornar(Enviado variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_enviados (idcampanha, txtitulo, txtexto, txpara, dtdata, idemail, flenviado, dtenviado, nrprioridade, dtenviarapartir) output INSERTED.idenviado VALUES (@idcampanha, @txtitulo, @txtexto, @txpara, @dtdata, @idemail, @flenviado, @dtenviado, @nrprioridade, @dtenviarapartir) ");
                query.SetParameter("idcampanha", variavel.idcampanha.idcampanha)
                .SetParameter("txtitulo", variavel.txtitulo)
                .SetParameter("txtexto", variavel.txtexto)
                .SetParameter("txpara", variavel.txpara)
                .SetParameter("dtdata", variavel.dtdata)
                .SetParameter("idemail", variavel.idemail.idemail)
                .SetParameter("flenviado", variavel.flenviado)
                .SetParameter("dtenviado", variavel.dtenviado)
                .SetParameter("nrprioridade", variavel.nrprioridade)
                .SetParameter("dtenviarapartir", variavel.dtenviarapartir);
                int id = query.ExecuteScalar();
                session.Close();

                return id;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Alterar(Enviado variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE mailing_enviados SET txtitulo = @txtitulo, txtexto = @txtexto, txpara = @txtexto, idemail = @idemail, flenviado = @flenviado, dtenviado = @dtenviado, nrprioridade = @nrprioridade, dtenviarapartir = @dtenviarapartir WHERE idenviado = @idenviado");
                query.SetParameter("idenviado", variavel.idenviado)
                .SetParameter("txtitulo", variavel.txtitulo)
                .SetParameter("txtexto", variavel.txtexto)
                .SetParameter("txpara", variavel.txpara)
                .SetParameter("idemail", variavel.idemail.idemail)
                .SetParameter("flenviado", variavel.flenviado)
                .SetParameter("dtenviado", variavel.dtenviado)
                .SetParameter("nrprioridade", variavel.nrprioridade)
                .SetParameter("dtenviarapartir", variavel.dtenviarapartir);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void AlterarTexto(Enviado variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE mailing_enviados SET txtexto = @txtexto WHERE idenviado = @idenviado");
                query.SetParameter("idenviado", variavel.idenviado)
                .SetParameter("txtexto", variavel.txtexto);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Enviado(int id, int idemail)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE mailing_enviados SET flenviado = 1, dtenviado = getdate(), idemail = @idemail WHERE idenviado = @idenviado");
                query.SetParameter("idenviado", id)
                .SetParameter("idemail", idemail);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Excluir(Enviado variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_enviados WHERE idenviado = @idenviado; DELETE FROM mailling_abriu WHERE idenviado = @idenviado;");
                query.SetParameter("idenviado", variavel.idenviado);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        
        public Enviado Buscar(int id)
        {
            try
            {
                Enviado enviado = null;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT isnull(idenviado, 0) as idenviado, isnull(idcampanha, 0) as idcampanha, isnull(txtitulo, '') as txtitulo, isnull(txtexto, '') as txtexto, isnull(txpara, '') as txpara, isnull(dtdata, '01/01/1900') as dtdata, isnull(idemail, 0) as idemail, isnull(flenviado, 0) as flenviado, isnull(dtenviado, '01/01/1900') as dtenviado, isnull(nrprioridade, 0) as nrprioridade, isnull(dtenviarapartir, getdate()) as dtenviarapartir FROM mailing_enviado WHERE idenviado = @idenviado");
                query.SetParameter("idenviado", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    enviado = new Enviado(Convert.ToInt32(reader["idenviado"]), new Campanhas() { idcampanha = Convert.ToInt32(reader["idcampanha"]) }, Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["txtexto"]), Convert.ToString(reader["txpara"]), Convert.ToDateTime(reader["dtdata"]), new Contas() { idemail = Convert.ToInt32(reader["idemail"]) }, Convert.ToDateTime(reader["dtenviarapartir"]), Convert.ToBoolean(reader["flenviado"]), Convert.ToDateTime(reader["dtenviado"]), Convert.ToInt32(reader["nrprioridade"]));
                }
                reader.Close();
                session.Close();

                return enviado;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public string Email(int id)
        {
            try
            {
                string enviado = "";

                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT isnull(txpara, '') as txpara FROM mailing_enviados WHERE idenviado = @idenviado");
                query.SetParameter("idenviado", id);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    enviado = Convert.ToString(reader["txpara"]);
                }
                reader.Close();
                session.Close();

                return enviado;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Enviado> Listar(int idemail)
        {
            try
            {
                List<Enviado> enviado = new List<Enviado>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT isnull(idenviado, 0) as idenviado, isnull(idcampanha, 0) as idcampanha, isnull(txtitulo, '') as txtitulo, isnull(txtexto, '') as txtexto, isnull(txpara, '') as txpara, isnull(dtdata, '01/01/1900') as dtdata, isnull(idemail, 0) as idemail, isnull(flenviado, 0) as flenviado, isnull(dtenviado, '01/01/1900') as dtenviado, isnull(nrprioridade, 0) as nrprioridade, isnull(dtenviarapartir, getdate()) as dtenviarapartir FROM mailing_enviados WHERE idemail = @idemail");
                query.SetParameter("idemail", idemail);
                IDataReader reader = query.ExecuteQuery();

                while(reader.Read())
                {
                    enviado.Add(new Enviado(Convert.ToInt32(reader["idenviado"]), new Campanhas() { idcampanha = Convert.ToInt32(reader["idcampanha"]) }, Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["txtexto"]), Convert.ToString(reader["txpara"]), Convert.ToDateTime(reader["dtdata"]), new Contas() { idemail = Convert.ToInt32(reader["idemail"]) }, Convert.ToDateTime(reader["dtenviarapartir"]), Convert.ToBoolean(reader["flenviado"]), Convert.ToDateTime(reader["dtenviado"]), Convert.ToInt32(reader["nrprioridade"])));
                }
                reader.Close();
                session.Close();

                return enviado;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Enviado> Listar(Campanhas campanha)
        {
            try
            {
                List<Enviado> enviado = new List<Enviado>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT isnull(idenviado, 0) as idenviado, isnull(idcampanha, 0) as idcampanha, isnull(txtitulo, '') as txtitulo, isnull(txtexto, '') as txtexto, isnull(txpara, '') as txpara, isnull(dtdata, '01/01/1900') as dtdata, isnull(idemail, 0) as idemail, isnull(flenviado, 0) as flenviado, isnull(dtenviado, '01/01/1900') as dtenviado, isnull(nrprioridade, 0) as nrprioridade, isnull(dtenviarapartir, getdate()) as dtenviarapartir FROM mailing_enviados WHERE idcampanha = @idcampanha");
                query.SetParameter("idcampanha", campanha.idcampanha);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    enviado.Add(new Enviado(Convert.ToInt32(reader["idenviado"]), new Campanhas() { idcampanha = Convert.ToInt32(reader["idcampanha"]) }, Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["txtexto"]), Convert.ToString(reader["txpara"]), Convert.ToDateTime(reader["dtdata"]), new Contas() { idemail = Convert.ToInt32(reader["idemail"]) }, Convert.ToDateTime(reader["dtenviarapartir"]), Convert.ToBoolean(reader["flenviado"]), Convert.ToDateTime(reader["dtenviado"]), Convert.ToInt32(reader["nrprioridade"])));
                }
                reader.Close();
                session.Close();

                return enviado;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Contas> ContasParaEnviar()
        {
            try
            {
                List<Contas> enviado = new List<Contas>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select isnull(m_em.idemail, 0) as idemail, isnull(m_em.txusuario, '') as txusuario, isnull(m_em.txsenha, '') as txsenha, isnull(m_em.qtlimite, 0) as qtlimite, isnull(m_dom.iddominio, 0) as iddominio, isnull(m_dom.txdominio, '') as txdominio, isnull(m_dom.txsmtp, '') as txsmtp, isnull(m_dom.txporta, 0) as txporta, isnull(m_dom.flautenticacao, 0) as flautenticacao, (isnull((SELECT count(m_env1.idenviado) FROM mailing_enviados as m_env1 WHERE  m_env1.idemail = m_em.idemail and m_env1.flenviado = 1 AND m_env1.dtenviado between dateadd(HH, -24, getdate()) and getdate()), 0) + isnull((select count(*) from Envio_email inner join contaEnvio on Envio_email.contaEnvio_id = contaEnvio.contaEnvio_id where contaEnvio.email = m_em.txusuario and envio_email.data_envio between dateadd(HH, -24, getdate()) and getdate()), 0)) as qtdenviados from mailing_emails as m_em INNER JOIN mailing_dominios as m_dom ON m_em.iddominio = m_dom.iddominio WHERE m_em.qtlimite >= (SELECT count(m_env1.idenviado) FROM mailing_enviados as m_env1 WHERE  m_env1.idemail = m_em.idemail and m_env1.flenviado = 1 AND m_env1.dtenviado between dateadd(HH, -24, getdate()) and getdate()) AND EXISTS (SELECT mc.idcampanha FROM mailing_campanhas_remetentes as mc where mc.idemail = m_em.idemail AND EXISTS (SELECT m_env1.idenviado FROM mailing_enviados as m_env1 WHERE mc.idcampanha = m_env1.idcampanha AND m_env1.flenviado = 0))");
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    enviado.Add(new Contas(Convert.ToInt32(reader["idemail"]), new Dominio(Convert.ToInt32(reader["iddominio"]), Convert.ToString(reader["txdominio"]), Convert.ToString(reader["txsmtp"]), Convert.ToInt32(reader["txporta"]), Convert.ToInt32(reader["flautenticacao"])), Convert.ToString(reader["txusuario"]), Convert.ToString(reader["txsenha"]), Convert.ToInt32(reader["qtlimite"]), Convert.ToString(reader["txdominio"]), Convert.ToInt32(reader["qtdenviados"])));
                }
                reader.Close();
                session.Close();

                return enviado;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Enviado> ParaEnviar(Contas idemail)
        {
            try
            {
                int top = idemail.limite / 24;

                if ((idemail.limite - idemail.qtdenviados) < top)
                    top = idemail.limite - idemail.qtdenviados;

                List<Enviado> enviado = new List<Enviado>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select top " + top + " isnull(m_env.idenviado, 0) as idenviado, isnull(m_env.idcampanha, 0) as idcampanha, isnull(m_env.txtitulo, '') as txtitulo, isnull(m_env.txtexto, '') as txtexto, isnull(m_env.txpara, '') as txpara, isnull(m_env.dtdata, '01/01/1900') as dtdata, isnull(m_env.dtenviarapartir, getdate()) as dtenviarapartir, isnull(m_env.flenviado, 0) as flenviado, isnull(m_env.dtenviado, '01/01/1900') as dtenviado, isnull(m_env.nrprioridade, 0) as nrprioridade, isnull(m_em.idemail, 0) as idemail, isnull(m_em.txusuario, '') as txusuario, isnull(m_em.txsenha, '') as txsenha, isnull(m_em.qtlimite, 0) as qtlimite, isnull(m_dom.iddominio, 0) as iddominio, isnull(m_dom.txdominio, '') as txdominio, isnull(m_dom.txsmtp, '') as txsmtp, isnull(m_dom.txporta, '') as txporta, isnull(m_dom.flautenticacao, 0) as flautenticacao from mailing_enviados AS m_env INNER JOIN mailing_emails as m_em ON @idemail = m_em.idemail INNER JOIN mailing_dominios as m_dom ON m_em.iddominio = m_dom.iddominio  WHERE m_env.flenviado = 0 AND EXISTS (SELECT mc.idcampanha from mailing_campanhas_remetentes as mc where mc.idcampanha = m_env.idcampanha and mc.idemail = @idemail) AND m_em.qtlimite >= (SELECT count(m_env1.idenviado) FROM mailing_enviados as m_env1 WHERE m_env.idemail = @idemail AND m_env1.idemail = m_env.idemail and m_env1.flenviado = 1 AND m_env1.dtenviado between dateadd(HH, -24, getdate()) and getdate()) and m_env.dtenviarapartir <= getdate() ORDER BY nrprioridade DESC");
                query.SetParameter("idemail", idemail.idemail);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    enviado.Add(new Enviado(Convert.ToInt32(reader["idenviado"]), new Campanhas() { idcampanha = Convert.ToInt32(reader["idcampanha"]) }, Convert.ToString(reader["txtitulo"]), Convert.ToString(reader["txtexto"]), Convert.ToString(reader["txpara"]), Convert.ToDateTime(reader["dtdata"]), new Contas(Convert.ToInt32(reader["idemail"]), new Dominio(Convert.ToInt32(reader["iddominio"]), Convert.ToString(reader["txdominio"]), Convert.ToString(reader["txsmtp"]), Convert.ToInt32(reader["txporta"]), Convert.ToInt32(reader["flautenticacao"])), Convert.ToString(reader["txusuario"]), Convert.ToString(reader["txsenha"]), Convert.ToInt32(reader["qtlimite"]), Convert.ToString(reader["txdominio"])), Convert.ToDateTime(reader["dtenviarapartir"]), Convert.ToBoolean(reader["flenviado"]), Convert.ToDateTime(reader["dtenviado"]), Convert.ToInt32(reader["nrprioridade"]), EmailsResposta(Convert.ToInt32(reader["idcampanha"]))));
                }
                reader.Close();
                session.Close();

                return enviado;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<string> EmailsResposta(int id)
        {
            try
            {
                List<string> emails = new List<string>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select em.txusuario from mailing_emails as em INNER JOIN mailing_campanhas_remetentes as mcr on em.idemail = mcr.idemail where mcr.idcampanha = @id");
                query.SetParameter("id", id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    emails.Add(Convert.ToString(reader["txusuario"]));
                }
                reader.Close();
                session.Close();

                return emails;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool Existe(int idcampanha, string email)
        {
            try
            {
                bool enviado = false;

                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT idenviado FROM mailing_enviados WHERE idcampanha = @idcampanha and txpara = @email");
                query.SetParameter("idcampanha", idcampanha)
                    .SetParameter("email", email);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    enviado = true;
                }
                reader.Close();
                session.Close();

                return enviado;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<string> EmailAbriu(int id)
        {
            try
            {
                List<string> emails = new List<string>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select mailing_enviados.txpara from mailing_enviados where idcampanha = @id and exists (select * from mailing_abriu where mailing_enviados.idenviado = mailing_abriu.idenviado)");
                query.SetParameter("id", id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    emails.Add(Convert.ToString(reader["txpara"]));
                }
                reader.Close();
                session.Close();

                return emails;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<string> EmailClicou(int id)
        {
            try
            {
                List<string> emails = new List<string>();

                DBSession session = new DBSession();
                Query query = session.CreateQuery("select mailing_enviados.txpara from mailing_enviados where idcampanha = @id and exists (select * from mailing_clicou where mailing_enviados.idenviado = mailing_clicou.idenviado)");
                query.SetParameter("id", id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    emails.Add(Convert.ToString(reader["txpara"]));
                }
                reader.Close();
                session.Close();

                return emails;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
