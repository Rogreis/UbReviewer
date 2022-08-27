using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbReviewer.Classes
{
    internal class GitCommands
    {
        /// <summary>
        /// Checkout a files from a branch or commit hash
        /// </summary>
        /// <param name="basePath"></param>
        /// <param name="relativePath"></param>
        /// <param name="branchName"></param>
        /// <returns></returns>
        public static List<string> GetFileCheckout(string basePath, string relativePath, string branchName)
        {
            List<string> result = new List<string>();
            if (string.IsNullOrWhiteSpace(relativePath))
            {
                return new List<string>() { $"ERROR: Relative path null or empty in GetFileCheckout" };
            }

            string pathFile = Path.Combine(basePath, relativePath);
            string fileName = Path.GetFileName(pathFile);
            string unixFilePath = RunScripts.GetUnixPath(Path.GetDirectoryName(pathFile));

            List<string> commands = new List<string>()
            {
                $"cd {unixFilePath}",
                $"git checkout {branchName} {fileName}"
            };

            return RunScripts.ExecuteSomeCommands(commands);
        }

        /// <summary>
        /// Undo a file checkout 
        /// </summary>
        /// <param name="basePath"></param>
        /// <param name="relativePath"></param>
        /// <returns></returns>
        public static List<string> GetUndoFileCheckout(string basePath, string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
            {
                return new List<string>() { $"ERROR: Relative path null or empty in GetUndoFileCheckout" };
            }

            string pathFile = Path.Combine(basePath, relativePath);
            string fileName = Path.GetFileName(pathFile);
            string unixFilePath = RunScripts.GetUnixPath(Path.GetDirectoryName(pathFile));

            List<string> commands = new List<string>()
            {
                $"cd {unixFilePath}",
                $"git checkout HEAD {fileName}"
            };

            return RunScripts.ExecuteSomeCommands(commands);
        }

        /// <summary>
        /// Get the current branch name
        /// </summary>
        /// <param name="basePath"></param>
        /// <returns></returns>
        public static string GetCurrentBranch(string basePath)
        {
            string unixFilePath = RunScripts.GetUnixPath(basePath);

            List<string> commands = new List<string>()
            {
                $"cd {unixFilePath}",
                $"git branch --show-current"
            };
            List<string> result= RunScripts.ExecuteSomeCommands(commands);
            if (result != null && result.Count > 0)
                return result[0];
            return String.Empty;
        }

        /// <summary>
        /// Stage a file
        /// </summary>
        /// <param name="basePath"></param>
        /// <param name="relativeFilePath"></param>
        /// <returns></returns>
        public static List<string> GetStageFile(string basePath, string relativeFilePath)
        {
            List<string> commands = new List<string>()
            {
                $"cd {RunScripts.GetUnixPath(basePath)}",
                $"git add {relativeFilePath}"
            };

            return RunScripts.ExecuteSomeCommands(commands);
        }



        //public static List<string> DiffBranchesFileListAsync(string basePath, string secondBranchName)
        //{
        //    List<string> commands = new List<string>()
        //    {
        //        $"cd {RunScripts.GetUnixPath(basePath)}",
        //        $"git diff --name-only {secondBranchName} | cat"
        //    };
        //    return RunScripts.ExecuteSomeCommandsAsync(commands);
        //}

        /// <summary>
        /// Get a list of relative path files names that differ from second branch
        /// </summary>
        /// <param name="basePath"></param>
        /// <param name="secondBranchName"></param>
        /// <returns></returns>
        public static List<string> DiffBranchesFileList(string basePath, string secondBranchName)
        {
            List<string> commands = new List<string>()
            {
                $"cd {RunScripts.GetUnixPath(basePath)}",
                $"git diff --name-only {secondBranchName} | cat"
            };
            // return RunScripts.ExecuteSomeCommandsAsync(commands);
            return RunScripts.ExecuteSomeCommands(commands);
        }

        /// <summary>
        /// List all available branches in the repository
        /// </summary>
        /// <param name="basePath"></param>
        /// <returns></returns>
        public static List<string> LocalBranches(string basePath)
        {
            List<string> commands = new List<string>()
            {
                $"cd {RunScripts.GetUnixPath(basePath)}",
                $"git branch --no-color | cat"
            };
            // return RunScripts.ExecuteSomeCommandsAsync(commands);
            return RunScripts.ExecuteSomeCommands(commands);
        }


        // 

    }
}
