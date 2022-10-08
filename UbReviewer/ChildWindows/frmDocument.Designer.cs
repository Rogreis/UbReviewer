namespace UbReviewer.ChildWindows
{
    partial class frmDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocument));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelIdent = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.webBrowserPaper = new System.Windows.Forms.WebBrowser();
            this.toolStripDocument = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonDescreaseSize = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonIncreaseSize = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButtonFontType = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItemSerifFont = new System.Windows.Forms.ToolStripMenuItem();
            this.nonSerifToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.toolStripDocument.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelIdent,
            this.toolStripStatusLabelMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 702);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1289, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelIdent
            // 
            this.toolStripStatusLabelIdent.Name = "toolStripStatusLabelIdent";
            this.toolStripStatusLabelIdent.Size = new System.Drawing.Size(0, 15);
            // 
            // toolStripStatusLabelMessage
            // 
            this.toolStripStatusLabelMessage.Name = "toolStripStatusLabelMessage";
            this.toolStripStatusLabelMessage.Size = new System.Drawing.Size(1274, 15);
            this.toolStripStatusLabelMessage.Spring = true;
            // 
            // webBrowserPaper
            // 
            this.webBrowserPaper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserPaper.Location = new System.Drawing.Point(0, 0);
            this.webBrowserPaper.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPaper.Name = "webBrowserPaper";
            this.webBrowserPaper.Size = new System.Drawing.Size(1289, 702);
            this.webBrowserPaper.TabIndex = 3;
            // 
            // toolStripDocument
            // 
            this.toolStripDocument.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripDocument.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonClose,
            this.toolStripSeparator1,
            this.toolStripSplitButtonFontType,
            this.toolStripLabel1,
            this.toolStripButtonDescreaseSize,
            this.toolStripButtonIncreaseSize});
            this.toolStripDocument.Location = new System.Drawing.Point(0, 0);
            this.toolStripDocument.Name = "toolStripDocument";
            this.toolStripDocument.Size = new System.Drawing.Size(1289, 34);
            this.toolStripDocument.TabIndex = 4;
            this.toolStripDocument.Text = "Tools for Document";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClose.Image")));
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(34, 29);
            this.toolStripButtonClose.Text = "Close";
            this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(93, 29);
            this.toolStripLabel1.Text = "Font Size: ";
            // 
            // toolStripButtonDescreaseSize
            // 
            this.toolStripButtonDescreaseSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDescreaseSize.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDescreaseSize.Image")));
            this.toolStripButtonDescreaseSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDescreaseSize.Name = "toolStripButtonDescreaseSize";
            this.toolStripButtonDescreaseSize.Size = new System.Drawing.Size(34, 29);
            this.toolStripButtonDescreaseSize.Text = "toolStripButton2";
            this.toolStripButtonDescreaseSize.Click += new System.EventHandler(this.toolStripButtonDescreaseSize_Click);
            // 
            // toolStripButtonIncreaseSize
            // 
            this.toolStripButtonIncreaseSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonIncreaseSize.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonIncreaseSize.Image")));
            this.toolStripButtonIncreaseSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonIncreaseSize.Name = "toolStripButtonIncreaseSize";
            this.toolStripButtonIncreaseSize.Size = new System.Drawing.Size(34, 29);
            this.toolStripButtonIncreaseSize.Text = "toolStripButton3";
            this.toolStripButtonIncreaseSize.Click += new System.EventHandler(this.toolStripButtonIncreaseSize_Click);
            // 
            // toolStripSplitButtonFontType
            // 
            this.toolStripSplitButtonFontType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButtonFontType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSerifFont,
            this.nonSerifToolStripMenuItem});
            this.toolStripSplitButtonFontType.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButtonFontType.Image")));
            this.toolStripSplitButtonFontType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonFontType.Name = "toolStripSplitButtonFontType";
            this.toolStripSplitButtonFontType.Size = new System.Drawing.Size(111, 29);
            this.toolStripSplitButtonFontType.Text = "Font Type";
            // 
            // toolStripMenuItemSerifFont
            // 
            this.toolStripMenuItemSerifFont.Checked = true;
            this.toolStripMenuItemSerifFont.CheckOnClick = true;
            this.toolStripMenuItemSerifFont.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemSerifFont.Name = "toolStripMenuItemSerifFont";
            this.toolStripMenuItemSerifFont.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItemSerifFont.Text = "Serif";
            this.toolStripMenuItemSerifFont.Click += new System.EventHandler(this.toolStripMenuItemSerifFont_Click);
            // 
            // nonSerifToolStripMenuItem
            // 
            this.nonSerifToolStripMenuItem.Name = "nonSerifToolStripMenuItem";
            this.nonSerifToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.nonSerifToolStripMenuItem.Text = "Non Serif";
            this.nonSerifToolStripMenuItem.Click += new System.EventHandler(this.nonSerifToolStripMenuItem_Click);
            // 
            // frmDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 724);
            this.Controls.Add(this.toolStripDocument);
            this.Controls.Add(this.webBrowserPaper);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmDocument";
            this.Text = "Paper";
            this.Load += new System.EventHandler(this.frmDocument_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripDocument.ResumeLayout(false);
            this.toolStripDocument.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.WebBrowser webBrowserPaper;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelIdent;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMessage;
        private System.Windows.Forms.ToolStrip toolStripDocument;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonFontType;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDescreaseSize;
        private System.Windows.Forms.ToolStripButton toolStripButtonIncreaseSize;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSerifFont;
        private System.Windows.Forms.ToolStripMenuItem nonSerifToolStripMenuItem;
    }
}