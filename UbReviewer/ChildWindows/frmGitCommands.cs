using LibGit2Sharp;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using UbReviewer.Classes;
using UbStandardObjects;
using UbStandardObjects.Objects;
using static System.Environment;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace UbReviewer.ChildWindows
{
    public partial class frmGitCommands : Form
    {

        private string CurrentBranch = "";
        private string SecondBranch = "";
        private bool LocalRespositoriesChecked = false;

        private HtmlFormat Formatter = null;

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            WriteIndented = true,
            IncludeFields = true
        };




        public frmGitCommands()
        {
            InitializeComponent();
        }

        //private string FilePathForCredentials()
        //{
        //    string processName = System.IO.Path.GetFileNameWithoutExtension(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        //    var commonpath = GetFolderPath(SpecialFolder.CommonApplicationData);
        //    string folder = Path.Combine(commonpath, processName);
        //    Directory.CreateDirectory(folder);
        //    return Path.Combine(folder, "Credentials.json");
        //}


        private void ShowMessage(string message)
        {
            if (message == null)
            {
                txGitCommands.Text = "";
            }
            else
            {
                txGitCommands.AppendText(message + Environment.NewLine);
            }
            Application.DoEvents();
        }


        //private string NewText = null;
        //private string OldText = null;
        //private ParagraphMarkDown CurrentParagraphMdFile = null;


        public bool HasCredentials
        {
            get
            {
                return !string.IsNullOrWhiteSpace(((ParameterReviewer)StaticObjects.Parameters).GitHubUserName);
            }
        }





        private void PrintStatus()
        {
            ShowMessage(null);
            if (string.IsNullOrEmpty(StaticObjects.Parameters.EditParagraphsRepositoryFolder))
            {
                ShowMessage("Please, choose a file folder to work as repository.");
                return;
            }

            btStageAll.Visible = false;
            btCommitAll.Visible = false;
            btPush.Visible = false;

            Cursor = Cursors.WaitCursor;
            GitData gitData = GitCommands.Status();
            Cursor = Cursors.Default;

            if (gitData == null) return;
            if (!gitData.IsRepository)
            {
                string message = $"The current folder ({StaticObjects.Parameters.EditParagraphsRepositoryFolder}) is not a repository. Initialize it. please.";
                biInicialize.Visible = true;
                ShowMessage(message);
                return;
            }

            biInicialize.Visible = false;
            btStageAll.Visible = false;
            btCommitAll.Visible = false;
            btClose.Visible = true;
            btStatus.Visible = true;
            btPush.Visible = gitData.HasNonPushedCommits && HasCredentials;
            btUndo.Visible = gitData.IsRepository && (gitData.IsToBeStaged || gitData.IsToBeCommited);

            ShowMessage($"Branch: {gitData.Branch}");
            if (gitData.ToBeStaged.Count > 0)
            {
                btStageAll.Visible = true;
                ShowMessage("");
                ShowMessage($"{gitData.ToBeStaged.Count} paragraphs or files to be staged.");
                foreach (string file in gitData.ToBeStaged)
                {
                    ShowMessage($"  {file}");
                }
            }
            else ShowMessage("Nothing to stage");

            if (gitData.ToBeCommited.Count > 0)
            {
                btCommitAll.Visible = true;
                ShowMessage("");
                ShowMessage($"{gitData.ToBeCommited.Count} paragraphs or files to be committed.");
                foreach (string file in gitData.ToBeCommited)
                {
                    ShowMessage($"  {file}");
                }
            }
            else ShowMessage("Nothing to commit");
        }


        private void VerifyFolders()
        {
            ((ParameterReviewer)StaticObjects.Parameters).GitHubUserName = txGitHubUserName.Text;
            ParameterReviewer.Serialize((ParameterReviewer)StaticObjects.Parameters, StaticObjects.PathParameters);
            if (!HasCredentials)
            {
                ShowMessage("Please, inform your github user name above.");
                return;
            }
            else
            {
                txGitHubUserName.Enabled = false;
            }

            Cursor = Cursors.WaitCursor;
            if (!GitCommands.InicializeRepository("git@github.com:Rogreis/TUB_Files.git", StaticObjects.Parameters.TUB_Files_RepositoryFolder, "main"))
            {
                Cursor = Cursors.Default;
                ShowMessage("It was not possible to initialize TUB Files.");
                return;
            }

            string branch = "correcoes_" + ((ParameterReviewer)StaticObjects.Parameters).GitHubUserName;
            if (!GitCommands.InicializeRepository("git@github.com:Rogreis/PtAlternative.git", StaticObjects.Parameters.EditParagraphsRepositoryFolder, branch))
            {
                Cursor = Cursors.Default;
                ShowMessage("It was not possible to initialize translation repository.");
                return;
            }
            ((ParameterReviewer)StaticObjects.Parameters).RespositoriesChecked = true;
            PrintStatus();
            Cursor = Cursors.Default;
        }


        private void frmGitCommands_Load(object sender, EventArgs e)
        {
            Formatter = new HtmlFormat(((ParameterReviewer)StaticObjects.Parameters));
            SecondBranch = ((ParameterReviewer)StaticObjects.Parameters).LastSecondBranchUsed;

            tabControlMain.TabPages.Remove(tabPageCompare);
            lblRepositoryFolders.Text += " " + StaticObjects.Parameters.EditParagraphsRepositoryFolder;
            lblBookReposirotyFolder.Text += " " + StaticObjects.Parameters.TUB_Files_RepositoryFolder;
            txGitHubUserName.Text = ((ParameterReviewer)StaticObjects.Parameters).GitHubUserName;
        }


        #region Compare routines and events

        //private void GetAllParagraphVersions(ParagraphMarkDown paragraph, bool getOld = true)
        //{
        //    CurrentParagraphMdFile = paragraph;

        //    // New text
        //    NewText = File.ReadAllText(paragraph.FullPath);
        //    webBrowserRepoOut.DocumentText = Formatter.FormatParagraph(CurrentBranch, NewText);

        //    // Old text
        //    if (getOld)
        //    {
        //        SecondBranch = comboBoxOtherBranches.SelectedValue.ToString();
        //        GitCommands.GetFileCheckout(((ParameterReviewer)StaticObjects.Parameters).EditParagraphsRepositoryFolder, paragraph.RelativeFilePath, SecondBranch);
        //        OldText = File.ReadAllText(paragraph.FullPath);
        //        webBrowserRepoIn.DocumentText = Formatter.FormatParagraph(SecondBranch, OldText);
        //        GitCommands.GetUndoFileCheckout(((ParameterReviewer)StaticObjects.Parameters).EditParagraphsRepositoryFolder, paragraph.RelativeFilePath);
        //    }

        //    // Compare text
        //    webBrowserCompare.DocumentText = Formatter.HtmlCompare(OldText, NewText);

        //    // Merge text
        //    txTextEdit.Text = NewText;

        //    btAcceptNew.Text = $"Accept {CurrentBranch}";
        //    btAcceptOld.Text = $"Accept {SecondBranch}";
        //}

        private void InicializeCompareData()
        {
            // Spliter distances
            splitContainerTexts.SplitterDistance = splitContainerTexts.ClientSize.Height / 2;
            splitContainerTextsTop.SplitterDistance = splitContainerTextsTop.ClientSize.Width / 2;
            splitContainertextsBotton.SplitterDistance = splitContainertextsBotton.ClientSize.Width / 2;

        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrentBranch))
            {
                //listBoxParagraphs.Items.Clear();
                SecondBranch = comboBoxOtherBranches.SelectedValue.ToString();
                List<string> list = GitCommands.DiffBranchesFileList(((ParameterReviewer)StaticObjects.Parameters).EditParagraphsRepositoryFolder, SecondBranch);
                if (list != null)
                {
                    List<ParagraphMarkDown> filesList = new List<ParagraphMarkDown>();
                    foreach (string fileFound in list)
                    {
                        filesList.Add(new ParagraphMarkDown(((ParameterReviewer)StaticObjects.Parameters).EditParagraphsRepositoryFolder, fileFound));
                    }
                    ((ParameterReviewer)StaticObjects.Parameters).LastSecondBranchUsed = SecondBranch;
                    listBoxParagraphs.DisplayMember = "Ident";
                    listBoxParagraphs.ValueMember = "RelativeFilePath";
                    listBoxParagraphs.DataSource = filesList;
                }
            }

        }

        private void btRefreshBranches_Click(object sender, EventArgs e)
        {
            CurrentBranch = GitCommands.GetCurrentBranch(((ParameterReviewer)StaticObjects.Parameters).EditParagraphsRepositoryFolder);
            lblLocalBranch.Text = CurrentBranch;
            listBoxParagraphs.Items.Clear();

            List<string> branches = GitCommands.LocalBranches(((ParameterReviewer)StaticObjects.Parameters).EditParagraphsRepositoryFolder);
            branches.Remove("* " + CurrentBranch);
            comboBoxOtherBranches.DataSource = branches;
            if (branches.Find(b => b == SecondBranch) != null)
            {
                comboBoxOtherBranches.SelectedItem = SecondBranch;
            }
            else
            {
                comboBoxOtherBranches.SelectedIndex = 0;
            }
        }

        private void comboBoxOtherBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxParagraphs.Items.Clear();
        }

        private void listBoxParagraphs_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (listBoxParagraphs.SelectedValue != null)
            //{
            //    string filePath = listBoxParagraphs.SelectedValue.ToString();
            //    if (filePath != null)
            //    {
            //        ParagraphMarkDown mdFileList = listBoxParagraphs.SelectedItem as ParagraphMarkDown;
            //        GetAllParagraphVersions(mdFileList);
            //    }
            //}
        }

        private void btAcceptOld_Click(object sender, EventArgs e)
        {
            //File.WriteAllText(CurrentParagraphMdFile.FullPath, OldText);
            //GetAllParagraphVersions(CurrentParagraphMdFile, false);
            //GitCommands.GetStageFile(((ParameterReviewer)StaticObjects.Parameters).EditParagraphsRepositoryFolder, CurrentParagraphMdFile.RelativeFilePath);
        }

        private void btAcceptNew_Click(object sender, EventArgs e)
        {
            //File.WriteAllText(CurrentParagraphMdFile.FullPath, NewText);
            //GetAllParagraphVersions(CurrentParagraphMdFile, false);
            //GitCommands.GetStageFile(((ParameterReviewer)StaticObjects.Parameters).EditParagraphsRepositoryFolder, CurrentParagraphMdFile.RelativeFilePath);
        }

        private void btAcceptMerged_Click(object sender, EventArgs e)
        {
            //File.WriteAllText(CurrentParagraphMdFile.FullPath, txTextEdit.Text);
            //GetAllParagraphVersions(CurrentParagraphMdFile, false);
            //GitCommands.GetStageFile(((ParameterReviewer)StaticObjects.Parameters).EditParagraphsRepositoryFolder, CurrentParagraphMdFile.RelativeFilePath);
        }

        #endregion

        private void btStatus_Click(object sender, EventArgs e)
        {
            PrintStatus();
        }

        private void btStageAll_Click(object sender, EventArgs e)
        {
            Cursor= Cursors.WaitCursor;
            GitCommands.Stage(StaticObjects.Parameters.EditParagraphsRepositoryFolder);
            PrintStatus();
            Cursor = Cursors.Default;
        }

        private void btCommitAll_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GitCommands.Commit(StaticObjects.Parameters.EditParagraphsRepositoryFolder);
        }

        private void btPush_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GitData gitData = GitCommands.Status();
            Cursor = Cursors.Default;
            if (gitData == null) return;
            if (gitData.HasNonPushedCommits)
            {
                GitCommands.Push(StaticObjects.Parameters.EditParagraphsRepositoryFolder);
                PrintStatus();
            }
        }

        private void btShowLog_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            StaticObjects.Logger.Close();
            txGitCommands.Text = File.ReadAllText(StaticObjects.PathLog);
            StaticObjects.Logger.Initialize(StaticObjects.PathLog, true);
            Cursor = Cursors.Default;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btUndo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GitCommands.Undo();
            PrintStatus();
            Cursor = Cursors.Default;
        }

        private void biInicialize_Click(object sender, EventArgs e)
        {
            VerifyFolders();
        }

        private void frmGitCommands_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void frmGitCommands_Activated(object sender, EventArgs e)
        {
            if (LocalRespositoriesChecked)
            {
                PrintStatus();
                return;
            }
            if (!((ParameterReviewer)StaticObjects.Parameters).RespositoriesChecked)
            {
                VerifyFolders();
            }
            LocalRespositoriesChecked = true;
            PrintStatus();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Exit(0);
        }
    }
}
