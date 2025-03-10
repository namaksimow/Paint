﻿using System;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Paint
{
    public class File
    {
        private MainForm _mainForm;

        //Configuratoin if file button
        public void ConfigureFile(MainForm mainForm, MenuStrip menuStrip) {
            _mainForm = mainForm;

            //Adding child elements
            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");
            ToolStripMenuItem fileOpen = new ToolStripMenuItem("Открыть...");
            ToolStripMenuItem fileNew = new ToolStripMenuItem("Новый");
            ToolStripMenuItem fileSave = new ToolStripMenuItem("Сохранить");
            ToolStripMenuItem fileSaveAs = new ToolStripMenuItem("Сохранить как...");
            ToolStripMenuItem fileExit = new ToolStripMenuItem("Выход");

            //Adding buttons
            fileItem.DropDownItems.Add(fileNew);
            fileItem.DropDownItems.Add(fileOpen);
            fileItem.DropDownItems.Insert(2, new ToolStripSeparator());
            fileItem.DropDownItems.Add(fileSave);
            fileItem.DropDownItems.Add(fileSaveAs);
            fileItem.DropDownItems.Insert(5, new ToolStripSeparator());
            fileItem.DropDownItems.Add(fileExit);

            //Adding action
            fileItem.DropDownOpened += FileItemDropDownOpening;
            fileOpen.Click += FileOpenClick;
            fileNew.Click += FileNewClick;
            fileSave.Click += FileSaveClick;
            fileSaveAs.Click += FileSaveAsClick;
            fileExit.Click += FileExitClick;

            //Adding chortcuts
            fileOpen.ShortcutKeys = Keys.Control | Keys.O;
            fileNew.ShortcutKeys = Keys.Control | Keys.N;
            fileSave.ShortcutKeys = Keys.Control | Keys.S;
            fileSaveAs.ShortcutKeys = Keys.Control | Keys.A;
            fileExit.ShortcutKeys = Keys.Control | Keys.E;

            //Add all to MenuStrip
            menuStrip.Items.Add(fileItem);
        }

        private void FileItemDropDownOpening(object sender, EventArgs e)
        {
            ToolStripMenuItem fileItem = sender as ToolStripMenuItem;

            if (fileItem != null)
            {
                ToolStripMenuItem fileSave = fileItem.DropDownItems[3] as ToolStripMenuItem;
                fileSave.Enabled = !(_mainForm.ActiveMdiChild == null);

                ToolStripMenuItem fileSaveAs = fileItem.DropDownItems[4] as ToolStripMenuItem;
                fileSaveAs.Enabled = !(_mainForm.ActiveMdiChild == null);
            }
        }

        private void FileOpenClick(object sender, EventArgs e)
        {
            var frm = new DocumentForm();
            frm.MdiParent = _mainForm;

            if (frm.Open()) 
            {
                frm.Show(); 
            }
            else
            {
                frm.Dispose(); 
            }
        }

        //open new DocumentForm
        private void FileNewClick(object sender, EventArgs e)
        {
            var frm = new DocumentForm();
            frm.MdiParent = _mainForm;
            frm.Show();
        }

        private void FileSaveClick(object sender, EventArgs e)
        {
            DocumentForm activeDocument = _mainForm.ActiveMdiChild as DocumentForm;
            if (activeDocument != null)
            {
                activeDocument.SaveFile();
            }
        }

        private void FileSaveAsClick(object sender, EventArgs e)
        {
            DocumentForm activeDocument = _mainForm.ActiveMdiChild as DocumentForm;
            if (activeDocument != null)
            {
                activeDocument.SaveFileAs();
            }
        }

        private void FileExitClick(object sender, EventArgs e)
        {
            DocumentForm activeDocument = _mainForm.ActiveMdiChild as DocumentForm;

            if (activeDocument != null) 
            {
                DialogResult dialpgResult = MessageBox.Show(
                    "Вы хотите сохранить изменения перед выходом?",
                    "Сохранение документа",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
       );

                if (dialpgResult == DialogResult.Yes)
                {
                    activeDocument.SaveFile();
                    Application.Exit();     
                }
                else if (dialpgResult == DialogResult.No)
                {
                    activeDocument.Close(); 
                    Application.Exit();
                }
            }
            else 
            {
                Application.Exit();
            }
        }
    }
}
