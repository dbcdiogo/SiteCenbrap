using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Titulo_curso
    {
        public int codigo { get; set; }
        public string titulo { get; set; }
        public string titulo_detalhado { get; set; }
        public string link { get; set; }
        public string certificacao { get; set; }
        public string aula_inaugural { get; set; }
        public string publico_alvo { get; set; }
        public string duracao_meses { get; set; }
        public string horario_aulas { get; set; }
        public string documentacao { get; set; }

        public string disciplinas { get; set; }
        public string disciplinas_completo { get; set; }
        public string professores { get; set; }
        public string professores_completo { get; set; }

        public string icone { get; set; }
        public string cor1 { get; set; }
        public string cor2 { get; set; }
        public string texto { get; set; }

        public string imagem { get; set; }

        public Titulo_curso()
        {
            this.codigo = 0;
            this.titulo = "";
            this.link = "";
            this.titulo_detalhado = "";
            this.certificacao = "";
            this.aula_inaugural = "";
            this.publico_alvo = "";
            this.duracao_meses = "";
            this.horario_aulas = "";
            this.documentacao = "";

            this.disciplinas = "";
            this.disciplinas_completo = "";
            this.professores = "";
            this.professores_completo = "";

            this.icone = "";
            this.cor1 = "";
            this.cor2 = "";
            this.texto = "";

            this.imagem = "";
        }

        public Titulo_curso(int id)
        {
            this.codigo = id;
            this.titulo = "";
            this.titulo_detalhado = "";
            this.certificacao = "";
            this.aula_inaugural = "";
            this.publico_alvo = "";
            this.duracao_meses = "";
            this.horario_aulas = "";
            this.documentacao = "";

            this.disciplinas = "";
            this.disciplinas_completo = "";
            this.professores = "";
            this.professores_completo = "";

            this.icone = "";
            this.cor1 = "";
            this.cor2 = "";
            this.texto = "";

            this.imagem = "";
        }

        public Titulo_curso(int id, string titulo)
        {
            this.codigo = id;
            this.titulo = titulo;
            this.titulo_detalhado = "";
            this.certificacao = "";
            this.aula_inaugural = "";
            this.publico_alvo = "";
            this.duracao_meses = "";
            this.horario_aulas = "";
            this.documentacao = "";

            this.disciplinas = "";
            this.disciplinas_completo = "";
            this.professores = "";
            this.professores_completo = "";

            this.icone = "";
            this.cor1 = "";
            this.cor2 = "";
            this.texto = "";

            this.imagem = "";
        }

        public Titulo_curso(int codigo, string titulo, string titulo_detalhado, string certificacao, string aula_inaugural, string publico_alvo, string duracao_meses, string horario_aulas, string documentacao, string disciplinas, string disciplinas_completo, string professores, string professores_completo, string icone, string cor1, string cor2, string texto, string imagem, string link)
        {
            this.codigo = codigo;
            this.titulo = titulo;
            this.titulo_detalhado = titulo_detalhado;
            this.certificacao = certificacao;
            this.aula_inaugural = aula_inaugural;
            this.publico_alvo = publico_alvo;
            this.duracao_meses = duracao_meses;
            this.horario_aulas = horario_aulas;
            this.documentacao = documentacao;
            this.disciplinas = disciplinas;
            this.disciplinas_completo = disciplinas_completo;
            this.professores = professores;
            this.professores_completo = professores_completo;
            this.icone = icone;
            this.cor1 = cor1;
            this.cor2 = cor2;
            this.texto = texto;
            this.imagem = imagem;
            this.link = link;
        }

        public void Salvar()
        {
            new Titulo_cursoDB().Salvar(this);
        }

        public void Alterar()
        {
            new Titulo_cursoDB().Alterar(this);
        }

        public void Excluir()
        {
            new Titulo_cursoDB().Excluir(this);
        }
    }
}
