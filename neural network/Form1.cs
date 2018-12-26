using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using System.Globalization;

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

        static SpeechSynthesizer ss = new SpeechSynthesizer();
        static SpeechRecognitionEngine sre;

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

            InitSpeech();
        }

        private void InitSpeech()
        {
            System.Globalization.CultureInfo ci;
            ci = new System.Globalization.CultureInfo("ru-ru");
            sre = new SpeechRecognitionEngine(ci);

            ss.SetOutputToDefaultAudioDevice();
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);

            Choices PredictCommands = new Choices();
            PredictCommands.Add("угадай");
            PredictCommands.Add("что");
            PredictCommands.Add("это");
            PredictCommands.Add("ну");
            PredictCommands.Add("давай");
            //PredictCommands.Add("speech off");
            //PredictCommands.Add("klatu barada nikto");

            GrammarBuilder gb_Predict = new GrammarBuilder();
            gb_Predict.Append(PredictCommands);

            Grammar g_Predict = new Grammar(gb_Predict);
            sre.LoadGrammarAsync(g_Predict);

            sre.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string txt = e.Result.Text;

            button2_Click(this, new EventArgs());
        }

        private static Graphics g;
        private static Bitmap bmp;
        private Random rand;
        bool drawing_now = false;
        List<Point> drawed_points = new List<Point>();
        LinkedList<Tuple<List<double>, int>> sensors_class1 = new LinkedList<Tuple<List<double>, int>>();

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
          //  double max = 0; // максимальная разница между нашим классом и классами, имеющими больший выход

            List<double> res = new List<double>();

            for (int i = 0; i < inL.Count(); ++i)
                res.Add(- inL[i]);
            res[c] = 1 - inL[c];

            return res;
        }

        private void progress(int n)
        {
            progressBar1.Value = n;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = Double.Parse(textBox1.Text);
            double ac = Double.Parse(textBox2.Text);
            int cnt_right = 0;
            int cnt_images = Int32.Parse(textBoxCountTrainPictures.Text);
            progressBar1.Maximum = cnt_images * 10;



            for (int i = 0; i < cnt_images; ++i)
            {
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

                sensors_class1.AddLast(Tuple.Create(sensors, c));
                while (sensors_class1.Count() > cnt_images)
                    sensors_class1.RemoveFirst();
            }

            int k = 0;
            for (int i = 0; i < 10; ++i)
                foreach (var item in sensors_class1)
                {
                    progress(k++);
                    List<double> sensors = getSensors();
                    List<double> p = predict(item.Item1);

                    int z = 0;

                    Debug.WriteLine("");
                    Debug.WriteLine("k:  ");
                    while (Math.Abs(p[item.Item2] - p.Max()) > ac && z < 30) //если разница больше, то запускаем обратное распространение ошибки
                    {
                        List<double> d = createErrorValue(p, item.Item2);
                        net.backpropagation(d, n); z++;
                        Debug.WriteLine(" Class: " + item.Item2.ToString() + "   try: " + z.ToString());
                        Debug.WriteLine(net.show());
                        p = predict(item.Item1);
                    }
                    if (z == 0)
                        cnt_right++;

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

            int res = indexOfMax(p);
            string s = "";
            switch (res)
            {
                case 0:
                    s = "Квадрат";
                    break;
                case 1:
                    s = "Треугольник";
                    break;
                case 2:
                    s = "Круг";
                    break;
                case 3:
                    s = "Синусоида";
                    break;
            }
            ss.SpeakAsync(s);
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

            for (int i = 0; i < 100; ++i)
            {
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
                int pred = indexOfMax(p);

                if ((p[pred] - p[i%4]) < 0.001)
                    ++cnt;
            }

            labelLast100.Text = ((double)cnt / 100).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //создаем сеть с 4 слоями: 1 входной - 400 нейронов, 1ый скрытый - 100, 2ой скрытый - 16, выходной - 4
            net = new NeuralNet(400, 400, 4);

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
        int input_cnt, layer_cnt,  out_cnt;
        List<double> eps_l = new List<double>();
        List<double> eps_out = new List<double>();

        public string s;

        List<double> inputLayer = new List<double>(); //входной слой
        List<double> layer = new List<double>(); //первый скрытый слой
        List<double> outputLayer = new List<double>(); // выходной слой

        List<List<double>> inputlink = new List<List<double>>(); // матрица весов между входным и 1ым скрытым
        List<List<double>> matr = new List<List<double>>(); //матрица весов между скрытыми слоями
      
        delegate double func_activation (double x);
        func_activation f;

        public NeuralNet(int cnt, int first, int o, double alpha = 1)
        {
            input_cnt = cnt;
            layer_cnt = first;
            out_cnt = o;

            for (int i = 0; i < cnt; ++i)
                inputLayer.Add(0);
            inputLayer.Add(1);

            for (int i = 0; i < first; ++i)
            {
                layer.Add(0);
                eps_l.Add(0);
            }
            layer.Add(1);


            for (int i = 0; i < o; ++i)
            {
                outputLayer.Add(0);
                eps_out.Add(0);
            }

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

            for (int i = 0; i < input_cnt + 1; ++i)
            {
                int cntLinks = layer_cnt; // rnd.Next(100, (int)Math.Floor(0.7 * firstLayer)); //кол-во связей для данного сенсора

                double oldc = 0;
                List<double> l = new List<double>();
                for (int j = 0; j < cntLinks; ++j)
                {
                    double c = rnd.NextDouble(); 
                    l.Add(c);
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

            for (int i = 0; i < layer_cnt + 1; ++i)
            {
                List<double> l = new List<double>();
                for (int j = 0; j < out_cnt; ++j)
                    l.Add(rnd.NextDouble());
                matr.Add(l);
            }
        }

        private void clearLayer1()
        {
            for (int i = 0; i < layer_cnt; ++i)
                layer[i] = 0;
        }

        //предсказываем ответ по заданным значениям
        public List<double> predict(List<double> sensors, bool fl = false)
        {
            for (int i = 0; i < input_cnt; ++i)
                inputLayer[i] = sensors[i];

            clearLayer1();

            for (int i = 0; i < input_cnt + 1; ++i) //принимаем веса от входного слоя layer1[j] = sum_i(sensors(i))
                for (int j = 0; j < layer_cnt; ++j)
                    layer[j] += inputLayer[i] * inputlink[i][j];

            double max = layer.Max();
            double min = layer.Min();

            for (int i = 0; i < layer_cnt; ++i) //применяем сигмоид ко всем нейронам данного слоя
                layer[i] = f((max - min) == 0 ? 0 : (layer[i]-min)/(max-min));

         
            //значение выходного слоя просчитываем
            for (int j = 0; j < out_cnt; ++j)
            {
                double sum = 0;
                for (int i = 0; i < layer_cnt + 1; ++i)
                    sum += layer[i] * matr[i][j];
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
        public string show()
        {

            s = "";
            /* double cnt = 0;
             for(int i = 0; i < input_cnt; ++i)
                 for (int j = 0; j < layer_cnt; ++j)
                    cnt += inputlink[i][j];

             s += (cnt / (input_cnt * layer_cnt)).ToString() + " ";

             s += Environment.NewLine + Environment.NewLine;

             cnt = 0;
             for (int i = 0; i < layer_cnt; ++i)
                 for (int j = 0; j < out_cnt; ++j)
                     cnt += matr[i][j];
             */
            s += Environment.NewLine;// + Environment.NewLine;
            /*
            for (int i = 0; i < secondLayer; ++i)
                s += layer2[i].ToString() + "  ";

            s += Environment.NewLine + Environment.NewLine;*/

            for (int i = 0; i < out_cnt; ++i)
                s += outputLayer[i].ToString() + "  ";
            s += Environment.NewLine + Environment.NewLine;
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
            for (int i = 0; i < out_cnt; ++i)
                eps_out[i] = outputLayer[i] * (1 - outputLayer[i]) * eps0[i];

            for (int i = 0; i < layer_cnt; ++i)
            {
                double sum = 0;
                for (int j = 0; j < out_cnt; ++j)
                    sum += matr[i][j] * eps_out[j];
                eps_l[i] = layer[i] * (1 - layer[i]) * sum;
            }

            for (int i = 0; i < input_cnt + 1; ++i)
                for (int j = 0; j < layer_cnt; ++j)
                    inputlink[i][j] += n * eps_l[j] * inputLayer[i];

            for (int i = 0; i < layer_cnt + 1; ++i)
                for (int j = 0; j < out_cnt; ++j)
                    matr[i][j] += n * eps_out[j] * layer[i];
        }
    }
}
