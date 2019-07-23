using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Aluno_MedTV_Notificacao
    {
        public Aluno_MedTV aluno_MedTV_id { get; set; }
        public DateTime data { get; set; }
        public string status { get; set; }
        public string msg { get; set; }

        public Aluno_MedTV_Notificacao()
        {
            this.aluno_MedTV_id = new Aluno_MedTV();
            this.data = DateTime.Now;
            this.status = "";
            this.msg = "";
        }

        public Aluno_MedTV_Notificacao(Aluno_MedTV aluno_medtv, DateTime data, string status, string msg)
        {
            this.aluno_MedTV_id = aluno_medtv;
            this.data = data;
            this.status = status;
            this.msg = msg;
        }

        public void Salvar()
        {
            new Aluno_MedTV_NotificacaoDB().Salvar(this);
        }
    }
}
