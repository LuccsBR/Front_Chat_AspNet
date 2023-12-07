using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio_Chat_Front.Chat
{
    public partial class Image : UserControl
    {
        public static System.Drawing.Image image;

        public Image()
        {
            InitializeComponent();
            pictureBox1.Image = image ;
        }

    }
}
