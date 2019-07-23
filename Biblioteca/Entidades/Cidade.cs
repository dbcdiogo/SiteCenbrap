using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Cidade
    {
        //cidade,estado,obs,data,painel
        public int codigo { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string obs { get; set; }
        public DateTime data { get; set; }
        public Painel painel { get; set; }
        public string local { get; set; }
        public string link { get; set; }

        public Cidade()
        {
            this.codigo = 0;
            this.cidade = "";
            this.estado = "";
            this.obs = "";
            this.data = DateTime.Now;
            this.painel = new Painel();
            this.local = "";
            this.link = "";
        }

        public Cidade(int codigo, string cidade, string estado, string obs, DateTime data, Painel painel, string local = "", string link = "")
        {
            this.codigo = codigo;
            this.cidade = cidade;
            this.estado = estado;
            this.obs = obs;
            this.data = data;
            this.painel = painel;
            this.local = local;
            this.link = link;
        }

        public void Salvar()
        {
            new CidadeDB().Salvar(this);
        }

        public void Alterar()
        {
            new CidadeDB().Alterar(this);
        }

        public void Excluir()
        {
            new CidadeDB().Excluir(this);
        }

    }

    public class CidadeString
    {
        public string value { get; set; } = "";
        public string cidade { get; set; } = "";

        public CidadeString(string value, string cidade)
        {
            this.value = value;
            this.cidade = cidade;
        }
    }
}
