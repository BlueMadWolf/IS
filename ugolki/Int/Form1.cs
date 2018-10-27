using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Int
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            //g.ScaleTransform(1, -1);
            //g.TranslateTransform(0, -pictureBox1.Height);

            drawLines();
            drawDigits();

            positions_to_default();
            positions_from_file();

            drawCheckers();
        }

        string fname = "..//..//..//positions.txt";
        string exefname = "..//..//..//Ugolki.exe";
        Graphics g;
        Pen pen = new Pen(Color.Black);
        List<int> positions1 = new List<int>();
        List<int> positions2 = new List<int>();
        bool now_moving = false;
        int moving_from = 0;
        List<char> step_chars = new List<char> { '1', '2', '3', '4',
            '5', '6', '7', '8', '9','a', 'b', 'c'};
        List<char> step_letters = new List<char> { 'A', 'B', 'C', 'D',
            'E', 'F', 'G', 'H'};

        private void drawLines()
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            int w = width / 8;
            int h = height / 8;

            for (int i = 1; i < 8; ++i)
            {
                g.DrawLine(pen, w * i, 0, w * i, height);
                g.DrawLine(pen, 0, h * i, width, h * i);
            }

            pen.Width = 5;

            pen.Color = Color.Gold;
            g.DrawLine(pen, w * 4, 0, w * 4, h * 3);
            g.DrawLine(pen, 0, h * 3, w * 4, h * 3);

            pen.Color = Color.Green;
            g.DrawLine(pen, w * 4, h*5, w * 4, height);
            g.DrawLine(pen, w * 4, h * 5, width, h * 5);

            pictureBox1.Image = pictureBox1.Image;
        }

        private void drawDigits()
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            int w = width / 8;
            int h = height / 8;

            Font font = new Font("Arial", 8);
            SolidBrush brush = new SolidBrush(Color.Black);

            for (int i = 0; i < 64; ++i)
            {
                g.DrawString(i.ToString(), font, brush, w*(i%8), h*(i/8));
            }

            pictureBox1.Image = pictureBox1.Image;
        }

        private void positions_to_default()
        {
            using (StreamWriter fs = new StreamWriter(fname))
            {
                List<int> l1 = new List<int> { 0, 1, 2, 3, 8, 9, 10, 11, 16, 17, 18, 19 };
                List<int> l2 = new List<int> { 63, 62, 61, 60, 55, 54, 53, 52, 47, 46, 45, 44 };

                foreach (var item in l1)
                {
                    fs.Write(item + " ");
                }
                fs.WriteLine();
                foreach (var item in l2)
                {
                    fs.Write(item + " ");
                }
                fs.WriteLine();
            }
        }

        private void positions_from_file()
        {
            using (StreamReader fs = new StreamReader(fname))
            {
                string s1 = fs.ReadLine();
                string s2 = fs.ReadLine();

                string[] strs1 = s1.Split(' ');
                string[] strs2 = s2.Split(' ');

                for (int i = 0; i < 12; ++i)
                {
                    positions1.Add(Convert.ToInt32(strs1[i]));
                    positions2.Add(Convert.ToInt32(strs2[i]));
                }
            }
        }

        private void drawCheck(int pos, Color c)
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            int w = width / 8;
            int h = height / 8;

            pen.Width = 2;
            pen.Color = c;
            int posx = w * (pos % 8) + w/4;
            int posy = h * (pos / 8) + h/4;

            g.DrawEllipse(pen, posx, posy, w/2, h/2);

        }

        private void drawCheckers()
        {
            foreach (var item in positions1)
            {
                drawCheck(item, Color.Gold);
            }

            foreach (var item in positions2)
            {
                drawCheck(item, Color.Green);
            }
        }

        private void fillChecker(int pos, Color c)
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            int w = width / 8;
            int h = height / 8;
            
            int posx = w * (pos % 8) + w / 4;
            int posy = h * (pos / 8) + h / 4;

            g.FillEllipse(new SolidBrush(c), posx, posy, w / 2, h / 2);
        }

        private char posToChar(int pos)
        {
            int p = positions1.IndexOf(pos);
            if (p == -1)
            {
                p = positions2.IndexOf(pos);
                if (p != -1)
                    return step_chars[p];
                else
                    return 'w';
            }
            else
                return step_chars[p];
        }

        private string posToString(int pos)
        {
            string s = "";
            int indx = pos % 8;
            int indy = pos / 8;

            s += step_letters[indx];
            s += step_chars[indy];

            return s;
        }
        
        private bool tryDoDtep(int from, int to)
        {
            
            Process proc = new Process();
            proc.StartInfo.FileName = exefname;
            proc.StartInfo.Arguments = "";
            proc.Start();
            proc.WaitForExit();

            return false;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            int w = width / 8;
            int h = height / 8;

            if (now_moving == false)
            {
                now_moving = true;

                int posx = e.X / w;
                int posy = e.Y / h;

                moving_from = posy * 8 + posx;

                fillChecker(moving_from, Color.Red);
                //posToChar(moving_from);
                //posToString(moving_from);
            }
            else
            {
                now_moving = false;
                fillChecker(moving_from, pictureBox1.BackColor);
                drawCheck(moving_from, Color.Green);

                int posx = e.X / w;
                int posy = e.Y / h;

                int moving_to = posy * 8 + posx;
                //posToChar(moving_to);
                //posToString(moving_to);

            }

            pictureBox1.Image = pictureBox1.Image;
        }
    }
}
