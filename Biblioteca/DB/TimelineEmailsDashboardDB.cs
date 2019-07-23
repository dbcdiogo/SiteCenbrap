using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class TimelineEmailsDashboardDB
    {       
        public List<TimelineEmailsDashboard> ListarFila()
        {
            try
            {
                List<TimelineEmailsDashboard> lista = new List<TimelineEmailsDashboard>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT MM.TXUSUARIO, COUNT(*) as total, mm.qtlimite FROM mailing_enviados ME INNER JOIN mailing_emails MM ON MM.IDEMAIL = ME.idemail WHERE ME.IDEMAIL IN (SELECT DISTINCT(IDEMAIL) FROM mailing_enviados WHERE FLENVIADO = 0) AND ME.FLENVIADO = 0 GROUP BY MM.TXUSUARIO, mm.qtlimite");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    lista.Add(new TimelineEmailsDashboard()
                    {
                        email = Convert.ToString(reader["TXUSUARIO"]),
                        total = Convert.ToInt32(reader["total"]),
                        limite = Convert.ToInt32(reader["qtlimite"])
                    });
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

        public List<TimelineEmailsDashboard> Agendadas()
        {
            try
            {
                List<TimelineEmailsDashboard> lista = new List<TimelineEmailsDashboard>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT MC.txcampanha, MCA.dtenvio FROM MAILING_CAMPANHAS_AGENDAMENTO MCA INNER JOIN mailing_campanhas MC ON MC.idcampanha = MCA.idcampanha WHERE MCA.DTENVIO >= GETDATE() AND (SELECT COUNT(*) FROM mailing_enviados ME WHERE ME.IDCAMPANHA = MCA.idcampanha) = 0 ORDER BY MCA.dtenvio");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    lista.Add(new TimelineEmailsDashboard()
                    {
                        email = Convert.ToString(reader["txcampanha"]),
                        data = Convert.ToDateTime(reader["dtenvio"])
                    });
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

        public List<TimelineEmailsDashboard> Contas()
        {
            try
            {
                List<TimelineEmailsDashboard> lista = new List<TimelineEmailsDashboard>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT ME.TXUSUARIO, me.qtlimite FROM mailing_emails ME WHERE ME.idemail NOT IN (SELECT DISTINCT IDEMAIL FROM mailing_enviados WHERE FLENVIADO = 0)");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    lista.Add(new TimelineEmailsDashboard()
                    {
                        email = Convert.ToString(reader["TXUSUARIO"]),
                        limite = Convert.ToInt32(reader["qtlimite"])
                    });
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

        public CampanhasEnviados Dados()
        {
            try
            {
                CampanhasEnviados dados = new CampanhasEnviados();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(@"select 
                    (SELECT COUNT(*) FROM mailing_enviados WHERE FLENVIADO = 1) as enviados,
                    (SELECT COUNT(*) FROM mailing_abriu) as abertos,
                    (SELECT COUNT(*) FROM mailing_clicou) as clicados,
                    (SELEct count(*) from mailing_descadastrar) as descadastrados,
                    (select count(*) as qtd from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and exists(select* from mailing_campanhas_cursos where mailing_campanhas_cursos.idcampanha = me.idcampanha and mailing_campanhas_cursos.idcurso = ac.curso) inner join curso as c ON c.codigo = ac.curso where a.codigo not in (select idaluno from timeline_usuarios where flignorar = 1)) as inscricoes,
                    (select count(distinct(aluno)) from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join mailing_abriu ma on ma.idenviado = me.idenviado inner join mailing_campanhas_cursos mcc on mcc.idcampanha = me.idcampanha inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and ac.curso = mcc.idcurso) as inscricoesa,
                    (select count(distinct(aluno)) from aluno as a inner join mailing_enviados me ON a.email = me.txpara inner join mailing_clicou mc on mc.idenviado = me.idenviado inner join mailing_campanhas_cursos mcc on mcc.idcampanha = me.idcampanha inner join aluno_curso as ac ON a.codigo = ac.aluno and cast(me.dtenviarapartir as date) <= ac.adesao and ac.curso = mcc.idcurso) as inscricoesc");
                IDataReader reader = quey.ExecuteQuery();
                if (reader.Read())
                {
                    dados = new CampanhasEnviados()
                    {
                        enviados = Convert.ToInt32(reader["enviados"]),
                        abertos = Convert.ToInt32(reader["abertos"]),
                        inscricoes = Convert.ToInt32(reader["inscricoes"]),
                        clicados = Convert.ToInt32(reader["clicados"]),
                        descadastrados = Convert.ToInt32(reader["descadastrados"]),
                        taxa_abertura = (double)Convert.ToInt32(reader["abertos"]) / (double)Convert.ToInt32(reader["enviados"]) * 100,
                        taxa_inscricoes = ((double)Convert.ToInt32(reader["inscricoes"]) / (double)Convert.ToInt32(reader["abertos"])) * 100,
                        taxa_clicados = ((double)Convert.ToInt32(reader["clicados"]) / (double)Convert.ToInt32(reader["abertos"])) * 100,
                        inscricoesa = Convert.ToInt32(reader["inscricoesa"]),
                        inscricoesc = Convert.ToInt32(reader["inscricoesc"])
                    };
                }

                reader.Close();
                session.Close();

                return dados;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
