using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class PreSet_acionador
    {
        public int preset_acionador_id { get; set; }
        public PreSet preset_id { get; set; }
        public string tabela { get; set; }
        public bool inclusao { get; set; }
        public bool alteracao { get; set; }
        public string alteracao_campo { get; set; }
        public string alteracao_campo_valor { get; set; }

        public PreSet_acionador()
        {
            this.preset_acionador_id = 0;
            this.preset_id = new PreSet();
            this.tabela = "";
            this.inclusao = false;
            this.alteracao = false;
            this.alteracao_campo = "";
            this.alteracao_campo_valor = "";
        }

        public PreSet_acionador(int id)
        {
            this.preset_acionador_id = id;
            this.preset_id = new PreSet();
            this.tabela = "";
            this.inclusao = false;
            this.alteracao = false;
            this.alteracao_campo = "";
            this.alteracao_campo_valor = "";
        }


        public PreSet_acionador(int id, PreSet preset, string tabela, bool inclusao, bool alteracao, string alteracao_campo, string alteracao_campo_valor)
        {
            this.preset_acionador_id = id;
            this.preset_id = preset;
            this.tabela = tabela;
            this.inclusao = inclusao;
            this.alteracao = alteracao;
            this.alteracao_campo = alteracao_campo;
            this.alteracao_campo_valor = alteracao_campo_valor;
        }

        public void Salvar()
        {
            this.preset_acionador_id = new PreSet_acionadorDB().Salvar(this.preset_id, this.tabela, this.inclusao, this.alteracao, this.alteracao_campo, this.alteracao_campo_valor);
        }

        public void Alterar()
        {
            new PreSet_acionadorDB().Alterar(this);
        }

        public void Excluir()
        {
            new PreSet_acionadorDB().Excluir(this);
        }
    }
}
