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

            Learn();
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

            Crop filter = new Crop(new Rectangle(0, 0, 500, 500));
            Bitmap newImage = filter.Apply(image);
            ResizeBilinear filter1 = new ResizeBilinear(28, 28);
            newImage = filter1.Apply(newImage);
            GrayscaleBT709 filter2 = new GrayscaleBT709();
            Bitmap grayImage = filter2.Apply(newImage);
            pictureBox1.Image = grayImage;
            

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
        double[][] input;
        double[][] output;

        public void fill_data(string[] ss, int num_str)
        {
            output[num_str] = new double[10];
            int res = Int32.Parse(ss[0]);

            for (int i = 0; i < 10; ++i)
            {
                if (i == res)
                {
                    output[num_str][i] = 1;
                }
                else
                {
                    output[num_str][i] = 0;
                }
            }

            input[num_str] = new double[784];
            for (int i = 0; i < 784; ++i)
            {
                int curr_value = Int32.Parse(ss[i+1]);
                input[num_str][i] = curr_value / 255.0;
            }
        }

        public void ReadData(string fname)
        {
            input = new double[count_train_samples][];
            output = new double[count_train_samples][];
            int cnt_read = 0;

            using (var reader = new StreamReader(fname))
            {
                var line = reader.ReadLine();
                while (!reader.EndOfStream && (cnt_read < count_train_samples))
                {
                    line = reader.ReadLine();
                
                    var values = line.Split(',');

                    fill_data(values, cnt_read);

                    ++cnt_read;
                }
            }
        }

        double[] input_camera;

        public void GetCameraInput()
        {
            input_camera = new double[784];

            Bitmap im = (Bitmap)pictureBox1.Image;

            for (int x = 0; x < 28; ++x)
            {
                for (int y = 0; y < 28; ++y)
                {
                    input_camera[y * 28 + x] = (int)im.GetPixel(x, y).A / 255.0;
                }
            }
        }

        ActivationNetwork network;
        //BackPropagationLearning teacher;

        public void Learn()
        {
            ReadData("train.csv");

            /*double[][] input1 = new double[4][] {
                new double[] {0, 0}, new double[] {0, 1},
                new double[] {1, 0}, new double[] {1, 1}
            };
            double[][] output1 = new double[4][] {
                new double[] {0}, new double[] {1},
                new double[] {1}, new double[] {1}
            };*/
            // create neural network
            /*
            network = new ActivationNetwork(
                new ThresholdFunction(),
                784, // two inputs in the network
                600, // two neurons in the first layer
                500,
                400,
                200,
                200,
                100,
                10); // one neuron in the second layer
                    // create teacher
            teacher = new BackPropagationLearning(network);*/

            // create perceptron
            network = new ActivationNetwork(new ThresholdFunction(), 784, 10);
            ActivationLayer layer = network.Layers[0] as ActivationLayer;
            // create teacher
            PerceptronLearning teacher = new PerceptronLearning(network);
            // set learning rate
            teacher.LearningRate = 1;

            bool b = true;
            double error;
            int cnt_it = 0;
            while (b)
            {
                // run epoch of learning procedure
                error = teacher.RunEpoch(input, output);
                // check error value to see if we need to stop
                // ...
                b = ((error > 0.1) && (cnt_it < 1000));
                ++cnt_it;
            }
            var r1 = network.Compute(input[0]);
            var r2 = network.Compute(input[1]);
            var r3 = network.Compute(input[7]);
            var r4 = network.Compute(input[9]);

        }


    }
}
