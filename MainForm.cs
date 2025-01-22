using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
        void ConfigureTSMI()
        {
            ConfigureTSMIFile();

            ToolStripMenuItem pictureItem = new ToolStripMenuItem("Рисунок");
            pictureItem.DropDownItems.Add("Размер холста...");

            ToolStripMenuItem windowItem = new ToolStripMenuItem("Окно");
            windowItem.DropDownItems.Add("Каскадом");
            windowItem.DropDownItems.Add("Слева направо");
            windowItem.DropDownItems.Add("Сверху вниз");
            windowItem.DropDownItems.Add("Упорядочить значки");

            ToolStripMenuItem helpItem = new ToolStripMenuItem("Справка");
            helpItem.DropDownItems.Add("О программе...");

            
            menuStrip.Items.Add(pictureItem);
            menuStrip.Items.Add(windowItem);
            menuStrip.Items.Add(helpItem);
        }

        void ConfigureTSMIFile()
        {
            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");
            ToolStripMenuItem fileOpen = new ToolStripMenuItem("Открыть...");
            ToolStripMenuItem fileNew = new ToolStripMenuItem("Новый");
            ToolStripMenuItem fileSave = new ToolStripMenuItem("Сохранить");
            ToolStripMenuItem fileSaveAs = new ToolStripMenuItem("Сохранить как...");
            ToolStripMenuItem fileExit = new ToolStripMenuItem("Выход");

            fileOpen.Click += FileOpenClick;
            fileNew.Click += FileNewClick;
            fileSave.Click += FileSaveClick;
            fileSaveAs.Click += FileSaveAsClick;
            fileExit.Click += FileExitClick;

            fileItem.DropDownItems.Add(fileNew);
            fileItem.DropDownItems.Add(fileOpen);
            fileItem.DropDownItems.Add(fileSave);
            fileItem.DropDownItems.Add(fileSaveAs);
            fileItem.DropDownItems.Add(fileExit);

            fileOpen.ShortcutKeys = Keys.Control | Keys.O;
            fileNew.ShortcutKeys = Keys.Control | Keys.N;
            fileSave.ShortcutKeys = Keys.Control | Keys.S;
            fileSaveAs.ShortcutKeys = Keys.Control | Keys.A;
            fileExit.ShortcutKeys = Keys.Control | Keys.E;

            menuStrip.Items.Add(fileItem);
        }

        void FileOpenClick(object sender, EventArgs e)
        {
            MessageBox.Show("Файл - открыть");
        }

        void FileNewClick(object sender, EventArgs e)
        {
            MessageBox.Show("Файл - новый");
        }

        void FileSaveClick(object sender, EventArgs e)
        {
            MessageBox.Show("Файл - сохранить");
        }

        void FileSaveAsClick(object sender, EventArgs e)
        {
            MessageBox.Show("Файл - сохранить как");
        }

        void FileExitClick(object sender, EventArgs e)
        {
            MessageBox.Show("Файл - выход");
        }





        public MainForm()
        {
            InitializeComponent();
            ConfigureTSMI();
            
        }

        
        
    }
}
