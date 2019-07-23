using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class TimelineHome
    {
        public int codigo { get; set; }
        public string titulo { get; set; }
        public string titulo1 { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_confirmado { get; set; }
        public TimelineTurmaDados dados { get; set; }
        public TimelineTurmaDados dados_anterior { get; set; }
        public int eventos { get; set; }
        public int historico { get; set; }
        public List<TimelineTurmaDadosLog> dadosLog { get; set; }
        public List<TimelineTurmaDadosLog> dadosLogAnterior { get; set; }
        public int destaque { get; set; }

        public TimelineHome()
        {
            this.codigo = 0;
            this.titulo = "";
            this.titulo1 = "";
            this.data_inicio = Convert.ToDateTime("01/01/1900");
            this.data_confirmado = Convert.ToDateTime("01/01/1900");
            this.dados = null;
            this.dados_anterior = null;
            this.eventos = 0;
            this.historico = 0;
            this.destaque = 0;
        }

        public TimelineHome(int codigo)
        {
            this.codigo = codigo;
        }

        public TimelineHome(int codigo, string titulo, string titulo1, DateTime data_inicio)
        {
            this.codigo = codigo;
            this.titulo = titulo;
            this.titulo1 = titulo1;
            this.data_inicio = data_inicio;
        }

        public TimelineHome(int dias, int codigo, string titulo, string titulo1, DateTime data_inicio, DateTime data_confirmado, int eventos, int historico)
        {
            this.codigo = codigo;
            this.titulo = titulo;
            this.titulo1 = titulo1;
            this.data_inicio = data_inicio;
            this.data_confirmado = data_confirmado;
            this.dados = new TimelineHomeDB().ListarDadosTurma(codigo);
            this.dados_anterior = new TimelineHomeDB().ListarDadosTurmaAnterior(codigo, dias);
            this.eventos = eventos;
            this.historico = historico;
            //this.dadosLog = new TimelineHomeDB().ListarDadosTurmaLog(codigo);
            //this.dadosLogAnterior = new TimelineHomeDB().ListarDadosTurmaLogAnterior(codigo);

            //this.dados = new TimelineTurmaDados();
            //foreach (var l in dadosLog)
            //{
            //    switch (l.tipo)
            //    {
            //        case 0: this.dados.aberto = l.qtdade; break;
            //        case 3: this.dados.confirmado = l.qtdade; break;
            //        case 4: this.dados.desistente = l.qtdade; break;
            //        case 5: this.dados.contrato = l.qtdade; break;
            //        case 9: this.dados.inativos = l.qtdade; break;
            //        case 10: this.dados.reservado = l.qtdade; break;
            //    }
            //}

            //this.dados_anterior = new TimelineTurmaDados();
            //foreach (var l in dadosLogAnterior)
            //{
            //    switch (l.tipo)
            //    {
            //        case 0: this.dados_anterior.aberto = l.qtdade; break;
            //        case 3: this.dados_anterior.confirmado = l.qtdade; break;
            //        case 4: this.dados_anterior.desistente = l.qtdade; break;
            //        case 5: this.dados_anterior.contrato = l.qtdade; break;
            //        case 9: this.dados_anterior.inativos = l.qtdade; break;
            //        case 10: this.dados_anterior.reservado = l.qtdade; break;
            //    }
            //}
        }

        public TimelineHome(int dias, int codigo, string titulo, string titulo1, DateTime data_inicio, DateTime data_confirmado, int eventos, int historico, int destaque)
        {
            this.codigo = codigo;
            this.titulo = titulo;
            this.titulo1 = titulo1;
            this.data_inicio = data_inicio;
            this.data_confirmado = data_confirmado;
            this.dados = new TimelineHomeDB().ListarDadosTurma(codigo);
            this.dados_anterior = new TimelineHomeDB().ListarDadosTurmaAnterior(codigo, dias);
            this.eventos = eventos;
            this.historico = historico;
            this.destaque = destaque;
            this.dadosLog = new TimelineHomeDB().ListarDadosTurmaLog(codigo);
            //this.dadosLogAnterior = new TimelineHomeDB().ListarDadosTurmaLogAnterior(codigo);

            //this.dados = new TimelineTurmaDados();
            //foreach (var l in dadosLog)
            //{
            //    switch (l.tipo)
            //    {
            //        case 0: this.dados.aberto = l.qtdade; break;
            //        case 3: this.dados.confirmado = l.qtdade; break;
            //        case 4: this.dados.desistente = l.qtdade; break;
            //        case 5: this.dados.contrato = l.qtdade; break;
            //        case 9: this.dados.inativos = l.qtdade; break;
            //        case 10: this.dados.reservado = l.qtdade; break;
            //    }
            //}

            //this.dados_anterior = new TimelineTurmaDados();
            //foreach (var l in dadosLogAnterior)
            //{
            //    switch (l.tipo)
            //    {
            //        case 0: this.dados_anterior.aberto = l.qtdade; break;
            //        case 3: this.dados_anterior.confirmado = l.qtdade; break;
            //        case 4: this.dados_anterior.desistente = l.qtdade; break;
            //        case 5: this.dados_anterior.contrato = l.qtdade; break;
            //        case 9: this.dados_anterior.inativos = l.qtdade; break;
            //        case 10: this.dados_anterior.reservado = l.qtdade; break;
            //    }
            //}
        }

    }

    public class TimelineTurmaDadosLog
    {
        public int tipo { get; set; }
        public int qtdade { get; set; }

        public TimelineTurmaDadosLog(int tipo, int qtdade)
        {
            this.tipo = tipo;
            this.qtdade = qtdade;
        }
    }


    public class TimelineTurmaDados
    {
        public int aberto { get; set; }
        public int reservado { get; set; }
        public int confirmado { get; set; }
        public int desistente { get; set; }
        public int contrato { get; set; }
        public int inativos { get; set; }

        public TimelineTurmaDados()
        {
            this.aberto = 0;
            this.reservado = 0;
            this.confirmado = 0;
            this.desistente = 0;
            this.contrato = 0;
            this.inativos = 0;
        }

        public TimelineTurmaDados(int aberto, int reservado, int confirmado, int desistente, int contrato, int inativos)
        {
            this.aberto = (aberto - reservado);
            //this.aberto = ((aberto - reservado) - inativos);
            this.reservado = reservado;
            this.confirmado = confirmado;
            this.desistente = desistente;
            this.contrato = contrato;
            this.inativos = inativos;
        }

    }

}
