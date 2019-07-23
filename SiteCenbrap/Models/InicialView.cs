using Biblioteca.DB;
using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCenbrap.Models
{
    public class InicialView
    {
        public List<Valor> cidades { get; set; }
        public List<Cursos> posgraduacoes { get; set; }
        public List<Cursos> workshops { get; set; }
        public List<Cursos> eads { get; set; }
        public List<Depoimento> depoimentos { get; set; }
        public List<ProximasAulas> proximasAulas { get; set; }
        public List<Noticia> noticias { get; set; }
        public List<Banners> banners { get; set; }

        public InicialView()
        {
            CursoDB db = new CursoDB();

            this.cidades = new List<Valor>();
            this.cidades = db.Cidades();

            this.posgraduacoes = new List<Cursos>();
            this.posgraduacoes = db.TituloCursos(TipoCurso.PosGraduacao, 100);

            this.workshops = new List<Cursos>();
            this.workshops = db.TituloCursos(TipoCurso.WorkShop, 100);

            this.eads = new List<Cursos>();
            this.eads = db.TituloCursos(TipoCurso.EaD, 100);
            
            this.depoimentos = new List<Depoimento>();
            this.depoimentos = new DepoimentoDB().Listar("cenbrap.com.br");

            this.proximasAulas = new List<ProximasAulas>();
            this.proximasAulas = new EncontroDB().ProximasAulas(4);

            this.noticias = new List<Noticia>();
            this.noticias = new NoticiaDB().Listar("cenbrap.com.br", 4);

            this.banners = new BannersDB().ListarBanners(1);
        }
    }
}