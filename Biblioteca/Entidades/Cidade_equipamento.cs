using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Cidade_equipamento
    {
        public int codigo { get; set; }
        public Cidade cidade { get; set; }
        public Equipamento equipamento { get; set; }
        public string descricao { get; set; }
        public DateTime data { get; set; }
        public Painel painel { get; set; }

        public Cidade_equipamento()
        {
            this.codigo = 0;
            this.cidade = new Cidade();
            this.equipamento = new Equipamento();
            this.descricao = "";
            this.data = DateTime.Now;
            this.painel = new Painel();
        }

        public Cidade_equipamento(int codigo, Cidade cidade, Equipamento equipamento, string descricao, DateTime data, Painel painel)
        {
            this.codigo = codigo;
            this.cidade = cidade;
            this.equipamento = equipamento;
            this.descricao = descricao;
            this.data = data;
            this.painel = painel;
        }

        public void Salvar()
        {
            new Cidade_equipamentoDB().Salvar(this);
        }

        public void Alterar()
        {
            new Cidade_equipamentoDB().Alterar(this);
        }

        public void Excluir()
        {
            new Cidade_equipamentoDB().Excluir(this);
        }
    }
}
