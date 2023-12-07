using Desafio_Chat_Front.Account;
using Desafio_Chat_Front.Properties;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using Tulpep.NotificationWindow;
using static Desafio_Chat_Front.Chat_Mensagens;

namespace Desafio_Chat_Front
{
    public partial class TelaInicial : Form
    {
       
        public static string email;
        public static string email_S;
        public static string Nome_S;
        public static int i = 0;
        public static int i2 = 0;
        public static int i3 = 0;

        public static bool verifica = true;

        public TelaInicial()
        {
            InitializeComponent();
            txt_Senha.UseSystemPasswordChar = true;
            textBox1.UseSystemPasswordChar = true;
            Chat_ chat_ = new Chat_();
            i--;
            i2--;
            Thread mythread1 = new Thread(async () =>
            {
                while (true == true)
                {
                    while (verifica == true && Login.logou == true)
                    {
                        Thread.Sleep(500);
                        var resposta = await chat_.RecebeTodasMensagens();
                        Mensagem(resposta);
                    }

                }

            });

            mythread1.Start();

        }
            private async void btn_Adicionar_Click(object sender, EventArgs e)
        {
            string message, title, defaultValues;
            message = "Digite o email do outro usuário";
            title = "Adicionar";
            defaultValues = "";
            email = Interaction.InputBox(message, title, defaultValues).ToString();
            Tela_Inicial tena_Inicial = new Tela_Inicial();
            if (Login.email != email)
            {
                var user = await tena_Inicial.GetByEmail(email);
                if (user != null) listBox1.Items.Add("User:" + user[1] + ".   " + "Email:" + user[0]);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure went to remove this user", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)


                listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItem.ToString() != null)
                {
                    var obj = listBox1.SelectedItem.ToString();
                    string[] substrings = obj.Split(':');
                    Nome_S = substrings[1].Trim();
                    string[] substrings2 = Nome_S.Split('.');
                    Nome_S = substrings2[0].Trim();
                    email_S = substrings[2].Replace("🔴", string.Empty);
                    Chat_Mensagens chat = new Chat_Mensagens();
                    verifica = false;
                    chat.ShowDialog();
                    Chat_Mensagens.verifica = false;
                    verifica = true;
                    i++;
                }
            }
            catch { }


        }
        public void Mensagem(string mensagensJson)
        {
            if (Login.logou == true)
            {
                HashSet<(string email, string name)> emailsNomesUnicos = new HashSet<(string email, string name)>();
                if (mensagensJson != "")
                {
                    List<Mensagem> mensagens = JsonConvert.DeserializeObject<List<Mensagem>>(mensagensJson).OrderBy(m => m.id).ToList();
                    var mensagensFiltradas = mensagens.FindAll(m => m.id_Usuario_R.email == Login.email);
                        listBox1.Invoke((MethodInvoker)delegate
                        {
                            foreach (var mensagem in mensagens)
                            {
                                if (mensagem.id_Usuario_E != null)
                                {
                                    emailsNomesUnicos.Add((mensagem.id_Usuario_E.email, mensagem.id_Usuario_E.name));
                                }
                                if (mensagem.id_Usuario_R != null)
                                {
                                    emailsNomesUnicos.Add((mensagem.id_Usuario_R.email, mensagem.id_Usuario_R.name));
                                }
                            }
                            for (int a = 0; a < mensagens.Count; a++)
                            {
                                if (mensagens[a].newMessage == true) i2++;
                            }
                            if (i2 != i3)
                            {
                                listBox1.Items.Clear();
                                foreach (var (email, name) in emailsNomesUnicos)
                                {
                                    if (email != Login.email)
                                        listBox1.Items.Add("User:" + name + ".   " + "Email:" + email);
                                }
                                var mensagensAgrupadas = mensagensFiltradas
                            .GroupBy(m => m.id_Usuario_E.email)
                             .SelectMany(group => group.OrderByDescending(m => m.id).Take(1)).ToList();
                                listBox1.Invoke((MethodInvoker)delegate
                                {
                                    if (email != Login.email)
                                    {
                                        for (int i = 0; i < mensagensAgrupadas.Count; i++)
                                        {

                                            if (mensagensAgrupadas[i].newMessage != true)
                                            {

                                                for (int i2 = 0; i2 < listBox1.Items.Count; i2++)
                                                {
                                                    if (listBox1.Items[i2].ToString() == "User:" + mensagensAgrupadas[i].id_Usuario_E.name + ".   " + "Email:" + mensagensAgrupadas[i].id_Usuario_E.email + " 🔴")
                                                    {

                                                        listBox1.Items[i2] = "User:" + mensagensAgrupadas[i].id_Usuario_E.name + ".   " + "Email:" + mensagensAgrupadas[i].id_Usuario_E.email;
                                                    }
                                                }
                                            }
                                            else if (mensagensAgrupadas[i].newMessage == true)
                                            {
                                                for (int i2 = 0; i2 < listBox1.Items.Count; i2++)
                                                {
                                                    if (listBox1.Items[i2].ToString() == "User:" + mensagensAgrupadas[i].id_Usuario_E.name + ".   " + "Email:" + mensagensAgrupadas[i].id_Usuario_E.email)
                                                    {

                                                        listBox1.Items[i2] = "User:" + mensagensAgrupadas[i].id_Usuario_E.name + ".   " + "Email:" + mensagensAgrupadas[i].id_Usuario_E.email + " 🔴";
                                                        PopupNotifier popup = new PopupNotifier();
                                                        popup.Image = Properties.Resources.Info;
                                                        popup.TitleText = "Nova Mensagem";
                                                        popup.ContentText = "Você possui uma mensagem nova de  " + mensagensAgrupadas[i].id_Usuario_E.name;
                                                        popup.Popup();
                                                    }
                                                }
                                            }
                                        }
                                    }

                                });
                            }
                                
                        });
                        i = mensagens.Count;
                    i3=  i2;
                    i2 = 0;

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Visible= true;
            panel2.Visible = false;
            panel3.Visible = false;



        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            verifica = false;
            i = 0;
        }

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_Email.Text != null && txt_Senha.Text != null)
            {
                Account.Account account = new Account.Account();
                string retorno = await account.LoginServer(txt_Email.Text, txt_Senha.Text);
                if (retorno == Account.Account.tokens)
                {
                    Login.email = txt_Email.Text;
                    Login.logou = true;
                    panel3.Visible= false;
                    panel2.Visible = false;
                    verifica = true;
                    i = 0;
                    txt_Email.Text = "";
                    txt_Senha.Text = "";
                    i2--;
                }
                else if (retorno == "Usuario ou senha incorretas")
                {
                    MessageBox.Show(retorno);
                }
            }
        }

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && txt_Nome.Text != "")
            {
                if (textBox1.ForeColor != Color.Red && textBox2.ForeColor != Color.Red)
                {

                        Account.Account account = new Account.Account();
                        string retorno = account.SignUpServer(textBox2.Text, textBox1.Text, txt_Nome.Text);
                        MessageBox.Show(retorno);
                        if (retorno == "OK       ")
                        {
                            panel4.Visible = false;
                        }
                }
                else
                {
                    MessageBox.Show("Email ou senha não validos");
                }
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios");
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            txt_Nome.Text = "";
            panel4.Visible=false;
            panel2.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txt_Email.Text = "";
            txt_Senha.Text = "";
            panel3.Visible = false;
            panel2.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txt_Senha.UseSystemPasswordChar == true)
                txt_Senha.UseSystemPasswordChar = false;
            else txt_Senha.UseSystemPasswordChar = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.UseSystemPasswordChar == true)
                textBox1.UseSystemPasswordChar = false;
            else textBox1.UseSystemPasswordChar = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length >= 7 && textBox1.Text.Any(char.IsUpper) == true && textBox1.Text.Any(char.IsNumber) == true)
            {
                textBox1.ForeColor = Color.Black;

            }
            else
            {
                textBox1.ForeColor = Color.Red;

            }

        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            contextMenuStrip1.ForeColor= Color.Blue;
            contextMenuStrip1.Show(Cursor.Position);

        }
            static bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmail(textBox2.Text) == true)
            {
                textBox2.ForeColor = Color.Black;

            }
            else
            {
                textBox2.ForeColor = Color.Red;

            }
        }
    }
}

