using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PEScannerLibrary;

namespace DesktopAppTest
{
    public partial class Form1 : Form
    {
        int normalHeight;
        int normalWidth;
        int maximizedHeight;
        int maximizedWidth;
        String CurrentPE = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
            button_Add_File.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            button_Add_File.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            treeView_Dependencies.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            listBox_Imports.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            listBox_Exports.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            normalHeight = this.Height;
            normalWidth = this.Width;
            button_Add_File.Text = "Add File";
            button_Examine_Selected.Text = "Examine Selected";
            label_Imports.Text = "Imports";
            label_Exports.Text = "Exports";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show("Hello from Irindu!");

            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.ShowDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.FileName;
                CurrentPE = fileName;
                UpdateUI(fileName);

                ToolStripItem item = new ToolStripMenuItem();
                //Name that will apear on the menu
                item.Text = fileName;
                //Put in the Name property whatever neccessery to retrive your data on click event
                item.Name = fileName;
                //On-Click event
                item.Click += new EventHandler(item_Click);
                //Add the submenu to the parent menu
                fileToolStripMenuItemRecent.DropDownItems.Add(item);
            }

        }

        void item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            String fileName = item.Text;
            CurrentPE = fileName;
            UpdateUI(fileName);
        }

        void RecursivelyPopulateTheTree(PortableExecutable portableExecutable, TreeNodeCollection tNodes)
        {

            tNodes.Add(portableExecutable.FileName);
            if (portableExecutable.Dependencies.Count == 0)
            {
                return;
            }
            else
            {
                TreeNodeCollection tNodesNextLevel = tNodes[0].Nodes;
                foreach (object __o in portableExecutable.Dependencies)
                {
                    PortableExecutable pe = (PortableExecutable)__o;
                    // loop body
                    RecursivelyPopulateTheTree(pe, tNodesNextLevel);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if(CurrentPE != null)
            {
                String fileName = CurrentPE;
                UpdateUI(fileName);
            }

        }

        protected void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            CurrentPE = e.Node.Text;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Todo");
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            String fileName = e.Node.Text;
            UpdateUI(fileName);
        }

        void UpdateUI(String fileName) {
            treeView_Dependencies.Nodes.Clear();
            PortableExecutable pe = new PortableExecutable(fileName);
            pe.MakeDependencies();
            TreeNodeCollection tNodes = treeView_Dependencies.Nodes;

            RecursivelyPopulateTheTree(pe, tNodes);

            pe.MakeImports();
            pe.MakeExports();

            listBox_Imports.Items.Clear();
            foreach (object __o in pe.GetImports())
            {
                String import = (String)__o;
                // loop body
                listBox_Imports.Items.Add(import);
            }

            listBox_Exports.Items.Clear();
            foreach (object __o in pe.GetExports())
            {
                String import = (String)__o;
                // loop body
                listBox_Exports.Items.Add(import);
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.ShowDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.FileName;
                CurrentPE = fileName;
                UpdateUI(fileName);

                ToolStripItem item = new ToolStripMenuItem();
                //Name that will apear on the menu
                item.Text = fileName;
                //Put in the Name property whatever neccessery to retrive your data on click event
                item.Name = fileName;
                //On-Click event
                item.Click += new EventHandler(item_Click);
                //Add the submenu to the parent menu
                fileToolStripMenuItemRecent.DropDownItems.Add(item);
            }
        }

        private void aboutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Portable Executable Scanner 2018!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //Todo
            if (WindowState == FormWindowState.Maximized)
            {
                maximizedHeight = Size.Height;
                maximizedWidth = Size.Width;

                int heightFactor = maximizedHeight / normalHeight;
                int widthFactor = maximizedWidth / normalWidth;
                button_Add_File.Font = new Font(button_Add_File.Font.FontFamily, button_Add_File.Font.Size*heightFactor);
                button_Examine_Selected.Font = new Font(button_Examine_Selected.Font.FontFamily, 16);
                button_Add_File.Size = new System.Drawing.Size(button_Add_File.Size.Width*widthFactor, button_Add_File.Size.Height * heightFactor);

                treeView_Dependencies.Font = new Font(treeView_Dependencies.Font.FontFamily, 16);
                label_Imports.Font = new Font(label_Imports.Font.FontFamily, 16);
                label_Exports.Font = new Font(label_Exports.Font.FontFamily, 16);
                listBox_Imports.Font = new Font(listBox_Imports.Font.FontFamily, 16);
                listBox_Exports.Font = new Font(listBox_Exports.Font.FontFamily, 16);

                listBox_Imports.Size = new System.Drawing.Size(400, 200);
                listBox_Exports.Size = new System.Drawing.Size(400, 200);

                listBox_Imports.Anchor = AnchorStyles.Left;
                MessageBox.Show(Size.Height + " " + Size.Width);
            }
            else if (WindowState == FormWindowState.Normal) {
                MessageBox.Show(Size.Height + " " + Size.Width);
            }
        }
    }
}
