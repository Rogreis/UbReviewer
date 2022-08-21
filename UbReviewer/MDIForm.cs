using System;
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
        private string PathParameters { get; set; } = "";

        private ParameterReviewer Parameters = null;

        private string BaseTubFilesPath { get; set; } = "";


        public mdiForm()
        {
            InitializeComponent();
        }

        private void ShowMessage(string message)
        {
            if (message == null)
            {
                toolStripStatusLabelMessages.Text = "";
            }
            else
            {
                toolStripStatusLabelMessages.Text = message;
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
                frm.PaperNo= paperNo;
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
            if (Initialize())
            {
                Parameters = ((ParameterReviewer)StaticObjects.Parameters);
                comboBoxPaperNo.Text = Parameters.LastPaperShown.ToString();
            }
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
            ParameterReviewer.Serialize((ParameterReviewer)StaticObjects.Parameters, PathParameters);
        }

        private void comboBoxPaperNo_SelectedValueChanged(object sender, EventArgs e)
        {
            ShowDocument();
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



        private string DataFolder()
        {
            string processName = System.IO.Path.GetFileNameWithoutExtension(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            var commonpath = GetFolderPath(SpecialFolder.CommonApplicationData);
            return Path.Combine(commonpath, processName);
        }


        private string MakeProgramDataFolder(string fileName)
        {
            string folder = DataFolder();
            Directory.CreateDirectory(folder);
            return Path.Combine(folder, fileName);
        }


        private bool Initialize()
        {

            string pathLog = MakeProgramDataFolder("UbStudyHelp.log");
            BaseTubFilesPath = MakeProgramDataFolder("TUB_Files");

            StaticObjects.Logger = new LogReviewer();
            StaticObjects.Logger.Initialize(pathLog, false);
            StaticObjects.Logger.Info("»»»» Startup");

            StaticObjects.Book = new BookEdit();

            GetDataFiles dataFiles = new GetDataFiles(Application.StartupPath, DataFolder());

            PathParameters = MakeProgramDataFolder("UbReviewer.json");
            if (!File.Exists(PathParameters))
            {
                StaticObjects.Logger.Info("Parameters not found, creating a new one: " + PathParameters);
            }

            // Initialize parameters
            StaticObjects.Parameters = ParameterReviewer.Deserialize(PathParameters);
            Parameters = ((ParameterReviewer)StaticObjects.Parameters);

            if (!StaticObjects.Book.Inicialize(dataFiles))
            {
                return false;
            }

            //StaticObjects.Book.GetFormatTable();


            Parameters.TranslationLeft= dataFiles.GetTranslation(Parameters.TranslationIdLeft);
            Parameters.TranslationMiddle = dataFiles.GetTranslation(Parameters.TranslationIdMiddle);
            Parameters.TranslationRight = new TranslationEdit(Parameters.LocalRepositoryFolder);

            return true;
        }

    }
}
