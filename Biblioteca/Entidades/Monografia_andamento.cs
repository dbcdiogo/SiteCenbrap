using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Monografia_andamento
    {
        public int codigo { get; set; }
        public Curso curso { get; set; }
        public Aluno aluno { get; set; }
        public Monografia monografia { get; set; }
        public DateTime data { get; set; }
        public int destino { get; set; }
        public string arquivo { get; set; }
        public string texto { get; set; }
        public int situacao { get; set; }

        public Monografia_andamento()
        {
            this.codigo = 0;
            this.curso = new Curso() { codigo = 0 };
            this.aluno = new Aluno() { codigo = 0 };
            this.monografia = new Monografia() { codigo = 0 };
            this.data = DateTime.Now;
            this.destino = 0;
            this.arquivo = "";
            this.texto = "";
            this.situacao = 0;
        }

        public Monografia_andamento(int codigo, Curso curso, Aluno aluno, Monografia monografia, DateTime data, int destino, string arquivo, string texto, int situacao)
        {
            this.codigo = codigo;
            this.curso = curso;
            this.aluno = aluno;
            this.monografia = monografia;
            this.data = data;
            this.destino = destino;
            this.arquivo = arquivo;
            this.texto = texto;
            this.situacao = situacao;
        }

        public void Salvar()
        {
            this.codigo = new Monografia_andamentoDB().SalvarRetornar(this);
        }

        public void Alterar()
        {
            new Monografia_andamentoDB().Alterar(this);
        }

        public void Excluir()
        {
            new Monografia_andamentoDB().Excluir(this);
        }
    }
}
