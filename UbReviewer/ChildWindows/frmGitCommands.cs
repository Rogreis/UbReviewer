using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UbReviewer.Classes;
using UbStandardObjects;
using UbStandardObjects.Objects;
using static System.Net.Mime.MediaTypeNames;

namespace UbReviewer.ChildWindows
{
    public partial class frmGitCommands : Form
    {

        private string CurrentBranch = "";
        private string SecondBranch = "";

        private HtmlFormat Formatter = null;
        private ParameterReviewer Param = null;

        private class ParagraphMarkDown
        {
            private string BaseRepositoryPath { get; set; } = "";

            public string RelativeFilePath { get; set; } = "";

            public string RelativeFilePathWindows 
            { 
                get
                {
                    return RelativeFilePath.Replace("/", "\\");
                }
            }



            public string FullPath
            {
                get
                {
                    return Path.Combine(BaseRepositoryPath, RelativeFilePathWindows);
                }
            }

            public string Ident
            {
                get
                {
                    return Path.GetFileNameWithoutExtension(FullPath);
                }
            }

            public string LocalPathFile
            {
                get { return Path.GetDirectoryName(BaseRepositoryPath); }
            }

            public ParagraphMarkDown(string baseRepositoryPath, string relativeFilePath)
            {
                BaseRepositoryPath = baseRepositoryPath;
                RelativeFilePath = relativeFilePath;
            }

        }

        public frmGitCommands()
        {
            InitializeComponent();
        }

        private string NewText = null;
        private string OldText = null;
        private ParagraphMarkDown CurrentParagraphMdFile = null;

        private void GetAllParagraphVersions(ParagraphMarkDown paragraph, bool getOld= true)
        {
            CurrentParagraphMdFile = paragraph;

            // New text
            NewText = File.ReadAllText(paragraph.FullPath);
            webBrowserRepoOut.DocumentText = Formatter.FormatParagraph(CurrentBranch, NewText);

            // Old text
            if (getOld)
            {
                SecondBranch = comboBoxOtherBranches.SelectedValue.ToString();
                GitCommands.GetFileCheckout(Param.TranslationRepositoryFolder, paragraph.RelativeFilePath, SecondBranch);
                OldText = File.ReadAllText(paragraph.FullPath);
                webBrowserRepoIn.DocumentText = Formatter.FormatParagraph(SecondBranch, OldText);
                GitCommands.GetUndoFileCheckout(Param.TranslationRepositoryFolder, paragraph.RelativeFilePath);
            }

            // Compare text
            webBrowserCompare.DocumentText = Formatter.HtmlCompare(OldText, NewText);

            // Merge text
            txTextEdit.Text = NewText;

            btAcceptNew.Text = $"Accept {CurrentBranch}";
            btAcceptOld.Text = $"Accept {SecondBranch}";
        }

        private void frmGitCommands_Load(object sender, EventArgs e)
        {
            Param = StaticObjects.Parameters as ParameterReviewer;
            Formatter = new HtmlFormat(Param.HtmlParam);
            SecondBranch = Param.LastSecondBranchUsed;

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
                List<string> list = GitCommands.DiffBranchesFileList(Param.TranslationRepositoryFolder, SecondBranch);
                if (list != null)
                {
                    List<ParagraphMarkDown> filesList = new List<ParagraphMarkDown>();
                    foreach (string fileFound in list)
                    {
                        filesList.Add(new ParagraphMarkDown(Param.TranslationRepositoryFolder, fileFound)); 
                    }
                    Param.LastSecondBranchUsed= SecondBranch;
                    listBoxParagraphs.DisplayMember = "Ident";
                    listBoxParagraphs.ValueMember = "RelativeFilePath";
                    listBoxParagraphs.DataSource = filesList;
                }
            }

        }

        private void btRefreshBranches_Click(object sender, EventArgs e)
        {
            CurrentBranch = GitCommands.GetCurrentBranch(Param.TranslationRepositoryFolder);
            lblLocalBranch.Text = CurrentBranch;
            listBoxParagraphs.Items.Clear();

            List<string> branches = GitCommands.LocalBranches(Param.TranslationRepositoryFolder);
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
            if (listBoxParagraphs.SelectedValue!= null)
            {
                string filePath = listBoxParagraphs.SelectedValue.ToString();
                if (filePath != null)
                {
                    ParagraphMarkDown mdFileList= listBoxParagraphs.SelectedItem as ParagraphMarkDown;
                    GetAllParagraphVersions(mdFileList);
                }
            }
        }

        private void btAcceptOld_Click(object sender, EventArgs e)
        {
            File.WriteAllText(CurrentParagraphMdFile.FullPath, OldText);
            GetAllParagraphVersions(CurrentParagraphMdFile, false);
            GitCommands.GetStageFile(Param.TranslationRepositoryFolder, CurrentParagraphMdFile.RelativeFilePath);
        }

        private void btAcceptNew_Click(object sender, EventArgs e)
        {
            File.WriteAllText(CurrentParagraphMdFile.FullPath, NewText);
            GetAllParagraphVersions(CurrentParagraphMdFile, false);
            GitCommands.GetStageFile(Param.TranslationRepositoryFolder, CurrentParagraphMdFile.RelativeFilePath);
        }

        private void btAcceptMerged_Click(object sender, EventArgs e)
        {
            File.WriteAllText(CurrentParagraphMdFile.FullPath, txTextEdit.Text);
            GetAllParagraphVersions(CurrentParagraphMdFile, false);
            GitCommands.GetStageFile(Param.TranslationRepositoryFolder, CurrentParagraphMdFile.RelativeFilePath);
        }

    }
}
