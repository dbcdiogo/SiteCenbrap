using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Video
    {
        public int video_id { get; set; }
        public string codigo { get; set; }
        public string link { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string imagem { get; set; }
        public DateTime data { get; set; }
        public DateTime tempo { get; set; }
        public bool gratuito { get; set; }
        public int trailer_id { get; set; }
        public string tempo_assistido { get; set; }

        public bool exibir { get; set; }

        public List<Video_tags> tags { get; set; }
        public List<Autor> autores { get; set; }
        public List<Categoria> categorias { get; set; }

        public Video()
        {
            this.video_id = 0;
            this.codigo = "";
            this.link = "";
            this.titulo = "";
            this.descricao = "";
            this.imagem = "";
            this.data = Convert.ToDateTime("01/01/1900");
            this.tempo = Convert.ToDateTime("01/01/1900 00:00:00");
            this.gratuito = false;
            this.trailer_id = 0;
            this.tempo_assistido = "";
            this.exibir = true;

            this.tags = new List<Video_tags>();
            this.autores = new List<Autor>();
            this.categorias = new List<Categoria>();
        }

        public Video(int id)
        {
            this.video_id = id;
            this.codigo = "";
            this.tags = new List<Video_tags>();
            this.autores = new List<Autor>();
            this.categorias = new List<Categoria>();
            this.trailer_id = 0;
            this.exibir = true;
        }

        public Video(string codigo)
        {
            this.video_id = 0;
            this.codigo = codigo;
            this.tags = new List<Video_tags>();
            this.autores = new List<Autor>();
            this.categorias = new List<Categoria>();
            this.trailer_id = 0;
            this.exibir = true;
        }

        public Video(int id, string link, string titulo, string descricao, string imagem, DateTime data, DateTime tempo, bool gratuito, int trailer_id = 0, string codigo = "", bool exibir = true)
        {
            this.video_id = id;
            this.codigo = codigo;
            this.link = link;
            this.titulo = titulo;
            this.descricao = descricao;
            this.imagem = imagem;
            this.data = data;
            this.tempo = tempo;
            this.gratuito = gratuito;
            this.trailer_id = trailer_id;
            this.exibir = exibir;

            this.tags = new Video_tagsDB().Listar(id);
            this.autores = new List<Autor>();
            this.categorias = new List<Categoria>();
        }

        public void Salvar()
        {
            this.video_id = new VideoDB().SalvarRetornar(this);
        }

        public void Alterar()
        {
            new VideoDB().Alterar(this);
        }

        public void Excluir()
        {
            new VideoDB().Excluir(this);
        }

        public void Completar()
        {
            this.tags = new Video_tagsDB().Listar(this.video_id);
            this.autores = new AutorDB().Listar(this);
            this.categorias = new CategoriaDB().Listar(this);
            this.categorias = new CategoriaDB().Listar(this);
        }

        public void CompletarCategorias()
        {
            this.categorias = new CategoriaDB().Listar(this);
        }

        public string Categorias()
        {
            string retorno = "";

            foreach (var c in this.categorias)
            {
                if (retorno != "")
                    retorno += ", ";
                retorno += c.titulo;
            }

            return retorno;
        }

        public string Autores()
        {
            string retorno = "";

            foreach (var a in this.autores)
            {
                if (retorno != "")
                    retorno += ", ";
                retorno += a.nome;
            }

            return retorno;
        }

        public string Tags()
        {
            string retorno = "";

            foreach(var t in this.tags)
            {
                if (retorno != "")
                    retorno += ", ";
                retorno += t.tag;
            }

            return retorno;
        }
    }

    public class VideoView
    {
        public Video video { get; set; }
        public List<Video> trailers { get; set; }
        public List<Select> tags { get; set; }
        public List<Select> categorias { get; set; }
        public List<Select> autores { get; set; }

        public VideoView()
        {
            this.video = new Video();
            this.tags = new List<Select>();
            this.trailers = new List<Video>();
            this.categorias = new List<Select>();
            this.autores = new List<Select>();
        }

        public VideoView(int id)
        {
            VideoDB db = new VideoDB();
            this.video = new Video();
            if (id != 0)
            {
                this.video = db.Buscar(id);
            }
            this.tags = db.Tags(id);
            this.trailers = db.Trailers();
            this.categorias = db.Categorias(id);
            this.autores = db.Autores(id);
        }
    }

    public class VideoRelatorio
    {
        public string categoria { get; set; }
        public string video { get; set; }

        public VideoRelatorio()
        {
            this.categoria = "";
            this.video = "";
        }

        public VideoRelatorio(string categoria, string video)
        {
            this.categoria = categoria;
            this.video = video;
        }
    }
}
