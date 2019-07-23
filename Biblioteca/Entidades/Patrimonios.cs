using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Biblioteca.Entidades
{
    public class Patrimonios
    {
        public int idpatrimonio { get; set; }
        public int idcategoria { get; set; }
        public int iddepartamento { get; set; }
        public int idsituacao { get; set; }
        public string txdescricao { get; set; }
        public Decimal nrvalor { get; set; }
        public DateTime dtcompra { get; set; }
        public string txobservacoes { get; set; }
        public int idlocal { get; set; }
        public int idcomprador { get; set; }
        public int nrpatrimonio { get; set; }
        public string categoria { get; set; }
        public string departamento { get; set; }
        public string situacao { get; set; }
        public string local { get; set; }
        public int qtdade { get; set; }
        public string txnrserie { get; set; }
        public string idpatrimoniovinc { get; set; }
        public string[] anexos { get; set; }

        public Patrimonios()
        {
            this.idpatrimonio = 0;
            this.idcategoria = 0;
            this.iddepartamento = 0;
            this.idsituacao = 0;
            this.txdescricao = "";
            this.nrvalor = 0;
            this.dtcompra = Convert.ToDateTime("01/01/1900");
            this.txobservacoes = "";
            this.idlocal = 0;
            this.idcomprador = 0;
            this.nrpatrimonio = new PatrimoniosDB().NumeroPatrimonio();
            this.qtdade = 1;
            this.txnrserie = "";
            this.idpatrimoniovinc = "";
        }

        public Patrimonios(int idpatrimonio, int idcategoria, int iddepartamento, int idsituacao, string txdescricao, Decimal nrvalor, DateTime dtcompra, string txobservacoes, int idlocal, int idcomprador, int nrpatrimonio, int qtdade, string txnrserie, string idpatrimoniovinc)
        {
            this.idpatrimonio = idpatrimonio;
            this.idcategoria = idcategoria;
            this.iddepartamento = iddepartamento;
            this.idsituacao = idsituacao;
            this.txdescricao = txdescricao;
            this.nrvalor = nrvalor;
            this.dtcompra = dtcompra;
            this.txobservacoes = txobservacoes;
            this.idlocal = idlocal;
            this.idcomprador = idcomprador;
            this.nrpatrimonio = nrpatrimonio;
            this.qtdade = qtdade;
            this.txnrserie = txnrserie;
            this.categoria = new PatrimoniosDB().BuscarCategoria(idcategoria);
            this.departamento = new DepartamentosDB().Buscar(iddepartamento).txdepartamento;
            this.situacao = new PatrimoniosDB().BuscarSituacao(idsituacao);
            this.local = new PatrimoniosDB().BuscarLocal(idlocal);
            this.idpatrimoniovinc = idpatrimoniovinc;
            if (idpatrimonio > 0) {
                string path = HttpContext.Current.Server.MapPath("~/Anexos/Patrimonios/" + idpatrimonio);
                if (Directory.Exists(path))
                {
                    this.anexos = Directory.GetFiles(path).Select(file => Path.GetFileName(file)).ToArray();
                }
            }
        }

        public Patrimonios(int idpatrimonio, string txdescricao, int nrpatrimonio)
        {
            this.idpatrimonio = idpatrimonio;
            this.txdescricao = txdescricao;
            this.nrpatrimonio = nrpatrimonio;
        }

        public int Salvar()
        {
            return new PatrimoniosDB().Salvar(this);
        }

        public void Alterar()
        {
            new PatrimoniosDB().Alterar(this);
        }
    }

    public class PatrimonioSituacao
    {
        public int idsituacao { get; set; }
        public string txsituacao { get; set; }

        public PatrimonioSituacao()
        {
            this.idsituacao = 0;
            this.txsituacao = "";
        }

        public PatrimonioSituacao(int idsituacao, string txsituacao)
        {
            this.idsituacao = idsituacao;
            this.txsituacao = txsituacao;
        }
    }

    public class PatrimonioCategoria
    {
        public int idcategoria { get; set; }
        public string txcategoria { get; set; }

        public PatrimonioCategoria()
        {
            this.idcategoria = 0;
            this.txcategoria = "";
        }

        public PatrimonioCategoria(int idcategoria, string txcategoria)
        {
            this.idcategoria = idcategoria;
            this.txcategoria = txcategoria;
        }
    }

    public class PatrimonioLocal
    {
        public int idlocal { get; set; }
        public string txlocal { get; set; }

        public PatrimonioLocal()
        {
            this.idlocal = 0;
            this.txlocal = "";
        }

        public PatrimonioLocal(int idlocal, string txlocal)
        {
            this.idlocal = idlocal;
            this.txlocal = txlocal;
        }
    }

    public class PatrimonioMovimentacao
    {
        public int idmovimentacao { get; set; }
        public int idpatrimonio { get; set; }
        public int idlocal { get; set; }
        public DateTime dtmovimentacao { get; set; }
        public int idusuario { get; set; }
        public string local { get; set; }
        public string usuario { get; set; }

        public PatrimonioMovimentacao()
        {
            this.idmovimentacao = 0;
            this.idpatrimonio = 0;
            this.idlocal = 0;
            this.dtmovimentacao = Convert.ToDateTime("01/01/1900"); ;
            this.idusuario = 0;
            this.local = "";
            this.usuario = "";
        }

        public PatrimonioMovimentacao(int idmovimentacao, int idpatrimonio, int idlocal, DateTime dtmovimentacao, int idusuario)
        {
            this.idmovimentacao = idmovimentacao;
            this.idpatrimonio = idpatrimonio;
            this.idlocal = idlocal;
            this.dtmovimentacao = dtmovimentacao;
            this.idusuario = idusuario;
            if (idlocal > 0) { this.local = new PatrimoniosDB().BuscarLocal(idlocal); }
            if (idusuario > 0) { this.usuario = new TimelineUsuariosDB().Buscar(idusuario).txnome; }
        }

        public void Salvar()
        {
            new PatrimoniosDB().SalvarMovimentacao(this);
        }
    }

    public class PatrimonioAlteraSituacao
    {
        public int idaltsituacao { get; set; }
        public int idpatrimonio { get; set; }
        public int idsituacao { get; set; }
        public DateTime dtalteracao { get; set; }
        public int idusuario { get; set; }
        public string situacao { get; set; }
        public string usuario { get; set; }
        public Decimal nralteracao { get; set; }

        public PatrimonioAlteraSituacao()
        {
            this.idaltsituacao = 0;
            this.idpatrimonio = 0;
            this.idsituacao = 0;
            this.dtalteracao = Convert.ToDateTime("01/01/1900"); ;
            this.idusuario = 0;
            this.situacao = "";
            this.usuario = "";
            this.nralteracao = 0;
        }

        public PatrimonioAlteraSituacao(int idaltsituacao, int idpatrimonio, int idsituacao, DateTime dtalteracao, int idusuario, decimal nralteracao)
        {
            this.idaltsituacao = idaltsituacao;
            this.idpatrimonio = idpatrimonio;
            this.idsituacao = idsituacao;
            this.dtalteracao = dtalteracao;
            this.idusuario = idusuario;
            this.nralteracao = nralteracao;
            if (idsituacao > 0) { this.situacao = new PatrimoniosDB().BuscarSituacao(idsituacao); }
            if (idusuario > 0) { this.usuario = new TimelineUsuariosDB().Buscar(idusuario).txnome; }
        }

        public void Salvar()
        {
            new PatrimoniosDB().SalvarAlteraSituacao(this);
        }
    }
}
