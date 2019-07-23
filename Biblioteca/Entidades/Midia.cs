using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Midia
    {
        public int midia_id { get; set; }
        public Midia_tipo midia_tipo_id { get; set; }
        public Painel painel { get; set; }
        public DateTime data { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public decimal valor { get; set; }
        public string obs { get; set; }
        public int visualizacoes { get; set; }
        public int alcance { get; set; }
        public int curtidas { get; set; }
        public int comentario_positivo { get; set; }
        public int comentario_negativo { get; set; }
        public int compartilhamento { get; set; }
        public bool impulsionada { get; set; }

        public string identificador { get; set; }

        public List<Cidade> cidades { get; set; }
        public List<Titulo_curso> titulos_curso { get; set; }
        public List<Curso> cursos { get; set; }

        public Midia()
        {
            this.midia_id = 0;
            this.midia_tipo_id = new Midia_tipo();
            this.painel = new Painel();
            this.data = DateTime.Now;
            this.titulo = "";
            this.descricao = "";
            this.valor = 0;
            this.obs = "";
            this.visualizacoes = 0;
            this.alcance = 0;
            this.curtidas = 0;
            this.comentario_negativo = 0;
            this.comentario_positivo = 0;
            this.compartilhamento = 0;
            this.impulsionada = false;
            this.identificador = "";

            this.cidades = new List<Cidade>();
            this.titulos_curso = new List<Titulo_curso>();
            this.cursos = new List<Curso>();
        }

        public Midia(int id, Midia_tipo tipo, Painel painel, DateTime data, string titulo, string descricao, decimal valor, string obs, int visualizacoes, int alcance, int curtidas, int comentario_positivo, int comentario_negativo, int compartilhamento, bool impulsionada, string identificador)
        {
            this.midia_id = id;
            this.midia_tipo_id = tipo;
            this.painel = painel;
            this.data = data;
            this.titulo = titulo;
            this.descricao = descricao;
            
            this.valor = valor;
            this.obs = obs;
            this.visualizacoes = visualizacoes;
            this.alcance = alcance;
            this.curtidas = curtidas;
            this.comentario_negativo = comentario_negativo;
            this.comentario_positivo = comentario_positivo;
            this.compartilhamento = compartilhamento;
            this.impulsionada = impulsionada;

            this.identificador = identificador;
        }

        public Midia(int id, Midia_tipo tipo, Painel painel, DateTime data, string titulo, string descricao, decimal valor, string obs, int visualizacoes, int alcance, int curtidas, int comentario_positivo, int comentario_negativo, int compartilhamento, bool impulsionada, List<Cidade> cidades, List<Titulo_curso> titulos_curso, List<Curso> cursos, string identificador)
        {
            this.midia_id = id;
            this.midia_tipo_id = tipo;
            this.painel = painel;
            this.data = data;
            this.titulo = titulo;
            this.descricao = descricao;
            this.cidades = cidades;
            this.titulos_curso = titulos_curso;
            this.cursos = cursos;
            this.valor = valor;
            this.obs = obs;
            this.visualizacoes = visualizacoes;
            this.alcance = alcance;
            this.curtidas = curtidas;
            this.comentario_negativo = comentario_negativo;
            this.comentario_positivo = comentario_positivo;
            this.compartilhamento = compartilhamento;
            this.impulsionada = impulsionada;
            this.identificador = identificador;
        }

        public void Salvar()
        {
            new MidiaDB().Salvar(this);
            this.midia_id = new MidiaDB().Buscar(this.titulo, this.midia_tipo_id).midia_id;
        }

        public void Alterar()
        {
            new MidiaDB().Alterar(this);
        }

        public void Excluir()
        {
            new MidiaDB().Excluir(this);
        }
    }

    public class MidiaCampanhas
    {
        public int idcampanha { get; set; }
        public string txcampanha { get; set; }
        public DateTime data { get; set; }
    }
}
