using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class ScoreCidades
    {
        public int idestado { get; set; }
        public int idcriterio { get; set; }
        public decimal vlcriterio { get; set; }
        public int nrano { get; set; }

        public ScoreCidades()
        {
            this.idestado = 0;
            this.idcriterio = 0;
            this.vlcriterio = 0;
            this.nrano = 0;
        }

        public ScoreCidades(int idestado, int idcriterio, decimal vlcriterio, int nrano)
        {
            this.idestado = idestado;
            this.idcriterio = idcriterio;
            this.vlcriterio = vlcriterio;
            this.nrano = nrano;
        }

        public void Salvar()
        {
            new ScoreCidadesDB().SalvarValor(this);
        }

        public void Alterar()
        {
            new ScoreCidadesDB().AlterarValor(this);
        }

        public void Excluir()
        {
            new ScoreCidadesDB().ExcluirValor(this);
        }

    }

    public class ScoreCidadesCriterios
    {
        public int idcriterio { get; set; }
        public string txcriterio { get; set; }
        public List<ScoreCidadesCriteriosValores> valores { get; set; }

        public ScoreCidadesCriterios()
        {
            this.idcriterio = 0;
            this.txcriterio = "";
            this.valores = null;
        }

        public ScoreCidadesCriterios(int idcriterio, string txcriterio)
        {
            this.idcriterio = idcriterio;
            this.txcriterio = txcriterio;
        }
    }

    public class ScoreCidadesCriteriosValores
    {
        public int idvalor { get; set; }
        public int idcriterio { get; set; }
        public decimal vlmin { get; set; }
        public decimal vlmax { get; set; }
        public int ptcriterio { get; set; }

        public ScoreCidadesCriteriosValores()
        {
            this.idvalor = 0;
            this.idcriterio = 0;
            this.vlmin = 0;
            this.vlmax = 0;
            this.ptcriterio = 0;
        }

        public ScoreCidadesCriteriosValores(int idvalor, int idcriterio, decimal vlmin, decimal vlmax, int ptcriterio)
        {
            this.idvalor = idvalor;
            this.idcriterio = idcriterio;
            this.vlmin = vlmin;
            this.vlmax = vlmax;
            this.ptcriterio = ptcriterio;
        }

        public void Alterar()
        {
            new ScoreCidadesDB().AlterarCriterioValor(this);
        }
    }

    public class ScoreCidadesEstados
    {
        public int idestado { get; set; }
        public string txestado { get; set; }
        public int flinterior { get; set; }
        public string txcidade { get; set; }

        public ScoreCidadesEstados()
        {
            this.idestado = 0;
            this.txestado = "";
            this.flinterior = 0;
            this.txcidade = "";
        }

        public ScoreCidadesEstados(int idestado, string txestado, int flinterior, string txcidade)
        {
            this.idestado = idestado;
            this.txestado = txestado;
            this.flinterior = flinterior;
            this.txcidade = txcidade;
        }
    }

    public class ScoreCidadesDashboard
    {
        public int pontos { get; set; }
        public string estado { get; set; }
        public int flinterior { get; set; }
        public int turmas { get; set; }

        public ScoreCidadesDashboard()
        {
            this.pontos = 0;
            this.estado = "";
            this.flinterior = 0;
            this.turmas = 0;
        }

        public ScoreCidadesDashboard(int pontos, string estado, int flinterior, int turmas)
        {
            this.pontos = pontos;
            this.estado = estado;
            this.flinterior = flinterior;
            this.turmas = turmas;
        }
    }
}
