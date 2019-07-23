using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public static class Whatsapp
{
    private static string serviceId = "4ef1df32-07f2-4c2e-9459-4677e47b6231";
    private static string token = "c3b425e90fd49bc010068a0768a6e46ca63edf08"; //"e7df885f316b133bb3e81e62ba0396f998e52c33"
    private static string urlMessages = "https://cenbrap-api.mandeumzap.com.br/v1/messages";

    public static string FormataCelular(string ddd, string celular)
    {
        string retorno = "";

        // Remove todos os caracateres não númericos
        ddd = new string(ddd.Where(char.IsNumber).ToArray());
        celular = new string(celular.Where(char.IsNumber).ToArray());

        // Verifica se o ddd é vazio ou diferente de 2 números ou se está inserido no celular
        if (((ddd != "") && (ddd.Length == 2)) || (celular.Length >= 10)) {

            // Verifica se o tamanho do celular possui entre 8 e 11 caracteres
            switch (celular.Length)
            {
                case 8:
                    retorno = "55" + ddd + "9" + celular;
                    break;

                case 9:
                    retorno = "55" + ddd + celular;
                    break;

                case 10:
                    retorno = "55" + celular.Substring(0,2) + "9" + celular.Substring(2,8);
                    break;

                case 11:
                    retorno = "55" + celular;
                    break;

                default:
                    break;
            }
        }
        return retorno;
    }

    // Busca as mensagens dentro de um período e/ou contato específico
    public static async Task<string> BuscarMensagens(string data1, string data2, int page = 1, int limit = 999999, string telefone = "")
    {        
        HttpContent ret;
        string filter = "page=" + page + "&per_page=" + limit;

        if (data1 != "")
        {
            filter += "&where[timestamp][$between][0]=" + data1;
        }

        if (data2 != "")
        {
            filter += "&where[timestamp][$between][1]=" + data2;
        }

        if (telefone != "")
        {
            //filter += "&where[timestamp][$between][1]=" + data2;
        }
        urlMessages = urlMessages + "?" + filter;


        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), urlMessages))
            {
                request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);
                var response = await httpClient.SendAsync(request);
                ret = response.Content;
            }
        }
        return await ret.ReadAsStringAsync();
    }

    // Enviar mensagem
    public static async Task<Boolean> EnviarMensagem(string telefone, string mensagem, string file)
    {
        Boolean ret = false;
        if ((telefone != "") && (mensagem != ""))
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), urlMessages))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

                    // Mensagem de texto
                    if (file == "")
                    {
                        request.Content = new StringContent("{\"number\":\"" + telefone + "\", \"serviceId\":\"" + serviceId + "\", \"text\":\"" + mensagem + "\"}", Encoding.UTF8, "application/json");
                    }
                    // Mensagem com arquivo
                    else
                    {
                        var caminho = Path.Combine(@"C:\inetpub\wwwroot\sistema.cenbrap.com.br\App_Data\whatsapp\", file);
                        Byte[] bytes = File.ReadAllBytes(caminho);
                        String anexo = Convert.ToBase64String(bytes);

                        request.Content = new StringContent("{\"number\":\""+ telefone + "\", \"serviceId\":\""+ serviceId + "\", \"text\":\"" + mensagem + "\", \"dontOpenTicket\": true, \"file\":{\"name\":\"" + file + "\", \"mimetype\": \"application/pdf\", \"base64\": \"" + anexo + "\"}}", Encoding.UTF8, "application/json");

                    }
                    var response = await httpClient.SendAsync(request);
                    ret = response.IsSuccessStatusCode;
                }
            }
        }
        return ret;
    }

}