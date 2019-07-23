using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Investimentos
    {
        public int idinvestimento { get; set; }
        public decimal vlinvestimento { get; set; }
        public int idtipoinvestimento { get; set; }
        public int idtipoperiodo { get; set; }
        public DateTime dtinicio { get; set; }
        public DateTime dtfim { get; set; }
        public string txobs { get; set; }
        public int idusuario { get; set; }
        public string txinvestimento { get; set; }
        public DateTime dtcadastro { get; set; }
        public List<InvestimentoTurmas> turmas { get; set; }
        public List<InvestimentoAcoes> ultimaacao { get; set; }
        public List<InvestimentoValores> valores { get; set; }

        public Investimentos()
        {
            this.idinvestimento = 0;
            this.vlinvestimento = 0;
            this.idtipoinvestimento = 0;
            this.idtipoperiodo = 0;
            this.dtinicio = Convert.ToDateTime("1900-01-01");
            this.dtfim = Convert.ToDateTime("1900-01-01");
            this.txobs = "";
            this.idusuario = 0;
            this.txinvestimento = "";
            this.dtcadastro = Convert.ToDateTime("1900-01-01");
        }

        public Investimentos(int idinvestimento, decimal vlinvestimento, int idtipoinvestimento, int idtipoperiodo, DateTime dtinicio, DateTime dtfim, string txobs, int idusuario, string txinvestimento)
        {
            this.idinvestimento = idinvestimento;
            this.vlinvestimento = vlinvestimento;
            this.idtipoinvestimento = idtipoinvestimento;
            this.idtipoperiodo = idtipoperiodo;
            this.dtinicio = dtinicio;
            this.dtfim = dtfim;
            this.txobs = txobs;
            this.idusuario = idusuario;
            this.txinvestimento = txinvestimento;
            this.turmas = new InvestimentoDB().ListarTurmasInvestimento(idinvestimento);
            this.ultimaacao = new InvestimentoDB().Alteracoes(idinvestimento);
            this.valores = new InvestimentoDB().Valores(idinvestimento);
        }

    }

    public class InvestimentoPeriodos
    {
        public int idtipoperiodo { get; set; }
        public string txtipoperiodo { get; set; }

        public InvestimentoPeriodos()
        {
            this.idtipoperiodo = 0;
            this.txtipoperiodo = "";
        }

        public InvestimentoPeriodos(int idtipoperiodo, string txtipoperiodo)
        {
            this.idtipoperiodo = idtipoperiodo;
            this.txtipoperiodo = txtipoperiodo;
        }
    }

    public class InvestimentoTipos
    {
        public int idtipoinvestimento { get; set; }
        public string txtipoinvestimento { get; set; }

        public InvestimentoTipos()
        {
            this.idtipoinvestimento = 0;
            this.txtipoinvestimento = "";
        }

        public InvestimentoTipos(int idtipoinvestimento, string txtipoinvestimento)
        {
            this.idtipoinvestimento = idtipoinvestimento;
            this.txtipoinvestimento = txtipoinvestimento;
        }

    }

    public class InvestimentoTurmas
    {
        public int ididinvestimento { get; set; }
        public int idturma { get; set; }
        public string titulo { get; set; }

        public InvestimentoTurmas(int ididinvestimento, int idturma, string titulo)
        {
            this.ididinvestimento = ididinvestimento;
            this.idturma = idturma;
            this.titulo = titulo;
        }
    }

    public class InvestimentoAcoes
    {
        public int ididinvestimento { get; set; }
        public DateTime dtpausa { get; set; }
        public DateTime dtreativado { get; set; }

        public InvestimentoAcoes(int ididinvestimento, DateTime dtpausa, DateTime dtreativado)
        {
            this.ididinvestimento = ididinvestimento;
            this.dtpausa = dtpausa;
            this.dtreativado = dtreativado;
        }
    }

    public class InvestimentoValores
    {
        public int ididinvestimento { get; set; }
        public DateTime dtalteracao { get; set; }
        public decimal vlalteracao { get; set; }

        public InvestimentoValores(int ididinvestimento, DateTime dtalteracao, decimal vlalteracao)
        {
            this.ididinvestimento = ididinvestimento;
            this.dtalteracao = dtalteracao;
            this.vlalteracao = vlalteracao;
        }
    }
}
