using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Biblioteca.Entidades
{
    public class Mensagens
    {
        public int idmensagem { get; set; }
        public string titulo { get; set; }
        public string identificador { get; set; }
        [AllowHtml]
        public string texto { get; set; }
        public string txjson { get; set; }
        public Nullable<DateTime> dtenvio { get; set; }
        public MensagensCategoria idcategoria { get; set; }

        public Mensagens()
        {
            this.idmensagem = 0;
            this.titulo = "";
            this.identificador = "";
            this.texto = "";
            this.txjson = "";
            this.dtenvio = null;
            this.idcategoria = null;
        }

        public Mensagens(int id)
        {
            this.idmensagem = id;
            this.titulo = "";
            this.identificador = "";
            this.texto = "";
            this.txjson = "";
            this.dtenvio = null;
            this.idcategoria = null;
        }

        public Mensagens(int id, string titulo, string texto, string json, string identificador, int idcategoria)
        {
            this.idmensagem = id;
            this.titulo = titulo;
            this.identificador = identificador;
            this.texto = texto;
            this.txjson = json;
            this.idcategoria = new MensagensDB().BuscaCategoria(idcategoria);
        }

        public Mensagens(int id, string titulo, Nullable<DateTime> dtenvio, string identificador, int idcategoria)
        {
            this.idmensagem = id;
            this.titulo = titulo;
            this.identificador = identificador;
            this.dtenvio = dtenvio;
            this.idcategoria = new MensagensDB().BuscaCategoria(idcategoria);
        }

        public Mensagens(int id, string titulo, string texto, string json, Nullable<DateTime> dtenvio, string identificador, int idcategoria)
        {
            this.idmensagem = id;
            this.titulo = titulo;
            this.identificador = identificador;
            this.texto = texto;
            this.txjson = json;
            this.dtenvio = dtenvio;
            this.idcategoria = new MensagensDB().BuscaCategoria(idcategoria); 
        }

        public Mensagens(int id, Nullable<DateTime> dtenvio, string identificador)
        {
            this.idmensagem = id;
            this.identificador = identificador;
            this.dtenvio = dtenvio;
        }
    }

    public class MensagensTemplate
    {
        public int idtemplate { get; set; }
        public string txtemplate { get; set; }
        [AllowHtml]
        public string txhtml { get; set; }
        public string txjson { get; set; }
        public bool flpadrao { get; set; }

        public MensagensTemplate(int idtemplate, string txtemplate, string txhtml, bool flpadrao, string txjson)
        {
            this.idtemplate = idtemplate;
            this.txtemplate = txtemplate;
            this.txhtml = txhtml;
            this.flpadrao = flpadrao;
            this.txjson = txjson;
        }
    }

    public class MensagensCategoria
    {
        public int idcategoria { get; set; }
        public string txcategoria { get; set; }

        public MensagensCategoria(int idcategoria, string txcategoria)
        {
            this.idcategoria = idcategoria;
            this.txcategoria = txcategoria;
        }
    }
}
