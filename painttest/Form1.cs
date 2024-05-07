﻿using System;
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

        public Form1()
        {
            InitializeComponent();
        }

        void draw(int x, int y)
        {
            // Rita en ifylld ellips i bmp genom graphics (se rad 45)
            graphics.FillEllipse(pen.Brush, x, y, size, size);

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
    }
}