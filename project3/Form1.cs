using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;


namespace project3
{
    public partial class Form1 : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private Stack<Bitmap> undoStack = new Stack<Bitmap>();
        private Stack<Bitmap> redoStack = new Stack<Bitmap>();
        private Bitmap tempBitmap = null; // 描画内容を一時的に保存するためのビットマップ

        public Form1()
        {
            InitializeComponent();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            pic.Paint += new PaintEventHandler(pic_PaintBorder);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _bitmap = new Bitmap(pic.Width, pic.Height);

            btn1.BackColor = Color.Black;
            btn2.BackColor = Color.White;
            btn3.BackColor = Color.Blue;
            btn4.BackColor = Color.Red;
            btn5.BackColor = Color.Green;
            btn6.BackColor = Color.Yellow;
            btn7.BackColor = Color.Pink;
            btn8.BackColor = Color.SkyBlue;

            //combboxの始めの太さを設定
            cmbWidth.SelectedIndex = 0;


            // イベントハンドラを設定
            pic.Paint += new PaintEventHandler(pic_Paint);
            pic.MouseClick += new MouseEventHandler(pic_MouseClick);

        }

        Bitmap _bitmap = null;

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            using (Graphics g = pic.CreateGraphics())
            {
                g.DrawLine(Pens.Blue, 100, 100, 300, 200);
            }
            */
            /*
            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                g.DrawLine(Pens.Blue, 100, 100, 300, 200);
                pic.Image = _bitmap;
            }
            */

        }

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            oldLocation = e.Location;

            // 描画前に現在の状態を保存
            SaveUndoState();

            // 描画中
            drawFlg = true;

            // 一時的なビットマップを作成し、現在のビットマップのコピーを保存
            tempBitmap = (Bitmap)_bitmap.Clone();

            //pic_MouseMove(sender, e);

            // テキストの描画開始位置を設定
            textLocation = e.Location;
        }

        bool drawFlg = false;   //true : 描画中   

        Point oldLocation = new Point();
        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (!drawFlg) return;

            switch (selectedShape)
            {
                case ShapeType.Rectangle:
                case ShapeType.Triangle:
                    // ガイドライン表示のために再描画
                    pic.Invalidate();
                    break;
                case ShapeType.Circle:
                    using (Graphics g = Graphics.FromImage(_bitmap))
                    {
                        g.Clear(Color.Transparent); // 以前の描画を消去
                        DrawCircle(g, oldLocation, Math.Max(Math.Abs(e.Location.X - oldLocation.X), Math.Abs(e.Location.Y - oldLocation.Y)));
                        pic.Image = _bitmap;
                    }
                    break;
                case ShapeType.Star:
                    using (Graphics g = Graphics.FromImage(_bitmap))
                    {
                        g.Clear(Color.Transparent); // 以前の描画を消去
                        DrawStar(g, oldLocation, Math.Max(Math.Abs(e.Location.X - oldLocation.X), Math.Abs(e.Location.Y - oldLocation.Y)) / 2, Math.Max(Math.Abs(e.Location.X - oldLocation.X), Math.Abs(e.Location.Y - oldLocation.Y)) / 4, 5);
                        pic.Image = _bitmap;
                    }
                    break;
                case ShapeType.Text:
                    using (Graphics g = Graphics.FromImage(_bitmap))
                    {
                        // 一度ビットマップをクリアして以前の描画内容を消去
                        g.Clear(Color.Transparent);

                        // ドラッグ中の位置からフォントサイズを計算
                        float distance = Math.Max(Math.Abs(e.Location.X - oldLocation.X), Math.Abs(e.Location.Y - oldLocation.Y));
                        int fontSize = (int)(distance / 5); // 5はフォントサイズの係数（調整が必要）

                        // フォントサイズが0より小さい場合は1を使用する
                        fontSize = Math.Max(fontSize, 1);

                        // テキストを描画
                        DrawText(g, oldLocation, txtInput.Text, new Font("Arial", fontSize));

                        textFont = new Font("Arial", fontSize);

                        pic.Image = _bitmap;
                    }
                    break;
                default:
                    using (Graphics g = Graphics.FromImage(_bitmap))
                    {
                        draw(g, oldLocation, e.Location);
                    }
                    pic.Image = _bitmap;
                    oldLocation = e.Location;
                    break;
            }
        }
        private void SaveUndoState()
        {
            // 現在のビットマップをコピーしてスタックに保存
            undoStack.Push((Bitmap)_bitmap.Clone());
            // REDOスタックをクリア
            redoStack.Clear();
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            drawFlg = false;
            if (selectedShape != ShapeType.None)
            {
                using (Graphics g = Graphics.FromImage(_bitmap))
                {
                    // 一時的なビットマップの内容を復元
                    g.DrawImage(tempBitmap, Point.Empty);
                    switch (selectedShape)
                    {
                        case ShapeType.Rectangle:
                            DrawRectangle(g, oldLocation, e.Location, chkFill.Checked);
                            break;
                        case ShapeType.Triangle:
                            DrawTriangle(g, oldLocation, e.Location, chkFill.Checked);
                            break;
                        case ShapeType.Circle:
                            DrawCircle(g, oldLocation, Math.Max(Math.Abs(e.Location.X - oldLocation.X), Math.Abs(e.Location.Y - oldLocation.Y)), chkFill.Checked);
                            break;
                        case ShapeType.Star:
                            DrawStar(g, oldLocation, Math.Max(Math.Abs(e.Location.X - oldLocation.X), Math.Abs(e.Location.Y - oldLocation.Y)) / 2, Math.Max(Math.Abs(e.Location.X - oldLocation.X), Math.Abs(e.Location.Y - oldLocation.Y)) / 4, 5, chkFill.Checked);
                            break;
                        case ShapeType.Text:
                            DrawText(g, textLocation, txtInput.Text, textFont);
                            break;
                    }
                }
                pic.Image = _bitmap;
            }
        }

        Color _selectedcolor = Color.Black;

        //全てのボタンクリック

        int rrr = 0;
        int bbb = 0;
        int ggg = 0;
        int www = 0;

        private void btn_Click(object sender, EventArgs e)
        {
            _selectedcolor = ((Button)sender).BackColor;
            selectedShape = ShapeType.None; // ペンモードに戻す

            #region おまけ
            if (_selectedcolor == Color.Red)
            {
                rrr++;// 赤色のボタンが押されたときの処理をここに追加
            }
            else if (_selectedcolor == Color.Blue)
            {
                bbb++;// 青色のボタンが押されたときの処理をここに追加
            }
            else if (_selectedcolor == Color.Green)
            {
                ggg++;// 緑色のボタンが押されたときの処理をここに追加
            }
            else
            {
                www++;
            }

            #endregion

        }

        private void draw(Graphics g, Point xy1, Point xy2)
        {
            int penWidth = Int32.Parse(cmbWidth.SelectedItem.ToString());
            if (penWidth <= 1)
            {
                Pen pen = new Pen(_selectedcolor, penWidth);
                g.DrawLine(pen, xy1, xy2);
                return;
            }


            //Point xy1 = new Point(100,100);
            //Point xy2 = new Point(300,200);

            Brush brush = new SolidBrush(_selectedcolor);

            bool drawX = true;  //true : X軸基準で描画
                                //false : Y軸基準で描画

            if (Math.Abs(xy2.X - xy1.X) > Math.Abs(xy2.Y - xy1.Y))
            {
                //幅の方が大きい場合->X軸でループ
                //xy2のxが大きくなるように処理
                if (xy1.X > xy2.X)
                {
                    Point p = xy1;
                    xy1 = xy2;
                    xy2 = p;
                }
                drawX = true;
            }
            else
            {
                //高さの方が大きい場合->Y軸でループ
                //xy2のyが大きくなるように処理
                if (xy1.Y > xy2.Y)
                {
                    Point p = xy1;
                    xy1 = xy2;
                    xy2 = p;
                }
                drawX = false;
            }

            if (drawX == true)
            {
                //X軸基準で描画
                float y = (float)(xy1.Y);

                //傾きの計算
                float a = (float)(xy2.Y - xy1.Y) / (float)(xy2.X - xy1.X);


                for (int x = xy1.X; x <= xy2.X; x++)
                {
                    RectangleF rect = new RectangleF(
                        x - (penWidth / 2),
                        y - (penWidth / 2),
                        penWidth,
                        penWidth);
                    g.FillEllipse(brush, rect);

                    y = y + a;
                }
            }
            else
            {
                //Y軸基準で描画
                float x = (float)(xy1.X);

                //傾きの計算
                float a = (float)(xy2.X - xy1.X) / (float)(xy2.Y - xy1.Y);


                for (int y = xy1.Y; y <= xy2.Y; y++)
                {
                    RectangleF rect = new RectangleF(
                        x - (penWidth / 2),
                        y - (penWidth / 2),
                        penWidth,
                        penWidth);
                    g.FillEllipse(brush, rect);

                    x = x + a;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _bitmap.Save("test.png", ImageFormat.Png);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveUndoState();
            clear();
        }

        private void clear()
        {
            // _bitmap を白でクリアするのではなく、完全に新しいビットマップを作成する
            _bitmap = new Bitmap(pic.Width, pic.Height);
            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                g.FillRectangle(Brushes.White, new Rectangle(0, 0, _bitmap.Width, _bitmap.Height));
            }
            pic.Image = _bitmap;

            rrr = 0;
            bbb = 0;
            ggg = 0;
            www = 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (rrr == 4 && bbb == 5 && ggg == 6 && www == 0)
            {
                _bitmap = new Bitmap("meiro.png");
                pic.Image = _bitmap;
                pic.Width = _bitmap.Width;
                pic.Height = _bitmap.Height;
            }
            else
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "PNG Files|*.png|JPEG Files|*.jpg|Bitmap Files|*.bmp|All Files|*.*";
                    openFileDialog.Title = "ファイルを選択してください";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        Image img = Bitmap.FromFile(filePath);
                        _bitmap = new Bitmap(img);
                        pic.Image = _bitmap;
                        pic.Width = _bitmap.Width;
                        pic.Height = _bitmap.Height;
                    }
                }
            }




        }

        private void pic_Resize(object sender, EventArgs e)
        {
            txtWidth.Text = pic.Width.ToString();
            txtHeight.Text = pic.Height.ToString();
        }

        private void btnSetSize_Click(object sender, EventArgs e)
        {
            SaveUndoState();

            int widht = Int32.Parse(txtWidth.Text);
            int height = Int32.Parse(txtHeight.Text);

            pic.Width = widht;
            pic.Height = height;

            Bitmap newBitmap = new Bitmap(widht, height);

            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.DrawImage(_bitmap, new Point(0, 0));
            }
            _bitmap = newBitmap;
            pic.Image = _bitmap;
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Files|*.png|JPEG Files|*.jpg|Bitmap Files|*.bmp";
                saveFileDialog.Title = "名前を付けて保存";
                saveFileDialog.DefaultExt = "png";
                saveFileDialog.AddExtension = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    ImageFormat format = ImageFormat.Png;

                    switch (Path.GetExtension(filePath).ToLower())
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }

                    _bitmap.Save(filePath, format);
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 0)
            {
                redoStack.Push((Bitmap)_bitmap.Clone());
                _bitmap = undoStack.Pop();
                pic.Image = _bitmap;
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
                undoStack.Push((Bitmap)_bitmap.Clone());
                _bitmap = redoStack.Pop();
                pic.Image = _bitmap;
            }
        }

        #region 図形
        private enum ShapeType { None, Rectangle, Triangle, Circle, Star, Fill, Text }
        private ShapeType selectedShape = ShapeType.None;

        private void btnRectang_Click(object sender, EventArgs e)
        {
            selectedShape = ShapeType.Rectangle;
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            selectedShape = ShapeType.Triangle;
        }

        private void DrawRectangle(Graphics g, Point p1, Point p2, bool fill = false)
        {
            Rectangle rect = new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y));

            if (fill)
            {
                Brush brush = new SolidBrush(_selectedcolor);
                g.FillRectangle(brush, rect);
            }
            else
            {
                int penWidth = Int32.Parse(cmbWidth.SelectedItem.ToString());
                Pen pen = new Pen(_selectedcolor,penWidth);
                g.DrawRectangle(pen, rect);
            }
        }

        private void DrawTriangle(Graphics g, Point p1, Point p2, bool fill = false)
        {
            Point topPoint = new Point((p1.X + p2.X) / 2, p1.Y);
            Point leftPoint = new Point(p1.X, p2.Y);
            Point rightPoint = new Point(p2.X, p2.Y);
            Point[] points = { topPoint, leftPoint, rightPoint };

            if (fill)
            {
                Brush brush = new SolidBrush(_selectedcolor);
                g.FillPolygon(brush, points);
            }
            else
            {
                int penWidth = Int32.Parse(cmbWidth.SelectedItem.ToString());
                using (Pen pen = new Pen(_selectedcolor, penWidth))
                {
                    g.DrawPolygon(pen, points);
                }
            }
        }


        private void DrawCircle(Graphics g, Point center, int radius, bool fill = false)
        {
            Rectangle rect = new Rectangle(center.X - radius, center.Y - radius, radius * 2, radius * 2);

            if (fill)
            {
                Brush brush = new SolidBrush(_selectedcolor);
                g.FillEllipse(brush, rect);
            }
            else
            {
                int penWidth = Int32.Parse(cmbWidth.SelectedItem.ToString());
                Pen pen = new Pen(_selectedcolor,penWidth);
                g.DrawEllipse(pen, rect);
            }
        }


        private void DrawStar(Graphics g, Point center, int outerRadius, int innerRadius, int numPoints, bool fill = false)
        {
            double angleStep = Math.PI / numPoints;
            PointF[] points = new PointF[numPoints * 2];

            for (int i = 0; i < numPoints * 2; i++)
            {
                double angle = i * angleStep - Math.PI / 2;
                double radius = (i % 2 == 0) ? outerRadius : innerRadius;
                points[i] = new PointF(
                    center.X + (float)(Math.Cos(angle) * radius),
                    center.Y + (float)(Math.Sin(angle) * radius));
            }

            if (fill)
            {
                Brush brush = new SolidBrush(_selectedcolor);
                g.FillPolygon(brush, points);
            }
            else
            {
                int penWidth = Int32.Parse(cmbWidth.SelectedItem.ToString());
                Pen pen = new Pen(_selectedcolor,penWidth);
                g.DrawPolygon(pen, points);
            }
        }

        // テキストの描画位置
        private Point textLocation = Point.Empty;
        // テキストのフォント
        private Font textFont = new Font("Arial", 12);

        private void DrawText(Graphics g, Point location, string text, Font font)
        {
            using (Brush brush = new SolidBrush(_selectedcolor))
            {
                g.DrawString(text, font, brush, location);
            }
        }

        private void UpdateTextLocationAndSize(Point newLocation, int width, int height)
        {
            // 新しい位置とサイズを計算
            int x = Math.Min(textLocation.X, newLocation.X);
            int y = Math.Min(textLocation.Y, newLocation.Y);
            textLocation = new Point(x, y);
            // テキストのフォントサイズを調整
            float fontSize = Math.Max(1, Math.Min(width / 2, height));
            textFont = new Font(textFont.FontFamily, fontSize);
        }




        private void pic_Paint(object sender, PaintEventArgs e)
        {
            if (!drawFlg) return;

            switch (selectedShape)
            {
                case ShapeType.Rectangle:
                    DrawRectangle(e.Graphics, oldLocation, pic.PointToClient(MousePosition));
                    break;
                case ShapeType.Triangle:
                    DrawTriangle(e.Graphics, oldLocation, pic.PointToClient(MousePosition));
                    break;
            }
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            selectedShape = ShapeType.Circle;
        }

        private void btnStar_Click(object sender, EventArgs e)
        {
            selectedShape = ShapeType.Star;
        }

                private void btnText_Click(object sender, EventArgs e)
        {
            selectedShape = ShapeType.Text;
        }
        #endregion



        #region 反転・回転

        private void FlipImage(bool horizontal)
        {
            // 新しいビットマップを作成し、反転した画像を描画する
            Bitmap flippedBitmap = new Bitmap(_bitmap.Width, _bitmap.Height);
            using (Graphics g = Graphics.FromImage(flippedBitmap))
            {
                if (horizontal)
                {
                    // 水平方向に反転
                    g.ScaleTransform(-1, 1);
                    g.TranslateTransform(-_bitmap.Width, 0);
                }
                else
                {
                    // 垂直方向に反転
                    g.ScaleTransform(1, -1);
                    g.TranslateTransform(0, -_bitmap.Height);
                }
                // 反転した画像を描画
                g.DrawImage(_bitmap, new Point(0, 0));
            }
            // ビットマップを更新し、PictureBoxに表示
            _bitmap = flippedBitmap;
            pic.Image = _bitmap;
        }



        private void btnFlipHorizontal_Click(object sender, EventArgs e)
        {
            FlipImage(true);
        }

        private void btnFlipVertical_Click(object sender, EventArgs e)
        {
            FlipImage(false);
        }
        #endregion


        #region 塗りつぶし




        private void pic_MouseClick(object sender, MouseEventArgs e)
        {
            ;
        }

        #endregion

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_bitmap != null)
            {
                // 画像のサイズを取得
                int originalWidth = _bitmap.Width;
                int originalHeight = _bitmap.Height;

                // 印刷可能な領域のサイズを取得
                int printableWidth = e.MarginBounds.Width;
                int printableHeight = e.MarginBounds.Height;

                // 画像のアスペクト比を保持しながらサイズを調整
                float scale = Math.Min((float)printableWidth / originalWidth, (float)printableHeight / originalHeight);
                int width = (int)(originalWidth * scale);
                int height = (int)(originalHeight * scale);

                // 画像を中央に配置
                int x = e.MarginBounds.Left + (printableWidth - width) / 2;
                int y = e.MarginBounds.Top + (printableHeight - height) / 2;

                // 調整されたサイズで画像を描画
                e.Graphics.DrawImage(_bitmap, x, y, width, height);

                using (Pen borderPen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawRectangle(borderPen, x, y, width, height);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
        }

        private void pic_PaintBorder(object sender, PaintEventArgs e)
        {
            // PictureBox のサイズを取得
            int width = pic.Width;
            int height = pic.Height;

            // 黒いペンを作成
            Pen blackPen = new Pen(Color.Black);

            // PictureBox の境界を描画
            e.Graphics.DrawRectangle(blackPen, 0, 0, width - 1, height - 1);
        }


    }
}
