// Simple Player sample application
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © AForge.NET, 2006-2011
// contacts@aforgenet.com
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using Accord.Video;
using Accord.Video.DirectShow;
//using AForge.Neuro;
//using AForge.Neuro.Learning;
using Accord.Imaging;
using Accord.Imaging.Filters;

using Accord;
using Accord.MachineLearning;
using Accord.Neuro;
using Accord.Neuro.Learning;
using Accord.Neuro.Networks;

using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using System.Globalization;

namespace Player
{
    public partial class MainForm : Form
    {
        private Stopwatch stopWatch = null;

        static SpeechSynthesizer ss = new SpeechSynthesizer();
        static SpeechRecognitionEngine sre;

        // Class constructor
        public MainForm( )
        {
            InitializeComponent( );

            Invalidate();
            labelCurrCountIterations.Invalidate();
            labelCurrError.Invalidate();
            labelTotalCountEpochs.Invalidate();

            System.Globalization.CultureInfo ci;
            ci = new System.Globalization.CultureInfo("ru-ru");
            sre = new SpeechRecognitionEngine(ci);

            ss.SetOutputToDefaultAudioDevice();
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);

            Choices PredictCommands = new Choices();
            PredictCommands.Add("угадай");
            //PredictCommands.Add("speech off");
            //PredictCommands.Add("klatu barada nikto");

            GrammarBuilder gb_Predict = new GrammarBuilder();
            gb_Predict.Append(PredictCommands);

            Grammar g_Predict = new Grammar(gb_Predict);
            sre.LoadGrammarAsync(g_Predict);

            sre.RecognizeAsync(RecognizeMode.Multiple);
            //InitNet();
        }

        private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string txt = e.Result.Text;
            labelRecognized.Text = "Recognized: " + txt;

            if (txt.IndexOf("угадай") >= 0)
            {
                buttonPredict_Click(this, new EventArgs());
            }
        }

        private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            CloseCurrentVideoSource( );
        }

        // "Exit" menu item clicked
        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.Close( );
            
        }

        // Open local video capture device
        private void localVideoCaptureDeviceToolStripMenuItem_Click( object sender, EventArgs e )
        {
            VideoCaptureDeviceForm form = new VideoCaptureDeviceForm( );

            if ( form.ShowDialog( this ) == DialogResult.OK )
            {
                // create video source
                VideoCaptureDevice videoSource = form.VideoDevice;

                // open it
                OpenVideoSource( videoSource );
            }
        }

        // Open video file using DirectShow
        private void openVideofileusingDirectShowToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( openFileDialog.ShowDialog( ) == DialogResult.OK )
            {
                // create video source
                FileVideoSource fileSource = new FileVideoSource( openFileDialog.FileName );

                // open it
                OpenVideoSource( fileSource );
            }
        }

        // Open JPEG URL
        private void openJPEGURLToolStripMenuItem_Click( object sender, EventArgs e )
        {
            URLForm form = new URLForm( );

            form.Description = "Enter URL of an updating JPEG from a web camera:";
            form.URLs = new string[]
				{
					"http://195.243.185.195/axis-cgi/jpg/image.cgi?camera=1",
				};

            if ( form.ShowDialog( this ) == DialogResult.OK )
            {
                // create video source
                JPEGStream jpegSource = new JPEGStream( form.URL );

                // open it
                OpenVideoSource( jpegSource );
            }
        }

        // Open MJPEG URL
        private void openMJPEGURLToolStripMenuItem_Click( object sender, EventArgs e )
        {
            URLForm form = new URLForm( );

            form.Description = "Enter URL of an MJPEG video stream:";
            form.URLs = new string[]
				{
					"http://195.243.185.195/axis-cgi/mjpg/video.cgi?camera=4",
					"http://195.243.185.195/axis-cgi/mjpg/video.cgi?camera=3",
				};

            if ( form.ShowDialog( this ) == DialogResult.OK )
            {
                // create video source
                MJPEGStream mjpegSource = new MJPEGStream( form.URL );

                // open it
                OpenVideoSource( mjpegSource );
            }
        }

        // Capture 1st display in the system
        private void capture1stDisplayToolStripMenuItem_Click( object sender, EventArgs e )
        {
            OpenVideoSource( new ScreenCaptureStream( Screen.AllScreens[0].Bounds, 100 ) );
        }

        // Open video source
        private void OpenVideoSource( IVideoSource source )
        {
            // set busy cursor
            this.Cursor = Cursors.WaitCursor;

            // stop current video source
            CloseCurrentVideoSource( );

            // start new video source
            videoSourcePlayer.VideoSource = source;
            videoSourcePlayer.Start( );

            // reset stop watch
            stopWatch = null;

            // start timer
            timer.Start( );

            this.Cursor = Cursors.Default;
        }

        // Close video source if it is running
        private void CloseCurrentVideoSource( )
        {
            if ( videoSourcePlayer.VideoSource != null )
            {
                videoSourcePlayer.SignalToStop( );

                // wait ~ 3 seconds
                for ( int i = 0; i < 30; i++ )
                {
                    if ( !videoSourcePlayer.IsRunning )
                        break;
                    System.Threading.Thread.Sleep( 100 );
                }

                if ( videoSourcePlayer.IsRunning )
                {
                    videoSourcePlayer.Stop( );
                }

                videoSourcePlayer.VideoSource = null;
            }
        }

        // New frame received by the player
        private void videoSourcePlayer_NewFrame( object sender, ref Bitmap image )
        {
            //DateTime now = DateTime.Now;
            Graphics g = Graphics.FromImage( image );

            // paint current time
            //SolidBrush brush = new SolidBrush( Color.Red );
            //g.DrawString( now.ToString( ), this.Font, brush, new PointF( 5, 5 ) );

            if (radioButtonFixPicNo.Checked)
            {
                Crop filter = new Crop(new Rectangle(50, 300, 400, 400));
                Bitmap newImage = filter.Apply(image);
                ResizeBilinear filter1 = new ResizeBilinear(200, 200);
                newImage = filter1.Apply(newImage);
                GrayscaleBT709 filter2 = new GrayscaleBT709();
                Bitmap grayImage = filter2.Apply(newImage);
                ResizeBilinear filter3 = new ResizeBilinear(28, 28);
                Bitmap smallPic = filter3.Apply(grayImage);

                pictureBox1.Image = grayImage;
                pictureBox2.Image = smallPic;
            }

            //brush.Dispose( );
            g.Dispose( );
        }

        // On timer event - gather statistics
        private void timer_Tick( object sender, EventArgs e )
        {
            IVideoSource videoSource = videoSourcePlayer.VideoSource;

            if ( videoSource != null )
            {
                // get number of frames since the last timer tick
                int framesReceived = videoSource.FramesReceived;

                if ( stopWatch == null )
                {
                    stopWatch = new Stopwatch( );
                    stopWatch.Start( );
                }
                else
                {
                    stopWatch.Stop( );

                    float fps = 1000.0f * framesReceived / stopWatch.ElapsedMilliseconds;
                    fpsLabel.Text = fps.ToString( "F2" ) + " fps";

                    stopWatch.Reset( );
                    stopWatch.Start( );
                }
            }
        }
        
        int count_train_samples = 4000;
        List<List<double>> input;
        List<List<double>> output;
        List<double> input_camera;
        int cnt_epochs;
        int total_cnt_epochs;
        int cnt_blocks_one_line = 28;
        int count_output = 10;
        int cnt_added = 0;
        int count_saved = 0;


        ActivationNetwork network;
        ResilientBackpropagationLearning teacher;

        //AForge.Neuro.ActivationNetwork network;
        //PerceptronLearning teacher;
        //BackPropagationLearning teacher;
        //ResilientBackpropagationLearning teacher;
        //EvolutionaryLearning teacher;
        public void InitNet()
        {
            // create perceptron
            int cnt_input = cnt_blocks_one_line * cnt_blocks_one_line;
            //network = new AForge.Neuro.ActivationNetwork(new AForge.Neuro.SigmoidFunction(-0.1), 
            //cnt_input, cnt_input*2, cnt_input * 2, count_output);         

            // create teacher
            //teacher = new BackPropagationLearning(network);
            
            
            network = new ActivationNetwork(new BipolarSigmoidFunction(),
                cnt_input, new[] { cnt_input*2, cnt_input/2, count_output });
            new NguyenWidrow(network).Randomize();

            
            teacher = new ResilientBackpropagationLearning(network);
            
            //teacher.LearningRate = 0.1;
        }

        private List<double> ToMultiClass(int res)
        {
            List<double> multiclass = new List<double>();
            for (int i = 0; i < count_output; ++i)
            {
                if (i == res)
                {
                    multiclass.Add(1);
                }
                else
                {
                    multiclass.Add(0);
                }
            }
            return multiclass;
        }

        public void fill_data(string[] ss)//, int num_str)
        {
            //output[num_str] = new double[count_output];
            
            int res = Int32.Parse(ss[0]);
            output.Add(ToMultiClass(res));

            /*
            for (int i = 0; i < count_output; ++i)
            {
                if (i == res)
                {
                    output[output.Count-1].Add(1);
                }
                else
                {
                    output[output.Count - 1].Add(0);
                }
            }*/


            //input[num_str] = new double[56 + cnt_blocks_one_line*cnt_blocks_one_line];

            input.Add(new List<double>(cnt_blocks_one_line * cnt_blocks_one_line));

            /*
            for (int y = 0; y < 28; ++y)
            {
                double sum = 0;
                for (int x = 0; x < 28; ++x)
                {
                    int curr_value = Int32.Parse(ss[y*28 + x]);
                    sum += curr_value / 255.0;
                }
                input[input.Count - 1].Add((sum / 28.0));// * 2 - 1);
            }
            for (int x = 0; x < 28; ++x)
            {
                double sum = 0;
                for (int y = 0; y < 28; ++y)
                {
                    int curr_value = Int32.Parse(ss[x * 28 + y]);
                    sum += curr_value / 255.0;
                }
                input[input.Count - 1].Add((sum / 28.0));// * 2 - 1);
            }
            */

            int length = 28 / cnt_blocks_one_line;

            for (int y1 = 0; y1 < cnt_blocks_one_line; ++y1)
            {
                for (int x1 = 0; x1 < cnt_blocks_one_line; ++x1)
                {
                    double sum = 0;
                    for (int y2 = 0; y2 < length; ++y2)
                    {
                        for (int x2 = 0; x2 < length; ++x2)
                        {
                            int y = y1 * length + y2;
                            int x = x1 * length + x2;
                            int curr_value = Int32.Parse(ss[y * 28 + x]);
                            sum += curr_value / 255.0;
                        }
                    }
                    int ind = y1 * cnt_blocks_one_line + x1;
                    input[input.Count - 1].Add((sum / length / length));// * 2 - 1);
                }
            }
        }

        /*
        public void ReadData(string fname)
        {
            //input = new double[count_train_samples][];
            //output = new double[count_train_samples][];
            input = new List<List<double>>();
            output = new List<List<double>>();

            int cnt_read = 0;
            cnt_added = 0;

            using (var reader = new StreamReader(fname))
            {
                var line = reader.ReadLine();
                while (!reader.EndOfStream && (cnt_read < count_train_samples))
                {
                    line = reader.ReadLine();
                
                    var values = line.Split(',');
                    int res = Int32.Parse(values[0]);
                    if (res < count_output)
                    {
                        fill_data(values);//, cnt_added);
                        ++cnt_added;
                    }
                    ++cnt_read;
                }
            }
        }        
        */

        public void ReadData()
        {
            //input = new double[count_train_samples][];
            //output = new double[count_train_samples][];
            input = new List<List<double>>();
            output = new List<List<double>>();

            int cnt_read = 1;
            cnt_added = 0;

            for (int numpic = 1; numpic <= count_train_samples; ++numpic)
            {
                Bitmap image = new Bitmap("..\\..\\Pictures\\pic" + numpic.ToString() + ".png");
                List<double> sensors = GetSensorsFromBitmap(image);
                int res = (numpic - 1) / 10;

                input.Add(sensors);
                output.Add(ToMultiClass(res));
            }
            
        }

        public List<double> GetSensorsFromBitmap(Bitmap image)
        {
            List<double> sensors = new List<double>(cnt_blocks_one_line*cnt_blocks_one_line);

            //Bitmap im = (Bitmap)pictureBox1.Image;
            ResizeBilinear filter = new ResizeBilinear(28, 28);
            Bitmap im = filter.Apply(image);

            /*
            for (int y = 0; y < 28; ++y)
            {
                double sum = 0;
                for (int x = 0; x < 28; ++x)
                {
                    Color c = im.GetPixel(x, y);
                    double curr_value = (int)c.R;
                    sum += curr_value / 255.0;
                }
                input_camera.Add((sum / 28.0));// * 2 - 1);
            }
            for (int x = 0; x < 28; ++x)
            {
                double sum = 0;
                for (int y = 0; y < 28; ++y)
                {
                    double curr_value = (int)im.GetPixel(x, y).R;
                    sum += curr_value / 255.0;
                }
                input_camera.Add((sum / 28.0));// * 2 - 1);
            }
            */

            int length = 28 / cnt_blocks_one_line;

            for (int y1 = 0; y1 < cnt_blocks_one_line; ++y1)
            {
                for (int x1 = 0; x1 < cnt_blocks_one_line; ++x1)
                {
                    double sum = 0;
                    for (int y2 = 0; y2 < length; ++y2)
                    {
                        for (int x2 = 0; x2 < length; ++x2)
                        {
                            int y = y1 * length + y2;
                            int x = x1 * length + x2;
                            int curr_value = (int)im.GetPixel(x, y).R;
                            sum += curr_value / 255.0;
                        }
                    }
                    int ind = y1 * cnt_blocks_one_line + x1;
                    sensors.Add((sum / length / length));// * 2 - 1);
                }
            }

            return sensors;
        }        

        public void PutCurrInfo(int cnt_it, double error)
        {            
            labelCurrCountIterations.Text = cnt_it.ToString();
            labelCurrError.Text = error.ToString();

            labelCurrCountIterations.Update();
            labelCurrError.Update();
        }

        public void PutTotalInfo(int cnt_it, double error, double accuracy)
        {
            labelCurrCountIterations.Text = cnt_it.ToString();
            labelCurrError.Text = error.ToString();
            labelTotalCountEpochs.Text = total_cnt_epochs.ToString();
            labelAccuracy.Text = accuracy.ToString();

            labelCurrCountIterations.Update();
            labelCurrError.Update();
            labelTotalCountEpochs.Update();
            labelAccuracy.Update();
        }

        public void Train()
        {
            
            bool b = true;
            double error = 0;
            int cnt_it = 0;
            while (b)
            {
                // run epoch of learning procedure
                error = teacher.RunEpoch(
                    input.ConvertAll(x => x.ToArray()).ToArray(),
                    output.ConvertAll(x => x.ToArray()).ToArray());

                //teacher.LearningRate *= 0.99;

                // check error value to see if we need to stop
                // ...
                b = ((error > 0.1) && (cnt_it < cnt_epochs));
                              
                if ((cnt_it % 1) == 0)
                {
                    PutCurrInfo(cnt_it, error);
                }

                ++cnt_it;
            }
            double accuracy = CheckAccuracy();
            total_cnt_epochs += (cnt_it - 1);
            PutTotalInfo(cnt_it-1, error, accuracy);
        }

        private int IndexOfMax(double[] l)
        {
            double max = l[0];
            int indmax = 0;

            for (int i = 0; i < l.Length; ++i)
            {
                if (l[i] > max)
                {
                    max = l[i];
                    indmax = i;
                }
            }
            return indmax;
        }

        private double CheckAccuracy()
        {
            int cnt_right_predicted = 0;
            for (int i = 0; i < input.Count; ++i)
            {
                var p = network.Compute(input[i].ToArray());
                int pred = IndexOfMax(p);
                if (Math.Abs(output[i][pred] - 1) < 0.001)
                {
                    ++cnt_right_predicted;
                }
            }

            return (double)cnt_right_predicted / input.Count;
        }
           
        private void buttonTrainNetwork_Click(object sender, EventArgs e)
        {
            cnt_epochs = Int32.Parse(textBoxCountEpochs.Text);

            Train();
        }

        private void buttonReadData_Click(object sender, EventArgs e)
        {
            count_train_samples = Int32.Parse(textBoxCountSamples.Text);
            
            ReadData();
            labelCntSamples.Text = cnt_added.ToString();
        }

        private void buttonPredict_Click(object sender, EventArgs e)
        {
            input_camera = GetSensorsFromBitmap((Bitmap)pictureBox1.Image);
            var p = network.Compute(input_camera.ToArray());
            labelPredictedNums.Text = "";

            UpdatePredicted(new List<double> (p));
            for (int i = 0; i < p.Length; ++i)
            {
                //if (p[i] > 0)
                {
                    labelPredictedNums.Text += i.ToString() + 
                        ": " + String.Format("{0:0.00}", p[i]) + " | ";
                }
            }

            int res = IndexOfMax(p);
            ss.SpeakAsync(res.ToString());
        }

        private void buttonInitNet_Click(object sender, EventArgs e)
        {
            InitNet();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.I:
                    buttonInitNet_Click(this, new EventArgs());
                    break;
                case Keys.R:
                    buttonReadData_Click(this, new EventArgs());
                    break;
                case Keys.T:
                    buttonTrainNetwork_Click(this, new EventArgs());
                    break;
                case Keys.P:
                    buttonPredict_Click(this, new EventArgs());
                    break;
                case Keys.S:
                    buttonSaveForTrain_Click(this, new EventArgs());
                    break;
                default:
                    break;
            }
        }

        private void buttonSaveForTrain_Click(object sender, EventArgs e)
        {
            List<double> sensors = GetSensorsFromBitmap((Bitmap)pictureBox1.Image);
            
            int numpic = (int)numericUpDownNumPic.Value;

            ((Bitmap)pictureBox1.Image).Save("..\\..\\Pics\\pic" + numpic.ToString() + ".png");

            ++count_saved;
            labelCountSavedPictures.Text = count_saved.ToString();
            numericUpDownNumPic.Value += 1;
        }

        private void UpdateProgressBar(string name, int value)
        {
            if ((value <= 100) && (value >= 0))
            {
                ProgressBar pb = Controls.Find(name, true)[0] as ProgressBar;
                pb.Value = value;
            }
        }

        private void UpdatePredicted(List<double> pred)
        {
            bool use_bipolar = true;

            if (use_bipolar)
            {
                pred = pred.ConvertAll(x => ((x + 1) / 2));
            }
            List<int> p = pred.ConvertAll(x => (int)(x * 100));

            for (int i = 0; i < pred.Count; ++i)
            {
                UpdateProgressBar("progressBarPred" + i.ToString(), p[i]);
            }
        }

        private void buttonSaveNN_Click(object sender, EventArgs e)
        {
            network.Save("nn.txt");
        }

        private void buttonLoadNN_Click(object sender, EventArgs e)
        {
            network = Network.Load("nn.txt") as ActivationNetwork;
            //var r = sre.Recognize();
            //labelRecognized.Text = r.Text;
        }
    }
}
