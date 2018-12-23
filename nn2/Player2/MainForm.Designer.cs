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
            this.videoSourcePlayer = new Accord.Controls.VideoSourcePlayer();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonTrainNetwork = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxCountSamples = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelAccuracy = new System.Windows.Forms.Label();
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelCountSavedPictures = new System.Windows.Forms.Label();
            this.numericUpDownNumPic = new System.Windows.Forms.NumericUpDown();
            this.buttonSaveForTrain = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.progressBarPred9 = new System.Windows.Forms.ProgressBar();
            this.labelPred9 = new System.Windows.Forms.Label();
            this.progressBarPred8 = new System.Windows.Forms.ProgressBar();
            this.labelPred8 = new System.Windows.Forms.Label();
            this.progressBarPred7 = new System.Windows.Forms.ProgressBar();
            this.labelPred7 = new System.Windows.Forms.Label();
            this.progressBarPred6 = new System.Windows.Forms.ProgressBar();
            this.labelPred6 = new System.Windows.Forms.Label();
            this.progressBarPred5 = new System.Windows.Forms.ProgressBar();
            this.labelPred5 = new System.Windows.Forms.Label();
            this.progressBarPred4 = new System.Windows.Forms.ProgressBar();
            this.labelPred4 = new System.Windows.Forms.Label();
            this.progressBarPred3 = new System.Windows.Forms.ProgressBar();
            this.labelPred3 = new System.Windows.Forms.Label();
            this.progressBarPred2 = new System.Windows.Forms.ProgressBar();
            this.labelPred2 = new System.Windows.Forms.Label();
            this.progressBarPred1 = new System.Windows.Forms.ProgressBar();
            this.labelPred1 = new System.Windows.Forms.Label();
            this.progressBarPred0 = new System.Windows.Forms.ProgressBar();
            this.labelPred0 = new System.Windows.Forms.Label();
            this.buttonSaveNN = new System.Windows.Forms.Button();
            this.buttonLoadNN = new System.Windows.Forms.Button();
            this.labelRecognized = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumPic)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(868, 27);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 23);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // localVideoCaptureDeviceToolStripMenuItem
            // 
            this.localVideoCaptureDeviceToolStripMenuItem.Name = "localVideoCaptureDeviceToolStripMenuItem";
            this.localVideoCaptureDeviceToolStripMenuItem.Size = new System.Drawing.Size(290, 24);
            this.localVideoCaptureDeviceToolStripMenuItem.Text = "Local &Video Capture Device";
            this.localVideoCaptureDeviceToolStripMenuItem.Click += new System.EventHandler(this.localVideoCaptureDeviceToolStripMenuItem_Click);
            // 
            // openVideofileusingDirectShowToolStripMenuItem
            // 
            this.openVideofileusingDirectShowToolStripMenuItem.Name = "openVideofileusingDirectShowToolStripMenuItem";
            this.openVideofileusingDirectShowToolStripMenuItem.Size = new System.Drawing.Size(290, 24);
            this.openVideofileusingDirectShowToolStripMenuItem.Text = "Open video &file (using DirectShow)";
            this.openVideofileusingDirectShowToolStripMenuItem.Click += new System.EventHandler(this.openVideofileusingDirectShowToolStripMenuItem_Click);
            // 
            // openJPEGURLToolStripMenuItem
            // 
            this.openJPEGURLToolStripMenuItem.Name = "openJPEGURLToolStripMenuItem";
            this.openJPEGURLToolStripMenuItem.Size = new System.Drawing.Size(290, 24);
            this.openJPEGURLToolStripMenuItem.Text = "Open JPEG &URL";
            this.openJPEGURLToolStripMenuItem.Click += new System.EventHandler(this.openJPEGURLToolStripMenuItem_Click);
            // 
            // openMJPEGURLToolStripMenuItem
            // 
            this.openMJPEGURLToolStripMenuItem.Name = "openMJPEGURLToolStripMenuItem";
            this.openMJPEGURLToolStripMenuItem.Size = new System.Drawing.Size(290, 24);
            this.openMJPEGURLToolStripMenuItem.Text = "Open &MJPEG URL";
            this.openMJPEGURLToolStripMenuItem.Click += new System.EventHandler(this.openMJPEGURLToolStripMenuItem_Click);
            // 
            // capture1stDisplayToolStripMenuItem
            // 
            this.capture1stDisplayToolStripMenuItem.Name = "capture1stDisplayToolStripMenuItem";
            this.capture1stDisplayToolStripMenuItem.Size = new System.Drawing.Size(290, 24);
            this.capture1stDisplayToolStripMenuItem.Text = "Capture 1st display";
            this.capture1stDisplayToolStripMenuItem.Click += new System.EventHandler(this.capture1stDisplayToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(287, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(290, 24);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fpsLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 468);
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
            this.mainPanel.Location = new System.Drawing.Point(559, 272);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(422, 308);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.Visible = false;
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
            this.videoSourcePlayer.NewFrame += new Accord.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer_NewFrame);
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
            this.pictureBox1.Location = new System.Drawing.Point(455, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
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
            this.textBoxCountSamples.Text = "100";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelAccuracy);
            this.groupBox2.Controls.Add(this.labelTotalCountEpochs);
            this.groupBox2.Controls.Add(this.labelCurrError);
            this.groupBox2.Controls.Add(this.labelCurrCountIterations);
            this.groupBox2.Location = new System.Drawing.Point(232, 339);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(101, 91);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Progress";
            // 
            // labelAccuracy
            // 
            this.labelAccuracy.AutoSize = true;
            this.labelAccuracy.Location = new System.Drawing.Point(6, 67);
            this.labelAccuracy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAccuracy.Name = "labelAccuracy";
            this.labelAccuracy.Size = new System.Drawing.Size(55, 15);
            this.labelAccuracy.TabIndex = 3;
            this.labelAccuracy.Text = "Accuracy";
            // 
            // labelTotalCountEpochs
            // 
            this.labelTotalCountEpochs.AutoSize = true;
            this.labelTotalCountEpochs.Location = new System.Drawing.Point(6, 18);
            this.labelTotalCountEpochs.Name = "labelTotalCountEpochs";
            this.labelTotalCountEpochs.Size = new System.Drawing.Size(107, 15);
            this.labelTotalCountEpochs.TabIndex = 2;
            this.labelTotalCountEpochs.Text = "TotalCountEpochs";
            // 
            // labelCurrError
            // 
            this.labelCurrError.AutoSize = true;
            this.labelCurrError.Location = new System.Drawing.Point(6, 34);
            this.labelCurrError.Name = "labelCurrError";
            this.labelCurrError.Size = new System.Drawing.Size(57, 15);
            this.labelCurrError.TabIndex = 1;
            this.labelCurrError.Text = "CurrError";
            // 
            // labelCurrCountIterations
            // 
            this.labelCurrCountIterations.AutoSize = true;
            this.labelCurrCountIterations.Location = new System.Drawing.Point(6, 51);
            this.labelCurrCountIterations.Name = "labelCurrCountIterations";
            this.labelCurrCountIterations.Size = new System.Drawing.Size(112, 15);
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
            this.textBoxCountEpochs.Text = "10";
            // 
            // buttonReadData
            // 
            this.buttonReadData.Location = new System.Drawing.Point(138, 339);
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
            this.labelCntSamples.Size = new System.Drawing.Size(74, 15);
            this.labelCntSamples.TabIndex = 1;
            this.labelCntSamples.Text = "CntSamples";
            // 
            // radioButtonFixPicYes
            // 
            this.radioButtonFixPicYes.AutoSize = true;
            this.radioButtonFixPicYes.Location = new System.Drawing.Point(15, 18);
            this.radioButtonFixPicYes.Name = "radioButtonFixPicYes";
            this.radioButtonFixPicYes.Size = new System.Drawing.Size(45, 19);
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
            this.radioButtonFixPicNo.Size = new System.Drawing.Size(41, 19);
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
            this.labelPredictedNums.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPredictedNums.Location = new System.Drawing.Point(10, 435);
            this.labelPredictedNums.Name = "labelPredictedNums";
            this.labelPredictedNums.Size = new System.Drawing.Size(117, 20);
            this.labelPredictedNums.TabIndex = 12;
            this.labelPredictedNums.Text = "PredictedNums";
            // 
            // buttonInitNet
            // 
            this.buttonInitNet.Location = new System.Drawing.Point(138, 370);
            this.buttonInitNet.Name = "buttonInitNet";
            this.buttonInitNet.Size = new System.Drawing.Size(88, 24);
            this.buttonInitNet.TabIndex = 13;
            this.buttonInitNet.Text = "InitNet";
            this.buttonInitNet.UseVisualStyleBackColor = true;
            this.buttonInitNet.Click += new System.EventHandler(this.buttonInitNet_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(455, 304);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 28);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelCountSavedPictures);
            this.groupBox5.Controls.Add(this.numericUpDownNumPic);
            this.groupBox5.Controls.Add(this.buttonSaveForTrain);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(681, 45);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(129, 97);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "SavePicForTrain";
            // 
            // labelCountSavedPictures
            // 
            this.labelCountSavedPictures.AutoSize = true;
            this.labelCountSavedPictures.Location = new System.Drawing.Point(6, 70);
            this.labelCountSavedPictures.Name = "labelCountSavedPictures";
            this.labelCountSavedPictures.Size = new System.Drawing.Size(117, 15);
            this.labelCountSavedPictures.TabIndex = 4;
            this.labelCountSavedPictures.Text = "CountSavedPictures";
            // 
            // numericUpDownNumPic
            // 
            this.numericUpDownNumPic.Location = new System.Drawing.Point(66, 20);
            this.numericUpDownNumPic.Name = "numericUpDownNumPic";
            this.numericUpDownNumPic.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownNumPic.TabIndex = 3;
            // 
            // buttonSaveForTrain
            // 
            this.buttonSaveForTrain.Location = new System.Drawing.Point(29, 44);
            this.buttonSaveForTrain.Name = "buttonSaveForTrain";
            this.buttonSaveForTrain.Size = new System.Drawing.Size(88, 23);
            this.buttonSaveForTrain.TabIndex = 2;
            this.buttonSaveForTrain.Text = "Save";
            this.buttonSaveForTrain.UseVisualStyleBackColor = true;
            this.buttonSaveForTrain.Click += new System.EventHandler(this.buttonSaveForTrain_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "NumPic";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.progressBarPred9);
            this.groupBox6.Controls.Add(this.labelPred9);
            this.groupBox6.Controls.Add(this.progressBarPred8);
            this.groupBox6.Controls.Add(this.labelPred8);
            this.groupBox6.Controls.Add(this.progressBarPred7);
            this.groupBox6.Controls.Add(this.labelPred7);
            this.groupBox6.Controls.Add(this.progressBarPred6);
            this.groupBox6.Controls.Add(this.labelPred6);
            this.groupBox6.Controls.Add(this.progressBarPred5);
            this.groupBox6.Controls.Add(this.labelPred5);
            this.groupBox6.Controls.Add(this.progressBarPred4);
            this.groupBox6.Controls.Add(this.labelPred4);
            this.groupBox6.Controls.Add(this.progressBarPred3);
            this.groupBox6.Controls.Add(this.labelPred3);
            this.groupBox6.Controls.Add(this.progressBarPred2);
            this.groupBox6.Controls.Add(this.labelPred2);
            this.groupBox6.Controls.Add(this.progressBarPred1);
            this.groupBox6.Controls.Add(this.labelPred1);
            this.groupBox6.Controls.Add(this.progressBarPred0);
            this.groupBox6.Controls.Add(this.labelPred0);
            this.groupBox6.Location = new System.Drawing.Point(24, 31);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(380, 287);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Predicted";
            // 
            // progressBarPred9
            // 
            this.progressBarPred9.Location = new System.Drawing.Point(27, 254);
            this.progressBarPred9.Name = "progressBarPred9";
            this.progressBarPred9.Size = new System.Drawing.Size(334, 20);
            this.progressBarPred9.TabIndex = 19;
            // 
            // labelPred9
            // 
            this.labelPred9.AutoSize = true;
            this.labelPred9.Location = new System.Drawing.Point(7, 254);
            this.labelPred9.Name = "labelPred9";
            this.labelPred9.Size = new System.Drawing.Size(14, 15);
            this.labelPred9.TabIndex = 18;
            this.labelPred9.Text = "9";
            // 
            // progressBarPred8
            // 
            this.progressBarPred8.Location = new System.Drawing.Point(27, 228);
            this.progressBarPred8.Name = "progressBarPred8";
            this.progressBarPred8.Size = new System.Drawing.Size(334, 20);
            this.progressBarPred8.TabIndex = 17;
            // 
            // labelPred8
            // 
            this.labelPred8.AutoSize = true;
            this.labelPred8.Location = new System.Drawing.Point(7, 228);
            this.labelPred8.Name = "labelPred8";
            this.labelPred8.Size = new System.Drawing.Size(14, 15);
            this.labelPred8.TabIndex = 16;
            this.labelPred8.Text = "8";
            // 
            // progressBarPred7
            // 
            this.progressBarPred7.Location = new System.Drawing.Point(27, 202);
            this.progressBarPred7.Name = "progressBarPred7";
            this.progressBarPred7.Size = new System.Drawing.Size(334, 20);
            this.progressBarPred7.TabIndex = 15;
            // 
            // labelPred7
            // 
            this.labelPred7.AutoSize = true;
            this.labelPred7.Location = new System.Drawing.Point(7, 202);
            this.labelPred7.Name = "labelPred7";
            this.labelPred7.Size = new System.Drawing.Size(14, 15);
            this.labelPred7.TabIndex = 14;
            this.labelPred7.Text = "7";
            // 
            // progressBarPred6
            // 
            this.progressBarPred6.Location = new System.Drawing.Point(27, 176);
            this.progressBarPred6.Name = "progressBarPred6";
            this.progressBarPred6.Size = new System.Drawing.Size(334, 20);
            this.progressBarPred6.TabIndex = 13;
            // 
            // labelPred6
            // 
            this.labelPred6.AutoSize = true;
            this.labelPred6.Location = new System.Drawing.Point(7, 176);
            this.labelPred6.Name = "labelPred6";
            this.labelPred6.Size = new System.Drawing.Size(14, 15);
            this.labelPred6.TabIndex = 12;
            this.labelPred6.Text = "6";
            // 
            // progressBarPred5
            // 
            this.progressBarPred5.Location = new System.Drawing.Point(27, 149);
            this.progressBarPred5.Name = "progressBarPred5";
            this.progressBarPred5.Size = new System.Drawing.Size(334, 20);
            this.progressBarPred5.TabIndex = 11;
            // 
            // labelPred5
            // 
            this.labelPred5.AutoSize = true;
            this.labelPred5.Location = new System.Drawing.Point(7, 149);
            this.labelPred5.Name = "labelPred5";
            this.labelPred5.Size = new System.Drawing.Size(14, 15);
            this.labelPred5.TabIndex = 10;
            this.labelPred5.Text = "5";
            // 
            // progressBarPred4
            // 
            this.progressBarPred4.Location = new System.Drawing.Point(27, 123);
            this.progressBarPred4.Name = "progressBarPred4";
            this.progressBarPred4.Size = new System.Drawing.Size(334, 20);
            this.progressBarPred4.TabIndex = 9;
            // 
            // labelPred4
            // 
            this.labelPred4.AutoSize = true;
            this.labelPred4.Location = new System.Drawing.Point(7, 123);
            this.labelPred4.Name = "labelPred4";
            this.labelPred4.Size = new System.Drawing.Size(14, 15);
            this.labelPred4.TabIndex = 8;
            this.labelPred4.Text = "4";
            // 
            // progressBarPred3
            // 
            this.progressBarPred3.Location = new System.Drawing.Point(27, 97);
            this.progressBarPred3.Name = "progressBarPred3";
            this.progressBarPred3.Size = new System.Drawing.Size(334, 20);
            this.progressBarPred3.TabIndex = 7;
            // 
            // labelPred3
            // 
            this.labelPred3.AutoSize = true;
            this.labelPred3.Location = new System.Drawing.Point(7, 97);
            this.labelPred3.Name = "labelPred3";
            this.labelPred3.Size = new System.Drawing.Size(14, 15);
            this.labelPred3.TabIndex = 6;
            this.labelPred3.Text = "3";
            // 
            // progressBarPred2
            // 
            this.progressBarPred2.Location = new System.Drawing.Point(27, 71);
            this.progressBarPred2.Name = "progressBarPred2";
            this.progressBarPred2.Size = new System.Drawing.Size(334, 20);
            this.progressBarPred2.TabIndex = 5;
            // 
            // labelPred2
            // 
            this.labelPred2.AutoSize = true;
            this.labelPred2.Location = new System.Drawing.Point(7, 71);
            this.labelPred2.Name = "labelPred2";
            this.labelPred2.Size = new System.Drawing.Size(14, 15);
            this.labelPred2.TabIndex = 4;
            this.labelPred2.Text = "2";
            // 
            // progressBarPred1
            // 
            this.progressBarPred1.Location = new System.Drawing.Point(27, 45);
            this.progressBarPred1.Name = "progressBarPred1";
            this.progressBarPred1.Size = new System.Drawing.Size(334, 20);
            this.progressBarPred1.TabIndex = 3;
            // 
            // labelPred1
            // 
            this.labelPred1.AutoSize = true;
            this.labelPred1.Location = new System.Drawing.Point(7, 45);
            this.labelPred1.Name = "labelPred1";
            this.labelPred1.Size = new System.Drawing.Size(14, 15);
            this.labelPred1.TabIndex = 2;
            this.labelPred1.Text = "1";
            // 
            // progressBarPred0
            // 
            this.progressBarPred0.Location = new System.Drawing.Point(27, 19);
            this.progressBarPred0.Name = "progressBarPred0";
            this.progressBarPred0.Size = new System.Drawing.Size(334, 20);
            this.progressBarPred0.Step = 1;
            this.progressBarPred0.TabIndex = 1;
            // 
            // labelPred0
            // 
            this.labelPred0.AutoSize = true;
            this.labelPred0.Location = new System.Drawing.Point(7, 19);
            this.labelPred0.Name = "labelPred0";
            this.labelPred0.Size = new System.Drawing.Size(14, 15);
            this.labelPred0.TabIndex = 0;
            this.labelPred0.Text = "0";
            // 
            // buttonSaveNN
            // 
            this.buttonSaveNN.Location = new System.Drawing.Point(681, 154);
            this.buttonSaveNN.Name = "buttonSaveNN";
            this.buttonSaveNN.Size = new System.Drawing.Size(100, 32);
            this.buttonSaveNN.TabIndex = 16;
            this.buttonSaveNN.Text = "SaveNN";
            this.buttonSaveNN.UseVisualStyleBackColor = true;
            this.buttonSaveNN.Click += new System.EventHandler(this.buttonSaveNN_Click);
            // 
            // buttonLoadNN
            // 
            this.buttonLoadNN.Location = new System.Drawing.Point(681, 192);
            this.buttonLoadNN.Name = "buttonLoadNN";
            this.buttonLoadNN.Size = new System.Drawing.Size(100, 32);
            this.buttonLoadNN.TabIndex = 17;
            this.buttonLoadNN.Text = "LoadNN";
            this.buttonLoadNN.UseVisualStyleBackColor = true;
            this.buttonLoadNN.Click += new System.EventHandler(this.buttonLoadNN_Click);
            // 
            // labelRecognized
            // 
            this.labelRecognized.AutoSize = true;
            this.labelRecognized.Location = new System.Drawing.Point(410, 233);
            this.labelRecognized.Name = "labelRecognized";
            this.labelRecognized.Size = new System.Drawing.Size(73, 15);
            this.labelRecognized.TabIndex = 18;
            this.labelRecognized.Text = "Recognized";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 490);
            this.Controls.Add(this.labelRecognized);
            this.Controls.Add(this.buttonLoadNN);
            this.Controls.Add(this.buttonSaveNN);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.pictureBox2);
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
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Simple Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumPic)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
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
        private Accord.Controls.VideoSourcePlayer videoSourcePlayer;
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
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelAccuracy;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonSaveForTrain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownNumPic;
        private System.Windows.Forms.Label labelCountSavedPictures;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ProgressBar progressBarPred0;
        private System.Windows.Forms.Label labelPred0;
        private System.Windows.Forms.ProgressBar progressBarPred9;
        private System.Windows.Forms.Label labelPred9;
        private System.Windows.Forms.ProgressBar progressBarPred8;
        private System.Windows.Forms.Label labelPred8;
        private System.Windows.Forms.ProgressBar progressBarPred7;
        private System.Windows.Forms.Label labelPred7;
        private System.Windows.Forms.ProgressBar progressBarPred6;
        private System.Windows.Forms.Label labelPred6;
        private System.Windows.Forms.ProgressBar progressBarPred5;
        private System.Windows.Forms.Label labelPred5;
        private System.Windows.Forms.ProgressBar progressBarPred4;
        private System.Windows.Forms.Label labelPred4;
        private System.Windows.Forms.ProgressBar progressBarPred3;
        private System.Windows.Forms.Label labelPred3;
        private System.Windows.Forms.ProgressBar progressBarPred2;
        private System.Windows.Forms.Label labelPred2;
        private System.Windows.Forms.ProgressBar progressBarPred1;
        private System.Windows.Forms.Label labelPred1;
        private System.Windows.Forms.Button buttonSaveNN;
        private System.Windows.Forms.Button buttonLoadNN;
        private System.Windows.Forms.Label labelRecognized;
    }
}

