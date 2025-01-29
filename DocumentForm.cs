using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class DocumentForm : Form
    {
        private int x, y;

        private Bitmap bitmap;
        public DocumentForm()
        {
            InitializeComponent();
            Configuration();
            bitmap = new Bitmap(this.Width, this.Height);
        }

        //Configuration actions
        private void Configuration()
        {
            this.MouseMove += DocumentFormMouseMove;
            this.MouseDown += DocumentFormMouseDown;
            this.Resize += DocumentFormResize;
        }

        //Start of paint
        private void DocumentFormMouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        //Paint when mouse is move
        private void DocumentFormMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawLine(new Pen(MainForm.Color, MainForm.Width), x, y, e.X, e.Y);
                Invalidate();
                Update();
                x = e.X;
                y = e.Y;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        //Dynamical change of bitmap if resize of form
        private void DocumentFormResize(object sender, EventArgs e)
        {
            Bitmap newBitmap = new Bitmap(ClientSize.Width, ClientSize.Height);

            //transfer image from old to new bitmap
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.DrawImage(bitmap, 0, 0);
            }

            bitmap.Dispose();
            bitmap = newBitmap;

            Invalidate(); 
        }
    }

}

