using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
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
            window.ConfigureWindow(menuStrip);

            Help help = new Help();
            help.ConfigureHelp(menuStrip);
        }

        public static Color Color { get; set; }
        public static int Width { get; set; }

        private void RedToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Color = Color.Red;
        }
    }
}
