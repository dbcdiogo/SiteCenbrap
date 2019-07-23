using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class ProgramacaoView
    {
        public DateTime data { get; set; }
        public List<Programacao> programacao { get; set; }

        public ProgramacaoView()
        {
            this.data = DateTime.Now;
            this.programacao = new List<Programacao>();
        }

        public ProgramacaoView(DateTime data, string dominio)
        {
            this.data = data;
            this.programacao = new ProgramacaoDB().Listar(data, dominio);
            foreach(var p in this.programacao)
            {
                p.palestrantes = new List<Palestrante>();
                foreach(var pa in new Programacao_palestranteDB().ListarOrdenado(p))
                {
                    p.palestrantes.Add(pa.palestrante_id);
                }
            }
        }

        public string Dia()
        {
            return "dia" + this.data.Day.ToString("00") + "" + this.data.Month.ToString("00");
        }
    }
}
