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


        private enum GitActions
        {
            Clone,
            Checkout,
            Stage,
            Commit,
            Pull,
            Push
        }


        public frmGitCommands()
        {
            InitializeComponent();
        }

        private string FilePathForCredentials()
        {
            string processName = System.IO.Path.GetFileNameWithoutExtension(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            var commonpath = GetFolderPath(SpecialFolder.CommonApplicationData);
            string folder = Path.Combine(commonpath, processName);
            Directory.CreateDirectory(folder);
            return Path.Combine(folder, "Credentials.json");
        }


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

        private class GitData
        {
            public string Branch = "";

            public bool IsRepository = true;

            public bool IsToBeCommited = false;

            public bool IsToBeStaged = false;

            public bool IsUpToDate = false;

            public bool HasNonPushedCommits = false;

            public bool NeedsPull = false;

            public List<string> ToBeCommited = new List<string>();

            public List<string> ToBeStaged = new List<string>();

            public List<GitActions> GitInitializationsActionsNeeded(string branch)
            {
                List<GitActions> list = new List<GitActions>();

                if (!IsRepository)
                {
                    list.Add(GitActions.Clone);
                    //list.Add(GitActions.Pull);
                    return list;
                }

                //if (IsToBeStaged) list.Add(GitActions.Stage);
                //if (IsToBeCommited) list.Add(GitActions.Commit);
                //if (HasNonPushedCommits) list.Add(GitActions.Push);
                if (!IsUpToDate) list.Add(GitActions.Pull);
                if (Branch != branch)
                {
                    list.Add(GitActions.Checkout);
                    list.Add(GitActions.Pull);
                }
                return list;
            }


        }

        public bool HasCredentials
        {
            get
            {
                return !string.IsNullOrWhiteSpace(((ParameterReviewer)StaticObjects.Parameters).GitHubUserName);
            }
        }




        #region Check for errors routines
        private void DumpCommands(string command, List<string> commands, List<string> returnedLines)
        {
            StaticObjects.Logger.Info("");
            StaticObjects.Logger.Info("Git command: " + command);
            if (commands == null)
            {
                StaticObjects.Logger.Info("   null");
            }
            else
            {
                foreach (string s in commands)
                {
                    StaticObjects.Logger.Info("   " + s);
                }
                StaticObjects.Logger.Info("");
                StaticObjects.Logger.Info("   Returned lines:");
                if (returnedLines != null)
                {
                    foreach (string s in returnedLines)
                    {
                        StaticObjects.Logger.Info("   " + s);
                    }
                }
                else
                {
                    StaticObjects.Logger.Info("   No returned line");
                }
            }
        }

        private bool NoErrorInList(List<string> returnedLines)
        {
            if (returnedLines == null || returnedLines.Count == 0)
            {
                StaticObjects.Logger.Info("   No returned line");
                return false;
            }
            if (returnedLines[0].StartsWith("ERROR"))
            {
                string message = "*** Error occurred. See log.";
                ShowMessage(message);
                return false;
            }
            return true;
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

            GitData gitData = Status();
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

        #endregion

        #region Initialize routines

        private bool InicializeRepository(string sshUrl, string folder, string branch)
        {
            Directory.CreateDirectory(folder);
            GitData gitData = Status(folder);
            if (gitData == null) return false;

            List<GitActions> actions = gitData.GitInitializationsActionsNeeded(branch);

            foreach (GitActions action in actions)
            {
                switch (action)
                {
                    case GitActions.Pull:
                        ShowMessage("Pull...");
                        GitCommand($"pull", folder);
                        ShowMessage("Pull ok");
                        break;

                    case GitActions.Checkout:
                        ShowMessage("Checkout...");
                        if (!GitCommand($"checkout -f -b {branch}; git push --set-upstream origin {branch}", folder)) return false;
                        ShowMessage("Checkout ok");
                        break;

                    case GitActions.Push:
                        if (!Push(folder)) return false;
                        break;

                    case GitActions.Commit:
                        if (!Commit(folder)) return false;
                        break;

                    case GitActions.Stage:
                        if (!Stage(folder)) return false;
                        break;

                    case GitActions.Clone:
                        ShowMessage("Clone...");
                        gitData = Clone(sshUrl, folder);
                        if (!gitData.IsRepository)
                        {
                            ShowMessage("ERROR: Could not clone.");
                            return false;
                        }
                        ShowMessage("Clone ok");
                        break;
                }
            }
            return true;
        }

        #endregion

        #region Git commands
        private GitData Status(string folder = null)
        {

            // Default folders
            if (folder == null)
            {
                folder = StaticObjects.Parameters.EditParagraphsRepositoryFolder;
            }

            GitData gitData = new GitData();
            if (gitData == null) return null;

            List<string> commands = new List<string>()
            {
                "cd " + RunScripts.GetUnixPath(folder),
                "git status"
            };
            Cursor = Cursors.WaitCursor;
            List<string> list = RunScripts.ExecuteSomeCommands(commands);
            Cursor = Cursors.Default;
            DumpCommands("Status", commands, list);
            //if (!NoErrorInList(list)) return null;

            // Parse status lines returned
            foreach (string line in list)
            {
                if (line.StartsWith("On branch "))
                {
                    gitData.Branch = line.Replace("On branch ", "").Trim();
                }
                if (line.StartsWith("Your branch is up to date with "))
                {
                    gitData.IsUpToDate = true;
                }
                if (line.StartsWith("fatal: not a git repository"))
                {
                    gitData.IsRepository = false;
                }
                if (line.StartsWith("nothing to commit"))
                {
                    gitData.IsToBeCommited = false;
                }
                if (line.StartsWith("Changes to be committed"))
                {
                    gitData.IsToBeStaged = false;
                    gitData.IsToBeCommited = true;
                }
                if (line.StartsWith("Your branch is behind"))
                {
                    gitData.NeedsPull = true;
                }
                if (line.StartsWith("Changes not staged for commit"))
                {
                    gitData.IsToBeCommited = false;
                    gitData.IsToBeStaged = true;
                }
                if (line.StartsWith("Your branch is ahead of"))
                {
                    gitData.HasNonPushedCommits = true;
                }

                if (line.StartsWith("\tmodified:   "))
                {
                    if (gitData.IsToBeCommited)
                    {
                        gitData.ToBeCommited.Add(line.Replace("\tmodified:   ", "").Trim());
                    }
                    else
                    {
                        gitData.ToBeStaged.Add(line.Replace("\tmodified:   ", "").Trim());
                    }
                }
            }
            return gitData;
        }

        private bool GitCommand(string command, string folder)
        {
            List<string> commands = new List<string>()
                {
                    "cd " + RunScripts.GetUnixPath(folder),
                    $"git {command}",
                };
            Cursor = Cursors.WaitCursor;
            List<string> list = RunScripts.ExecuteSomeCommands(commands);
            Cursor = Cursors.Default;
            DumpCommands(command, commands, list);
            return NoErrorInList(list);
        }

        private bool Stage(string folder)
        {
            ShowMessage(null);
            ShowMessage("Stage...");
            if (!GitCommand("add .", folder)) return false;
            ShowMessage("Stage ok");
            return true;
        }

        private GitData Clone(string sshUrl, string folder)
        {
            List<string> commands = new List<string>()
                {
                    "cd " + RunScripts.GetUnixPath(folder),
                    $"git clone {sshUrl} .",
                };
            Cursor = Cursors.WaitCursor;
            List<string> list = RunScripts.ExecuteSomeCommands(commands);
            Cursor = Cursors.Default;
            DumpCommands("Clone", commands, list);
            return Status(folder);
        }

        private bool Commit(string folder)
        {
            ShowMessage("Commit...");
            frmCommit frm = new frmCommit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (!GitCommand($"commit -m \"{frm.CommitMessage}\"", folder)) return false;
                ShowMessage("Commit ok");
                return true;
            }
            else
            {
                ShowMessage("Commit cancelled");
                return false;
            }
        }

        private void Undo()
        {
            ShowMessage("Undo...");
            if (MessageBox.Show($"Are you sure to remove all changes??", "Ub Review",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                List<string> commands = new List<string>()
                {
                    "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
                    "git reset --hard",
                    "git clean -fxd",
                };
                Cursor = Cursors.WaitCursor;
                List<string> list = RunScripts.ExecuteSomeCommands(commands);
                Cursor = Cursors.Default;
                DumpCommands("Undo", commands, list);
                PrintStatus();
            }
            else ShowMessage("Undo cancelled.");
        }


        private bool Push(string folder)
        {
            ShowMessage("Push...");
            GitData gitData = Status();
            if (gitData == null) return false;

            if (!gitData.HasNonPushedCommits)
            {
                ShowMessage("Nothing to push");
                return true;
            }
            if (!GitCommand($"push -f", folder)) return false;
            ShowMessage("Push ok");
            return true;
        }

        #endregion


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

            if (!InicializeRepository("git@github.com:Rogreis/TUB_Files.git", StaticObjects.Parameters.TUB_Files_RepositoryFolder, "main"))
            {
                ShowMessage("It was not possible to initialize TUB Files.");
                return;
            }


            string branch = "correcoes_" + ((ParameterReviewer)StaticObjects.Parameters).GitHubUserName;
            if (!InicializeRepository("git@github.com:Rogreis/PtAlternative.git", StaticObjects.Parameters.EditParagraphsRepositoryFolder, branch))
            {
                ShowMessage("It was not possible to initialize translation repository.");
                return;
            }
            ((ParameterReviewer)StaticObjects.Parameters).RespositoriesChecked = true;
            PrintStatus();
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

        private void GitLog()
        {
            // git log -p -- Doc120/Par_120_002_001.md
            ShowMessage("History...");
            List<string> commands = new List<string>()
            {
                "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
                "git log --pretty=oneline -- Doc120/Par_120_002_001.md",
            };
            // git show ce49661f16036d366d212b57a4a1a3ccd15362da:Doc120/Par_120_002_001.md
            Cursor = Cursors.WaitCursor;
            List<string> list = RunScripts.ExecuteSomeCommands(commands);
            foreach (string l in list) ShowMessage(l);
            Cursor = Cursors.Default;
        }

        private void btStatus_Click(object sender, EventArgs e)
        {
            PrintStatus();
        }

        private void btStageAll_Click(object sender, EventArgs e)
        {
            Stage(StaticObjects.Parameters.EditParagraphsRepositoryFolder);
            PrintStatus();
        }

        private void btCommitAll_Click(object sender, EventArgs e)
        {
            Commit(StaticObjects.Parameters.EditParagraphsRepositoryFolder);
        }

        private void btPush_Click(object sender, EventArgs e)
        {
            GitData gitData = Status();
            if (gitData == null) return;
            if (gitData.HasNonPushedCommits)
            {
                Push(StaticObjects.Parameters.EditParagraphsRepositoryFolder);
                PrintStatus();
            }
        }

        private void btShowLog_Click(object sender, EventArgs e)
        {
            StaticObjects.Logger.Close();
            txGitCommands.Text = File.ReadAllText(StaticObjects.PathLog);
            StaticObjects.Logger.Initialize(StaticObjects.PathLog, true);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            //GitLog();
            Close();
        }

        private void btUndo_Click(object sender, EventArgs e)
        {
            Undo();
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
