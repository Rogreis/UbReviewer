namespace UbReviewer
{
    partial class mdiForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelBranch = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelParagraph = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelMessages = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btGit = new System.Windows.Forms.Button();
            this.btOpenDocument = new System.Windows.Forms.Button();
            this.btOpenParagraph = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.btCascace = new System.Windows.Forms.Button();
            this.btTile = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelBranch,
            this.toolStripStatusLabelParagraph,
            this.toolStripStatusLabelMessages});
            this.statusStrip1.Location = new System.Drawing.Point(0, 980);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1602, 32);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelBranch
            // 
            this.toolStripStatusLabelBranch.Name = "toolStripStatusLabelBranch";
            this.toolStripStatusLabelBranch.Size = new System.Drawing.Size(65, 25);
            this.toolStripStatusLabelBranch.Text = "Branch";
            // 
            // toolStripStatusLabelParagraph
            // 
            this.toolStripStatusLabelParagraph.Name = "toolStripStatusLabelParagraph";
            this.toolStripStatusLabelParagraph.Size = new System.Drawing.Size(92, 25);
            this.toolStripStatusLabelParagraph.Text = "Paragraph";
            // 
            // toolStripStatusLabelMessages
            // 
            this.toolStripStatusLabelMessages.Name = "toolStripStatusLabelMessages";
            this.toolStripStatusLabelMessages.Size = new System.Drawing.Size(1430, 25);
            this.toolStripStatusLabelMessages.Spring = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btTile);
            this.panel1.Controls.Add(this.btCascace);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.btGit);
            this.panel1.Controls.Add(this.btOpenDocument);
            this.panel1.Controls.Add(this.btOpenParagraph);
            this.panel1.Controls.Add(this.btExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1602, 84);
            this.panel1.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(94, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 5;
            // 
            // btGit
            // 
            this.btGit.Location = new System.Drawing.Point(598, 21);
            this.btGit.Name = "btGit";
            this.btGit.Size = new System.Drawing.Size(75, 40);
            this.btGit.TabIndex = 3;
            this.btGit.Text = "Git";
            this.btGit.UseVisualStyleBackColor = true;
            this.btGit.Click += new System.EventHandler(this.btGit_Click);
            // 
            // btOpenDocument
            // 
            this.btOpenDocument.Location = new System.Drawing.Point(413, 21);
            this.btOpenDocument.Name = "btOpenDocument";
            this.btOpenDocument.Size = new System.Drawing.Size(179, 40);
            this.btOpenDocument.TabIndex = 2;
            this.btOpenDocument.Text = "Open Document";
            this.btOpenDocument.UseVisualStyleBackColor = true;
            this.btOpenDocument.Click += new System.EventHandler(this.btOpenDocument_Click);
            // 
            // btOpenParagraph
            // 
            this.btOpenParagraph.Location = new System.Drawing.Point(228, 21);
            this.btOpenParagraph.Name = "btOpenParagraph";
            this.btOpenParagraph.Size = new System.Drawing.Size(179, 40);
            this.btOpenParagraph.TabIndex = 1;
            this.btOpenParagraph.Text = "Open Paragraph";
            this.btOpenParagraph.UseVisualStyleBackColor = true;
            this.btOpenParagraph.Click += new System.EventHandler(this.btOpenParagraph_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(13, 21);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 40);
            this.btExit.TabIndex = 0;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btCascace
            // 
            this.btCascace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCascace.Location = new System.Drawing.Point(1410, 21);
            this.btCascace.Name = "btCascace";
            this.btCascace.Size = new System.Drawing.Size(87, 40);
            this.btCascace.TabIndex = 6;
            this.btCascace.Text = "Cascade";
            this.btCascace.UseVisualStyleBackColor = true;
            this.btCascace.Click += new System.EventHandler(this.btCascace_Click);
            // 
            // btTile
            // 
            this.btTile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTile.Location = new System.Drawing.Point(1503, 21);
            this.btTile.Name = "btTile";
            this.btTile.Size = new System.Drawing.Size(87, 40);
            this.btTile.TabIndex = 7;
            this.btTile.Text = "Tile";
            this.btTile.UseVisualStyleBackColor = true;
            this.btTile.Click += new System.EventHandler(this.btTile_Click);
            // 
            // mdiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1602, 1012);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.IsMdiContainer = true;
            this.Name = "mdiForm";
            this.Text = "UB Reviewer";
            this.Load += new System.EventHandler(this.mdiForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelBranch;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelParagraph;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMessages;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btGit;
        private System.Windows.Forms.Button btOpenDocument;
        private System.Windows.Forms.Button btOpenParagraph;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btCascace;
        private System.Windows.Forms.Button btTile;
    }
}

