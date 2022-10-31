using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UbReviewer.ChildWindows;
using UbReviewer.Classes;
using UbStandardObjects;
using UbStandardObjects.Objects;
using static System.Environment;

namespace UbReviewer
{
    internal static class Program
    {

        private static string DataFolder()
        {
            string processName = System.IO.Path.GetFileNameWithoutExtension(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            var commonpath = GetFolderPath(SpecialFolder.CommonApplicationData);
            return Path.Combine(commonpath, processName);
        }


        private static string MakeProgramDataFolder(string fileName)
        {
            string folder = DataFolder();
            Directory.CreateDirectory(folder);
            return Path.Combine(folder, fileName);
        }

        private static void DeleteFile(string pathFile)
        {
            if (File.Exists(pathFile)) File.Delete(pathFile);
        }

        public static bool ShowGitCommands()
        {
            frmGitCommands frm = new frmGitCommands();
            frm.ShowDialog();
            return ((ParameterReviewer)StaticObjects.Parameters).RespositoriesChecked;
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StaticObjects.PathLog = MakeProgramDataFolder("UbReviewer.log");
            DeleteFile(StaticObjects.PathLog);

            StaticObjects.Logger = new LogReviewer();
            StaticObjects.Logger.Initialize(StaticObjects.PathLog, false);
            StaticObjects.Logger.Info("»»»» Startup");

            StaticObjects.Book = new Book();


            StaticObjects.PathParameters = MakeProgramDataFolder("UbReviewer.json");
            if (!File.Exists(StaticObjects.PathParameters))
            {
                StaticObjects.Logger.Info("Parameters not found, creating a new one: " + StaticObjects.PathParameters);
            }

            // Initialize parameters
            StaticObjects.Parameters = ParameterReviewer.Deserialize(StaticObjects.PathParameters);
            StaticObjects.Parameters = ((ParameterReviewer)StaticObjects.Parameters);

            // Fixed paths for this app
            StaticObjects.Parameters.EditBookRepositoryFolder = "";  // No full book needed yet
            StaticObjects.Parameters.TUB_Files_RepositoryFolder = MakeProgramDataFolder("TUB_Files");
            StaticObjects.Parameters.EditParagraphsRepositoryFolder = MakeProgramDataFolder("PtAlternative");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (ShowGitCommands())
            {
                Application.Run(new mdiForm());
            }

            DeleteFile(StaticObjects.PathParameters);
            ParameterReviewer.Serialize((ParameterReviewer)StaticObjects.Parameters, StaticObjects.PathParameters);
        }
    }
}
