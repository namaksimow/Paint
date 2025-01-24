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
        public void ConfigureHelp(MenuStrip menuStrip)
        {
            ToolStripMenuItem helpItem = new ToolStripMenuItem("Справка");
            ToolStripMenuItem helpAbout = new ToolStripMenuItem("О программе...");

            helpItem.DropDownItems.Add(helpAbout);

            helpAbout.ShortcutKeys = Keys.Control | Keys.B;

            menuStrip.Items.Add(helpItem);
        }

        private void HelpAboutClick(object sender, EventArgs e)
        {
            MessageBox.Show("Справка - о программе");
        }

    }
}
