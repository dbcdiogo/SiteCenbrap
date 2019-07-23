using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uol.PagSeguro;
using Biblioteca.DB;
using Biblioteca.Entidades;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Constants.PreApproval;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Exception;
using Uol.PagSeguro.Resources;
using Uol.PagSeguro.Service;

namespace Biblioteca.Funcoes
{
    public class PagamentoPagseguro
    {
        private decimal valor = 19.90m;
        private int qtd_max_meses = 60;
        private bool isSandbox = false;
        private string emailNotificacaoPagamento = "pagamento@cenbrap.com.br";
        private string emailNotificacaoAtivado = "marcello@cenbrap.com.br";

        #region "Assinatura"
        public Aluno_MedTV Pagar(Aluno_MedTV am)
        {
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            // Instantiate a new preApproval request
            PreApprovalRequest preApproval = new PreApprovalRequest();

            // Sets the currency
            preApproval.Currency = Currency.Brl;

            // Sets a reference code for this preApproval request, it is useful to identify this payment in future notifications.
            preApproval.Reference = am.aluno_MedTV_id.ToString();

            // Sets your customer information.
            preApproval.Sender = new Sender(
                am.aluno.nome,
                am.aluno.email,
                new Phone(am.aluno.ddd, am.aluno.telefone)
            );

            // Sets the preApproval informations
            var now = DateTime.Now;
            preApproval.PreApproval = new PreApproval();
            preApproval.PreApproval.Charge = Charge.Auto;
            preApproval.PreApproval.Name = "Assinatura MedTV";
            preApproval.PreApproval.AmountPerPayment = valor;
            preApproval.PreApproval.MaxAmountPerPeriod = valor;
            preApproval.PreApproval.MaxPaymentsPerPeriod = 1;
            preApproval.PreApproval.Details = string.Format("Todo dia {0} sera cobrado o valor de {1} referente a sua assinatura MedTV. A assinatura esta sendo contratada ate o termino da vigencia, no entanto voce podera fazer o cancelamento quando quiser!", now.Day, preApproval.PreApproval.AmountPerPayment.ToString("C2"));
            preApproval.PreApproval.Period = Period.Monthly;
            preApproval.PreApproval.DayOfMonth = now.Day;
            preApproval.PreApproval.InitialDate = now;
            preApproval.PreApproval.FinalDate = now.AddMonths(qtd_max_meses);
            preApproval.PreApproval.MaxTotalAmount = qtd_max_meses * valor;

            // Sets the url used by PagSeguro for redirect user after ends checkout process
            preApproval.RedirectUri = new Uri("https://www.medtv.com.br/retorno");
            // Sets the url used for user review the signature or read the rules
            preApproval.ReviewUri = new Uri("https://www.medtv.com.br/revisao");

            SenderDocument senderCPF = new SenderDocument(Documents.GetDocumentByType("CPF"), am.aluno.cpf.Replace(".", "").Replace(" ", "").Replace("-", "").Replace("/", "").Replace(",", ""));
            preApproval.Sender.Documents.Add(senderCPF);

            try
            {
                //AccountCredentials credentials = new AccountCredentials(email, token);
                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

                Uri preApprovalRedirectUri = preApproval.Register(credentials);

                am.pagseguro = true;
                am.urlPagseguro = preApprovalRedirectUri.ToString();
                am.msgPagseguro = "";

                am.Alterar();
            }
            catch (PagSeguroServiceException exception)
            {
                am.pagseguro = false;
                am.urlPagseguro = "";

                am.msgPagseguro = exception.Message + "\n";

                foreach (ServiceError element in exception.Errors)
                {
                    am.msgPagseguro += (element + "\n");
                }

                am.Alterar();
            }

            return am;
        }

        public Aluno_MedTV CancelarAssinaturaCode(string code)
        {
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            try
            {

                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

                if(PreApprovalService.CancelPreApproval(credentials, code))
                {
                    var transaction = PreApprovalSearchService.SearchByCode(credentials, code);
                    return AssinaturaTratarRetorno(transaction);
                }
                else
                {
                    var transaction = PreApprovalSearchService.SearchByCode(credentials, code);
                    return AssinaturaTratarRetorno(transaction);
                }
                

            }
            catch (PagSeguroServiceException exception)
            {
                string retorno = exception.Message + "\n";

                foreach (ServiceError element in exception.Errors)
                {
                    retorno += element + "\n";
                }

                return new Aluno_MedTV();
            }
        }

        public Aluno_MedTV ConsultarAssinaturaCode(string code)
        {
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            try
            {

                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

                var transaction = PreApprovalSearchService.SearchByCode(credentials, code);

                return AssinaturaTratarRetorno(transaction);

            }
            catch (PagSeguroServiceException exception)
            {
                string retorno = exception.Message + "\n";

                foreach (ServiceError element in exception.Errors)
                {
                    retorno += element + "\n";
                }

                return new Aluno_MedTV();
            }
        }

        public void AssinaturaNotificacao(string notificationCode)
        {
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            try
            {

                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

                PreApprovalTransaction transaction = PreApprovalSearchService.SearchByNofication(credentials, notificationCode);

                AssinaturaTratarRetorno(transaction);

            }
            catch (PagSeguroServiceException exception)
            {
                string retorno = exception.Message + "\n";

                foreach (ServiceError element in exception.Errors)
                {
                    retorno += element + "\n";
                }
            }
        }

        public Aluno_MedTV AssinaturaTratarRetorno(PreApprovalTransaction transaction)
        {
            Aluno_MedTV am = new Aluno_MedTVDB().Buscar(Convert.ToInt32(transaction.Reference));

            if (am != null)
            {
                am.aluno = new AlunoDB().Buscar(am.aluno.codigo);
                //salva o code no Aluno_MedTV
                am.codePagseguro = transaction.Code;
                am.msgPagseguro = AssinaturaMsg(transaction.Status);

                DateTime dateTime = DateTime.UtcNow;
                dateTime = dateTime.AddSeconds(-dateTime.Second);
                if (dateTime.Minute % 2 != 0)
                    dateTime = dateTime.AddMinutes(1);

                if (!new Aluno_MedTV_NotificacaoDB().Existe(am, dateTime))
                    new Aluno_MedTV_Notificacao(am, dateTime, transaction.Status, am.msgPagseguro).Salvar();

                //ACTIVE
                if (transaction.Status == "ACTIVE")
                {
                    if (!am.ativo)
                    {
                        am.Ativar();
                    }
                    new Envio_emailDB().Salvar(new Envio_email()
                    {
                        data = DateTime.Now,
                        assunto = "MedTV Assinatura ativada",
                        texto = "Aluno: " + am.aluno.nome + "(" + am.aluno.cpf + ")<BR>Msg: " + am.msgPagseguro,
                        para = emailNotificacaoAtivado
                    });

                    //LancaEntrada(am.aluno);
                }
                //CANCELLED ou CANCELLED_BY_RECEIVER ou CANCELLED_BY_SENDER ou EXPIRED
                if (transaction.Status == "CANCELLED" || transaction.Status == "CANCELLED_BY_RECEIVER" || transaction.Status == "CANCELLED_BY_SENDER" || transaction.Status == "EXPIRED")
                {
                    if (am.ativo)
                    {
                        am.Desativar();
                    }

                    new Envio_emailDB().Salvar(new Envio_email()
                    {
                        data = DateTime.Now,
                        assunto = "MedTV Assinatura cancelada",
                        texto = "Aluno: " + am.aluno.nome + "(" + am.aluno.cpf + ")<BR>Msg: " + am.msgPagseguro,
                        para = emailNotificacaoPagamento
                    });
                }
                am.Alterar();
            }
            return am;
        }

        public string AssinaturaMsg(string status)
        {
            string msg = "";

            //PENDING O comprador iniciou a fluxo de pagamento da transação que originou a assinatura ou optou por trocar o cartão de crédito atrelado a uma assinatura existente mas até o momento o PagSeguro não recebeu nenhuma confirmação da operadoraresponsável pelo processamento da transação validadora ou ela ainda está em análise. Transições: ACTIVE ou CANCELLED
            if (status == "PENDING")
            {
                msg = "O comprador iniciou a fluxo de pagamento da transação que originou a assinatura ou optou por trocar o cartão de crédito atrelado a uma assinatura existente mas até o momento o PagSeguro não recebeu nenhuma confirmação da operadoraresponsável pelo processamento da transação validadora ou ela ainda está em análise.";
            }
            //ACTIVE A transação que originou a assinatura foi paga pelo comprador e o PagSeguro já recebeu uma confirmação da operadora responsável pelo processamento. Transições: EXPIRED ou CANCELLED_BY_RECEIVER ou CANCELLED_BY_SENDER ou PENDING
            if (status == "ACTIVE")
            {
                msg = "A transação que originou a assinatura foi paga pelo comprador e o PagSeguro já recebeu uma confirmação da operadora responsável pelo processamento.";
            }
            //CANCELLED A transação que originou a assinatura foi cancelada por não ter sido aprovada pelo PagSeguro ou pela operadora.
            if (status == "CANCELLED")
            {
                msg = "A transação que originou a assinatura foi cancelada por não ter sido aprovada pelo PagSeguro ou pela operadora.";
            }
            //CANCELLED_BY_RECEIVER A assinatura foi cancelada mediante solicitação do vendedor. Transições: nenhuma
            if (status == "CANCELLED_BY_RECEIVER")
            {
                msg = "A assinatura foi cancelada mediante solicitação do vendedor.";
            }
            //CANCELLED_BY_SENDER A assinatura foi cancelada mediante solicitação do comprador. Transições: nenhuma
            if (status == "CANCELLED_BY_SENDER")
            {
                msg = "A assinatura foi cancelada mediante solicitação do comprador.";
            }
            //EXPIRED A assinatura expirou por ter atingido o tempo limite de sua vigência(preApprovalFinalDate) ou por ter atingido o valor definido em preApprovalMaxTotalAmount.
            if (status == "EXPIRED")
            {
                msg = "A assinatura expirou por ter atingido o tempo limite de sua vigência(preApprovalFinalDate) ou por ter atingido o valor definido em preApprovalMaxTotalAmount.";
            }

            return msg;
        }
        #endregion

        #region "Transação"
        public Aluno_MedTV ConsultarCode(string code)
        {
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            try
            {

                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

                Transaction transaction = TransactionSearchService.SearchByCode(credentials, code);

                return TratarRetorno(transaction);

            }
            catch (PagSeguroServiceException exception)
            {
                string retorno = exception.Message + "\n";

                foreach (ServiceError element in exception.Errors)
                {
                    retorno += element + "\n";
                }

                return new Aluno_MedTV();
            }
        }

        public void Notificacao(string code)
        {

            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            try
            {

                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

                Transaction transaction = NotificationService.CheckTransaction(credentials, code);

                TratarRetorno(transaction);

            }
            catch (PagSeguroServiceException exception)
            {
                string retorno = exception.Message + "\n";

                foreach (ServiceError element in exception.Errors)
                {
                    retorno += element + "\n";
                }
            }
        }

        public Aluno_MedTV TratarRetorno(Transaction transaction)
        {
            Aluno_MedTV am = new Aluno_MedTVDB().Buscar(Convert.ToInt32(transaction.Reference));

            int status = transaction.TransactionStatus;

            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.Initiated)
            //    status = 0;
            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.WaitingPayment)
            //    status = 1;
            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.InAnalysis)
            //    status = 2;
            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.Paid)
            //    status = 3;
            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.Available)
            //    status = 4;
            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.InDispute)
            //    status = 5;
            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.Refunded)
            //    status = 6;
            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.Cancelled)
            //    status = 7;

            Aluno_MedTV_Transacao amt = new Aluno_MedTV_TransacaoDB().Buscar(am, transaction.Code, status);

            if (amt == null)
            {
                amt = new Aluno_MedTV_Transacao()
                {
                    aluno_medTV_id = am,
                    code = transaction.Code,
                    data = DateTime.Now,
                    status = status
                };
                amt.Salvar();
            }

            if (am != null)
            {
                am.aluno = new AlunoDB().Buscar(am.aluno.codigo);
                //salva o code no Aluno_MedTV

                //msg do status
                amt.msg = TransacaoMsg(status);

                //3	Paga
                if (transaction.TransactionStatus == 3)
                {
                    //se não estiver ativo, ativa o usuário
                    if (!am.ativo)
                    {
                        am.Ativar();
                    }
                }
                //4 Disponivel
                if(transaction.TransactionStatus == 4)
                {
                    LancaEntrada(am.aluno, amt.data);
                }
                //5   Em disputa
                if (transaction.TransactionStatus == 5)
                {
                    //se estiver ativo, desativa o usuário
                    if (am.ativo)
                    {
                        am.Desativar();
                    }
                    new Envio_emailDB().Salvar(new Envio_email()
                    {
                        data = DateTime.Now,
                        assunto = "MedTV alterações de pagamento",
                        texto = "Alterações no pagamento.<BR>Aluno: " + am.aluno.nome + "(" + am.aluno.cpf + ")<BR>Msg: " + amt.msg,
                        para = emailNotificacaoPagamento
                    });
                }
                
                amt.data = DateTime.Now;
                amt.Alterar();
            }
            return am;
        }

        public int RetornoTransactionStatus(string transactionStatus)
        {
            int retorno = 0;



            return retorno;
        }

        public string TransacaoMsg(int status)
        {
            string msg = "";

            //1   Aguardando pagamento: o comprador iniciou a transação, mas até o momento o PagSeguro não recebeu nenhuma informação sobre o pagamento.
            if (status == 1)
                msg = "Aguardando pagamento: o comprador iniciou a transação, mas até o momento o PagSeguro não recebeu nenhuma informação sobre o pagamento.";

            //2   Em análise: o comprador optou por pagar com um cartão de crédito e o PagSeguro está analisando o risco da transação.
            if (status == 2)
                msg = "Em análise: o comprador optou por pagar com um cartão de crédito e o PagSeguro está analisando o risco da transação.";

            //3	Paga: a transação foi paga pelo comprador e o PagSeguro já recebeu uma confirmação da instituição financeira responsável pelo processamento.
            if (status == 3)
                msg = "Paga: a transação foi paga pelo comprador e o PagSeguro já recebeu uma confirmação da instituição financeira responsável pelo processamento.";

            //4   Disponível: a transação foi paga e chegou ao final de seu prazo de liberação sem ter sido retornada e sem que haja nenhuma disputa aberta.
            if (status == 4)
                msg = "Disponível: a transação foi paga e chegou ao final de seu prazo de liberação sem ter sido retornada e sem que haja nenhuma disputa aberta.";

            //5   Em disputa: o comprador, dentro do prazo de liberação da transação, abriu uma disputa.
            if (status == 5)
                msg = "Em disputa: o comprador, dentro do prazo de liberação da transação, abriu uma disputa.";

            //6   Devolvida: o valor da transação foi devolvido para o comprador.
            if (status == 6)
                msg = "Devolvida: o valor da transação foi devolvido para o comprador.";

            //7   Cancelada: a transação foi cancelada sem ter sido finalizada.
            if (status == 7)
                msg = "Cancelada: a transação foi cancelada sem ter sido finalizada.";

            //8   Debitado: o valor da transação foi devolvido para o comprador.
            if (status == 8)
                msg = "Debitado: o valor da transação foi devolvido para o comprador.";

            //9   Retenção temporária: o comprador contestou o pagamento junto à operadora do cartão de crédito ou abriu uma demanda judicial ou administrativa(Procon).
            if (status == 9)
                msg = "Retenção temporária: o comprador contestou o pagamento junto à operadora do cartão de crédito ou abriu uma demanda judicial ou administrativa(Procon).";

            return msg;
        }
        #endregion

        public void LancaEntrada(Aluno aluno, DateTime data)
        {
            try
            {
                Entrada entrada = new Entrada()
                {
                    cliente = new Cliente(aluno, new Curso() { codigo = 0, titulo1 = "MEDTV" }),
                    data = data,
                    boleto = "0",
                    codboleto = 0,
                    cod_verificacao = "",
                    arquivo_xml = "",
                    conta = new Conta() { codigo = 3 },
                    conta_devolucao = new Conta() { codigo = 0 },
                    codigo = 0,
                    data_devolucao = Convert.ToDateTime("01/01/1900"),
                    data_nota_fiscal = Convert.ToDateTime("01/01/1900"),
                    data_quitado = Convert.ToDateTime("01/01/1900"),
                    data_recebimento = Convert.ToDateTime("01/01/1900"),
                    desconto = 0,
                    emolumento = "",
                    identificacao = "Assinatura MedTV",
                    juros = 0,
                    multa = 0,
                    negativado = 0,
                    negativado_data = Convert.ToDateTime("01/01/1900"),
                    negativado_data_removido = Convert.ToDateTime("01/01/1900"),
                    negociacao = 0,
                    nota_fiscal = "",
                    obs_cancelado = "",
                    painel = new Painel() { codigo = 0 },
                    parcela = "",
                    situacao = 0,
                    tipo_entrada = new Tipo_entrada() { codigo = 9 },
                    tipo_pgto = "PagSeguro",
                    valor = (double)valor,
                    vencimento = data,
                    xml_envio = "",
                    xml_retorno = ""
                };
                EntradaDB entradaDB = new EntradaDB();

                if (!entradaDB.Existe(entrada))
                    entradaDB.Salvar(entrada);

            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }

    public class PagamentoPagseguroCenbrap
    {
        private decimal valor = 390.00m;
        private int qtd_max_meses = 12;
        private bool isSandbox = false;
        private string emailNotificacaoPagamento = "marcello@cenbrap.com.br";
        private string emailNotificacaoAtivado = "marcello@cenbrap.com.br";

        #region "Assinatura"
        public string Pagamento(Aluno_pgto ap)
        {
            string link = "";
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            // Instantiate a new preApproval request
            PreApprovalRequest preApproval = new PreApprovalRequest();

            // Sets the currency
            preApproval.Currency = Currency.Brl;

            // Sets a reference code for this preApproval request, it is useful to identify this payment in future notifications.
            preApproval.Reference = "AP" + ap.codigo.ToString();

            ap.CompletaCampos();

            // Sets your customer information.
            preApproval.Sender = new Sender(
                ap.aluno.nome,
                ap.aluno.email,
                new Phone(ap.aluno.ddd, ap.aluno.telefone)
            );

            valor = Convert.ToDecimal(ap.curso.valor);

            if (ap.aluno.codigo == 4284)
                valor = 1;

            preApproval.PreApproval = new PreApproval();

            // Sets the preApproval informations
            var now = DateTime.Now;
            preApproval.PreApproval = new PreApproval();
            preApproval.PreApproval.Charge = Charge.Auto;
            preApproval.PreApproval.Name = "Assinatura " + ap.curso.titulo;
            preApproval.PreApproval.AmountPerPayment = valor;
            preApproval.PreApproval.MaxAmountPerPeriod = valor;
            preApproval.PreApproval.MaxPaymentsPerPeriod = 1;
            preApproval.PreApproval.Details = string.Format("Todo dia {0} sera cobrado o valor de {1} referente a sua assinatura {2}. A assinatura esta sendo contratada ate o termino da vigencia, no entanto voce podera fazer o cancelamento quando quiser!", now.Day, preApproval.PreApproval.AmountPerPayment.ToString("C2"), ap.curso.titulo);
            preApproval.PreApproval.Period = Period.Monthly;
            preApproval.PreApproval.DayOfMonth = now.Day;
            preApproval.PreApproval.InitialDate = now;
            preApproval.PreApproval.FinalDate = now.AddMonths(qtd_max_meses);
            preApproval.PreApproval.MaxTotalAmount = qtd_max_meses * valor;

            // Sets the url used by PagSeguro for redirect user after ends checkout process
            preApproval.RedirectUri = new Uri("https://www.cenbrap.com.br/Pagseguro/retorno");
            // Sets the url used for user review the signature or read the rules
            preApproval.ReviewUri = new Uri("https://www.cenbrap.com.br/Pagseguro/revisao");

            SenderDocument senderCPF = new SenderDocument(Documents.GetDocumentByType("CPF"), ap.aluno.cpf.Replace(".", "").Replace(" ", "").Replace("-", "").Replace("/", "").Replace(",", ""));
            preApproval.Sender.Documents.Add(senderCPF);

            try
            {
                //AccountCredentials credentials = new AccountCredentials(email, token);
                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

                Uri preApprovalRedirectUri = preApproval.Register(credentials);

                ap.situacao = 0;
                ap.obs = preApprovalRedirectUri.ToString();
                ap.txt = "";

                link = preApprovalRedirectUri.ToString();

                ap.Alterar();
            }
            catch (PagSeguroServiceException exception)
            {
                ap.situacao = 1;
                ap.obs = "";

                ap.txt = exception.Message + "\n";

                foreach (ServiceError element in exception.Errors)
                {
                    ap.txt += (element + "\n");
                }

                ap.Alterar();
            }

            return link;
        }

        public Aluno_pgto Pagar(Aluno_pgto ap)
        {
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            // Instantiate a new preApproval request
            PreApprovalRequest preApproval = new PreApprovalRequest();
            
            // Sets the currency
            preApproval.Currency = Currency.Brl;

            // Sets a reference code for this preApproval request, it is useful to identify this payment in future notifications.
            preApproval.Reference = "AP"+ap.codigo.ToString();

            ap.CompletaCampos();

            // Sets your customer information.
            preApproval.Sender = new Sender(
                ap.aluno.nome,
                ap.aluno.email,
                new Phone(ap.aluno.ddd, ap.aluno.telefone)
            );

            valor = Convert.ToDecimal(ap.curso.valor);

            if (ap.aluno.codigo == 4284)
                valor = 1;

            preApproval.PreApproval = new PreApproval();

            // Sets the preApproval informations
            var now = DateTime.Now;
            preApproval.PreApproval = new PreApproval();
            preApproval.PreApproval.Charge = Charge.Auto;
            preApproval.PreApproval.Name = "Assinatura " + ap.curso.titulo;
            preApproval.PreApproval.AmountPerPayment = valor;
            preApproval.PreApproval.MaxAmountPerPeriod = valor;
            preApproval.PreApproval.MaxPaymentsPerPeriod = 1;
            preApproval.PreApproval.Details = string.Format("Todo dia {0} sera cobrado o valor de {1} referente a sua assinatura {2}. A assinatura esta sendo contratada ate o termino da vigencia, no entanto voce podera fazer o cancelamento quando quiser!", now.Day, preApproval.PreApproval.AmountPerPayment.ToString("C2"), ap.curso.titulo);
            preApproval.PreApproval.Period = Period.Monthly;
            preApproval.PreApproval.DayOfMonth = now.Day;
            preApproval.PreApproval.InitialDate = now;
            preApproval.PreApproval.FinalDate = now.AddMonths(qtd_max_meses);
            preApproval.PreApproval.MaxTotalAmount = qtd_max_meses * valor;

            // Sets the url used by PagSeguro for redirect user after ends checkout process
            preApproval.RedirectUri = new Uri("https://www.cenbrap.com.br/Pagseguro/retorno");
            // Sets the url used for user review the signature or read the rules
            preApproval.ReviewUri = new Uri("https://www.cenbrap.com.br/Pagseguro/revisao");

            SenderDocument senderCPF = new SenderDocument(Documents.GetDocumentByType("CPF"), ap.aluno.cpf.Replace(".", "").Replace(" ", "").Replace("-", "").Replace("/", "").Replace(",", ""));
            preApproval.Sender.Documents.Add(senderCPF);

            try
            {
                //AccountCredentials credentials = new AccountCredentials(email, token);
                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

                Uri preApprovalRedirectUri = preApproval.Register(credentials);

                ap.situacao = 0;
                ap.obs = preApprovalRedirectUri.ToString();
                ap.txt = "";

                ap.Alterar();
            }
            catch (PagSeguroServiceException exception)
            {
                ap.situacao = 1;
                ap.obs = "";

                ap.txt = exception.Message + "\n";

                foreach (ServiceError element in exception.Errors)
                {
                    ap.txt += (element + "\n");
                }

                ap.Alterar();
            }

            return ap;
        }

        public Aluno_pgto CancelarAssinaturaCode(string code)
        {
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            try
            {

                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

                if (PreApprovalService.CancelPreApproval(credentials, code))
                {
                    var transaction = PreApprovalSearchService.SearchByCode(credentials, code);
                    return AssinaturaTratarRetorno(transaction);
                }
                else
                {
                    var transaction = PreApprovalSearchService.SearchByCode(credentials, code);
                    return AssinaturaTratarRetorno(transaction);
                }


            }
            catch (PagSeguroServiceException exception)
            {
                string retorno = exception.Message + "\n";

                foreach (ServiceError element in exception.Errors)
                {
                    retorno += element + "\n";
                }

                return new Aluno_pgto();
            }
        }

        public Aluno_pgto ConsultarAssinaturaCode(string code)
        {
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            try
            {

                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

                var transaction = PreApprovalSearchService.SearchByCode(credentials, code);

                return AssinaturaTratarRetorno(transaction);

            }
            catch (PagSeguroServiceException exception)
            {
                string retorno = exception.Message + "\n";

                foreach (ServiceError element in exception.Errors)
                {
                    retorno += element + "\n";
                }

                return new Aluno_pgto();
            }
        }

        public void AssinaturaNotificacao(string notificationCode)
        {
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            try
            {

                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

                PreApprovalTransaction transaction = PreApprovalSearchService.SearchByNofication(credentials, notificationCode);

                AssinaturaTratarRetorno(transaction);

            }
            catch (PagSeguroServiceException exception)
            {
                string retorno = exception.Message + "\n";

                foreach (ServiceError element in exception.Errors)
                {
                    retorno += element + "\n";
                }
            }
        }

        public Aluno_pgto AssinaturaTratarRetorno(PreApprovalTransaction transaction)
        {
            Aluno_pgto ap = new Aluno_pgtoDB().Buscar(Convert.ToInt32(transaction.Reference.Replace("AP", "")));

            if (ap != null)
            {
                ap.CompletaCampos();
                //salva o code no Aluno_MedTV
                ap.obs = transaction.Code;
                ap.txt = AssinaturaMsg(transaction.Status);

                DateTime dateTime = DateTime.UtcNow;
                dateTime = dateTime.AddSeconds(-dateTime.Second);
                if (dateTime.Minute % 2 != 0)
                    dateTime = dateTime.AddMinutes(1);

                if (!new Aluno_pgto_NotificacaoDB().Existe(ap, dateTime))
                    new Aluno_pgto_Notificacao(ap, dateTime, transaction.Status, ap.txt).Salvar();

                //ACTIVE
                if (transaction.Status == "ACTIVE")
                {
                    if (ap.situacao != 2)
                    {
                        ap.Ativar();
                    }
                    new Envio_emailDB().Salvar(new Envio_email()
                    {
                        data = DateTime.Now,
                        assunto = "Cenbrap Assinatura ativada",
                        texto = "Aluno: " + ap.aluno.nome + "(" + ap.aluno.cpf + ")<BR>Curso: " + ap.curso.titulo + "<BR>Msg: " + ap.txt,
                        para = emailNotificacaoAtivado
                    });

                    //LancaEntrada(am.aluno);
                }
                //CANCELLED ou CANCELLED_BY_RECEIVER ou CANCELLED_BY_SENDER ou EXPIRED
                if (transaction.Status == "CANCELLED" || transaction.Status == "CANCELLED_BY_RECEIVER" || transaction.Status == "CANCELLED_BY_SENDER" || transaction.Status == "EXPIRED")
                {
                    if (ap.situacao == 2)
                    {
                        ap.Desativar();
                    }

                    new Envio_emailDB().Salvar(new Envio_email()
                    {
                        data = DateTime.Now,
                        assunto = "Cenbrap Assinatura cancelada",
                        texto = "Aluno: " + ap.aluno.nome + "(" + ap.aluno.cpf + ")<BR>Curso: " + ap.curso.titulo + "<BR>Msg: " + ap.txt,
                        para = emailNotificacaoPagamento
                    });
                }
                ap.Alterar();
            }
            return ap;
        }

        public string AssinaturaMsg(string status)
        {
            string msg = "";

            //PENDING O comprador iniciou a fluxo de pagamento da transação que originou a assinatura ou optou por trocar o cartão de crédito atrelado a uma assinatura existente mas até o momento o PagSeguro não recebeu nenhuma confirmação da operadoraresponsável pelo processamento da transação validadora ou ela ainda está em análise. Transições: ACTIVE ou CANCELLED
            if (status == "PENDING")
            {
                msg = "O comprador iniciou a fluxo de pagamento da transação que originou a assinatura ou optou por trocar o cartão de crédito atrelado a uma assinatura existente mas até o momento o PagSeguro não recebeu nenhuma confirmação da operadoraresponsável pelo processamento da transação validadora ou ela ainda está em análise.";
            }
            //ACTIVE A transação que originou a assinatura foi paga pelo comprador e o PagSeguro já recebeu uma confirmação da operadora responsável pelo processamento. Transições: EXPIRED ou CANCELLED_BY_RECEIVER ou CANCELLED_BY_SENDER ou PENDING
            if (status == "ACTIVE")
            {
                msg = "A transação que originou a assinatura foi paga pelo comprador e o PagSeguro já recebeu uma confirmação da operadora responsável pelo processamento.";
            }
            //CANCELLED A transação que originou a assinatura foi cancelada por não ter sido aprovada pelo PagSeguro ou pela operadora.
            if (status == "CANCELLED")
            {
                msg = "A transação que originou a assinatura foi cancelada por não ter sido aprovada pelo PagSeguro ou pela operadora.";
            }
            //CANCELLED_BY_RECEIVER A assinatura foi cancelada mediante solicitação do vendedor. Transições: nenhuma
            if (status == "CANCELLED_BY_RECEIVER")
            {
                msg = "A assinatura foi cancelada mediante solicitação do vendedor.";
            }
            //CANCELLED_BY_SENDER A assinatura foi cancelada mediante solicitação do comprador. Transições: nenhuma
            if (status == "CANCELLED_BY_SENDER")
            {
                msg = "A assinatura foi cancelada mediante solicitação do comprador.";
            }
            //EXPIRED A assinatura expirou por ter atingido o tempo limite de sua vigência(preApprovalFinalDate) ou por ter atingido o valor definido em preApprovalMaxTotalAmount.
            if (status == "EXPIRED")
            {
                msg = "A assinatura expirou por ter atingido o tempo limite de sua vigência(preApprovalFinalDate) ou por ter atingido o valor definido em preApprovalMaxTotalAmount.";
            }

            return msg;
        }
        #endregion

        #region "Transação"
        public Aluno_pgto ConsultarCode(string code)
        {
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            try
            {

                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

                Transaction transaction = TransactionSearchService.SearchByCode(credentials, code);

                return TratarRetorno(transaction);

            }
            catch (PagSeguroServiceException exception)
            {
                string retorno = exception.Message + "\n";

                foreach (ServiceError element in exception.Errors)
                {
                    retorno += element + "\n";
                }

                return new Aluno_pgto();
            }
        }

        public void Notificacao(string code)
        {

            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            try
            {

                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

                Transaction transaction = NotificationService.CheckTransaction(credentials, code);

                TratarRetorno(transaction);

            }
            catch (PagSeguroServiceException exception)
            {
                string retorno = exception.Message + "\n";

                foreach (ServiceError element in exception.Errors)
                {
                    retorno += element + "\n";
                }
            }
        }

        public Aluno_pgto TratarRetorno(Transaction transaction)
        {
            Aluno_pgto ap = new Aluno_pgtoDB().Buscar(Convert.ToInt32(transaction.Reference.Replace("AP", "")));

            int status = transaction.TransactionStatus;

            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.Initiated)
            //    status = 0;
            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.WaitingPayment)
            //    status = 1;
            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.InAnalysis)
            //    status = 2;
            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.Paid)
            //    status = 3;
            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.Available)
            //    status = 4;
            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.InDispute)
            //    status = 5;
            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.Refunded)
            //    status = 6;
            //if (transaction.TransactionStatus == Uol.PagSeguro.Enums.TransactionStatus.Cancelled)
            //    status = 7;

            Aluno_pgto_Transacao apt = new Aluno_pgto_TransacaoDB().Buscar(ap, transaction.Code, status);

            if (apt == null)
            {
                apt = new Aluno_pgto_Transacao()
                {
                    aluno_pgto = ap,
                    code = transaction.Code,
                    data = DateTime.Now,
                    status = status
                };
                apt.Salvar();
            }

            if (ap != null)
            {
                ap.aluno = new AlunoDB().Buscar(ap.aluno.codigo);
                //salva o code no Aluno_MedTV

                //msg do status
                apt.msg = TransacaoMsg(status);

                //3	Paga
                if (transaction.TransactionStatus == 3)
                {
                    //se não estiver ativo, ativa o usuário
                    if (ap.situacao != 2)
                    {
                        ap.Ativar();
                    }
                }
                //4 Disponivel
                if (transaction.TransactionStatus == 4)
                {
                    LancaEntrada(ap.aluno, ap.curso, apt.data);
                }
                //5   Em disputa
                if (transaction.TransactionStatus == 5)
                {
                    //se estiver ativo, desativa o usuário
                    if (ap.situacao == 2)
                    {
                        ap.Desativar();
                    }
                    new Envio_emailDB().Salvar(new Envio_email()
                    {
                        data = DateTime.Now,
                        assunto = "Cenbrap alterações de pagamento",
                        texto = "Alterações no pagamento.<BR>Aluno: " + ap.aluno.nome + "(" + ap.aluno.cpf + ")<BR>Msg: " + apt.msg,
                        para = emailNotificacaoPagamento
                    });
                }

                apt.data = DateTime.Now;
                apt.Alterar();
            }
            return ap;
        }

        public int RetornoTransactionStatus(string transactionStatus)
        {
            int retorno = 0;



            return retorno;
        }

        public string TransacaoMsg(int status)
        {
            string msg = "";

            //1   Aguardando pagamento: o comprador iniciou a transação, mas até o momento o PagSeguro não recebeu nenhuma informação sobre o pagamento.
            if (status == 1)
                msg = "Aguardando pagamento: o comprador iniciou a transação, mas até o momento o PagSeguro não recebeu nenhuma informação sobre o pagamento.";

            //2   Em análise: o comprador optou por pagar com um cartão de crédito e o PagSeguro está analisando o risco da transação.
            if (status == 2)
                msg = "Em análise: o comprador optou por pagar com um cartão de crédito e o PagSeguro está analisando o risco da transação.";

            //3	Paga: a transação foi paga pelo comprador e o PagSeguro já recebeu uma confirmação da instituição financeira responsável pelo processamento.
            if (status == 3)
                msg = "Paga: a transação foi paga pelo comprador e o PagSeguro já recebeu uma confirmação da instituição financeira responsável pelo processamento.";

            //4   Disponível: a transação foi paga e chegou ao final de seu prazo de liberação sem ter sido retornada e sem que haja nenhuma disputa aberta.
            if (status == 4)
                msg = "Disponível: a transação foi paga e chegou ao final de seu prazo de liberação sem ter sido retornada e sem que haja nenhuma disputa aberta.";

            //5   Em disputa: o comprador, dentro do prazo de liberação da transação, abriu uma disputa.
            if (status == 5)
                msg = "Em disputa: o comprador, dentro do prazo de liberação da transação, abriu uma disputa.";

            //6   Devolvida: o valor da transação foi devolvido para o comprador.
            if (status == 6)
                msg = "Devolvida: o valor da transação foi devolvido para o comprador.";

            //7   Cancelada: a transação foi cancelada sem ter sido finalizada.
            if (status == 7)
                msg = "Cancelada: a transação foi cancelada sem ter sido finalizada.";

            //8   Debitado: o valor da transação foi devolvido para o comprador.
            if (status == 8)
                msg = "Debitado: o valor da transação foi devolvido para o comprador.";

            //9   Retenção temporária: o comprador contestou o pagamento junto à operadora do cartão de crédito ou abriu uma demanda judicial ou administrativa(Procon).
            if (status == 9)
                msg = "Retenção temporária: o comprador contestou o pagamento junto à operadora do cartão de crédito ou abriu uma demanda judicial ou administrativa(Procon).";

            return msg;
        }
        #endregion

        public void LancaEntrada(Aluno aluno, Curso curso, DateTime data)
        {
            try
            {
                Entrada entrada = new Entrada()
                {
                    cliente = new Cliente(aluno, curso),
                    data = data,
                    boleto = "0",
                    codboleto = 0,
                    cod_verificacao = "",
                    arquivo_xml = "",
                    conta = new Conta() { codigo = 3 },
                    conta_devolucao = new Conta() { codigo = 0 },
                    codigo = 0,
                    data_devolucao = Convert.ToDateTime("01/01/1900"),
                    data_nota_fiscal = Convert.ToDateTime("01/01/1900"),
                    data_quitado = Convert.ToDateTime("01/01/1900"),
                    data_recebimento = Convert.ToDateTime("01/01/1900"),
                    desconto = 0,
                    emolumento = "",
                    identificacao = "Assinatura Cenbrap",
                    juros = 0,
                    multa = 0,
                    negativado = 0,
                    negativado_data = Convert.ToDateTime("01/01/1900"),
                    negativado_data_removido = Convert.ToDateTime("01/01/1900"),
                    negociacao = 0,
                    nota_fiscal = "",
                    obs_cancelado = "",
                    painel = new Painel() { codigo = 0 },
                    parcela = "",
                    situacao = 0,
                    tipo_entrada = new Tipo_entrada() { codigo = 9 },
                    tipo_pgto = "PagSeguro",
                    valor = (double)valor,
                    vencimento = data,
                    xml_envio = "",
                    xml_retorno = ""
                };
                EntradaDB entradaDB = new EntradaDB();

                if (!entradaDB.Existe(entrada))
                    entradaDB.Salvar(entrada);

            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
