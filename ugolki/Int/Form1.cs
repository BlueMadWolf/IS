using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Int
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.ScaleTransform(1, -1);
            g.TranslateTransform(0, -pictureBox1.Height);

            drawLines();
            drawDigits();
        }

        Graphics g;
        Pen pen = new Pen(Color.Black);

        private void drawLines()
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            int w = width / 9;
            int h = height / 9;

            for (int i = 1; i < 9; ++i)
            {
                g.DrawLine(pen, w * i, 0, w * i, height);
                g.DrawLine(pen, 0, h * i, width, h * i);
            }

            pictureBox1.Image = pictureBox1.Image;
        }

        private void drawDigits()
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            int w = width / 9;
            int h = height / 9;

            

            pictureBox1.Image = pictureBox1.Image;
        }
    }
}
