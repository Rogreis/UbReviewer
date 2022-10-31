namespace UbReviewer.ChildWindows
{
    partial class frmGitCommands
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageParameters = new System.Windows.Forms.TabPage();
            this.splitContainerGitCommands = new System.Windows.Forms.SplitContainer();
            this.biInicialize = new System.Windows.Forms.Button();
            this.lblBookReposirotyFolder = new System.Windows.Forms.Label();
            this.btShowLog = new System.Windows.Forms.Button();
            this.txGitHubUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btPush = new System.Windows.Forms.Button();
            this.btCommitAll = new System.Windows.Forms.Button();
            this.btStageAll = new System.Windows.Forms.Button();
            this.lblRepositoryFolders = new System.Windows.Forms.Label();
            this.btStatus = new System.Windows.Forms.Button();
            this.txGitCommands = new System.Windows.Forms.TextBox();
            this.tabPageCompare = new System.Windows.Forms.TabPage();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.btAcceptMerged = new System.Windows.Forms.Button();
            this.btAcceptNew = new System.Windows.Forms.Button();
            this.btAcceptOld = new System.Windows.Forms.Button();
            this.btRefreshBranches = new System.Windows.Forms.Button();
            this.lblLocalBranch = new System.Windows.Forms.Label();
            this.comboBoxOtherBranches = new System.Windows.Forms.ComboBox();
            this.btRefresh = new System.Windows.Forms.Button();
            this.splitContainerWork = new System.Windows.Forms.SplitContainer();
            this.listBoxParagraphs = new System.Windows.Forms.ListBox();
            this.splitContainerTexts = new System.Windows.Forms.SplitContainer();
            this.splitContainerTextsTop = new System.Windows.Forms.SplitContainer();
            this.webBrowserRepoIn = new System.Windows.Forms.WebBrowser();
            this.webBrowserRepoOut = new System.Windows.Forms.WebBrowser();
            this.splitContainertextsBotton = new System.Windows.Forms.SplitContainer();
            this.webBrowserCompare = new System.Windows.Forms.WebBrowser();
            this.txTextEdit = new System.Windows.Forms.TextBox();
            this.btClose = new System.Windows.Forms.Button();
            this.btUndo = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGitCommands)).BeginInit();
            this.splitContainerGitCommands.Panel1.SuspendLayout();
            this.splitContainerGitCommands.Panel2.SuspendLayout();
            this.splitContainerGitCommands.SuspendLayout();
            this.tabPageCompare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerWork)).BeginInit();
            this.splitContainerWork.Panel1.SuspendLayout();
            this.splitContainerWork.Panel2.SuspendLayout();
            this.splitContainerWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTexts)).BeginInit();
            this.splitContainerTexts.Panel1.SuspendLayout();
            this.splitContainerTexts.Panel2.SuspendLayout();
            this.splitContainerTexts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTextsTop)).BeginInit();
            this.splitContainerTextsTop.Panel1.SuspendLayout();
            this.splitContainerTextsTop.Panel2.SuspendLayout();
            this.splitContainerTextsTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainertextsBotton)).BeginInit();
            this.splitContainertextsBotton.Panel1.SuspendLayout();
            this.splitContainertextsBotton.Panel2.SuspendLayout();
            this.splitContainertextsBotton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageParameters);
            this.tabControlMain.Controls.Add(this.tabPageCompare);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1428, 1019);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageParameters
            // 
            this.tabPageParameters.Controls.Add(this.splitContainerGitCommands);
            this.tabPageParameters.Location = new System.Drawing.Point(4, 29);
            this.tabPageParameters.Name = "tabPageParameters";
            this.tabPageParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParameters.Size = new System.Drawing.Size(1420, 986);
            this.tabPageParameters.TabIndex = 1;
            this.tabPageParameters.Text = "Parameters";
            this.tabPageParameters.UseVisualStyleBackColor = true;
            // 
            // splitContainerGitCommands
            // 
            this.splitContainerGitCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerGitCommands.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerGitCommands.IsSplitterFixed = true;
            this.splitContainerGitCommands.Location = new System.Drawing.Point(3, 3);
            this.splitContainerGitCommands.Name = "splitContainerGitCommands";
            this.splitContainerGitCommands.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerGitCommands.Panel1
            // 
            this.splitContainerGitCommands.Panel1.Controls.Add(this.btExit);
            this.splitContainerGitCommands.Panel1.Controls.Add(this.btUndo);
            this.splitContainerGitCommands.Panel1.Controls.Add(this.btClose);
            this.splitContainerGitCommands.Panel1.Controls.Add(this.biInicialize);
            this.splitContainerGitCommands.Panel1.Controls.Add(this.lblBookReposirotyFolder);
            this.splitContainerGitCommands.Panel1.Controls.Add(this.btShowLog);
            this.splitContainerGitCommands.Panel1.Controls.Add(this.txGitHubUserName);
            this.splitContainerGitCommands.Panel1.Controls.Add(this.label1);
            this.splitContainerGitCommands.Panel1.Controls.Add(this.btPush);
            this.splitContainerGitCommands.Panel1.Controls.Add(this.btCommitAll);
            this.splitContainerGitCommands.Panel1.Controls.Add(this.btStageAll);
            this.splitContainerGitCommands.Panel1.Controls.Add(this.lblRepositoryFolders);
            this.splitContainerGitCommands.Panel1.Controls.Add(this.btStatus);
            // 
            // splitContainerGitCommands.Panel2
            // 
            this.splitContainerGitCommands.Panel2.Controls.Add(this.txGitCommands);
            this.splitContainerGitCommands.Size = new System.Drawing.Size(1414, 980);
            this.splitContainerGitCommands.SplitterDistance = 169;
            this.splitContainerGitCommands.TabIndex = 1;
            // 
            // biInicialize
            // 
            this.biInicialize.BackColor = System.Drawing.Color.LightSteelBlue;
            this.biInicialize.Location = new System.Drawing.Point(21, 107);
            this.biInicialize.Name = "biInicialize";
            this.biInicialize.Size = new System.Drawing.Size(122, 47);
            this.biInicialize.TabIndex = 20;
            this.biInicialize.Text = "Inicialize";
            this.biInicialize.UseVisualStyleBackColor = false;
            this.biInicialize.Click += new System.EventHandler(this.biInicialize_Click);
            // 
            // lblBookReposirotyFolder
            // 
            this.lblBookReposirotyFolder.AutoSize = true;
            this.lblBookReposirotyFolder.Location = new System.Drawing.Point(17, 75);
            this.lblBookReposirotyFolder.Name = "lblBookReposirotyFolder";
            this.lblBookReposirotyFolder.Size = new System.Drawing.Size(175, 20);
            this.lblBookReposirotyFolder.TabIndex = 19;
            this.lblBookReposirotyFolder.Text = "Book Repository Folder";
            // 
            // btShowLog
            // 
            this.btShowLog.BackColor = System.Drawing.Color.Silver;
            this.btShowLog.Location = new System.Drawing.Point(789, 107);
            this.btShowLog.Name = "btShowLog";
            this.btShowLog.Size = new System.Drawing.Size(122, 47);
            this.btShowLog.TabIndex = 18;
            this.btShowLog.Text = "Show Log";
            this.btShowLog.UseVisualStyleBackColor = false;
            this.btShowLog.Click += new System.EventHandler(this.btShowLog_Click);
            // 
            // txGitHubUserName
            // 
            this.txGitHubUserName.Location = new System.Drawing.Point(174, 6);
            this.txGitHubUserName.Name = "txGitHubUserName";
            this.txGitHubUserName.Size = new System.Drawing.Size(293, 26);
            this.txGitHubUserName.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Github user name:";
            // 
            // btPush
            // 
            this.btPush.BackColor = System.Drawing.Color.DarkOrange;
            this.btPush.Location = new System.Drawing.Point(533, 107);
            this.btPush.Name = "btPush";
            this.btPush.Size = new System.Drawing.Size(122, 47);
            this.btPush.TabIndex = 13;
            this.btPush.Text = "Push";
            this.btPush.UseVisualStyleBackColor = false;
            this.btPush.Visible = false;
            this.btPush.Click += new System.EventHandler(this.btPush_Click);
            // 
            // btCommitAll
            // 
            this.btCommitAll.BackColor = System.Drawing.Color.DarkOrange;
            this.btCommitAll.Location = new System.Drawing.Point(405, 107);
            this.btCommitAll.Name = "btCommitAll";
            this.btCommitAll.Size = new System.Drawing.Size(122, 47);
            this.btCommitAll.TabIndex = 12;
            this.btCommitAll.Text = "Commit All";
            this.btCommitAll.UseVisualStyleBackColor = false;
            this.btCommitAll.Visible = false;
            this.btCommitAll.Click += new System.EventHandler(this.btCommitAll_Click);
            // 
            // btStageAll
            // 
            this.btStageAll.BackColor = System.Drawing.Color.DarkOrange;
            this.btStageAll.Location = new System.Drawing.Point(277, 107);
            this.btStageAll.Name = "btStageAll";
            this.btStageAll.Size = new System.Drawing.Size(122, 47);
            this.btStageAll.TabIndex = 11;
            this.btStageAll.Text = "Stage All";
            this.btStageAll.UseVisualStyleBackColor = false;
            this.btStageAll.Visible = false;
            this.btStageAll.Click += new System.EventHandler(this.btStageAll_Click);
            // 
            // lblRepositoryFolders
            // 
            this.lblRepositoryFolders.AutoSize = true;
            this.lblRepositoryFolders.Location = new System.Drawing.Point(17, 43);
            this.lblRepositoryFolders.Name = "lblRepositoryFolders";
            this.lblRepositoryFolders.Size = new System.Drawing.Size(175, 20);
            this.lblRepositoryFolders.TabIndex = 9;
            this.lblRepositoryFolders.Text = "Work Repository Folder";
            // 
            // btStatus
            // 
            this.btStatus.BackColor = System.Drawing.Color.DarkOrange;
            this.btStatus.Location = new System.Drawing.Point(149, 107);
            this.btStatus.Name = "btStatus";
            this.btStatus.Size = new System.Drawing.Size(122, 47);
            this.btStatus.TabIndex = 0;
            this.btStatus.Text = "Status";
            this.btStatus.UseVisualStyleBackColor = false;
            this.btStatus.Visible = false;
            this.btStatus.Click += new System.EventHandler(this.btStatus_Click);
            // 
            // txGitCommands
            // 
            this.txGitCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txGitCommands.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txGitCommands.Location = new System.Drawing.Point(0, 0);
            this.txGitCommands.Multiline = true;
            this.txGitCommands.Name = "txGitCommands";
            this.txGitCommands.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txGitCommands.Size = new System.Drawing.Size(1414, 807);
            this.txGitCommands.TabIndex = 0;
            // 
            // tabPageCompare
            // 
            this.tabPageCompare.Controls.Add(this.splitContainerMain);
            this.tabPageCompare.Location = new System.Drawing.Point(4, 29);
            this.tabPageCompare.Name = "tabPageCompare";
            this.tabPageCompare.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCompare.Size = new System.Drawing.Size(1420, 986);
            this.tabPageCompare.TabIndex = 0;
            this.tabPageCompare.Text = "Compare";
            this.tabPageCompare.UseVisualStyleBackColor = true;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.btAcceptMerged);
            this.splitContainerMain.Panel1.Controls.Add(this.btAcceptNew);
            this.splitContainerMain.Panel1.Controls.Add(this.btAcceptOld);
            this.splitContainerMain.Panel1.Controls.Add(this.btRefreshBranches);
            this.splitContainerMain.Panel1.Controls.Add(this.lblLocalBranch);
            this.splitContainerMain.Panel1.Controls.Add(this.comboBoxOtherBranches);
            this.splitContainerMain.Panel1.Controls.Add(this.btRefresh);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerWork);
            this.splitContainerMain.Size = new System.Drawing.Size(1414, 980);
            this.splitContainerMain.SplitterDistance = 163;
            this.splitContainerMain.TabIndex = 0;
            // 
            // btAcceptMerged
            // 
            this.btAcceptMerged.BackColor = System.Drawing.Color.Wheat;
            this.btAcceptMerged.Location = new System.Drawing.Point(1008, 77);
            this.btAcceptMerged.Name = "btAcceptMerged";
            this.btAcceptMerged.Size = new System.Drawing.Size(207, 47);
            this.btAcceptMerged.TabIndex = 6;
            this.btAcceptMerged.Text = "Accept Merged";
            this.btAcceptMerged.UseVisualStyleBackColor = false;
            this.btAcceptMerged.Click += new System.EventHandler(this.btAcceptMerged_Click);
            // 
            // btAcceptNew
            // 
            this.btAcceptNew.BackColor = System.Drawing.Color.Wheat;
            this.btAcceptNew.Location = new System.Drawing.Point(801, 77);
            this.btAcceptNew.Name = "btAcceptNew";
            this.btAcceptNew.Size = new System.Drawing.Size(207, 47);
            this.btAcceptNew.TabIndex = 5;
            this.btAcceptNew.Text = "Accept New";
            this.btAcceptNew.UseVisualStyleBackColor = false;
            this.btAcceptNew.Click += new System.EventHandler(this.btAcceptNew_Click);
            // 
            // btAcceptOld
            // 
            this.btAcceptOld.BackColor = System.Drawing.Color.Wheat;
            this.btAcceptOld.Location = new System.Drawing.Point(594, 77);
            this.btAcceptOld.Name = "btAcceptOld";
            this.btAcceptOld.Size = new System.Drawing.Size(207, 47);
            this.btAcceptOld.TabIndex = 4;
            this.btAcceptOld.Text = "Accept Old";
            this.btAcceptOld.UseVisualStyleBackColor = false;
            this.btAcceptOld.Click += new System.EventHandler(this.btAcceptOld_Click);
            // 
            // btRefreshBranches
            // 
            this.btRefreshBranches.Location = new System.Drawing.Point(272, 54);
            this.btRefreshBranches.Name = "btRefreshBranches";
            this.btRefreshBranches.Size = new System.Drawing.Size(211, 47);
            this.btRefreshBranches.TabIndex = 3;
            this.btRefreshBranches.Text = "Refresh Branches";
            this.btRefreshBranches.UseVisualStyleBackColor = true;
            this.btRefreshBranches.Click += new System.EventHandler(this.btRefreshBranches_Click);
            // 
            // lblLocalBranch
            // 
            this.lblLocalBranch.AutoSize = true;
            this.lblLocalBranch.Location = new System.Drawing.Point(564, 23);
            this.lblLocalBranch.Name = "lblLocalBranch";
            this.lblLocalBranch.Size = new System.Drawing.Size(51, 20);
            this.lblLocalBranch.TabIndex = 2;
            this.lblLocalBranch.Text = "label1";
            // 
            // comboBoxOtherBranches
            // 
            this.comboBoxOtherBranches.FormattingEnabled = true;
            this.comboBoxOtherBranches.Location = new System.Drawing.Point(272, 20);
            this.comboBoxOtherBranches.Name = "comboBoxOtherBranches";
            this.comboBoxOtherBranches.Size = new System.Drawing.Size(226, 28);
            this.comboBoxOtherBranches.TabIndex = 1;
            this.comboBoxOtherBranches.SelectedIndexChanged += new System.EventHandler(this.comboBoxOtherBranches_SelectedIndexChanged);
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(42, 77);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(122, 47);
            this.btRefresh.TabIndex = 0;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // splitContainerWork
            // 
            this.splitContainerWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerWork.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerWork.IsSplitterFixed = true;
            this.splitContainerWork.Location = new System.Drawing.Point(0, 0);
            this.splitContainerWork.Name = "splitContainerWork";
            // 
            // splitContainerWork.Panel1
            // 
            this.splitContainerWork.Panel1.Controls.Add(this.listBoxParagraphs);
            // 
            // splitContainerWork.Panel2
            // 
            this.splitContainerWork.Panel2.Controls.Add(this.splitContainerTexts);
            this.splitContainerWork.Size = new System.Drawing.Size(1414, 813);
            this.splitContainerWork.SplitterDistance = 209;
            this.splitContainerWork.TabIndex = 0;
            // 
            // listBoxParagraphs
            // 
            this.listBoxParagraphs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxParagraphs.FormattingEnabled = true;
            this.listBoxParagraphs.ItemHeight = 20;
            this.listBoxParagraphs.Location = new System.Drawing.Point(0, 0);
            this.listBoxParagraphs.Name = "listBoxParagraphs";
            this.listBoxParagraphs.Size = new System.Drawing.Size(209, 813);
            this.listBoxParagraphs.TabIndex = 0;
            this.listBoxParagraphs.SelectedValueChanged += new System.EventHandler(this.listBoxParagraphs_SelectedValueChanged);
            // 
            // splitContainerTexts
            // 
            this.splitContainerTexts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTexts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTexts.Name = "splitContainerTexts";
            this.splitContainerTexts.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTexts.Panel1
            // 
            this.splitContainerTexts.Panel1.Controls.Add(this.splitContainerTextsTop);
            // 
            // splitContainerTexts.Panel2
            // 
            this.splitContainerTexts.Panel2.Controls.Add(this.splitContainertextsBotton);
            this.splitContainerTexts.Size = new System.Drawing.Size(1201, 813);
            this.splitContainerTexts.SplitterDistance = 356;
            this.splitContainerTexts.TabIndex = 0;
            // 
            // splitContainerTextsTop
            // 
            this.splitContainerTextsTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTextsTop.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTextsTop.Name = "splitContainerTextsTop";
            // 
            // splitContainerTextsTop.Panel1
            // 
            this.splitContainerTextsTop.Panel1.Controls.Add(this.webBrowserRepoIn);
            // 
            // splitContainerTextsTop.Panel2
            // 
            this.splitContainerTextsTop.Panel2.Controls.Add(this.webBrowserRepoOut);
            this.splitContainerTextsTop.Size = new System.Drawing.Size(1201, 356);
            this.splitContainerTextsTop.SplitterDistance = 560;
            this.splitContainerTextsTop.TabIndex = 0;
            // 
            // webBrowserRepoIn
            // 
            this.webBrowserRepoIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserRepoIn.Location = new System.Drawing.Point(0, 0);
            this.webBrowserRepoIn.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserRepoIn.Name = "webBrowserRepoIn";
            this.webBrowserRepoIn.Size = new System.Drawing.Size(560, 356);
            this.webBrowserRepoIn.TabIndex = 0;
            // 
            // webBrowserRepoOut
            // 
            this.webBrowserRepoOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserRepoOut.Location = new System.Drawing.Point(0, 0);
            this.webBrowserRepoOut.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserRepoOut.Name = "webBrowserRepoOut";
            this.webBrowserRepoOut.Size = new System.Drawing.Size(637, 356);
            this.webBrowserRepoOut.TabIndex = 0;
            // 
            // splitContainertextsBotton
            // 
            this.splitContainertextsBotton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainertextsBotton.Location = new System.Drawing.Point(0, 0);
            this.splitContainertextsBotton.Name = "splitContainertextsBotton";
            // 
            // splitContainertextsBotton.Panel1
            // 
            this.splitContainertextsBotton.Panel1.Controls.Add(this.webBrowserCompare);
            // 
            // splitContainertextsBotton.Panel2
            // 
            this.splitContainertextsBotton.Panel2.Controls.Add(this.txTextEdit);
            this.splitContainertextsBotton.Size = new System.Drawing.Size(1201, 453);
            this.splitContainertextsBotton.SplitterDistance = 560;
            this.splitContainertextsBotton.TabIndex = 1;
            // 
            // webBrowserCompare
            // 
            this.webBrowserCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserCompare.Location = new System.Drawing.Point(0, 0);
            this.webBrowserCompare.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserCompare.Name = "webBrowserCompare";
            this.webBrowserCompare.Size = new System.Drawing.Size(560, 453);
            this.webBrowserCompare.TabIndex = 0;
            // 
            // txTextEdit
            // 
            this.txTextEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txTextEdit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txTextEdit.Location = new System.Drawing.Point(0, 0);
            this.txTextEdit.Multiline = true;
            this.txTextEdit.Name = "txTextEdit";
            this.txTextEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txTextEdit.Size = new System.Drawing.Size(637, 453);
            this.txTextEdit.TabIndex = 0;
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btClose.Location = new System.Drawing.Point(917, 107);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(122, 47);
            this.btClose.TabIndex = 21;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Visible = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btUndo
            // 
            this.btUndo.BackColor = System.Drawing.Color.LightCoral;
            this.btUndo.Location = new System.Drawing.Point(661, 107);
            this.btUndo.Name = "btUndo";
            this.btUndo.Size = new System.Drawing.Size(122, 47);
            this.btUndo.TabIndex = 22;
            this.btUndo.Text = "Undo All";
            this.btUndo.UseVisualStyleBackColor = false;
            this.btUndo.Click += new System.EventHandler(this.btUndo_Click);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btExit.Location = new System.Drawing.Point(1045, 107);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(122, 47);
            this.btExit.TabIndex = 23;
            this.btExit.Text = "Exit App";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // frmGitCommands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 1019);
            this.Controls.Add(this.tabControlMain);
            this.Name = "frmGitCommands";
            this.Text = "Merge Paragraphs";
            this.Activated += new System.EventHandler(this.frmGitCommands_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGitCommands_FormClosing);
            this.Load += new System.EventHandler(this.frmGitCommands_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageParameters.ResumeLayout(false);
            this.splitContainerGitCommands.Panel1.ResumeLayout(false);
            this.splitContainerGitCommands.Panel1.PerformLayout();
            this.splitContainerGitCommands.Panel2.ResumeLayout(false);
            this.splitContainerGitCommands.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGitCommands)).EndInit();
            this.splitContainerGitCommands.ResumeLayout(false);
            this.tabPageCompare.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerWork.Panel1.ResumeLayout(false);
            this.splitContainerWork.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerWork)).EndInit();
            this.splitContainerWork.ResumeLayout(false);
            this.splitContainerTexts.Panel1.ResumeLayout(false);
            this.splitContainerTexts.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTexts)).EndInit();
            this.splitContainerTexts.ResumeLayout(false);
            this.splitContainerTextsTop.Panel1.ResumeLayout(false);
            this.splitContainerTextsTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTextsTop)).EndInit();
            this.splitContainerTextsTop.ResumeLayout(false);
            this.splitContainertextsBotton.Panel1.ResumeLayout(false);
            this.splitContainertextsBotton.Panel2.ResumeLayout(false);
            this.splitContainertextsBotton.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainertextsBotton)).EndInit();
            this.splitContainertextsBotton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageCompare;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TabPage tabPageParameters;
        private System.Windows.Forms.SplitContainer splitContainerWork;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.ListBox listBoxParagraphs;
        private System.Windows.Forms.Label lblLocalBranch;
        private System.Windows.Forms.ComboBox comboBoxOtherBranches;
        private System.Windows.Forms.Button btRefreshBranches;
        private System.Windows.Forms.SplitContainer splitContainerTexts;
        private System.Windows.Forms.SplitContainer splitContainerTextsTop;
        private System.Windows.Forms.SplitContainer splitContainertextsBotton;
        private System.Windows.Forms.WebBrowser webBrowserRepoIn;
        private System.Windows.Forms.WebBrowser webBrowserRepoOut;
        private System.Windows.Forms.WebBrowser webBrowserCompare;
        private System.Windows.Forms.TextBox txTextEdit;
        private System.Windows.Forms.Button btAcceptMerged;
        private System.Windows.Forms.Button btAcceptNew;
        private System.Windows.Forms.Button btAcceptOld;
        private System.Windows.Forms.SplitContainer splitContainerGitCommands;
        private System.Windows.Forms.Label lblRepositoryFolders;
        private System.Windows.Forms.Button btStatus;
        private System.Windows.Forms.TextBox txGitCommands;
        private System.Windows.Forms.Button btPush;
        private System.Windows.Forms.Button btCommitAll;
        private System.Windows.Forms.Button btStageAll;
        private System.Windows.Forms.TextBox txGitHubUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btShowLog;
        private System.Windows.Forms.Label lblBookReposirotyFolder;
        private System.Windows.Forms.Button biInicialize;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btUndo;
        private System.Windows.Forms.Button btExit;
    }
}