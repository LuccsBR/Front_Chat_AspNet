using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio_Chat_Front.Account
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            if(txt_Email.Text != null && txt_Nome.Text != null && txt_Senha.Text != null)
            {
                Account account = new Account();
                string retorno = account.SignUpServer(txt_Email.Text, txt_Senha.Text, txt_Nome.Text);
                MessageBox.Show(retorno);
                if (retorno == "OK       ")
                {
                    Close();
                }
            }
           
        }
    }
}
