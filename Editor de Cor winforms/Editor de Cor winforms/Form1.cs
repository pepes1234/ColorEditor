using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor_de_Cor_winforms
{
    public partial class Form1 : Form
    {
        Point? p = null;
        Bitmap bmp;
        Graphics g;
        Rectangle rec = new Rectangle(50, 50, 100, 100);
        Bitmap clip;
        Bitmap img;

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (o, e) =>
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
                {
                    clip = Clipboard.GetImage() as Bitmap;
                    if (clip == null)
                        return;

                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(clip, Point.Empty);
                    g.Dispose();
                    pb.Refresh();
                    img = clip;
                }
            };
            Load += delegate
            {
                bmp = new Bitmap(pb.Width, pb.Height);
                g = Graphics.FromImage(bmp);
                g.Clear(Color.White);
                pb.Image = bmp;
                pb.Refresh();
                tm.Start();
            };
            tm.Interval = 25;
            tm.Tick += delegate
            {
                if (clip == null)
                    return;
                g.Clear(Color.White);
                g.DrawImage(img, rec);
                drawrec(rec.X, rec.Y);
                drawrec(rec.X + rec.Width, rec.Y);
                drawrec(rec.X, rec.Y + rec.Height);
                drawrec(rec.X + rec.Width, rec.Y + rec.Height);
                pb.Refresh();

                void drawrec(int x, int y)
                {
                    g.FillRectangle(Brushes.White,
                        x - 3, y - 3, 6, 6);
                    g.DrawRectangle(Pens.Black,
                        x - 3, y - 3, 6, 6);
                }
            };

        }

        private void pb_MouseDown(object sender, MouseEventArgs e)
            => p = e.Location;

        private void pb_MouseUp(object sender, MouseEventArgs e)
            => p = null;

        private void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (p == null)
                return;
            mouseMove(p.Value, e.Location);
            p = e.Location;
        }
        private void mouseMove(Point p, Point q)
        {
            if (!rec.Contains(p))
                return;
            int dx = q.X - p.X,
                dy = q.Y - p.Y;

            if (contains(rec.X + rec.Width, rec.Y + rec.Height))
            {
                rec = new Rectangle(rec.X, rec.Y, rec.Width + dx, rec.Height + dy);
            }
            else if (contains(rec.X, rec.Y))
            {
                rec = new Rectangle(rec.X + dx, rec.Y + dy, rec.Width - dx, rec.Height - dy);
            }
            else if (contains(rec.X + rec.Width, rec.Y))
            {
                rec = new Rectangle(rec.X, rec.Y + dy, rec.Width + dx, rec.Height - dy);
            }
            else if (contains(rec.X, rec.Y + rec.Height))
            {
                rec = new Rectangle(rec.X + dx, rec.Y, rec.Width - dx, rec.Height + dy);
            }
            else
            {
                rec = new Rectangle(rec.X + dx, rec.Y + dy, rec.Width, rec.Height);
            }


            bool contains(int x, int y)
            {
                return new Rectangle(x - 3, y - 3, 6, 6)
                    .Contains(p);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

/*
 CODIGO RESIZAR IMAGEM:



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Point? p = null;
        Bitmap bmp;
        Graphics g;
        Rectangle rec = new Rectangle(50, 50, 100, 100);
        
        Bitmap img;
        public Form1()
        {
            InitializeComponent();
            img = Image.FromFile(@"C:\Users\Aluno\Desktop\imagem.png") as Bitmap;
            Load += delegate
            {
                bmp = new Bitmap(pb.Width, pb.Height);
                g = Graphics.FromImage(bmp);
                g.Clear(Color.White);
                pb.Image = bmp;
                tm.Start();
            };
            tm.Interval = 25;
            tm.Tick += delegate
            {
                g.Clear(Color.White);
                g.DrawImage(img, rec);
                drawrec(rec.X, rec.Y);
                drawrec(rec.X + rec.Width, rec.Y);
                drawrec(rec.X, rec.Y + rec.Height);
                drawrec(rec.X + rec.Width, rec.Y + rec.Height);
                pb.Refresh();

                void drawrec(int x, int y)
                {
                    g.FillRectangle(Brushes.White, 
                        x - 3, y - 3, 6, 6);
                    g.DrawRectangle(Pens.Black, 
                        x - 3, y - 3, 6, 6);

                }
            };

        }

        private void pb_MouseDown(object sender, MouseEventArgs e)
            => p = e.Location;

        private void pb_MouseUp(object sender, MouseEventArgs e)
            => p = null;

        private void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (p == null)  
                return;
            mouseMove(p.Value, e.Location);
            p = e.Location;
        }
        private void mouseMove(Point p, Point q)
        {
            if (!rec.Contains(p))
                return;
            int dx = q.X - p.X,
                dy = q.Y - p.Y;

            if (contains(rec.X + rec.Width, rec.Y + rec.Height))
            {
                rec = new Rectangle(rec.X, rec.Y, rec.Width + dx, rec.Height + dy);
            }
            else if(contains(rec.X, rec.Y))
            {
                //rec = new Rectangle(rec.X, rec.Y, rec.Width - rec.X, rec.Height - rec.Y);
                rec = new Rectangle(rec.X + dx, rec.Y + dy, rec.Width - dx, rec.Height - dy);
            }
            else if(contains(rec.X + rec.Width, rec.Y))
            {
                rec = new Rectangle(rec.X, rec.Y + dy, rec.Width + dx, rec.Height - dy);
                //x negativo, y positivo
            }
            else if (contains(rec.X, rec.Y + rec.Height))
            {
                rec = new Rectangle(rec.X + dx, rec.Y, rec.Width - dx, rec.Height + dy);
            }
            else
            {
                rec = new Rectangle(rec.X + dx, rec.Y + dy, rec.Width, rec.Height);
            }
            

            bool contains(int x, int y)
            {
                return new Rectangle(x - 3, y - 3, 6, 6)
                    .Contains(p);
            }
        }
    } 
  
  
 *using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (o, e) =>
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V) // Ctrl + v
                {
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(Clipboard.GetImage(), Point.Empty);
                    g.Dispose();
                    pb.Refresh();

                    //if (colorDialog1.ShowDialog() == DialogResult.OK)
                    //    pb.BackColor = colorDialog1.Color;


                }
            };

            Load += delegate
            {
                bmp = new Bitmap(pb.Width, pb.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.White);
                g.DrawEllipse(Pens.Black, pb.Width / 4, pb.Height / 4, pb.Width / 2, pb.Height / 2);
                g.Dispose();
                pb.Image = bmp;
            };

            pb.MouseDown += (s, e) =>
            {
               


                BitmapData data = bmp.LockBits(
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb); // Format24bppArgb rgb

                byte[] img = new byte[data.Height * data.Stride];
                Marshal.Copy(data.Scan0, img, 0, img.Length);

                int x = e.Location.X,
                   y = e.Location.Y;

                int clickindex = y * data.Stride + 4 * x;

                int b = img[clickindex],
                    g = img[clickindex + 1],
                    r = img[clickindex + 2],
                    a = img[clickindex + 3];

                if (b == 255 && g == 255 && r == 0 && a == 255)
                    goto end;

                Stack<int> stack = new Stack<int>();

                stack.Push(clickindex);

                while (stack.Count > 0)
                {
                    int i = stack.Pop();
                    
                    if (i < 0 || i >= img.Length)
                        continue;


                    if (img[i] != b || img[i + 1] != g ||
                        img[i + 2] != r || img[i + 3] != a)
                        continue;

                    img[i] = 255;
                    img[i + 1] = 255;
                    img[i + 2] = 0;
                    img[i + 3] = 255;
                    if ((i + 4) % data.Stride != 0)
                        stack.Push(i + 4); // Pixel a direita;
                    if (i % data.Stride != 0)
                        stack.Push(i - 4); // Pixel a esquerda
                    stack.Push(i + data.Stride);
                    stack.Push(i - data.Stride);

                    
                }


                //for(int j = 0; j < data.Height; j++)
                //{
                //    for(int i = 0; i < data.Width; i++)
                //    {
                //        //int index = j * data.Stride + 4 * i; // Indice da primeira posição de cada pixel.
                //        //img[index] = 0;    // b
                //        //img[index + 1] = (byte)(0 + i);  // g
                //        //img[index + 2] = (byte)(111 + j); // r
                //        //img[index + 3] = (byte)(255 + i - j); // a

                //        int index = j * data.Stride + 4 * i;
                //        if (img[index] == 0 && img[index + 3] == 255)
                //            img[index + 2] = 255;

                //    }
                //}



                Marshal.Copy(img, 0, data.Scan0, img.Length);

                end:
                    bmp.UnlockBits(data);
                    pb.Refresh();
                
            };


            Teste teste = new Teste();
            teste.Valor = 65;
            teste.OtoValor = "OtoValoreesssssssssssssssssss";

            BinaryFormatter formatter = new BinaryFormatter();
            
            Stream stream = new FileStream(
                @"C:\Users\Aluno\Documents\olamundo.wordskills.txt",
                FileMode.Create, FileAccess.Write, FileShare.None);

            
            formatter.Serialize(stream, teste);
            stream.Close();

            stream = new FileStream(
                @"C:\Users\Aluno\Documents\olamundo.wordskills.txt",
                FileMode.Open, FileAccess.Read, FileShare.Read);
            Teste obj = (Teste)formatter.Deserialize(stream);
            stream.Close();

            // bmp.Save("garaio.png"); Salva imagens
        }

    }
}

[Serializable]
public class Teste
{
    public int Valor { get; set; }
    public string OtoValor { get; set; }
}





}*/