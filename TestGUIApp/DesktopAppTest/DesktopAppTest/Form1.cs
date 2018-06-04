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

        String CurrentPE = null;
        public Form1()
        {
            InitializeComponent();
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
                recentToolStripMenuItem.DropDownItems.Add(item);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Add File";
            button2.Text = "Examine Selected";

           
            label1.Text = "Imports";

            label2.Text = "Exports";

            //listView1.Items.Add("abc");

            //listView2.Items.Add("Exports");

            //listView1.Items.Add("abc");


            //listView1.View = View.Details;
            //listView1.GridLines = true;
            //listView1.FullRowSelect = true;


            ////Add column header
            //listView1.Columns.Add("ProductName", 100);
            //listView1.Columns.Add("Price", 70);
            //listView1.Columns.Add("Quantity", 70);

            ////Add items in the listview
            //string[] arr = new string[4];
            //ListViewItem itm;

            ////Add first item
            //arr[0] = "product_1";
            //arr[1] = "100";
            //arr[2] = "10";
            //itm = new ListViewItem(arr);
            //listView1.Items.Add(itm);

            ////Add second item
            //arr[0] = "product_2";
            //arr[1] = "200";
            //arr[2] = "20";
            //itm = new ListViewItem(arr);
            //listView1.Items.Add(itm);

            //for (int i = 0; i < 10; i++) {
            //    listView1.Items.Add("Some Text");
            //}
           
            //   TreeNode tNode;
            //    tNode = treeView1.Nodes.Add("Websites");

            //treeView1.Nodes[0].Nodes.Add("Net-informations.com");
            //treeView1.Nodes[0].Nodes[0].Nodes.Add("CLR");

            //treeView1.Nodes[0].Nodes.Add("Vb.net-informations.com");
            //treeView1.Nodes[0].Nodes[1].Nodes.Add("String Tutorial");
            //treeView1.Nodes[0].Nodes[1].Nodes.Add("Excel Tutorial");

            //treeView1.Nodes[0].Nodes.Add("Csharp.net-informations.com");
            //treeView1.Nodes[0].Nodes[2].Nodes.Add("ADO.NET");
            //treeView1.Nodes[0].Nodes[2].Nodes[0].Nodes.Add("Dataset");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dlg = new openfiledialog();
            //dlg.showdialog();

            //if (dlg.showdialog() == dialogresult.ok)
            //{
            //    string filename;
            //    filename = dlg.filename;
            //    MessageBox.show(filename);

            //    treenode tnode;
            //    tnode = treeview1.nodes.add(filename);

            //}

            //if (treeView1.SelectedNode != null)
            //{
            //    String fileName = treeView1.SelectedNode.Name;
            //    treeView1.Nodes.Clear();
            //    PortableExecutable pe = new PortableExecutable(fileName);
            //    pe.makeDependencies();
            //    //TreeNode tNode;
            //    //tNode = treeView1.Nodes.Add(fileName);
            //    MessageBox.Show(fileName);
            //    TreeNodeCollection tNodes = treeView1.Nodes;

            //    RecursivelyPopulateTheTree(pe, tNodes);

            //}
            if(CurrentPE != null)
            {
                String fileName = CurrentPE;
                UpdateUI(fileName);
            }

        }

        protected void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            // Determine by checking the Text property.  
            //  MessageBox.Show(e.Node.Text);
            CurrentPE = e.Node.Text;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Todo");
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           // MessageBox.Show(e.Node.Text);

            String fileName = e.Node.Text;
            UpdateUI(fileName);
        }

        void UpdateUI(String fileName) {
            treeView1.Nodes.Clear();
            PortableExecutable pe = new PortableExecutable(fileName);
            pe.makeDependencies();
            //TreeNode tNode;
            //tNode = treeView1.Nodes.Add(fileName);
            //  MessageBox.Show(fileName);
            TreeNodeCollection tNodes = treeView1.Nodes;

            RecursivelyPopulateTheTree(pe, tNodes);

            pe.makeImports();
            pe.makeExports();

            listBox1.Items.Clear();
            foreach (object __o in pe.getImports())
            {
                String import = (String)__o;

                // loop body
                listBox1.Items.Add(import);
            }

            listBox2.Items.Clear();
            foreach (object __o in pe.getExports())
            {
                String import = (String)__o;

                // loop body
                listBox2.Items.Add(import);
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
                recentToolStripMenuItem.DropDownItems.Add(item);
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
    }
}
