using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using Biblioteca.DB;

namespace Biblioteca.Funcoes
{
    public class GerarEmails
    {
        public static void Agendados()
        {
            //Verifica se tem algum agendamento para a próxima hora
            List<Campanhas_Agendamento> agendados = new Campanhas_AgendamentoDB().AgendadosProximaHora();

            foreach(var a in agendados)
            {
                GerarEnviados(a.idcampanha, Convert.ToDateTime(a.dtenvio));
            }
        }

        public static void GerarEnviados(int id, DateTime data)
        {

            CampanhasDB cdb = new CampanhasDB();
            Campanhas campanha = new CampanhasDB().Buscar(id);
            campanha.idmensagem = new MensagensDB().Buscar(campanha.idmensagem.idmensagem);

            Contas conta = cdb.Remetentes(id);

            EnviadoDB db = new EnviadoDB();

            List<string> lista = new List<string>();

            if(campanha.condicao == "O")
            {
                lista = new Campanhas_CidadesDB().Emails(id);
            }
            else
            {
                lista = new Campanhas_CidadesDB().Emails_E(id);
            }

            foreach (var e in lista)
            {
                if (!db.Existe(id, e))
                {
                    byte[] key = Encoding.ASCII.GetBytes(e + "#" + campanha.idcampanha);

                    Enviado env = new Enviado()
                    {
                        dtdata = DateTime.Now,
                        dtenviarapartir = data,
                        dtenviado = Convert.ToDateTime("01/01/1900"),
                        flenviado = false,
                        idcampanha = campanha,
                        idemail = cdb.Remetentes(id),
                        nrprioridade = 1,
                        txtitulo = campanha.idmensagem.titulo,
                        responder = cdb.Responder(id),
                        txpara = e,
                        txtexto = campanha.idmensagem.texto.Replace("[EMAIL_ALUNO]", e).Replace("[PRIMEIRO_NOME]", new AlunoDB().PrimeiroNome(e)).Replace("[CHAVE]", Crypt.Encode(key))
                    };
                    env.SalvarRetornar();
                    env.Link();
                }
            }
        }
    }
}
