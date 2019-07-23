using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Video_autor
    {
        public Video video_id { get; set; }
        public Autor autor_id { get; set; }

        public Video_autor()
        {
            this.video_id = new Video();
            this.autor_id = new Autor();
        }

        public Video_autor(Video video, Autor autor)
        {
            this.video_id = video;
            this.autor_id = autor;
        }

        public void Salvar()
        {
            new Video_autorDB().Salvar(this);
        }

        public void Excluir()
        {
            new Video_autorDB().Excluir(this);
        }
    }
}
