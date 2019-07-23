using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class AtividadeComplementar
    {
        public int idatividade { get; set; }
        public int idencontro { get; set; }
        public string txtitulo { get; set; }
        public string txtexto { get; set; }
        public DateTime dtexibicao { get; set; }
        public Boolean concluido { get; set; }
        public List<AtividadeComplementarQuestoes> questoes { get; set; }
        public List<AtividadeComplementarVideos> videos { get; set; }
        public List<AtividadeComplementarAnexos> anexos { get; set; }
        public int aluno { get; set; }

        public AtividadeComplementar()
        {
            this.idatividade = 0;
            this.idencontro = 0;
            this.txtitulo = "";
            this.txtexto = "";
            this.dtexibicao = Convert.ToDateTime("01/01/1900"); ;
            this.questoes = null;
            this.videos = null;
            this.anexos = null;
            this.concluido = false;
            this.aluno = 0;
        }

        public AtividadeComplementar(int idatividade, int idencontro, string txtitulo, string txtexto, DateTime dtexibicao, int aluno)
        {
            this.idatividade = idatividade;
            this.idencontro = idencontro;
            this.txtitulo = txtitulo;
            this.txtexto = txtexto;
            this.dtexibicao = dtexibicao;
            this.questoes = new AtividadeComplementarDB().ListaQuestoes(idatividade, aluno);
            this.videos = new AtividadeComplementarDB().ListaVideos(idatividade);
            this.anexos = new AtividadeComplementarDB().ListaAnexos(idatividade);
            if (new AtividadeComplementarDB().TotalRespostas(idatividade, aluno) > 0) {
                concluido = true;
            }
        }
    }

    public class AtividadeComplementarQuestoes
    {
        public int idatividade { get; set; }
        public int idquestao { get; set; }
        public string txquestao { get; set; }
        public string flgabarito { get; set; }
        public string resposta { get; set; }

        public AtividadeComplementarQuestoes()
        {
            this.idatividade = 0;
            this.idquestao = 0;
            this.txquestao = "";
            this.flgabarito = "";
            this.resposta = "";
        }

        public AtividadeComplementarQuestoes(int idatividade, int idquestao, string txquestao, string flgabarito, string resposta)
        {
            this.idatividade = idatividade;
            this.idquestao = idquestao;
            this.txquestao = txquestao;
            this.flgabarito = flgabarito;
            this.resposta = resposta;
        }
    }

    public class AtividadeComplementarVideos
    {
        public int idatividade { get; set; }
        public string txlink { get; set; }

        public AtividadeComplementarVideos()
        {
            this.idatividade = 0;
            this.txlink = "";
        }

        public AtividadeComplementarVideos(int idatividade, string txlink)
        {
            this.idatividade = idatividade;
            this.txlink = txlink;
        }
    }

    public class AtividadeComplementarAnexos
    {
        public int idatividade { get; set; }
        public string txarquivo { get; set; }

        public AtividadeComplementarAnexos()
        {
            this.idatividade = 0;
            this.txarquivo = "";
        }

        public AtividadeComplementarAnexos(int idatividade, string txarquivo)
        {
            this.idatividade = idatividade;
            this.txarquivo = txarquivo;
        }
    }

    public class AtividadeComplementarResposta
    {
        public int idquestao { get; set; }
        public int idaluno { get; set; }
        public string txresposta { get; set; }

        public AtividadeComplementarResposta()
        {
            this.idquestao = 0;
            this.idaluno = 0;
            this.txresposta = "";
        }

        public AtividadeComplementarResposta(int idquestao, int idaluno, string txresposta)
        {
            this.idquestao = idquestao;
            this.idaluno = idaluno;
            this.txresposta = txresposta;
        }

        public void Salvar()
        {
            new AtividadeComplementarDB().SalvarResposta(this);
        }

        public void Alterar()
        {
            new AtividadeComplementarDB().AlterarResposta(this);
        }
    }
}
