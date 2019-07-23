using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Aluno_pgto
    {
        public int codigo { get; set; }
        public Aluno aluno { get; set; }
        public Curso curso { get; set; }
        public Aluno_curso aluno_curso { get; set; }
        public int boleto_avulso { get; set; }
        public DateTime data { get; set; }
        public DateTime vencimento { get; set; }
        public double total { get; set; }
        public int total_parcelas { get; set; }
        public double desconto_pgto_dia { get; set; }
        public int forma_pgto { get; set; }
        public int parcela { get; set; }
        public double valor_parcela { get; set; }
        public int situacao { get; set; }
        public int painel { get; set; }
        public int painel_pgto { get; set; }
        public DateTime data_pgto { get; set; }
        public string obs { get; set; }
        public int vinculado { get; set; }
        public double total_vinculado { get; set; }
        public DateTime data_gerado { get; set; }
        public string txt { get; set; }
        public double matricula { get; set; }
        public int boleto { get; set; }

        public Aluno_pgto()
        {
            this.codigo = 0;
            this.aluno = new Aluno() { codigo = 0 };
            this.curso = new Curso() { codigo = 0 };
            this.aluno_curso = new Aluno_curso() { codigo = 0 };
            this.boleto_avulso = 0;
            this.data = DateTime.Now;
            this.vencimento = DateTime.Now.AddDays(2);
            this.total = 0;
            this.total_parcelas = 0;
            this.desconto_pgto_dia = 0;
            this.forma_pgto = 0;
            this.parcela = 0;
            this.valor_parcela = 0;
            this.situacao = 1;
            this.painel = 0;
            this.painel_pgto = 0;
            this.data_pgto = Convert.ToDateTime("01/01/1900");
            this.obs = "";
            this.vinculado = 0;
            this.total_vinculado = 0;
            this.data_gerado = DateTime.Now;
            this.txt = "";
            this.matricula = 0;
            this.boleto = 0;
        }

        public Aluno_pgto(int codigo, Aluno aluno, Curso curso, Aluno_curso aluno_curso, int boleto_avulso, DateTime data, DateTime vencimento, double total, int total_parcelas, double desconto_pgto_dia, int forma_pgto, int parcela, double valor_parcela, int situacao, int painel, int painel_pgto, DateTime data_pgto, string obs, int vinculado, double total_vinculado, DateTime data_gerado, string txt, double matricula, int boleto)
        {
            this.codigo = codigo;
            this.aluno = aluno;
            this.curso = curso;
            this.aluno_curso = aluno_curso;
            this.boleto_avulso = boleto_avulso;
            this.data = data;
            this.vencimento = vencimento;
            this.total = total;
            this.total_parcelas = total_parcelas;
            this.desconto_pgto_dia = desconto_pgto_dia;
            this.forma_pgto = forma_pgto;
            this.parcela = parcela;
            this.valor_parcela = valor_parcela;
            this.situacao = situacao;
            this.painel = painel;
            this.painel_pgto = painel_pgto;
            this.data_pgto = data_pgto;
            this.obs = obs;
            this.vinculado = vinculado;
            this.total_vinculado = total_vinculado;
            this.data_gerado = data_gerado;
            this.txt = txt;
            this.matricula = matricula;
            this.boleto = boleto;

        }

        public void Salvar()
        {
            new Aluno_pgtoDB().Salvar(this);
        }

        public void Alterar()
        {
            new Aluno_pgtoDB().Alterar(this);
        }

        public void Excluir()
        {
            new Aluno_pgtoDB().Excluir(this);
        }

        public void CompletaCampos()
        {
            this.aluno_curso = new Aluno_cursoDB().Buscar(this.aluno_curso.codigo);
            this.aluno = new AlunoDB().Buscar(this.aluno.codigo);
            this.curso = new CursoDB().Buscar(this.curso.codigo);
        }

        public void Confirma()
        {
            this.data_pgto = DateTime.Now;
            this.Alterar();
            if(this.aluno_curso.situacao != 2)
            {
                this.aluno_curso.Confirma();
                this.EnviaConfirmacao();
                this.LancaEntrada();
            }
        }

        public void EnviaConfirmacao()
        {
            string titulo = "Confirmacao";

            if (this.curso.inicio_confirmado == 1)
                titulo = "Confirmacao-inicio-confirmado";

            Email_tipo et = new Email_tipoDB().Buscar(this.curso.tipo, titulo);

            string assunto = et.assunto;
            string txt = et.texto.Replace("#TITULOCURSO#", this.curso.titulo).Replace("#NOMEALUNO#", this.aluno.nome);

            new Envio_email() { para = this.aluno.email, assunto = assunto, texto = txt }.Salvar();

            this.aluno_curso.envio_pre_matricula = DateTime.Now;
            new Aluno_cursoDB().Alterar(this.aluno_curso);
        }

        public void LancaEntrada()
        {
            double valor = this.matricula;

            if (valor == 0)
            {
                valor = this.total;
            }

            Entrada entrada = new Entrada()
            {
                cliente = new Cliente(this.aluno, this.curso),
                data = DateTime.Now,
                boleto = "0",
                codboleto = 0,
                cod_verificacao = "",
                arquivo_xml = "",
                conta = new Conta() { codigo = 6 },
                conta_devolucao = new Conta() { codigo = 0 },
                codigo = 0,
                data_devolucao = Convert.ToDateTime("01/01/1900"),
                data_nota_fiscal = Convert.ToDateTime("01/01/1900"),
                data_quitado = DateTime.Now,
                data_recebimento = DateTime.Now.AddDays(30),
                desconto = 0,
                emolumento = "",
                identificacao = "Inscricao " + this.txt,
                juros = 0,
                multa = 0,
                negativado = 0,
                negativado_data = Convert.ToDateTime("01/01/1900"),
                negativado_data_removido = Convert.ToDateTime("01/01/1900"),
                negociacao = 0,
                nota_fiscal = "",
                obs_cancelado = "",
                painel = new Painel() { codigo = 0 },
                parcela = this.parcela.ToString(),
                situacao = 0,
                tipo_entrada = new Tipo_entrada() { codigo = 7 },
                tipo_pgto = "Cartão",
                valor = valor,
                vencimento = DateTime.Now,
                xml_envio = "",
                xml_retorno = "",

                valor_parcela1 = 0,
                valor_parcela2 = 0,
                valor_parcela3 = 0,
                valor_parcela4 = 0,
                valor_parcela5 = 0,
                valor_parcela6 = 0,

                data_recebimento2 = Convert.ToDateTime("01/01/1900"),
                data_recebimento3 = Convert.ToDateTime("01/01/1900"),
                data_recebimento4 = Convert.ToDateTime("01/01/1900"),
                data_recebimento5 = Convert.ToDateTime("01/01/1900"),
                data_recebimento6 = Convert.ToDateTime("01/01/1900")
            };

            if(this.parcela == 2)
            {
                entrada.valor_parcela1 = entrada.valor / this.parcela;
                entrada.valor_parcela2 = entrada.valor / this.parcela;
                entrada.data_recebimento2 = entrada.data_recebimento.AddDays(60);
            }

            if (this.parcela == 3)
            {
                entrada.valor_parcela1 = entrada.valor / this.parcela;
                entrada.valor_parcela2 = entrada.valor / this.parcela;
                entrada.valor_parcela3 = entrada.valor / this.parcela;
                entrada.data_recebimento2 = entrada.data_recebimento.AddDays(60);
                entrada.data_recebimento3 = entrada.data_recebimento.AddDays(90);
            }

            if (this.parcela == 4)
            {
                entrada.valor_parcela1 = entrada.valor / this.parcela;
                entrada.valor_parcela2 = entrada.valor / this.parcela;
                entrada.valor_parcela3 = entrada.valor / this.parcela;
                entrada.valor_parcela4 = entrada.valor / this.parcela;
                entrada.data_recebimento2 = entrada.data_recebimento.AddDays(60);
                entrada.data_recebimento3 = entrada.data_recebimento.AddDays(90);
                entrada.data_recebimento4 = entrada.data_recebimento.AddDays(120);
            }

            if (this.parcela == 5)
            {
                entrada.valor_parcela1 = entrada.valor / this.parcela;
                entrada.valor_parcela2 = entrada.valor / this.parcela;
                entrada.valor_parcela3 = entrada.valor / this.parcela;
                entrada.valor_parcela4 = entrada.valor / this.parcela;
                entrada.valor_parcela5 = entrada.valor / this.parcela;
                entrada.data_recebimento2 = entrada.data_recebimento.AddDays(60);
                entrada.data_recebimento3 = entrada.data_recebimento.AddDays(90);
                entrada.data_recebimento4 = entrada.data_recebimento.AddDays(120);
                entrada.data_recebimento5 = entrada.data_recebimento.AddDays(150);
            }

            if (this.parcela == 6)
            {
                entrada.valor_parcela1 = entrada.valor / this.parcela;
                entrada.valor_parcela2 = entrada.valor / this.parcela;
                entrada.valor_parcela3 = entrada.valor / this.parcela;
                entrada.valor_parcela4 = entrada.valor / this.parcela;
                entrada.valor_parcela5 = entrada.valor / this.parcela;
                entrada.valor_parcela6 = entrada.valor / this.parcela;
                entrada.data_recebimento2 = entrada.data_recebimento.AddDays(60);
                entrada.data_recebimento3 = entrada.data_recebimento.AddDays(90);
                entrada.data_recebimento4 = entrada.data_recebimento.AddDays(120);
                entrada.data_recebimento5 = entrada.data_recebimento.AddDays(150);
                entrada.data_recebimento6 = entrada.data_recebimento.AddDays(180);
            }

            if (entrada.cliente.codigo != 0)
                new EntradaDB().Salvar(entrada);
            else
                new Envio_email() { para = "bruno@coweb.com.br", assunto = "CENBRAP - Cielo lanca entrada erro", texto = this.txt + "<BR>Aluno: " + this.aluno.codigo + " - " + this.aluno.nome + " <BR>Curso: "+this.curso.codigo + " - " + this.curso.titulo1 }.Salvar();

                }

        public void Ativar()
        {
            this.aluno_curso = new Aluno_cursoDB().Buscar(this.aluno_curso.codigo);
            this.aluno_curso.Confirma();

            this.situacao = 2;
        }

        public void Desativar()
        {
            this.aluno_curso = new Aluno_cursoDB().Buscar(this.aluno_curso.codigo);
            this.aluno_curso.Cancela();

            this.situacao = 3;
        }

    }
}
