namespace Editor_de_Cor_winforms
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pb = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tm = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.BackColor = System.Drawing.Color.White;
            this.pb.Location = new System.Drawing.Point(23, 1);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(635, 451);
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(664, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Salvar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tm
            // 
            this.tm.Interval = 25;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(664, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 30);
            this.button3.TabIndex = 3;
            this.button3.Text = "Criar Poligono";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Escolha Arquivo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(664, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Modo Edição";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pb);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer tm;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
    }
}

