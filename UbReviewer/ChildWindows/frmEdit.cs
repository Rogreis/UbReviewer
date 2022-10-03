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

namespace UbReviewer.ChildWindows
{
    public partial class frmEdit : Form
    {
        PaperEdit Paper = null;
        private ParagraphMarkDown Paragraph = null;
        private Note note = null;

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
            textBoxNotes.Text = note.Notes;
            textBoxTranslatorNotes.Text = note.TranslatorNote;
        }

        public void SetParagraph(PaperEdit paper, string ident)
        {
            Paper= paper;
            Paragraph = new ParagraphMarkDown(StaticObjects.Parameters.EditParagraphsRepositoryFolder, ident);
            Paper.GetNotesData(Paragraph);
            SetData();
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            this.Text= Paragraph.ID;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (Paragraph.Save(StaticObjects.Parameters.EditParagraphsRepositoryFolder, textBoxText.Text, note))
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
    }
}
