using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using Biblioteca.DB;

namespace Biblioteca.Funcoes
{
    public class AutomacaoEAD
    {
        public static void Executar()
        {
            List<Curso> lista = new CursoDB().BuscarListaEADTermino();

            foreach (var a in lista)
            {
                // Envia aviso aos alunos informando no período final do curso
                if ((a.codigo == 15) || (a.codigo == 10) || (a.codigo == 5))
                {
                    // Lista alunos
                    List<Aluno> aluno = new Aluno_cursoDB().ListarAlunosEad(new CursoDB().Buscar(a.titulo1).codigo);
                    foreach (var l in aluno)
                    {
                        new Envio_emailDB().Salvar(new Envio_email()
                        {
                            para = l.email,
                            assunto = "Últimos dias para concluir seu curso EAD",
                            texto = "Prezado(a) Dr(a). " + l.nome + ", bom dia.<br><Br>Restam apenas " + a.codigo + " dias para que expire o prazo de acesso ao curso: " + a.titulo + "<Br><br>Qualquer dúvida, me mantenho à disposição por e-mail, pela nossa Central de Atendimento 0300-31-31-538 (custo de ligação local) e também pelo WhatsApp (62) 9 8164-4645.<br><Br>Obrigado.<br><Br>Atenciosamente,<br><br><table style='float: none; height: 100px; width: 570px;' border='0' width='570' align='left'>  <tbody>  <tr valign='top'>  <td width='200'><span style='font-size: small;'> <a style='color: #336699; font-weight: normal; text-decoration: underline;'><img style='border: 0; line-height: 100%; outline: none; text-decoration: none; display: inline;' src='https://cenbrap.com.br/public/mailing/images/logo_menor.jpg' alt='Logomarca Cenbrap' align='none' /></a> </span></td>  <td style='text-align: left;' width='350'><span style='font-size: 8pt;'><span style='color: #808080;'><strong>Fernando Tiago |&nbsp; </strong></span><span style='color: #808080;'><span style='color: #888888;'><em>Coordenação Pedagógica Adjunta</em></span></span></span><br /><span style='margin-top: 0px; margin-bottom: 0px;'><span style='margin-top: 0px; margin-bottom: 0px;'><span style='font-size: 8pt;'><span style='color: #ff6600;'><span style='color: #888888;'>pedagogico@cenbrap.com.br</span><br /></span><span style='color: #888888;'>WPP (62) 9 8164-4645<br />Faculdade CENBRAP</span></span><br /><br /></span></span></td>  </tr>  </tbody>  </table>",
                            data = DateTime.Now
                        });
                        break;
                    }

                }

                // Envia e-mail ao pedagógico para retirar do site
                if (a.codigo == 0)
                {
                    new Envio_emailDB().Salvar(new Envio_email()
                    {
                        para = "pedagogico@cenbrap.com.br",
                        assunto = "Aviso de último dia para o curso - " + a.titulo1,
                        texto = "Curso: " + a.titulo,
                        data = DateTime.Now
                    });
                }
            }
        }
    }

}