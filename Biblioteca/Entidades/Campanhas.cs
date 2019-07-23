using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Campanhas
    {
        public int idcampanha { get; set; }
        public string txcampanha { get; set; }
        public Mensagens idmensagem { get; set; }
        public int flativo { get; set; }
        public string txcodigo { get; set; }
        public string condicao { get; set; }
        public DateTime ultimoenvio { get; set; }

        public DateTime data { get; set; }

        public Campanhas()
        {
            this.idcampanha = 0;
            this.txcampanha = "";
            this.idmensagem = new Mensagens();
            this.flativo = 0;
            this.txcodigo = "";
            this.condicao = "O";
            this.ultimoenvio = Convert.ToDateTime("01/01/1900");
            this.data = Convert.ToDateTime("01/01/1900");
        }

        public Campanhas(int id)
        {
            this.idcampanha = id;
            this.txcampanha = "";
            this.idmensagem = new Mensagens();
            this.flativo = 0;
            this.txcodigo = "";
            this.condicao = "O";
            this.ultimoenvio = Convert.ToDateTime("01/01/1900");
            this.data = Convert.ToDateTime("01/01/1900");
        }

        public Campanhas(int id, string campanha, int mensagem, int ativo, string codigo)
        {
            this.idcampanha = id;
            this.txcampanha = campanha;
            this.idmensagem = new DB.MensagensDB().Buscar(mensagem);
            this.flativo = ativo;
            this.txcodigo = codigo;
            this.data = Convert.ToDateTime("01/01/1900");
        }

        public Campanhas(int id, string campanha, int mensagem, int ativo, string codigo, string condicao)
        {
            this.idcampanha = id;
            this.txcampanha = campanha;
            this.idmensagem = new DB.MensagensDB().Buscar(mensagem);
            this.flativo = ativo;
            this.txcodigo = codigo;
            this.condicao = condicao;
            this.data = Convert.ToDateTime("01/01/1900");
        }

        public Campanhas(int id, string campanha, int mensagem, int ativo, string codigo, DateTime data)
        {
            this.idcampanha = id;
            this.txcampanha = campanha;
            this.idmensagem = new DB.MensagensDB().Buscar(mensagem);
            this.flativo = ativo;
            this.txcodigo = codigo;

            this.data = data;
        }

        public Campanhas(int id, string campanha, int mensagem, int ativo, string codigo, DateTime data, string condicao, DateTime ultimoenvio)
        {
            this.idcampanha = id;
            this.txcampanha = campanha;
            this.idmensagem = new DB.MensagensDB().Buscar(mensagem);
            this.flativo = ativo;
            this.txcodigo = codigo;
            this.condicao = condicao;
            this.ultimoenvio = ultimoenvio;
            this.data = data;
        }

        public Campanhas(int id, string campanha, DateTime data)
        {
            this.idcampanha = id;
            this.txcampanha = campanha;
            this.data = data;
        }

        public Campanhas(int id, string campanha)
        {
            this.idcampanha = id;
            this.txcampanha = campanha;
        }
    }

    public class CidadesCursos
    {
        public int codigo_curso { get; set; }       
        public string titulo_curso { get; set; }
        public int codigo_cidade { get; set; }
        public string cidade { get; set; }

        public CidadesCursos()
        {
            this.codigo_curso = 0;
            this.titulo_curso = "";
            this.codigo_cidade = 0;
            this.cidade = "";
        }

        public CidadesCursos(int codigo_curso, string titulo_curso, int codigo_cidade, string cidade)
        {
            this.codigo_curso = codigo_curso;
            this.titulo_curso = titulo_curso;
            this.codigo_cidade = codigo_cidade;
            this.cidade = cidade;
        }
    }

    public class Exclusoes
    {
        public int codigo_campanha { get; set; }
        public int codigo_curso { get; set; }
        public string tipo { get; set; }
        public string curso { get; set; }

        public Exclusoes()
        {
            this.codigo_campanha = 0;
            this.codigo_curso = 0;
            this.tipo = "";
            this.curso = "";
        }

        public Exclusoes(int codigo_campanha, int codigo_curso, string tipo, string curso)
        {
            this.codigo_campanha = codigo_campanha;
            this.codigo_curso = codigo_curso;
            this.tipo = tipo;
            this.curso = curso;
        }
    }

    public class CampanhasGraf
    {
        public DateTime data { get; set; }
        public int abriu { get; set; }
        public int clicou { get; set; }

        public CampanhasGraf(DateTime data, int abriu, int clicou)
        {
            this.data = data;
            this.abriu = abriu;
            this.clicou = clicou;
        }
    }

    public class CampanhasEmails
    {
        public int aluno { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public int curso { get; set; }
        public string titulo { get; set; }
        public bool abriu { get; set; }
        public bool clicou { get; set; }
        public DateTime data_adesao { get; set; }
    }

    public class CampanhasEnviados : Campanhas
    {
        public int selecionados { get; set; }
        public int enviados { get; set; }
        public int abertos { get; set; }
        public int inscricoes { get; set; }
        public List<CampanhasEmails> emails { get; set; }
        public double taxa_abertura { get; set; }
        public double taxa_inscricoes { get; set; }
        public List<string> links { get; set; }
        public string cursos_inscricoes { get; set; }
        public int clicados { get; set; }
        public int inscricoesa { get; set; }
        public int inscricoesc { get; set; }
        public int descadastrados { get; set; }
        public double taxa_clicados { get; set; }

        public CampanhasEnviados()
        {
            this.idcampanha = 0;
            this.txcampanha = "";
            this.idmensagem = new Mensagens();
            this.flativo = 0;
            this.txcodigo = "";
            this.selecionados = 0;
            this.enviados = 0;
            this.abertos = 0;
            this.inscricoes = 0;
            this.taxa_abertura = 0;
            this.taxa_inscricoes = 0;
            this.emails = new List<CampanhasEmails>();
            this.links = new List<string>();
            this.cursos_inscricoes = "";
            this.clicados = 0;
            this.inscricoesa = 0;
            this.inscricoesc = 0;
            this.taxa_clicados = 0;
            this.descadastrados = 0;
        }

        public CampanhasEnviados(int id, string campanha, int mensagem, int ativo, string codigo, DateTime data, int enviados = 0, int abertos = 0, int inscricoes = 0, List<CampanhasEmails> emails = null, string cursos_inscricoes = "", int selecionados = 0)
        {
            this.idcampanha = id;
            this.txcampanha = campanha;
            this.idmensagem = new DB.MensagensDB().Buscar(mensagem);
            this.flativo = ativo;
            this.txcodigo = codigo;
            this.selecionados = selecionados;
            this.enviados = enviados;
            this.abertos = abertos;
            this.emails = emails;
            this.inscricoes = inscricoes;
            this.data = data;
            
            this.taxa_abertura = (double)this.abertos / (double)this.enviados * 100;
            this.taxa_inscricoes = ((double)this.inscricoes / (double)this.abertos) * 100;

            this.cursos_inscricoes = cursos_inscricoes;

            Link();
        }

        public CampanhasEnviados(DateTime data, int enviados = 0, int abertos = 0, int inscricoes = 0, int clicados = 0, int inscricoesa = 0, int inscricoesc = 0, int mensagem = 0, string codigo = "", int descadastrados = 0, int selecionados = 0)
        {
            this.idcampanha = idcampanha;
            this.data = data;
            this.selecionados = selecionados;
            this.enviados = enviados;
            this.inscricoes = inscricoes;
            this.abertos = abertos;
            this.clicados = clicados;
            this.inscricoesa = inscricoesa;
            this.inscricoesc = inscricoesc;
            this.taxa_abertura = (double)this.abertos / (double)this.enviados * 100;
            this.taxa_inscricoes = ((double)this.inscricoesa / (double)this.abertos) * 100;
            this.taxa_clicados = ((double)this.clicados / (double)this.abertos) * 100;
            this.idmensagem = new DB.MensagensDB().Buscar(mensagem);
            this.txcodigo = codigo;
            this.descadastrados = descadastrados;
            Link();
        }

        public void Link()
        {
            this.links = new List<string>();

            //Verifica se a campanha tem o txcodigo
            if (this.txcodigo != null)
            {
                if (this.txcodigo != "")
                {
                    string texto = this.idmensagem.texto;

                    //substitui todos os www.cenbrap.com.br para cenbrap.com.br e todos http://cenbrap.com.br para https://cenbrap.com.br
                    texto = texto.Replace("www.cenbrap.com.br", "cenbrap.com.br").Replace("http://cenbrap.com.br", "https://cenbrap.com.br");

                    int posicao = 0;
                    int cont = 0;

                    while (posicao < texto.Length)
                    {
                        if (texto.IndexOf("https://cenbrap.com.br", posicao) > -1)
                        {
                            cont++;

                            posicao = texto.IndexOf("https://cenbrap.com.br", posicao);

                            int aspas = texto.IndexOf("\"", posicao);
                            int aspas_simples = texto.IndexOf("'", posicao);

                            if (aspas == -1)
                                aspas = posicao + 1000;
                            if (aspas_simples == -1)
                                aspas_simples = posicao + 1000;

                            if (aspas > aspas_simples)
                                aspas = aspas_simples;

                            string link = texto.Substring(posicao, aspas - posicao);
                            string link_novo = link;
                            if (link.IndexOf('?') == -1)
                            {
                                link_novo += "?";
                            }
                            else
                            {
                                link_novo += "&";
                            }
                            //link_novo += "utm_source=" + this.txcodigo.Replace("e_", "e_" + cont.ToString() + "_");

                            texto = texto.Substring(0, posicao) + link_novo + texto.Substring(aspas);

                            this.links.Add(cont + ". " + link_novo);

                            posicao++;
                        }
                        else
                        {
                            posicao = texto.Length;
                        }
                    }
                    
                }
            }
        }        

    }

    public class CampanhasAlunos
    {
        public int aluno { get; set; }
        public string nome { get; set; }
        public DateTime data { get; set; }
        public string curso { get; set; }

        public CampanhasAlunos(int tipo, string aluno, DateTime data, string curso)
        {
            this.nome = aluno;
            this.data = data;
            this.curso = curso;
        }
    }
}
