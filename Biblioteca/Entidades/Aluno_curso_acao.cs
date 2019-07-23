using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Aluno_curso_Acao
    {
        public int idacao { get; set; }
        public int aluno_curso { get; set; }
        public string txacao { get; set; }
        public string tipo { get; set; }
        public DateTime dtacao { get; set; }
        public int idusuario { get; set; }
        public TimelineUsuarios usuario { get; set; }
        public DateTime dtretorno { get; set; }
        public string txobs { get; set; }
        public List<Aluno_curso_Acao_Usuario> usuarios { get; set; }
        public string celular { get; set; }

        public Aluno_curso_Acao()
        {
            this.idacao = 0;
            this.aluno_curso = 0;
            this.txacao = "";
            this.tipo = "";
            this.dtacao = DateTime.Now;
            this.idusuario = 0;
            this.usuario = null;
            this.dtretorno = Convert.ToDateTime("01/01/1900");
            this.txobs = "";
            this.usuarios = null;
            this.celular = "";
        }

        public Aluno_curso_Acao(int idacao, int aluno_curso, string txacao, string tipo, DateTime dtacao, int idusuario, DateTime dtretorno, string txobs)
        {
            this.idacao = idacao;
            this.aluno_curso = aluno_curso;
            this.txacao = txacao;
            this.tipo = tipo;
            this.dtacao = dtacao;
            this.idusuario = idusuario;
            this.usuario = new TimelineUsuariosDB().Buscar(idusuario);
            this.dtretorno = dtretorno;
            this.txobs = txobs;
            this.usuarios = new Aluno_curso_AcaoDB().ListarUsuarios(idacao);
        }

        public int Salvar()
        {
            return new Aluno_curso_AcaoDB().Salvar(this);
        }

        public void Alterar()
        {
            new Aluno_curso_AcaoDB().Alterar(this);
        }

    }

    public class Aluno_curso_Acao_Usuario
    {
        public int idacao { get; set; }
        public int idusuario { get; set; }
        public string txnome { get; set; }

        public Aluno_curso_Acao_Usuario(int idacao, int idusuario, string txnome)
        {
            this.idacao = idacao;
            this.idusuario = idusuario;
            this.txnome = txnome;

        }
    }
}
