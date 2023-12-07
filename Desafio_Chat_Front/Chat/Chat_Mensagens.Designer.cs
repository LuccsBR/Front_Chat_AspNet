namespace Desafio_Chat_Front
{
    partial class Chat_Mensagens
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_Mensagem = new System.Windows.Forms.TextBox();
            this.lbl_Image = new System.Windows.Forms.Label();
            this.btn_Enviar = new System.Windows.Forms.Button();
            this.btn_Imagem = new System.Windows.Forms.Button();
            this.txt_Chat2 = new System.Windows.Forms.TextBox();
            this.txt_Chat = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txt_Mensagem
            // 
            this.txt_Mensagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Mensagem.Location = new System.Drawing.Point(12, 342);
            this.txt_Mensagem.Multiline = true;
            this.txt_Mensagem.Name = "txt_Mensagem";
            this.txt_Mensagem.Size = new System.Drawing.Size(746, 71);
            this.txt_Mensagem.TabIndex = 0;
            // 
            // lbl_Image
            // 
            this.lbl_Image.AutoSize = true;
            this.lbl_Image.Location = new System.Drawing.Point(12, 317);
            this.lbl_Image.Name = "lbl_Image";
            this.lbl_Image.Size = new System.Drawing.Size(57, 13);
            this.lbl_Image.TabIndex = 2;
            this.lbl_Image.Text = "Image ???";
            // 
            // btn_Enviar
            // 
            this.btn_Enviar.Location = new System.Drawing.Point(683, 419);
            this.btn_Enviar.Name = "btn_Enviar";
            this.btn_Enviar.Size = new System.Drawing.Size(75, 23);
            this.btn_Enviar.TabIndex = 3;
            this.btn_Enviar.Text = "Enviar";
            this.btn_Enviar.UseVisualStyleBackColor = true;
            this.btn_Enviar.Click += new System.EventHandler(this.btn_Enviar_Click);
            // 
            // btn_Imagem
            // 
            this.btn_Imagem.Location = new System.Drawing.Point(683, 312);
            this.btn_Imagem.Name = "btn_Imagem";
            this.btn_Imagem.Size = new System.Drawing.Size(75, 23);
            this.btn_Imagem.TabIndex = 4;
            this.btn_Imagem.Text = "Imagem";
            this.btn_Imagem.UseVisualStyleBackColor = true;
            this.btn_Imagem.Click += new System.EventHandler(this.btn_Imagem_Click);
            // 
            // txt_Chat2
            // 
            this.txt_Chat2.Enabled = false;
            this.txt_Chat2.Location = new System.Drawing.Point(13, 12);
            this.txt_Chat2.Multiline = true;
            this.txt_Chat2.Name = "txt_Chat2";
            this.txt_Chat2.Size = new System.Drawing.Size(692, 284);
            this.txt_Chat2.TabIndex = 5;
            // 
            // txt_Chat
            // 
            this.txt_Chat.Enabled = false;
            this.txt_Chat.Location = new System.Drawing.Point(15, 12);
            this.txt_Chat.Name = "txt_Chat";
            this.txt_Chat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txt_Chat.Size = new System.Drawing.Size(743, 284);
            this.txt_Chat.TabIndex = 6;
            this.txt_Chat.Text = "";
            // 
            // Chat_Mensagens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 450);
            this.Controls.Add(this.txt_Chat);
            this.Controls.Add(this.txt_Chat2);
            this.Controls.Add(this.btn_Imagem);
            this.Controls.Add(this.btn_Enviar);
            this.Controls.Add(this.lbl_Image);
            this.Controls.Add(this.txt_Mensagem);
            this.Name = "Chat_Mensagens";
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Mensagem;
        private System.Windows.Forms.Label lbl_Image;
        private System.Windows.Forms.Button btn_Enviar;
        private System.Windows.Forms.Button btn_Imagem;
        private System.Windows.Forms.TextBox txt_Chat2;
        private System.Windows.Forms.RichTextBox txt_Chat;
    }
}