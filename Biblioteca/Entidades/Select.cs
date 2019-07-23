using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Select
    {
        public string value { get; set; }
        public string text { get; set; }
        public bool selected { get; set; }

        public Select()
        {
            this.value = "";
            this.text = "";
            this.selected = false;
        }

        public Select(string value, string text, bool selected)
        {
            this.value = value;
            this.text = text;
            this.selected = selected;
        }
    }
}
