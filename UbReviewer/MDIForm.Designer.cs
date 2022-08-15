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
            this.btTile = new System.Windows.Forms.Button();
            this.btCascace = new System.Windows.Forms.Button();
            this.comboBoxPaperNo = new System.Windows.Forms.ComboBox();
            this.btGit = new System.Windows.Forms.Button();
            this.btOpenDocument = new System.Windows.Forms.Button();
            this.btOpenParagraph = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.comboBoxPaperNo);
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
            // comboBoxPaperNo
            // 
            this.comboBoxPaperNo.FormattingEnabled = true;
            this.comboBoxPaperNo.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100",
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110",
            "111",
            "112",
            "113",
            "114",
            "115",
            "116",
            "117",
            "118",
            "119",
            "120",
            "121",
            "122",
            "123",
            "124",
            "125",
            "126",
            "127",
            "128",
            "129",
            "130",
            "131",
            "132",
            "133",
            "134",
            "135",
            "136",
            "137",
            "138",
            "139",
            "140",
            "141",
            "142",
            "143",
            "144",
            "145",
            "146",
            "147",
            "148",
            "149",
            "150",
            "151",
            "152",
            "153",
            "154",
            "155",
            "156",
            "157",
            "158",
            "159",
            "160",
            "161",
            "162",
            "163",
            "164",
            "165",
            "166",
            "167",
            "168",
            "169",
            "170",
            "171",
            "172",
            "173",
            "174",
            "175",
            "176",
            "177",
            "178",
            "179",
            "180",
            "181",
            "182",
            "183",
            "184",
            "185",
            "186",
            "187",
            "188",
            "189",
            "190",
            "191",
            "192",
            "193",
            "194",
            "195",
            "196"});
            this.comboBoxPaperNo.Location = new System.Drawing.Point(113, 28);
            this.comboBoxPaperNo.Name = "comboBoxPaperNo";
            this.comboBoxPaperNo.Size = new System.Drawing.Size(92, 28);
            this.comboBoxPaperNo.TabIndex = 5;
            this.comboBoxPaperNo.Text = "0";
            this.comboBoxPaperNo.SelectedValueChanged += new System.EventHandler(this.comboBoxPaperNo_SelectedValueChanged);
            // 
            // btGit
            // 
            this.btGit.Location = new System.Drawing.Point(405, 21);
            this.btGit.Name = "btGit";
            this.btGit.Size = new System.Drawing.Size(75, 40);
            this.btGit.TabIndex = 3;
            this.btGit.Text = "Git";
            this.btGit.UseVisualStyleBackColor = true;
            this.btGit.Click += new System.EventHandler(this.btGit_Click);
            // 
            // btOpenDocument
            // 
            this.btOpenDocument.Location = new System.Drawing.Point(220, 21);
            this.btOpenDocument.Name = "btOpenDocument";
            this.btOpenDocument.Size = new System.Drawing.Size(179, 40);
            this.btOpenDocument.TabIndex = 2;
            this.btOpenDocument.Text = "Open Document";
            this.btOpenDocument.UseVisualStyleBackColor = true;
            this.btOpenDocument.Click += new System.EventHandler(this.btOpenDocument_Click);
            // 
            // btOpenParagraph
            // 
            this.btOpenParagraph.Location = new System.Drawing.Point(486, 21);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mdiForm_FormClosing);
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
        private System.Windows.Forms.ComboBox comboBoxPaperNo;
        private System.Windows.Forms.Button btGit;
        private System.Windows.Forms.Button btOpenDocument;
        private System.Windows.Forms.Button btOpenParagraph;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btCascace;
        private System.Windows.Forms.Button btTile;
    }
}

