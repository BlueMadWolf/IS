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

        NeuralNet net;

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

            button1.Visible = false;
            button2.Visible = false;
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

        public void show_res(string s)
        {
            textBoxOutput.Text = s;
        }

        private void drawSinVert()
        {
            clear();
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
            pictureBox1.Image = pictureBox1.Image;
        }

        private void drawSinHor()
        {
            clear();
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
            pictureBox1.Image = pictureBox1.Image;
        }

        private void drawRectangle()
        {
            clear();
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

            pictureBox1.Image = pictureBox1.Image;
        }

        private void drawTriangle()
        {
            clear();

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

            pictureBox1.Image = pictureBox1.Image;
        }

        private void drawCircle()
        {
            clear();
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            int r = rand.Next(radius_from, radius_to);
            int x = w / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - r;
            int y = h / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - r;

            drawCircle(x, y, r*2);

            writer.WriteLine("x = " + x.ToString() + " | y = " + y.ToString() + " | w = " + (r * 2).ToString());
            writer.Flush();

            pictureBox1.Image = pictureBox1.Image;
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
        private void predictVisible( List<double> l)
        {
            double sum = 0;
            for (int i = 0; i < l.Count(); ++i)
                sum += l[i];

            itIsRectangle(l[0]);// / sum);
            itIsTriangle(l[1]);// / sum);
            itIsCircle(l[2]);/// sum);
            itIsSinVert(l[3]);// / sum);
            itIsSinHor(l[4]);// / sum);
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
            drawRectangle();
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            drawTriangle();
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            drawCircle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            net = new NeuralNet(400, 800, 80, 5);
            button1.Visible = true;
            button2.Visible = true;
        }

        public List<double> createD(List<double> inL, int c)
        {
            double realize_max = inL[c];

            List<double> res = new List<double>();
            double max = 0;

            for (int i = 0; i < inL.Count(); ++i)
                if (i != c && inL[i] >= realize_max && inL[i] - realize_max > max)
                    max = inL[i];

            max = max == 0? 0 : max - realize_max + 0.0001;

            for (int i = 0; i < inL.Count(); ++i)
                if (inL[i] > realize_max)
                    res.Add(inL[i] - max);
                else
                    res.Add(inL[i]);
            res[c] = inL[c] + max;

            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; ++i)
            {
                List<double> p, d;

                drawRectangle();
                for (int j = 0; j < 10; ++j)
                {
                    p = predict();
                    d = createD(p, 0);
                    net.backpropagation(d, 20);
                }

                drawTriangle();
                for (int j = 0; j < 10; ++j)
                {
                    p = predict();
                    d = createD(p, 1);
                    net.backpropagation(d, 20);
                }

                drawCircle();
                for (int j = 0; j < 10; ++j)
                {
                    p = predict();
                    d = createD(p, 2);
                    net.backpropagation(d, 20);
                }

                drawSinVert();
                for (int j = 0; j < 10; ++j)
                {
                    p = predict();
                    d = createD(p, 3);
                    net.backpropagation(d, 20);
                }

                drawSinHor();
                for (int j = 0; j < 10; ++j)
                {
                    p = predict();
                    d = createD(p, 4);
                    net.backpropagation(d, 20);
                }
            }
        }

        public List<double> predict(bool f = false)
        {
            List<double> sensors = getSensors();

           /* textBoxOutput.Text += sensors.Count() + System.Environment.NewLine;
            foreach (var item in sensors)
                textBoxOutput.Text += item.ToString() + "  ";
                */
            return net.predict(sensors, f);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<double> p = predict(true);

            show_res(net.s);
            predictVisible(p);
        }

        private void buttonSinVert_Click(object sender, EventArgs e)
        {
            drawSinVert();
        }

        private void buttonSinHor_Click(object sender, EventArgs e)
        {
            drawSinHor();
        }
    }

    //======================== Работа с нейронной сетью ============================
    public class NeuralNet
    {
        int start_cnt, firstLayer, secondLayer, outCnt;

        public string s;

        List<double> input = new List<double>();
        List<double> layer1 = new List<double>();
        List<double> layer2 = new List<double>();
        List<double> output = new List<double>();

        Dictionary<int, List<int>> inputlink = new Dictionary<int, List<int>>();
        List<List<double>> matr1 = new List<List<double>>();
        List<List<double>> matr2 = new List<List<double>>();

        delegate double func_activation (double x);
        func_activation f;

        public NeuralNet(int cnt, int first, int second, int o)
        {
            start_cnt = cnt;
            firstLayer = first;
            secondLayer = second;
            outCnt = o;

            for (int i = 0; i < cnt; ++i)
                input.Add(0); 
            for (int i = 0; i < first; ++i) 
                layer1.Add(0);
            for (int i = 0; i < second; ++i)
                layer2.Add(0);
            for (int i = 0; i < o; ++i)
                output.Add(0);

            createConnections();

            f = (x) => 1.0 / (1 + Math.Exp(-x));
        }

        //создание рандомных связей между сенсорами и первым скрытым слоем (веса всегда == 1)
        private void randomFLink()
        {
            Random rnd = new Random();

            for (int i = 0; i < start_cnt; ++i)
            {
                int cntLinks = rnd.Next(1, firstLayer - 1); //кол-во связей для данного сенсора

                for (int j = 0; j < cntLinks; ++j)
                {
                    int neighbour = rnd.Next(0, 3 * firstLayer / 4 );
                    while (inputlink.ContainsKey(i) && inputlink[i].Contains(neighbour))
                        neighbour = rnd.Next(0, firstLayer - 1);

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
            Random rnd = new Random();

            for (int i = 0; i < firstLayer; ++i)
            {
                List<double> l = new List<double>();
                for (int j = 0; j < secondLayer; ++j)
                    l.Add(rnd.NextDouble());
                matr1.Add(l);
            }

            for (int i = 0; i < secondLayer; ++i)
            {
                List<double> l = new List<double>();
                for (int j = 0; j < outCnt; ++j)
                    l.Add(rnd.NextDouble());
                matr2.Add(l);
            }
        }

        //предсказываем ответ по заданным значениям
        public List<double> predict(List<double> sensors, bool fl = false)
        {
            for (int i = 0; i < start_cnt; ++i)
                input[i] = sensors[i];

            foreach (var k in inputlink.Keys) //принимаем веса от входного слоя layer1[j] = sum_i(sensors(i))
                foreach (var j in inputlink[k])
                    layer1[j] += input[k];

            for (int i = 0; i < firstLayer; ++i) //применяем сигмоид ко всем (?)
                layer1[i] = f(layer1[i]);

            //вычисляем второй скрытый слой
            for (int j = 0; j < secondLayer; ++j)
            {
                double sum = 0;
                for (int i = 0; i < firstLayer; ++i)
                    sum += layer1[i] * matr1[i][j];
                layer2[j] = sum;
            }

            double max = layer2.Max();
            for (int j = 0; j < secondLayer; ++j)
                layer2[j] = f(layer2[j] / max);

            //значение выходного слоя просчитываем
            for (int j = 0; j < outCnt; ++j)
            {
                double sum = 0;
                for (int i = 0; i < secondLayer; ++i)
                    sum += layer1[i] * matr2[i][j];
                output[j] = sum; //f(sum)
            }

            max = output.Max();
            for (int j = 0; j < outCnt; ++j)
                output[j] = f(output[j] / max);

            if (fl)
                show();

            return output;
        }

        
        private string show()
        {

            s = "";
            for(int i = 0; i < firstLayer; ++i)
                   s += layer1[i].ToString() + "  ";

            s += Environment.NewLine + Environment.NewLine;

            for (int i = 0; i < secondLayer; ++i)
                s += layer2[i].ToString() + "  ";

            s += Environment.NewLine + Environment.NewLine;

            for (int i = 0; i < outCnt; ++i)
                s += output[i].ToString() + "  ";

            return s;
        }

        public void backpropagation(List<double> d, double n = 1)
        {
            List<double> eps0 = new List<double>();
            for (int i = 0; i < outCnt; ++i)
                eps0.Add(d[i] - output[i]); //просчет ошибки для выходного слоя

            for (int i = 0; i < secondLayer; ++i)
                for (int j = 0; j < outCnt; ++j)
                    matr2[i][j] += n * eps0[j] * layer2[i]; //изменяем веса

            List<double> eps1 = new List<double>();

            for (int i = 0; i < secondLayer; ++i)
            {
                double ed = 0;

                for (int j = 0; j < outCnt; ++j)
                    ed += eps0[j] * matr2[i][j];
                eps1.Add(ed);
            }

            for(int i = 0; i < firstLayer; ++i)
                for (int j = 0; j < secondLayer; ++j)
                matr1[i][j] += n * eps1[j] * layer1[i]; //изменяем веса
        }
    }
    
}
