namespace Player
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localVideoCaptureDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVideofileusingDirectShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openJPEGURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMJPEGURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capture1stDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.fpsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonTrainNetwork = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxCountSamples = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelTotalCountEpochs = new System.Windows.Forms.Label();
            this.labelCurrError = new System.Windows.Forms.Label();
            this.labelCurrCountIterations = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxCountEpochs = new System.Windows.Forms.TextBox();
            this.buttonReadData = new System.Windows.Forms.Button();
            this.labelCntSamples = new System.Windows.Forms.Label();
            this.radioButtonFixPicYes = new System.Windows.Forms.RadioButton();
            this.radioButtonFixPicNo = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonPredict = new System.Windows.Forms.Button();
            this.labelPredictedNums = new System.Windows.Forms.Label();
            this.buttonInitNet = new System.Windows.Forms.Button();
            this.mainMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(868, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localVideoCaptureDeviceToolStripMenuItem,
            this.openVideofileusingDirectShowToolStripMenuItem,
            this.openJPEGURLToolStripMenuItem,
            this.openMJPEGURLToolStripMenuItem,
            this.capture1stDisplayToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // localVideoCaptureDeviceToolStripMenuItem
            // 
            this.localVideoCaptureDeviceToolStripMenuItem.Name = "localVideoCaptureDeviceToolStripMenuItem";
            this.localVideoCaptureDeviceToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.localVideoCaptureDeviceToolStripMenuItem.Text = "Local &Video Capture Device";
            this.localVideoCaptureDeviceToolStripMenuItem.Click += new System.EventHandler(this.localVideoCaptureDeviceToolStripMenuItem_Click);
            // 
            // openVideofileusingDirectShowToolStripMenuItem
            // 
            this.openVideofileusingDirectShowToolStripMenuItem.Name = "openVideofileusingDirectShowToolStripMenuItem";
            this.openVideofileusingDirectShowToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.openVideofileusingDirectShowToolStripMenuItem.Text = "Open video &file (using DirectShow)";
            this.openVideofileusingDirectShowToolStripMenuItem.Click += new System.EventHandler(this.openVideofileusingDirectShowToolStripMenuItem_Click);
            // 
            // openJPEGURLToolStripMenuItem
            // 
            this.openJPEGURLToolStripMenuItem.Name = "openJPEGURLToolStripMenuItem";
            this.openJPEGURLToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.openJPEGURLToolStripMenuItem.Text = "Open JPEG &URL";
            this.openJPEGURLToolStripMenuItem.Click += new System.EventHandler(this.openJPEGURLToolStripMenuItem_Click);
            // 
            // openMJPEGURLToolStripMenuItem
            // 
            this.openMJPEGURLToolStripMenuItem.Name = "openMJPEGURLToolStripMenuItem";
            this.openMJPEGURLToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.openMJPEGURLToolStripMenuItem.Text = "Open &MJPEG URL";
            this.openMJPEGURLToolStripMenuItem.Click += new System.EventHandler(this.openMJPEGURLToolStripMenuItem_Click);
            // 
            // capture1stDisplayToolStripMenuItem
            // 
            this.capture1stDisplayToolStripMenuItem.Name = "capture1stDisplayToolStripMenuItem";
            this.capture1stDisplayToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.capture1stDisplayToolStripMenuItem.Text = "Capture 1st display";
            this.capture1stDisplayToolStripMenuItem.Click += new System.EventHandler(this.capture1stDisplayToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(254, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fpsLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 423);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(868, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // fpsLabel
            // 
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(853, 17);
            this.fpsLabel.Spring = true;
            this.fpsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.videoSourcePlayer);
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(422, 308);
            this.mainPanel.TabIndex = 2;
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.AutoSizeControl = true;
            this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.videoSourcePlayer.ForeColor = System.Drawing.Color.White;
            this.videoSourcePlayer.Location = new System.Drawing.Point(50, 33);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(322, 242);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.VideoSource = null;
            this.videoSourcePlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer_NewFrame);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "AVI files (*.avi)|*.avi|All files (*.*)|*.*";
            this.openFileDialog.Title = "Opem movie";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(455, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 308);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // buttonTrainNetwork
            // 
            this.buttonTrainNetwork.Location = new System.Drawing.Point(138, 399);
            this.buttonTrainNetwork.Name = "buttonTrainNetwork";
            this.buttonTrainNetwork.Size = new System.Drawing.Size(88, 24);
            this.buttonTrainNetwork.TabIndex = 4;
            this.buttonTrainNetwork.Text = "TrainNetwork";
            this.buttonTrainNetwork.UseVisualStyleBackColor = true;
            this.buttonTrainNetwork.Click += new System.EventHandler(this.buttonTrainNetwork_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxCountSamples);
            this.groupBox1.Location = new System.Drawing.Point(24, 339);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(101, 40);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CountSamples";
            // 
            // textBoxCountSamples
            // 
            this.textBoxCountSamples.Location = new System.Drawing.Point(6, 17);
            this.textBoxCountSamples.Name = "textBoxCountSamples";
            this.textBoxCountSamples.Size = new System.Drawing.Size(45, 20);
            this.textBoxCountSamples.TabIndex = 0;
            this.textBoxCountSamples.Text = "1000";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelTotalCountEpochs);
            this.groupBox2.Controls.Add(this.labelCurrError);
            this.groupBox2.Controls.Add(this.labelCurrCountIterations);
            this.groupBox2.Location = new System.Drawing.Point(232, 339);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(101, 70);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Progress";
            // 
            // labelTotalCountEpochs
            // 
            this.labelTotalCountEpochs.AutoSize = true;
            this.labelTotalCountEpochs.Location = new System.Drawing.Point(6, 18);
            this.labelTotalCountEpochs.Name = "labelTotalCountEpochs";
            this.labelTotalCountEpochs.Size = new System.Drawing.Size(95, 13);
            this.labelTotalCountEpochs.TabIndex = 2;
            this.labelTotalCountEpochs.Text = "TotalCountEpochs";
            // 
            // labelCurrError
            // 
            this.labelCurrError.AutoSize = true;
            this.labelCurrError.Location = new System.Drawing.Point(6, 34);
            this.labelCurrError.Name = "labelCurrError";
            this.labelCurrError.Size = new System.Drawing.Size(48, 13);
            this.labelCurrError.TabIndex = 1;
            this.labelCurrError.Text = "CurrError";
            // 
            // labelCurrCountIterations
            // 
            this.labelCurrCountIterations.AutoSize = true;
            this.labelCurrCountIterations.Location = new System.Drawing.Point(6, 51);
            this.labelCurrCountIterations.Name = "labelCurrCountIterations";
            this.labelCurrCountIterations.Size = new System.Drawing.Size(97, 13);
            this.labelCurrCountIterations.TabIndex = 0;
            this.labelCurrCountIterations.Text = "CurrCountIterations";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxCountEpochs);
            this.groupBox4.Location = new System.Drawing.Point(24, 382);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(101, 40);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CountEpochs";
            // 
            // textBoxCountEpochs
            // 
            this.textBoxCountEpochs.Location = new System.Drawing.Point(6, 17);
            this.textBoxCountEpochs.Name = "textBoxCountEpochs";
            this.textBoxCountEpochs.Size = new System.Drawing.Size(45, 20);
            this.textBoxCountEpochs.TabIndex = 0;
            this.textBoxCountEpochs.Text = "50";
            // 
            // buttonReadData
            // 
            this.buttonReadData.Location = new System.Drawing.Point(138, 369);
            this.buttonReadData.Name = "buttonReadData";
            this.buttonReadData.Size = new System.Drawing.Size(88, 24);
            this.buttonReadData.TabIndex = 7;
            this.buttonReadData.Text = "ReadData";
            this.buttonReadData.UseVisualStyleBackColor = true;
            this.buttonReadData.Click += new System.EventHandler(this.buttonReadData_Click);
            // 
            // labelCntSamples
            // 
            this.labelCntSamples.AutoSize = true;
            this.labelCntSamples.Location = new System.Drawing.Point(81, 359);
            this.labelCntSamples.Name = "labelCntSamples";
            this.labelCntSamples.Size = new System.Drawing.Size(63, 13);
            this.labelCntSamples.TabIndex = 1;
            this.labelCntSamples.Text = "CntSamples";
            // 
            // radioButtonFixPicYes
            // 
            this.radioButtonFixPicYes.AutoSize = true;
            this.radioButtonFixPicYes.Location = new System.Drawing.Point(15, 18);
            this.radioButtonFixPicYes.Name = "radioButtonFixPicYes";
            this.radioButtonFixPicYes.Size = new System.Drawing.Size(43, 17);
            this.radioButtonFixPicYes.TabIndex = 8;
            this.radioButtonFixPicYes.Text = "Yes";
            this.radioButtonFixPicYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonFixPicNo
            // 
            this.radioButtonFixPicNo.AutoSize = true;
            this.radioButtonFixPicNo.Checked = true;
            this.radioButtonFixPicNo.Location = new System.Drawing.Point(15, 41);
            this.radioButtonFixPicNo.Name = "radioButtonFixPicNo";
            this.radioButtonFixPicNo.Size = new System.Drawing.Size(39, 17);
            this.radioButtonFixPicNo.TabIndex = 9;
            this.radioButtonFixPicNo.TabStop = true;
            this.radioButtonFixPicNo.Text = "No";
            this.radioButtonFixPicNo.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonFixPicNo);
            this.groupBox3.Controls.Add(this.radioButtonFixPicYes);
            this.groupBox3.Location = new System.Drawing.Point(358, 349);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(79, 70);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FixPicture";
            // 
            // buttonPredict
            // 
            this.buttonPredict.Location = new System.Drawing.Point(443, 361);
            this.buttonPredict.Name = "buttonPredict";
            this.buttonPredict.Size = new System.Drawing.Size(82, 42);
            this.buttonPredict.TabIndex = 11;
            this.buttonPredict.Text = "Predict";
            this.buttonPredict.UseVisualStyleBackColor = true;
            this.buttonPredict.Click += new System.EventHandler(this.buttonPredict_Click);
            // 
            // labelPredictedNums
            // 
            this.labelPredictedNums.AutoSize = true;
            this.labelPredictedNums.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPredictedNums.Location = new System.Drawing.Point(531, 359);
            this.labelPredictedNums.Name = "labelPredictedNums";
            this.labelPredictedNums.Size = new System.Drawing.Size(140, 24);
            this.labelPredictedNums.TabIndex = 12;
            this.labelPredictedNums.Text = "PredictedNums";
            // 
            // buttonInitNet
            // 
            this.buttonInitNet.Location = new System.Drawing.Point(138, 339);
            this.buttonInitNet.Name = "buttonInitNet";
            this.buttonInitNet.Size = new System.Drawing.Size(88, 24);
            this.buttonInitNet.TabIndex = 13;
            this.buttonInitNet.Text = "InitNet";
            this.buttonInitNet.UseVisualStyleBackColor = true;
            this.buttonInitNet.Click += new System.EventHandler(this.buttonInitNet_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 445);
            this.Controls.Add(this.buttonInitNet);
            this.Controls.Add(this.labelPredictedNums);
            this.Controls.Add(this.buttonPredict);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.labelCntSamples);
            this.Controls.Add(this.buttonReadData);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonTrainNetwork);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Simple Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localVideoCaptureDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel fpsLabel;
        private System.Windows.Forms.ToolStripMenuItem openVideofileusingDirectShowToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem openJPEGURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMJPEGURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capture1stDisplayToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonTrainNetwork;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxCountSamples;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelCurrError;
        private System.Windows.Forms.Label labelCurrCountIterations;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxCountEpochs;
        private System.Windows.Forms.Label labelTotalCountEpochs;
        private System.Windows.Forms.Button buttonReadData;
        private System.Windows.Forms.Label labelCntSamples;
        private System.Windows.Forms.RadioButton radioButtonFixPicYes;
        private System.Windows.Forms.RadioButton radioButtonFixPicNo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonPredict;
        private System.Windows.Forms.Label labelPredictedNums;
        private System.Windows.Forms.Button buttonInitNet;
    }
}

