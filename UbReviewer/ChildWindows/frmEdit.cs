using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UbStandardObjects.Objects;
using UbStandardObjects;
using static UbStandardObjects.Objects.ParagraphMarkDown;
using UbReviewer.Classes;

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
        }

        public void SetParagraph(PaperEdit paper, string ident)
        {
            Paper= paper;
            Paragraph = new ParagraphMarkDown(StaticObjects.Parameters.EditParagraphsRepositoryFolder, ident);
            Paper.GetNotesData(Paragraph);
            SetData();
        }

        public void SetParagraph(PaperEdit paper, short paperNo, short sectionNo, short paragraphNo)
        {
            Paper = paper;
            Paragraph = new ParagraphMarkDown(StaticObjects.Parameters.EditParagraphsRepositoryFolder, paperNo, sectionNo, paragraphNo);
            Paper.GetNotesData(Paragraph);
            Paper currentPaper = ((ParameterReviewer)StaticObjects.Parameters).TranslationLeft.Paper(paperNo);
            EnglishParagraph = currentPaper.GetParagraph(new TOC_Entry(0, paperNo, sectionNo, paragraphNo, 0, 0));
            webBrowserEnglishText.DocumentText= FormatObject.FormatParagraph(EnglishParagraph);
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
            if (Paragraph.Save(StaticObjects.Parameters.EditParagraphsRepositoryFolder, textBoxText.Text))
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
    }
}
