using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using UbReviewer.Classes;
using UbStandardObjects;
using UbStandardObjects.Objects;
using static System.Collections.Specialized.BitVector32;

namespace UbReviewer.ChildWindows
{
    public partial class frmEdit : Form
    {
        private PaperEdit Paper = null;
        private ParagraphMarkDown Paragraph = null;
        private HtmlFormat FormatObject = new HtmlFormat(StaticObjects.Parameters);
        private ParameterReviewer Param = (ParameterReviewer)StaticObjects.Parameters;
        private Paragraph EnglishParagraph = null;
        private ParagraphStatus InitialStatus;

        public frmEdit()
        {
            InitializeComponent();
            string fontFamily = StaticObjects.Parameters.FontFamilyInfo == "Verdana" ? "Verdana" : "Calisto MT";
            textBoxText.Font = new System.Drawing.Font(fontFamily, StaticObjects.Parameters.FontSize);
            textBoxTranslatorNotes.Font = new System.Drawing.Font(fontFamily, StaticObjects.Parameters.FontSize);
            textBoxNotes.Font = new System.Drawing.Font(fontFamily, StaticObjects.Parameters.FontSize);
            txHistory.Font = new System.Drawing.Font(fontFamily, StaticObjects.Parameters.FontSize);
        }

        private void SetData()
        {
            if (Paragraph == null)
            {
                return;
            }
            textBoxText.Text = Paragraph.Text;
            textBoxNotes.Text = Paragraph.Comment;
            textBoxTranslatorNotes.Text = Paragraph.TranslatorNote;
            InitialStatus = Paragraph.Status;

            ((ParameterReviewer)StaticObjects.Parameters).LastPaperShown = Paragraph.Paper;
            ((ParameterReviewer)StaticObjects.Parameters).LastSectionShown = Paragraph.Section;
            ((ParameterReviewer)StaticObjects.Parameters).LastParagraphShown = Paragraph.ParagraphNo;
            this.Text = Paragraph.ID;

            Paper currentPaper = ((ParameterReviewer)StaticObjects.Parameters).TranslationLeft.Paper(Paragraph.Paper);
            EnglishParagraph = currentPaper.GetParagraph(new TOC_Entry(0, Paragraph.Paper, Paragraph.Section, Paragraph.ParagraphNo, 0, 0));
            webBrowserEnglishText.DocumentText = FormatObject.FormatParagraph(EnglishParagraph);

        }

        private Tuple<PaperEdit, ParagraphMarkDown> GetPaperParagraph(short paperNo, short sectionNo, short paragraphNo)
        {
            if (Paper == null || Paper.PaperNo != paperNo)
            {
                Paper = new PaperEdit(paperNo, StaticObjects.Parameters.EditParagraphsRepositoryFolder);
            }
            ParagraphMarkDown par = (ParagraphMarkDown)Paper.GetParagraph(new TOC_Entry(((ParameterReviewer)StaticObjects.Parameters).TranslationIdRight, paperNo, sectionNo, paragraphNo, 0, 0));
            return new Tuple<PaperEdit, ParagraphMarkDown>(Paper, par);
        }

        private Tuple<PaperEdit, ParagraphMarkDown> Previous(ParagraphMarkDown par)
        {
            short paperNo = par.Paper;
            short sectionNo = par.Section;
            short paragraphNo = --par.ParagraphNo;

            if (paragraphNo < 0)
            {
                sectionNo--;
                paragraphNo = 0;
                if (sectionNo < 0)
                {
                    paperNo--;
                    sectionNo = 0;
                    if (paperNo < 0)
                    {
                        MessageBox.Show("This is already the first book paragraph.");
                        return new Tuple<PaperEdit, ParagraphMarkDown>(this.Paper, this.Paragraph);
                    }
                }
            }
            return GetPaperParagraph(paperNo, sectionNo, paragraphNo);
        }

        private Tuple<PaperEdit, ParagraphMarkDown> Next(ParagraphMarkDown par)
        {
            short paperNo = par.Paper;
            short sectionNo = par.Section;
            short paragraphNo = ++par.ParagraphNo;
            bool found = false;

            do
            {
                found = File.Exists(ParagraphMarkDown.FullPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder, paperNo, sectionNo, paragraphNo));
                if (found)
                {
                    return GetPaperParagraph(paperNo, sectionNo, paragraphNo);
                }

                if (paragraphNo > 0)
                {
                    paragraphNo = 0;
                    sectionNo++;
                }
                else if (sectionNo > 0)
                {
                    sectionNo = 0;
                    if (paperNo == 196)
                    {
                        // book end
                        MessageBox.Show("This is already the last book paragraph.");
                        return new Tuple<PaperEdit, ParagraphMarkDown>(Paper, Paragraph);
                    }
                    paperNo++;
                }
            } while (!found);
            return null;
        }

        private void GetNextParagraph(short value)
        {
            Tuple<PaperEdit, ParagraphMarkDown> tuple = (value == 1 ? Next(Paragraph) : Previous(Paragraph));
            Paper = tuple.Item1;
            Paragraph = tuple.Item2;
            Paper.GetNotesData(Paragraph);
            SetData();
        }

        private bool Save()
        {
            bool ret = true;
            if (Paragraph.Text != textBoxText.Text)
            {
                Paragraph.Text = textBoxText.Text;
                ret = Paragraph.SaveText(StaticObjects.Parameters.EditParagraphsRepositoryFolder);
            }
            if (Paragraph.TranslatorNote != textBoxTranslatorNotes.Text || Paragraph.Comment != textBoxNotes.Text || InitialStatus != Paragraph.Status)
            {
                Paragraph.TranslatorNote = textBoxTranslatorNotes.Text;
                Paragraph.Comment = textBoxNotes.Text;
                ret = ret && Paragraph.SaveNotes(StaticObjects.Parameters.EditParagraphsRepositoryFolder);
            }
            return ret;
        }

        public void SetParagraph(PaperEdit paper, string ident)
        {
            Paper = paper;
            Paragraph = new ParagraphMarkDown(StaticObjects.Parameters.EditParagraphsRepositoryFolder, ident);
            Paper.GetNotesData(Paragraph);
            SetData();
        }

        public void SetParagraph(PaperEdit paper, short paperNo, short sectionNo, short paragraphNo)
        {
            Paper = paper;
            Paragraph = new ParagraphMarkDown(StaticObjects.Parameters.EditParagraphsRepositoryFolder, paperNo, sectionNo, paragraphNo);
            Paper.GetNotesData(Paragraph);
            SetData();
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            this.Text = Paragraph.ID;
            splitContainerTexts.SplitterDistance = tabPageText.Height / 2;
            btWorking.BackColor = Param.BackgroundWorking;
            btDone.BackColor = Param.BackgroundOk;
            btDoubt.BackColor = Param.BackgroundDoubt;
            btClosed.BackColor = Param.BackgroundClosed;
            switch (Paragraph.Status)
            {
                case ParagraphStatus.Ok:
                    textBoxText.BackColor = Param.BackgroundOk;
                    break;
                case ParagraphStatus.Doubt:
                    textBoxText.BackColor = Param.BackgroundDoubt;
                    break;
                case ParagraphStatus.Working:
                    textBoxText.BackColor = Param.BackgroundWorking;
                    break;
                case ParagraphStatus.Closed:
                    textBoxText.BackColor = Param.BackgroundClosed;
                    break;
            }
            Debug.WriteLine("");
            Debug.WriteLine("Size  .  Location on loading");
            Debug.WriteLine(((ParameterReviewer)StaticObjects.Parameters).EditWindowSize);
            Debug.WriteLine(((ParameterReviewer)StaticObjects.Parameters).EditWindowLocation);
            this.Size = new Size(((ParameterReviewer)StaticObjects.Parameters).EditWindowSize.Width, ((ParameterReviewer)StaticObjects.Parameters).EditWindowSize.Height);
            //this.Location = new Point(((ParameterReviewer)StaticObjects.Parameters).EditWindowLocation.X, ((ParameterReviewer)StaticObjects.Parameters).EditWindowLocation.Y);
        }


        private void btOk_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Close();
                DialogResult = DialogResult.OK;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btWorking_Click(object sender, EventArgs e)
        {
            Paragraph.Status = ParagraphStatus.Working;
            textBoxText.BackColor = Param.BackgroundWorking;
        }

        private void btDone_Click(object sender, EventArgs e)
        {
            Paragraph.Status = ParagraphStatus.Ok;
            textBoxText.BackColor = Param.BackgroundOk;
        }

        private void btDoubt_Click(object sender, EventArgs e)
        {
            Paragraph.Status = ParagraphStatus.Doubt;
            textBoxText.BackColor = Param.BackgroundDoubt;
        }

        private void btClosed_Click(object sender, EventArgs e)
        {
            Paragraph.Status = ParagraphStatus.Closed;
            textBoxText.BackColor = Param.BackgroundClosed;
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                GetNextParagraph(-1);
            }
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                GetNextParagraph(1);
            }
        }

        private void frmEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((ParameterReviewer)StaticObjects.Parameters).EditWindowSize = new Size(Width, Height);
            ((ParameterReviewer)StaticObjects.Parameters).EditWindowLocation = new Point(Left, Right);
            Debug.WriteLine("");
            Debug.WriteLine("Size  .  Location on closing");
            Debug.WriteLine(((ParameterReviewer)StaticObjects.Parameters).EditWindowSize);
            Debug.WriteLine(((ParameterReviewer)StaticObjects.Parameters).EditWindowLocation);
        }



        private void ShowHistoryLine(string message)
        {
            if (message == null)
            {
                txHistory.Text = "";
            }
            else
            {
                txHistory.AppendText(message + Environment.NewLine);
            }
            Application.DoEvents();
        }


        //public static Encoding GetFileEncoding(GitRepository repository, GitItem gitItem)
        //{
        //    GitVersionDescriptor versionDesc = !string.IsNullOrEmpty(Configuration.Branch) ? new GitVersionDescriptor()
        //    {
        //        VersionType = GitVersionType.Branch,
        //        Version = Configuration.Branch,
        //        VersionOptions = GitVersionOptions.None
        //    } : null;

        //    using (Stream stream = GitClient.GetItemContentAsync(repository.Id, gitItem.Path, download: false, versionDescriptor: versionDesc, includeContentMetadata: true, includeContent: true).Result)
        //    {
        //        var bytes = new byte[4];
        //        stream.Read(bytes, 0, 4);
        //        // Analyze the BOM
        //        if (bytes[0] == 0x2b && bytes[1] == 0x2f && bytes[2] == 0x76) return Encoding.UTF7;
        //        if (bytes[0] == 0xef && bytes[1] == 0xbb && bytes[2] == 0xbf) return Encoding.UTF8;
        //        if (bytes[0] == 0xff && bytes[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
        //        if (bytes[0] == 0xfe && bytes[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
        //        if (bytes[0] == 0 && bytes[1] == 0 && bytes[2] == 0xfe && bytes[3] == 0xff) return Encoding.UTF32;
        //        using (StreamReader reader = new StreamReader(stream, true))
        //        {
        //            reader.Peek();
        //            if (reader.ReadToEnd().Contains('�'))
        //            {
        //                return Encoding.ASCII;
        //            }
        //            return Encoding.UTF8;
        //        }
        //    }
        //}

        private Encoding GetEncoding(byte[] bytes)
        {
            // Analyze the BOM
            if (bytes[0] == 0x2b && bytes[1] == 0x2f && bytes[2] == 0x76) return Encoding.UTF7;
            if (bytes[0] == 0xef && bytes[1] == 0xbb && bytes[2] == 0xbf) return Encoding.UTF8;
            if (bytes[0] == 0xff && bytes[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bytes[0] == 0xfe && bytes[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bytes[0] == 0 && bytes[1] == 0 && bytes[2] == 0xfe && bytes[3] == 0xff) return Encoding.UTF32;
            return Encoding.UTF8;
        }

        private string FixEncoding(string line)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(line);
            Encoding encoding = GetEncoding(bytes);
            return encoding.GetString(bytes);
        }

        private void GitHistory()
        {
            // git log -p -- Doc120/Par_120_002_001.md
            string filePath = ParagraphMarkDown.RelativeFilePath(Paragraph);

            ShowHistoryLine(null);
            List<string> commands = new List<string>()
            {
                "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
                $"git log --encoding=UTF-8 --pretty=oneline -- {filePath}",
            };
            // git show ce49661f16036d366d212b57a4a1a3ccd15362da:Doc120/Par_120_002_001.md
            Cursor = Cursors.WaitCursor;
            List<string> list = RunScripts.ExecuteSomeCommands(commands);
            foreach (string l in list)
            {
                if (l.Length >= 40)
                {
                    string hash = l.Substring(0, 40);
                    string printLine = l.Replace(hash, "");
                    ShowHistoryLine($"Commit comment: {FixEncoding(printLine)}");
                    commands = new List<string>()
                    {
                        "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
                        $"git show --encoding=UTF-8 {hash}:{filePath}",
                    };
                    List<string> list2 = RunScripts.ExecuteSomeCommands(commands);
                    foreach (string line in list2)
                    {
                        ShowHistoryLine("");
                        ShowHistoryLine(FixEncoding(line));
                    }
                    ShowHistoryLine("");
                }
            }
            Cursor = Cursors.Default;
        }

        private void GitHistory2()
        {

            try
            {
                //var repo = new LibGit2Sharp.Repository(RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder));
                var repo = new LibGit2Sharp.Repository(StaticObjects.Parameters.EditParagraphsRepositoryFolder);

                foreach (Commit commit in repo.Commits)
                {
                    foreach (var parent in commit.Parents)
                    {
                        ShowHistoryLine($"{commit.Sha} | {commit.MessageShort}");
                        foreach (TreeEntryChanges change in repo.Diff.Compare<TreeChanges>(parent.Tree,commit.Tree))
                        {
                            ShowHistoryLine($"{change.Status} : {change.Path}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ShowHistoryLine($"Error:  {ex.Message}");
            }
            //using (var repo = new Repository(Run "path\to\repo.git"))
            //{

            //}

        }

        private void btHistoryTrack_Click(object sender, EventArgs e)
        {
            GitHistory();
            tabControlEdit.SelectedTab = tabPageHistory;
        }
    }
}
