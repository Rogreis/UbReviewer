using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UbReviewer.ChildWindows
{
    public partial class frmCommit : Form
    {
        public frmCommit()
        {
            InitializeComponent();
        }

        public string CommitMessage
        {
            get { return comboBoxCommitMessage.Text; }
            set { comboBoxCommitMessage.Text = value; }
        }
    }
}
