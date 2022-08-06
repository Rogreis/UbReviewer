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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanelDocument = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 702);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1289, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tableLayoutPanelDocument
            // 
            this.tableLayoutPanelDocument.ColumnCount = 3;
            this.tableLayoutPanelDocument.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelDocument.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelDocument.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDocument.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelDocument.Name = "tableLayoutPanelDocument";
            this.tableLayoutPanelDocument.RowCount = 5;
            this.tableLayoutPanelDocument.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDocument.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDocument.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDocument.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDocument.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDocument.Size = new System.Drawing.Size(1289, 702);
            this.tableLayoutPanelDocument.TabIndex = 3;
            // 
            // frmDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 724);
            this.Controls.Add(this.tableLayoutPanelDocument);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmDocument";
            this.Text = "frmDocument";
            this.Load += new System.EventHandler(this.frmDocument_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDocument;
    }
}