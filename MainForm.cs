using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
        public static Color Color { get; set; }
        public static int Width { get; set; }

        void ConfigureTSMI()
        {
            File file = new File();
            file.ConfigureFile(this, menuStrip);

            Picture picture = new Picture();
            picture.ConfigurePicture(menuStrip);
            
            Window window = new Window();
            window.ConfigureWindow(menuStrip);

            Help help = new Help();
            help.ConfigureHelp(menuStrip);
        }


        public MainForm()
        {
            InitializeComponent();
            ConfigureTSMI();
        }
    }
}
