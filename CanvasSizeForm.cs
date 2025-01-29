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
        //parameters to DocumentForm
        public int CanvasWidth { get; set; }
        public int CanvasLength { get; set; }

        //elements of form
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

        /// <summary>
        /// Initialization of propertys
        /// </summary>
        private void InitializePropertys()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// Initialization, Configuration of forms elements
        /// </summary>
        private void InitializeControls()
        {
            //Initializaion of elements
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

            buttonCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(140, 100),
                Size = new Size(75, 25)
            };

            //Initialization of actions
            buttonOk.Click += ButtonOkClick;
            buttonCancel.Click += ButtonCancelClick;

            //Adding controls
            AcceptButton = buttonOk;
            CancelButton = buttonCancel;
            Controls.Add(textWidth);
            Controls.Add(textLength);
            Controls.Add(buttonOk);
            Controls.Add(buttonCancel);
            Controls.Add(labelWidth);
            Controls.Add(labelLength);
        }

        /// <summary>
        /// Getting new width and length to DocumentForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOkClick(object sender, EventArgs e)
        {
            int width, length;

            if (int.TryParse(textWidth.Text, out width) && int.TryParse(textLength.Text, out length))
            {
                if (width > 0 && length > 0)
                {
                    CanvasWidth = width;
                    CanvasLength = length;
                    DialogResult = DialogResult.OK;
                    Close();
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

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
