using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Biblioteca.Entidades;

namespace Biblioteca.DB
{
    public class MidiaDB
    {
        public void Salvar(Midia variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("INSERT INTO midia (midia_tipo_id, data, painel, titulo, descricao, valor, obs, visualizacoes, alcance, curtidas, comentario_positivo, comentario_negativo, compartilhamento, impulsionada, identificador) VALUES (@midia_tipo, @data, @painel, @titulo, @descricao, @valor, @obs, @visualizacoes, @alcance, @curtidas, @comentario_positivo, @comentario_negativo, @compartilhamento, @impulsionada, @identificador) ");
                query.SetParameter("midia_tipo", variavel.midia_tipo_id.midia_tipo_id)
                    .SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("descricao", variavel.descricao)
                    .SetParameter("valor", variavel.valor)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("visualizacoes", variavel.visualizacoes)
                    .SetParameter("alcance", variavel.alcance)
                    .SetParameter("curtidas", variavel.curtidas)
                    .SetParameter("comentario_positivo", variavel.comentario_positivo)
                    .SetParameter("comentario_negativo", variavel.comentario_negativo)
                    .SetParameter("compartilhamento", variavel.compartilhamento)
                    .SetParameter("impulsionada", variavel.impulsionada)
                    .SetParameter("identificador", variavel.identificador);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(Midia variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("UPDATE Midia SET midia_tipo_id = @midia_tipo_id, data = @data, painel = @painel, titulo = @titulo, descricao = @descricao, valor = @valor, obs = @obs, visualizacoes = @visualizacoes, alcance = @alcance, curtidas = @curtidas, comentario_positivo = @comentario_positivo, comentario_negativo = @comentario_negativo, compartilhamento @compartilhamento, impulsionada = @impulsionada, identificador = @identificador WHERE midia_id = @midia_id;");
                query.SetParameter("midia_tipo_id", variavel.midia_tipo_id.midia_tipo_id)
                    .SetParameter("data", variavel.data)
                    .SetParameter("painel", variavel.painel.codigo)
                    .SetParameter("titulo", variavel.titulo)
                    .SetParameter("descricao", variavel.descricao)
                    .SetParameter("midia_id", variavel.midia_id)
                    .SetParameter("valor", variavel.valor)
                    .SetParameter("obs", variavel.obs)
                    .SetParameter("visualizacoes", variavel.visualizacoes)
                    .SetParameter("alcance", variavel.alcance)
                    .SetParameter("curtidas", variavel.curtidas)
                    .SetParameter("comentario_positivo", variavel.comentario_positivo)
                    .SetParameter("comentario_negativo", variavel.comentario_negativo)
                    .SetParameter("compartilhamento", variavel.compartilhamento)
                    .SetParameter("impulsionada", variavel.impulsionada)
                    .SetParameter("identificador", variavel.identificador);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Midia variavel)
        {
            try
            {
                DBSession session = new DBSession();
                Query query = session.CreateQuery("DELETE FROM midia WHERE midia_id = @midia_id; DELETE FROM midia_curso WHERE midia_id = @midia_id; DELETE FROM midia_cidade WHERE midia_id = @midia_id; DELETE FROM midia_titulo_curso WHERE midia_id = @midia_id; DELETE FROM midia_arquivo WHERE midia_id = @midia_id;");
                query.SetParameter("midia_id", variavel.midia_id);
                query.ExecuteUpdate();
                session.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public bool Existe(string identificador)
        {
            bool retorno = false;
            try
            {
                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM midia WHERE identificador = @identificador");
                quey.SetParameter("identificador", identificador);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = true;
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Midia Buscar(int id)
        {
            Midia retorno;
            try
            {
                retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM midia WHERE midia_id = @id");
                quey.SetParameter("id", id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Midia(Convert.ToInt32(reader["midia_id"]), new Midia_tipoDB().Buscar(Convert.ToInt32(reader["midia_tipo_id"])), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToDecimal(reader["valor"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["visualizacoes"]), Convert.ToInt32(reader["alcance"]), Convert.ToInt32(reader["curtidas"]), Convert.ToInt32(reader["comentario_positivo"]), Convert.ToInt32(reader["comentario_negativo"]), Convert.ToInt32(reader["compartilhamento"]), Convert.ToBoolean(reader["impulsionada"]), new CidadeDB().ListarMidia(Convert.ToInt32(reader["midia_id"])), new Titulo_cursoDB().ListarMidia(Convert.ToInt32(reader["midia_id"])), new CursoDB().ListarMidia(Convert.ToInt32(reader["midia_id"])), Convert.ToString(reader["identificador"]));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Midia Buscar(string titulo, Midia_tipo tipo)
        {
            Midia retorno;
            try
            {
                retorno = null;

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM midia WHERE titulo = @titulo AND midia_tipo_id = @tipo ORDER BY midia_id DESC");
                quey.SetParameter("titulo", titulo).SetParameter("tipo", tipo.midia_tipo_id);
                IDataReader reader = quey.ExecuteQuery();

                if (reader.Read())
                {
                    retorno = new Midia(Convert.ToInt32(reader["midia_id"]), new Midia_tipoDB().Buscar(Convert.ToInt32(reader["midia_tipo_id"])), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToDecimal(reader["valor"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["visualizacoes"]), Convert.ToInt32(reader["alcance"]), Convert.ToInt32(reader["curtidas"]), Convert.ToInt32(reader["comentario_positivo"]), Convert.ToInt32(reader["comentario_negativo"]), Convert.ToInt32(reader["compartilhamento"]), Convert.ToBoolean(reader["impulsionada"]), Convert.ToString(reader["identificador"]));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Midia> Listar()
        {
            List<Midia> retorno;
            try
            {
                retorno = new List<Midia>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Midia ORDER BY data DESC");
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Midia(Convert.ToInt32(reader["midia_id"]), new Midia_tipoDB().Buscar(Convert.ToInt32(reader["midia_tipo_id"])), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToDecimal(reader["valor"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["visualizacoes"]), Convert.ToInt32(reader["alcance"]), Convert.ToInt32(reader["curtidas"]), Convert.ToInt32(reader["comentario_positivo"]), Convert.ToInt32(reader["comentario_negativo"]), Convert.ToInt32(reader["compartilhamento"]), Convert.ToBoolean(reader["impulsionada"]), Convert.ToString(reader["identificador"])));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Midia> Listar(Midia_tipo tipo)
        {
            List<Midia> retorno;
            try
            {
                retorno = new List<Midia>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT * FROM Midia WHERE midia_tipo_id = @tipo ORDER BY data DESC")
                    .SetParameter("tipo", tipo.midia_tipo_id);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Midia(Convert.ToInt32(reader["midia_id"]), tipo, new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToDecimal(reader["valor"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["visualizacoes"]), Convert.ToInt32(reader["alcance"]), Convert.ToInt32(reader["curtidas"]), Convert.ToInt32(reader["comentario_positivo"]), Convert.ToInt32(reader["comentario_negativo"]), Convert.ToInt32(reader["compartilhamento"]), Convert.ToBoolean(reader["impulsionada"]), Convert.ToString(reader["identificador"])));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Midia> Listar(Titulo_curso variavel)
        {
            List<Midia> retorno;
            try
            {
                retorno = new List<Midia>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT m.midia_id, m.midia_tipo_id, m.painel, m.data, m.titulo, m.descricao FROM Midia AS m JOIN midia_titulo_curso as mtc ON m.midia_id = mtc.midia_id WHERE mtc.titulo_curso = @id ORDER BY m.data DESC")
                    .SetParameter("id", variavel.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Midia(Convert.ToInt32(reader["midia_id"]), new Midia_tipoDB().Buscar(Convert.ToInt32(reader["midia_tipo_id"])), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToDecimal(reader["valor"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["visualizacoes"]), Convert.ToInt32(reader["alcance"]), Convert.ToInt32(reader["curtidas"]), Convert.ToInt32(reader["comentario_positivo"]), Convert.ToInt32(reader["comentario_negativo"]), Convert.ToInt32(reader["compartilhamento"]), Convert.ToBoolean(reader["impulsionada"]), Convert.ToString(reader["identificador"])));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Midia> Listar(Curso variavel)
        {
            List<Midia> retorno;
            try
            {
                retorno = new List<Midia>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT m.midia_id, m.midia_tipo_id, m.painel, m.data, m.titulo, m.descricao FROM Midia AS m JOIN midia_curso as mc ON m.midia_id = mc.midia_id WHERE mc.cidade = @id ORDER BY m.data DESC")
                    .SetParameter("id", variavel.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Midia(Convert.ToInt32(reader["midia_id"]), new Midia_tipoDB().Buscar(Convert.ToInt32(reader["midia_tipo_id"])), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToDecimal(reader["valor"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["visualizacoes"]), Convert.ToInt32(reader["alcance"]), Convert.ToInt32(reader["curtidas"]), Convert.ToInt32(reader["comentario_positivo"]), Convert.ToInt32(reader["comentario_negativo"]), Convert.ToInt32(reader["compartilhamento"]), Convert.ToBoolean(reader["impulsionada"]), Convert.ToString(reader["identificador"])));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Midia> Listar(Cidade variavel)
        {
            List<Midia> retorno;
            try
            {
                retorno = new List<Midia>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("SELECT m.midia_id, m.midia_tipo_id, m.painel, m.data, m.titulo, m.descricao FROM Midia AS m JOIN midia_cidade as mc ON m.midia_id = mc.midia_id WHERE mc.cidade = @id ORDER BY m.data DESC")
                    .SetParameter("id", variavel.codigo);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Midia(Convert.ToInt32(reader["midia_id"]), new Midia_tipoDB().Buscar(Convert.ToInt32(reader["midia_tipo_id"])), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToDecimal(reader["valor"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["visualizacoes"]), Convert.ToInt32(reader["alcance"]), Convert.ToInt32(reader["curtidas"]), Convert.ToInt32(reader["comentario_positivo"]), Convert.ToInt32(reader["comentario_negativo"]), Convert.ToInt32(reader["compartilhamento"]), Convert.ToBoolean(reader["impulsionada"]), Convert.ToString(reader["identificador"])));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Midia> Listar(int midia_tipo = 0, int cidade = 0, int titulo_curso = 0, int curso = 0)
        {
            List<Midia> retorno;
            try
            {
                retorno = new List<Midia>();

                string executar = "SELECT m.midia_id, m.midia_tipo_id, m.painel, m.data, m.titulo, m.descricao, m.valor, m.obs, m.visualizacoes, m.alcance, m.curtidas, m.comentario_positivo, m.comentario_negativo, m.compartilhamento, m.impulsionada, m.identificador  FROM Midia AS m WHERE m.midia_id > 0";
                if (midia_tipo > 0)
                    executar += " AND m.midia_tipo_id = " + midia_tipo;
                if (cidade > 0)
                    executar += " AND EXISTS (SELECT mc.midia_id FROM midia_cidade AS mc WHERE mc.midia_id = m.midia_id AND mc.cidade = " + cidade + ")";
                if (titulo_curso > 0)
                    executar += " AND EXISTS (SELECT mc.midia_id FROM midia_titulo_curso AS mt WHERE mt.midia_id = m.midia_id AND mt.titulo_curso = " + titulo_curso + ")";
                if (curso > 0)
                    executar += " AND EXISTS (SELECT mc.midia_id FROM midia_curso AS mc WHERE mc.midia_id = m.midia_id AND mc.curso = " + curso + ")";
                executar += " ORDER BY m.data DESC";

                DBSession session = new DBSession();
                Query quey = session.CreateQuery(executar);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Midia(Convert.ToInt32(reader["midia_id"]), new Midia_tipoDB().Buscar(Convert.ToInt32(reader["midia_tipo_id"])), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToDecimal(reader["valor"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["visualizacoes"]), Convert.ToInt32(reader["alcance"]), Convert.ToInt32(reader["curtidas"]), Convert.ToInt32(reader["comentario_positivo"]), Convert.ToInt32(reader["comentario_negativo"]), Convert.ToInt32(reader["compartilhamento"]), Convert.ToBoolean(reader["impulsionada"]), new CidadeDB().ListarMidia(Convert.ToInt32(reader["midia_id"])), new Titulo_cursoDB().ListarMidia(Convert.ToInt32(reader["midia_id"])), new CursoDB().ListarMidia(Convert.ToInt32(reader["midia_id"])), Convert.ToString(reader["identificador"])));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<Midia> Listar(string curso, DateTime inicio, DateTime fim)
        {
            List<Midia> retorno;
            try
            {
                retorno = new List<Midia>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select m.midia_id, m.data, m.titulo, m.descricao, m.midia_tipo_id, m.painel, m.valor, m.obs, m.visualizacoes, m.alcance, m.obs, m.visualizacoes, m.curtidas, m.comentario_positivo, m.comentario_negativo, m.compartilhamento, m.impulsionada from curso as c left join midia_titulo_curso as mtc ON mtc.titulo_curso = c.titulo_curso left join midia_cidade as mcid ON mcid.cidade = c.cidade_codigo LEFT JOIN midia_curso AS mc ON mc.curso = c.codigo JOIN midia as m on m.midia_id = mtc.midia_id OR m.midia_id = mcid.midia_id OR m.midia_id = mc.midia_id where c.titulo1 = @curso AND m.data between @inicio and @fim ORDER BY data")
                    .SetParameter("curso", curso)
                    .SetParameter("inicio", inicio)
                    .SetParameter("fim", fim);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new Midia(Convert.ToInt32(reader["midia_id"]), new Midia_tipoDB().Buscar(Convert.ToInt32(reader["midia_tipo_id"])), new Painel() { codigo = Convert.ToInt32(reader["painel"]) }, Convert.ToDateTime(reader["data"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToDecimal(reader["valor"]), Convert.ToString(reader["obs"]), Convert.ToInt32(reader["visualizacoes"]), Convert.ToInt32(reader["alcance"]), Convert.ToInt32(reader["curtidas"]), Convert.ToInt32(reader["comentario_positivo"]), Convert.ToInt32(reader["comentario_negativo"]), Convert.ToInt32(reader["compartilhamento"]), Convert.ToBoolean(reader["impulsionada"]), Convert.ToString(reader["identificador"])));
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public List<MidiaCampanhas> ListarCampanha(int curso, DateTime inicio, DateTime fim)
        {
            List<MidiaCampanhas> retorno;
            try
            {
                retorno = new List<MidiaCampanhas>();

                DBSession session = new DBSession();
                Query quey = session.CreateQuery("select mc.idcampanha, mc.txcampanha, isnull((select top 1 me.dtenviarapartir from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha ORDER BY me.dtdata), '01/01/1900') as data from mailing_campanhas as mc inner join mailing_campanhas_cursos as mcc ON mc.idcampanha = mcc.idcampanha where mcc.idcurso = @curso and EXISTS (select me.idenviado from mailing_enviados as me WHERE me.idcampanha = mc.idcampanha and me.dtenviarapartir between @inicio and @fim)")
                    .SetParameter("curso", curso)
                    .SetParameter("inicio", inicio)
                    .SetParameter("fim", fim);
                IDataReader reader = quey.ExecuteQuery();

                while (reader.Read())
                {
                    retorno.Add(new MidiaCampanhas() {
                            idcampanha = Convert.ToInt32(reader["idcampanha"]),
                            txcampanha = Convert.ToString(reader["txcampanha"]),
                            data = Convert.ToDateTime(reader["data"])
                    });
                }
                reader.Close();
                session.Close();

                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
