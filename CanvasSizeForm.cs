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
    public partial class CanvasSizeForm : Form
    {
        public int CanvasWidth { get; set; }
        public int CanvasLength { get; set; }

        private TextBox textWidth;
        private TextBox textLength;
        private Button buttonOk;
        private Button buttonCancel;
        private Label labelWidth;
        private Label labelLength;

        public CanvasSizeForm()
        {
            InitializeComponent();

            InitializePropertys();
            
            InitializeControls();
        }

        private void InitializePropertys()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void InitializeControls()
        {
            textWidth = new TextBox
            {
                Location = new Point(100, 20),
                Size = new Size(120, 20)
            };

            textLength = new TextBox
            {
                Location = new Point(100, 60),
                Size = new Size(120, 20)
            };

            labelWidth = new Label
            {
                Text = "Ширина:",
                Location = new Point(20, 20),
                Size = new Size(80, 20)
            };

            labelLength = new Label
            {
                Text = "Высота:",
                Location = new Point(20, 60),
                Size = new Size(80, 20)
            };

            buttonOk = new Button
            {
                Text = "OK",
                Location = new Point(40, 100),
                Size = new Size(75, 25)
            };

            buttonOk.Click += BtnOKClick;

            buttonCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(140, 100),
                Size = new Size(75, 25)
            };

            buttonCancel.Click += BtnCancel_Click;

            AcceptButton = buttonOk;
            CancelButton = buttonCancel;
            Controls.Add(textWidth);
            Controls.Add(textLength);
            Controls.Add(buttonOk);
            Controls.Add(buttonCancel);
            Controls.Add(labelWidth);
            Controls.Add(labelLength);
        }

        private void BtnOKClick(object sender, EventArgs e)
        {
            int width, length;

            if (int.TryParse(textWidth.Text, out width) && int.TryParse(textLength.Text, out length))
            {
                if (width > 0 && length > 0)
                {
                    CanvasWidth = width;
                    CanvasLength = length;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Размеры должны быть положительными числами");
                }
            }
            else
            {
                MessageBox.Show("Введите корректные значения для размеров");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
