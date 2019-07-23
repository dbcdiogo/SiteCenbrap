using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;
using System.Globalization;

namespace Biblioteca.Entidades
{
    public class Curso
    {
        public int codigo {get; set; }

        public DateTime data { get; set; }
        public Painel painel { get; set; }

        public Cidade cidade_codigo { get; set; }
        public Cidade_local cidade_local { get; set; }
        public Titulo_curso titulo_curso { get; set; }

        public Painel painel_contrato { get; set; }
        public DateTime data_contrato { get; set; }

        public decimal valor { get; set; }
        public decimal valor_avista { get; set; }
        public decimal matricula { get; set; }
        public decimal matricula1 { get; set; }
        public decimal desconto_pgto_dia { get; set; }

        public DateTime data_criacao { get; set; }
        public DateTime data_limite1 { get; set; }
        public DateTime data_limite2 { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_2parcela { get; set; }
        public DateTime inicio_confirmado_data { get; set; }
        public DateTime ativo_data_abertura_matricula { get; set; }
        public DateTime data_abertura_pre_reserva { get; set; }

        public int qtd_parcelas { get; set; }
        public int total_alunos { get; set; }
        public int tipo { get; set; }
        public int qtd_modulos { get; set; }
        public int pgto_1parcela { get; set; }
        public int ultimas_vagas { get; set; }
        public int inicio_confirmado { get; set; }
        public int visualiza_site { get; set; }
        public int ativar_monografia { get; set; }
        public int ativo { get; set; }
        public int vagas_esgotadas { get; set; }
        public int qtd_reposicao { get; set; }
        public int representante { get; set; }
        public int grupo_datas { get; set; }
        public int carga_horaria { get; set; }

        public string titulo { get; set; }
        public string titulo1 { get; set; }
        public string texto { get; set; }
        public string textoData { get; set; }

        public string obs1 { get; set; }
        public string obs { get; set; }
        public string cidade { get; set; }

        public string contrato { get; set; }
        public string contrato1 { get; set; }
        public string contrato2 { get; set; }
        public string contratoc { get; set; }
        public string orientador { get; set; }
        public string email_orientador { get; set; }

        public string arquivo_2passo { get; set; }

        public DateTime data_fim { get; set; }
        public string xerox { get; set; }
        public string dossie { get; set; }
        public string endereco_local { get; set; }
        public string arquivo_mapa { get; set; }
        public string obs_local { get; set; }
        public string pag_site_professores { get; set; }
        public string pag_site_disciplina { get; set; }
        public string contrato_tcc { get; set; }
        public string certificadora { get; set; }
        public Certificadora certificadora_id { get; set; }

        public bool cartao { get; set; }
        public bool pagseguro_recorrente { get; set; }

        public decimal matriculaContrato { get; set; }
        public decimal matricula1Contrato { get; set; }

        public bool imprimir_certificado { get; set; }

        public string link_trailer { get; set; }
        public DateTime data_lista_espera { get; set; }

        public int idhotel { get; set; }
        public DateTime dtaberturainicial { get; set; }
        public string texto_curso { get; set; }

        public Curso()
        {
            this.codigo = 0;
            this.data = DateTime.Now;
            this.painel = new Painel();
            this.cidade_codigo = new Cidade();
            this.cidade_local = new Cidade_local();
            this.titulo_curso = new Titulo_curso();
            this.data_contrato = DateTime.Now;
            this.painel_contrato = new Painel();
            this.data_criacao = DateTime.Now;
            this.titulo = "";
            this.titulo1 = "";
            this.texto = "";
            this.textoData = "";
            this.valor = 0;
            this.valor_avista = 0;
            this.matricula = 0;
            this.matricula1 = 0;
            this.data_limite1 = DateTime.Now;
            this.data_limite2 = DateTime.Now;
            this.qtd_parcelas = 0;
            this.total_alunos = 0;
            this.tipo = 0;
            this.obs1 = "";
            this.obs = "";
            this.qtd_modulos = 0;
            this.data_inicio = DateTime.Now;
            this.data_2parcela = DateTime.Now;
            this.desconto_pgto_dia = 0;
            this.cidade = "";
            this.pgto_1parcela = 0;
            this.ultimas_vagas = 0;
            this.inicio_confirmado = 0;
            this.inicio_confirmado_data = DateTime.Now;
            this.visualiza_site = 0;
            this.contrato = "";
            this.contrato1 = "";
            this.contrato2 = "";
            this.contratoc = "";
            this.orientador = "";
            this.email_orientador = "";
            this.arquivo_2passo = "";
            this.data_fim = DateTime.Now;
            this.ativar_monografia = 0;
            this.ativo = 0;
            this.ativo_data_abertura_matricula = DateTime.Now;
            this.data_abertura_pre_reserva = DateTime.Now;
            this.vagas_esgotadas = 0;
            this.xerox = "";
            this.dossie = "";
            this.endereco_local = "";
            this.arquivo_mapa = "";
            this.obs_local = "";
            this.qtd_reposicao = 0;
            this.pag_site_professores = "";
            this.pag_site_disciplina = "";
            this.representante = 0;
            this.contrato_tcc = "";
            this.grupo_datas = 0;
            this.certificadora = "";
            this.certificadora_id = new Certificadora();
            this.carga_horaria = 0;
            this.cartao = false;
            this.pagseguro_recorrente = false;
            this.imprimir_certificado = false;

            this.matriculaContrato = 0;
            this.matricula1Contrato = 0;

            this.link_trailer = "";
            this.data_lista_espera = Convert.ToDateTime("01/01/1900");

            this.idhotel = 0;
            this.dtaberturainicial = Convert.ToDateTime("01/01/1900");
            this.texto_curso = "";
        }

        public Curso(int codigo)
        {
            this.codigo = codigo;
        }

        public Curso(int codigo, string titulo, string titulo1)
        {
            this.codigo = codigo;
            this.titulo = titulo;
            this.titulo1 = titulo1;
        }

        public void Salvar()
        {
            new CursoDB().Salvar(this);
        }

        public void Alterar()
        {
            new CursoDB().Alterar(this);
        }

        public void Excluir()
        {
            new CursoDB().Excluir(this);
        }

        public string Tipo()
        {
            if (this.tipo == 3 || this.tipo == 4)
                return "Inscrição";

            return "Matrícula";
        }

        public decimal CursoValor()
        {
            decimal v = 0;

            this.matriculaContrato = this.matricula;
            this.matricula1Contrato = this.matricula1;

            if (this.data_limite1 > Convert.ToDateTime("01/01/2000"))
            {
                if (this.data_limite1 > DateTime.Now.Date)
                    this.matricula = this.matricula1;
            }
            
            if (this.matricula > 0)
            {
                v = this.matricula;
                if (this.pgto_1parcela == 1)
                    v += this.valor / this.qtd_parcelas;
            }
            else
            {
                v = this.valor;
            }

            return v;
        }

        public string Titulo()
        {
            string retorno = this.titulo;

            if (retorno.IndexOf(" (") > 0)
                retorno = retorno.Substring(0, retorno.IndexOf(" ("));

            return retorno;
        }

        public decimal Valor()
        {
            return this.valor / this.qtd_parcelas;
        }

        public string Texto()
        {
            string t = this.texto;

            if(t.IndexOf("#data_inicio#") > 0)
            {
                t = t.Replace("#data_inicio#", this.data_inicio.ToShortDateString());
            }

            if(t.IndexOf("#data_mudanca#") > 0)
            {
                if(this.data_limite1 > Convert.ToDateTime("01/01/1900"))
                {
                    t = t.Replace("#data_mudanca#", this.data_limite1.ToShortDateString());

                    t = t.Replace("#data_limite#", this.data_limite1.AddDays(-1).ToShortDateString());

                }
            }

            if (t.IndexOf("#valor_inicial#") > 0)
            {
                t = t.Replace("#valor_inicial#", this.matricula1Contrato.ToString("N2"));
            }

            if (t.IndexOf("#valor_final#") > 0)
            {
                t = t.Replace("#valor_final#", this.matriculaContrato.ToString("N2"));
            }

            if (t.IndexOf("#valor_mensalidade#") > 0)
            {
                t = t.Replace("#valor_mensalidade#", (this.valor/this.qtd_parcelas).ToString("N2"));
            }

            if (t.IndexOf("#valor_total#") > 0)
            {
                t = t.Replace("#valor_total#", this.valor.ToString("N2"));
            }

            if (t.IndexOf("#qtd_parcelas#") > 0)
            {
                t = t.Replace("#qtd_parcelas#", this.qtd_parcelas.ToString());
            }

            if (t.IndexOf("#quantidade_parcelas#") > 0)
            {
                t = t.Replace("#quantidade_parcelas#", this.qtd_parcelas.ToString());
            }

            if(t.IndexOf('\r') > 0)
            {
                t = t.Replace("\r", "<BR>");
            }

            return t;
        }

        public string Data()
        {
            string data = "";

            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            int dia = this.data_inicio.Day;
            int ano = this.data_inicio.Year;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(this.data_inicio.Month));

            data = dia + " de " + mes + " de " + ano;

            return data;
        }

        public string Contrato()
        {
            string contrato = this.contrato;
            contrato += this.contrato1;
            contrato += this.contrato2;

            //#data_inicio#
            if (contrato.IndexOf("#data_inicio#") > 0)
                contrato = contrato.Replace("#data_inicio#", this.data_inicio.ToShortDateString());

            //#data_mudanca#
            if (contrato.IndexOf("#data_mudanca#") > 0)
                contrato = contrato.Replace("#data_mudanca#", this.data_limite1.ToShortDateString());

            //#data_limite#
            if (contrato.IndexOf("#data_limite#") > 0)
                contrato = contrato.Replace("#data_limite#", this.data_limite1.AddDays(-1).ToShortDateString());

            //#valor_inicial#
            if (contrato.IndexOf("#valor_inicial#") > 0)
                contrato = contrato.Replace("#valor_inicial#", this.matricula1Contrato.ToString("N2"));

            //#valor_final#
            if (contrato.IndexOf("#valor_final#") > 0)
                contrato = contrato.Replace("#valor_final#", this.matriculaContrato.ToString("N2"));

            //#valor_mensalidade#
            if (contrato.IndexOf("#valor_mensalidade#") > 0)
                contrato = contrato.Replace("#valor_mensalidade#", (this.valor / this.qtd_parcelas).ToString("N2"));

            //#valor_total#
            if (contrato.IndexOf("#valor_total#") > 0)
                contrato = contrato.Replace("#valor_total#", this.valor.ToString("N2"));

            //#qtd_parcelas#
            if (contrato.IndexOf("#qtd_parcelas#") > 0)
                contrato = contrato.Replace("#qtd_parcelas#", this.qtd_parcelas.ToString());

            //#quantidade_parcelas#
            if (contrato.IndexOf("#quantidade_parcelas#") > 0)
                contrato = contrato.Replace("#quantidade_parcelas#", this.qtd_parcelas.ToString());

            //#nome_curso#
            if (contrato.IndexOf("#nome_curso#") > 0)
                contrato = contrato.Replace("#nome_curso#", this.titulo_curso.titulo);

            return contrato;
        }

        public string ContratoC()
        {
            string contrato = this.contratoc;

            //#data_inicio#
            if (contrato.IndexOf("#data_inicio#") > 0)
                contrato = contrato.Replace("#data_inicio#", this.data_inicio.ToShortDateString());

            //#data_mudanca#
            if (contrato.IndexOf("#data_mudanca#") > 0)
                contrato = contrato.Replace("#data_mudanca#", this.data_limite1.ToShortDateString());

            //#data_limite#
            if (contrato.IndexOf("#data_limite#") > 0)
                contrato = contrato.Replace("#data_limite#", this.data_limite1.AddDays(-1).ToShortDateString());

            //#valor_inicial#
            if (contrato.IndexOf("#valor_inicial#") > 0)
                contrato = contrato.Replace("#valor_inicial#", this.matricula1Contrato.ToString("N2"));

            //#valor_final#
            if (contrato.IndexOf("#valor_final#") > 0)
                contrato = contrato.Replace("#valor_final#", this.matriculaContrato.ToString("N2"));

            //#valor_mensalidade#
            if (contrato.IndexOf("#valor_mensalidade#") > 0)
                contrato = contrato.Replace("#valor_mensalidade#", (this.valor / this.qtd_parcelas).ToString("N2"));

            //#valor_total#
            if (contrato.IndexOf("#valor_total#") > 0)
                contrato = contrato.Replace("#valor_total#", this.valor.ToString("N2"));

            //#qtd_parcelas#
            if (contrato.IndexOf("#qtd_parcelas#") > 0)
                contrato = contrato.Replace("#qtd_parcelas#", this.qtd_parcelas.ToString());

            //#quantidade_parcelas#
            if (contrato.IndexOf("#quantidade_parcelas#") > 0)
                contrato = contrato.Replace("#quantidade_parcelas#", this.qtd_parcelas.ToString());

            //#nome_curso#
            if (contrato.IndexOf("#nome_curso#") > 0)
                contrato = contrato.Replace("#nome_curso#", this.titulo_curso.titulo);

            return contrato;
        }
    }

    public enum TipoCurso
    {
        PosGraduacao = 0,
        WorkShop = 1,
        EaD = 2,
        Congresso = 3,
        Simposio = 4,
        Video = 5
    }
}
