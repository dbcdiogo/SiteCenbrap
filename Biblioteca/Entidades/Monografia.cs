using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Monografia
    {
        public int codigo { get; set; }
        public Curso curso { get; set; }
        public Aluno aluno { get; set; }
        public DateTime data_inicial { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public string telefone { get; set; }
        public string msn { get; set; }
        public string problemas { get; set; }
        public string objetivos { get; set; }
        public string metodologia { get; set; }
        public string bibliografia { get; set; }
        public string justificativa { get; set; }
        public string hipotese { get; set; }
        public DateTime data_final { get; set; }
        public double nota { get; set; }
        public string arquivo { get; set; }
        public string obs { get; set; }
        public int parte1 { get; set; }
        public int parte2 { get; set; }
        public int parte3 { get; set; }
        public string problemas_corrigido { get; set; }
        public string objetivos_corrigido { get; set; }
        public string metodologia_corrigido { get; set; }
        public string bibliografia_corrigido { get; set; }
        public string justificativa_corrigido { get; set; }
        public string hipotese_corrigido { get; set; }
        public string recados { get; set; }
        public int conteudo { get; set; }
        public int formatacao { get; set; }
        public int pago { get; set; }

        public Monografia()
        {
            this.codigo = 0;
            this.curso = new Curso() { codigo = 0 };
            this.aluno = new Aluno() { codigo = 0 };
            this.data_inicial = DateTime.Now;
            this.nome = "";
            this.email = "";
            this.celular = "";
            this.telefone = "";
            this.msn = "";
            this.problemas = "";
            this.objetivos = "";
            this.metodologia = "";
            this.bibliografia = "";
            this.justificativa = "";
            this.hipotese = "";
            this.data_final = DateTime.Now;
            this.nota = 0;
            this.arquivo = "";
            this.obs = "";
            this.parte1 = 0;
            this.parte2 = 0;
            this.parte3 = 0;
            this.problemas_corrigido = "";
            this.objetivos_corrigido = "";
            this.metodologia_corrigido = "";
            this.bibliografia_corrigido = "";
            this.justificativa_corrigido = "";
            this.hipotese_corrigido = "";
            this.recados = "";
            this.conteudo = 0;
            this.formatacao = 0;
            this.pago = 0;
        }

        public Monografia(Curso curso, Aluno aluno, DateTime data_inical, string nome, int parte1, string email)
        {
            this.codigo = 0;
            this.curso = curso;
            this.aluno = aluno;
            this.data_inicial = data_inical;
            this.nome = nome;
            this.email = email;
            this.celular = "";
            this.telefone = "";
            this.msn = "";
            this.problemas = "";
            this.objetivos = "";
            this.metodologia = "";
            this.bibliografia = "";
            this.justificativa = "";
            this.hipotese = "";
            this.data_final = DateTime.Now;
            this.nota = 0;
            this.arquivo = "";
            this.obs = "";
            this.parte1 = parte1;
            this.parte2 = 0;
            this.parte3 = 0;
            this.problemas_corrigido = "";
            this.objetivos_corrigido = "";
            this.metodologia_corrigido = "";
            this.bibliografia_corrigido = "";
            this.justificativa_corrigido = "";
            this.hipotese_corrigido = "";
            this.recados = "";
            this.conteudo = 0;
            this.formatacao = 0;
            this.pago = 0;

            Salvar();

            //salva o andamento
            Monografia_andamento andamento = new Monografia_andamento(0, this.curso, this.aluno, this, DateTime.Now, 0, "", "Aluno acessou ambiente virtual do TCC.", 0);
            andamento.Salvar();

            //envia email
            //new Envio_email() { codigo = 0, para = "monografia@cenbrap.com.br", assunto = "Inscricao Monografia - www.cenbrap.com.br", texto = "Inicio do TCC:<BR>Data: <strong>" + DateTime.Now + "</strong><BR>Nome: <strong>" + this.aluno.nome + "</strong><BR><BR>", data = DateTime.Now, envio = 0, data_envio = DateTime.Now, hora_envio = DateTime.Now, agendado = 0, data_agendado = DateTime.Now, hora_agendado = DateTime.Now, encontro = 0, prioridade = 0, envio_email = "contato@cenbrap.com.br"}.Salvar();
        }

        public Monografia(int codigo, Curso curso, Aluno aluno, DateTime data_inicial, string nome, string email, string celular, string telefone, string msn, string problemas, string objetivos, string metodologia, string bibliografia, string justificativa, string hipotese, DateTime data_final, double nota, string arquivo, string obs, int parte1, int parte2, int parte3, string problemas_corrigido, string objetivos_corrigido, string metodologia_corrigido, string bibliografia_corrigido, string justificativa_corrigido, string hipotese_corrigido, string recados, int conteudo, int formatacao, int pago)
        {
            this.codigo = codigo;
            this.curso = curso;
            this.aluno = aluno;
            this.data_inicial = data_inicial;
            this.nome = nome;
            this.email = email;
            this.celular = celular;
            this.telefone = telefone;
            this.msn = msn;
            this.problemas = problemas;
            this.objetivos = objetivos;
            this.metodologia = metodologia;
            this.bibliografia = bibliografia;
            this.justificativa = justificativa;
            this.hipotese = hipotese;
            this.data_final = data_final;
            this.nota = nota;
            this.arquivo = arquivo;
            this.obs = obs;
            this.parte1 = parte1;
            this.parte2 = parte2;
            this.parte3 = parte3;
            this.problemas_corrigido = problemas_corrigido;
            this.objetivos_corrigido = objetivos_corrigido;
            this.metodologia_corrigido = metodologia_corrigido;
            this.bibliografia_corrigido = bibliografia_corrigido;
            this.justificativa_corrigido = justificativa_corrigido;
            this.hipotese_corrigido = hipotese_corrigido;
            this.recados = recados;
            this.conteudo = conteudo;
            this.formatacao = formatacao;
            this.pago = pago;

        }

        public void Salvar()
        {
            this.codigo = new MonografiaDB().SalvarRetornar(this);
        }

        public void Alterar()
        {
            new MonografiaDB().Alterar(this);
        }

        public void Excluir()
        {
            new MonografiaDB().Excluir(this);
        }
    }
}
