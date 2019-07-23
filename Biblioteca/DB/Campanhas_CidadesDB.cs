using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class Campanhas_CidadesDB
    {

        public void Salvar(Campanhas_Cidades publico)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO mailing_campanhas_cidades (idcampanha, txestado, txcidade) VALUES (@campanha, @estado, @cidade) ");
                query.SetParameter("campanha", publico.idcampanha);
                query.SetParameter("estado", publico.txestado);
                query.SetParameter("cidade", publico.txcidade);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void ExcluirCidades(int id = 0)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM mailing_campanhas_cidades where idcampanha = @campanha");
                query.SetParameter("campanha", id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        //public List<Campanhas_PublicoAlvo> Buscar(int id)
        //{
        //    try
        //    {
        //        List<Campanhas_PublicoAlvo> publico = new List<Campanhas_PublicoAlvo>();
        //        DBSession session = new DBSession();
        //        Query query = session.CreateQuery("select * from mailing_campanhas_publicoalvo where idcampanha = @campanha");
        //        query.SetParameter("campanha", id);
        //        IDataReader reader = query.ExecuteQuery();

        //        while (reader.Read())
        //        {
        //            publico.Add(new Campanhas_PublicoAlvo(Convert.ToInt32(reader["idcampanha"]), Convert.ToString(reader["txestado"]), Convert.ToString(reader["txcidade"])));
        //        }
        //        reader.Close();
        //        session.Close();

        //        return publico;
        //    }
        //    catch (Exception error)
        //    {
        //        throw error;
        //    }

        //}

        public List<Campanhas_Cidades_Estados> BuscarEstados(int id)
        {
            try
            {
                List<Campanhas_Cidades_Estados> estados = new List<Campanhas_Cidades_Estados>();
                DBSession session = new DBSession();
                Query query = session.CreateQuery("select distinct txestado, idcampanha from mailing_campanhas_cidades where idcampanha = @campanha");
                query.SetParameter("campanha", id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    estados.Add(new Campanhas_Cidades_Estados(Convert.ToInt32(reader["idcampanha"]), Convert.ToString(reader["txestado"])));
                }
                reader.Close();
                session.Close();

                return estados;
            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public String BuscarCidades(int id, string estado)
        {
            try
            {
                String cidades = "";
                DBSession session = new DBSession();
                Query query = session.CreateQuery("SELECT SUBSTRING((SELECT ',' + Cast(txcidade as varchar) from mailing_campanhas_cidades WHERE idcampanha = @campanha and txestado = @estado FOR XML PATH('')),2,9999) as cidades");
                query.SetParameter("campanha", id);
                query.SetParameter("estado", estado);
                IDataReader reader = query.ExecuteQuery();

                if (reader.Read())
                {
                    cidades = Convert.ToString(reader["cidades"]);
                }
                reader.Close();
                session.Close();

                return cidades;
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
                Query query = session.CreateQuery("select * from mailing_campanhas_cidades where idcampanha = @campanha");
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

        public List<string> Emails(int id)
        {
            try
            {
                //    SELECT ANTERIOR
                //select distinct email from (select distinct a.email from aluno as a inner join mailing_campanhas_publicoalvo as mcp ON (a.estado = mcp.txestado and mcp.txcidade = '') OR (a.estado = mcp.txestado and a.cidade = mcp.txcidade) where mcp.idcampanha = @idcampanha and a.envio_email = 1 AND not exists ((select distinct email from mailing_campanhas_exclusoes as mce inner join curso as e_c ON mce.idcurso = e_c.titulo_curso INNER JOIN aluno_curso as e_ac ON e_c.codigo = e_ac.curso AND ((mce.fltipo = 'M' and e_ac.situacao = 2) OR (mce.fltipo = 'N' and e_ac.situacao < 2) OR (mce.fltipo = 'A' and e_ac.situacao = 2 and e_c.data_inicio between dateadd(month, -20, getdate()) and GETDATE())) inner join aluno as e_a ON e_a.codigo = e_ac.aluno where mce.idcampanha = mcp.idcampanha and e_ac.envio_email = 1))) as t1 union (select distinct a.email from aluno as a inner join aluno_curso as ac ON a.codigo = ac.aluno INNER JOIN curso as c ON ac.curso = c.codigo inner join cidade as ci ON c.cidade_codigo = ci.codigo inner join mailing_campanhas_publicoalvo as mcp ON ci.estado = mcp.txestado where mcp.idcampanha = @idcampanha and a.envio_email = 1 and ac.envio_email = 1 and ((mcp.txcidade = '' and exists(select * from cidade as ci2 inner join curso as c2 on ci2.codigo = c2.cidade_codigo inner join mailing_campanhas_cursos as mcc ON mcc.idcurso = c2.codigo where mcc.idcampanha = mcp.idcampanha and ci2.estado = ci.estado)) OR (mcp.txcidade != '' and exists (select * from cidade as ci2 inner join curso as c2 on ci2.codigo = c2.cidade_codigo inner join mailing_campanhas_cursos as mcc ON mcc.idcurso = c2.codigo where mcc.idcampanha = mcp.idcampanha and ci2.cidade = ci.cidade and ci2.estado = ci.estado))) and not exists (select distinct email from mailing_campanhas_exclusoes as mce inner join curso as e_c ON mce.idcurso = e_c.titulo_curso INNER JOIN aluno_curso as e_ac ON e_c.codigo = e_ac.curso AND ((mce.fltipo = 'M' and e_ac.situacao = 2) OR (mce.fltipo = 'N' and e_ac.situacao < 2) OR (mce.fltipo = 'A' and e_ac.situacao = 2 and e_c.data_inicio between dateadd(month, -20, getdate()) and GETDATE())) inner join aluno as e_a ON e_a.codigo = e_ac.aluno where mce.idcampanha = mcp.idcampanha and e_a.email = a.email)) ORDER BY email

                List<string> publico = new List<string>();
                DBSession session = new DBSession();
                Query query = session.CreateQuery(@"
                        select distinct email from (
	                    /*
	                    Seleciona os e-mails dos mailing_campanhas_cidades dos alunos
	                    */
	                    (select distinct a.email 
		                    from aluno as a 
			                    inner join mailing_campanhas_cidades as mcc ON (a.estado = mcc.txestado and mcc.txcidade = '') OR (a.estado = mcc.txestado and a.cidade = mcc.txcidade) 
		                    where mcc.idcampanha = @idcampanha and a.envio_email = 1)
	                    union
	                    /*
	                    Seleciona os e-mails dos mailing_campanhas_cidades da cidade curso
	                    */
	                    (select distinct a.email 
		                    from aluno as a 
			                    inner join aluno_curso as ac ON a.codigo = ac.aluno
			                    INNER JOIN curso as c ON ac.curso = c.codigo
			                    inner join cidade as ci ON c.cidade_codigo = ci.codigo
                                inner join mailing_campanhas_cidades as mcc ON (ci.estado = mcc.txestado and mcc.txcidade = '') OR (ci.estado = mcc.txestado and ci.cidade = mcc.txcidade)
		                    where 
			                    mcc.idcampanha = @idcampanha
			                    and a.envio_email = 1
			                    and ac.envio_email = 1
			                    and (
				                    (mcc.txcidade = ''
					                    and exists(
						                    select * from 
						                    cidade as ci2
						                    inner join curso as c2 on ci2.codigo = c2.cidade_codigo
						                    inner join mailing_campanhas_cursos as mcc1 ON mcc1.idcurso = c2.codigo
						                    where mcc1.idcampanha = mcc.idcampanha and ci2.estado = ci.estado)
				                    ) OR (
					                    mcc.txcidade != ''
					                    and exists(
						                    select * from 
						                    cidade as ci2
						                    inner join curso as c2 on ci2.codigo = c2.cidade_codigo
						                    inner join mailing_campanhas_cursos as mcc1 ON mcc1.idcurso = c2.codigo
						                    where mcc1.idcampanha = mcc.idcampanha
							                    and ci2.cidade = ci.cidade
							                    and ci2.estado = ci.estado
					                    )
				                    )
			                    )
	                        )
	                        union
	                    /*
	                    Seleciona os e-mails dos mailing_campanhas_cursos_envio
	                    */
	                    (select distinct email 
				                    from mailing_campanhas_cursos_envio as mcce 
				                    inner join curso as c ON ((mcce.idcurso = 0 AND mcce.idtitulo = c.titulo_curso) OR (mcce.idcurso > 0 AND mcce.idcurso = c.codigo))
                                    INNER JOIN aluno_curso as ac ON ac.curso = c.codigo AND (
					                    (mcce.fltipo = 'M' and ac.situacao = 2)
					                        OR (mcce.fltipo = 'N' and ac.situacao < 2)
					                        OR (mcce.fltipo = 'R' and ac.situacao = 1)
                                            OR (mcce.fltipo = 'D' and ac.situacao in (3,4))
				                    )
				                    inner join aluno as a ON a.codigo = ac.aluno
				                    where mcce.idcampanha = @idcampanha and ac.envio_email = 1 and a.envio_email = 1)
	                        union
                        /*
	                    Seleciona os e-mails do medtv
	                    */
	                    (select distinct a.email	
		                    from aluno_medtv am
		                    inner join aluno a on a.codigo = am.aluno
		                    where (exists(select idcampanha from mailing_campanhas_publicoalvo as mcp where mcp.idcampanha = @idcampanha and mcp.tipo = 5 and mcp.idcampanharef = 1)) or
		                    (exists(select idcampanha from mailing_campanhas_publicoalvo as mcp where mcp.idcampanha = @idcampanha and mcp.tipo = 5 and mcp.idcampanharef = 2)) and am.ativo = 1 and am.ativoAte >= getdate())
		                    union
	                    /*
	                    Seleciona os e-mails dos mailing_campanhas_publicoalvo tipo 3 ou 4
	                    */
	                    (select distinct email 
				                    from mailing_campanhas_publicoalvo as mcp 
				                    inner join mailing_enviados as mce on mcp.idcampanharef = mce.idcampanha
				                    inner join aluno as a ON a.email = mce.txpara
				                    where mcp.idcampanha = @idcampanha and ((mcp.tipo = 3 and exists (select ma.idenviado from mailing_abriu as ma where ma.idenviado = mce.idenviado)) OR (mcp.tipo = 4 and exists (select mc.idenviado from mailing_clicou as mc where mc.idenviado = mce.idenviado))) and a.envio_email = 1)
	 
	                        ) as t WHERE  
		                    /*
		                    Remove os e-mails através da mailing_campanhas_exclusoes
		                    */
		                    not exists (
			                    select distinct email 
				                    from mailing_campanhas_exclusoes as mce 
				                    inner join curso as c ON ((mce.idcurso = 0 AND mce.idtitulo = c.titulo_curso) OR (mce.idcurso > 0 AND mce.idcurso = c.codigo))
				                    INNER JOIN aluno_curso as ac ON ac.curso = c.codigo AND (
					                    (mce.fltipo = 'M' and ac.situacao = 2)
					                        OR (mce.fltipo = 'N' and ac.situacao < 2)
					                        OR (mce.fltipo = 'R' and ac.situacao = 1)
                                            OR (mce.fltipo = 'D' and ac.situacao in (3,4))
				                    )
				                    inner join aluno as a ON a.codigo = ac.aluno
				                    where mce.idcampanha = @idcampanha and a.email = t.email
		                    )
                        ORDER BY email");

                query.SetParameter("idcampanha", id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    publico.Add(Convert.ToString(reader["email"]));
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

        public List<string> Emails_E(int id)
        {
            try
            {
                List<string> publico = new List<string>();
                DBSession session = new DBSession();
                Query query = session.CreateQuery(@"select distinct email from (
	                    /*
	                    Seleciona os e-mails dos mailing_campanhas_cursos_envio
	                    */
	                    (select distinct email 
				                    from mailing_campanhas_cursos_envio as mcce 
				                    inner join curso as c ON ((mcce.idcurso = 0 AND mcce.idtitulo = c.titulo_curso) OR (mcce.idcurso > 0 AND mcce.idcurso = c.codigo))
                                    INNER JOIN aluno_curso as ac ON ac.curso = c.codigo AND (
					                    (mcce.fltipo = 'M' and ac.situacao = 2)
					                        OR (mcce.fltipo = 'N' and ac.situacao < 2)
					                        OR (mcce.fltipo = 'R' and ac.situacao = 1)
                                            OR (mcce.fltipo = 'D' and ac.situacao in (3,4))
				                    )
				                    inner join aluno as a ON a.codigo = ac.aluno
				                    where mcce.idcampanha = @idcampanha and ac.envio_email = 1 and a.envio_email = 1 AND EXISTS (select * 
		                    from mailing_campanhas_cidades as mcc  
		                    where mcc.idcampanha = mcce.idcampanha AND ((mcc.txcidade = '' AND a.estado = mcc.txestado) OR (mcc.txcidade != '' AND replace(upper(a.cidade), ' ', '') = replace(upper(mcc.txcidade), ' ', '') AND a.estado = mcc.txestado)))
				                    )
	                        union
                        /*
	                    Seleciona os e-mails do medtv
	                    */
	                    (select distinct a.email	
		                    from aluno_medtv am
		                    inner join aluno a on a.codigo = am.aluno
		                    where (exists(select idcampanha from mailing_campanhas_publicoalvo as mcp where mcp.idcampanha = @idcampanha and mcp.tipo = 5 and mcp.idcampanharef = 1)) or
		                    (exists(select idcampanha from mailing_campanhas_publicoalvo as mcp where mcp.idcampanha = @idcampanha and mcp.tipo = 5 and mcp.idcampanharef = 2)) and am.ativo = 1 and am.ativoAte >= getdate())
		                    union
	                    /*
	                    Seleciona os e-mails dos mailing_campanhas_publicoalvo tipo 3 ou 4
	                    */
	                    (select distinct email 
				                    from mailing_campanhas_publicoalvo as mcp 
				                    inner join mailing_enviados as mce on mcp.idcampanharef = mce.idcampanha
				                    inner join aluno as a ON a.email = mce.txpara
				                    where mcp.idcampanha = @idcampanha and ((mcp.tipo = 3 and exists (select ma.idenviado from mailing_abriu as ma where ma.idenviado = mce.idenviado)) OR (mcp.tipo = 4 and exists (select mc.idenviado from mailing_clicou as mc where mc.idenviado = mce.idenviado))) and a.envio_email = 1)
	 
                    ) as t WHERE  
                    /*
                    Remove os e-mails através da mailing_campanhas_exclusoes
                    */
                    not exists (
	                    select distinct email 
		                    from mailing_campanhas_exclusoes as mce 
		                    inner join curso as c ON ((mce.idcurso = 0 AND mce.idtitulo = c.titulo_curso) OR (mce.idcurso > 0 AND mce.idcurso = c.codigo))
		                    INNER JOIN aluno_curso as ac ON ac.curso = c.codigo AND (
			                    (mce.fltipo = 'M' and ac.situacao = 2)
				                    OR (mce.fltipo = 'N' and ac.situacao < 2)
				                    OR (mce.fltipo = 'R' and ac.situacao = 1)
                                    OR (mce.fltipo = 'D' and ac.situacao in (3,4))
		                    )
		                    inner join aluno as a ON a.codigo = ac.aluno
		                    where mce.idcampanha = @idcampanha and a.email = t.email
                    )
                    ORDER BY email");

                query.SetParameter("idcampanha", id);
                IDataReader reader = query.ExecuteQuery();

                while (reader.Read())
                {
                    publico.Add(Convert.ToString(reader["email"]));
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

    }
}
