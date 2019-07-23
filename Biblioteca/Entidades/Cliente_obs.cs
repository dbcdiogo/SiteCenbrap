using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Cliente_obs
    {
        public int cliente_obs_id { get; set; }
        public Cliente cliente { get; set; }
        public Painel painel { get; set; }
        public DateTime data { get; set; }
        public string obs { get; set; }

        public Cliente_obs()
        {
            this.cliente_obs_id = 0;
            this.cliente = new Cliente() { codigo = 0 };
            this.painel = new Painel() { codigo = 0 };
            this.data = DateTime.Now;
            this.obs = "";
        }

        public Cliente_obs(int cliente_obs_id, Cliente cliente, Painel painel, DateTime data, string obs)
        {
            this.cliente_obs_id = cliente_obs_id;
            this.cliente = cliente;
            this.painel = painel;
            this.data = data;
            this.obs = obs;
        }

    }
}
