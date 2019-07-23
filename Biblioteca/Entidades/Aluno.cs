using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DB;

namespace Biblioteca.Entidades
{
    public class Aluno
    {
        public int codigo { get; set; }
        public DateTime data { get; set; }
        public Painel painel { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public int convenio { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime data_nascimento { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string ddd { get; set; }
        public string telefone { get; set; }
        public string ddd_celular { get; set; }
        public string celular { get; set; }
        public string formacao { get; set; }
        public string graduacao { get; set; }
        public string instituicao { get; set; }
        public string profissao { get; set; }
        public string local_trabalho { get; set; }
        public string obs { get; set; }
        public string conheceu { get; set; }
        public string rg { get; set; }
        public string rg_emissor { get; set; }
        public int rg_2via { get; set; }
        public string formacao_data { get; set; }
        public string formacao_titulo { get; set; }
        public string formacao_instituicao { get; set; }
        public string titulo_monografia { get; set; }
        public int envio_email { get; set; }
        public string sexo { get; set; }
        public string recado_telefone { get; set; }
        public string recado_nome { get; set; }
        public int email_autoriza { get; set; }
        public string email_apoio { get; set; }
        public int pne { get; set; }
        public string pne_qual { get; set; }
        public string nome_cracha { get; set; }
        public string nacionalidade { get; set; }
        public bool bloqueio { get; set; }
        public int idprofissao { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public int flcorrecao { get; set; }

        public Aluno()
        {
            this.codigo = 0;
            this.data = DateTime.Now;
            this.painel = new Painel() { codigo = 0 };
            this.nome = "";
            this.cpf = "";
            this.convenio = 0;
            this.email = "";
            this.senha = "";
            this.data_nascimento = DateTime.Now.AddYears(-30);
            this.endereco = "";
            this.bairro = "";
            this.cidade = "";
            this.estado = "";
            this.cep = "";
            this.ddd = "";
            this.telefone = "";
            this.ddd_celular = "";
            this.celular = "";
            this.formacao = "";
            this.graduacao = "";
            this.instituicao = "";
            this.profissao = "";
            this.local_trabalho = "";
            this.obs = "";
            this.conheceu = "";
            this.rg = "";
            this.rg_emissor = "";
            this.rg_2via = 0;
            this.formacao_data = "";
            this.formacao_titulo = "";
            this.formacao_instituicao = "";
            this.titulo_monografia = "";
            this.envio_email = 1;
            this.sexo = "";
            this.recado_telefone = "";
            this.recado_nome = "";
            this.email_autoriza = 0;
            this.email_apoio = "";
            this.pne = 0;
            this.pne_qual = "";
            this.nome_cracha = "";
            this.nacionalidade = "";
            this.bloqueio = false;
            this.idprofissao = 0;
            this.numero = "";
            this.complemento = "";
            this.flcorrecao = 0;
        }

        public Aluno(int codigo, DateTime data, Painel painel, string nome, string cpf, int convenio, string email, string senha, DateTime data_nascimento, string endereco, string bairro, string cidade, string estado, string cep, string ddd, string telefone, string ddd_celular, string celular, string formacao, string graduacao, string instituicao, string profissao, string local_trabalho, string obs, string conheceu, string rg, string rg_emissor, int rg_2via, string formacao_data, string formacao_titulo, string formacao_instituicao, string titulo_monografia, int envio_email, string sexo, string recado_telefone, string recado_nome, int email_autoriza, string email_apoio, int pne, string pne_qual, string nome_cracha, string nacionalidade, bool bloqueio)
        {
            this.codigo = codigo;
            this.data = DateTime.Now;
            this.painel = new Painel() { codigo = 0 };
            this.nome = nome;
            this.cpf = cpf;
            this.convenio = convenio;
            this.email = email;
            this.senha = senha;
            this.data_nascimento = data_nascimento;
            this.endereco = endereco;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
            this.cep = cep;
            this.ddd = ddd;
            this.telefone = telefone;
            this.ddd_celular = ddd_celular;
            this.celular = celular;
            this.formacao = formacao;
            this.graduacao = graduacao;
            this.instituicao = instituicao;
            this.profissao = profissao;
            this.local_trabalho = local_trabalho;
            this.obs = obs;
            this.conheceu = conheceu;
            this.rg = rg;
            this.rg_emissor = rg_emissor;
            this.rg_2via = rg_2via;
            this.formacao_data = formacao_data;
            this.formacao_titulo = formacao_titulo;
            this.formacao_instituicao = formacao_instituicao;
            this.titulo_monografia = titulo_monografia;
            this.envio_email = envio_email;
            this.sexo = sexo;
            this.recado_telefone = recado_telefone;
            this.recado_nome = recado_nome;
            this.email_autoriza = email_autoriza;
            this.email_apoio = email_apoio;
            this.pne = pne;
            this.pne_qual = pne_qual;
            this.nome_cracha = nome_cracha;
            this.nacionalidade = nacionalidade;
            this.bloqueio = bloqueio;
        }

        public Aluno(int codigo, DateTime data, Painel painel, string nome, string cpf, int convenio, string email, string senha, DateTime data_nascimento, string endereco, string bairro, string cidade, string estado, string cep, string ddd, string telefone, string ddd_celular, string celular, string formacao, string graduacao, string instituicao, string profissao, string local_trabalho, string obs, string conheceu, string rg, string rg_emissor, int rg_2via, string formacao_data, string formacao_titulo, string formacao_instituicao, string titulo_monografia, int envio_email, string sexo, string recado_telefone, string recado_nome, int email_autoriza, string email_apoio, int pne, string pne_qual, string nome_cracha, string nacionalidade, bool bloqueio, int idprofissao)
        {
            this.codigo = codigo;
            this.data = DateTime.Now;
            this.painel = new Painel() { codigo = 0 };
            this.nome = nome;
            this.cpf = cpf;
            this.convenio = convenio;
            this.email = email;
            this.senha = senha;
            this.data_nascimento = data_nascimento;
            this.endereco = endereco;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
            this.cep = cep;
            this.ddd = ddd;
            this.telefone = telefone;
            this.ddd_celular = ddd_celular;
            this.celular = celular;
            this.formacao = formacao;
            this.graduacao = graduacao;
            this.instituicao = instituicao;
            this.profissao = profissao;
            this.local_trabalho = local_trabalho;
            this.obs = obs;
            this.conheceu = conheceu;
            this.rg = rg;
            this.rg_emissor = rg_emissor;
            this.rg_2via = rg_2via;
            this.formacao_data = formacao_data;
            this.formacao_titulo = formacao_titulo;
            this.formacao_instituicao = formacao_instituicao;
            this.titulo_monografia = titulo_monografia;
            this.envio_email = envio_email;
            this.sexo = sexo;
            this.recado_telefone = recado_telefone;
            this.recado_nome = recado_nome;
            this.email_autoriza = email_autoriza;
            this.email_apoio = email_apoio;
            this.pne = pne;
            this.pne_qual = pne_qual;
            this.nome_cracha = nome_cracha;
            this.nacionalidade = nacionalidade;
            this.bloqueio = bloqueio;
            this.idprofissao = idprofissao;
        }

        public Aluno(int codigo, DateTime data, Painel painel, string nome, string cpf, int convenio, string email, string senha, DateTime data_nascimento, string endereco, string bairro, string cidade, string estado, string cep, string ddd, string telefone, string ddd_celular, string celular, string formacao, string graduacao, string instituicao, string profissao, string local_trabalho, string obs, string conheceu, string rg, string rg_emissor, int rg_2via, string formacao_data, string formacao_titulo, string formacao_instituicao, string titulo_monografia, int envio_email, string sexo, string recado_telefone, string recado_nome, int email_autoriza, string email_apoio, int pne, string pne_qual, string nome_cracha, string nacionalidade, bool bloqueio, int idprofissao, int flcorrecao)
        {
            this.codigo = codigo;
            this.data = DateTime.Now;
            this.painel = new Painel() { codigo = 0 };
            this.nome = nome;
            this.cpf = cpf;
            this.convenio = convenio;
            this.email = email;
            this.senha = senha;
            this.data_nascimento = data_nascimento;
            this.endereco = endereco;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
            this.cep = cep;
            this.ddd = ddd;
            this.telefone = telefone;
            this.ddd_celular = ddd_celular;
            this.celular = celular;
            this.formacao = formacao;
            this.graduacao = graduacao;
            this.instituicao = instituicao;
            this.profissao = profissao;
            this.local_trabalho = local_trabalho;
            this.obs = obs;
            this.conheceu = conheceu;
            this.rg = rg;
            this.rg_emissor = rg_emissor;
            this.rg_2via = rg_2via;
            this.formacao_data = formacao_data;
            this.formacao_titulo = formacao_titulo;
            this.formacao_instituicao = formacao_instituicao;
            this.titulo_monografia = titulo_monografia;
            this.envio_email = envio_email;
            this.sexo = sexo;
            this.recado_telefone = recado_telefone;
            this.recado_nome = recado_nome;
            this.email_autoriza = email_autoriza;
            this.email_apoio = email_apoio;
            this.pne = pne;
            this.pne_qual = pne_qual;
            this.nome_cracha = nome_cracha;
            this.nacionalidade = nacionalidade;
            this.bloqueio = bloqueio;
            this.idprofissao = idprofissao;
            this.flcorrecao = flcorrecao;
        }

        public Aluno(int codigo, DateTime data, Painel painel, string nome, string cpf, int convenio, string email, string senha, DateTime data_nascimento, string endereco, string bairro, string cidade, string estado, string cep, string ddd, string telefone, string ddd_celular, string celular, string formacao, string graduacao, string instituicao, string profissao, string local_trabalho, string obs, string conheceu, string rg, string rg_emissor, int rg_2via, string formacao_data, string formacao_titulo, string formacao_instituicao, string titulo_monografia, int envio_email, string sexo, string recado_telefone, string recado_nome, int email_autoriza, string email_apoio, int pne, string pne_qual, string nome_cracha, string nacionalidade, bool bloqueio, int idprofissao, string numero, string complemento, int flcorrecao)
        {
            this.codigo = codigo;
            this.data = DateTime.Now;
            this.painel = new Painel() { codigo = 0 };
            this.nome = nome;
            this.cpf = cpf;
            this.convenio = convenio;
            this.email = email;
            this.senha = senha;
            this.data_nascimento = data_nascimento;
            this.endereco = endereco;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
            this.cep = cep;
            this.ddd = ddd;
            this.telefone = telefone;
            this.ddd_celular = ddd_celular;
            this.celular = celular;
            this.formacao = formacao;
            this.graduacao = graduacao;
            this.instituicao = instituicao;
            this.profissao = profissao;
            this.local_trabalho = local_trabalho;
            this.obs = obs;
            this.conheceu = conheceu;
            this.rg = rg;
            this.rg_emissor = rg_emissor;
            this.rg_2via = rg_2via;
            this.formacao_data = formacao_data;
            this.formacao_titulo = formacao_titulo;
            this.formacao_instituicao = formacao_instituicao;
            this.titulo_monografia = titulo_monografia;
            this.envio_email = envio_email;
            this.sexo = sexo;
            this.recado_telefone = recado_telefone;
            this.recado_nome = recado_nome;
            this.email_autoriza = email_autoriza;
            this.email_apoio = email_apoio;
            this.pne = pne;
            this.pne_qual = pne_qual;
            this.nome_cracha = nome_cracha;
            this.nacionalidade = nacionalidade;
            this.bloqueio = bloqueio;
            this.idprofissao = idprofissao;
            this.numero = numero;
            this.complemento = complemento;
            this.flcorrecao = flcorrecao;
        }

        public Aluno(int codigo, string nome, string cpf)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.cpf = cpf;
        }

        public Aluno(int codigo, DateTime data, Painel painel, string nome, string cpf, string email)
        {
            this.codigo = codigo;
            this.data = data;
            this.painel = painel;
            this.nome = nome;
            this.cpf = cpf;
            this.email = email;
        }

        public void Salvar()
        {
            this.codigo = new AlunoDB().SalvarRetornar(this);
        }

        public void Alterar()
        {
            new AlunoDB().Alterar(this);
        }

        public void AlterarJornada()
        {
            new AlunoDB().Alterar(this);
        }

        public void Excluir()
        {
            new AlunoDB().Excluir(this);
        }

        public void AlterarSenha()
        {
            new AlunoDB().AlterarSenha(this);
        }
    }

    public class AlunoVendaRD
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string curso { get; set; }
        public string titulo_curso { get; set; }
        public string cidade { get; set; }

        public AlunoVendaRD()
        {
            this.nome = "";
            this.email = "";
            this.curso = "";
            this.titulo_curso = "";
            this.cidade = "";
        }

        public AlunoVendaRD(string nome, string email, string curso, string titulo_curso, string cidade)
        {
            this.nome = nome;
            this.email = email;
            this.curso = curso;
            this.titulo_curso = titulo_curso;
            this.cidade = cidade;
        }

        public void GerarConversao()
        {
            try
            {
                var webAddr = "https://www.rdstation.com.br/api/1.3/conversions";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";

                string v = "0.00";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"token_rdstation\": \"f82d8f17ef68b5b28c0b60fb3d2995bf\", \"identificador\": \"Matricula\", \"email\": \"" + this.email + "\", \"nome\": \"" + this.nome + "\", \"Código do Curso\": \"" + this.curso + "\", \"tags\": \"" + this.titulo_curso + ", " + this.cidade + "\"}";
                    
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpWebResponse httpResponse;

                bool continuar = true;

                try
                {
                    httpResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                    continuar = true;
                }
                catch (WebException ex)
                {
                    httpResponse = ex.Response as HttpWebResponse;
                    continuar = false;
                }

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    //if (continuar)
                    //marca como enviado
                }
            }
            catch (Exception error)
            {
                throw error;
            }


        }

        public void RegistrarVenda()
        {
            try
            {
                var webAddr = "https://www.rdstation.com.br/api/1.2/services/9808f8b443312e2e965d5b6e1738dc72/generic";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";

                string v = "0.00";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{ \"status\": \"won\", \"value\": " + v + ", \"email\": \"" + this.email + "\", \"nome\": \"" + this.nome + "\", \"curso\": \"" + this.curso + "\", \"tags\": \"" + this.titulo_curso + ", " + this.cidade + "\" }";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpWebResponse httpResponse;

                bool continuar = true;

                try
                {
                    httpResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                    continuar = true;
                }
                catch (WebException ex)
                {
                    httpResponse = ex.Response as HttpWebResponse;
                    continuar = false;
                }

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    
                    //if (continuar)
                        //marca como enviado
                }
            }
            catch (Exception error)
            {
                throw error;
            }


        }

    }
}
