using System.Drawing;
using System.Windows.Forms;
using static Paint.DocumentForm;

namespace Paint
{
    public partial class MainForm : Form
    {
        //Setting to paint
        public static Color currentColor { get; set; }

        public static Color eraserColor = Color.White;

        public static Color lastColor;

        public static int Width {  get; set; }

        public MainForm()
        {
            InitializeComponent();
            ConfigureTSMI();
        }

        //Configuration of ToolStripMenuItem panel
        void ConfigureTSMI()
        {
            File file = new File();
            file.ConfigureFile(this, menuStrip);

            Picture picture = new Picture();
            picture.ConfigurePicture(this, menuStrip);

            Window window = new Window();
            window.ConfigureWindow(this, menuStrip);

            Help help = new Help();
            help.ConfigureHelp(menuStrip);
        }

        private void RedToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            currentColor = Color.Red;
        }

        private void GreenToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            currentColor = Color.Green;
        }

        private void BlueToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            currentColor = Color.Blue;
        }

        //Palette with multiple colors
        private void AnotherColorToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK) 
            { 
                currentColor = colorDialog.Color;
            }
        }

        private void ChangeIconSetPenThickness(object sender, System.EventArgs e)
        {
            if (DocumentForm.penThickness == 0)
            {
                toolStripButton1.Image = Image.FromFile("C:\\notSystem\\vcs\\Paint\\Images\\nothing.png");
            }

            if (DocumentForm.penThickness > 0 && DocumentForm.penThickness < 5)
            {
                toolStripButton1.Image = Image.FromFile("C:\\notSystem\\vcs\\Paint\\Images\\small.png");
            }

            if (DocumentForm.penThickness >= 5 && DocumentForm.penThickness < 15)
            {
                toolStripButton1.Image = Image.FromFile("C:\\notSystem\\vcs\\Paint\\Images\\medium.png");
            }

            if (DocumentForm.penThickness >= 15)
            {
                toolStripButton1.Image = Image.FromFile("C:\\notSystem\\vcs\\Paint\\Images\\large.png");
            }
        }

        private void ChangeToolToPencil(object sender, System.EventArgs e)
        {
            SetTool(Tool.Pencil);
        }

        private void ChangeToolToLine(object sender, System.EventArgs e)
        {
            SetTool(Tool.Line);
        }

        private void ChangeToolToCircle(object sender, System.EventArgs e)
        {
            SetTool(Tool.Circle);
        }

        private void ChangeToolToEraser(object sender, System.EventArgs e)
        {
            lastColor = currentColor;
            currentTool = Tool.Pencil;
            currentColor = eraserColor;
        }

        private void SetTool(Tool tool)
        {
            if (currentTool == Tool.Pencil && currentColor == eraserColor)
            {
                currentColor = lastColor;
            }
            currentTool = tool;
        }
    }
}
