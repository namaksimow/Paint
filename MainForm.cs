using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
        //Setting to paint
        public static Color Color { get; set; }

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
            Color = Color.Red;
        }

        private void GreenToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            Color = Color.Green;
        }

        private void BlueToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            Color = Color.Blue;
        }

        //Palette with multiple colors
        private void AnotherColorToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK) 
            { 
                Color = colorDialog.Color;
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
    }
}
