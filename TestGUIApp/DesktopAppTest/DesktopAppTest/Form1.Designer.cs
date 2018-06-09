namespace DesktopAppTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_Add_File = new System.Windows.Forms.Button();
            this.treeView_Dependencies = new System.Windows.Forms.TreeView();
            this.button_Examine_Selected = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItemRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.label_Imports = new System.Windows.Forms.Label();
            this.label_Exports = new System.Windows.Forms.Label();
            this.listBox_Imports = new System.Windows.Forms.ListBox();
            this.listBox_Exports = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Add_File
            // 
            this.button_Add_File.Location = new System.Drawing.Point(39, 296);
            this.button_Add_File.Name = "button_Add_File";
            this.button_Add_File.Size = new System.Drawing.Size(75, 23);
            this.button_Add_File.TabIndex = 0;
            this.button_Add_File.TabStop = false;
            this.button_Add_File.Text = "Add File";
            this.button_Add_File.UseVisualStyleBackColor = true;
            this.button_Add_File.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView_Dependencies
            // 
            this.treeView_Dependencies.Location = new System.Drawing.Point(12, 57);
            this.treeView_Dependencies.Name = "treeView_Dependencies";
            this.treeView_Dependencies.Size = new System.Drawing.Size(336, 97);
            this.treeView_Dependencies.TabIndex = 1;
            this.treeView_Dependencies.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView_Dependencies.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // button_Examine_Selected
            // 
            this.button_Examine_Selected.Location = new System.Drawing.Point(146, 296);
            this.button_Examine_Selected.Name = "button_Examine_Selected";
            this.button_Examine_Selected.Size = new System.Drawing.Size(117, 23);
            this.button_Examine_Selected.TabIndex = 2;
            this.button_Examine_Selected.Text = "Examine Selected";
            this.button_Examine_Selected.UseVisualStyleBackColor = true;
            this.button_Examine_Selected.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItemOpen,
            this.fileToolStripMenuItemRecent,
            this.fileToolStripMenuItemExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // fileToolStripMenuItemOpen
            // 
            this.fileToolStripMenuItemOpen.Name = "fileToolStripMenuItemOpen";
            this.fileToolStripMenuItemOpen.Size = new System.Drawing.Size(180, 22);
            this.fileToolStripMenuItemOpen.Text = "Open";
            this.fileToolStripMenuItemOpen.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // fileToolStripMenuItemRecent
            // 
            this.fileToolStripMenuItemRecent.Name = "fileToolStripMenuItemRecent";
            this.fileToolStripMenuItemRecent.Size = new System.Drawing.Size(180, 22);
            this.fileToolStripMenuItemRecent.Text = "Recent";
            // 
            // fileToolStripMenuItemExit
            // 
            this.fileToolStripMenuItemExit.Name = "fileToolStripMenuItemExit";
            this.fileToolStripMenuItemExit.Size = new System.Drawing.Size(180, 22);
            this.fileToolStripMenuItemExit.Text = "Exit";
            this.fileToolStripMenuItemExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todoToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // todoToolStripMenuItem1
            // 
            this.todoToolStripMenuItem1.Name = "todoToolStripMenuItem1";
            this.todoToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.todoToolStripMenuItem1.Text = "Todo";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todoToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // todoToolStripMenuItem
            // 
            this.todoToolStripMenuItem.Name = "todoToolStripMenuItem";
            this.todoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.todoToolStripMenuItem.Text = "Todo";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItemAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItemAbout
            // 
            this.helpToolStripMenuItemAbout.Name = "helpToolStripMenuItemAbout";
            this.helpToolStripMenuItemAbout.Size = new System.Drawing.Size(180, 22);
            this.helpToolStripMenuItemAbout.Text = "About";
            this.helpToolStripMenuItemAbout.Click += new System.EventHandler(this.aboutToolStripMenuItem2_Click);
            // 
            // label_Imports
            // 
            this.label_Imports.AutoSize = true;
            this.label_Imports.Font = new System.Drawing.Font("Monaco", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Imports.Location = new System.Drawing.Point(383, 40);
            this.label_Imports.Name = "label_Imports";
            this.label_Imports.Size = new System.Drawing.Size(71, 16);
            this.label_Imports.TabIndex = 4;
            this.label_Imports.Text = "Imports";
            // 
            // label_Exports
            // 
            this.label_Exports.AutoSize = true;
            this.label_Exports.Font = new System.Drawing.Font("Monaco", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Exports.Location = new System.Drawing.Point(383, 239);
            this.label_Exports.Name = "label_Exports";
            this.label_Exports.Size = new System.Drawing.Size(70, 17);
            this.label_Exports.TabIndex = 5;
            this.label_Exports.Text = "Exports";
            // 
            // listBox_Imports
            // 
            this.listBox_Imports.FormattingEnabled = true;
            this.listBox_Imports.Location = new System.Drawing.Point(386, 73);
            this.listBox_Imports.MaximumSize = new System.Drawing.Size(600, 200);
            this.listBox_Imports.Name = "listBox_Imports";
            this.listBox_Imports.Size = new System.Drawing.Size(295, 95);
            this.listBox_Imports.TabIndex = 6;
            // 
            // listBox_Exports
            // 
            this.listBox_Exports.FormattingEnabled = true;
            this.listBox_Exports.Location = new System.Drawing.Point(386, 277);
            this.listBox_Exports.Name = "listBox_Exports";
            this.listBox_Exports.Size = new System.Drawing.Size(290, 95);
            this.listBox_Exports.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox_Exports);
            this.Controls.Add(this.listBox_Imports);
            this.Controls.Add(this.label_Exports);
            this.Controls.Add(this.label_Imports);
            this.Controls.Add(this.button_Examine_Selected);
            this.Controls.Add(this.treeView_Dependencies);
            this.Controls.Add(this.button_Add_File);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Portable Executable Scanner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Add_File;
        private System.Windows.Forms.Button button_Examine_Selected;
        private System.Windows.Forms.TreeView treeView_Dependencies;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItemRecent;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItemAbout;
        private System.Windows.Forms.Label label_Imports;
        private System.Windows.Forms.Label label_Exports;
        private System.Windows.Forms.ListBox listBox_Imports;
        private System.Windows.Forms.ListBox listBox_Exports;
        private System.Windows.Forms.ToolStripMenuItem todoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem todoToolStripMenuItem;
    }
}

