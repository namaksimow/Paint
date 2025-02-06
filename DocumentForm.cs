using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Paint
{
    public partial class DocumentForm : Form
    {
        public string currentFilePath = null;

        public ImageFormat currentFormat = null;

        public static int penThickness = 0;

        public enum Tool {Nothing, Pencil, Line, Circle, Eraser}

        public static Tool currentTool = Tool.Nothing;

        private int x, y;

        public Bitmap bitmap { get; set; }

        private Bitmap bitmapTemp;
        public DocumentForm()
        {
            InitializeComponent();
            Configuration();
            bitmap = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
        }

        //Configuration actions
        private void Configuration()
        {
            this.MouseMove += DocumentFormMouseMove;
            this.MouseDown += DocumentFormMouseDown;
            this.MouseUp += DocumentFormMouseUp;
            this.Resize += DocumentFormResize;
        }

        //Start of paint
        private void DocumentFormMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
        }

        //Paint when mouse is move
        private void DocumentFormMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (penThickness == 0)
                {
                    return;
                }

                using (Brush brush = new SolidBrush(MainForm.currentColor))
                using (Pen pen = new Pen(MainForm.currentColor, penThickness))
                {
                    switch (currentTool)
                    {
                        case Tool.Pencil:
                            DrawCirclesBetween(x, y, e.X, e.Y, Graphics.FromImage(bitmap), brush);
                            x = e.X;
                            y = e.Y;
                            break;
                        case Tool.Circle:
                            bitmapTemp = (Bitmap)bitmap.Clone();
                            using (Graphics graphicsLocal = Graphics.FromImage(bitmapTemp))
                            {
                                int rectX = Math.Min(x, e.X);
                                int rectY = Math.Min(y, e.Y);
                                int width = Math.Abs(e.X - x);
                                int height = Math.Abs(e.Y - y);

                                if (width > 0 && height > 0)
                                {
                                    graphicsLocal.DrawEllipse(pen, new Rectangle(rectX, rectY, width, height));
                                }
                            }
                            break;
                        case Tool.Line:
                            bitmapTemp = (Bitmap)bitmap.Clone();
                            using (Graphics graphicsLocal = Graphics.FromImage(bitmapTemp))
                            {
                                graphicsLocal.DrawLine(pen, x, y, e.X, e.Y);
                            }
                            break;
                    }
                }
                Invalidate();
            }
        }

        private void DrawCirclesBetween(int startX, int startY, int endX, int endY, Graphics g, Brush brush)
        {
            float distance = (float)Math.Sqrt((endX - startX) * (endX - startX) + (endY - startY) * (endY - startY));

            if (distance > penThickness)
            {
                int numCircles = (int)(distance / penThickness);
                for (int i = 0; i <= numCircles; i++)
                {
                    float ratio = (float)i / numCircles;
                    int x = (int)(startX + ratio * (endX - startX));
                    int y = (int)(startY + ratio * (endY - startY));
                    g.FillEllipse(brush, x - penThickness, y - penThickness, penThickness * 2, penThickness * 2);
                    g.DrawEllipse(new Pen(MainForm.currentColor), x - penThickness, y - penThickness, penThickness * 2, penThickness * 2);
                }
            }
            else
            {
                g.FillEllipse(brush, endX - penThickness, endY - penThickness, penThickness * 2, penThickness * 2);
                g.DrawEllipse(new Pen(MainForm.currentColor), endX - penThickness, endY - penThickness, penThickness * 2, penThickness * 2);
            }
        }

        private void DocumentFormMouseUp(object sender, MouseEventArgs e)
        {
            if (penThickness == 0)
            {
                return;
            }

            if ((currentTool == Tool.Circle || currentTool == Tool.Line) && bitmapTemp != null)
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(bitmapTemp, 0, 0);
                }
                bitmapTemp.Dispose();
                bitmapTemp = null;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if ((currentTool == Tool.Circle || currentTool == Tool.Line) && bitmapTemp != null)
            {
                e.Graphics.DrawImage(bitmapTemp, 0, 0);
            }
            else
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
        }


        //Dynamical change of bitmap if resize of form
        private void DocumentFormResize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                Bitmap newBitmap = new Bitmap(ClientSize.Width, ClientSize.Height);

                //transfer image from old to new bitmap
                using (Graphics g = Graphics.FromImage(newBitmap))
                {
                    g.Clear(Color.White);
                    g.DrawImage(bitmap, 0, 0);
                }

                bitmap.Dispose();
                bitmap = newBitmap;

                Invalidate();
            }
        }

        public void SaveFile()
        {
            if (currentFilePath == null)
            {
                SaveFileAs();
            }
            else
            {
                try
                {
                    bitmap.Save(currentFilePath, currentFormat);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении файла: " + ex.Message);
                }
            }
        }

        public void SaveFileAs()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpg)|*.jpg | Файлы PNG (*.png)|*.png";
            ImageFormat[] ff = { ImageFormat.Bmp, ImageFormat.Jpeg, ImageFormat.Png };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                bitmap.Save(dlg.FileName, ff[dlg.FilterIndex - 1]);
                currentFilePath = dlg.FileName;
                currentFormat = ff[dlg.FilterIndex - 1];
            }
        }

        public bool Open()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp|Файлы JPEG (*.jpeg, *.jpg)|*.jpeg;*.jpg|Все файлы (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (bitmap != null)
                {
                    bitmap.Dispose();
                }

                bitmap = new Bitmap(dlg.FileName);
                currentFilePath = dlg.FileName;
                string extension = Path.GetExtension(dlg.FileName);
                switch (extension)
                {
                    case ".bmp":
                        currentFormat = ImageFormat.Bmp;
                        break;
                    case ".jpg":
                        currentFormat = ImageFormat.Jpeg;
                        break;
                    case ".png":
                        currentFormat = ImageFormat.Png;
                        break;
                }

                ClientSize = new Size(bitmap.Width, bitmap.Height);

                Invalidate();

                return true;
            }

            return false;
        }


        public static void SetPenThickness(object sender, EventArgs e)
        {
            using (InputPenThickness inputPenThickness = new InputPenThickness())
            {
                if (inputPenThickness.ShowDialog() == DialogResult.OK)
                {
                    penThickness = inputPenThickness.PenThickness;
                }
            }
        }

        public void FileSaveClick(object sender, EventArgs e)
        {
            SaveFile();
        }

        
    }
}