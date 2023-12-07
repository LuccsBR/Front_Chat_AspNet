using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Desafio_Chat_Front.Account
{
    public class LoginViewModel
    {
        public string Email { get; set; } 
        public string Password { get; set; } 
    }
    public class SignUpViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

    }
    public class Account
    {
        public static string tokens = " ";
        public async Task<string> LoginServer(string email, string password)
        {
            try
            {
                string url = $"{Porta.porta}/account/login";
                var client = new RestClient(url);
                var request = new RestRequest();
                var body = new LoginViewModel { Email = email, Password = password };
                request.AddJsonBody(body);
                var response = client.Post(request);
                string responseS = response.Content.ToString();
                var jsonObject = JsonConvert.DeserializeObject<JObject>(responseS);
                string token = jsonObject["token"].Value<string>();
                tokens = token;
                return token;
            }
            catch
            {
                return "Usuario ou senha incorretas";
            }

        }
        public string SignUpServer(string email, string password, string nome)
        {
            try
            {
                string url = $"{Porta.porta}/account/Signup";
                var client = new RestClient(url);
                var request = new RestRequest();
                var body = new SignUpViewModel { Email = email, Password = password, Name = nome };
                request.AddJsonBody(body);
                var response = client.Post(request);
                string responseS = response.StatusCode.ToString() + "       " + response.Content.ToString();
                return responseS;
            }
            catch
            {
                return "Email já cadastrado"; 
            }
            
        }
    }
}
