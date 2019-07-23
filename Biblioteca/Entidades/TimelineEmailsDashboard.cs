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
    public class TimelineEmailsDashboard
    {
        public string email { get; set; }
        public int total { get; set; }
        public DateTime data { get; set; }
        public int limite { get; set; }

        public TimelineEmailsDashboard()
        {
            this.email = email;
            this.total = total;
            this.data = data;
            this.limite = limite;
        }

    }
}
