using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class CupomDesconto
    {
        public int cupomDesconto_id { get; set; }
        public string cupom { get; set; }
        public DateTime data { get; set; }
        public string ip { get; set; }

        public int qtdUtilizado { get; set; }
        public int qtdEnviado { get; set; }
        public int qtdConcluido { get; set; }

        public CupomDesconto()
        {
            this.cupomDesconto_id = 0;
            this.cupom = "";
            this.data = DateTime.Now;
            this.ip = "";
            this.qtdUtilizado = 0;
            this.qtdConcluido = 0;
            this.qtdEnviado = 0;
        }

        public CupomDesconto(int id)
        {
            this.cupomDesconto_id = id;
            this.cupom = "";
            this.data = DateTime.Now;
            this.ip = "";
            this.qtdUtilizado = 0;
            this.qtdEnviado = 0;
            this.qtdConcluido = 0;
        }

        public CupomDesconto(int cupomDesconto_id, string cupom, DateTime data, string ip, int qtdUtilizado = 0, int qtdConcluido = 0, int qtdEnviado = 0)
        {
            this.cupomDesconto_id = cupomDesconto_id;
            this.cupom = cupom;
            this.data = data;
            this.ip = ip;
            this.qtdUtilizado = qtdUtilizado;
            this.qtdEnviado = qtdEnviado;
            this.qtdConcluido = qtdConcluido;

        }

        public CupomDesconto(DateTime data, string ip)
        {
            CupomDescontoDB db = new CupomDescontoDB();
            this.data = data;
            this.ip = ip;
            this.cupom = "";
            this.qtdUtilizado = 0;
            this.qtdEnviado = 0;
            this.qtdConcluido = 0;
            this.cupomDesconto_id = db.SalvarRetornar(this);
            bool sair = true;
            for (int i = 0; sair; i++)
            {
                this.cupom = Gerar(this.cupomDesconto_id, this.data, i);

                //se não existe sai do loop
                sair = db.Existe(this.cupom);
            }
            
            Alterar();
        }

        public CupomDesconto(DateTime data, string cupom, string ip)
        {
            CupomDescontoDB db = new CupomDescontoDB();
            this.data = data;
            this.ip = ip;
            this.cupom = "";
            this.qtdUtilizado = 0;
            this.qtdEnviado = 0;
            this.qtdConcluido = 0;
            this.cupomDesconto_id = db.SalvarRetornar(this);
            bool sair = true;
            for (int i = 0; sair; i++)
            {
                if (i > 0)
                    this.cupom = cupom + "" + i;
                else
                    this.cupom = cupom;

                //se não existe sai do loop
                sair = db.Existe(this.cupom);
            }

            Alterar();
        }

        public string Gerar(int id, DateTime date, int cont)
        {
            MD5 md5 = MD5.Create();
            
            string data = date.ToString().Replace("/", "C" + id.ToString() + cont.ToString()).Replace(" ", "B" + id.ToString() + cont.ToString()).Replace(":", "PO" + id.ToString() + cont.ToString());

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(data);
            byte[] hash = md5.ComputeHash(inputBytes);


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            string s_hash = sb.ToString();

            string s_retorno = string.Join("", s_hash.ToCharArray().Where(Char.IsDigit));

            return s_retorno.Substring(0, 6);
        }


        public void Salvar()
        {
            this.cupomDesconto_id = new CupomDescontoDB().SalvarRetornar(this);
        }

        public void Alterar()
        {
            new CupomDescontoDB().Alterar(this);
        }

        public void Excluir()
        {
            new CupomDescontoDB().Excluir(this);
        }
    }

    public class CupomDesconto_utilizacao
    {
        public int cupomDesconto_utilizacao_id { get; set; }
        public CupomDesconto cupomDesconto_id { get; set; }
        public Aluno aluno { get; set; }
        public DateTime data { get; set; }
        public int curso { get; set; }
        public string titulo_curso { get; set; }

        public CupomDesconto_utilizacao()
        {
            this.cupomDesconto_utilizacao_id = 0;
            this.cupomDesconto_id = new CupomDesconto();
            this.aluno = new Aluno();
            this.data = DateTime.Now;
            this.curso = 0;
            this.titulo_curso = "";
        }

        public CupomDesconto_utilizacao(int id)
        {
            this.cupomDesconto_utilizacao_id = id;
            this.cupomDesconto_id = new CupomDesconto();
            this.aluno = new Aluno();
            this.data = DateTime.Now;
            this.curso = 0;
        }

        public CupomDesconto_utilizacao(int cupomDesconto_utilizacao_id, CupomDesconto cupomDesconto_id, Aluno aluno, DateTime data)
        {
            this.cupomDesconto_utilizacao_id = cupomDesconto_utilizacao_id;
            this.cupomDesconto_id = cupomDesconto_id;
            this.aluno = aluno;
            this.data = data;
            this.curso = 0;
        }

        public CupomDesconto_utilizacao(int cupomDesconto_utilizacao_id, CupomDesconto cupomDesconto_id, Aluno aluno, DateTime data, int curso)
        {
            this.cupomDesconto_utilizacao_id = cupomDesconto_utilizacao_id;
            this.cupomDesconto_id = cupomDesconto_id;
            this.aluno = aluno;
            this.data = data;
            this.curso = curso;
            if (curso > 0)
            {
                this.titulo_curso = new CursoDB().BuscarNomeCurso(curso);
            }
        }

        public void Salvar()
        {
            this.cupomDesconto_utilizacao_id = new CupomDesconto_utilizacaoDB().SalvarRetornar(this);
        }

        public void Excluir()
        {
            new CupomDesconto_utilizacaoDB().Excluir(this);
        }
    }

    public class CupomAluno
    {
        public int aluno { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string cupom { get; set; }

        public CupomAluno(int aluno, string nome, string email, string cupom)
        {
            this.aluno = aluno;
            this.nome = nome;
            this.email = email;
            this.cupom = cupom;
        }
    }
}
