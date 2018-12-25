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
        float brushWidth = 2f;

        double n;
        NeuralNet net;
        int last_picture = 0;

        public Form1()
        {
            InitializeComponent();
            Invalidate();

            pictureBox1.Width = Width;
            pictureBox1.Height = Height;

            //зададим диапазон изменений при построении фигуры
            dist_to_center_to = 5;
            radius_from = 30;
            radius_to = 35;

            rand = new Random();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            foreach (Control c in Controls)
            {
                if (c.Name != "button4")
                    c.Visible = false;
            }
        }

        private static Graphics g;
        private static Bitmap bmp;
        private Random rand;
        bool drawing_now = false;
        List<Point> drawed_points = new List<Point>();
        LinkedList<Tuple<List<double>, int>> sensors_class = new LinkedList<Tuple<List<double>, int>>();

        int dist_to_center_to, radius_from, radius_to;

        private System.IO.StreamWriter writer = new System.IO.StreamWriter("debug.txt");


        //  -------------------------------- отрисовка фигур -----------------------------------------

        private void clear()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
        }

        private void drawLine(Point p1, Point p2)
        {
            g.DrawLine(new Pen(Color.Black, brushWidth), p1, p2);
        }

        private void drawLine(int x1, int y1, int x2, int y2)
        {
            g.DrawLine(new Pen(Color.Black, brushWidth), new Point(x1, y1), new Point(x2, y2));
        }

        private void drawCircle(int x, int y, int w)
        {
            g.DrawEllipse(new Pen(Color.Black, brushWidth), x, y, w, w);
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

            g.DrawCurve(new Pen(Color.Black, brushWidth), points);
            pictureBox1.Image = pictureBox1.Image;

            
        }

        private void drawSinHor()
        {
            clear();
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            int width = rand.Next(radius_from, radius_to) * 5;
            int height = rand.Next(radius_from, radius_to);
            int x = (w + rand.Next(-dist_to_center_to, dist_to_center_to) - width / 2);
            int y = h / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - height / 2;

            Point[] points = new Point[width];
            for (int i = 0; i < width; ++i)
            {
                double k = sin(i) + 1;
                points[i] = new Point((x + i)/2, y + (int)(k * height) / 2);
            }

            g.DrawCurve(new Pen(Color.Black, brushWidth), points);
            pictureBox1.Image = pictureBox1.Image;

            last_picture = 3;
        }

        private void drawRectangle()
        {
            clear();
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            int width = rand.Next(radius_from, radius_to) * 2 + 4;
            int height = rand.Next(radius_from, radius_to) * 2;
            int x = w / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - width/2;
            int y = h / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - height/2;

            g.DrawRectangle(new Pen(Color.Black, brushWidth), x, y, width, height);

            writer.WriteLine("x = " + x.ToString() + " | y = " + y.ToString() + 
                " | w = " + width.ToString() + " | h = " + height.ToString());
            writer.Flush();

            pictureBox1.Image = pictureBox1.Image;

            last_picture = 0;
        }

        private void drawTriangle()
        {
            clear();

            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            int r = rand.Next(radius_from, radius_to);
            int x1 = w / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - r;
            int x2 = w / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) + r;
            int x3 = rand.Next(x1, x2);
       
            int y1 = h / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) + r + 10;
            int y2 = y1;
            int y3 = h / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - r;

            drawLine(x1, y1, x2, y2);
            drawLine(x2, y2, x3, y3);
            drawLine(x3, y3, x1, y1);

            pictureBox1.Image = pictureBox1.Image;

            last_picture = 1;
        }

        private void drawCircle()
        {
            clear();
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            int r = rand.Next(radius_from, radius_to);
            int x = w / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - r/2;
            int y = h / 2 + rand.Next(-dist_to_center_to, dist_to_center_to) - r/2;

            drawCircle(x, y, r);

            writer.WriteLine("x = " + x.ToString() + " | y = " + y.ToString() + " | w = " + (r * 2).ToString());
            writer.Flush();

            pictureBox1.Image = pictureBox1.Image;

            last_picture = 2;
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
            
        }

        private void buttonSinVert_Click(object sender, EventArgs e)
        {
            drawSinVert();
        }

        private void buttonSinHor_Click(object sender, EventArgs e)
        {
            drawSinHor();
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
                    if ((c.R + c.G + c.B) < 127 * 3)
                    {
                        ++sum;
                    }
                }
                l.Add(sum);// / (double)Width);
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
                l.Add(sum);// / (double)Width);
            }

            return l;
        }

        //Выводит на форму вероятность принадлежности нарисованной фигуры к каждому классу
        private void predictVisible(List<double> l)
        {
            double sum = l.Sum();

            itIsRectangle(l[0] / sum);
            itIsTriangle(l[1] / sum);
            itIsCircle(l[2] / sum);
            itIsSinHor(l[3] / sum);
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


        //возвращает ошбку для выходного слоя сети
        public List<double> createErrorValue(List<double> inL, int c)
        {
            double realize_max = inL[c]; //значение выхода правильного класса
            double max = 0; // максимальная разница между нашим классом и классами, имеющими больший выход

            List<double> res = new List<double>();

            for (int i = 0; i < inL.Count(); ++i)
                if (inL[i] > realize_max)
                {
                    res.Add(realize_max - inL[i]);
                    if (inL[i] - realize_max > max)
                        max = inL[i] - realize_max;
                }
                else
                    res.Add(0);
            res[c] = inL[c] + max;

            return res;
        }

        private void progress(int n)
        {
            progressBar1.Value = n;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = Double.Parse(textBox1.Text);
            int cnt_right = 0;
            int cnt_images = Int32.Parse(textBoxCountTrainPictures.Text);
            progressBar1.Maximum = cnt_images;
            for (int i = 0; i < cnt_images; ++i)
            {
                progress(i);

                int c = i % 4;
                switch (c)
                {
                     case 0:
                         drawRectangle();
                         break;
                     case 1:
                         drawTriangle();
                         break;
                     case 2:
                         drawCircle();
                         break;
                     case 3:
                         drawSinHor();
                         break;

                }

                List<double> sensors = getSensors();
                List<double> p = predict(sensors);

                sensors_class.AddLast(Tuple.Create(sensors, c));
                if (sensors_class.Count() > 100)
                    sensors_class.RemoveFirst();

                if (Math.Abs(p[c] - p.Max()) > 0.01) //если разница больше, то запускаем обратное распространение ошибки
                { 
                    List<double> d = createErrorValue(p, c);
                    net.backpropagation(d, n);
                }
                else
                {
                    ++cnt_right;
                }

                if (i > 8 && cnt_right / i > 0.75) //досрочное завершение
                    break;
              
            }
            int cnt_right_old = Int32.Parse(labelCountOfRightPredictedPictures.Text);
            labelCountOfRightPredictedPictures.Text = (cnt_right_old + cnt_right).ToString();
            int cnt_old = Int32.Parse(labelCountOfTrainPictures.Text);
            labelCountOfTrainPictures.Text = (cnt_old + cnt_images).ToString();
            textBox1.Text = n.ToString();
        }


        public List<double> predict(List<double> sensors, bool f = false)
        {
            return net.predict(sensors, f);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox1.Image;
            List<double> sensors = getSensors();
            List<double> p = predict(sensors, true);

            show_res(net.s);
            predictVisible(p); //выводит отладочную информацию по предсказанию на форму
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxOutput.Text += e.KeyCode.ToString() + " | ";

            if (e.KeyCode == Keys.D1)
            {
                drawRectangle();
            }

            if (e.KeyCode == Keys.D2)
            {
                drawTriangle();
            }

            if (e.KeyCode == Keys.D3)
            {
                drawCircle();
            }

            if (e.KeyCode == Keys.D4)
            {
                drawSinHor();
            }

            if (e.KeyCode == Keys.T)
            {
                button1_Click(this, new EventArgs());
            }

            if (e.KeyCode == Keys.P)
            {
                button2_Click(sender, e);
            }
            if (e.KeyCode == Keys.A)
            {
                List<double> sensors = getSensors();
                List<double> p = predict(sensors, true);

                show_res(net.s);
                predictVisible(p);

                if (p.Max() - p[last_picture] > 0.001)
                {
                    List<double> d = createErrorValue(p, last_picture);
                    n = Double.Parse(textBox1.Text);
                    net.backpropagation(d, n);
                }

                sensors_class.AddLast(Tuple.Create(sensors, last_picture));
                if (sensors_class.Count() > 100)
                    sensors_class.RemoveFirst();
            }
        }

        //находит индекс максимального выхода
        private int indexOfMax(List<double> p)
        {
            int imax = 0;
            double max = p[0];
            for (int i = 0; i < p.Count(); ++i)
            {
                if (p[i] > max)
                {
                    max = p[i];
                    imax = i;
                }
            }

            return imax;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int cnt = 0;

            foreach (var item in sensors_class)
            {
                List<double> sensors = item.Item1;
                List<double> p = predict(sensors, false);
                int pred = indexOfMax(p);

                if ((p[pred] - p[item.Item2]) < 0.001)
                    ++cnt;
            }

            labelLast100.Text = ((double)cnt / sensors_class.Count()).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //создаем сеть с 4 слоями: 1 входной - 400 нейронов, 1ый скрытый - 100, 2ой скрытый - 16, выходной - 4
            net = new NeuralNet(400, 100, 16, 4);

            button4.Visible = false;

            foreach (Control c in Controls)
            {
                if (c.Name != "button4")
                    c.Visible = true;
            }
        }


    }

    //======================== Работа с нейронной сетью ============================
    public class NeuralNet
    {
        int input_cnt, layer1_cnt, layer2_cnt, out_cnt;
     

        public string s;

        List<double> inputLayer = new List<double>(); //входной слой
        List<double> layer1 = new List<double>(); //первый скрытый слой
        List<double> layer2 = new List<double>(); // второй скрытый слой
        List<double> outputLayer = new List<double>(); // выходной слой

        List<List<double>> inputlink = new List<List<double>>(); // матрица весов между входным и 1ым скрытым
        List<List<double>> matr1 = new List<List<double>>(); //матрица весов между скрытыми слоями
        List<List<double>> matr2 = new List<List<double>>(); // матрица весов между вторым скрытым и выходным слоями

        delegate double func_activation (double x);
        func_activation f;

        public NeuralNet(int cnt, int first, int second, int o, double alpha = 1)
        {
            input_cnt = cnt;
            layer1_cnt = first;
            layer2_cnt = second;
            out_cnt = o;

            for (int i = 0; i < cnt; ++i)
                inputLayer.Add(0); 
            for (int i = 0; i < first; ++i) 
                layer1.Add(0);
            for (int i = 0; i < second; ++i)
                layer2.Add(0);
            for (int i = 0; i < o; ++i)
                outputLayer.Add(0);

            createConnections();

            //f = (x) => Math.Exp(-x / 2);
            //f = (x) => 1.0 / (1 + Math.Exp(-2*alpha*x));
            f = (x) => 1.0 / (1 + Math.Exp(-x));

            //f = (x) => (x == 0) ? 0 : (x);

        }

        //создание рандомных связей между сенсорами и первым скрытым слоем (веса всегда == 1)
        private void randomFLink()
        {
            Random rnd = new Random(0);

            for (int i = 0; i < input_cnt; ++i)
            {
                int cntLinks = layer1_cnt; // rnd.Next(100, (int)Math.Floor(0.7 * firstLayer)); //кол-во связей для данного сенсора

                double oldc = 0;
                List<double> l = new List<double>();
                for (int j = 0; j < cntLinks; ++j)
                {
                    //int neighbour = rnd.Next(0, firstLayer - 1);
                    //while (inputlink.ContainsKey(i) && inputlink[i].Contains(neighbour))
                    //  neighbour = rnd.Next(0, firstLayer - 1);
                    double c = rnd.NextDouble(); // *2 - 1;
                  /*  while(Math.Abs(c - oldc) < 0.01)
                        c = rnd.NextDouble() + 0.5;*/
                    l.Add(c);//c);//c > 1 ? 1 : c);
                    oldc = c;
                }

                inputlink.Add(l);
            }
        }

        //создаем изначально связи (рандомные)
        private void createConnections()
        {
            randomFLink();
            Random rnd = new Random();

            for (int i = 0; i < layer1_cnt; ++i)
            {
                List<double> l = new List<double>();
                for (int j = 0; j < layer2_cnt; ++j)
                    l.Add(0);// rnd.NextDouble());
                matr1.Add(l);
            }

            for (int i = 0; i < layer2_cnt; ++i)
            {
                List<double> l = new List<double>();
                for (int j = 0; j < out_cnt; ++j)
                    l.Add(rnd.NextDouble());
                matr2.Add(l);
            }
        }

        private void clearLayer1()
        {
            for (int i = 0; i < layer1_cnt; ++i)
                layer1[i] = 0;
        }

        //предсказываем ответ по заданным значениям
        public List<double> predict(List<double> sensors, bool fl = false)
        {
            for (int i = 0; i < input_cnt; ++i)
                inputLayer[i] = sensors[i];

            clearLayer1();

            for (int i = 0; i < input_cnt; ++i) //принимаем веса от входного слоя layer1[j] = sum_i(sensors(i))
                for (int j = 0; j < layer1_cnt; ++j)
                    layer1[j] += inputLayer[i] * inputlink[i][j];

            double max = layer1.Max();
            double min = layer1.Min();

            for (int i = 0; i < layer1_cnt; ++i) //применяем сигмоид ко всем нейронам данного слоя
                layer1[i] = f((max - min) == 0 ? 0 : (layer1[i]-min)/(max-min));

            //вычисляем второй скрытый слой
            for (int j = 0; j < layer2_cnt; ++j)
            {
                double sum = 0;
                for (int i = 0; i < layer1_cnt; ++i)
                    sum += layer1[i] * matr1[i][j];
                layer2[j] = sum;
            }

            max = layer2.Max();
            min = layer2.Min();

            for (int j = 0; j < layer2_cnt; ++j)
                layer2[j] = f((max - min) == 0 ? 0 :(layer2[j] - min) / (max - min));

            //значение выходного слоя просчитываем
            for (int j = 0; j < out_cnt; ++j)
            {
                double sum = 0;
                for (int i = 0; i < layer2_cnt; ++i)
                    sum += layer1[i] * matr2[i][j];
                outputLayer[j] = sum; //f(sum)
            }

            max = outputLayer.Max();
            min = outputLayer.Min();
            for (int j = 0; j < out_cnt; ++j)
                outputLayer[j] = (max - min) == 0 ? 0 : f((outputLayer[j] - min) / (max - min));
                
            if (fl)
                show();

            return outputLayer;
        }

        //отладочная информация
        private string show()
        {

            s = "";
            double cnt = 0;
            for(int i = 0; i < input_cnt; ++i)
                for (int j = 0; j < layer1_cnt; ++j)
                   cnt += inputlink[i][j];

            s += (cnt / (input_cnt * layer1_cnt)).ToString() + " ";

            s += Environment.NewLine + Environment.NewLine;

            cnt = 0;
            for (int i = 0; i < layer1_cnt; ++i)
                for (int j = 0; j < layer2_cnt; ++j)
                    cnt += matr1[i][j];
            s += (cnt / (input_cnt * layer1_cnt)).ToString() + " ";

            s += Environment.NewLine + Environment.NewLine;
            /*
            for (int i = 0; i < secondLayer; ++i)
                s += layer2[i].ToString() + "  ";

            s += Environment.NewLine + Environment.NewLine;*/

            for (int i = 0; i < out_cnt; ++i)
                s += outputLayer[i].ToString() + "  ";
/*
            s += Environment.NewLine + Environment.NewLine;
            s += Environment.NewLine + Environment.NewLine;
            s += "WEIGHT";
            s += Environment.NewLine + Environment.NewLine;
            s += Environment.NewLine + Environment.NewLine;

            for (int i = 0; i < firstLayer; ++i)
                for (int j = 0; j < secondLayer; ++j)
                    s += matr1[i][j].ToString() + "  ";
            s += Environment.NewLine + Environment.NewLine;
            
            for (int i = 0; i < secondLayer; ++i)
                for (int j = 0; j < outCnt; ++j)
                    s += matr2[i][j].ToString() + "  ";*/

            return s;
        }

        public void backpropagation(List<double> eps0, double n = 1)
        {
            for (int i = 0; i < layer2_cnt; ++i)
                for (int j = 0; j < out_cnt; ++j)
                    matr2[i][j] += n * eps0[j] * layer2[i] * outputLayer[j] * (1 - outputLayer[j]); //изменяем веса связей 
            //между выходным и вторым скрытым слоем

            List<double> eps1 = new List<double>();

            //просчитываем ошибку второго скрытого слоя
            for (int i = 0; i < layer2_cnt; ++i)
            {
                double ed = 0;

                for (int j = 0; j < out_cnt; ++j)
                    ed += eps0[j] * matr2[i][j];
                eps1.Add(ed);
            }

            for(int i = 0; i < layer1_cnt; ++i)
                for (int j = 0; j < layer2_cnt; ++j)
                matr1[i][j] += n * eps1[j] * layer1[i] * layer2[j] * (1 - layer2[j]); //изменяем веса связей между скрытыми слоями


            //просчитываем ошибку первого скрытого слоя
            List<double> eps2 = new List<double>();

            for (int i = 0; i < layer1_cnt; ++i)
            {
                double ed = 0;

                for (int j = 0; j < layer2_cnt; ++j)
                    ed += eps1[j] * matr1[i][j];
                eps2.Add(ed); 
            }

            //изменяем веса связей между входным и первым скрытым слоями
            for (int i = 0; i < input_cnt; ++i)
                for (int j = 0; j < layer1_cnt; ++j)
                    inputlink[i][j] = n * eps2[j] * inputLayer[i] * layer1[j] * (1 - layer1[j]);
             
        }
    }
    
}
