using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbStandardObjects;

namespace UbReviewer.Classes
{
    internal class RunScripts
    {

        private static StringBuilder stringBuilderConsole = null;

        private static StringBuilder stringBuilderErrors = null;


        #region Private functions
        private static Process GetPowershellProcess()
        {
            ParameterReviewer param = (ParameterReviewer)StaticObjects.Parameters;
            Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = param.PowershellPath;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.StartInfo.ErrorDialog = true;

            //Set output of program to be written to process output stream
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.RedirectStandardError = true;
            //Optional
            //pProcess.StartInfo.WorkingDirectory = workingDirectory;
            return pProcess;
        }


        private static Process GetBashProcess()
        {
            ParameterReviewer param = (ParameterReviewer)StaticObjects.Parameters;
            Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = param.BashPath;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.StartInfo.ErrorDialog = true;

            //Set output of program to be written to process output stream
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.RedirectStandardError = true;
            //Optional
            //pProcess.StartInfo.WorkingDirectory = workingDirectory;
            return pProcess;
        }

        private static void ExecuteProcess(Process pProcess, int timeoutMiliseconds = 10000)
        {
            //Start the process
            pProcess.Start();
            if (timeoutMiliseconds == 0)
            {
                pProcess.WaitForExit();
            }
            else
            {
                pProcess.WaitForExit(timeoutMiliseconds);
            }
            if (!pProcess.HasExited)
            {
                pProcess.Kill();
                pProcess.WaitForExit();
            }
        }


        private static void GetLines(StreamReader reader, List<string> list)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                list.Add(line);
                //Program.Log.Logger.Info(line);
                line = reader.ReadLine();
            }
        }

        private static List<string> ExecuteGetLines(string bashScriptPath, int timeoutMiliseconds = 10000)
        {
            List<string> list = new List<string>();
            try
            {
                Process pProcess = GetBashProcess();
                pProcess.StartInfo.Arguments = RunScripts.GetUnixPath(bashScriptPath);
                ExecuteProcess(pProcess, timeoutMiliseconds);

                //Get program output
                if (pProcess.ExitCode > 0)
                {
                    list.Add($"ERROR - process exit code {pProcess.ExitCode}");
                    GetLines(pProcess.StandardError, list);
                }
                else
                {
                    GetLines(pProcess.StandardOutput, list);
                }
                return list;
            }
            catch 
            {
                throw;
                //Messenger.FireShowLogErrorMessage("BASH: ExecuteGettingLines", ex);
                //return list;
            }
        }

        private static bool ExecuteBashGetLinesAsync(string bashScriptPath)
        {
            try
            {
                stringBuilderConsole = new StringBuilder();
                stringBuilderErrors = new StringBuilder();

                using (Process process = GetBashProcess())
                {
                    process.StartInfo.Arguments = RunScripts.GetUnixPath(bashScriptPath);
                    process.StartInfo.Arguments = "-c \" " + RunScripts.GetUnixPath(bashScriptPath) + " \"";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.ErrorDialog = true;

                    process.Start();
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.OutputDataReceived += Process_OutputDataReceived;
                    process.ErrorDataReceived += Process_ErrorDataReceived;
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit();
                }
                string errors = stringBuilderErrors.ToString();
                string result= stringBuilderConsole.ToString();
                if (!string.IsNullOrEmpty(errors) && errors.Length > 2)
                {
                    //Messenger.FireShowLogErrorMessage($"Python Script output error: {errors}");
                    return false;
                }
                else
                {
                    //sb.Append(File.ReadAllText(jsonOutputFilePath));
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            stringBuilderErrors.AppendLine(e.Data);
        }

        private static void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            stringBuilderConsole.AppendLine(e.Data);
        }


        private static string WriteScript(StringBuilder sb, string extension = ".sh")
        {
            string bashScriptPath = Path.Combine(Path.GetTempPath(), $"automation{extension}");
            if (File.Exists(bashScriptPath))
            {
                File.Delete(bashScriptPath);
            }
            File.WriteAllText(bashScriptPath, sb.ToString());
            return bashScriptPath;
        }


        //private static string GetWindowsPath(string path)
        //{
        //    return path.Replace(@"/", @"\").Replace("\r\n", "");
        //}

        #endregion


        public static string GetUnixPath(string path)
        {
            if (path.StartsWith(@"C:", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Replace(@"C:", "/c");
                path = path.Replace(@"c:", "/c");
            }
            return path.Replace(@"\", "/");
        }


        public static List<string> ExecuteSomeCommands(List<string> commands)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string command in commands)
            {
                sb.AppendLine(command);
            }
            string bashScriptPath = WriteScript(sb);
            File.WriteAllText(bashScriptPath, sb.ToString());
            return ExecuteGetLines(bashScriptPath);
        }

        public static List<string> ExecuteSomeCommandsAsync(List<string> commands)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string command in commands)
            {
                sb.AppendLine(command);
            }
            string bashScriptPath = WriteScript(sb);
            File.WriteAllText(bashScriptPath, sb.ToString());
            ExecuteBashGetLinesAsync(bashScriptPath);
            return null; // fix
        }

        public static List<string> ExecuteSomeCommandsRedirected(List<string> commands)
        {
            string outputFile = Path.Combine(Path.GetTempPath(), "lines.txt");
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }


            StringBuilder sb = new StringBuilder();
            foreach (string command in commands)
            {
                sb.AppendLine(command);
            }
            string bashScriptPath = WriteScript(sb);
            File.WriteAllText(bashScriptPath, sb.ToString());
            ExecuteBashGetLinesAsync(bashScriptPath);
            return null;
        }


    }
}
