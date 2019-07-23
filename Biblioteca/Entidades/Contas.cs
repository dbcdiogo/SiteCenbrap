using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Contas
    {
        public int idemail { get; set; }
        public Dominio dominio { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public int limite { get; set; }
        public string nome_dominio { get; set; }

        public int qtdenviados { get; set; }

        public Contas()
        {
            this.idemail = 0;
            this.dominio = new Dominio();
            this.usuario = "";
            this.senha = "";
            this.limite = 0;
            this.nome_dominio = "";
            this.qtdenviados = 0;
        }

        public Contas(int id)
        {
            this.idemail = id;
            this.dominio = new Dominio();
            this.usuario = "";
            this.senha = "";
            this.limite = 0;
            this.nome_dominio = "";
            this.qtdenviados = 0;
        }

        public Contas(int id, Dominio dominio, string usuario, string senha, int limite, string nome_dominio)
        {
            this.idemail = id;
            this.dominio = dominio;
            this.usuario = usuario;
            this.senha = senha;
            this.limite = limite;
            this.nome_dominio = nome_dominio;
        }

        public Contas(int id, Dominio dominio, string usuario, string senha, int limite, string nome_dominio, int qtdenviados)
        {
            this.idemail = id;
            this.dominio = dominio;
            this.usuario = usuario;
            this.senha = senha;
            this.limite = limite;
            this.nome_dominio = nome_dominio;
            this.qtdenviados = qtdenviados;
        }
    }
}
