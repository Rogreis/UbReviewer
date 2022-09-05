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
        private ParagraphMarkDown Paragraph = null;
        private Note note = null;

        public frmEdit()
        {
            InitializeComponent();
        }


        public void SetParagraph(string ident)
        {
            Paragraph = new ParagraphMarkDown(StaticObjects.Parameters.EditParagraphsRepositoryFolder, ParagraphMarkDown.FilePath(ident));
            note = Paragraph.GetNotes(StaticObjects.Parameters.EditParagraphsRepositoryFolder, Paragraph.Paper);
            if (note == null)
            {
                note = new Note();
            }
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            this.Text= Paragraph.ID;
            textBoxText.Text = Paragraph.Text;
            textBoxNotes.Text = note.Notes;
            textBoxTranslatorNotes.Text = note.TranslatorNote;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (Paragraph.Save(textBoxText.Text, note))
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
