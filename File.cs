using System;
using System.Windows.Forms;

namespace Paint
{
    public class File
    {
        public void ConfigureFile(MenuStrip menuStrip) {
            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");
            ToolStripMenuItem fileOpen = new ToolStripMenuItem("Открыть...");
            ToolStripMenuItem fileNew = new ToolStripMenuItem("Новый");
            ToolStripMenuItem fileSave = new ToolStripMenuItem("Сохранить");
            ToolStripMenuItem fileSaveAs = new ToolStripMenuItem("Сохранить как...");
            ToolStripMenuItem fileExit = new ToolStripMenuItem("Выход");

            fileItem.DropDownItems.Add(fileNew);
            fileItem.DropDownItems.Add(fileOpen);
            fileItem.DropDownItems.Add(fileSave);
            fileItem.DropDownItems.Add(fileSaveAs);
            fileItem.DropDownItems.Add(fileExit);

            fileOpen.Click += FileOpenClick;
            fileNew.Click += FileNewClick;
            fileSave.Click += FileSaveClick;
            fileSaveAs.Click += FileSaveAsClick;
            fileExit.Click += FileExitClick;

            fileOpen.ShortcutKeys = Keys.Control | Keys.O;
            fileNew.ShortcutKeys = Keys.Control | Keys.N;
            fileSave.ShortcutKeys = Keys.Control | Keys.S;
            fileSaveAs.ShortcutKeys = Keys.Control | Keys.A;
            fileExit.ShortcutKeys = Keys.Control | Keys.E;

            menuStrip.Items.Add(fileItem);
        }

        private void FileOpenClick(object sender, EventArgs e)
        {
            MessageBox.Show("Файл - открыть");
        }

        private void FileNewClick(object sender, EventArgs e)
        {
            MessageBox.Show("Файл - новый");
        }

        private void FileSaveClick(object sender, EventArgs e)
        {
            MessageBox.Show("Файл - сохранить");
        }

        private void FileSaveAsClick(object sender, EventArgs e)
        {
            MessageBox.Show("Файл - сохранить как");
        }

        private void FileExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
