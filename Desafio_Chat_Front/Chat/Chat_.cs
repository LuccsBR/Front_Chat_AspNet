using Desafio_Chat_Front.Account;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Desafio_Chat_Front
{
    public class Chat_
    {
        public class EnviaViewModel
        {
            public string Email_Usuario_R { get; set; }
            public string Texto { get; set; }
            public byte[] Imagem { get; set; }
        }
        public  async void EnviaMensagem( string Email_R, string texto)
        {
            try
            {
                string url = $"{Porta.porta}/mensagens";
                var client = new RestClient(url);
                var request = new RestRequest();
                var body = new EnviaViewModel { Email_Usuario_R = Email_R, Texto = texto, Imagem = null };
                var key = new RestSharp.Authenticators.JwtAuthenticator(Account.Account.tokens);
                request.Authenticator = key;
                request.AddJsonBody(body);
                var response = await client.PostAsync(request);
                string responseS = response.StatusCode.ToString() + "       " + response.Content.ToString();
            }
            catch
            {
            }
        }
        public async Task<string> RecebeMensagem(string Email_R)
        {
            try
            {
                string url = $"{Porta.porta}/mensagens/{Email_R}";
                var client = new RestClient(url);
                var request = new RestRequest();
                var key = new RestSharp.Authenticators.JwtAuthenticator(Account.Account.tokens);
                request.Authenticator = key;
                var response = await client.PostAsync(request);
                string responseS = response.StatusCode.ToString() + "       " + response.Content.ToString();
                Chat_Mensagens.responseS = responseS;
                return responseS;
            }
            catch
            {
                return "";

            }
        }
        public async Task<string> RecebeTodasMensagens()
        {
            try
            {
                string url = $"{Porta.porta}/mensagens/email";
                var client = new RestClient(url);
                var request = new RestRequest();
                var key = new RestSharp.Authenticators.JwtAuthenticator(Account.Account.tokens);
                request.Authenticator = key;
                var response = await client.GetAsync(request);
                string responseS = response.Content.ToString();
                Chat_Mensagens.responseS = responseS;
                return responseS;
            }
            catch
            {
                return "";

            }
        }
        public void RecebeMensagemT(string Email_R)
        {
            try
            {
                string url = $"{Porta.porta}/mensagens/{Email_R}";
                var client = new RestClient(url);
                var request = new RestRequest();
                var key = new RestSharp.Authenticators.JwtAuthenticator(Account.Account.tokens);
                request.Authenticator = key;
                var response =  client.Get(request);
                string responseS = response.Content.ToString();
                Chat_Mensagens.responseS2 = Chat_Mensagens.responseS;
                Chat_Mensagens.responseS = responseS;
                url = $"http://localhost:5100/mensagens/new/{Email_R}";
                client = new RestClient(url);
                request = new RestRequest();
                request.Authenticator = key;
                response = client.Put(request);

            }
            catch {}
        }
        public async void EnviaMensagemImagem(string Email_R, byte[] imagem)
        {
            try
            {
                string url = $"{Porta.porta}/mensagens/imagem";
                var client = new RestClient(url);
                var request = new RestRequest();
                var body = new EnviaViewModel { Email_Usuario_R = Email_R, Texto = null, Imagem = imagem };
                var key = new RestSharp.Authenticators.JwtAuthenticator(Account.Account.tokens);
                request.Authenticator = key;
                request.AddJsonBody(body);
                var response = await client.PostAsync(request);
                string responseS = response.StatusCode.ToString() + "       " + response.Content.ToString();
            }
            catch
            {
            }
        }
    }
}
