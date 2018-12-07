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
        static int Width = 200;
        static int Height = Width;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Width = Width;
            pictureBox1.Height = Height;

            dist_to_center_to = 20;
            radius_from = 35;
            radius_to = 50;

            rand = new Random();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private static Graphics g;
        private static Bitmap bmp;
        private Random rand;
        bool drawing_now = false;
        List<Point> drawed_points = new List<Point>();

        int dist_to_center_to, radius_from, radius_to;

        private System.IO.StreamWriter writer = new System.IO.StreamWriter("debug.txt");

        private void clear()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            //if (!(bmp is null))
            //    bmp.Dispose();
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

        private double sin(int x)
        {
            return Math.Sin(x * Math.PI / 20);
        }

        private void drawSinVert()
        {
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            int width = rand.Next(radius_from, radius_to);
            int height = rand.Next(radius_from, radius_to) * 2;
            int x = w / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - width / 2;
            int y = h / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - height / 2;

            Point[] points = new Point[height];
            for (int i = 0; i < height; ++i)
            {
                double k = sin(i) + 1;
                points[i] = new Point(x + (int)(k * width) / 2, y + i);
            }

            g.DrawCurve(new Pen(Color.Black), points);
        }

        private void drawSinHor()
        {
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            int width = rand.Next(radius_from, radius_to) * 2;
            int height = rand.Next(radius_from, radius_to);
            int x = w / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - width / 2;
            int y = h / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - height / 2;

            Point[] points = new Point[width];
            for (int i = 0; i < width; ++i)
            {
                double k = sin(i) + 1;
                points[i] = new Point(x + i, y + (int)(k * height) / 2);
            }

            g.DrawCurve(new Pen(Color.Black), points);
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

        //---------------------------------------------------------------------------------------------
        //Возвращает список из 400 параметров
        private List<double> getSensors()
        {
            //bmp.Dispose();

            //bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);

            //bmp.Save("img.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

         
            int dist_to_borders = 0;

            List<double> l = new List<double>(Width + Height - dist_to_borders * 4);

            int sum = 0;

            //Добавление сенсоров по оси X
            for (int x = dist_to_borders; x < Width - dist_to_borders; ++x)
            {
                sum = 0;
                for (int y = dist_to_borders; y < Height - dist_to_borders; ++y)
                {
                    Color c = bmp.GetPixel(x, y);
                    if ((c.R + c.G + c.B) < 127*3)
                    {
                        ++sum;
                    }
                }
                l.Add(sum / (double)Width);
            }

            //Добавление сенсоров по оси Y
            for (int y = dist_to_borders; y < Height - dist_to_borders; ++y)
            {
                sum = 0;
                for (int x = dist_to_borders; x < Width - dist_to_borders; ++x)
                {
                    Color c = bmp.GetPixel(x, y);
                    if ((c.R + c.G + c.B) < 127 * 3)
                    {
                        ++sum;
                    }
                }
                l.Add(sum / (double)Width);
            }

            return l;
        }

        //Выводит на форму вероятность принадлежности нарисованной фигуры к каждому классу
        private void predict()
        {
            List<double> sensors = getSensors();

            textBoxOutput.Text += sensors.Count() + System.Environment.NewLine;

            foreach (var item in sensors)
            {
                textBoxOutput.Text += item.ToString() + System.Environment.NewLine;
            }

            itIsCircle(0);
            itIsRectangle(0);
            itIsSinVert(0);
            itIsTriangle(0);
            itIsSinHor(0);
        }



        //Выводит на форму вероятность того, что фигура принадлежит к классу Прямоугольник
        private void itIsRectangle(double probability)
        {
            if (probability <= 1)
            {
                progressBarRectangle.Value = (int)Math.Round(probability * 100);
                labelRectangle.Text = progressBarRectangle.Value.ToString() + "%";
            }
        }

        //Выводит на форму вероятность того, что фигура принадлежит к классу Треугольник
        private void itIsTriangle(double probability)
        {
            if (probability <= 1)
            {
                progressBarTriangle.Value = (int)Math.Round(probability * 100);
                labelTriangle.Text = progressBarTriangle.Value.ToString() + "%";
            }
        }

        //Выводит на форму вероятность того, что фигура принадлежит к классу Круг
        private void itIsCircle(double probability)
        {
            if (probability <= 1)
            {
                progressBarCircle.Value = (int)Math.Round(probability * 100);
                labelCircle.Text = progressBarCircle.Value.ToString() + "%";
            }
        }

        //Выводит на форму вероятность того, что фигура принадлежит к классу Синусоида Горизонтальная
        private void itIsSinHor(double probability)
        {
            if (probability <= 1)
            {
                progressBarSinHor.Value = (int)Math.Round(probability * 100);
                labelSinHor.Text = progressBarSinHor.Value.ToString() + "%";
            }
        }

        //Выводит на форму вероятность того, что фигура принадлежит к классу Синусоида Вертикальная
        private void itIsSinVert(double probability)
        {
            if (probability <= 1)
            {
                progressBarSinVert.Value = (int)Math.Round(probability * 100);
                labelSinVert.Text = progressBarSinVert.Value.ToString() + "%";
            }
        }

        private void drawPoints()
        {
            Point[] lp = new Point[drawed_points.Count()];
            
            for (int i = 0; i < drawed_points.Count(); ++i)
            {
                lp[i] = drawed_points[i];
            }

            g.DrawCurve(new Pen(Color.Black), lp);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drawed_points.Clear();
            drawing_now = true;
            drawed_points.Add(new Point(e.X, e.Y));
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drawed_points.Add(new Point(e.X, e.Y));
            drawing_now = false;

            clear();
            drawPoints();
            predict();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing_now)
            {
                drawed_points.Add(new Point(e.X, e.Y));

                clear();
                drawPoints();
            }
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            clear();
            drawRectangle();
            pictureBox1.Image = pictureBox1.Image;

            textBoxOutput.Text = "";
            predict();
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            clear();
            drawTriangle();
            pictureBox1.Image = pictureBox1.Image;

            textBoxOutput.Text = "";
            predict();
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            clear();
            drawCircle();
            pictureBox1.Image = pictureBox1.Image;

            textBoxOutput.Text = "";
            predict();
        }

        private void buttonSinVert_Click(object sender, EventArgs e)
        {
            clear();
            drawSinVert();
            pictureBox1.Image = pictureBox1.Image;

            textBoxOutput.Text = "";
            predict();
        }

        private void buttonSinHor_Click(object sender, EventArgs e)
        {
            clear();
            drawSinHor();
            pictureBox1.Image = pictureBox1.Image;

            textBoxOutput.Text = "";
            predict();
        }
    }

    //======================== Работа с нейронной сетью ============================
    public class NeuralNet
    {
        List<double> input = new List<double>(400);
        List<double> layer1 = new List<double>(800);
        List<double> layer2 = new List<double>(80);
        List<double> output = new List<double>(5);

        Dictionary<int, List<int>> inputlink = new Dictionary<int, List<int>>();
        List<List<double>> matr1 = new List<List<double>>();
        List<List<double>> matr2 = new List<List<double>>();

        public NeuralNet(List<double> sensors)
        {
            for (int i = 0; i < 400; ++i)
                input.Add(0); 
            for (int i = 0; i < 800; ++i) 
                layer1.Add(0);
            for (int i = 0; i < 80; ++i)
                layer2.Add(0);
            for (int i = 0; i < 5; ++i)
                output.Add(0);
        }

        //создание рандомных связей между сенсорами и первым скрытым слоем (веса всегда == 1)
        private void randomFLink()
        {
            for (int i = 0; i < 400; ++i)
            {
                Random rnd = new Random();
                int cntLinks = rnd.Next(1, 20); //кол-во связей для данного сенсора

                for (int j = 0; j < cntLinks; ++j)
                {
                    int neighbour = rnd.Next(0, 799);
                    while (inputlink.ContainsKey(i) && inputlink[i].Contains(neighbour))
                        neighbour = rnd.Next(0, 799);

                    if (!inputlink.ContainsKey(i))
                        inputlink.Add(i, new List<int>());

                    inputlink[i].Add(neighbour);
                    
                }
            }
        }



        //создаем изначально связи (рандомные)
        private void createConnections()
        {
            randomFLink();
        }

        //выводим значение наружу
        public List<double> returnResult()
        {
            List<double> res = new List<double>();
            foreach (var c in output)
                res.Add(c);

            return res;
        }
    }
    
}
