using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Video_tags
    {
        public Video video_id { get; set; }
        public string tag { get; set; }

        public Video_tags()
        {
            this.video_id = new Video();
            this.tag = "";
        }

        public Video_tags(Video video, string tag)
        {
            this.video_id = video;
            this.tag = tag;
        }

        public void Salvar()
        {
            new Video_tagsDB().Salvar(this);
        }

        public void Excluir()
        {
            new Video_tagsDB().Excluir(this);
        }
    }
}
