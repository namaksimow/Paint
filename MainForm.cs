using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
        void ConfigureTSMI()
        {
            ConfigureTSMIFile configFile = new ConfigureTSMIFile();
            configFile.ConfigureFile(menuStrip);

            ConfigureTSMIPicture configPicture = new ConfigureTSMIPicture();
            configPicture.ConfigurePicture(menuStrip);
            
            ConfigurationTSMIWindow configWindow = new ConfigurationTSMIWindow();
            configWindow.ConfigureWindow(menuStrip);
            
            ConfigureTSMIHelp configHelp = new ConfigureTSMIHelp();
            configHelp.ConfigureHelp(menuStrip);
        }


        public MainForm()
        {
            InitializeComponent();
            ConfigureTSMI();
        }

        
        
    }
}
