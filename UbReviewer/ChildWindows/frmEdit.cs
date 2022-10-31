using System;
using System.IO;
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

        public frmEdit()
        {
            InitializeComponent();
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
                Paper= new PaperEdit(paperNo, StaticObjects.Parameters.EditParagraphsRepositoryFolder);
            }
            ParagraphMarkDown par = (ParagraphMarkDown)Paper.GetParagraph(new TOC_Entry(((ParameterReviewer)StaticObjects.Parameters).TranslationIdRight, paperNo, sectionNo, paragraphNo, 0, 0));
            return new Tuple<PaperEdit, ParagraphMarkDown>(Paper, par);
        }

        private Tuple<PaperEdit, ParagraphMarkDown> Previous(ParagraphMarkDown par)
        {
            short paperNo = par.Paper;
            short sectionNo = par.Section;
            short paragraphNo = par.ParagraphNo--;

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
            Tuple<PaperEdit, ParagraphMarkDown> tuple= (value == 1 ? Next(Paragraph) : Previous(Paragraph));
            Paper = tuple.Item1;
            Paragraph= tuple.Item2;
            Paper.GetNotesData(Paragraph);
            SetData();
        }

        private bool Save()
        {
            bool ret= true;
            if (Paragraph.Text != textBoxText.Text)
            {
                Paragraph.Text = textBoxText.Text;
                ret = Paragraph.SaveText(StaticObjects.Parameters.EditParagraphsRepositoryFolder);
            }
            if (Paragraph.TranslatorNote != textBoxTranslatorNotes.Text || Paragraph.Comment != textBoxNotes.Text)
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
            this.Text= Paragraph.ID;
            splitContainerTexts.SplitterDistance = tabPageText.Height / 2;
            btWorking.BackColor = Param.BackgroundWorking;
            btDone.BackColor = Param.BackgroundOk;
            btDoubt.BackColor = Param.BackgroundDoubt;
            btClosed.BackColor = Param.BackgroundClosed;
            switch(Paragraph.Status)
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

        }


        private void btOk_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Close();
                DialogResult= DialogResult.OK;
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
            textBoxText.BackColor= Param.BackgroundOk;
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
    }
}
