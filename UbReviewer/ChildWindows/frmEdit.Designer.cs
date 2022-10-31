namespace UbReviewer.ChildWindows
{
    partial class frmEdit
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
            this.tabControlEdit = new System.Windows.Forms.TabControl();
            this.tabPageText = new System.Windows.Forms.TabPage();
            this.splitContainerTexts = new System.Windows.Forms.SplitContainer();
            this.webBrowserEnglishText = new System.Windows.Forms.WebBrowser();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.tabPageNT = new System.Windows.Forms.TabPage();
            this.textBoxTranslatorNotes = new System.Windows.Forms.TextBox();
            this.tabPageComments = new System.Windows.Forms.TabPage();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.panelBotton = new System.Windows.Forms.Panel();
            this.btNext = new System.Windows.Forms.Button();
            this.btPrevious = new System.Windows.Forms.Button();
            this.btClosed = new System.Windows.Forms.Button();
            this.btDoubt = new System.Windows.Forms.Button();
            this.btDone = new System.Windows.Forms.Button();
            this.btWorking = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.tabControlEdit.SuspendLayout();
            this.tabPageText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTexts)).BeginInit();
            this.splitContainerTexts.Panel1.SuspendLayout();
            this.splitContainerTexts.Panel2.SuspendLayout();
            this.splitContainerTexts.SuspendLayout();
            this.tabPageNT.SuspendLayout();
            this.tabPageComments.SuspendLayout();
            this.panelBotton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlEdit
            // 
            this.tabControlEdit.Controls.Add(this.tabPageText);
            this.tabControlEdit.Controls.Add(this.tabPageNT);
            this.tabControlEdit.Controls.Add(this.tabPageComments);
            this.tabControlEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEdit.Location = new System.Drawing.Point(0, 0);
            this.tabControlEdit.Name = "tabControlEdit";
            this.tabControlEdit.SelectedIndex = 0;
            this.tabControlEdit.Size = new System.Drawing.Size(1135, 735);
            this.tabControlEdit.TabIndex = 1;
            // 
            // tabPageText
            // 
            this.tabPageText.Controls.Add(this.splitContainerTexts);
            this.tabPageText.Location = new System.Drawing.Point(4, 29);
            this.tabPageText.Name = "tabPageText";
            this.tabPageText.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageText.Size = new System.Drawing.Size(1127, 702);
            this.tabPageText.TabIndex = 0;
            this.tabPageText.Text = "Text";
            this.tabPageText.UseVisualStyleBackColor = true;
            // 
            // splitContainerTexts
            // 
            this.splitContainerTexts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTexts.Location = new System.Drawing.Point(3, 3);
            this.splitContainerTexts.Name = "splitContainerTexts";
            this.splitContainerTexts.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTexts.Panel1
            // 
            this.splitContainerTexts.Panel1.Controls.Add(this.webBrowserEnglishText);
            // 
            // splitContainerTexts.Panel2
            // 
            this.splitContainerTexts.Panel2.Controls.Add(this.textBoxText);
            this.splitContainerTexts.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerTexts.Size = new System.Drawing.Size(1121, 696);
            this.splitContainerTexts.SplitterDistance = 312;
            this.splitContainerTexts.TabIndex = 1;
            // 
            // webBrowserEnglishText
            // 
            this.webBrowserEnglishText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserEnglishText.Location = new System.Drawing.Point(0, 0);
            this.webBrowserEnglishText.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserEnglishText.Name = "webBrowserEnglishText";
            this.webBrowserEnglishText.Size = new System.Drawing.Size(1121, 312);
            this.webBrowserEnglishText.TabIndex = 0;
            // 
            // textBoxText
            // 
            this.textBoxText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxText.HideSelection = false;
            this.textBoxText.Location = new System.Drawing.Point(5, 5);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxText.Size = new System.Drawing.Size(1111, 370);
            this.textBoxText.TabIndex = 0;
            // 
            // tabPageNT
            // 
            this.tabPageNT.Controls.Add(this.textBoxTranslatorNotes);
            this.tabPageNT.Location = new System.Drawing.Point(4, 29);
            this.tabPageNT.Name = "tabPageNT";
            this.tabPageNT.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNT.Size = new System.Drawing.Size(1127, 702);
            this.tabPageNT.TabIndex = 1;
            this.tabPageNT.Text = "Translator\'s Notes";
            this.tabPageNT.UseVisualStyleBackColor = true;
            // 
            // textBoxTranslatorNotes
            // 
            this.textBoxTranslatorNotes.AcceptsReturn = true;
            this.textBoxTranslatorNotes.AcceptsTab = true;
            this.textBoxTranslatorNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTranslatorNotes.Location = new System.Drawing.Point(3, 3);
            this.textBoxTranslatorNotes.Multiline = true;
            this.textBoxTranslatorNotes.Name = "textBoxTranslatorNotes";
            this.textBoxTranslatorNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTranslatorNotes.Size = new System.Drawing.Size(1121, 696);
            this.textBoxTranslatorNotes.TabIndex = 1;
            // 
            // tabPageComments
            // 
            this.tabPageComments.Controls.Add(this.textBoxNotes);
            this.tabPageComments.Location = new System.Drawing.Point(4, 29);
            this.tabPageComments.Name = "tabPageComments";
            this.tabPageComments.Size = new System.Drawing.Size(1127, 702);
            this.tabPageComments.TabIndex = 2;
            this.tabPageComments.Text = "Comments";
            this.tabPageComments.UseVisualStyleBackColor = true;
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.AcceptsReturn = true;
            this.textBoxNotes.AcceptsTab = true;
            this.textBoxNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNotes.Location = new System.Drawing.Point(0, 0);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNotes.Size = new System.Drawing.Size(1127, 702);
            this.textBoxNotes.TabIndex = 1;
            // 
            // panelBotton
            // 
            this.panelBotton.Controls.Add(this.btNext);
            this.panelBotton.Controls.Add(this.btPrevious);
            this.panelBotton.Controls.Add(this.btClosed);
            this.panelBotton.Controls.Add(this.btDoubt);
            this.panelBotton.Controls.Add(this.btDone);
            this.panelBotton.Controls.Add(this.btWorking);
            this.panelBotton.Controls.Add(this.btOk);
            this.panelBotton.Controls.Add(this.btCancel);
            this.panelBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotton.Location = new System.Drawing.Point(0, 735);
            this.panelBotton.Name = "panelBotton";
            this.panelBotton.Size = new System.Drawing.Size(1135, 48);
            this.panelBotton.TabIndex = 2;
            // 
            // btNext
            // 
            this.btNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNext.Image = global::UbReviewer.Properties.Resources.arrow_right_3;
            this.btNext.Location = new System.Drawing.Point(850, 6);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 36);
            this.btNext.TabIndex = 7;
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btPrevious
            // 
            this.btPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrevious.Image = global::UbReviewer.Properties.Resources.arrow_left_3;
            this.btPrevious.Location = new System.Drawing.Point(769, 6);
            this.btPrevious.Name = "btPrevious";
            this.btPrevious.Size = new System.Drawing.Size(75, 36);
            this.btPrevious.TabIndex = 6;
            this.btPrevious.UseVisualStyleBackColor = true;
            this.btPrevious.Click += new System.EventHandler(this.btPrevious_Click);
            // 
            // btClosed
            // 
            this.btClosed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClosed.Location = new System.Drawing.Point(631, 6);
            this.btClosed.Name = "btClosed";
            this.btClosed.Size = new System.Drawing.Size(75, 36);
            this.btClosed.TabIndex = 5;
            this.btClosed.Text = "Closed";
            this.btClosed.UseVisualStyleBackColor = true;
            this.btClosed.Click += new System.EventHandler(this.btClosed_Click);
            // 
            // btDoubt
            // 
            this.btDoubt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDoubt.Location = new System.Drawing.Point(537, 6);
            this.btDoubt.Name = "btDoubt";
            this.btDoubt.Size = new System.Drawing.Size(75, 36);
            this.btDoubt.TabIndex = 4;
            this.btDoubt.Text = "Doubt";
            this.btDoubt.UseVisualStyleBackColor = true;
            this.btDoubt.Click += new System.EventHandler(this.btDoubt_Click);
            // 
            // btDone
            // 
            this.btDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDone.Location = new System.Drawing.Point(443, 6);
            this.btDone.Name = "btDone";
            this.btDone.Size = new System.Drawing.Size(75, 36);
            this.btDone.TabIndex = 3;
            this.btDone.Text = "Done";
            this.btDone.UseVisualStyleBackColor = true;
            this.btDone.Click += new System.EventHandler(this.btDone_Click);
            // 
            // btWorking
            // 
            this.btWorking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btWorking.Location = new System.Drawing.Point(349, 6);
            this.btWorking.Name = "btWorking";
            this.btWorking.Size = new System.Drawing.Size(75, 36);
            this.btWorking.TabIndex = 2;
            this.btWorking.Text = "Working";
            this.btWorking.UseVisualStyleBackColor = true;
            this.btWorking.Click += new System.EventHandler(this.btWorking_Click);
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(967, 6);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 36);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.Location = new System.Drawing.Point(1048, 6);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 36);
            this.btCancel.TabIndex = 0;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // frmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 783);
            this.Controls.Add(this.tabControlEdit);
            this.Controls.Add(this.panelBotton);
            this.Name = "frmEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editing paragraph";
            this.Load += new System.EventHandler(this.frmEdit_Load);
            this.tabControlEdit.ResumeLayout(false);
            this.tabPageText.ResumeLayout(false);
            this.splitContainerTexts.Panel1.ResumeLayout(false);
            this.splitContainerTexts.Panel2.ResumeLayout(false);
            this.splitContainerTexts.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTexts)).EndInit();
            this.splitContainerTexts.ResumeLayout(false);
            this.tabPageNT.ResumeLayout(false);
            this.tabPageNT.PerformLayout();
            this.tabPageComments.ResumeLayout(false);
            this.tabPageComments.PerformLayout();
            this.panelBotton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlEdit;
        private System.Windows.Forms.TabPage tabPageText;
        private System.Windows.Forms.TabPage tabPageNT;
        private System.Windows.Forms.TextBox textBoxTranslatorNotes;
        private System.Windows.Forms.TabPage tabPageComments;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Panel panelBotton;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.SplitContainer splitContainerTexts;
        private System.Windows.Forms.WebBrowser webBrowserEnglishText;
        private System.Windows.Forms.Button btClosed;
        private System.Windows.Forms.Button btDoubt;
        private System.Windows.Forms.Button btDone;
        private System.Windows.Forms.Button btWorking;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.Button btPrevious;
        private System.Windows.Forms.Button btNext;
    }
}