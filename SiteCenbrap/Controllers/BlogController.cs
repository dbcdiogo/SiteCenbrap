using Biblioteca.DB;
using Biblioteca.Entidades;
using Biblioteca.Filters;
using SiteCenbrap.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteCenbrap.Controllers
{
    public class BlogController : OrigemController
    {
        // GET: Blog
        [Compress]
        [Route("Blog/")]
        public ActionResult Index(string categoria = "", string busca = "")
        {
            if (categoria == "")
            {
                ViewBag.nomecategoria = "Novidades";
            }
            else
            {
                ViewBag.nomecategoria = categoria;
            }
            return View(new ListBlogView(categoria, busca));
        }

        // GET: Blog
        
        [Route("Blog/{tituloUrl}")]
        public ActionResult Blog(string tituloUrl = "")
        {
            BlogView b = new BlogView(tituloUrl);
            

            if (b.blog != null)
            {
                ViewBag.description = b.blog.subtitulo;
                return View(b);
            }
            else
                return RedirectToAction("Index");
        }

        [Compress]
        [Route("Blog/Img/{id}/")]
        public ActionResult Img(int id, int tamanho = 500)
        {
            Blog b = new BlogDB().Buscar(id);
            if (b != null)
            {
                var path = Path.Combine(b.imagem);

                if (System.IO.File.Exists(path))
                {
                    Image i = Image.FromFile(path);
                    return new ImageResult(i, tamanho);
                }
                else
                {
                    return base.File(Path.Combine(Server.MapPath("/Images"), "transparente.png"), "image/png");
                }

            }
            else
            {
                return base.File(Path.Combine(Server.MapPath("/Images"), "transparente.png"), "image/png");
            }
        }
    }
}