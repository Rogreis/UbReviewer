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
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.tabPageNT = new System.Windows.Forms.TabPage();
            this.textBoxTranslatorNotes = new System.Windows.Forms.TextBox();
            this.tabPageComments = new System.Windows.Forms.TabPage();
            this.textBoxComments = new System.Windows.Forms.TextBox();
            this.panelBotton = new System.Windows.Forms.Panel();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.tabControlEdit.SuspendLayout();
            this.tabPageText.SuspendLayout();
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
            this.tabControlEdit.Size = new System.Drawing.Size(1020, 672);
            this.tabControlEdit.TabIndex = 1;
            // 
            // tabPageText
            // 
            this.tabPageText.Controls.Add(this.textBoxText);
            this.tabPageText.Location = new System.Drawing.Point(4, 29);
            this.tabPageText.Name = "tabPageText";
            this.tabPageText.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageText.Size = new System.Drawing.Size(1012, 639);
            this.tabPageText.TabIndex = 0;
            this.tabPageText.Text = "Text";
            this.tabPageText.UseVisualStyleBackColor = true;
            // 
            // textBoxText
            // 
            this.textBoxText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxText.Location = new System.Drawing.Point(3, 3);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxText.Size = new System.Drawing.Size(1006, 633);
            this.textBoxText.TabIndex = 0;
            // 
            // tabPageNT
            // 
            this.tabPageNT.Controls.Add(this.textBoxTranslatorNotes);
            this.tabPageNT.Location = new System.Drawing.Point(4, 29);
            this.tabPageNT.Name = "tabPageNT";
            this.tabPageNT.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNT.Size = new System.Drawing.Size(836, 461);
            this.tabPageNT.TabIndex = 1;
            this.tabPageNT.Text = "Translator\'s Notes";
            this.tabPageNT.UseVisualStyleBackColor = true;
            // 
            // textBoxTranslatorNotes
            // 
            this.textBoxTranslatorNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTranslatorNotes.Location = new System.Drawing.Point(3, 3);
            this.textBoxTranslatorNotes.Multiline = true;
            this.textBoxTranslatorNotes.Name = "textBoxTranslatorNotes";
            this.textBoxTranslatorNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTranslatorNotes.Size = new System.Drawing.Size(830, 455);
            this.textBoxTranslatorNotes.TabIndex = 1;
            // 
            // tabPageComments
            // 
            this.tabPageComments.Controls.Add(this.textBoxComments);
            this.tabPageComments.Location = new System.Drawing.Point(4, 29);
            this.tabPageComments.Name = "tabPageComments";
            this.tabPageComments.Size = new System.Drawing.Size(836, 461);
            this.tabPageComments.TabIndex = 2;
            this.tabPageComments.Text = "Comments";
            this.tabPageComments.UseVisualStyleBackColor = true;
            // 
            // textBoxComments
            // 
            this.textBoxComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxComments.Location = new System.Drawing.Point(0, 0);
            this.textBoxComments.Multiline = true;
            this.textBoxComments.Name = "textBoxComments";
            this.textBoxComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxComments.Size = new System.Drawing.Size(836, 461);
            this.textBoxComments.TabIndex = 1;
            // 
            // panelBotton
            // 
            this.panelBotton.Controls.Add(this.btOk);
            this.panelBotton.Controls.Add(this.btCancel);
            this.panelBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotton.Location = new System.Drawing.Point(0, 672);
            this.panelBotton.Name = "panelBotton";
            this.panelBotton.Size = new System.Drawing.Size(1020, 48);
            this.panelBotton.TabIndex = 2;
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(853, 6);
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
            this.btCancel.Location = new System.Drawing.Point(934, 6);
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
            this.ClientSize = new System.Drawing.Size(1020, 720);
            this.Controls.Add(this.tabControlEdit);
            this.Controls.Add(this.panelBotton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editing paragraph";
            this.Load += new System.EventHandler(this.frmEdit_Load);
            this.tabControlEdit.ResumeLayout(false);
            this.tabPageText.ResumeLayout(false);
            this.tabPageText.PerformLayout();
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
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.TabPage tabPageNT;
        private System.Windows.Forms.TextBox textBoxTranslatorNotes;
        private System.Windows.Forms.TabPage tabPageComments;
        private System.Windows.Forms.TextBox textBoxComments;
        private System.Windows.Forms.Panel panelBotton;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
    }
}