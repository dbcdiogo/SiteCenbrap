using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Equipamento
    {
        public int codigo { get; set; }
        public string titulo { get; set; }
        public string imagem { get; set; }

        public Equipamento()
        {
            this.codigo = 0;
            this.titulo = "";
            this.imagem = "";
        }

        public Equipamento(int codigo, string titulo, string imagem)
        {
            this.codigo = codigo;
            this.titulo = titulo;
            this.imagem = imagem;
        }

        public void Salvar()
        {
            new EquipamentoDB().Salvar(this);
        }

        public void Alterar()
        {
            new EquipamentoDB().Alterar(this);
        }

        public void Excluir()
        {
            new EquipamentoDB().Excluir(this);
        }
    }
}
