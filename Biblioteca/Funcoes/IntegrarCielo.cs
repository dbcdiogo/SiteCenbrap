using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Biblioteca.Entidades;
using Biblioteca.DB;

namespace Biblioteca.Funcoes
{
    public class IntegrarCielo
    {
        public string Gerar(int id, double valor, string curso, string nome, string cpf, string email, string telefone)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://cieloecommerce.cielo.com.br/api/public/v1/orders");

            request.Method = "POST";
            request.ContentType = "text/json";
            request.Headers["MerchantId"] = "a25873bf-faf2-46ea-b7af-06f2bc828bb3";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
        | SecurityProtocolType.Tls11
        | SecurityProtocolType.Tls12
        | SecurityProtocolType.Ssl3;

            string json = "{"
                        + "    \"OrderNumber\": \"" + id.ToString() + "\","
                        + "    \"SoftDescriptor\": \"CENBRAP\","
                        + "    \"Cart\": {"
                        + "        \"Items\": ["
                        + "            {"
                        + "                \"Name\": \"" + curso + "\","
                        + "                \"UnitPrice\": " + valor.ToString("N2").Replace(".", "").Replace(",", "") + ","
                        + "                \"Quantity\": 1,"
                        + "                \"Type\": \"Service\""
                        + "            }"
                        + "        ]"
                        + "    },"
                        + "    \"Shipping\": {"
                        + "        \"Type\": \"WithoutShipping\""
                        + "    },"
                        + "     \"Customer\": {"
                        + "         \"Identity\": \"" + cpf.Replace(".", "").Replace("-", "").Replace("/", "") + "\","
                        + "         \"FullName\": \"" + nome + "\","
                        + "         \"Email\": \"" + email + "\","
                        + "         \"Phone\": \"" + telefone.Replace(" ", "").Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace(",", "") + "\""
                        + "     }"
                        + "}";

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(json);
                writer.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string url = "";

            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new StreamReader(response.GetResponseStream(), encoding))
            {
                string responseText = reader.ReadToEnd();

                var j = JsonConvert.DeserializeObject<dynamic>(responseText);

                url = j.settings.checkoutUrl;
            }

            return url;
        }

        public void Notificacao(string checkout_cielo_order_number, int amount, string order_number, string created_date, string customer_name, string customer_identity, string customer_email, int customer_phone, int discount_amount, int shipping_type, string shipping_name, int shipping_price, int shipping_address_zipcode, string shipping_address_district, string shipping_address_city, string shipping_address_state, string shipping_address_line1, string shipping_address_line2, int shipping_address_number, int payment_method_type, int payment_method_brand, int payment_method_bank, string payment_maskedcredicard, int payment_installments, int payment_antifrauderesult, int payment_boletonumber, int payment_boletoexpirationdate, int payment_status, string tid)
        {
            //se recebeu os dados necessários
            if (order_number != "" && tid != "" && payment_status != 0 && amount != 0 && payment_method_type != 0)
            {
                Aluno_pgto pgto = new Aluno_pgtoDB().Buscar(Convert.ToInt32(order_number));

                if (pgto != null)
                {
                    //pgto.forma_pgto = FormaPgto(payment_method_type, payment_method_brand);
                    pgto.txt = tid;
                    pgto.parcela = payment_installments;
                    pgto.Alterar();

                    Status(checkout_cielo_order_number, amount, order_number, payment_status);
                }
            }
        }

        public void Status(string checkout_cielo_order_number, int amount, string order_number, int payment_status)
        {
            if (order_number != "" && payment_status != 0)
            {
                Aluno_pgto pgto = new Aluno_pgtoDB().Buscar(Convert.ToInt32(order_number));

                if (pgto != null)
                {
                    int situacao_anterior = pgto.situacao;
                    pgto.situacao = PagamentoStatus(payment_status);
                    pgto.Alterar();

                    //se a situacao anterior for 2 e ocorrer a mudança de situacao avisa a Rakel
                    if ((situacao_anterior == 2 && pgto.situacao != 2) || payment_status == 8)
                    {
                        EmailAlertaRakel(pgto);
                    }

                    //se a situacao anterior era diferente de 2 e virou 2
                    //Confirma matrícula / Inscrição

                    if (situacao_anterior != 2 && pgto.situacao == 2)
                    {
                        PgtoConcluido(pgto);
                    }

                    //se a situacao virou 1 envia email para o aluno avisando que o pagamento não foi efetuado
                    if (situacao_anterior != 1 && pgto.situacao == 1)
                    {
                        PgtoNaoConcluido(pgto);
                    }
                }
            }
        }

        public int FormaPgto(int type, int brand)
        {
            int forma_pgto = 0;

            if (type == 3 || type == 4)
            {
                forma_pgto = 4;
            }

            if (type == 1)
            {
                //Visa
                if (brand == 1)
                    forma_pgto = 5;
                //Mastercard
                if (brand == 2)
                    forma_pgto = 6;
                //AmericanExpress
                if (brand == 3)
                    forma_pgto = 8;
                //Diners
                if (brand == 4)
                    forma_pgto = 9;
                //Elo
                if (brand == 5)
                    forma_pgto = 7;
                //Aura
                if (brand == 6)
                    forma_pgto = 10;
                //JCB
                if (brand == 7)
                    forma_pgto = 11;
            }

            return forma_pgto;
        }

        public int PagamentoStatus(int status)
        {
            int situacao = 0;
            //1   Pendente(Para todos os meios de pagamento)
            //2   Pago(Para todos os meios de pagamento)
            //3   Negado(Somente para Cartão Crédito)
            //4   Expirado(Cartões de Crédito e Boleto)
            //5   Cancelado(Para cartões de crédito)
            //6   Não Finalizado (Todos os meios de pagamento)
            //7   Autorizado(somente para Cartão de Crédito)
            //8   Chargeback(somente para Cartão de Crédito)

            if (status == 3 || status == 4 || status == 5 || status == 6)
                situacao = 1;

            if (status == 2 || status == 7)
                situacao = 2;

            return situacao;
        }

        public void EmailAlertaRakel(Aluno_pgto pgto)
        {
            pgto.aluno = new AlunoDB().Buscar(pgto.aluno.codigo);
            pgto.curso = new CursoDB().Buscar(pgto.curso.codigo);

            string txt = "O pagamento Cielo TID " + pgto.txt + " foi cancelado.<BR>Aluno: " + pgto.aluno.nome + "<BR>Curso: " + pgto.curso.titulo;

            new Envio_email() { para = "pagamento@cenbrap.com.br", assunto = "Pagamento Cielo Cancelado", texto = txt }.Salvar();
        }

        public void PgtoConcluido(Aluno_pgto pgto)
        {
            pgto.CompletaCampos();
            pgto.Confirma();
        }

        public void PgtoNaoConcluido(Aluno_pgto pgto)
        {
            pgto.aluno = new AlunoDB().Buscar(pgto.aluno.codigo);
            pgto.curso = new CursoDB().Buscar(pgto.curso.codigo);

            string txt = "Olá Dr(a). " + pgto.aluno.nome + ",<BR><BR>O pagamento da " + pgto.curso.Tipo() + " no(a) " + pgto.curso.titulo + " não foi concluído, por favor tente novamente.";

            new Envio_email() { para = pgto.aluno.email, assunto = "Pagamento não concluído - Cenbrap", texto = txt }.Salvar();
        }
    }
}
