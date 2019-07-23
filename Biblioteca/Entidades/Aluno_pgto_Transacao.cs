using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Aluno_pgto_Transacao
    {
        public int aluno_pgto_Transacao_id { get; set; }
        public Aluno_pgto aluno_pgto { get; set; }
        public int status { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
        public DateTime data { get; set; }


        public Aluno_pgto_Transacao()
        {
            this.aluno_pgto_Transacao_id = 0;
            this.aluno_pgto = new Aluno_pgto();
            this.status = 0;
            this.code = "";
            this.msg = "";
            this.data = Convert.ToDateTime("01/01/1900");
        }

        public Aluno_pgto_Transacao(int id, Aluno_pgto aluno_pgto, int status, string code, string msg, DateTime data)
        {
            this.aluno_pgto_Transacao_id = id;
            this.aluno_pgto = aluno_pgto;
            this.status = status;
            this.code = code;
            this.msg = msg;
            this.data = data;
        }

        public void Salvar()
        {
            this.aluno_pgto_Transacao_id = new Aluno_pgto_TransacaoDB().SalvarRetornar(this);
        }

        public void Alterar()
        {
            new Aluno_pgto_TransacaoDB().Alterar(this);
        }

        public void Excluir()
        {
            new Aluno_pgto_TransacaoDB().Excluir(this);
        }
    }
}
