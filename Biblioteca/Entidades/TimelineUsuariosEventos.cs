using Biblioteca.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Biblioteca.Entidades
{
    public class TimelineUsuariosEventos
    {
        public DateTime data { get; set; }
        public string curso { get; set; }
        public string aluno { get; set; }
        public int tipo { get; set; }
        public string tipo_evento { get; set; }
        public string titulo { get; set; }
        public string texto { get; set; }
        public TimelineEventosUsuario evento_usuario { get; set; }
        public List<TimelineTarefasItens> evento_tarefa { get; set; }

        public TimelineUsuariosEventos()
        {
            this.data = Convert.ToDateTime("01/01/1900");
            this.curso = "";
            this.aluno = "";
            this.tipo = 0;
            this.tipo_evento = "";
            this.titulo = "";
            this.texto = "";
        }

        public TimelineUsuariosEventos(DateTime data, string curso, string aluno, int tipo, string tipo_evento, string titulo, string texto)
        {
            this.data = data;
            this.curso = curso;
            this.aluno = aluno;
            this.tipo = tipo;
            this.tipo_evento = tipo_evento;
            this.titulo = titulo;
            this.texto = texto;
        }

        public TimelineUsuariosEventos(DateTime data, string curso, string aluno, int tipo, string tipo_evento, string titulo, string texto, int idevento, DateTime data_tarefa, DateTime data_deadline, DateTime data_inicio, DateTime data_fim, int usuario)
        {
            this.data = data;
            this.curso = curso;
            this.aluno = aluno;
            this.tipo = tipo;
            this.tipo_evento = tipo_evento;
            this.titulo = titulo;
            this.texto = texto;
            this.evento_usuario = new TimelineEventosUsuario();
            evento_usuario.idevento = idevento;
            evento_usuario.fltipo = tipo_evento;
            evento_usuario.dttarefa = data_tarefa;
            evento_usuario.dtdeadline = data_deadline;
            evento_usuario.dteventoini = data_inicio;
            evento_usuario.dteventofim = data_fim;
            evento_usuario.usuario = new TimelineUsuariosDB().Buscar(usuario);
            string path = HttpContext.Current.Server.MapPath("~/Anexos/" + idevento);
            if (Directory.Exists(path))
            {
                evento_usuario.anexos = Directory.GetFiles(path).Select(file => Path.GetFileName(file)).ToArray();
            }
            this.evento_tarefa = new TimelineTarefasDB().ListarTarefas(idevento);
        }
    }
}
