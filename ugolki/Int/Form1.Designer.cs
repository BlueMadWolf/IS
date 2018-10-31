namespace Int
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelStepNumber = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelManH = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelCompH = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(360, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.label1.Location = new System.Drawing.Point(180, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(687, 201);
            this.label1.TabIndex = 1;
            this.label1.Text = "Вы играете за зелёных!\r\nНажмите на меня, \r\n чтобы начать";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.label2.Location = new System.Drawing.Point(22, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ваш шаг №: ";
            // 
            // labelStepNumber
            // 
            this.labelStepNumber.AutoSize = true;
            this.labelStepNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.labelStepNumber.Location = new System.Drawing.Point(199, 27);
            this.labelStepNumber.Name = "labelStepNumber";
            this.labelStepNumber.Size = new System.Drawing.Size(31, 33);
            this.labelStepNumber.TabIndex = 3;
            this.labelStepNumber.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelManH);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.groupBox1.Location = new System.Drawing.Point(28, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 133);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ваша эвристика";
            // 
            // labelManH
            // 
            this.labelManH.AutoSize = true;
            this.labelManH.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.labelManH.Location = new System.Drawing.Point(17, 82);
            this.labelManH.Name = "labelManH";
            this.labelManH.Size = new System.Drawing.Size(31, 33);
            this.labelManH.TabIndex = 5;
            this.labelManH.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelCompH);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.groupBox2.Location = new System.Drawing.Point(28, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 133);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Эвристика компьютера";
            // 
            // labelCompH
            // 
            this.labelCompH.AutoSize = true;
            this.labelCompH.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.labelCompH.Location = new System.Drawing.Point(17, 82);
            this.labelCompH.Name = "labelCompH";
            this.labelCompH.Size = new System.Drawing.Size(31, 33);
            this.labelCompH.TabIndex = 5;
            this.labelCompH.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelStepNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelStepNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelManH;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelCompH;
    }
}

