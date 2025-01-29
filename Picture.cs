using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public class Picture
    {
        //Mainform parameter
        private MainForm _mainForm;

        //Configuration
        public void ConfigurePicture(MainForm mainForm, MenuStrip menuStrip)
        {
            _mainForm = mainForm;

            ToolStripMenuItem pictureItem = new ToolStripMenuItem("Рисунок");
            ToolStripMenuItem frameSize = new ToolStripMenuItem("Размер холста...");

            pictureItem.DropDownItems.Add(frameSize);

            pictureItem.DropDownOpening += PictureItemDropDownOpening;
            frameSize.Click += FrameSizeClick;

            frameSize.ShortcutKeys = Keys.Control | Keys.F;

            menuStrip.Items.Add(pictureItem);
        }

        //Adding action to button
        private void FrameSizeClick(object sender, EventArgs e)
        {
            using (CanvasSizeForm canvasSizeForm = new CanvasSizeForm())
            {
                if (canvasSizeForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateChildFormSize(canvasSizeForm.CanvasWidth, canvasSizeForm.CanvasLength);
                }
            }
        }

        //If no DocumentForm, you cant change her size manually
        private void PictureItemDropDownOpening(object sender, EventArgs e)
        {
            ToolStripMenuItem pictureItem = sender as ToolStripMenuItem;

            if (pictureItem != null)
            {
                ToolStripMenuItem frameSize = pictureItem.DropDownItems[0] as ToolStripMenuItem;
                frameSize.Enabled =! (_mainForm.ActiveMdiChild == null);
            }
        }

        //Updating DocumentForm size
        private void UpdateChildFormSize(int newWidth, int newLength)
        {
            if (_mainForm.ActiveMdiChild is Form childForm)
            {
                childForm.Size = new Size(newWidth, newLength);
                MessageBox.Show("Размер холста изменен!");
            }
            else
            {
                MessageBox.Show("Вы не ещё не открыли документ");
            }
        }
    }
}
