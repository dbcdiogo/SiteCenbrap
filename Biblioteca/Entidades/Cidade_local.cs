using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Cidade_local
    {
        public int codigo { get; set; }
        public Cidade cidade { get; set; }
        public int aula { get; set; }
        public int hospedagem { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string telefone1 { get; set; }
        public string link_google_maps { get; set; }
        public DateTime data { get; set; }
        public Painel painel { get; set; }

        public Cidade_local()
        {
            this.codigo = 0;
            this.cidade = new Cidade();
            this.aula = 0;
            this.hospedagem = 0;
            this.nome = "";
            this.endereco = "";
            this.email = "";
            this.telefone = "";
            this.telefone1 = "";
            this.link_google_maps = "";
            this.data = DateTime.Now;
            this.painel = new Painel();
        }

        public Cidade_local(int codigo, Cidade cidade, int aula, int hospedagem, string nome, string endereco, string email, string telefone, string telefone1, string link_google_maps, DateTime data, Painel painel)
        {
            this.codigo = codigo;
            this.cidade = cidade;
            this.aula = aula;
            this.hospedagem = hospedagem;
            this.nome = nome;
            this.endereco = endereco;
            this.email = email;
            this.telefone = telefone;
            this.telefone1 = telefone1;
            this.link_google_maps = link_google_maps;
            this.data = data;
            this.painel = painel;
        }

        public void Salvar()
        {
            new Cidade_localDB().Salvar(this);
        }

        public void Alterar()
        {
            new Cidade_localDB().Alterar(this);
        }

        public void Excluir()
        {
            new Cidade_localDB().Excluir(this);
        }
    }
}
