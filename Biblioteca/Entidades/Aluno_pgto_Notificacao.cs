using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Aluno_pgto_Notificacao
    {
        public Aluno_pgto aluno_pgto { get; set; }
        public DateTime data { get; set; }
        public string status { get; set; }
        public string msg { get; set; }

        public Aluno_pgto_Notificacao()
        {
            this.aluno_pgto = new Aluno_pgto();
            this.data = DateTime.Now;
            this.status = "";
            this.msg = "";

        }

        public Aluno_pgto_Notificacao(Aluno_pgto aluno_pgto, DateTime data, string status, string msg)
        {
            this.aluno_pgto = aluno_pgto;
            this.data = data;
            this.status = status;
            this.msg = msg;
        }

        public void Salvar()
        {
            new Aluno_pgto_NotificacaoDB().Salvar(this);
        }
    }
}
