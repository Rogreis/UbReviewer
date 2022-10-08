using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Web.ModelBinding;
using System.Windows.Forms;
using UbReviewer.Classes;
using UbStandardObjects;
using UbStandardObjects.Objects;
using static System.Environment;

namespace UbReviewer.ChildWindows
{
    public partial class frmGitCommands : Form
    {

        private string CurrentBranch = "";
        private string SecondBranch = "";

        private HtmlFormat Formatter = null;
        private ParameterReviewer Param = null;

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            WriteIndented = true,
            IncludeFields = true
        };


        //private class ParagraphMarkDown
        //{
        //    private string BaseRepositoryPath { get; set; } = "";

        //    public string RelativeFilePath { get; set; } = "";

        //    public string RelativeFilePathWindows
        //    {
        //        get
        //        {
        //            return RelativeFilePath.Replace("/", "\\");
        //        }
        //    }



        //    public string FullPath
        //    {
        //        get
        //        {
        //            return Path.Combine(BaseRepositoryPath, RelativeFilePathWindows);
        //        }
        //    }

        //    public string Ident
        //    {
        //        get
        //        {
        //            return Path.GetFileNameWithoutExtension(FullPath);
        //        }
        //    }

        //    public string LocalPathFile
        //    {
        //        get { return Path.GetDirectoryName(BaseRepositoryPath); }
        //    }

        //    public ParagraphMarkDown(string baseRepositoryPath, string relativeFilePath)
        //    {
        //        BaseRepositoryPath = baseRepositoryPath;
        //        RelativeFilePath = relativeFilePath;
        //    }

        //}

        public frmGitCommands()
        {
            InitializeComponent();
        }


        private string FilePathForCredentials()
        {
            string processName = System.IO.Path.GetFileNameWithoutExtension(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            var commonpath = GetFolderPath(SpecialFolder.CommonApplicationData);
            string folder= Path.Combine(commonpath, processName);
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

        /// <summary>
        /// Get a generic folder
        /// </summary>
        /// <param name="tx"></param>
        /// <param name="previousFolder"></param>
        private bool GetFolder(TextBox tx, ref string previousFolder)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            if (!string.IsNullOrEmpty(previousFolder))
            {
                browserDialog.SelectedPath = previousFolder;
            }
            else
            {
                browserDialog.SelectedPath = UbStandardObjects.StaticObjects.Parameters.InputHtmlFilesPath;
            }
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                previousFolder = tx.Text = browserDialog.SelectedPath;
                return true;
            }
            return false;
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

            public bool IsToBePushed = false;

            public List<string> ToBeCommited = new List<string>();

            public List<string> ToBeStaged = new List<string>();

            public string GitHubUserName = null;

            public string GitHubToken = null;

            public bool HasCredentials
            {
                get
                {
                    return !string.IsNullOrWhiteSpace(GitHubUserName) && !string.IsNullOrWhiteSpace(GitHubToken);
                }
            }
        }



        private void ReadGitDataFile()
        {
            if (File.Exists(FilePathForCredentials()))
            {
                string jsonString = File.ReadAllText(FilePathForCredentials());
                GitData gitData = JsonSerializer.Deserialize<GitData>(jsonString, options);
                txGitHubUserName.Text= gitData.GitHubUserName;
                txGitHubToken.Text= gitData.GitHubToken;
            }
        }

        private void SaveGitDataFile(GitData gitData)
        {
            string jsonString = JsonSerializer.Serialize<GitData>(gitData, options);
            File.WriteAllText(FilePathForCredentials(), jsonString);
        }

        private bool Push()
        {
            //GitData gitData = Status();
            //// https://techglimpse.com/git-push-github-token-based-passwordless/
            //// rogreis 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
            //if (!gitData.HasCredentials)
            //{
            //    MessageBox.Show("Please, inform User name and token to continue");
            //    return false;
            //}

            List<string> commands = new List<string>()
            {
                "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
                "git push"
            };
            return true;



            //string command = $"git push https://{gitData.GitHubToken}@github.com/{gitData.GitHubUserName}/PtAlternative.git";
            //List<string> commands = new List<string>()
            //{
            //    "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
            //    command
            //};
            //List<string> list = RunScripts.ExecuteSomeCommands(commands);
            //if (list.Count > 0) 
            //{
            //    if (list[0].IndexOf("has no upstream branch.") > 0)
            //    {
            //        // git push --set-upstream origin correcoes-rogreis
            //        command = $"git push --set-upstream https://{gitData.GitHubToken}@github.com/{gitData.GitHubUserName}/PtAlternative.git";
            //        commands = new List<string>()
            //        {
            //            "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
            //            command
            //        };
            //        List<string> list = RunScripts.ExecuteSomeCommands(commands);
            //    }
            //}

            // 
            return true;
        }

        private GitData Clone()
        {
            List<string> commands = new List<string>()
            {
                "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
                "git clone git@github.com:Rogreis/PtAlternative.git .",
                "git checkout correcoes"
            };
            List<string> list = RunScripts.ExecuteSomeCommands(commands);
            return Status();
        }

        private GitData Commit(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Commit message cannot ne empty");
                return null;
            }
            List<string> commands = new List<string>()
            {
                "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
                "git clone git@github.com:Rogreis/PtAlternative.git .",
                $"git commit -m \"{message}\""
            };
            List<string> list = RunScripts.ExecuteSomeCommands(commands);
            return Status();
        }

        private GitData Stage()
        {
            ShowMessage(null);
            List<string> commands = new List<string>()
            {
                "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
                "git add .",
            };
            List<string> list = RunScripts.ExecuteSomeCommands(commands);
            return Status();
        }

        private GitData Status()
        {
            GitData gitData = new GitData();
            List<string> commands = new List<string>()
            {
                "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
                "git status"
            };
            List<string> list = RunScripts.ExecuteSomeCommands(commands);

            gitData.GitHubUserName= txGitHubUserName.Text;
            gitData.GitHubToken = txGitHubToken.Text;

            foreach (string line in list)
            {
                if (line.StartsWith("On branch "))
                {
                    gitData.Branch = line.Replace("On branch ", "").Trim();
                }
                if (line.StartsWith("fatal: not a git repository"))
                {
                    gitData.IsRepository = false;
                }
                if (line.StartsWith("Changes to be committed"))
                {
                    gitData.IsToBeStaged = false;
                    gitData.IsToBeCommited = true;
                }
                if (line.StartsWith("Changes not staged for commit"))
                {
                    gitData.IsToBeCommited = false;
                    gitData.IsToBeStaged = true;
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

            // Anything to push?
            commands = new List<string>()
            {
                "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
                "git log --pretty = oneline"
            };
            list = RunScripts.ExecuteSomeCommands(commands);
            gitData.IsToBePushed = true;
            if (list != null && list.Count > 0)
            {
                gitData.IsToBePushed = list[0].Contains(" (HEAD ->");
            }

            SaveGitDataFile(gitData);
            return gitData;
        }

        private void PrintStatus()
        {
            ShowMessage(null);
            if (string.IsNullOrEmpty(StaticObjects.Parameters.EditParagraphsRepositoryFolder))
            {
                ShowMessage("Please, choose a file folder to work as repository.");
                return;
            }

            GitData gitData = Status();
            if (!gitData.IsRepository)
            {
                string message = $"The current folder ({StaticObjects.Parameters.EditParagraphsRepositoryFolder}) is not a repository. Clone here?";
                if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ShowMessage($"Clonning a new local repository in: {StaticObjects.Parameters.EditParagraphsRepositoryFolder}...");
                    gitData = Clone();
                    ShowMessage("Repository clonned");
                }
                else
                {
                    return;
                }
            }

            if (!gitData.HasCredentials)
            {
                ShowMessage("*** Missing credentials");
            }

            btStageAll.Visible = false;
            btCommitAll.Visible = false;
            btPush.Visible = gitData.IsToBePushed && gitData.HasCredentials;

            ShowMessage($"Branch: {gitData.Branch}");
            if (gitData.ToBeStaged.Count > 0)
            {
                btStageAll.Visible = true;
                ShowMessage("");
                ShowMessage($"{gitData.ToBeCommited.Count} paragraphs or files to be staged.");
                foreach (string file in gitData.ToBeStaged)
                {
                    ShowMessage($"  {file}");
                }
            }
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
        }


        private void frmGitCommands_Load(object sender, EventArgs e)
        {
            Param = StaticObjects.Parameters as ParameterReviewer;
            Formatter = new HtmlFormat(Param);
            SecondBranch = Param.LastSecondBranchUsed;

            txTranslationRepositoryFolder.Text = StaticObjects.Parameters.EditParagraphsRepositoryFolder;
            ReadGitDataFile();
            PrintStatus();

            //InicializeCompareData();
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
        //        GitCommands.GetFileCheckout(Param.EditParagraphsRepositoryFolder, paragraph.RelativeFilePath, SecondBranch);
        //        OldText = File.ReadAllText(paragraph.FullPath);
        //        webBrowserRepoIn.DocumentText = Formatter.FormatParagraph(SecondBranch, OldText);
        //        GitCommands.GetUndoFileCheckout(Param.EditParagraphsRepositoryFolder, paragraph.RelativeFilePath);
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
                List<string> list = GitCommands.DiffBranchesFileList(Param.EditParagraphsRepositoryFolder, SecondBranch);
                if (list != null)
                {
                    List<ParagraphMarkDown> filesList = new List<ParagraphMarkDown>();
                    foreach (string fileFound in list)
                    {
                        filesList.Add(new ParagraphMarkDown(Param.EditParagraphsRepositoryFolder, fileFound));
                    }
                    Param.LastSecondBranchUsed = SecondBranch;
                    listBoxParagraphs.DisplayMember = "Ident";
                    listBoxParagraphs.ValueMember = "RelativeFilePath";
                    listBoxParagraphs.DataSource = filesList;
                }
            }

        }

        private void btRefreshBranches_Click(object sender, EventArgs e)
        {
            CurrentBranch = GitCommands.GetCurrentBranch(Param.EditParagraphsRepositoryFolder);
            lblLocalBranch.Text = CurrentBranch;
            listBoxParagraphs.Items.Clear();

            List<string> branches = GitCommands.LocalBranches(Param.EditParagraphsRepositoryFolder);
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
            //GitCommands.GetStageFile(Param.EditParagraphsRepositoryFolder, CurrentParagraphMdFile.RelativeFilePath);
        }

        private void btAcceptNew_Click(object sender, EventArgs e)
        {
            //File.WriteAllText(CurrentParagraphMdFile.FullPath, NewText);
            //GetAllParagraphVersions(CurrentParagraphMdFile, false);
            //GitCommands.GetStageFile(Param.EditParagraphsRepositoryFolder, CurrentParagraphMdFile.RelativeFilePath);
        }

        private void btAcceptMerged_Click(object sender, EventArgs e)
        {
            //File.WriteAllText(CurrentParagraphMdFile.FullPath, txTextEdit.Text);
            //GetAllParagraphVersions(CurrentParagraphMdFile, false);
            //GitCommands.GetStageFile(Param.EditParagraphsRepositoryFolder, CurrentParagraphMdFile.RelativeFilePath);
        }

        #endregion

        private void btEditTranslationRepositoryFolder_Click(object sender, EventArgs e)
        {
            string folder = StaticObjects.Parameters.EditParagraphsRepositoryFolder;
            GetFolder(txTranslationRepositoryFolder, ref folder);
            StaticObjects.Parameters.EditParagraphsRepositoryFolder = folder;
            PrintStatus();
        }

        private void btStatus_Click(object sender, EventArgs e)
        {
            PrintStatus();
        }

        private void btStageAll_Click(object sender, EventArgs e)
        {
            Stage();
            PrintStatus();
        }

        private void btCommitAll_Click(object sender, EventArgs e)
        {
            frmCommit frm= new frmCommit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Commit(frm.CommitMessage);
            }
        }

        private void btPush_Click(object sender, EventArgs e)
        {
            Push();
            PrintStatus();
        }
    }
}
