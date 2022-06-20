using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    public partial class Form1 : Form
    {
        Bitmap pic;
        int x1, y1;
        Pen p = new Pen(Color.Black);
        public Form1(int w = 800, int h = 600)
        {
            //конструктор
            InitializeComponent();
            pic = new Bitmap(w, h);
            x1 = y1 = 0;

        }
        
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            //выбор цвета
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog2.Color;
                p.Color = color;
            }
        }

        private void pictureBox2_MouseMove_1(object sender, MouseEventArgs e)
        {
            //функция рисования
            p.Width = trackBar2.Value;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Graphics g;
            g = Graphics.FromImage(pic);

            if (e.Button == MouseButtons.Left)
            {
                g.DrawLine(p, x1, y1, e.X, e.Y);
                pictureBox2.Image = pic;
            }
            x1 = e.X;
            y1 = e.Y;
            label1.Text = x1.ToString() + "," + y1.ToString();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //очистка
            Graphics g = Graphics.FromImage(pictureBox2.Image);
            g.Clear(Color.White);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //открыть проект
            openFileDialog2.ShowDialog();
            
            if (openFileDialog2.FileName != "")
            {
                Graphics g = Graphics.FromImage(pictureBox2.Image);
                g.Clear(Color.White); 
                pic = (Bitmap)Image.FromFile(openFileDialog2.FileName);
                pictureBox2.Image = pic;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //сохранить
            saveFileDialog2.ShowDialog();
            if (saveFileDialog2.FileName != "")
                pic.Save(saveFileDialog2.FileName);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            //закрыть
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //новый проект
            var new1 = new WindowsFormsApp1.New();
            new1.Show();
        }
        
    }
}
