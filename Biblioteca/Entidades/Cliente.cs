using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Cliente
    {
        public int codigo { get; set; }
        public Aluno aluno { get; set; }
        public Cliente_grupo grupo { get; set; }
        public Cliente_grupo_subgrupo subgrupo { get; set; }
        public int tipo { get; set; }
        public string nome { get; set; }
        public string contato { get; set; }
        public string cpf_cnpj { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string cod_municipio { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public int ativo { get; set; }
        public double desconto { get; set; }
        public string obs { get; set; }

        public Cliente()
        {
            this.codigo = 0;
            this.aluno = new Aluno() { codigo = 0 };
            this.grupo = new Cliente_grupo() { codigo = 0 };
            this.subgrupo = new Cliente_grupo_subgrupo() { codigo = 0 };
            this.tipo = 0;
            this.nome = "";
            this.contato = "";
            this.cpf_cnpj = "";
            this.endereco = "";
            this.bairro = "";
            this.cidade = "";
            this.estado = "";
            this.cep = "";
            this.telefone = "";
            this.celular = "";
            this.fax = "";
            this.email = "";
            this.cod_municipio = "";
            this.numero = "";
            this.complemento = "";
            this.ativo = 0;
            this.desconto = 0;
            this.obs = "";

        }

        public Cliente(int codigo, Aluno aluno, Cliente_grupo grupo, Cliente_grupo_subgrupo subgrupo, int tipo, string nome, string contato, string cpf_cnpj, string endereco, string bairro, string cidade, string estado, string cep, string telefone, string celular, string fax, string email, string cod_municipio, string numero, string complemento, int ativo, double desconto, string obs)
        {
            this.codigo = 0;
            this.aluno = new Aluno() { codigo = 0 };
            this.grupo = new Cliente_grupo() { codigo = 0 };
            this.subgrupo = new Cliente_grupo_subgrupo() { codigo = 0 };
            this.tipo = 0;
            this.nome = "";
            this.contato = "";
            this.cpf_cnpj = "";
            this.endereco = "";
            this.bairro = "";
            this.cidade = "";
            this.estado = "";
            this.cep = "";
            this.telefone = "";
            this.celular = "";
            this.fax = "";
            this.email = "";
            this.cod_municipio = "";
            this.numero = "";
            this.complemento = "";
            this.ativo = 0;
            this.desconto = 0;
            this.obs = "";
        }

        public Cliente(Aluno aluno, Curso curso)
        {
            Cliente_grupo cliente_grupo = new Cliente_grupoDB().Buscar(curso.titulo1);

            if(cliente_grupo != null)
            {
                this.codigo = new ClienteDB().Buscar(aluno.cpf, cliente_grupo);
                if (this.codigo == 0)
                {
                    this.codigo = 0;
                    this.aluno = aluno;
                    this.grupo = cliente_grupo;
                    this.subgrupo = new Cliente_grupo_subgrupo() { codigo = 0 };
                    this.tipo = 0;
                    this.nome = aluno.nome;
                    this.contato = aluno.nome;
                    this.cpf_cnpj = aluno.cpf.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
                    this.endereco = aluno.endereco;
                    this.bairro = aluno.bairro;
                    this.cidade = aluno.cidade;
                    this.estado = aluno.estado;
                    this.cep = aluno.cep;
                    this.telefone = aluno.telefone;
                    this.celular = aluno.cep;
                    this.fax = "";
                    this.email = aluno.email;
                    this.cod_municipio = new MunicipioDB().Buscar(aluno.cidade, aluno.estado).ToString();
                    this.numero = "";
                    this.complemento = "";
                    this.ativo = 1;
                    this.desconto = 0;
                    this.obs = "";

                    new ClienteDB().Salvar(this);
                    this.codigo = new ClienteDB().Buscar(this.cpf_cnpj, this.grupo);
                }
            }
        }
    }
}
