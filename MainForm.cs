using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
        void ConfigureTSMI()
        {
            File file = new File();
            file.ConfigureFile(menuStrip);

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
