namespace neural_network
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonRectangle = new System.Windows.Forms.Button();
            this.buttonTriangle = new System.Windows.Forms.Button();
            this.buttonCircle = new System.Windows.Forms.Button();
            this.buttonSinHor = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.groupBoxItIs = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelTriangle = new System.Windows.Forms.Label();
            this.progressBarTriangle = new System.Windows.Forms.ProgressBar();
            this.labelCircle = new System.Windows.Forms.Label();
            this.progressBarCircle = new System.Windows.Forms.ProgressBar();
            this.labelSinHor = new System.Windows.Forms.Label();
            this.labelRectangle = new System.Windows.Forms.Label();
            this.progressBarRectangle = new System.Windows.Forms.ProgressBar();
            this.progressBarSinHor = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelCountOfTrainPictures = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelCountOfRightPredictedPictures = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.labelLast100 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBoxCountTrainPictures = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxItIs.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(147, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.Location = new System.Drawing.Point(29, 28);
            this.buttonRectangle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Size = new System.Drawing.Size(94, 24);
            this.buttonRectangle.TabIndex = 1;
            this.buttonRectangle.Text = "drawRectangle";
            this.buttonRectangle.UseVisualStyleBackColor = true;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangle_Click);
            // 
            // buttonTriangle
            // 
            this.buttonTriangle.Location = new System.Drawing.Point(29, 66);
            this.buttonTriangle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTriangle.Name = "buttonTriangle";
            this.buttonTriangle.Size = new System.Drawing.Size(94, 24);
            this.buttonTriangle.TabIndex = 2;
            this.buttonTriangle.Text = "drawTriangle";
            this.buttonTriangle.UseVisualStyleBackColor = true;
            this.buttonTriangle.Click += new System.EventHandler(this.buttonTriangle_Click);
            // 
            // buttonCircle
            // 
            this.buttonCircle.Location = new System.Drawing.Point(29, 105);
            this.buttonCircle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(94, 24);
            this.buttonCircle.TabIndex = 3;
            this.buttonCircle.Text = "drawCircle";
            this.buttonCircle.UseVisualStyleBackColor = true;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            // 
            // buttonSinHor
            // 
            this.buttonSinHor.Location = new System.Drawing.Point(29, 144);
            this.buttonSinHor.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSinHor.Name = "buttonSinHor";
            this.buttonSinHor.Size = new System.Drawing.Size(94, 24);
            this.buttonSinHor.TabIndex = 5;
            this.buttonSinHor.Text = "drawSin";
            this.buttonSinHor.UseVisualStyleBackColor = true;
            this.buttonSinHor.Click += new System.EventHandler(this.buttonSinHor_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(29, 220);
            this.textBoxOutput.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(545, 197);
            this.textBoxOutput.TabIndex = 6;
            // 
            // groupBoxItIs
            // 
            this.groupBoxItIs.Controls.Add(this.label2);
            this.groupBoxItIs.Controls.Add(this.label5);
            this.groupBoxItIs.Controls.Add(this.label6);
            this.groupBoxItIs.Controls.Add(this.label7);
            this.groupBoxItIs.Controls.Add(this.labelTriangle);
            this.groupBoxItIs.Controls.Add(this.progressBarTriangle);
            this.groupBoxItIs.Controls.Add(this.labelCircle);
            this.groupBoxItIs.Controls.Add(this.progressBarCircle);
            this.groupBoxItIs.Controls.Add(this.labelSinHor);
            this.groupBoxItIs.Controls.Add(this.labelRectangle);
            this.groupBoxItIs.Controls.Add(this.progressBarRectangle);
            this.groupBoxItIs.Controls.Add(this.progressBarSinHor);
            this.groupBoxItIs.Location = new System.Drawing.Point(377, 31);
            this.groupBoxItIs.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxItIs.Name = "groupBoxItIs";
            this.groupBoxItIs.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxItIs.Size = new System.Drawing.Size(197, 137);
            this.groupBoxItIs.TabIndex = 7;
            this.groupBoxItIs.TabStop = false;
            this.groupBoxItIs.Text = "It is ...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Triangle";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 76);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Circle";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Rectangle";
            // 
            // labelTriangle
            // 
            this.labelTriangle.AutoSize = true;
            this.labelTriangle.Location = new System.Drawing.Point(144, 53);
            this.labelTriangle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTriangle.Name = "labelTriangle";
            this.labelTriangle.Size = new System.Drawing.Size(52, 15);
            this.labelTriangle.TabIndex = 9;
            this.labelTriangle.Text = "Triangle";
            // 
            // progressBarTriangle
            // 
            this.progressBarTriangle.Location = new System.Drawing.Point(66, 53);
            this.progressBarTriangle.Margin = new System.Windows.Forms.Padding(2);
            this.progressBarTriangle.Name = "progressBarTriangle";
            this.progressBarTriangle.Size = new System.Drawing.Size(75, 19);
            this.progressBarTriangle.Step = 5;
            this.progressBarTriangle.TabIndex = 8;
            // 
            // labelCircle
            // 
            this.labelCircle.AutoSize = true;
            this.labelCircle.Location = new System.Drawing.Point(144, 76);
            this.labelCircle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCircle.Name = "labelCircle";
            this.labelCircle.Size = new System.Drawing.Size(38, 15);
            this.labelCircle.TabIndex = 3;
            this.labelCircle.Text = "Circle";
            // 
            // progressBarCircle
            // 
            this.progressBarCircle.Location = new System.Drawing.Point(66, 76);
            this.progressBarCircle.Margin = new System.Windows.Forms.Padding(2);
            this.progressBarCircle.Name = "progressBarCircle";
            this.progressBarCircle.Size = new System.Drawing.Size(75, 19);
            this.progressBarCircle.Step = 5;
            this.progressBarCircle.TabIndex = 2;
            // 
            // labelSinHor
            // 
            this.labelSinHor.AutoSize = true;
            this.labelSinHor.Location = new System.Drawing.Point(144, 100);
            this.labelSinHor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSinHor.Name = "labelSinHor";
            this.labelSinHor.Size = new System.Drawing.Size(25, 15);
            this.labelSinHor.TabIndex = 7;
            this.labelSinHor.Text = "Sin";
            // 
            // labelRectangle
            // 
            this.labelRectangle.AutoSize = true;
            this.labelRectangle.Location = new System.Drawing.Point(144, 29);
            this.labelRectangle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRectangle.Name = "labelRectangle";
            this.labelRectangle.Size = new System.Drawing.Size(63, 15);
            this.labelRectangle.TabIndex = 1;
            this.labelRectangle.Text = "Rectangle";
            // 
            // progressBarRectangle
            // 
            this.progressBarRectangle.Location = new System.Drawing.Point(66, 29);
            this.progressBarRectangle.Margin = new System.Windows.Forms.Padding(2);
            this.progressBarRectangle.Name = "progressBarRectangle";
            this.progressBarRectangle.Size = new System.Drawing.Size(75, 19);
            this.progressBarRectangle.Step = 5;
            this.progressBarRectangle.TabIndex = 0;
            // 
            // progressBarSinHor
            // 
            this.progressBarSinHor.Location = new System.Drawing.Point(66, 100);
            this.progressBarSinHor.Margin = new System.Windows.Forms.Padding(2);
            this.progressBarSinHor.Name = "progressBarSinHor";
            this.progressBarSinHor.Size = new System.Drawing.Size(75, 19);
            this.progressBarSinHor.Step = 5;
            this.progressBarSinHor.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "train";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(423, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 31);
            this.button2.TabIndex = 9;
            this.button2.Text = "predict";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(26, 113);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(123, 19);
            this.progressBar1.Step = 5;
            this.progressBar1.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "0,008";
            // 
            // labelCountOfTrainPictures
            // 
            this.labelCountOfTrainPictures.AutoSize = true;
            this.labelCountOfTrainPictures.Location = new System.Drawing.Point(84, 15);
            this.labelCountOfTrainPictures.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCountOfTrainPictures.Name = "labelCountOfTrainPictures";
            this.labelCountOfTrainPictures.Size = new System.Drawing.Size(14, 15);
            this.labelCountOfTrainPictures.TabIndex = 13;
            this.labelCountOfTrainPictures.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelCountOfTrainPictures);
            this.groupBox1.Location = new System.Drawing.Point(578, 338);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(176, 40);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Count of train pictures";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelCountOfRightPredictedPictures);
            this.groupBox2.Location = new System.Drawing.Point(578, 383);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(178, 36);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Count of right predicted pictures";
            // 
            // labelCountOfRightPredictedPictures
            // 
            this.labelCountOfRightPredictedPictures.AutoSize = true;
            this.labelCountOfRightPredictedPictures.Location = new System.Drawing.Point(84, 15);
            this.labelCountOfRightPredictedPictures.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCountOfRightPredictedPictures.Name = "labelCountOfRightPredictedPictures";
            this.labelCountOfRightPredictedPictures.Size = new System.Drawing.Size(14, 15);
            this.labelCountOfRightPredictedPictures.TabIndex = 13;
            this.labelCountOfRightPredictedPictures.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.labelLast100);
            this.groupBox3.Location = new System.Drawing.Point(578, 246);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(176, 50);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Right predicted on last 100";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(40, 19);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 26);
            this.button3.TabIndex = 16;
            this.button3.Text = "Check";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // labelLast100
            // 
            this.labelLast100.AutoSize = true;
            this.labelLast100.Location = new System.Drawing.Point(111, 25);
            this.labelLast100.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLast100.Name = "labelLast100";
            this.labelLast100.Size = new System.Drawing.Size(14, 15);
            this.labelLast100.TabIndex = 13;
            this.labelLast100.Text = "0";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(649, 176);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(79, 34);
            this.button4.TabIndex = 16;
            this.button4.Text = "Create NN";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBoxCountTrainPictures
            // 
            this.textBoxCountTrainPictures.Location = new System.Drawing.Point(13, 35);
            this.textBoxCountTrainPictures.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCountTrainPictures.Name = "textBoxCountTrainPictures";
            this.textBoxCountTrainPictures.Size = new System.Drawing.Size(38, 20);
            this.textBoxCountTrainPictures.TabIndex = 17;
            this.textBoxCountTrainPictures.Text = "120";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.progressBar1);
            this.groupBox4.Location = new System.Drawing.Point(579, 31);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(171, 144);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Training";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxCountTrainPictures);
            this.groupBox5.Location = new System.Drawing.Point(98, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(67, 60);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Count pictures";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Location = new System.Drawing.Point(10, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(71, 60);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Learning rate";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 432);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBoxItIs);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonSinHor);
            this.Controls.Add(this.buttonCircle);
            this.Controls.Add(this.buttonTriangle);
            this.Controls.Add(this.buttonRectangle);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxItIs.ResumeLayout(false);
            this.groupBoxItIs.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonRectangle;
        private System.Windows.Forms.Button buttonTriangle;
        private System.Windows.Forms.Button buttonCircle;
        private System.Windows.Forms.Button buttonSinHor;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.GroupBox groupBoxItIs;
        private System.Windows.Forms.ProgressBar progressBarRectangle;
        private System.Windows.Forms.Label labelRectangle;
        private System.Windows.Forms.Label labelTriangle;
        private System.Windows.Forms.ProgressBar progressBarTriangle;
        private System.Windows.Forms.Label labelSinHor;
        private System.Windows.Forms.ProgressBar progressBarSinHor;
        private System.Windows.Forms.Label labelCircle;
        private System.Windows.Forms.ProgressBar progressBarCircle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelCountOfTrainPictures;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelCountOfRightPredictedPictures;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labelLast100;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBoxCountTrainPictures;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

