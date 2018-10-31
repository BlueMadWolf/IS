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
        int comp_from = 0;
        int comp_to = 0;
        int step_number = 1;
        bool first_click_on_label1 = true;

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
                fs.Close();
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
                fs.Close();
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
        
        private string startUgolki(int from, int to)
        {
            
            Process proc = new Process();
            proc.StartInfo.FileName = exefname;
            proc.StartInfo.Arguments = posToChar(from).ToString() + ' ' + posToString(to).ToString();
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;

            proc.Start();
            proc.WaitForExit();

            string output = proc.StandardOutput.ReadToEnd();

            return output;
            
        }

        private bool getPositions(string output)
        {
            string[] strs1 = output.Split(' ');

            int n = Int32.Parse(strs1[0]);
            if (n == -1)
                return false;

            for (int i = 0; i < 12; ++i)
            {
                n = Int32.Parse(strs1[i]);
                if (positions1[i] != n)
                {
                    comp_from = positions1[i];
                    comp_to = n;
                    positions1[i] = n;
                }
                n = Int32.Parse(strs1[i+12]);
                if (positions2[i] != n)
                {
                    //position_to_delete = positions2[i];
                    positions2[i] = n;
                }
            }

            return true;
        }

        private void clearCheck(int pos)
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            int w = width / 8;
            int h = height / 8;

            int posx = w * (pos % 8) + (w / 4)-4;
            int posy = h * (pos / 8) + (h / 4)-4;

            g.FillEllipse(new SolidBrush(pictureBox1.BackColor), posx, posy, (w / 2)+8, (h / 2)+8);
        }

        private void clearCheckers()
        {
            foreach (var item in positions1)
            {
                clearCheck(item);
            }

            foreach (var item in positions2)
            {
                clearCheck(item);
            }
        }

        private void drawPoint(int pos, Color c)
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            int w = width / 8;
            int h = height / 8;

            pen.Width = 2;
            pen.Color = c;
            int posx = w * (pos % 8) + w / 3 + w/12;
            int posy = h * (pos / 8) + h / 3 + w/12;

            g.DrawEllipse(pen, posx, posy, w / 5, h / 5);

        }

        private int manh_dist(int from, int to)
        {
            int s1 = Math.Abs((from % 8) - (to % 8));
            int s2 = Math.Abs((from / 8) - (to / 8));
            return s1 + s2;
        }

        private int heuristic(List<int> positions, int best_pos)
        {
            int sum = 0;
            foreach (var item in positions)
            {
                sum += manh_dist(item, best_pos);
            }
            return sum;
        }

        private void updateHeuristics()
        {
            labelCompH.Text = heuristic(positions1, 63).ToString();
            labelManH.Text = heuristic(positions2, 0).ToString();
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
                
                drawPoint(comp_from, pictureBox1.BackColor);
                drawPoint(comp_to, pictureBox1.BackColor);
            }
            else
            {
                now_moving = false;
                clearCheck(moving_from);
                

                int posx = e.X / w;
                int posy = e.Y / h;

                int moving_to = posy * 8 + posx;

                string output = startUgolki(moving_from, moving_to);
                bool correct_step = getPositions(output);
                if (correct_step)
                {
                    step_number += 1;
                    labelStepNumber.Text = step_number.ToString();
                    updateHeuristics();

                    drawCheckers();
                    clearCheck(comp_from);
                    drawPoint(comp_from, Color.Red);
                    drawPoint(comp_to, Color.Red);
                }
                else
                {
                    label1.Visible = true;
                    label1.Text = "Некорректный шаг!\nНажмите на меня,\n чтобы продолжить!";
                    drawCheck(moving_from, Color.Green);
                } 
            }

            pictureBox1.Image = pictureBox1.Image;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (first_click_on_label1)
            {
                drawLines();
                drawDigits();

                positions_to_default();
                positions_from_file();

                drawCheckers();

                updateHeuristics();

                first_click_on_label1 = false;
            }

            label1.Visible = false;
        }
    }
}
