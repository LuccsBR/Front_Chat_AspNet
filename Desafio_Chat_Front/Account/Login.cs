using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio_Chat_Front
{
    public partial class Login : Form
    {
        public static bool logou = false;
        public static string email=" ";
        public Login()
        {
            InitializeComponent();
        }
            private async void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_Email.Text != null && txt_Senha.Text != null)
            {
                Account.Account account = new Account.Account();
                string retorno = await account.LoginServer(txt_Email.Text, txt_Senha.Text);
                if (retorno == Account.Account.tokens)
                {
                    email = txt_Email.Text;
                    logou = true;
                    Close();
                }else if (retorno == "Usuario ou senha incorretas")
                {
                    MessageBox.Show(retorno);
                }
            }
        }
    }
}
