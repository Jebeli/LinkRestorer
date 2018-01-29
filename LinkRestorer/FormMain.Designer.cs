namespace LinkRestorer
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonScan = new System.Windows.Forms.Button();
            this.listBoxLinks = new System.Windows.Forms.ListBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.listBoxFailed = new System.Windows.Forms.ListBox();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonSymLink = new System.Windows.Forms.RadioButton();
            this.radioButtonJunction = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 484);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(640, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(640, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanLinksToolStripMenuItem,
            this.saveLinksToolStripMenuItem,
            this.loadLinksToolStripMenuItem,
            this.checkLinksToolStripMenuItem,
            this.restoreLinksToolStripMenuItem,
            this.removeSelectedLinksToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // scanLinksToolStripMenuItem
            // 
            this.scanLinksToolStripMenuItem.Name = "scanLinksToolStripMenuItem";
            this.scanLinksToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.scanLinksToolStripMenuItem.Text = "Scan Links";
            this.scanLinksToolStripMenuItem.Click += new System.EventHandler(this.scanLinksToolStripMenuItem_Click);
            // 
            // saveLinksToolStripMenuItem
            // 
            this.saveLinksToolStripMenuItem.Name = "saveLinksToolStripMenuItem";
            this.saveLinksToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.saveLinksToolStripMenuItem.Text = "Save Links";
            this.saveLinksToolStripMenuItem.Click += new System.EventHandler(this.saveLinksToolStripMenuItem_Click);
            // 
            // loadLinksToolStripMenuItem
            // 
            this.loadLinksToolStripMenuItem.Name = "loadLinksToolStripMenuItem";
            this.loadLinksToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.loadLinksToolStripMenuItem.Text = "Load Links";
            this.loadLinksToolStripMenuItem.Click += new System.EventHandler(this.loadLinksToolStripMenuItem_Click);
            // 
            // checkLinksToolStripMenuItem
            // 
            this.checkLinksToolStripMenuItem.Name = "checkLinksToolStripMenuItem";
            this.checkLinksToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.checkLinksToolStripMenuItem.Text = "Check Links";
            this.checkLinksToolStripMenuItem.Click += new System.EventHandler(this.checkLinksToolStripMenuItem_Click);
            // 
            // restoreLinksToolStripMenuItem
            // 
            this.restoreLinksToolStripMenuItem.Name = "restoreLinksToolStripMenuItem";
            this.restoreLinksToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.restoreLinksToolStripMenuItem.Text = "Restore Links";
            this.restoreLinksToolStripMenuItem.Click += new System.EventHandler(this.restoreLinksToolStripMenuItem_Click);
            // 
            // removeSelectedLinksToolStripMenuItem
            // 
            this.removeSelectedLinksToolStripMenuItem.Name = "removeSelectedLinksToolStripMenuItem";
            this.removeSelectedLinksToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.removeSelectedLinksToolStripMenuItem.Text = "Remove Selected Links";
            this.removeSelectedLinksToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedLinksToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(191, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(5, 3);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(75, 23);
            this.buttonScan.TabIndex = 2;
            this.buttonScan.Text = "Scan";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // listBoxLinks
            // 
            this.listBoxLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLinks.FormattingEnabled = true;
            this.listBoxLinks.Location = new System.Drawing.Point(3, 18);
            this.listBoxLinks.Name = "listBoxLinks";
            this.listBoxLinks.Size = new System.Drawing.Size(634, 194);
            this.listBoxLinks.TabIndex = 3;
            this.listBoxLinks.SelectedIndexChanged += new System.EventHandler(this.listBoxLinks_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(86, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(167, 3);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 5;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(248, 3);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 6;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // listBoxFailed
            // 
            this.listBoxFailed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFailed.FormattingEnabled = true;
            this.listBoxFailed.Location = new System.Drawing.Point(3, 18);
            this.listBoxFailed.Name = "listBoxFailed";
            this.listBoxFailed.Size = new System.Drawing.Size(634, 93);
            this.listBoxFailed.TabIndex = 7;
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(329, 3);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(75, 23);
            this.buttonRestore.TabIndex = 8;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // textBoxSource
            // 
            this.textBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSource.Location = new System.Drawing.Point(93, 21);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(454, 22);
            this.textBoxSource.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Source:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Destination:";
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDestination.Location = new System.Drawing.Point(93, 46);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(454, 22);
            this.textBoxDestination.TabIndex = 12;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.Location = new System.Drawing.Point(553, 19);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 13;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(553, 44);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 14;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxFailed);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 370);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 114);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Missing Links";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxLinks);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(640, 215);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Links";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonSymLink);
            this.groupBox3.Controls.Add(this.radioButtonJunction);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxSource);
            this.groupBox3.Controls.Add(this.buttonDelete);
            this.groupBox3.Controls.Add(this.textBoxDestination);
            this.groupBox3.Controls.Add(this.buttonCreate);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(640, 100);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Link";
            // 
            // radioButtonSymLink
            // 
            this.radioButtonSymLink.AutoSize = true;
            this.radioButtonSymLink.Location = new System.Drawing.Point(106, 77);
            this.radioButtonSymLink.Name = "radioButtonSymLink";
            this.radioButtonSymLink.Size = new System.Drawing.Size(70, 17);
            this.radioButtonSymLink.TabIndex = 20;
            this.radioButtonSymLink.TabStop = true;
            this.radioButtonSymLink.Text = "Symbolic";
            this.radioButtonSymLink.UseVisualStyleBackColor = true;
            this.radioButtonSymLink.CheckedChanged += new System.EventHandler(this.radioButtonSymLink_CheckedChanged);
            // 
            // radioButtonJunction
            // 
            this.radioButtonJunction.AutoSize = true;
            this.radioButtonJunction.Location = new System.Drawing.Point(15, 77);
            this.radioButtonJunction.Name = "radioButtonJunction";
            this.radioButtonJunction.Size = new System.Drawing.Size(69, 17);
            this.radioButtonJunction.TabIndex = 19;
            this.radioButtonJunction.TabStop = true;
            this.radioButtonJunction.Text = "Junction";
            this.radioButtonJunction.UseVisualStyleBackColor = true;
            this.radioButtonJunction.CheckedChanged += new System.EventHandler(this.radioButtonJunction_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRemove);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.buttonRestore);
            this.panel1.Controls.Add(this.buttonScan);
            this.panel1.Controls.Add(this.buttonCheck);
            this.panel1.Controls.Add(this.buttonLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 31);
            this.panel1.TabIndex = 20;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(410, 3);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 9;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 506);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Link Restorer";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.ListBox listBoxLinks;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ListBox listBoxFailed;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanLinksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLinksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadLinksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkLinksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreLinksToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonSymLink;
        private System.Windows.Forms.RadioButton radioButtonJunction;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedLinksToolStripMenuItem;
    }
}

