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
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mainMenuStrip.Size = new System.Drawing.Size(1157, 28);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // localVideoCaptureDeviceToolStripMenuItem
            // 
            this.localVideoCaptureDeviceToolStripMenuItem.Name = "localVideoCaptureDeviceToolStripMenuItem";
            this.localVideoCaptureDeviceToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.localVideoCaptureDeviceToolStripMenuItem.Text = "Local &Video Capture Device";
            this.localVideoCaptureDeviceToolStripMenuItem.Click += new System.EventHandler(this.localVideoCaptureDeviceToolStripMenuItem_Click);
            // 
            // openVideofileusingDirectShowToolStripMenuItem
            // 
            this.openVideofileusingDirectShowToolStripMenuItem.Name = "openVideofileusingDirectShowToolStripMenuItem";
            this.openVideofileusingDirectShowToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.openVideofileusingDirectShowToolStripMenuItem.Text = "Open video &file (using DirectShow)";
            this.openVideofileusingDirectShowToolStripMenuItem.Click += new System.EventHandler(this.openVideofileusingDirectShowToolStripMenuItem_Click);
            // 
            // openJPEGURLToolStripMenuItem
            // 
            this.openJPEGURLToolStripMenuItem.Name = "openJPEGURLToolStripMenuItem";
            this.openJPEGURLToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.openJPEGURLToolStripMenuItem.Text = "Open JPEG &URL";
            this.openJPEGURLToolStripMenuItem.Click += new System.EventHandler(this.openJPEGURLToolStripMenuItem_Click);
            // 
            // openMJPEGURLToolStripMenuItem
            // 
            this.openMJPEGURLToolStripMenuItem.Name = "openMJPEGURLToolStripMenuItem";
            this.openMJPEGURLToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.openMJPEGURLToolStripMenuItem.Text = "Open &MJPEG URL";
            this.openMJPEGURLToolStripMenuItem.Click += new System.EventHandler(this.openMJPEGURLToolStripMenuItem_Click);
            // 
            // capture1stDisplayToolStripMenuItem
            // 
            this.capture1stDisplayToolStripMenuItem.Name = "capture1stDisplayToolStripMenuItem";
            this.capture1stDisplayToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.capture1stDisplayToolStripMenuItem.Text = "Capture 1st display";
            this.capture1stDisplayToolStripMenuItem.Click += new System.EventHandler(this.capture1stDisplayToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(312, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fpsLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 579);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1157, 24);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // fpsLabel
            // 
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(1098, 19);
            this.fpsLabel.Spring = true;
            this.fpsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.videoSourcePlayer);
            this.mainPanel.Location = new System.Drawing.Point(0, 30);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(563, 379);
            this.mainPanel.TabIndex = 2;
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.AutoSizeControl = true;
            this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.videoSourcePlayer.ForeColor = System.Drawing.Color.White;
            this.videoSourcePlayer.Location = new System.Drawing.Point(120, 68);
            this.videoSourcePlayer.Margin = new System.Windows.Forms.Padding(4);
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
            this.pictureBox1.Location = new System.Drawing.Point(607, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(535, 379);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // buttonTrainNetwork
            // 
            this.buttonTrainNetwork.Location = new System.Drawing.Point(184, 491);
            this.buttonTrainNetwork.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTrainNetwork.Name = "buttonTrainNetwork";
            this.buttonTrainNetwork.Size = new System.Drawing.Size(117, 30);
            this.buttonTrainNetwork.TabIndex = 4;
            this.buttonTrainNetwork.Text = "TrainNetwork";
            this.buttonTrainNetwork.UseVisualStyleBackColor = true;
            this.buttonTrainNetwork.Click += new System.EventHandler(this.buttonTrainNetwork_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxCountSamples);
            this.groupBox1.Location = new System.Drawing.Point(32, 417);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(135, 49);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CountSamples";
            // 
            // textBoxCountSamples
            // 
            this.textBoxCountSamples.Location = new System.Drawing.Point(8, 21);
            this.textBoxCountSamples.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCountSamples.Name = "textBoxCountSamples";
            this.textBoxCountSamples.Size = new System.Drawing.Size(59, 22);
            this.textBoxCountSamples.TabIndex = 0;
            this.textBoxCountSamples.Text = "1000";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelTotalCountEpochs);
            this.groupBox2.Controls.Add(this.labelCurrError);
            this.groupBox2.Controls.Add(this.labelCurrCountIterations);
            this.groupBox2.Location = new System.Drawing.Point(309, 417);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(135, 86);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Progress";
            // 
            // labelTotalCountEpochs
            // 
            this.labelTotalCountEpochs.AutoSize = true;
            this.labelTotalCountEpochs.Location = new System.Drawing.Point(8, 22);
            this.labelTotalCountEpochs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotalCountEpochs.Name = "labelTotalCountEpochs";
            this.labelTotalCountEpochs.Size = new System.Drawing.Size(124, 17);
            this.labelTotalCountEpochs.TabIndex = 2;
            this.labelTotalCountEpochs.Text = "TotalCountEpochs";
            // 
            // labelCurrError
            // 
            this.labelCurrError.AutoSize = true;
            this.labelCurrError.Location = new System.Drawing.Point(8, 42);
            this.labelCurrError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrError.Name = "labelCurrError";
            this.labelCurrError.Size = new System.Drawing.Size(67, 17);
            this.labelCurrError.TabIndex = 1;
            this.labelCurrError.Text = "CurrError";
            // 
            // labelCurrCountIterations
            // 
            this.labelCurrCountIterations.AutoSize = true;
            this.labelCurrCountIterations.Location = new System.Drawing.Point(8, 63);
            this.labelCurrCountIterations.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrCountIterations.Name = "labelCurrCountIterations";
            this.labelCurrCountIterations.Size = new System.Drawing.Size(130, 17);
            this.labelCurrCountIterations.TabIndex = 0;
            this.labelCurrCountIterations.Text = "CurrCountIterations";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxCountEpochs);
            this.groupBox4.Location = new System.Drawing.Point(32, 470);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(135, 49);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CountEpochs";
            // 
            // textBoxCountEpochs
            // 
            this.textBoxCountEpochs.Location = new System.Drawing.Point(8, 21);
            this.textBoxCountEpochs.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCountEpochs.Name = "textBoxCountEpochs";
            this.textBoxCountEpochs.Size = new System.Drawing.Size(59, 22);
            this.textBoxCountEpochs.TabIndex = 0;
            this.textBoxCountEpochs.Text = "10";
            // 
            // buttonReadData
            // 
            this.buttonReadData.Location = new System.Drawing.Point(184, 454);
            this.buttonReadData.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReadData.Name = "buttonReadData";
            this.buttonReadData.Size = new System.Drawing.Size(117, 30);
            this.buttonReadData.TabIndex = 7;
            this.buttonReadData.Text = "ReadData";
            this.buttonReadData.UseVisualStyleBackColor = true;
            this.buttonReadData.Click += new System.EventHandler(this.buttonReadData_Click);
            // 
            // labelCntSamples
            // 
            this.labelCntSamples.AutoSize = true;
            this.labelCntSamples.Location = new System.Drawing.Point(108, 442);
            this.labelCntSamples.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCntSamples.Name = "labelCntSamples";
            this.labelCntSamples.Size = new System.Drawing.Size(83, 17);
            this.labelCntSamples.TabIndex = 1;
            this.labelCntSamples.Text = "CntSamples";
            // 
            // radioButtonFixPicYes
            // 
            this.radioButtonFixPicYes.AutoSize = true;
            this.radioButtonFixPicYes.Location = new System.Drawing.Point(20, 22);
            this.radioButtonFixPicYes.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonFixPicYes.Name = "radioButtonFixPicYes";
            this.radioButtonFixPicYes.Size = new System.Drawing.Size(53, 21);
            this.radioButtonFixPicYes.TabIndex = 8;
            this.radioButtonFixPicYes.Text = "Yes";
            this.radioButtonFixPicYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonFixPicNo
            // 
            this.radioButtonFixPicNo.AutoSize = true;
            this.radioButtonFixPicNo.Checked = true;
            this.radioButtonFixPicNo.Location = new System.Drawing.Point(20, 50);
            this.radioButtonFixPicNo.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonFixPicNo.Name = "radioButtonFixPicNo";
            this.radioButtonFixPicNo.Size = new System.Drawing.Size(47, 21);
            this.radioButtonFixPicNo.TabIndex = 9;
            this.radioButtonFixPicNo.TabStop = true;
            this.radioButtonFixPicNo.Text = "No";
            this.radioButtonFixPicNo.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonFixPicNo);
            this.groupBox3.Controls.Add(this.radioButtonFixPicYes);
            this.groupBox3.Location = new System.Drawing.Point(477, 430);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(105, 86);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FixPicture";
            // 
            // buttonPredict
            // 
            this.buttonPredict.Location = new System.Drawing.Point(591, 444);
            this.buttonPredict.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPredict.Name = "buttonPredict";
            this.buttonPredict.Size = new System.Drawing.Size(109, 52);
            this.buttonPredict.TabIndex = 11;
            this.buttonPredict.Text = "Predict";
            this.buttonPredict.UseVisualStyleBackColor = true;
            this.buttonPredict.Click += new System.EventHandler(this.buttonPredict_Click);
            // 
            // labelPredictedNums
            // 
            this.labelPredictedNums.AutoSize = true;
            this.labelPredictedNums.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPredictedNums.Location = new System.Drawing.Point(13, 535);
            this.labelPredictedNums.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPredictedNums.Name = "labelPredictedNums";
            this.labelPredictedNums.Size = new System.Drawing.Size(124, 20);
            this.labelPredictedNums.TabIndex = 12;
            this.labelPredictedNums.Text = "PredictedNums";
            // 
            // buttonInitNet
            // 
            this.buttonInitNet.Location = new System.Drawing.Point(184, 417);
            this.buttonInitNet.Margin = new System.Windows.Forms.Padding(4);
            this.buttonInitNet.Name = "buttonInitNet";
            this.buttonInitNet.Size = new System.Drawing.Size(117, 30);
            this.buttonInitNet.TabIndex = 13;
            this.buttonInitNet.Text = "InitNet";
            this.buttonInitNet.UseVisualStyleBackColor = true;
            this.buttonInitNet.Click += new System.EventHandler(this.buttonInitNet_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 603);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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

