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
        public MainForm()
        {
            InitializeComponent();

            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");

            ToolStripMenuItem open = new ToolStripMenuItem("Открыть...");
            open.Click += open_Click;

            fileItem.DropDownItems.Add("Новый");
            fileItem.DropDownItems.Add(open);
            fileItem.DropDownItems.Add("Сохранить");
            fileItem.DropDownItems.Add("Сохранить как...");
            fileItem.DropDownItems.Add("Выход");
            open.ShortcutKeys = Keys.Control | Keys.O;

            ToolStripMenuItem pictureItem = new ToolStripMenuItem("Рисунок");
            pictureItem.DropDownItems.Add("Размер холста...");

            ToolStripMenuItem windowItem = new ToolStripMenuItem("Окно");
            windowItem.DropDownItems.Add("Каскадом");
            windowItem.DropDownItems.Add("Слева направо");
            windowItem.DropDownItems.Add("Сверху вниз");
            windowItem.DropDownItems.Add("Упорядочить значки");

            ToolStripMenuItem helpItem = new ToolStripMenuItem("Справка");
            helpItem.DropDownItems.Add("О программе...");

            menuStrip.Items.Add(fileItem);
            menuStrip.Items.Add(pictureItem);
            menuStrip.Items.Add(windowItem);
            menuStrip.Items.Add(helpItem);
        }

        void open_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Открытие");
        }
        
    }
}
