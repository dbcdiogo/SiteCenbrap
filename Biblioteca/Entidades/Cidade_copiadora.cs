using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Cidade_copiadora
    {
        public int codigo { get; set; }
        public Cidade cidade { get; set; }
        public string responsavel { get; set; }
        public string email { get; set; }
        public string email1 { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        public string telefone1 { get; set; }
        public string link_google_maps { get; set; }
        public DateTime data { get; set; }
        public Painel painel { get; set; }

        public Cidade_copiadora()
        {
            this.codigo = 0;
            this.cidade = new Cidade();
            this.responsavel = "";
            this.email = "";
            this.email1 = "";
            this.nome = "";
            this.endereco = "";
            this.telefone = "";
            this.telefone1 = "";
            this.link_google_maps = "";
            this.data = DateTime.Now;
            this.painel = new Painel();
        }

        public Cidade_copiadora(int codigo, Cidade cidade, string responsavel, string email, string email1, string nome, string endereco, string telefone, string telefone1, string link_google_maps, DateTime data, Painel painel)
        {
            this.codigo = codigo;
            this.cidade = cidade;
            this.responsavel = responsavel;
            this.email = email;
            this.email1 = email1;
            this.nome = nome;
            this.endereco = endereco;
            this.telefone = telefone;
            this.telefone1 = telefone1;
            this.link_google_maps = link_google_maps;
            this.data = data;
            this.painel = painel;
        }

        public void Salvar()
        {
            new Cidade_copiadoraDB().Salvar(this);
        }

        public void Alterar()
        {
            new Cidade_copiadoraDB().Alterar(this);
        }

        public void Excluir()
        {
            new Cidade_copiadoraDB().Excluir(this);
        }
    }
}
