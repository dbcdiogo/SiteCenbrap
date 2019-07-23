using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Programacao_palestrante
    {
        public Programacao programacao_id { get; set; }
        public Palestrante palestrante_id { get; set; }

        public Programacao_palestrante()
        {
            this.programacao_id = new Programacao();
            this.palestrante_id = new Palestrante();
        }

        public Programacao_palestrante(Programacao programacao, Palestrante palestrante)
        {
            this.programacao_id = programacao;
            this.palestrante_id = palestrante;
        }

        public void Salvar()
        {
            new Programacao_palestranteDB().Salvar(this);
        }

        public void Excluir()
        {
            new Programacao_palestranteDB().Excluir(this);
        }
    }
}
