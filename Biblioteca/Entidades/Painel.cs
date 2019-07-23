using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Painel
    {
        public int codigo { get; set; }
        public int nivel { get; set; }
        public int financeiro { get; set; }
        public int pedagogico { get; set; }
        public int marketing { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string email { get; set; }

        public Painel()
        {
            this.codigo = 0;
            this.nivel = 0;
            this.financeiro = 0;
            this.pedagogico = 0;
            this.marketing = 0;
            this.nome = "";
            this.login = "";
            this.senha = "";
            this.email = "";
        }

        public Painel(int id)
        {
            this.codigo = id;
        }

        public Painel(int codigo, int nivel, int financeiro, int pedagogico, int marketing, string nome, string login, string senha, string email)
        {
            this.codigo = codigo;
            this.nivel = nivel;
            this.financeiro = financeiro;
            this.pedagogico = pedagogico;
            this.marketing = marketing;
            this.nome = nome;
            this.login = login;
            this.senha = senha;
            this.email = email;
        }

        public void Salvar()
        {
            new PainelDB().Salvar(this);
        }

        public void Alterar()
        {
            new PainelDB().Alterar(this);
        }

        public void Excluir()
        {
            new PainelDB().Excluir(this);
        }
    }
}
