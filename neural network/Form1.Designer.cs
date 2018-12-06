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
            this.buttonSinVert = new System.Windows.Forms.Button();
            this.buttonSinHor = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.groupBoxItIs = new System.Windows.Forms.GroupBox();
            this.progressBarRectangle = new System.Windows.Forms.ProgressBar();
            this.labelRectangle = new System.Windows.Forms.Label();
            this.labelCircle = new System.Windows.Forms.Label();
            this.progressBarCircle = new System.Windows.Forms.ProgressBar();
            this.labelSin = new System.Windows.Forms.Label();
            this.progressBarSin = new System.Windows.Forms.ProgressBar();
            this.labelTriangle = new System.Windows.Forms.Label();
            this.progressBarTriangle = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxItIs.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(235, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.Location = new System.Drawing.Point(39, 15);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Size = new System.Drawing.Size(126, 29);
            this.buttonRectangle.TabIndex = 1;
            this.buttonRectangle.Text = "drawRectangle";
            this.buttonRectangle.UseVisualStyleBackColor = true;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangle_Click);
            // 
            // buttonTriangle
            // 
            this.buttonTriangle.Location = new System.Drawing.Point(39, 61);
            this.buttonTriangle.Name = "buttonTriangle";
            this.buttonTriangle.Size = new System.Drawing.Size(126, 29);
            this.buttonTriangle.TabIndex = 2;
            this.buttonTriangle.Text = "drawTriangle";
            this.buttonTriangle.UseVisualStyleBackColor = true;
            this.buttonTriangle.Click += new System.EventHandler(this.buttonTriangle_Click);
            // 
            // buttonCircle
            // 
            this.buttonCircle.Location = new System.Drawing.Point(39, 109);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(126, 29);
            this.buttonCircle.TabIndex = 3;
            this.buttonCircle.Text = "drawCircle";
            this.buttonCircle.UseVisualStyleBackColor = true;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            // 
            // buttonSinVert
            // 
            this.buttonSinVert.Location = new System.Drawing.Point(39, 159);
            this.buttonSinVert.Name = "buttonSinVert";
            this.buttonSinVert.Size = new System.Drawing.Size(126, 29);
            this.buttonSinVert.TabIndex = 4;
            this.buttonSinVert.Text = "drawSinVert";
            this.buttonSinVert.UseVisualStyleBackColor = true;
            this.buttonSinVert.Click += new System.EventHandler(this.buttonSinVert_Click);
            // 
            // buttonSinHor
            // 
            this.buttonSinHor.Location = new System.Drawing.Point(39, 208);
            this.buttonSinHor.Name = "buttonSinHor";
            this.buttonSinHor.Size = new System.Drawing.Size(126, 29);
            this.buttonSinHor.TabIndex = 5;
            this.buttonSinHor.Text = "drawSinHor";
            this.buttonSinHor.UseVisualStyleBackColor = true;
            this.buttonSinHor.Click += new System.EventHandler(this.buttonSinHor_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(39, 271);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(472, 242);
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
            this.groupBoxItIs.Controls.Add(this.labelSin);
            this.groupBoxItIs.Controls.Add(this.progressBarSin);
            this.groupBoxItIs.Controls.Add(this.labelCircle);
            this.groupBoxItIs.Controls.Add(this.progressBarCircle);
            this.groupBoxItIs.Controls.Add(this.labelRectangle);
            this.groupBoxItIs.Controls.Add(this.progressBarRectangle);
            this.groupBoxItIs.Location = new System.Drawing.Point(528, 12);
            this.groupBoxItIs.Name = "groupBoxItIs";
            this.groupBoxItIs.Size = new System.Drawing.Size(263, 244);
            this.groupBoxItIs.TabIndex = 7;
            this.groupBoxItIs.TabStop = false;
            this.groupBoxItIs.Text = "It is ...";
            // 
            // progressBarRectangle
            // 
            this.progressBarRectangle.Location = new System.Drawing.Point(88, 36);
            this.progressBarRectangle.Name = "progressBarRectangle";
            this.progressBarRectangle.Size = new System.Drawing.Size(100, 23);
            this.progressBarRectangle.Step = 5;
            this.progressBarRectangle.TabIndex = 0;
            // 
            // labelRectangle
            // 
            this.labelRectangle.AutoSize = true;
            this.labelRectangle.Location = new System.Drawing.Point(192, 36);
            this.labelRectangle.Name = "labelRectangle";
            this.labelRectangle.Size = new System.Drawing.Size(72, 17);
            this.labelRectangle.TabIndex = 1;
            this.labelRectangle.Text = "Rectangle";
            // 
            // labelCircle
            // 
            this.labelCircle.AutoSize = true;
            this.labelCircle.Location = new System.Drawing.Point(192, 134);
            this.labelCircle.Name = "labelCircle";
            this.labelCircle.Size = new System.Drawing.Size(43, 17);
            this.labelCircle.TabIndex = 3;
            this.labelCircle.Text = "Circle";
            // 
            // progressBarCircle
            // 
            this.progressBarCircle.Location = new System.Drawing.Point(88, 134);
            this.progressBarCircle.Name = "progressBarCircle";
            this.progressBarCircle.Size = new System.Drawing.Size(100, 23);
            this.progressBarCircle.Step = 5;
            this.progressBarCircle.TabIndex = 2;
            // 
            // labelSin
            // 
            this.labelSin.AutoSize = true;
            this.labelSin.Location = new System.Drawing.Point(192, 183);
            this.labelSin.Name = "labelSin";
            this.labelSin.Size = new System.Drawing.Size(28, 17);
            this.labelSin.TabIndex = 7;
            this.labelSin.Text = "Sin";
            // 
            // progressBarSin
            // 
            this.progressBarSin.Location = new System.Drawing.Point(88, 183);
            this.progressBarSin.Name = "progressBarSin";
            this.progressBarSin.Size = new System.Drawing.Size(100, 23);
            this.progressBarSin.Step = 5;
            this.progressBarSin.TabIndex = 6;
            // 
            // labelTriangle
            // 
            this.labelTriangle.AutoSize = true;
            this.labelTriangle.Location = new System.Drawing.Point(192, 84);
            this.labelTriangle.Name = "labelTriangle";
            this.labelTriangle.Size = new System.Drawing.Size(60, 17);
            this.labelTriangle.TabIndex = 9;
            this.labelTriangle.Text = "Triangle";
            // 
            // progressBarTriangle
            // 
            this.progressBarTriangle.Location = new System.Drawing.Point(88, 84);
            this.progressBarTriangle.Name = "progressBarTriangle";
            this.progressBarTriangle.Size = new System.Drawing.Size(100, 23);
            this.progressBarTriangle.Step = 5;
            this.progressBarTriangle.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Triangle";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Circle";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Rectangle";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 741);
            this.Controls.Add(this.groupBoxItIs);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonSinHor);
            this.Controls.Add(this.buttonSinVert);
            this.Controls.Add(this.buttonCircle);
            this.Controls.Add(this.buttonTriangle);
            this.Controls.Add(this.buttonRectangle);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Button buttonSinVert;
        private System.Windows.Forms.Button buttonSinHor;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.GroupBox groupBoxItIs;
        private System.Windows.Forms.ProgressBar progressBarRectangle;
        private System.Windows.Forms.Label labelRectangle;
        private System.Windows.Forms.Label labelTriangle;
        private System.Windows.Forms.ProgressBar progressBarTriangle;
        private System.Windows.Forms.Label labelSin;
        private System.Windows.Forms.ProgressBar progressBarSin;
        private System.Windows.Forms.Label labelCircle;
        private System.Windows.Forms.ProgressBar progressBarCircle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

