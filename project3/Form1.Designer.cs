﻿namespace project3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnSetSize = new Button();
            txtHeight = new TextBox();
            txtWidth = new TextBox();
            btnLoad = new Button();
            button1 = new Button();
            btnSave = new Button();
            cmbWidth = new ComboBox();
            btn8 = new Button();
            btn7 = new Button();
            btn6 = new Button();
            btn5 = new Button();
            btn4 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn1 = new Button();
            pic = new PictureBox();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 255, 192);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnSetSize);
            panel1.Controls.Add(txtHeight);
            panel1.Controls.Add(txtWidth);
            panel1.Controls.Add(btnLoad);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(cmbWidth);
            panel1.Controls.Add(btn8);
            panel1.Controls.Add(btn7);
            panel1.Controls.Add(btn6);
            panel1.Controls.Add(btn5);
            panel1.Controls.Add(btn4);
            panel1.Controls.Add(btn2);
            panel1.Controls.Add(btn3);
            panel1.Controls.Add(btn1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1346, 102);
            panel1.TabIndex = 0;
            // 
            // btnSetSize
            // 
            btnSetSize.Location = new Point(232, 55);
            btnSetSize.Name = "btnSetSize";
            btnSetSize.Size = new Size(172, 44);
            btnSetSize.TabIndex = 15;
            btnSetSize.Text = "サイズ変更";
            btnSetSize.UseVisualStyleBackColor = true;
            btnSetSize.Click += btnSetSize_Click;
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(110, 58);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(96, 39);
            txtHeight.TabIndex = 14;
            // 
            // txtWidth
            // 
            txtWidth.Location = new Point(11, 58);
            txtWidth.Name = "txtWidth";
            txtWidth.Size = new Size(93, 39);
            txtWidth.TabIndex = 13;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(1045, 25);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(140, 53);
            btnLoad.TabIndex = 12;
            btnLoad.Text = "読み込み";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // button1
            // 
            button1.Location = new Point(906, 22);
            button1.Name = "button1";
            button1.Size = new Size(79, 55);
            button1.TabIndex = 11;
            button1.Text = "クリア";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(1191, 26);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 51);
            btnSave.TabIndex = 10;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += button2_Click;
            // 
            // cmbWidth
            // 
            cmbWidth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWidth.FormattingEnabled = true;
            cmbWidth.Items.AddRange(new object[] { "1", "2", "4", "8", "16", "32", "64", "128", "256" });
            cmbWidth.Location = new Point(11, 11);
            cmbWidth.Name = "cmbWidth";
            cmbWidth.Size = new Size(306, 40);
            cmbWidth.TabIndex = 8;
            // 
            // btn8
            // 
            btn8.Location = new Point(844, 22);
            btn8.Name = "btn8";
            btn8.Size = new Size(56, 56);
            btn8.TabIndex = 7;
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btn_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(782, 22);
            btn7.Name = "btn7";
            btn7.Size = new Size(56, 56);
            btn7.TabIndex = 6;
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btn_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(720, 22);
            btn6.Name = "btn6";
            btn6.Size = new Size(56, 56);
            btn6.TabIndex = 5;
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btn_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(658, 22);
            btn5.Name = "btn5";
            btn5.Size = new Size(56, 56);
            btn5.TabIndex = 4;
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btn_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(596, 22);
            btn4.Name = "btn4";
            btn4.Size = new Size(56, 56);
            btn4.TabIndex = 3;
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btn_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(472, 22);
            btn2.Name = "btn2";
            btn2.Size = new Size(56, 56);
            btn2.TabIndex = 2;
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(534, 22);
            btn3.Name = "btn3";
            btn3.Size = new Size(56, 56);
            btn3.TabIndex = 1;
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn_Click;
            // 
            // btn1
            // 
            btn1.Location = new Point(410, 22);
            btn1.Name = "btn1";
            btn1.Size = new Size(56, 56);
            btn1.TabIndex = 0;
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn_Click;
            // 
            // pic
            // 
            pic.BackColor = Color.White;
            pic.Location = new Point(0, 0);
            pic.Name = "pic";
            pic.Size = new Size(744, 168);
            pic.TabIndex = 1;
            pic.TabStop = false;
            pic.MouseDown += pic_MouseDown;
            pic.MouseMove += pic_MouseMove;
            pic.MouseUp += pic_MouseUp;
            pic.Resize += pic_Resize;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel2.Controls.Add(pic);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 102);
            panel2.Name = "panel2";
            panel2.Size = new Size(1346, 375);
            panel2.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1346, 477);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "お絵描きソフト";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pic;
        private Button btn1;
        private Button btn8;
        private Button btn7;
        private Button btn6;
        private Button btn5;
        private Button btn4;
        private Button btn2;
        private Button btn3;
        private ComboBox cmbWidth;
        private Button btnSave;
        private Button button1;
        private Button btnLoad;
        private Panel panel2;
        private Button btnSetSize;
        private TextBox txtHeight;
        private TextBox txtWidth;
    }
}
