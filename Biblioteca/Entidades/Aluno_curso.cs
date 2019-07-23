using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Aluno_curso
    {
        public int codigo { get; set; }
        public Curso curso { get; set; }
        public Aluno aluno { get; set; }
        public DateTime data { get; set; }
        public int situacao { get; set; }
        public DateTime? data1 { get; set; }
        public Painel painel { get; set; }
        public string obs { get; set; }
        public DateTime? adesao { get; set; }
        public Painel painel1 { get; set; }
        public string campo_documentacao { get; set; }
        public string campo_status_relatorio { get; set; }
        public string campo_status_certificado { get; set; }
        public DateTime? campo_status_relatorio_data { get; set; }
        public string campo_entrega_certificado { get; set; }
        public string obs1 { get; set; }
        public string obs2 { get; set; }
        public string obs_documentos { get; set; }
        public int cor { get; set; }
        public string obs_financeiro { get; set; }
        public int cor_financeiro { get; set; }
        public int info { get; set; }
        public DateTime? data_confirmacao { get; set; }
        public DateTime? data_desistente { get; set; }
        public string campo_financeiro { get; set; }
        public int cor_certificado { get; set; }
        public int cor_certificado1 { get; set; }
        public int envio_email { get; set; }
        public int relatorio_certificadora { get; set; }
        public int contato_pre_matricula { get; set; }
        public DateTime? ligou_pre_reserva { get; set; }
        public DateTime? ligou_matricula_aberta { get; set; }
        public DateTime? ligou_apos_7dias { get; set; }
        public DateTime? confirmou_pre_matricula { get; set; }
        public DateTime? ligou_no_adiamento { get; set; }
        public DateTime? ligou_turma_confirmada { get; set; }
        public DateTime? visita_tecnica1 { get; set; }
        public DateTime? visita_tecnica2 { get; set; }
        public DateTime? email_pre_reserva { get; set; }
        public DateTime? email_informativo { get; set; }
        public DateTime? email_matriculas_abertas { get; set; }
        public DateTime? email_matriculas_abertas_reforco { get; set; }
        public DateTime? email_impressao_boleto { get; set; }
        public DateTime? envio_pre_matricula { get; set; }
        public DateTime? email_inicio_turma { get; set; }
        public DateTime? email_adiamento_turma { get; set; }
        public DateTime? nao_fara_o_curso { get; set; }
        public string obs_nota_frequencia { get; set; }
        public string titulo_monografia { get; set; }
        public string nome_aluno { get; set; }

        public int fase { get; set; }

        public Aluno_curso()
        {
            this.codigo = 0;
            this.curso = new Curso() { codigo = 0 };
            this.aluno = new Aluno() { codigo = 0 };
            this.data = DateTime.Now;
            this.situacao = 0;
            this.data1 = Convert.ToDateTime("01/01/1900");
            this.painel = new Painel() { codigo = 0 };
            this.obs = "";
            this.adesao = DateTime.Now;
            this.painel1 = new Painel() { codigo = 0 };
            this.campo_documentacao = "";
            this.campo_status_relatorio = "";
            this.campo_status_certificado = "";
            this.campo_status_relatorio_data = Convert.ToDateTime("01/01/1900");
            this.campo_entrega_certificado = "";
            this.obs1 = "";
            this.obs2 = "";
            this.obs_documentos = "";
            this.cor = 0;
            this.obs_financeiro = "";
            this.cor_financeiro = 0;
            this.info = 0;
            this.data_confirmacao = Convert.ToDateTime("01/01/1900");
            this.data_desistente = Convert.ToDateTime("01/01/1900");
            this.campo_financeiro = "";
            this.cor_certificado = 0;
            this.cor_certificado1 = 0;
            this.envio_email = 1;
            this.relatorio_certificadora = 0;
            this.contato_pre_matricula = 0;
            this.ligou_pre_reserva = Convert.ToDateTime("01/01/1900");
            this.ligou_matricula_aberta = Convert.ToDateTime("01/01/1900");
            this.ligou_apos_7dias = Convert.ToDateTime("01/01/1900");
            this.confirmou_pre_matricula = Convert.ToDateTime("01/01/1900");
            this.ligou_no_adiamento = Convert.ToDateTime("01/01/1900");
            this.ligou_turma_confirmada = Convert.ToDateTime("01/01/1900");
            this.visita_tecnica1 = Convert.ToDateTime("01/01/1900");
            this.visita_tecnica2 = Convert.ToDateTime("01/01/1900");
            this.email_pre_reserva = Convert.ToDateTime("01/01/1900");
            this.email_informativo = Convert.ToDateTime("01/01/1900");
            this.email_matriculas_abertas = Convert.ToDateTime("01/01/1900");
            this.email_matriculas_abertas_reforco = Convert.ToDateTime("01/01/1900");
            this.email_impressao_boleto = Convert.ToDateTime("01/01/1900");
            this.envio_pre_matricula = Convert.ToDateTime("01/01/1900");
            this.email_inicio_turma = Convert.ToDateTime("01/01/1900");
            this.email_adiamento_turma = Convert.ToDateTime("01/01/1900");
            this.nao_fara_o_curso = Convert.ToDateTime("01/01/1900");
            this.obs_nota_frequencia = "";
            this.titulo_monografia = "";
            this.fase = 0;
            this.nome_aluno = "";
        }

        public Aluno_curso(int codigo)
        {
            this.codigo = codigo;
        }

        public Aluno_curso(int codigo, int situacao, string nome)
        {
            this.codigo = codigo;
            this.situacao = situacao;
            this.nome_aluno = nome;
        }

        public Aluno_curso(int codigo, Curso curso, Aluno aluno, DateTime data, int situacao, DateTime data1, Painel painel, string obs, DateTime adesao, Painel painel1, string campo_documentacao, string campo_status_relatorio, string campo_status_certificado, DateTime campo_status_relatorio_data, string campo_entrega_certificado, string obs1, string obs2, string obs_documentos, int cor, string obs_financeiro, int cor_financeiro, int info, DateTime data_confirmacao, DateTime data_desistente, string campo_financeiro, int cor_certificado, int cor_certificado1, int envio_email, int relatorio_certificadora, int contato_pre_matricula, DateTime ligou_pre_reserva, DateTime ligou_matricula_aberta, DateTime ligou_apos_7dias, DateTime confirmou_pre_matricula, DateTime ligou_no_adiamento, DateTime ligou_turma_confirmada, DateTime visita_tecnica1, DateTime visita_tecnica2, DateTime email_pre_reserva, DateTime email_informativo, DateTime email_matriculas_abertas, DateTime email_matriculas_abertas_reforco, DateTime email_impressao_boleto, DateTime envio_pre_matricula, DateTime email_inicio_turma, DateTime email_adiamento_turma, string obs_nota_frequencia, string titulo_monografia, int fase, DateTime nao_fara_o_curso)
        {
            this.codigo = codigo;
            this.curso = curso;
            this.aluno = aluno;
            this.data = data;
            this.situacao = situacao;
            this.data1 = Confere(data1);
            this.painel = painel;
            this.obs = obs;
            this.adesao = Confere(adesao);
            this.painel1 = painel1;
            this.campo_documentacao = campo_documentacao;
            this.campo_status_relatorio = campo_status_relatorio;
            this.campo_status_certificado = campo_status_certificado;
            this.campo_status_relatorio_data = Confere(campo_status_relatorio_data);
            this.campo_entrega_certificado = campo_entrega_certificado;
            this.obs1 = obs1;
            this.obs2 = obs2;
            this.obs_documentos = obs_documentos;
            this.cor = cor;
            this.obs_financeiro = obs_financeiro;
            this.cor_financeiro = cor_financeiro;
            this.info = info;
            this.data_confirmacao = Confere(data_confirmacao);
            this.data_desistente = Confere(data_desistente);
            this.campo_financeiro = campo_financeiro;
            this.cor_certificado = cor_certificado;
            this.cor_certificado1 = cor_certificado1;
            this.envio_email = envio_email;
            this.relatorio_certificadora = relatorio_certificadora;
            this.contato_pre_matricula = contato_pre_matricula;
            this.ligou_pre_reserva = Confere(ligou_pre_reserva);
            this.ligou_matricula_aberta = Confere(ligou_matricula_aberta);
            this.ligou_apos_7dias = Confere(ligou_apos_7dias);
            this.confirmou_pre_matricula = Confere(confirmou_pre_matricula);
            this.ligou_no_adiamento = Confere(ligou_no_adiamento);
            this.ligou_turma_confirmada = Confere(ligou_turma_confirmada);
            this.visita_tecnica1 = Confere(visita_tecnica1);
            this.visita_tecnica2 = Confere(visita_tecnica2);
            this.email_pre_reserva = Confere(email_pre_reserva);
            this.email_informativo = Confere(email_informativo);
            this.email_matriculas_abertas = Confere(email_matriculas_abertas);
            this.email_matriculas_abertas_reforco = Confere(email_matriculas_abertas_reforco);
            this.email_impressao_boleto = Confere(email_impressao_boleto);
            this.envio_pre_matricula = Confere(envio_pre_matricula);
            this.email_inicio_turma = Confere(email_inicio_turma);
            this.email_adiamento_turma = Confere(email_adiamento_turma);
            this.obs_nota_frequencia = obs_nota_frequencia;
            this.titulo_monografia = titulo_monografia;
            this.fase = fase;
            this.nao_fara_o_curso = nao_fara_o_curso;

        }

        public void Salvar()
        {
            new Aluno_cursoDB().Salvar(this);
            this.codigo = new Aluno_cursoDB().Buscar(this.curso, this.aluno).codigo;
            //new Aluno_cursoDB().ZeraData();

            //Salva log
            new Aluno_curso_log(this, 0);
        }

        public void Alterar()
        {
            new Aluno_cursoDB().Alterar(this);
        }

        public void Excluir()
        {
            new Aluno_cursoDB().Excluir(this);
        }

        public DateTime? Confere(DateTime? dat)
        {
            if(dat == Convert.ToDateTime("01/01/1900"))
            {
                dat = Convert.ToDateTime("01/01/1900");
            }
            return dat;
        }

        public void Confirma()
        {
            this.situacao = 2;
            this.painel = new Painel() { codigo = 0 };
            this.data = DateTime.Now;
            this.data_confirmacao = DateTime.Now;

            this.Alterar();

            //Salva log
            new Aluno_curso_log(this, 3);
        }

        public void Cancela()
        {
            this.situacao = 3;
            this.painel = new Painel() { codigo = 0 };
            this.data = DateTime.Now;

            this.Alterar();

            //Salva log
            new Aluno_curso_log(this, 4);
        }

        public void ImprimiuBoleto()
        {
            new Aluno_cursoDB().ImprimiuBoleto(this.codigo);

            //Salva log
            new Aluno_curso_log(this, 1);
        }

        public void AbriuCartao()
        {
            new Aluno_cursoDB().ImprimiuBoleto(this.codigo);

            //Salva log
            new Aluno_curso_log(this, 2);
        }
    }

    public class VendasAlunoCurso
    {
        public int Curso { get; set; }
        public string Titulo { get; set; }
        public string Titulo1 { get; set; }
        public DateTime Adesao { get; set; }
        public int Codigo { get; set; }
        public DateTime Data { get; set; }
        public string Texto { get; set; }
        public int Tipo { get; set; }
        public int Acoes { get; set; }

        public VendasAlunoCurso(int Curso, string Titulo, string Titulo1, DateTime Adesao, int Codigo, DateTime Data, string Texto, int Tipo, int Acoes)
        {
            this.Curso = Curso;
            this.Titulo = Titulo;
            this.Titulo1 = Titulo1;
            this.Adesao = Adesao;
            this.Codigo = Codigo;
            this.Data = Data;
            this.Texto = Texto;
            this.Tipo = Tipo;
            this.Acoes = Acoes;
        }

        public VendasAlunoCurso(int Curso, string Titulo, string Titulo1)
        {
            this.Curso = Curso;
            this.Titulo = Titulo;
            this.Titulo1 = Titulo1;
        }
    }

    public class Aluno_curso_fase
    {
        public int codigo { get; set; }
        public int situacao { get; set; }
        public int inicio_confirmado { get; set; }
        public int fase { get; set; }
        public int curso { get; set; }
        public int ativo { get; set; }
        public DateTime adesao { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime inicio_confirmado_data { get; set; }
        public DateTime data_abertura_pre_reserva { get; set; }
        public DateTime ativo_data_abertura_matricula { get; set; }
        public DateTime data_prorrogacao { get; set; }

        public Aluno_curso_fase()
        {
            this.codigo = 0;
            this.situacao = 0;
            this.fase = 0;
            this.inicio_confirmado = 0;
            this.adesao = Convert.ToDateTime("01/01/1900");
            this.data_inicio = Convert.ToDateTime("01/01/1900");
            this.inicio_confirmado_data = Convert.ToDateTime("01/01/1900");
            this.data_abertura_pre_reserva = Convert.ToDateTime("01/01/1900");
            this.ativo_data_abertura_matricula = Convert.ToDateTime("01/01/1900");
            this.data_prorrogacao = Convert.ToDateTime("01/01/1900");
        }

        public void QualFase()
        {
            int f = 1;

            //se a adesao for maior que data_abertura_pre_reserva e menor que ativo_data_abertura_matricula
            if (this.adesao >= this.data_abertura_pre_reserva && this.adesao < this.ativo_data_abertura_matricula)
            {
                f = 1;
            }
            else
            {
                //se a ativo_data_abertura_matricula for maior que 01/01/1900
                if (this.ativo_data_abertura_matricula > Convert.ToDateTime("01/01/1900"))
                {
                    //se a adesao for maior que ativo_data_abertura_matricula
                    if (this.adesao >= this.ativo_data_abertura_matricula)
                    {
                        f = 2;

                        //se a data_prorrogacao for maior que 01/01/1900
                        if (this.data_prorrogacao > Convert.ToDateTime("01/01/1900"))
                        {
                            //se a adesao for maior que data_prorrogacao
                            if (this.adesao >= this.data_prorrogacao)
                            {
                                f = 3;
                            }
                        }

                        //se a inicio_confirmado_data for maior que 01/01/1900
                        if (this.inicio_confirmado_data > Convert.ToDateTime("01/01/1900"))
                        {
                            //se a adesao for maior que inicio_confirmado_data
                            if (this.adesao >= this.inicio_confirmado_data)
                            {
                                f = 4;
                            }
                        }

                        //se a data_inicio for maior que 01/01/1900
                        if (this.data_inicio > Convert.ToDateTime("01/01/1900"))
                        {
                            //se a adesao for maior que data_inicio
                            if (this.adesao >= this.data_inicio)
                            {
                                f = 5;
                            }
                        }
                    }
                }
            }
            this.fase = f;
        }
    }
}
