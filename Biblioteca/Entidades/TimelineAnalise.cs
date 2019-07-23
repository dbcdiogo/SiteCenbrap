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
    public class TimelineAnalise
    {
        public string data { get; set; }
        public int inscricao { get; set; }
        public int boleto { get; set; }
        public int cartao { get; set; }
        public int matricula { get; set; }
        public int desistencia { get; set; }
        public int contrato { get; set; }
        public int abertoinativo { get; set; }
        public int abertoreativado { get; set; }
        public int matriculainativo { get; set; }
        public int matriculareativado { get; set; }
        public int prereserva { get; set; }
        public int iniciocurso { get; set; }
        public int aberturamatricula { get; set; }
        public int inicioconfirmado { get; set; }
        public int espera { get; set; }
        public int adiamento { get; set; }
        public int campanha { get; set; }
        public int evento { get; set; }
        public string nome_campanha { get; set; }
        public string nome_evento { get; set; }
        public string tipo_evento { get; set; }

        public TimelineAnalise(string data, int inscricao, int boleto, int cartao, int matricula, int desistencia, int contrato, int abertoinativo, int abertoreativado, int matriculainativo, int matriculareativado, int prereserva, int iniciocurso, int aberturamatricula, int inicioconfirmado, int espera, int adiamento, int campanha, int evento, string tipo_evento)            
        {
            this.data = data;
            this.inscricao = inscricao;
            this.boleto = boleto;
            this.cartao = cartao;
            this.matricula = matricula;
            this.desistencia = desistencia;
            this.contrato = contrato;
            this.abertoinativo = abertoinativo;
            this.abertoreativado = abertoreativado;
            this.matriculainativo = matriculainativo;
            this.matriculareativado = matriculareativado;
            this.prereserva = prereserva;
            this.iniciocurso = iniciocurso;
            this.aberturamatricula = aberturamatricula;
            this.inicioconfirmado = inicioconfirmado;
            this.espera = espera;
            this.adiamento = adiamento;
            this.campanha = campanha;
            this.evento = evento;
            this.tipo_evento = tipo_evento;
            if (campanha > 0)
            {
                Campanhas camp = new CampanhasDB().Buscar(campanha);
                if (camp != null)
                {
                    this.nome_campanha = camp.txcampanha;
                }
            }
            if (evento > 0)
            {
                this.nome_evento = new TimelineEventosDB().BuscarNomeEvento(evento);
            }
        }
    }
}
