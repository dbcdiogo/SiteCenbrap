using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Video_categoria
    {
        public Video video_id { get; set; }
        public Categoria categoria_id { get; set; }

        public Video_categoria()
        {
            this.video_id = new Video();
            this.categoria_id = new Categoria();
        }

        public Video_categoria(Video video, Categoria categoria)
        {
            this.video_id = video;
            this.categoria_id = categoria;
        }

        public void Salvar()
        {
            new Video_categoriaDB().Salvar(this);
        }

        public void Excluir()
        {
            new Video_categoriaDB().Excluir(this);
        }
    }
}
