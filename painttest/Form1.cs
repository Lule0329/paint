using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace painttest
{
    public partial class Form1 : Form
    {
        int size = 10;

        Pen pen = new Pen(Brushes.Black);
        Bitmap bmp;
        Graphics graphics;
        string filename = "";
        string type = "fEllipse";

        public Form1()
        {
            InitializeComponent();
        }

        void draw(int x, int y)
        {
            

            // Rita en ifylld ellips i bmp genom graphics (se rad 45)
            if (type == "fEllipse")
            {
                graphics.FillEllipse(pen.Brush, x - size / 2, y - size / 2, size, size);
            }
            else if (type == "ellipse")
            {
                graphics.DrawEllipse(pen, x - size / 2, y - size / 2, size, size);
            }
            else if (type == "fRectangle")
            {
                graphics.FillRectangle(pen.Brush, x - size / 2, y - size / 2, size, size);
            }
            else if (type == "rectangle")
            {
                graphics.DrawRectangle(pen, x - size / 2, y - size / 2, size, size);
            }

            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draw(e.X, e.Y);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Skapa en bitmap som är lika stor som pictureboxen
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            // Skapa en ny Graphics klass som ritar i den nya bitmapen
            graphics = Graphics.FromImage(bmp);

            pictureBox1.Image = bmp;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Öppna colorDialog1 och kolla så att man inte avbröt eller stängde fönstret utan att trycka på OK.
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.Transparent);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                Image img = Image.FromFile(filename);
                bmp = new Bitmap(img);

                graphics = Graphics.FromImage(bmp);

                ClientSize = new Size(img.Width, img.Height + menuStrip1.Height);

                pictureBox1.Image = bmp;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
            {
                bmp.Save(filename, ImageFormat.Png);
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog1.FileName;
                    bmp.Save(filename, ImageFormat.Png);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
                bmp.Save(filename, ImageFormat.Png);
            }
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(bmp.Width, bmp.Height, this);
            form2.ShowDialog();
        }

        public void resize(int width, int height, bool scale)
        {
            ClientSize = new Size(width, height);
        }

        private void fillWithBrushColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphics.Clear(pen.Color);
            this.Refresh();
        }

        private void filledEllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = "fEllipse";
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = "ellipse";
        }

        private void filledRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = "fRectangle";
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = "rectangle";
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            size = 5;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            size = 10;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            size = 20;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            size = 35;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            size = 50;
        }
    }
}