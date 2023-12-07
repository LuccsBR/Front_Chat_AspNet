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

namespace Desafio_Chat_Front
{
    public class Tela_Inicial
    {

        public async Task<List<string>> GetByEmail(string email)
        {
            try
            {
                string url = $"{Porta.porta}/account/{email}";
                var client = new RestClient(url);
                var request = new RestRequest();
                var key = new RestSharp.Authenticators.JwtAuthenticator(Account.Account.tokens);
                request.Authenticator = key;
                var response =await client.GetAsync(request);
                string responseS = response.Content.ToString();
                var jsonObject = JsonConvert.DeserializeObject<JObject>(responseS);
                List<string> dados = new List<string>();
                dados.Add((string)jsonObject["user"]["email"]);
                dados.Add((string)jsonObject["user"]["name"]);
                return dados;
            }
            catch 
            {
                return null;
            }    

        }
        public class EmailViewModel
        {
            public string Email { get; set; }
        }
    }
}
