using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public class Help
    {
        //Configuration of help button
        public void ConfigureHelp(MenuStrip menuStrip)
        {
            ToolStripMenuItem helpItem = new ToolStripMenuItem("Справка");
            ToolStripMenuItem helpAbout = new ToolStripMenuItem("О программе...");

            helpItem.DropDownItems.Add(helpAbout);

            helpAbout.Click += HelpAboutClick;
            
            helpAbout.ShortcutKeys = Keys.Control | Keys.B;

            menuStrip.Items.Add(helpItem);
        }

        //Click and get AboutForm
        private void HelpAboutClick(object sender, EventArgs e)
        {
            var formAbout = new AboutForm();
            formAbout.ShowDialog();
        }

    }
}
