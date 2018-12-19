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

using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Neuro;
using AForge.Neuro.Learning;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace Player
{
    public partial class MainForm : Form
    {
        private Stopwatch stopWatch = null;       

        // Class constructor
        public MainForm( )
        {
            InitializeComponent( );

            Invalidate();
            labelCurrCountIterations.Invalidate();
            labelCurrError.Invalidate();
            labelTotalCountEpochs.Invalidate();

            //InitNet();
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
                ResizeBilinear filter1 = new ResizeBilinear(300, 300);
                newImage = filter1.Apply(newImage);
                GrayscaleBT709 filter2 = new GrayscaleBT709();
                Bitmap grayImage = filter2.Apply(newImage);
                pictureBox1.Image = grayImage;
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
        int cnt_blocks_one_line = 2;
        int count_output = 2;
        int cnt_added = 0;

        ActivationNetwork network;
        //PerceptronLearning teacher;
        BackPropagationLearning teacher;
        //ResilientBackpropagationLearning teacher;
        //EvolutionaryLearning teacher;
        public void InitNet()
        {
            // create perceptron
            int cnt_input = 56 + cnt_blocks_one_line * cnt_blocks_one_line;
            network = new ActivationNetwork(new SigmoidFunction(-0.1), 
                cnt_input, cnt_input*2, cnt_input * 2, count_output);
      
            // create teacher
            teacher = new BackPropagationLearning(network);
            // set learning rate
            teacher.LearningRate = 0.1;
        }

        public void fill_data(string[] ss)//, int num_str)
        {
            //output[num_str] = new double[count_output];
            output.Add(new List<double>(count_output));
            int res = Int32.Parse(ss[0]);
            
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
            }


            //input[num_str] = new double[56 + cnt_blocks_one_line*cnt_blocks_one_line];
            input.Add(new List<double>(56 + cnt_blocks_one_line * cnt_blocks_one_line));

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

        public void GetCameraInput()
        {
            input_camera = new List<double>(56 + cnt_blocks_one_line*cnt_blocks_one_line);

            Bitmap im = (Bitmap)pictureBox1.Image;
            ResizeBilinear filter = new ResizeBilinear(28, 28);
            im = filter.Apply(im);

            for (int y = 0; y < 28; ++y)
            {
                double sum = 0;
                for (int x = 0; x < 28; ++x)
                {
                    double curr_value = (int)im.GetPixel(x, y).R;
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
                    input_camera.Add((sum / length / length));// * 2 - 1);
                }
            }
        }        

        public void PutCurrInfo(int cnt_it, double error)
        {            
            labelCurrCountIterations.Text = cnt_it.ToString();
            labelCurrError.Text = error.ToString();

            labelCurrCountIterations.Update();
            labelCurrError.Update();
        }

        public void PutTotalInfo(int cnt_it, double error)
        {
            labelCurrCountIterations.Text = cnt_it.ToString();
            labelCurrError.Text = error.ToString();
            labelTotalCountEpochs.Text = total_cnt_epochs.ToString();

            labelCurrCountIterations.Update();
            labelCurrError.Update();
            labelTotalCountEpochs.Update();
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
            total_cnt_epochs += (cnt_it - 1);
            PutTotalInfo(cnt_it-1, error);
        }
           
        private void buttonTrainNetwork_Click(object sender, EventArgs e)
        {
            cnt_epochs = Int32.Parse(textBoxCountEpochs.Text);

            Train();
        }

        private void buttonReadData_Click(object sender, EventArgs e)
        {
            count_train_samples = Int32.Parse(textBoxCountSamples.Text);
            
            ReadData("train.csv");
            labelCntSamples.Text = cnt_added.ToString();
        }

        private void buttonPredict_Click(object sender, EventArgs e)
        {
            GetCameraInput();
            var p = network.Compute(input_camera.ToArray());
            labelPredictedNums.Text = "";

            for (int i = 0; i < p.Length; ++i)
            {
                //if (p[i] > 0)
                {
                    labelPredictedNums.Text += i.ToString() + 
                        ": " + String.Format("{0:0.00}", p[i]) + " | ";
                }
            }
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
                default:
                    break;
            }
        }
    }
}
