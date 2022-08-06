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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBoxLeft = new System.Windows.Forms.RichTextBox();
            this.richTextBoxMiddle = new System.Windows.Forms.RichTextBox();
            this.richTextBoxRight = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 723);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1096, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.richTextBoxRight, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBoxMiddle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBoxLeft, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1096, 723);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // richTextBoxLeft
            // 
            this.richTextBoxLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLeft.Location = new System.Drawing.Point(5, 5);
            this.richTextBoxLeft.Margin = new System.Windows.Forms.Padding(5);
            this.richTextBoxLeft.Name = "richTextBoxLeft";
            this.richTextBoxLeft.Size = new System.Drawing.Size(318, 713);
            this.richTextBoxLeft.TabIndex = 0;
            this.richTextBoxLeft.Text = "";
            // 
            // richTextBoxMiddle
            // 
            this.richTextBoxMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMiddle.Location = new System.Drawing.Point(333, 5);
            this.richTextBoxMiddle.Margin = new System.Windows.Forms.Padding(5);
            this.richTextBoxMiddle.Name = "richTextBoxMiddle";
            this.richTextBoxMiddle.Size = new System.Drawing.Size(318, 713);
            this.richTextBoxMiddle.TabIndex = 1;
            this.richTextBoxMiddle.Text = "";
            // 
            // richTextBoxRight
            // 
            this.richTextBoxRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxRight.Location = new System.Drawing.Point(661, 5);
            this.richTextBoxRight.Margin = new System.Windows.Forms.Padding(5);
            this.richTextBoxRight.Name = "richTextBoxRight";
            this.richTextBoxRight.Size = new System.Drawing.Size(430, 713);
            this.richTextBoxRight.TabIndex = 2;
            this.richTextBoxRight.Text = "";
            // 
            // frmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 745);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmEdit";
            this.Text = "Editing paragraph";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBoxRight;
        private System.Windows.Forms.RichTextBox richTextBoxMiddle;
        private System.Windows.Forms.RichTextBox richTextBoxLeft;
    }
}