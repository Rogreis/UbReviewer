using System;
using System.Windows.Forms;
using UbReviewer.ChildWindows;

namespace UbReviewer
{
    public partial class mdiForm : Form
    {
        public mdiForm()
        {
            InitializeComponent();
        }

        #region Events
        private void mdiForm_Load(object sender, EventArgs e)
        {
         }


        private void btOpenParagraph_Click(object sender, EventArgs e)
        {
             frmEdit frm = new frmEdit();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btOpenDocument_Click(object sender, EventArgs e)
        {
            frmDocument frm = new frmDocument();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btGit_Click(object sender, EventArgs e)
        {
            frmGit frm = new frmGit();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btCascace_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void btTile_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void btExit_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
