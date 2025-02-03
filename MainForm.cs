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
    }
}
