using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class TurmasDashboardAnalise
    {
        public string titulo { get; set; }
        public int codigo { get; set; }
        public int tempo_matricula { get; set; }
        public int confirmados { get; set; }
        public int confirmadosmes { get; set; }
        public int confirmados4meses { get; set; }
        public int naoconfirmados { get; set; }
        public int naoconfirmadosmes { get; set; }
        public int naoconfirmados4meses { get; set; }
        public int boletosmes { get; set; }
        public int boletos4meses { get; set; }
        public int pontos { get; set; }
        public int p1 { get; set; }
        public int p2 { get; set; }
        public int p3 { get; set; }
        public int p4 { get; set; }
        public int p5 { get; set; }
        public int p6 { get; set; }
        public int destaques { get; set; }
        public DateTime datainicio { get; set; }
        public DateTime dataultimo { get; set; }
        public int farao { get; set; }

        public TurmasDashboardAnalise(string titulo, int codigo, int tempo_matricula, int confirmados, int confirmadosmes, int confirmados4meses, int naoconfirmados, int naoconfirmadosmes, int naoconfirmados4meses, int boletosmes, int boletos4meses, int pontos, int p1, int p2, int p3, int p4, int p5, int p6, int destaques, DateTime datainicio, int farao, DateTime dataultimo)
        {
            this.titulo = titulo;
            this.codigo = codigo;
            this.tempo_matricula = tempo_matricula;
            this.confirmados = confirmados;
            this.confirmadosmes = confirmadosmes;
            this.confirmados4meses = confirmados4meses;
            this.naoconfirmados = naoconfirmados;
            this.naoconfirmadosmes = naoconfirmadosmes;
            this.naoconfirmados4meses = naoconfirmados4meses;
            this.boletosmes = boletosmes;
            this.boletos4meses = boletos4meses;
            this.pontos = pontos;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.p5 = p5;
            this.p6 = p6;
            this.destaques = destaques;
            this.datainicio = datainicio;
            this.farao = farao;
            this.dataultimo = dataultimo;
        }
    }
}
