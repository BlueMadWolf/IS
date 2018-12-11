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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxItIs.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(220, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 308);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.Location = new System.Drawing.Point(44, 43);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Size = new System.Drawing.Size(141, 37);
            this.buttonRectangle.TabIndex = 1;
            this.buttonRectangle.Text = "drawRectangle";
            this.buttonRectangle.UseVisualStyleBackColor = true;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangle_Click);
            // 
            // buttonTriangle
            // 
            this.buttonTriangle.Location = new System.Drawing.Point(44, 102);
            this.buttonTriangle.Name = "buttonTriangle";
            this.buttonTriangle.Size = new System.Drawing.Size(141, 37);
            this.buttonTriangle.TabIndex = 2;
            this.buttonTriangle.Text = "drawTriangle";
            this.buttonTriangle.UseVisualStyleBackColor = true;
            this.buttonTriangle.Click += new System.EventHandler(this.buttonTriangle_Click);
            // 
            // buttonCircle
            // 
            this.buttonCircle.Location = new System.Drawing.Point(44, 162);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(141, 37);
            this.buttonCircle.TabIndex = 3;
            this.buttonCircle.Text = "drawCircle";
            this.buttonCircle.UseVisualStyleBackColor = true;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            // 
            // buttonSinHor
            // 
            this.buttonSinHor.Location = new System.Drawing.Point(44, 222);
            this.buttonSinHor.Name = "buttonSinHor";
            this.buttonSinHor.Size = new System.Drawing.Size(141, 37);
            this.buttonSinHor.TabIndex = 5;
            this.buttonSinHor.Text = "drawSin";
            this.buttonSinHor.UseVisualStyleBackColor = true;
            this.buttonSinHor.Click += new System.EventHandler(this.buttonSinHor_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(44, 338);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(816, 301);
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
            this.groupBoxItIs.Location = new System.Drawing.Point(566, 48);
            this.groupBoxItIs.Name = "groupBoxItIs";
            this.groupBoxItIs.Size = new System.Drawing.Size(296, 211);
            this.groupBoxItIs.TabIndex = 7;
            this.groupBoxItIs.TabStop = false;
            this.groupBoxItIs.Text = "It is ...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Triangle";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Circle";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Rectangle";
            // 
            // labelTriangle
            // 
            this.labelTriangle.AutoSize = true;
            this.labelTriangle.Location = new System.Drawing.Point(216, 82);
            this.labelTriangle.Name = "labelTriangle";
            this.labelTriangle.Size = new System.Drawing.Size(65, 20);
            this.labelTriangle.TabIndex = 9;
            this.labelTriangle.Text = "Triangle";
            // 
            // progressBarTriangle
            // 
            this.progressBarTriangle.Location = new System.Drawing.Point(99, 82);
            this.progressBarTriangle.Name = "progressBarTriangle";
            this.progressBarTriangle.Size = new System.Drawing.Size(112, 29);
            this.progressBarTriangle.Step = 5;
            this.progressBarTriangle.TabIndex = 8;
            // 
            // labelCircle
            // 
            this.labelCircle.AutoSize = true;
            this.labelCircle.Location = new System.Drawing.Point(216, 117);
            this.labelCircle.Name = "labelCircle";
            this.labelCircle.Size = new System.Drawing.Size(48, 20);
            this.labelCircle.TabIndex = 3;
            this.labelCircle.Text = "Circle";
            // 
            // progressBarCircle
            // 
            this.progressBarCircle.Location = new System.Drawing.Point(99, 117);
            this.progressBarCircle.Name = "progressBarCircle";
            this.progressBarCircle.Size = new System.Drawing.Size(112, 29);
            this.progressBarCircle.Step = 5;
            this.progressBarCircle.TabIndex = 2;
            // 
            // labelSinHor
            // 
            this.labelSinHor.AutoSize = true;
            this.labelSinHor.Location = new System.Drawing.Point(216, 154);
            this.labelSinHor.Name = "labelSinHor";
            this.labelSinHor.Size = new System.Drawing.Size(32, 20);
            this.labelSinHor.TabIndex = 7;
            this.labelSinHor.Text = "Sin";
            // 
            // labelRectangle
            // 
            this.labelRectangle.AutoSize = true;
            this.labelRectangle.Location = new System.Drawing.Point(216, 45);
            this.labelRectangle.Name = "labelRectangle";
            this.labelRectangle.Size = new System.Drawing.Size(82, 20);
            this.labelRectangle.TabIndex = 1;
            this.labelRectangle.Text = "Rectangle";
            // 
            // progressBarRectangle
            // 
            this.progressBarRectangle.Location = new System.Drawing.Point(99, 45);
            this.progressBarRectangle.Name = "progressBarRectangle";
            this.progressBarRectangle.Size = new System.Drawing.Size(112, 29);
            this.progressBarRectangle.Step = 5;
            this.progressBarRectangle.TabIndex = 0;
            // 
            // progressBarSinHor
            // 
            this.progressBarSinHor.Location = new System.Drawing.Point(99, 154);
            this.progressBarSinHor.Name = "progressBarSinHor";
            this.progressBarSinHor.Size = new System.Drawing.Size(112, 29);
            this.progressBarSinHor.Step = 5;
            this.progressBarSinHor.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(908, 122);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 45);
            this.button1.TabIndex = 8;
            this.button1.Text = "train";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(908, 188);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 48);
            this.button2.TabIndex = 9;
            this.button2.Text = "predict";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(908, 83);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(184, 29);
            this.progressBar1.Step = 5;
            this.progressBar1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 665);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxItIs);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonSinHor);
            this.Controls.Add(this.buttonCircle);
            this.Controls.Add(this.buttonTriangle);
            this.Controls.Add(this.buttonRectangle);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxItIs.ResumeLayout(false);
            this.groupBoxItIs.PerformLayout();
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
    }
}

