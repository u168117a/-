using System.Drawing;
using System.Drawing.Imaging;

namespace project3
{
    public partial class Form1 : Form
    {
        private Stack<Bitmap> undoStack = new Stack<Bitmap>();
        private Stack<Bitmap> redoStack = new Stack<Bitmap>();

        public Form1()
        {
            InitializeComponent();
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

            //描画中
            drawFlg = true;

            pic_MouseMove(sender, e);
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
                    switch (selectedShape)
                    {
                        case ShapeType.Rectangle:
                            DrawRectangle(g, oldLocation, e.Location);
                            break;
                        case ShapeType.Triangle:
                            DrawTriangle(g, oldLocation, e.Location);
                            break;
                        case ShapeType.Circle:
                            DrawCircle(g, oldLocation, Math.Max(Math.Abs(e.Location.X - oldLocation.X), Math.Abs(e.Location.Y - oldLocation.Y)));
                            break;
                        case ShapeType.Star:
                            DrawStar(g, oldLocation, Math.Max(Math.Abs(e.Location.X - oldLocation.X), Math.Abs(e.Location.Y - oldLocation.Y)) / 2, Math.Max(Math.Abs(e.Location.X - oldLocation.X), Math.Abs(e.Location.Y - oldLocation.Y)) / 4, 5);
                            break;
                    }
                }
                pic.Image = _bitmap;
            }
        }

        Color _selectedcolor = Color.Black;

        //全てのボタンクリック
        private void btn_Click(object sender, EventArgs e)
        {
            _selectedcolor = ((Button)sender).BackColor;
            selectedShape = ShapeType.None; // ペンモードに戻す
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
            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                g.FillRectangle(Brushes.White, new Rectangle(0, 0, _bitmap.Width, _bitmap.Height));
            }
            pic.Image = _bitmap;
        }

        private void btnLoad_Click(object sender, EventArgs e)
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

        private void pic_Resize(object sender, EventArgs e)
        {
            txtWidth.Text = pic.Width.ToString();
            txtHeight.Text = pic.Height.ToString();
        }

        private void btnSetSize_Click(object sender, EventArgs e)
        {
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
        private enum ShapeType { None, Rectangle, Triangle, Circle, Star }
        private ShapeType selectedShape = ShapeType.None;


        #endregion

        private void btnRectang_Click(object sender, EventArgs e)
        {
            selectedShape = ShapeType.Rectangle;
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            selectedShape = ShapeType.Triangle;
        }

        private void DrawRectangle(Graphics g, Point startPoint, Point endPoint)
        {
            int width = endPoint.X - startPoint.X;
            int height = endPoint.Y - startPoint.Y;
            int penWidth = Int32.Parse(cmbWidth.SelectedItem.ToString());
            using (Pen pen = new Pen(_selectedcolor, penWidth))
            {
                g.DrawRectangle(pen, startPoint.X, startPoint.Y, width, height);
            }
        }

        private void DrawTriangle(Graphics g, Point startPoint, Point endPoint)
        {
            Point topPoint = new Point((startPoint.X + endPoint.X) / 2, startPoint.Y);
            Point leftPoint = new Point(startPoint.X, endPoint.Y);
            Point rightPoint = new Point(endPoint.X, endPoint.Y);
            Point[] points = { topPoint, leftPoint, rightPoint };
            int penWidth = Int32.Parse(cmbWidth.SelectedItem.ToString());
            using (Pen pen = new Pen(_selectedcolor, penWidth))
            {
                g.DrawPolygon(pen, points);
            }
        }

        private void DrawCircle(Graphics g, Point center, int radius)
        {
            int penWidth = Int32.Parse(cmbWidth.SelectedItem.ToString()); // コンボボックスからペンの太さを取得
            g.DrawEllipse(new Pen(_selectedcolor, penWidth), center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }

        private void DrawStar(Graphics g, Point center, int outerRadius, int innerRadius, int points)
        {
            int penWidth = Int32.Parse(cmbWidth.SelectedItem.ToString()); // コンボボックスからペンの太さを取得
            PointF[] starPoints = new PointF[2 * points];

            double angle = Math.PI / points;

            for (int i = 0; i < 2 * points; i++)
            {
                double r = (i % 2 == 0) ? outerRadius : innerRadius;
                double theta = i * angle - Math.PI / 2; // 上方向を向くように角度を調整
                starPoints[i] = new PointF((float)(center.X + r * Math.Cos(theta)), (float)(center.Y + r * Math.Sin(theta)));
            }

            g.DrawPolygon(new Pen(_selectedcolor, penWidth), starPoints);
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

    }
}
