using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class BSC_Perspectivas
    {
        public int idperspectiva { get; set; }
        public string txperspectiva { get; set; }
        public int nrordem { get; set; }
        public string txcor { get; set; }
        public string txiniciativa { get; set; }
        public List<BSC_Objetivos> objetivos { get; set; }

        public BSC_Perspectivas()
        {
            this.idperspectiva = 0;
            this.txperspectiva = "";
            this.nrordem = 0;
            this.txcor = "";
            this.txiniciativa = "";
            this.objetivos = null;
        }

        public BSC_Perspectivas(int idperspectiva, string txperspectiva, int nrordem, string txcor, string txiniciativa)
        {
            this.idperspectiva = idperspectiva;
            this.txperspectiva = txperspectiva;
            this.nrordem = nrordem;
            this.txcor = txcor;
            this.txiniciativa = txiniciativa;
        }

        public void Salvar()
        {
            this.idperspectiva = new BscDB().SalvarPerspectivaRetornar(this);
        }

        public void Alterar()
        {
            new BscDB().AlterarPerspectiva(this);
        }

        public void Excluir()
        {
            new BscDB().ExcluirPerspectiva(this);
        }

    }

    public class BSC_Objetivos
    {
        public int idobjetivo { get; set; }
        public int idperspectiva { get; set; }
        public string txobjetivo { get; set; }
        public int nrordem { get; set; }
        public List<BSC_Indicadores> inidicadores { get; set; }

        public BSC_Objetivos()
        {
            this.idobjetivo = 0;
            this.idperspectiva = 0;
            this.txobjetivo = "";
            this.nrordem = 0;
            this.inidicadores = null;
        }

        public BSC_Objetivos(int idobjetivo, int idperspectiva, string txobjetivo, int nrordem)
        {
            this.idobjetivo = idobjetivo;
            this.idperspectiva = idperspectiva;
            this.txobjetivo = txobjetivo;
            this.nrordem = nrordem;
        }

        public void Salvar()
        {
            this.idobjetivo = new BscDB().SalvarObjetivoRetornar(this);
        }

        public void Alterar()
        {
            new BscDB().AlterarObjetivo(this);
        }

        public void Excluir()
        {
            new BscDB().ExcluirObjetivo(this);
        }

    }

    public class BSC_Indicadores
    {
        public int idindicador { get; set; }
        public int idobjetivo { get; set; }
        public string txindicador { get; set; }
        public int nrordem { get; set; }
        public string txunidade { get; set; }
        public int idcondicao { get; set; }
        public List<BSC_Metas> metas { get; set; }
        public List<BSC_Indicadores_Valor> valores { get; set; }

        public BSC_Indicadores()
        {
            this.idindicador = 0;
            this.idobjetivo = 0;
            this.txindicador = "";
            this.nrordem = 0;
            this.metas = null;
            this.txunidade = "";
            this.idcondicao = 1;
            this.valores = null;
        }

        public BSC_Indicadores(int idindicador, int idobjetivo, string txindicador, int nrordem, string txunidade, int idcondicao)
        {
            this.idindicador = idindicador;
            this.idobjetivo = idobjetivo;
            this.txindicador = txindicador;
            this.nrordem = nrordem;
            this.txunidade = txunidade;
            this.idcondicao = idcondicao;
            this.metas = new BscDB().ListarMetas(idindicador);
        }

        public void Salvar()
        {
            this.idobjetivo = new BscDB().SalvarIndicadorRetornar(this);
        }

        public void Alterar()
        {
            new BscDB().AlterarIndicador(this);
        }

        public void Excluir()
        {
            new BscDB().ExcluirIndicador(this);
        }

    }

    public class BSC_Kpis
    {
        public int idkpi { get; set; }
        public int idindicador { get; set; }
        public string txkpi { get; set; }
        public int nrordem { get; set; }
        public string txformula { get; set; }
        public string txunidade { get; set; }

        public BSC_Kpis()
        {
            this.idkpi = 0;
            this.idindicador = 0;
            this.txkpi = "";
            this.nrordem = 0;
            this.txformula = "";
            this.txunidade = "";
        }

        public BSC_Kpis(int idkpi, int idindicador, string txkpi, int nrordem, string txformula, string txunidade)
        {
            this.idkpi = idkpi;
            this.idindicador = idindicador;
            this.txkpi = txkpi;
            this.nrordem = nrordem;
            this.txformula = txformula;
            this.txunidade = txunidade;
        }

        //public void Salvar()
        //{
        //    this.idkpi = new BscDB().SalvarKpiRetornar(this);
        //}

        //public void Alterar()
        //{
        //    new BscDB().AlterarKpi(this);
        //}

        //public void Excluir()
        //{
        //    new BscDB().ExcluirKpi(this);
        //}

    }

    public class BSC_Metas
    {
        public int idindicador { get; set; }
        public int txano { get; set; }
        public string txvalor { get; set; }

        public BSC_Metas()
        {
            this.idindicador = 0;
            this.txano = 0;
            this.txvalor = "";
        }

        public BSC_Metas(int idindicador, int txano, string txvalor)
        {
            this.idindicador = idindicador;
            this.txano = txano;
            this.txvalor = txvalor;
        }

        public void Salvar()
        {
            new BscDB().SalvarMeta(this);
        }

        public void Alterar()
        {
            new BscDB().AlterarMeta(this);
        }
    }

    public class BSC_Indicadores_Valor
    {
        public int idindicador { get; set; }
        public int ano { get; set; }
        public int mes { get; set; }
        public int valor { get; set; }

        public BSC_Indicadores_Valor()
        {
            this.idindicador = 0;
            this.ano = 0;
            this.mes = 0;
            this.valor = 0;
        }

        public BSC_Indicadores_Valor(int idindicador, int ano, int mes, int valor)
        {
            this.idindicador = idindicador;
            this.ano = ano;
            this.mes = mes;
            this.valor = valor;
        }

        public void Salvar()
        {
            new BscDB().SalvarIndicadorValor(this);
        }

        public void Alterar()
        {
            new BscDB().AlterarIndicadorValor(this);
        }

        public void Excluir()
        {
            new BscDB().ExcluirIndicadorValor(this);
        }
    }

}
