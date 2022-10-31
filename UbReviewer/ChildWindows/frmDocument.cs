using System;
using System.ComponentModel;
using System.Windows.Forms;
using UbReviewer.Classes;
using UbStandardObjects;
using UbStandardObjects.Objects;

namespace UbReviewer.ChildWindows
{
    public partial class frmDocument : Form
    {

        private HtmlFormat Formatter = new HtmlFormat(StaticObjects.Parameters);
        private ParameterReviewer Parameters = ((ParameterReviewer)StaticObjects.Parameters);
        private short paperNo = 0;
        private bool FormShown = false;

        public frmDocument()
        {
            InitializeComponent();
            webBrowserPaper.DocumentCompleted += WebBrowserPaper_DocumentCompleted;
            webBrowserPaper.Navigating += WebBrowserPaper_Navigating;
            webBrowserPaper.NewWindow += WebBrowserPaper_NewWindow;
        }

        private void EditParagraph(string ident)
        {
            frmEdit frm = new frmEdit();
            PaperEdit paper = new PaperEdit(paperNo, StaticObjects.Parameters.EditParagraphsRepositoryFolder);
            frm.SetParagraph(paper, ident);
            //frm.MdiParent = this.MdiParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ShowPaper(paperNo);
            }
        }


        private void WebBrowserPaper_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void WebBrowserPaper_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.AbsolutePath != "blank")
            {
                e.Cancel = true;
            }
        }

        private void WebBrowserPaper_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            AttachEventHandler();
        }

        private void AttachEventHandler()
        {
            HtmlElementCollection links = webBrowserPaper.Document.Links;
            foreach (HtmlElement link in links)
            {
                try
                {
                    link.DetachEventHandler("onclick", new EventHandler(this.linkClicked));
                }
                catch { }
            }

            foreach (HtmlElement link in links)
            {
                link.AttachEventHandler("onclick", new EventHandler(this.linkClicked));
                string Para = link.GetAttribute("href");
                Para = Para.Replace("about:", "");
            }
        }

        private void linkClicked(object sender, EventArgs e)
        {
            HtmlElement link = (HtmlElement)webBrowserPaper.Document.ActiveElement;
            string ident = link.GetAttribute("ident");
            toolStripStatusLabelIdent.Text = ident;
            toolStripStatusLabelMessage.Text = ident;
            EditParagraph(ident);
            AttachEventHandler();
        }



        private void ShowPaper(short paperNo)
        {
            webBrowserPaper.DocumentText = Formatter.FormatPaper(paperNo, Parameters.TranslationLeft, Parameters.TranslationMiddle, Parameters.TranslationRight);
            this.Text = $"Paper {paperNo}";
            Parameters.LastPaperShown = paperNo;
        }


        public short PaperNo
        {
            set
            {
                paperNo = value;
                if (FormShown)
                {
                    RefreshPage();
                }
            }
        }

        private void RefreshPage()
        {
            ShowPaper(paperNo);
        }

        private void frmDocument_Load(object sender, EventArgs e)
        {
            if (StaticObjects.Parameters.FontFamilyInfo == "Roboto Serif Medium")
            {
                toolStripMenuItemSerifFont.Checked = true;
                nonSerifToolStripMenuItem.Checked = false;
            }
            else
            {
                toolStripMenuItemSerifFont.Checked = false;
                nonSerifToolStripMenuItem.Checked = true;
            }
            RefreshPage();
            FormShown = true;
        }


        private void toolStripButtonDescreaseSize_Click(object sender, EventArgs e)
        {
            if (StaticObjects.Parameters.FontSize > 8)
            {
                StaticObjects.Parameters.FontSize--;
                RefreshPage();
            }
        }

        private void toolStripButtonIncreaseSize_Click(object sender, EventArgs e)
        {
            if (StaticObjects.Parameters.FontSize < 30)
            {
                StaticObjects.Parameters.FontSize++;
                RefreshPage();
            }
        }

        private void toolStripMenuItemSerifFont_Click(object sender, EventArgs e)
        {
            StaticObjects.Parameters.FontFamilyInfo = "Roboto Serif Medium";
            toolStripMenuItemSerifFont.Checked = true;
            nonSerifToolStripMenuItem.Checked = false;
            RefreshPage();
        }

        private void nonSerifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticObjects.Parameters.FontFamilyInfo = "Verdana";
            toolStripMenuItemSerifFont.Checked = false;
            nonSerifToolStripMenuItem.Checked = true;
            RefreshPage();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
