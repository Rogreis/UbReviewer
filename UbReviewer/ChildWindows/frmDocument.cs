using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using UbReviewer.Classes;
using UbStandardObjects;
using UbStandardObjects.Objects;
using static System.Collections.Specialized.BitVector32;

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
            Notes notes = new Notes(StaticObjects.Parameters.EditParagraphsRepositoryFolder);
            PaperEdit paper = new PaperEdit(notes, paperNo, StaticObjects.Parameters.EditParagraphsRepositoryFolder);
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
                    ShowPaper(paperNo);
                }
            }
        }

        private void frmDocument_Load(object sender, EventArgs e)
        {
            ShowPaper(paperNo);
            FormShown = true;
        }
    }
}
