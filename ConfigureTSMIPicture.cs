using System;
using System.Windows.Forms;

namespace Paint
{
    public class ConfigureTSMIPicture
    {
        public void ConfigurePicture(MenuStrip menuStrip)
        {
            ToolStripMenuItem pictureItem = new ToolStripMenuItem("Рисунок");
            ToolStripMenuItem frameSize = new ToolStripMenuItem("Размер холста...");

            pictureItem.DropDownItems.Add(frameSize);

            frameSize.Click += FrameSizeClick;

            frameSize.ShortcutKeys = Keys.Control | Keys.F;

            menuStrip.Items.Add(pictureItem);
        }

        private void FrameSizeClick(object sender, EventArgs e)
        {
            MessageBox.Show("Рисунок - размер холста");
        }
    }
}
