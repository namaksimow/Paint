using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public class Window
    {
        //Configuration of window button
        public void ConfigureWindow(MenuStrip menuStrip)
        {
            //Adding child buttons
            ToolStripMenuItem windowItem = new ToolStripMenuItem("Окно");
            ToolStripMenuItem windowCascade = new ToolStripMenuItem("Каскадом");
            ToolStripMenuItem windowLeftToRight = new ToolStripMenuItem("Слева направо");
            ToolStripMenuItem windowUpToDown = new ToolStripMenuItem("Сверху вниз");
            ToolStripMenuItem windowStraight = new ToolStripMenuItem("Упорядочить значки");

            //Adding buttons
            windowItem.DropDownItems.Add(windowCascade);
            windowItem.DropDownItems.Add(windowLeftToRight);
            windowItem.DropDownItems.Add(windowUpToDown);
            windowItem.DropDownItems.Add(windowStraight);

            //Adding action to buttons
            windowCascade.Click += WindowCascadeClick;
            windowLeftToRight.Click += WindowLeftToRightClick;
            windowUpToDown.Click += WindowUpToDownClick;
            windowStraight.Click += WindowStraightClick;

            //Adding shortcuts
            windowCascade.ShortcutKeys = Keys.Control | Keys.C;
            windowLeftToRight.ShortcutKeys = Keys.Control | Keys.L;
            windowUpToDown.ShortcutKeys = Keys.Control | Keys.U;
            windowStraight.ShortcutKeys = Keys.Control | Keys.T;

            //Add to MenuStrip
            menuStrip.Items.Add(windowItem);
            menuStrip.MdiWindowListItem = windowItem;
        }

        private void WindowCascadeClick(object sender, EventArgs e)
        {
            MessageBox.Show("Окно - каскад");
        }

        private void WindowLeftToRightClick(object sender, EventArgs e)
        {
            MessageBox.Show("Окно - слева направо");
        }

        private void WindowUpToDownClick(object sender, EventArgs e)
        {
            MessageBox.Show("Окно - сверзу вниз");
        }

        private void WindowStraightClick(object sender, EventArgs e)
        {
            MessageBox.Show("Окно - упорядочить значки");
        }
    }
}
