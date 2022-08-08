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

namespace UbReviewer.ChildWindows
{
    public partial class frmDocument : Form
    {

        string textDummy = "Muito freqüente e efetivamente, os reprodutores celestes colaboram com os diretores de retrospecção, combinando a recapitulação da memória com certas formas de descanso para a mente e recreio para a personalidade. Antes dos conclaves moronciais e assembléias do espírito, esses reprodutores, algumas vezes, agrupam-se para realizar espetáculos dramáticos extraordinários, representativos dos propósitos de tais encontros. Recentemente, testemunhei uma apresentação bastante assombrosa, na qual mais de um milhão de atores produziram uma sucessão de mil cenas.";

        public frmDocument()
        {
            InitializeComponent();
        }

        private RichTextBox CreateRichTextBox(int line, int col)
        {
            RichTextBox rtf = new RichTextBox();
            rtf.Dock = System.Windows.Forms.DockStyle.Fill;
            rtf.Margin = new System.Windows.Forms.Padding(5);
            rtf.Name = $"Rtf_{line}-{col}";
            rtf.Text = textDummy;
            return rtf;
        }

        private void frmDocument_Load(object sender, EventArgs e)
        {
            //tableLayoutPanelDocument.RowCount = 50;

            //for(int i = 0; i < 50; i++)
            //{
            //    tableLayoutPanelDocument.Controls.Add(CreateRichTextBox(i, 0));
            //    tableLayoutPanelDocument.Controls.Add(CreateRichTextBox(i, 1));
            //    tableLayoutPanelDocument.Controls.Add(CreateRichTextBox(i, 2));
            //}

            // Get Translations
            Translations  

        }
    }
}
