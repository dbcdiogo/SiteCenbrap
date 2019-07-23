using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Aluno_video
    {
        public Aluno aluno { get; set; }
        public Video video_id { get; set; }
        public DateTime data { get; set; }
        public string tempo { get; set; }

        public Aluno_video()
        {
            this.aluno = new Aluno();
            this.video_id = new Video();
            this.data = Convert.ToDateTime("01/01/1900");
            this.tempo = "";
        }

        public Aluno_video(Aluno aluno, Video video, DateTime data)
        {
            this.aluno = aluno;
            this.video_id = video;
            this.data = data;
        }

        public void Salvar()
        {
            new Aluno_videoDB().Salvar(this);
        }

        public void VerificaSeExiste()
        {
            new Aluno_videoDB().Salvar(this);
        }

        public void Excluir()
        {
            new Aluno_videoDB().Excluir(this);
        }
    }
}
