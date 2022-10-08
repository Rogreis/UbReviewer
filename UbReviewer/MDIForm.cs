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
            if (Initialize())
            {
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
            ///ShowDocument();
        }


        private void btGit_Click(object sender, EventArgs e)
        {
            frmGitCommands frm = new frmGitCommands();
            frm.MdiParent = this;
            frm.Show();
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

            StaticObjects.Book = new Book();


            PathParameters = MakeProgramDataFolder("UbReviewer.json");
            if (!File.Exists(PathParameters))
            {
                StaticObjects.Logger.Info("Parameters not found, creating a new one: " + PathParameters);
            }

            // Initialize parameters
            StaticObjects.Parameters = ParameterReviewer.Deserialize(PathParameters);
            Parameters = ((ParameterReviewer)StaticObjects.Parameters);

            frmGitCommands frm = new frmGitCommands();
            frm.ShowDialog();

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
            Translation trans= dataFiles.GetTranslation(editLanguageId);
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
                PaperEdit paper = new PaperEdit(paperNo, StaticObjects.Parameters.EditParagraphsRepositoryFolder);
                frmEdit frm = new frmEdit();
                frm.SetParagraph(paper, paperNo, sectionNo, paragraphNo);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //ShowPaper(paperNo);
                }
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
    }
}
