using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UbReviewer.Classes;
using UbStandardObjects;
using UbStandardObjects.Objects;

namespace UbReviewer.ChildWindows
{
    public partial class frmDocument : Form
    {

        private HtmlFormat Formatter = new HtmlFormat((ParameterReviewer)StaticObjects.Parameters);
        private ParameterReviewer Parameters = ((ParameterReviewer)StaticObjects.Parameters);
        private short paperNo = 0;
        private bool FormShown = false;

        public frmDocument()
        {
            InitializeComponent();
        }

        private void ShowPaper(short paperNo)
        {
            webBrowserPaper.DocumentText = Formatter.FormatPaper(paperNo,
                                                                 Parameters.TranslationLeft.Paper(paperNo).Paragraphs,
                                                                 Parameters.TranslationMiddle.Paper(paperNo).Paragraphs,
                                                                 Parameters.TranslationRight.Paper(paperNo).Paragraphs);
            this.Text = $"Paper {paperNo}";
            Parameters.LastPaperShown= paperNo;
        }


        public short PaperNo 
        {
            set
            {
                paperNo= value;
                if (FormShown)
                {
                    ShowPaper(paperNo);
                }
            }
        }

        private void frmDocument_Load(object sender, EventArgs e)
        {
            ShowPaper(paperNo);
            FormShown=true;
        }
    }
}
