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
    public partial class InputPenThickness : Form
    {
        public int PenThickness { get; set; }

        private TextBox textWidth;
        private TextBox textLength;
        private Button buttonOk;
        private Button buttonCancel;
        private Label labelWidth;
        private Label labelLength;

        public InputPenThickness()
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
            //Initializaion of elements
            textWidth = new TextBox
            {
                Location = new Point(100, 20),
                Size = new Size(120, 20)
            };

            labelWidth = new Label
            {
                Text = "Толщина:",
                Location = new Point(20, 20),
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

        private void ButtonOkClick(object sender, EventArgs e)
        {
            int thickness;

            if (int.TryParse(textWidth.Text, out thickness))
            {
                if (thickness >= 0)
                {
                    PenThickness = thickness;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Толщина пера должна быть неотрицательным числом");
                }
            }
            else
            {
                MessageBox.Show("Введите корректное значение для толщины пера");
            }
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
