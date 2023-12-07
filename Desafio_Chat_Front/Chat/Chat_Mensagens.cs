using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Desafio_Chat_Front
{
    public partial class Chat_Mensagens : Form
    {
        public static string Email_E = Login.email;
        public static string Email_R = TelaInicial.email_S;
        public static string responseS = "";
        public static int i = 0;
        public static int i2 = 0;
        public static int i3 = -1;
        public static string responseS2 = "";
        public static bool verifica = true;
        public static byte[] imagem;

        public class Usuario
        {
            public string email { get; set; }
            public string name { get; set; }
            public string password { get; set; }
            public string image { get; set; }
            public string role { get; set; }
        }
        public class Mensagem
        {

            public int id { get; set; }
            public Usuario id_Usuario_E { get; set; }
            public Usuario id_Usuario_R { get; set; }
            public string texto { get; set; }
            public byte[] image { get; set; }
            public DateTime horario { get; set; }

            [JsonProperty("new")]
            public bool newMessage { get; set; }
        }
        public Chat_Mensagens()
        {
            InitializeComponent();
            i2 = 0;
            i3 = -1;
            txt_Chat.ScrollBars  = RichTextBoxScrollBars.Vertical;
            i--;
            Email_E = Login.email;
            Email_R = TelaInicial.email_S;
            verifica = true;
            Chat_ chat_ = new Chat_();

            Thread mythread2 = new Thread(() =>
            {
                while (verifica == true)
                {

                    Thread.Sleep(1000);
                    chat_.RecebeMensagemT(Email_R);
                    TextoT();
                }

            });
            mythread2.Start();

        }

        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            if (txt_Mensagem.Text != "")
            {

                Chat_ chat_ = new Chat_();
                chat_.EnviaMensagem(Email_R, txt_Mensagem.Text);
                txt_Mensagem.Text = null;
            }
            else if (lbl_Image.Text != "Image ???")
            {
                Chat_ chat_ = new Chat_();
                chat_.EnviaMensagemImagem(Email_R, imagem);
                txt_Mensagem.Text = null;
                txt_Mensagem.Enabled = true;
                lbl_Image.Text = "Image ???";

            }
        }
        public void Texto()
        {

            List<Mensagem> mensagens = JsonConvert.DeserializeObject<List<Mensagem>>(responseS).OrderBy(m => m.id).ToList(); ;
            if (mensagens.Count != i && InvokeRequired)
            {
                txt_Chat2.Invoke((MethodInvoker)delegate
                {
                    txt_Chat2.Text = "";
                    for (int i = 0; i < mensagens.Count; i++)
                    {
                        if (mensagens[i].newMessage == true)
                            txt_Chat2.AppendText(mensagens[i].id_Usuario_E.name + ": " + mensagens[i].texto + Environment.NewLine + "          " + " ✅   " + mensagens[i].horario.ToString());
                        if (mensagens[i].newMessage != true)
                            txt_Chat2.AppendText(mensagens[i].id_Usuario_E.name + ": " + mensagens[i].texto + Environment.NewLine + "          " + " ✅✅  " + mensagens[i].horario.ToString());
                        txt_Chat2.AppendText("\r\n");
                    }
                });
                i = mensagens.Count;
            }

        }
        public void TextoT()
        {
            try
            {
                List<Mensagem> mensagens = JsonConvert.DeserializeObject<List<Mensagem>>(responseS).OrderBy(m => m.id).ToList(); 
                for(int a= 0;a < mensagens.Count;a++)
                {
                    if (mensagens[a].newMessage == true) i2++;
                }
                if(i2 != i3)
                {
                    txt_Chat.Invoke((MethodInvoker)delegate
                    {
                    txt_Chat.Enabled = false;
                    txt_Chat.ReadOnly = false;
                    txt_Chat.Text = "";
                    for (int i = 0; i < mensagens.Count; i++)
                    {
                        if (mensagens[i].texto == null)
                        {
                            if (mensagens[i].newMessage == true)
                            {
                                txt_Chat.AppendText(mensagens[i].id_Usuario_E.name + ": ");
                                var newImage = ResizeImage(ConvertBinaryTolmage(mensagens[i].image), 110, 80);
                                Image imagem23 = newImage;
                                Clipboard.SetImage(imagem23);
                                txt_Chat.Paste();
                                txt_Chat.AppendText(Environment.NewLine + "          " + " ✅   " + mensagens[i].horario.ToString());

                            }
                            else
                            {
                                    txt_Chat.AppendText(mensagens[i].id_Usuario_E.name + ": ");
                                    var newImage = ResizeImage(ConvertBinaryTolmage(mensagens[i].image), 110, 80);
                                    Image imagem23 = newImage;
                                    Clipboard.SetImage(imagem23);
                                    txt_Chat.Paste();
                                    txt_Chat.AppendText(Environment.NewLine + "          " + " ✅✅  " + mensagens[i].horario.ToString());
                                    Clipboard.Clear();
                                }
                                txt_Chat.AppendText("\r\n");

                            }
                            else
                            {
                                if (mensagens[i].newMessage == true)
                                    txt_Chat.AppendText(mensagens[i].id_Usuario_E.name + ": " + mensagens[i].texto + Environment.NewLine + "          " + " ✅   " + mensagens[i].horario.ToString());
                                if (mensagens[i].newMessage != true)
                                    txt_Chat.AppendText(mensagens[i].id_Usuario_E.name + ": " + mensagens[i].texto + Environment.NewLine + "          " + " ✅✅  " + mensagens[i].horario.ToString());
                                txt_Chat.AppendText("\r\n");
                            }
                        }
                        txt_Chat.Enabled = true;
                        txt_Chat.ReadOnly = true;
                        i3 =i2;
                    });
                }
                i2 = 0;
                i = mensagens.Count;

            }
            catch { }


        }

        private void btn_Imagem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofg = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofg.ShowDialog() == DialogResult.OK)
                {
                    lbl_Image.Text = ofg.FileName;
                    txt_Mensagem.Enabled = false;
                    txt_Mensagem.Text = null;
                    imagem = ConvertImageToBinary(Image.FromFile(ofg.FileName));

                }


            }
        }
        byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {

                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        Image ConvertBinaryTolmage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);

            }

        }
        Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);

                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }

}
            