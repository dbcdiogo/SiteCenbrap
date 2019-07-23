using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class TimelineUsuarios
    {
        public int idusuario { get; set; }
        public string txnome { get; set; }
        public string txemail { get; set; }
        public string txsenha { get; set; }
        public string txlogin { get; set; }
        public int idperfil { get; set; }
        public int flativo { get; set; }
        public string txfoto { get; set; }
        public int idaluno { get; set; }
        public int flignorar { get; set; }
        public int fldashboard { get; set; }
        public Aluno aluno { get; set; }
        public TimelinePerfis perfil { get; set; }

        public TimelineUsuarios()
        {
            this.idusuario = 0;
            this.txnome = "";
            this.txemail = "";
            this.txsenha = "";
            this.txlogin = "";
            this.idperfil = 0;
            this.flativo = 0;
            this.txfoto = "";
            this.idaluno = 0;
            this.flignorar = 0;
            this.aluno = null;
            this.perfil = null;
            this.fldashboard = 0;
        }

        public TimelineUsuarios(int idusuario, string txnome, string txemail, string txsenha, string txlogin, int idperfil, int flativo, string txfoto, int idaluno, int flignorar, int fldashboard)
        {
            this.idusuario = idusuario;
            this.txnome = txnome;
            this.txemail = txemail;
            this.txsenha = txsenha;
            this.txlogin = txlogin;
            this.idperfil = idperfil;
            this.flativo = flativo;
            this.txfoto = txfoto;
            this.idaluno = idaluno;
            this.flignorar = flignorar;
            this.fldashboard = fldashboard;
            this.aluno = new Aluno();
            if (idaluno > 0)
            {
                this.aluno = new AlunoDB().Buscar(idaluno);
            }
            if (idperfil > 0)
            {
                this.perfil = new TimelinePerfisDB().Buscar(idperfil);
            }
        }


    }

}
