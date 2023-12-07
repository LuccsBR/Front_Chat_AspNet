using Desafio_Chat_Front.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio_Chat_Front
{
    public partial class Painel : Form
    {
        public Painel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login oi = new Login();
            oi.ShowDialog();
            if(Login.logou == true)
            {
                TelaInicial telaInicial= new TelaInicial();
                telaInicial.ShowDialog();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp oi = new SignUp();
            oi.ShowDialog();
        }
    }
}
