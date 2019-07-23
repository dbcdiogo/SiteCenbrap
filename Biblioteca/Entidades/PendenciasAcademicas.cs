using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class ClienteAcademico
    {
        public int aluno { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public int curso { get; set; }
        public string cursoTitulo { get; set; }
        public int aluno_curso { get; set; }
        public int situacao { get; set; }
        public DateTime dataConfirmacao { get; set; }
        public DateTime dataDesistente { get; set; }
        public DateTime contrato { get; set; }

        public List<string> documentos { get; set; }
        public string qtdEncontros { get; set; }
        public List<string> frequencia { get; set; }


        //declare @curso int;
        //declare @aluno int;
        //set @curso = 243;
        //set @aluno = 8406;
        //select documentos1 from documentos where curso = @curso and not exists(select * from documentos_alunos where curso = @curso and aluno = @aluno and documentos.codigo = documentos_alunos.documentos)
    }
}
