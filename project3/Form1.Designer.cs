namespace project3
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
            btnFlipVertical = new Button();
            btnFlipHorizontal = new Button();
            btnStar = new Button();
            btnCircle = new Button();
            btnTriangle = new Button();
            btnRectang = new Button();
            btnRedo = new Button();
            btnUndo = new Button();
            btnSaveAs = new Button();
            btnSetSize = new Button();
            txtHeight = new TextBox();
            txtWidth = new TextBox();
            btnLoad = new Button();
            button1 = new Button();
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
            btnFill = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 255, 192);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnFill);
            panel1.Controls.Add(btnFlipVertical);
            panel1.Controls.Add(btnFlipHorizontal);
            panel1.Controls.Add(btnStar);
            panel1.Controls.Add(btnCircle);
            panel1.Controls.Add(btnTriangle);
            panel1.Controls.Add(btnRectang);
            panel1.Controls.Add(btnRedo);
            panel1.Controls.Add(btnUndo);
            panel1.Controls.Add(btnSaveAs);
            panel1.Controls.Add(btnSetSize);
            panel1.Controls.Add(txtHeight);
            panel1.Controls.Add(txtWidth);
            panel1.Controls.Add(btnLoad);
            panel1.Controls.Add(button1);
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
            panel1.Size = new Size(1615, 148);
            panel1.TabIndex = 0;
            // 
            // btnFlipVertical
            // 
            btnFlipVertical.Location = new Point(1339, 92);
            btnFlipVertical.Name = "btnFlipVertical";
            btnFlipVertical.Size = new Size(150, 46);
            btnFlipVertical.TabIndex = 25;
            btnFlipVertical.Text = "垂直反転";
            btnFlipVertical.UseVisualStyleBackColor = true;
            btnFlipVertical.Click += btnFlipVertical_Click;
            // 
            // btnFlipHorizontal
            // 
            btnFlipHorizontal.Location = new Point(1183, 92);
            btnFlipHorizontal.Name = "btnFlipHorizontal";
            btnFlipHorizontal.Size = new Size(150, 46);
            btnFlipHorizontal.TabIndex = 24;
            btnFlipHorizontal.Text = "水平反転";
            btnFlipHorizontal.UseVisualStyleBackColor = true;
            btnFlipHorizontal.Click += btnFlipHorizontal_Click;
            // 
            // btnStar
            // 
            btnStar.Font = new Font("Yu Gothic UI", 11F);
            btnStar.Location = new Point(966, 86);
            btnStar.Name = "btnStar";
            btnStar.Size = new Size(55, 55);
            btnStar.TabIndex = 22;
            btnStar.Text = "★";
            btnStar.UseVisualStyleBackColor = true;
            btnStar.Click += btnStar_Click;
            // 
            // btnCircle
            // 
            btnCircle.Font = new Font("Yu Gothic UI", 11F);
            btnCircle.Location = new Point(906, 86);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(54, 55);
            btnCircle.TabIndex = 21;
            btnCircle.Text = "●";
            btnCircle.UseVisualStyleBackColor = true;
            btnCircle.Click += btnCircle_Click;
            // 
            // btnTriangle
            // 
            btnTriangle.Font = new Font("Yu Gothic UI", 13F);
            btnTriangle.Location = new Point(851, 86);
            btnTriangle.Name = "btnTriangle";
            btnTriangle.Size = new Size(49, 55);
            btnTriangle.TabIndex = 20;
            btnTriangle.Text = "▲";
            btnTriangle.TextAlign = ContentAlignment.TopCenter;
            btnTriangle.UseVisualStyleBackColor = true;
            btnTriangle.Click += btnTriangle_Click;
            // 
            // btnRectang
            // 
            btnRectang.Font = new Font("Yu Gothic UI", 13F);
            btnRectang.Location = new Point(789, 86);
            btnRectang.Name = "btnRectang";
            btnRectang.Size = new Size(56, 55);
            btnRectang.TabIndex = 9;
            btnRectang.Text = "■";
            btnRectang.TextAlign = ContentAlignment.TopCenter;
            btnRectang.UseVisualStyleBackColor = true;
            btnRectang.Click += btnRectang_Click;
            // 
            // btnRedo
            // 
            btnRedo.Location = new Point(581, 92);
            btnRedo.Name = "btnRedo";
            btnRedo.Size = new Size(150, 46);
            btnRedo.TabIndex = 18;
            btnRedo.Text = "次に進む";
            btnRedo.UseVisualStyleBackColor = true;
            btnRedo.Click += btnRedo_Click;
            // 
            // btnUndo
            // 
            btnUndo.Location = new Point(415, 92);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(150, 46);
            btnUndo.TabIndex = 17;
            btnUndo.Text = "前へ戻る";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // btnSaveAs
            // 
            btnSaveAs.Location = new Point(1397, 11);
            btnSaveAs.Name = "btnSaveAs";
            btnSaveAs.Size = new Size(205, 52);
            btnSaveAs.TabIndex = 16;
            btnSaveAs.Text = "名前を付けて保存";
            btnSaveAs.UseVisualStyleBackColor = true;
            btnSaveAs.Click += btnSaveAs_Click;
            // 
            // btnSetSize
            // 
            btnSetSize.Location = new Point(212, 70);
            btnSetSize.Name = "btnSetSize";
            btnSetSize.Size = new Size(172, 44);
            btnSetSize.TabIndex = 15;
            btnSetSize.Text = "サイズ変更";
            btnSetSize.UseVisualStyleBackColor = true;
            btnSetSize.Click += btnSetSize_Click;
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(110, 73);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(96, 39);
            txtHeight.TabIndex = 14;
            // 
            // txtWidth
            // 
            txtWidth.Location = new Point(11, 73);
            txtWidth.Name = "txtWidth";
            txtWidth.Size = new Size(93, 39);
            txtWidth.TabIndex = 13;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(1251, 10);
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
            panel2.Location = new Point(0, 148);
            panel2.Name = "panel2";
            panel2.Size = new Size(1615, 329);
            panel2.TabIndex = 2;
            // 
            // btnFill
            // 
            btnFill.Location = new Point(1027, 92);
            btnFill.Name = "btnFill";
            btnFill.Size = new Size(150, 46);
            btnFill.TabIndex = 26;
            btnFill.Text = "塗りつぶし";
            btnFill.UseVisualStyleBackColor = true;
            btnFill.Click += btnFill_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1615, 477);
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
        private Button button1;
        private Button btnLoad;
        private Panel panel2;
        private Button btnSetSize;
        private TextBox txtHeight;
        private TextBox txtWidth;
        private Button btnSaveAs;
        private Button btnUndo;
        private Button btnRedo;
        private Button btnTriangle;
        private Button btnRectang;
        private Button btnStar;
        private Button btnCircle;
        private Button btnFlipVertical;
        private Button btnFlipHorizontal;
        private Button btnFill;
    }
}
