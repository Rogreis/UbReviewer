using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using UbReviewer.ChildWindows;
using UbReviewer.Classes;
using UbStandardObjects;
using UbStandardObjects.Objects;
using static System.Environment;

namespace UbReviewer
{
    public partial class mdiForm : Form
    {
        private ParameterReviewer Parameters = null;
        private bool Initializing = true;
        private bool DocumentShown = false;

        public mdiForm()
        {
            InitializeComponent();
        }

        private void ShowMessage(string message)
        {
            if (message == null)
            {
                toolStripStatusLabelMessages.Text = "";
                lblMessages.Text = "";
            }
            else
            {
                toolStripStatusLabelMessages.Text = message;
                lblMessages.Text = message;
            }
            Application.DoEvents();
        }

        #region Events

        private void ShowDocument()
        {
            try
            {
                short paperNo = Convert.ToInt16(comboBoxPaperNo.Text);
                frmDocument frm = new frmDocument();
                frm.MdiParent = this;
                frm.PaperNo = paperNo;
                ((ParameterReviewer)StaticObjects.Parameters).LastPaperShown = paperNo;
                frm.Show();
                ShowMessage($"Showing paper {paperNo}.");

            }
            catch (Exception)
            {
                ShowMessage("Invalid paper.");
            }
        }


        private void mdiForm_Load(object sender, EventArgs e)
        {
            ShowMessage("Starting...");
            txParagraph.Text= ((ParameterReviewer)StaticObjects.Parameters).LastIdentParagraphUsed;

            if (Initialize())
            {
                comboBoxPaperNo.Text = ((ParameterReviewer)StaticObjects.Parameters).LastPaperShown.ToString();
            }
            
            Initializing = false;
        }

        private void btOpenParagraph_Click(object sender, EventArgs e)
        {
        }

        private void btOpenDocument_Click(object sender, EventArgs e)
        {
            ShowDocument();
        }

        private void mdiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ParameterReviewer.Serialize((ParameterReviewer)StaticObjects.Parameters, StaticObjects.PathParameters);
        }

        private void comboBoxPaperNo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Initializing) return;
            ShowDocument();
        }


        private void btGit_Click(object sender, EventArgs e)
        {   
            Program.ShowGitCommands();
        }


        private void btPrint_Click(object sender, EventArgs e)
        {
            //BootstrapBook bootstrap = new BootstrapBook(StaticObjects.Parameters.HtmlParam);
            //bootstrap.ShowMessage += ShowMessage;
            //bootstrap.Generate(Parameters.EditBookRepositoryFolder, Parameters.TranslationLeft, Parameters.TranslationRight);
            //File.AppendAllText(filePath, Formatter.End(), Encoding.UTF8);
            //Process.Start(filePath);
        }

        private void btCascace_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void btTile_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void btExit_Click(object sender, EventArgs e)
        {

        }
        #endregion



        private bool Initialize()
        {
            Parameters = (ParameterReviewer)StaticObjects.Parameters;

            if (string.IsNullOrWhiteSpace(Parameters.EditParagraphsRepositoryFolder))
            {
                MessageBox.Show("Repository folder not empty is mandatory to use this edit program");
                Close();
            }

            GetDataFiles dataFiles = new GetDataFiles(StaticObjects.Parameters);

            if (!StaticObjects.Book.Inicialize(dataFiles))
            {
                return false;
            }

            Parameters.TranslationLeft = dataFiles.GetTranslation(Parameters.TranslationIdLeft);
            Parameters.TranslationMiddle = dataFiles.GetTranslation(Parameters.TranslationIdMiddle);

            // Set the edit translation (hard coded here to be PT Alternative)
            short editLanguageId = 2;
            Translation trans= dataFiles.GetTranslation(editLanguageId, false);
            TranslationEdit translatioEdit = new TranslationEdit(trans, Parameters.EditParagraphsRepositoryFolder);
            Parameters.TranslationRight = translatioEdit;

            return true;
        }

        private void EditParagraph(string ident)
        {
            try
            {
                char[] sep = new char[] { ' ', ';', '-', '.', ':' };
                string[] parts = txParagraph.Text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                short paperNo= Convert.ToInt16(parts[0]);
                short sectionNo = Convert.ToInt16(parts[1]);
                short paragraphNo = Convert.ToInt16(parts[2]);
                ((ParameterReviewer)StaticObjects.Parameters).LastIdentParagraphUsed = txParagraph.Text;
                PaperEdit paper = new PaperEdit(paperNo, StaticObjects.Parameters.EditParagraphsRepositoryFolder);
                frmEdit frm = new frmEdit();
                frm.SetParagraph(paper, paperNo, sectionNo, paragraphNo);
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Invalid paragraph; use any combination of 3 numbers and separators ; . : or space");
            }


        }


        private void txParagraph_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditParagraph(txParagraph.Text);
            }
        }

        private void mdiForm_Activated(object sender, EventArgs e)
        {
            if (!DocumentShown)
            {
                ShowDocument();
                DocumentShown = true;
            }
        }
    }
}
