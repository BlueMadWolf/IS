using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neural_network
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Width = 200;
            pictureBox1.Height = 200;

            dist_to_center_to = 20;
            radius_from = 35;
            radius_to = 50;

            rand = new Random();
        }

        private static Graphics g;
        private static Bitmap bmp;
        private Random rand;

        int dist_to_center_to, radius_from, radius_to;

        private System.IO.StreamWriter writer = new System.IO.StreamWriter("debug.txt");

        private void clear()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            bmp = (Bitmap)pictureBox1.Image;
        }

        private void drawLine(Point p1, Point p2)
        {
            //g.DrawLine(new Pen(Color.Black), new Point((int)p1.X, (int)p1.Y), new Point((int)p2.X, (int)p2.Y));
            g.DrawLine(new Pen(Color.Black), p1, p2);
        }

        private void drawLine(int x1, int y1, int x2, int y2)
        {
            g.DrawLine(new Pen(Color.Black), new Point(x1, y1), new Point(x2, y2));
        }

        private void drawCircle(int x, int y, int w)
        {
            g.DrawEllipse(new Pen(Color.Black), x, y, w, w);
        }

        private void drawSin()
        {
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            int width = rand.Next(radius_from, radius_to) * 2;
            int height = rand.Next(radius_from, radius_to) * 2;
            int x = w / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - width / 2;
            int y = h / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - height / 2;
        }

        private void drawRectangle()
        {
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            int width = rand.Next(radius_from, radius_to) * 2;
            int height = rand.Next(radius_from, radius_to) * 2;
            int x = w / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - width/2;
            int y = h / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - height/2;

            g.DrawRectangle(new Pen(Color.Black), x, y, width, height);

            writer.WriteLine("x = " + x.ToString() + " | y = " + y.ToString() + 
                " | w = " + width.ToString() + " | h = " + height.ToString());
            writer.Flush();
        }

        private void drawTriangle()
        {
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            int r = rand.Next(radius_from, radius_to);
            int x1 = w / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - r;
            int x2 = w / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) + r;
            //int x3 = rand.Next(x1, x2);
            int x3 = (x2 + x1) / 2;
            int y1 = h / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) + r;
            int y2 = y1;
            int y3 = h / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - r;

            drawLine(x1, y1, x2, y2);
            drawLine(x2, y2, x3, y3);
            drawLine(x3, y3, x1, y1);
        }

        private void drawCircle()
        {
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            int r = rand.Next(radius_from, radius_to);
            int x = w / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - r;
            int y = h / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - r;

            drawCircle(x, y, r*2);

            writer.WriteLine("x = " + x.ToString() + " | y = " + y.ToString() + " | w = " + (r * 2).ToString());
            writer.Flush();
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            clear();
            drawRectangle();
            pictureBox1.Image = pictureBox1.Image;
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            clear();
            drawTriangle();
            pictureBox1.Image = pictureBox1.Image;
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            clear();
            drawCircle();
            pictureBox1.Image = pictureBox1.Image;
        }

        private void buttonSin_Click(object sender, EventArgs e)
        {
            clear();
            drawSin();
            pictureBox1.Image = pictureBox1.Image;
        }
    }
}
