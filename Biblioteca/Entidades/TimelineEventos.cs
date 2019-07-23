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
    public class TimelineEventos
    {
        public DateTime data { get; set; }
        public int tipo { get; set; }
        public int usuario { get; set; }
        public string titulo { get; set; }
        public string texto { get; set; }
        public Aluno_curso aluno_curso { get; set; }
        public CampanhasEnviados campanha { get; set; }
        public List<Aluno_Email> aluno_email { get; set; }
        public TimelineEventosUsuario evento_usuario { get; set; }
        public List<TimelineTarefasItens> evento_tarefa { get; set; }
        public int ativo { get; set; }
        public TimelineUsuarios perfil_usuario { get; set; }
        public int anterior { get; set; }

        public TimelineEventos()
        {
            this.data = Convert.ToDateTime("01/01/1900");
            this.tipo = 0;
            this.usuario = 0;
            this.titulo = "";
            this.texto = "";
            this.aluno_curso = new Aluno_curso();
            this.campanha = new CampanhasEnviados();
            this.evento_usuario = new TimelineEventosUsuario();
            this.evento_tarefa = null;
            this.ativo = 1;
            this.perfil_usuario = null;
            this.anterior = anterior;
        }

        public TimelineEventos(DateTime data, int tipo, int usuario, string titulo, string texto)
        {
            this.data = data;
            this.tipo = tipo;
            this.usuario = usuario;
            this.titulo = titulo;
            this.texto = texto;
            this.aluno_curso = null;
            if (tipo == 6)
            {
                this.campanha = new CampanhasDB().BuscarDadosSemLink(usuario);
            }
            if (tipo == 8)
            {
                this.perfil_usuario = new TimelineUsuariosDB().Buscar(usuario);
            }
        }

        public TimelineEventos(DateTime data, int tipo, int usuario, string titulo, string texto, int ativo)
        {
            this.data = data;
            this.tipo = tipo;
            this.usuario = usuario;
            this.titulo = titulo;
            this.texto = texto;
            this.aluno_curso = null;
            this.ativo = ativo;
            if (tipo == 6)
            {
                this.campanha = new CampanhasDB().BuscarDados(usuario);
            }            
        }

        public TimelineEventos(DateTime data, int tipo, int usuario, string titulo, string texto, string fltipo, int idevento, DateTime data_tarefa, DateTime data_deadline, DateTime data_inicio, DateTime data_fim)
        {
            this.data = data;
            this.tipo = tipo;
            this.usuario = usuario;
            this.titulo = titulo;
            this.texto = texto;
            this.evento_usuario = new TimelineEventosUsuario();
            evento_usuario.idevento = idevento;
            evento_usuario.fltipo = fltipo;
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

            if (tipo == 7)
            {
                this.evento_tarefa = new TimelineTarefasDB().ListarTarefas(idevento);
            }
        }

        public TimelineEventos(DateTime data, int tipo, int usuario, string titulo, string texto, string fltipo, int idevento, DateTime data_tarefa, DateTime data_deadline, DateTime data_inicio, DateTime data_fim, int flinvestimento, Decimal vlinvestimento, int idtipoinvestimento)
        {
            this.data = data;
            this.tipo = tipo;
            this.usuario = usuario;
            this.titulo = titulo;
            this.texto = texto;
            this.evento_usuario = new TimelineEventosUsuario();
            evento_usuario.idevento = idevento;
            evento_usuario.fltipo = fltipo;
            evento_usuario.dttarefa = data_tarefa;
            evento_usuario.dtdeadline = data_deadline;
            evento_usuario.dteventoini = data_inicio;
            evento_usuario.dteventofim = data_fim;
            evento_usuario.flinvestimento = flinvestimento;
            evento_usuario.vlinvestimento = vlinvestimento;
            evento_usuario.idtipoinvestimento = idtipoinvestimento;
            evento_usuario.usuario = new TimelineUsuariosDB().Buscar(usuario);
            string path = HttpContext.Current.Server.MapPath("~/Anexos/" + idevento);
            if (Directory.Exists(path))
            {
                evento_usuario.anexos = Directory.GetFiles(path).Select(file => Path.GetFileName(file)).ToArray();
            }

            if (tipo == 7)
            {
                this.evento_tarefa = new TimelineTarefasDB().ListarTarefas(idevento);
            }
        }

        public TimelineEventos(DateTime data, int tipo, int usuario, string titulo, string texto, string fltipo, int idevento, DateTime data_tarefa, DateTime data_deadline, DateTime data_inicio, DateTime data_fim, int ativo)
        {
            this.data = data;
            this.tipo = tipo;
            this.usuario = usuario;
            this.titulo = titulo;
            this.texto = texto;
            this.ativo = ativo;
            this.evento_usuario = new TimelineEventosUsuario();
            evento_usuario.idevento = idevento;
            evento_usuario.fltipo = fltipo;
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

            if (tipo == 7)
            {
                this.evento_tarefa = new TimelineTarefasDB().ListarTarefas(idevento);
            }

        }

        public TimelineEventos(DateTime data, int tipo, int usuario, int aluno_curso)
        {
            this.data = data;
            this.tipo = tipo;
            this.usuario = usuario;
            this.aluno_curso = new Aluno_cursoDB().BuscarResumido(aluno_curso);
            this.texto = Convert.ToString(this.aluno_curso.situacao);
            this.titulo = Convert.ToString(this.aluno_curso.nome_aluno);
        }

        public TimelineEventos(DateTime data, int tipo, int aluno_curso)
        {
            this.data = data;
            this.tipo = 5;
            this.usuario = 0;
            this.aluno_curso = new Aluno_cursoDB().BuscarResumido(aluno_curso);
            this.titulo = Convert.ToString(tipo);
        }

        public TimelineEventos(DateTime data, int tipo, int aluno_curso, int usuario, int anterior)
        {
            this.data = data;
            this.tipo = 5;
            this.usuario = usuario;
            this.aluno_curso = new Aluno_cursoDB().BuscarResumido(aluno_curso);
            this.titulo = Convert.ToString(tipo);
            this.anterior = anterior;
        }
    }

    public class TimelineEventosUsuario
    {
        public string fltipo { get; set; }
        public int idevento { get; set; }
        public TimelineUsuarios usuario { get; set; }
        public string[] anexos { get; set; }
        public DateTime dttarefa { get; set; }
        public DateTime dtdeadline { get; set; }
        public DateTime dteventoini { get; set; }
        public DateTime dteventofim { get; set; }
        public int flinvestimento { get; set; }
        public Decimal vlinvestimento { get; set; }
        public int idtipoinvestimento { get; set; }

        public TimelineEventosUsuario()
        {
            this.idevento = 0;
            this.fltipo = "I";
            this.usuario = null;
            this.anexos = new string[] { };
            this.dttarefa = Convert.ToDateTime("01/01/1900");
            this.dtdeadline = Convert.ToDateTime("01/01/1900");
            this.dteventoini = Convert.ToDateTime("01/01/1900");
            this.dteventofim = Convert.ToDateTime("01/01/1900");
            this.flinvestimento = 0;
            this.vlinvestimento = 0;
            this.idtipoinvestimento = 0;

        }

    }

    public class TimelineEventosTurma
    {
        public DateTime data_reserva { get; set; }
        public DateTime data_matricula { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_confirmado { get; set; }
        public DateTime data_lista_espera { get; set; }

        public TimelineEventosTurma()
        {
            this.data_reserva = Convert.ToDateTime("01/01/1900");
            this.data_matricula = Convert.ToDateTime("01/01/1900");
            this.data_inicio = Convert.ToDateTime("01/01/1900");
            this.data_confirmado = Convert.ToDateTime("01/01/1900");
            this.data_lista_espera = Convert.ToDateTime("01/01/1900");
        }

        public TimelineEventosTurma(DateTime data_reserva, DateTime data_matricula, DateTime data_inicio, DateTime data_confirmado, DateTime data_lista_espera)
        {
            this.data_reserva = data_reserva;
            this.data_matricula = data_matricula;
            this.data_inicio = data_inicio;
            this.data_confirmado = data_confirmado;
            this.data_lista_espera = data_lista_espera;
        }
    }

    public class Aluno_Email {

        public string campanha { get; set; }
        public string recebido { get; set; }
        public string aberto { get; set; }
        public string clicado { get; set; }

        public Aluno_Email(string campanha, string recebido, string aberto, string clicado)
        {
            this.campanha = campanha;
            this.recebido = recebido;
            this.aberto = aberto;
            this.clicado = clicado;
        }
    }

    public class HomeViewAlertasLista
    {
        public int iditem { get; set; }
        public string txtitulo { get; set; }
        public DateTime dtdeadline { get; set; }
        public string txitem { get; set; }
        public string curso { get; set; }
        public int idevento { get; set; }
        public TimelineUsuarios usuario { get; set; }
        public int visualizado { get; set; }
        public string tipo { get; set; }

        public HomeViewAlertasLista(int iditem, string txtitulo, DateTime dtdeadline, string txitem, string curso, int idevento, int idusuario, int visualizado, string tipo)
        {
            this.iditem = iditem;
            this.txtitulo = txtitulo;
            this.dtdeadline = dtdeadline;
            this.txitem = txitem;
            this.curso = curso;
            this.idevento = idevento;
            this.usuario = new TimelineUsuariosDB().Buscar(idusuario);
            this.visualizado = visualizado;
            this.tipo = tipo;
        }
    }
}
