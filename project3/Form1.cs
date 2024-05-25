using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace project3
{
    public partial class Form1 : Form
    {
        private Stack<Bitmap> undoStack = new Stack<Bitmap>();
        private Stack<Bitmap> redoStack = new Stack<Bitmap>();
        private Bitmap tempBitmap = null; // �`����e���ꎞ�I�ɕۑ����邽�߂̃r�b�g�}�b�v

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

            //combbox�̎n�߂̑�����ݒ�
            cmbWidth.SelectedIndex = 0;


            // �C�x���g�n���h����ݒ�
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

            // �`��O�Ɍ��݂̏�Ԃ�ۑ�
            SaveUndoState();

            // �`�撆
            drawFlg = true;

            // �ꎞ�I�ȃr�b�g�}�b�v���쐬���A���݂̃r�b�g�}�b�v�̃R�s�[��ۑ�
            tempBitmap = (Bitmap)_bitmap.Clone();

            pic_MouseMove(sender, e);
        }

        bool drawFlg = false;   //true : �`�撆   

        Point oldLocation = new Point();
        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (!drawFlg) return;

            switch (selectedShape)
            {
                case ShapeType.Rectangle:
                case ShapeType.Triangle:
                    // �K�C�h���C���\���̂��߂ɍĕ`��
                    pic.Invalidate();
                    break;
                case ShapeType.Circle:
                    using (Graphics g = Graphics.FromImage(_bitmap))
                    {
                        g.Clear(Color.Transparent); // �ȑO�̕`�������
                        DrawCircle(g, oldLocation, Math.Max(Math.Abs(e.Location.X - oldLocation.X), Math.Abs(e.Location.Y - oldLocation.Y)));
                        pic.Image = _bitmap;
                    }
                    break;
                case ShapeType.Star:
                    using (Graphics g = Graphics.FromImage(_bitmap))
                    {
                        g.Clear(Color.Transparent); // �ȑO�̕`�������
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
            // ���݂̃r�b�g�}�b�v���R�s�[���ăX�^�b�N�ɕۑ�
            undoStack.Push((Bitmap)_bitmap.Clone());
            // REDO�X�^�b�N���N���A
            redoStack.Clear();
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            drawFlg = false;
            if (selectedShape != ShapeType.None)
            {
                using (Graphics g = Graphics.FromImage(_bitmap))
                {
                    // �ꎞ�I�ȃr�b�g�}�b�v�̓��e�𕜌�
                    g.DrawImage(tempBitmap, Point.Empty);
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

        //�S�Ẵ{�^���N���b�N

        int rrr = 0;
        int bbb = 0;
        int ggg = 0;
        int www = 0;

        private void btn_Click(object sender, EventArgs e)
        {
            _selectedcolor = ((Button)sender).BackColor;
            selectedShape = ShapeType.None; // �y�����[�h�ɖ߂�

            #region ���܂�
            if (_selectedcolor == Color.Red)
            {
                rrr++;// �ԐF�̃{�^���������ꂽ�Ƃ��̏����������ɒǉ�
            }
            else if (_selectedcolor == Color.Blue)
            {
                bbb++;// �F�̃{�^���������ꂽ�Ƃ��̏����������ɒǉ�
            }
            else if (_selectedcolor == Color.Green)
            {
                ggg++;// �ΐF�̃{�^���������ꂽ�Ƃ��̏����������ɒǉ�
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

            bool drawX = true;  //true : X����ŕ`��
                                //false : Y����ŕ`��

            if (Math.Abs(xy2.X - xy1.X) > Math.Abs(xy2.Y - xy1.Y))
            {
                //���̕����傫���ꍇ->X���Ń��[�v
                //xy2��x���傫���Ȃ�悤�ɏ���
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
                //�����̕����傫���ꍇ->Y���Ń��[�v
                //xy2��y���傫���Ȃ�悤�ɏ���
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
                //X����ŕ`��
                float y = (float)(xy1.Y);

                //�X���̌v�Z
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
                //Y����ŕ`��
                float x = (float)(xy1.X);

                //�X���̌v�Z
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
            // _bitmap �𔒂ŃN���A����̂ł͂Ȃ��A���S�ɐV�����r�b�g�}�b�v���쐬����
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
                    openFileDialog.Title = "�t�@�C����I�����Ă�������";
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
                saveFileDialog.Title = "���O��t���ĕۑ�";
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

        #region �}�`
        private enum ShapeType { None, Rectangle, Triangle, Circle, Star ,Fill}
        private ShapeType selectedShape = ShapeType.None;

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
            int penWidth = Int32.Parse(cmbWidth.SelectedItem.ToString()); // �R���{�{�b�N�X����y���̑������擾
            g.DrawEllipse(new Pen(_selectedcolor, penWidth), center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }

        private void DrawStar(Graphics g, Point center, int outerRadius, int innerRadius, int points)
        {
            int penWidth = Int32.Parse(cmbWidth.SelectedItem.ToString()); // �R���{�{�b�N�X����y���̑������擾
            PointF[] starPoints = new PointF[2 * points];

            double angle = Math.PI / points;

            for (int i = 0; i < 2 * points; i++)
            {
                double r = (i % 2 == 0) ? outerRadius : innerRadius;
                double theta = i * angle - Math.PI / 2; // ������������悤�Ɋp�x�𒲐�
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
        #endregion



        #region ���]�E��]

        private void FlipImage(bool horizontal)
        {
            // �V�����r�b�g�}�b�v���쐬���A���]�����摜��`�悷��
            Bitmap flippedBitmap = new Bitmap(_bitmap.Width, _bitmap.Height);
            using (Graphics g = Graphics.FromImage(flippedBitmap))
            {
                if (horizontal)
                {
                    // ���������ɔ��]
                    g.ScaleTransform(-1, 1);
                    g.TranslateTransform(-_bitmap.Width, 0);
                }
                else
                {
                    // ���������ɔ��]
                    g.ScaleTransform(1, -1);
                    g.TranslateTransform(0, -_bitmap.Height);
                }
                // ���]�����摜��`��
                g.DrawImage(_bitmap, new Point(0, 0));
            }
            // �r�b�g�}�b�v���X�V���APictureBox�ɕ\��
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


        #region �h��Ԃ�
        private void Fill(Point pt, Color targetColor, Color replacementColor)
        {
            if (targetColor.ToArgb() == replacementColor.ToArgb()) return;

            bool[,] visited = new bool[_bitmap.Width, _bitmap.Height];
            Queue<Point> pixels = new Queue<Point>();
            pixels.Enqueue(pt);

            while (pixels.Count > 0)
            {
                Point current = pixels.Dequeue();
                if (current.X < 0 || current.X >= _bitmap.Width || current.Y < 0 || current.Y >= _bitmap.Height)
                    continue;

                if (visited[current.X, current.Y])
                    continue;

                visited[current.X, current.Y] = true;

                if (_bitmap.GetPixel(current.X, current.Y) == targetColor)
                {
                    _bitmap.SetPixel(current.X, current.Y, replacementColor);

                    pixels.Enqueue(new Point(current.X + 1, current.Y));
                    pixels.Enqueue(new Point(current.X - 1, current.Y));
                    pixels.Enqueue(new Point(current.X, current.Y + 1));
                    pixels.Enqueue(new Point(current.X, current.Y - 1));
                }
            }
            pic.Image = _bitmap;
        }
                
        private void btnFill_Click(object sender, EventArgs e)
        {
            selectedShape = ShapeType.Fill; // �h��Ԃ����[�h�ɐݒ�
        }

        private void pic_MouseClick(object sender, MouseEventArgs e)
        {
            if (selectedShape == ShapeType.Fill)
            {
                Color targetColor = _bitmap.GetPixel(e.X, e.Y);
                if (targetColor.ToArgb() != _selectedcolor.ToArgb()) // �h��Ԃ��ׂ��ΏېF���I�����ꂽ�F�łȂ��ꍇ
                {
                    Fill(e.Location, targetColor, _selectedcolor);
                }
            }
        }

        #endregion
    }
}
