using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class PreSet
    {
        public int preset_id { get; set; }
        public Painel painel { get; set; }
        public DateTime data { get; set; }
        public bool ativo { get; set; }
        public string titulo { get; set; }

        public PreSet()
        {
            this.preset_id = 0;
            this.painel = new Painel();
            this.data = DateTime.Now;
            this.ativo = false;
            this.titulo = "";
        }

        public PreSet(int id)
        {
            this.preset_id = id;
            this.painel = new Painel();
            this.data = DateTime.Now;
            this.ativo = false;
            this.titulo = "";
        }

        public PreSet(int id, Painel painel, DateTime data, bool ativo, string titulo)
        {
            this.preset_id = id;
            this.painel = painel;
            this.data = data;
            this.ativo = ativo;
            this.titulo = titulo;
        }

        public void Salvar()
        {
            this.preset_id = new PreSetDB().Salvar(this.data, this.painel, this.ativo, this.titulo);
        }

        public void Alterar()
        {
            new PreSetDB().Alterar(this);
        }

        public void Excluir()
        {
            new PreSetDB().Excluir(this);
        }

    }
}
