using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Aluno_curso_log
    {
        public int Aluno_curso_log_id { get; set; }
        public Aluno_curso aluno_curso { get; set; }
        public int tipo { get; set; } //0 - inscrição, 1 - Boleto, 2 - Cartão, 3 - Matrícula, 4 - Desistência, 5 - Contrato, 6 - Aberto inativo, 7 - Aberto reativado, 8 - Matricula inativa, 9 - Matricula reativada, 10 - Inativo
        public string texto { get; set; }
        public DateTime data { get; set; }

        public Aluno_curso_log()
        {
            this.Aluno_curso_log_id = 0;
            this.aluno_curso = new Aluno_curso();
            this.tipo = 0;
            this.texto = "";
            this.data = DateTime.Now;
        }

        public Aluno_curso_log(Aluno_curso aluno_curso, int tipo)
        {
            this.Aluno_curso_log_id = 0;
            this.aluno_curso = aluno_curso;
            this.tipo = tipo;
            if (tipo == 0)
                this.texto = "Inscrição";
            if (tipo == 1)
                this.texto = "Boleto";
            if (tipo == 2)
                this.texto = "Cartão";
            if (tipo == 3)
                this.texto = "Matrícula";
            if (tipo == 4)
                this.texto = "Desistência";
            if (tipo == 5)
                this.texto = "Contrato";
            if (tipo == 6)
                this.texto = "Aberto Inativo";
            if (tipo == 7)
                this.texto = "Aberto Reativado";
            if (tipo == 8)
                this.texto = "Matrícula Inativo";
            if (tipo == 9)
                this.texto = "Matrícula Reativada";
            this.data = DateTime.Now;

            new Aluno_curso_logDB().Salvar(this);
        }

    }
}
