using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class AvaliacaoLista
    {
        public string aluno { get; set; }
        public int idaluno { get; set; }
        public string turma { get; set; }
        public string email { get; set; }
        public AvaliacaoForm avaliacao { get; set; }
        public int frequencia { get; set; }

        public AvaliacaoLista()
        {
            this.aluno = "";
            this.idaluno = 0;
            this.turma = "";
            this.email = "";
            this.frequencia = 0;
        }

        public AvaliacaoLista(string aluno, int idaluno)
        {
            this.aluno = aluno;
            this.idaluno = idaluno;
        }

        public AvaliacaoLista(string aluno, int idaluno, string turma)
        {
            this.aluno = aluno;
            this.idaluno = idaluno;
            this.turma = turma;
        }

        public AvaliacaoLista(string aluno, int idaluno, string turma, string email)
        {
            this.aluno = aluno;
            this.idaluno = idaluno;
            this.turma = turma;
            this.email = email;
        }

    }

    public class AvaliacaoFrequencia
    {
        public int idcurso { get; set; }
        public int idencontro { get; set; }
        public int idaluno { get; set; }
        public int frequencia { get; set; }

        public AvaliacaoFrequencia()
        {
            this.idcurso = 0;
            this.idencontro = 0;
            this.idaluno = 0;
            this.frequencia = 0;
        }

        public AvaliacaoFrequencia(int idcurso, int idencontro, int idaluno, int frequencia)
        {
            this.idcurso = idcurso;
            this.idencontro = idencontro;
            this.idaluno = idaluno;
            this.frequencia = frequencia;
        }

        public void Salvar()
        {
            new AvaliacaoDB().SalvarFrequencia(this);
        }

        public void Alterar()
        {
            new AvaliacaoDB().AlterarFrequencia(this);
        }

    }

    public class Avaliacao1Encontro
    {
        public int idcurso { get; set; }
        public int idencontro { get; set; }
        public int frequencia { get; set; }
        public int resposta { get; set; }

        public Avaliacao1Encontro()
        {
            this.idcurso = 0;
            this.idencontro = 0;
            this.resposta = 0;
            this.frequencia = 0;
        }

        public Avaliacao1Encontro(int idcurso, int idencontro, int frequencia, int resposta)
        {
            this.idcurso = idcurso;
            this.idencontro = idencontro;
            this.resposta = resposta;
            this.frequencia = frequencia;
        }

    }

    public class AvaliacaoForm
    {
        public int idavaliacao { get; set; }
        public int idaluno { get; set; }
        public int idencontro { get; set; }
        public int idcurso { get; set; }
        public string ntdominio { get; set; }
        public string ntdidatica { get; set; }
        public string ntpontualidade { get; set; }
        public string ntmaterial { get; set; }
        public string txelogio { get; set; }
        public string txsugestao { get; set; }
        public string autorizo { get; set; }
        public string ntdisponibilidade { get; set; }
        public string ntpontualidaderep { get; set; }
        public string ntcompetencia { get; set; }
        public string txelogiorep { get; set; }
        public string txsugestaorep { get; set; }
        public DateTime dtavaliacao { get; set; }
        public List<AvaliacaoItens> lista_conheceu { get; set; }
        public List<AvaliacaoItens> lista_objetivo { get; set; }
        public List<AvaliacaoItens> lista_trabalho { get; set; }

        public AvaliacaoForm()
        {
            this.idaluno = 0;
            this.idencontro = 0;
            this.idcurso = 0;
            this.ntdominio = "";
            this.ntdidatica = "";
            this.ntpontualidade = "";
            this.ntmaterial = "";
            this.txelogio = "";
            this.txsugestao = "";
            this.autorizo = "";
            this.ntdisponibilidade = "";
            this.ntpontualidaderep = "";
            this.ntcompetencia = "";
            this.txelogiorep = "";
            this.txsugestaorep = "";
            this.dtavaliacao = Convert.ToDateTime("1900-01-01");
        }

        public int Salvar()
        {
            return new AvaliacaoDB().Salvar(this);
        }

        public void ExcluirConheceu(int id = 0)
        {
            new AvaliacaoDB().ExcluirConheceu(id);
        }

        public void ExcluirObjetivos(int id = 0)
        {
            new AvaliacaoDB().ExcluirObjetivos(id);
        }

        public void ExcluirTrabalhos(int id = 0)
        {
            new AvaliacaoDB().ExcluirTrabalhos(id);
        }

        public void SalvarConheceu(int id = 0, int idavaliacao = 0, string outros = "")
        {
            new AvaliacaoDB().SalvarConheceu(id, idavaliacao, outros);
        }

        public void SalvarObjetivos(int id = 0, int idavaliacao = 0, string outros = "")
        {
            new AvaliacaoDB().SalvarObjetivos(id, idavaliacao, outros);
        }

        public void SalvarTrabalhos(int id = 0, int idavaliacao = 0, string outros = "")
        {
            new AvaliacaoDB().SalvarTrabalhos(id, idavaliacao, outros);
        }

    }

    public class AvaliacaoItens
    {
        public int iditem { get; set; }
        public string txitem { get; set; }
        public int nrordem { get; set; }
        public string txoutros { get; set; }

        public AvaliacaoItens()
        {
            this.iditem = 0;
            this.txitem = "";
            this.nrordem = 0;
            this.txoutros = "";
        }

        public AvaliacaoItens(int iditem, string txitem)
        {
            this.iditem = iditem;
            this.txitem = txitem;
        }

        public AvaliacaoItens(int iditem, string txitem, int nrordem)
        {
            this.iditem = iditem;
            this.txitem = txitem;
            this.nrordem = nrordem;
        }

        public AvaliacaoItens(int iditem, string txitem, int nrordem, string txoutros)
        {
            this.iditem = iditem;
            this.txitem = txitem;
            this.nrordem = nrordem;
            this.txoutros = txoutros;
        }

    }

    public class AvaliacaoElogioSugestao
    {
        public string texto { get; set; }
        public string aluno { get; set; }
        public string encontro { get; set; }
        public string curso { get; set; }
        public DateTime data { get; set; }

        public AvaliacaoElogioSugestao()
        {
            this.texto = "";
            this.aluno = "";
            this.encontro = "";
            this.curso = "";
            this.data = Convert.ToDateTime("1900-01-01");
        }

        public AvaliacaoElogioSugestao(string texto, string aluno, string encontro, string curso, DateTime data)
        {
            this.texto = texto;
            this.aluno = aluno;
            this.encontro = encontro;
            this.curso = curso;
            this.data = data;
        }

    }
}
