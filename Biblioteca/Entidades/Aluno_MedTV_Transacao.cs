using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Aluno_MedTV_Transacao
    {
        public int aluno_MedTV_Transacao_id { get; set; }
        public Aluno_MedTV aluno_medTV_id { get; set; }
        public int status { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
        public DateTime data { get; set; }

        public Aluno_MedTV_Transacao()
        {
            this.aluno_MedTV_Transacao_id = 0;
            this.aluno_medTV_id = new Aluno_MedTV();
            this.status = 0;
            this.code = "";
            this.msg = "";
            this.data = Convert.ToDateTime("01/01/1900");
        }

        public Aluno_MedTV_Transacao(int id, Aluno_MedTV aluno_medtv, int status, string code, string msg, DateTime data)
        {
            this.aluno_MedTV_Transacao_id = id;
            this.aluno_medTV_id = aluno_medtv;
            this.status = status;
            this.code = code;
            this.msg = msg;
            this.data = data;
        }

        public void Salvar()
        {
            this.aluno_MedTV_Transacao_id = new Aluno_MedTV_TransacaoDB().SalvarRetornar(this);
        }

        public void Alterar()
        {
            new Aluno_MedTV_TransacaoDB().Alterar(this);
        }

        public void Excluir()
        {
            new Aluno_MedTV_TransacaoDB().Excluir(this);
        }
    }
}
