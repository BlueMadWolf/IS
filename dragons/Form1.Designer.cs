namespace dragons
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
            this.labelT = new System.Windows.Forms.Label();
            this.labelS = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.labelP = new System.Windows.Forms.Label();
            this.labelW = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.labelF = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkedListBoxG = new System.Windows.Forms.ListBox();
            this.checkedListBoxW = new System.Windows.Forms.ListBox();
            this.checkedListBoxO = new System.Windows.Forms.ListBox();
            this.checkedListBoxС = new System.Windows.Forms.ListBox();
            this.checkedListBoxP = new System.Windows.Forms.ListBox();
            this.checkedListBoxF = new System.Windows.Forms.ListBox();
            this.checkedListBoxS = new System.Windows.Forms.ListBox();
            this.checkedListBoxZ = new System.Windows.Forms.ListBox();
            this.checkedListBoxT = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelO = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.summary = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelT
            // 
            this.labelT.AutoSize = true;
            this.labelT.Location = new System.Drawing.Point(2, 1);
            this.labelT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelT.Name = "labelT";
            this.labelT.Size = new System.Drawing.Size(60, 13);
            this.labelT.TabIndex = 8;
            this.labelT.Text = "Категория";
            // 
            // labelS
            // 
            this.labelS.AutoSize = true;
            this.labelS.Location = new System.Drawing.Point(180, 1);
            this.labelS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelS.Name = "labelS";
            this.labelS.Size = new System.Drawing.Size(89, 13);
            this.labelS.TabIndex = 9;
            this.labelS.Text = "Место обитания";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(180, 112);
            this.labelZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(105, 13);
            this.labelZ.TabIndex = 11;
            this.labelZ.Text = "Количество залпов";
            // 
            // labelP
            // 
            this.labelP.AutoSize = true;
            this.labelP.Location = new System.Drawing.Point(2, 112);
            this.labelP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelP.Name = "labelP";
            this.labelP.Size = new System.Drawing.Size(73, 13);
            this.labelP.TabIndex = 10;
            this.labelP.Text = "Вид пламени";
            // 
            // labelW
            // 
            this.labelW.AutoSize = true;
            this.labelW.Location = new System.Drawing.Point(2, 349);
            this.labelW.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelW.Name = "labelW";
            this.labelW.Size = new System.Drawing.Size(182, 13);
            this.labelW.TabIndex = 13;
            this.labelW.Text = "Благоприятные погодные условия";
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(8, 226);
            this.labelC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(32, 13);
            this.labelC.TabIndex = 12;
            this.labelC.Text = "Цвет";
            // 
            // labelF
            // 
            this.labelF.AutoSize = true;
            this.labelF.Location = new System.Drawing.Point(184, 226);
            this.labelF.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelF.Name = "labelF";
            this.labelF.Size = new System.Drawing.Size(85, 13);
            this.labelF.TabIndex = 14;
            this.labelF.Text = "Виды драконов";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.checkedListBoxG);
            this.splitContainer1.Panel1.Controls.Add(this.checkedListBoxW);
            this.splitContainer1.Panel1.Controls.Add(this.checkedListBoxO);
            this.splitContainer1.Panel1.Controls.Add(this.checkedListBoxС);
            this.splitContainer1.Panel1.Controls.Add(this.checkedListBoxP);
            this.splitContainer1.Panel1.Controls.Add(this.checkedListBoxF);
            this.splitContainer1.Panel1.Controls.Add(this.checkedListBoxS);
            this.splitContainer1.Panel1.Controls.Add(this.checkedListBoxZ);
            this.splitContainer1.Panel1.Controls.Add(this.checkedListBoxT);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.labelO);
            this.splitContainer1.Panel1.Controls.Add(this.labelF);
            this.splitContainer1.Panel1.Controls.Add(this.labelT);
            this.splitContainer1.Panel1.Controls.Add(this.labelW);
            this.splitContainer1.Panel1.Controls.Add(this.labelS);
            this.splitContainer1.Panel1.Controls.Add(this.labelC);
            this.splitContainer1.Panel1.Controls.Add(this.labelZ);
            this.splitContainer1.Panel1.Controls.Add(this.labelP);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel2.Controls.Add(this.summary);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.start);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1159, 628);
            this.splitContainer1.SplitterDistance = 483;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 15;
            // 
            // checkedListBoxG
            // 
            this.checkedListBoxG.FormattingEnabled = true;
            this.checkedListBoxG.Location = new System.Drawing.Point(3, 522);
            this.checkedListBoxG.Name = "checkedListBoxG";
            this.checkedListBoxG.Size = new System.Drawing.Size(194, 95);
            this.checkedListBoxG.TabIndex = 7;
            this.checkedListBoxG.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxG_MouseDoubleClick);
            // 
            // checkedListBoxW
            // 
            this.checkedListBoxW.FormattingEnabled = true;
            this.checkedListBoxW.Location = new System.Drawing.Point(3, 380);
            this.checkedListBoxW.Name = "checkedListBoxW";
            this.checkedListBoxW.Size = new System.Drawing.Size(165, 95);
            this.checkedListBoxW.TabIndex = 9;
            this.checkedListBoxW.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxW_MouseDoubleClick);
            // 
            // checkedListBoxO
            // 
            this.checkedListBoxO.FormattingEnabled = true;
            this.checkedListBoxO.Location = new System.Drawing.Point(183, 380);
            this.checkedListBoxO.Name = "checkedListBoxO";
            this.checkedListBoxO.Size = new System.Drawing.Size(289, 95);
            this.checkedListBoxO.TabIndex = 9;
            this.checkedListBoxO.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxO_MouseDoubleClick);
            // 
            // checkedListBoxС
            // 
            this.checkedListBoxС.FormattingEnabled = true;
            this.checkedListBoxС.Location = new System.Drawing.Point(3, 242);
            this.checkedListBoxС.Name = "checkedListBoxС";
            this.checkedListBoxС.Size = new System.Drawing.Size(165, 95);
            this.checkedListBoxС.TabIndex = 7;
            this.checkedListBoxС.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxC_MouseDoubleClick);
            // 
            // checkedListBoxP
            // 
            this.checkedListBoxP.FormattingEnabled = true;
            this.checkedListBoxP.Location = new System.Drawing.Point(3, 128);
            this.checkedListBoxP.Name = "checkedListBoxP";
            this.checkedListBoxP.Size = new System.Drawing.Size(165, 95);
            this.checkedListBoxP.TabIndex = 8;
            this.checkedListBoxP.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxP_MouseDoubleClick);
            // 
            // checkedListBoxF
            // 
            this.checkedListBoxF.FormattingEnabled = true;
            this.checkedListBoxF.Location = new System.Drawing.Point(183, 242);
            this.checkedListBoxF.Name = "checkedListBoxF";
            this.checkedListBoxF.Size = new System.Drawing.Size(289, 95);
            this.checkedListBoxF.TabIndex = 10;
            this.checkedListBoxF.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxF_MouseDoubleClick);
            // 
            // checkedListBoxS
            // 
            this.checkedListBoxS.FormattingEnabled = true;
            this.checkedListBoxS.Location = new System.Drawing.Point(183, 17);
            this.checkedListBoxS.Name = "checkedListBoxS";
            this.checkedListBoxS.Size = new System.Drawing.Size(289, 95);
            this.checkedListBoxS.TabIndex = 7;
            this.checkedListBoxS.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxS_MouseDoubleClick);
            // 
            // checkedListBoxZ
            // 
            this.checkedListBoxZ.FormattingEnabled = true;
            this.checkedListBoxZ.Location = new System.Drawing.Point(183, 128);
            this.checkedListBoxZ.Name = "checkedListBoxZ";
            this.checkedListBoxZ.Size = new System.Drawing.Size(289, 95);
            this.checkedListBoxZ.TabIndex = 8;
            this.checkedListBoxZ.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxZ_MouseDoubleClick);
            // 
            // checkedListBoxT
            // 
            this.checkedListBoxT.FormattingEnabled = true;
            this.checkedListBoxT.Location = new System.Drawing.Point(3, 15);
            this.checkedListBoxT.Name = "checkedListBoxT";
            this.checkedListBoxT.Size = new System.Drawing.Size(165, 95);
            this.checkedListBoxT.TabIndex = 5;
            this.checkedListBoxT.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxT_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 494);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Поставленная задача";
            // 
            // labelO
            // 
            this.labelO.AutoSize = true;
            this.labelO.Location = new System.Drawing.Point(204, 353);
            this.labelO.Name = "labelO";
            this.labelO.Size = new System.Drawing.Size(125, 13);
            this.labelO.TabIndex = 16;
            this.labelO.Text = "Особенности драконов";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(396, 17);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Обратный вывод";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // summary
            // 
            this.summary.FormattingEnabled = true;
            this.summary.Location = new System.Drawing.Point(21, 15);
            this.summary.Name = "summary";
            this.summary.Size = new System.Drawing.Size(272, 290);
            this.summary.TabIndex = 7;
            this.summary.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.summary_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Выбранные факты";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(325, 94);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(109, 49);
            this.start.TabIndex = 4;
            this.start.Text = "Запуск";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(17, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Вывод";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 385);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(661, 236);
            this.textBox2.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 662);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Книга драконов";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelT;
        private System.Windows.Forms.Label labelS;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Label labelP;
        private System.Windows.Forms.Label labelW;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.Label labelF;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox checkedListBoxT;
        private System.Windows.Forms.ListBox checkedListBoxG;
        private System.Windows.Forms.ListBox checkedListBoxW;
        private System.Windows.Forms.ListBox checkedListBoxO;
        private System.Windows.Forms.ListBox checkedListBoxС;
        private System.Windows.Forms.ListBox checkedListBoxP;
        private System.Windows.Forms.ListBox checkedListBoxF;
        private System.Windows.Forms.ListBox checkedListBoxS;
        private System.Windows.Forms.ListBox checkedListBoxZ;
        private System.Windows.Forms.ListBox summary;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

