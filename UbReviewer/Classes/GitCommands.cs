using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UbReviewer.ChildWindows;
using UbStandardObjects;
using UbStandardObjects.Objects;

namespace UbReviewer.Classes
{
    internal class GitCommands
    {

        private static void ShowMessage(string message)
        {
            StaticObjects.FireSendMessage(message);
        }


        #region Old Routines
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
            List<string> result = RunScripts.ExecuteSomeCommands(commands);
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

        #endregion


        #region Check for errors routines
        public static void DumpCommands(string command, List<string> commands, List<string> returnedLines)
        {
            StaticObjects.Logger.Info("");
            StaticObjects.Logger.Info("Git command: " + command);
            if (commands == null)
            {
                StaticObjects.Logger.Info("   null");
            }
            else
            {
                foreach (string s in commands)
                {
                    StaticObjects.Logger.Info("   " + s);
                }
                StaticObjects.Logger.Info("");
                StaticObjects.Logger.Info("   Returned lines:");
                if (returnedLines != null)
                {
                    foreach (string s in returnedLines)
                    {
                        StaticObjects.Logger.Info("   " + s);
                    }
                }
                else
                {
                    StaticObjects.Logger.Info("   No returned line");
                }
            }
        }

        public static bool NoErrorInList(List<string> returnedLines)
        {
            if (returnedLines == null || returnedLines.Count == 0)
            {
                StaticObjects.Logger.Info("   No returned line");
                return false;
            }
            if (returnedLines[0].StartsWith("ERROR"))
            {
                string message = "*** Error occurred. See log.";
                ShowMessage(message);
                return false;
            }
            return true;
        }


        #endregion


        #region Git commands
        public static GitData Status(string folder = null)
        {

            // Default folders
            if (folder == null)
            {
                folder = StaticObjects.Parameters.EditParagraphsRepositoryFolder;
            }

            GitData gitData = new GitData();
            if (gitData == null) return null;

            List<string> commands = new List<string>()
            {
                "cd " + RunScripts.GetUnixPath(folder),
                "git status"
            };

            List<string> list = RunScripts.ExecuteSomeCommands(commands);
            DumpCommands("Status", commands, list);
            //if (!NoErrorInList(list)) return null;

            // Parse status lines returned
            foreach (string line in list)
            {
                if (line.StartsWith("On branch "))
                {
                    gitData.Branch = line.Replace("On branch ", "").Trim();
                }
                if (line.StartsWith("Your branch is up to date with ") || line.StartsWith("Your branch is ahead"))
                {
                    gitData.IsUpToDate = true;
                }
                if (line.StartsWith("fatal: not a git repository"))
                {
                    gitData.IsRepository = false;
                }
                if (line.StartsWith("nothing to commit"))
                {
                    gitData.IsToBeCommited = false;
                }
                if (line.StartsWith("Changes to be committed"))
                {
                    gitData.IsToBeStaged = false;
                    gitData.IsToBeCommited = true;
                }
                if (line.StartsWith("Your branch is behind"))
                {
                    gitData.NeedsPull = true;
                }
                if (line.StartsWith("Changes not staged for commit"))
                {
                    gitData.IsToBeCommited = false;
                    gitData.IsToBeStaged = true;
                }
                if (line.StartsWith("Your branch is ahead of"))
                {
                    gitData.HasNonPushedCommits = true;
                }

                if (line.StartsWith("\tmodified:   "))
                {
                    if (gitData.IsToBeCommited)
                    {
                        gitData.ToBeCommited.Add(line.Replace("\tmodified:   ", "").Trim());
                    }
                    else
                    {
                        gitData.ToBeStaged.Add(line.Replace("\tmodified:   ", "").Trim());
                    }
                }
            }
            return gitData;
        }

        public static bool GitCommand(string command, string folder)
        {
            List<string> commands = new List<string>()
                {
                    "cd " + RunScripts.GetUnixPath(folder),
                    $"git {command}",
                };
            List<string> list = RunScripts.ExecuteSomeCommands(commands);
            DumpCommands(command, commands, list);
            return NoErrorInList(list);
        }

        public static bool Stage(string folder)
        {
            ShowMessage(null);
            ShowMessage("Stage...");
            if (!GitCommand("add .", folder)) return false;
            ShowMessage("Stage ok");
            return true;
        }

        public static GitData Clone(string sshUrl, string folder)
        {
            List<string> commands = new List<string>()
                {
                    "cd " + RunScripts.GetUnixPath(folder),
                    $"git clone {sshUrl} .",
                };
            List<string> list = RunScripts.ExecuteSomeCommands(commands);
            DumpCommands("Clone", commands, list);
            return Status(folder);
        }

        public static bool Commit(string folder)
        {
            ShowMessage("Commit...");
            frmCommit frm = new frmCommit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (!GitCommand($"commit -m \"{frm.CommitMessage}\"", folder)) return false;
                ShowMessage("Commit ok");
                Status(folder);
                return true;
            }
            else
            {
                ShowMessage("Commit cancelled");
                Status(folder);
                return false;
            }
        }

        public static void Undo()
        {
            ShowMessage("Undo...");
            if (MessageBox.Show($"Are you sure to remove all changes??", "Ub Review",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                List<string> commands = new List<string>()
                {
                    "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
                    "git reset --hard",
                    "git clean -fxd",
                };
                List<string> list = RunScripts.ExecuteSomeCommands(commands);
                DumpCommands("Undo", commands, list);
            }
            else ShowMessage("Undo cancelled.");
        }


        public static bool Push(string folder)
        {
            ShowMessage("Push...");
            GitData gitData = Status();
            if (gitData == null) return false;

            if (!gitData.HasNonPushedCommits)
            {
                ShowMessage("Nothing to push");
                return true;
            }
            if (!GitCommand($"push -f", folder)) return false;
            ShowMessage("Push ok");
            return true;
        }

        #endregion

        #region Initialize routines

        public static bool InicializeRepository(string sshUrl, string folder, string branch)
        {
            Directory.CreateDirectory(folder);
            GitData gitData = Status(folder);
            if (gitData == null) return false;

            List<GitActions> actions = gitData.GitInitializationsActionsNeeded(branch);

            foreach (GitActions action in actions)
            {
                switch (action)
                {
                    case GitActions.Pull:
                        ShowMessage("Pull...");
                        GitCommand($"pull", folder);
                        ShowMessage("Pull ok");
                        break;

                    case GitActions.Checkout:
                        ShowMessage("Checkout...");
                        if (!GitCommand($"checkout -f -b {branch}; git push --set-upstream origin {branch}", folder)) return false;
                        ShowMessage("Checkout ok");
                        break;

                    case GitActions.Push:
                        if (!Push(folder)) return false;
                        break;

                    case GitActions.Commit:
                        if (!Commit(folder)) return false;
                        break;

                    case GitActions.Stage:
                        if (!Stage(folder)) return false;
                        break;

                    case GitActions.Clone:
                        ShowMessage("Clone...");
                        gitData = Clone(sshUrl, folder);
                        if (!gitData.IsRepository)
                        {
                            ShowMessage("ERROR: Could not clone.");
                            return false;
                        }
                        ShowMessage("Clone ok");
                        break;
                }
            }
            return true;
        }

        #endregion


        #region History from file

        private static Encoding GetEncoding(byte[] bytes)
        {
            // Analyze the BOM
            if (bytes[0] == 0x2b && bytes[1] == 0x2f && bytes[2] == 0x76) return Encoding.UTF7;
            if (bytes[0] == 0xef && bytes[1] == 0xbb && bytes[2] == 0xbf) return Encoding.UTF8;
            if (bytes[0] == 0xff && bytes[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bytes[0] == 0xfe && bytes[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bytes[0] == 0 && bytes[1] == 0 && bytes[2] == 0xfe && bytes[3] == 0xff) return Encoding.UTF32;
            return Encoding.UTF8;
        }

        private static string FixEncoding(string line)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(line);
            Encoding encoding = GetEncoding(bytes);
            return encoding.GetString(bytes);
        }


        private static void GitLog()
        {
            // git log -p -- Doc120/Par_120_002_001.md
            ShowMessage("History...");
            List<string> commands = new List<string>()
            {
                "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
                "git log --pretty=oneline -- Doc120/Par_120_002_001.md",
            };
            // git show ce49661f16036d366d212b57a4a1a3ccd15362da:Doc120/Par_120_002_001.md
            List<string> list = RunScripts.ExecuteSomeCommands(commands);
            foreach (string line in list) ShowMessage(line);
        }

        public static List<string> GitHistory(ParagraphMarkDown Paragraph)
        {
            List<string> linesReturned = new List<string>();
            // git log -p -- Doc120/Par_120_002_001.md
            string filePath = ParagraphMarkDown.RelativeFilePath(Paragraph);

            List<string> commands = new List<string>()
            {
                "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
                $"git log --encoding=UTF-8 --pretty=oneline -- {filePath}",
            };
            // git show ce49661f16036d366d212b57a4a1a3ccd15362da:Doc120/Par_120_002_001.md
            List<string> list = RunScripts.ExecuteSomeCommands(commands);
            foreach (string l in list)
            {
                if (l.Length >= 40)
                {
                    string hash = l.Substring(0, 40);
                    string printLine = l.Replace(hash, "");
                    linesReturned.Add($"Commit comment: {FixEncoding(printLine)}");
                    commands = new List<string>()
                    {
                        "cd " + RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder),
                        $"git show --encoding=UTF-8 {hash}:{filePath}",
                    };
                    List<string> list2 = RunScripts.ExecuteSomeCommands(commands);
                    foreach (string line in list2)
                    {
                        linesReturned.Add("");
                        linesReturned.Add(FixEncoding(line));
                    }
                    linesReturned.Add("");
                }
            }
            return linesReturned;
        }

        public List<string> GitHistory2()
        {
            List<string> linesReturned = new List<string>();

            try
            {
                //var repo = new LibGit2Sharp.Repository(RunScripts.GetUnixPath(StaticObjects.Parameters.EditParagraphsRepositoryFolder));
                var repo = new LibGit2Sharp.Repository(StaticObjects.Parameters.EditParagraphsRepositoryFolder);

                foreach (Commit commit in repo.Commits)
                {
                    foreach (var parent in commit.Parents)
                    {
                        linesReturned.Add($"{commit.Sha} | {commit.MessageShort}");
                        foreach (TreeEntryChanges change in repo.Diff.Compare<TreeChanges>(parent.Tree, commit.Tree))
                        {
                            linesReturned.Add($"{change.Status} : {change.Path}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                linesReturned.Add($"Error:  {ex.Message}");
            }

            return linesReturned;

            //using (var repo = new Repository(Run "path\to\repo.git"))
            //{

            //}

        }



        #endregion


    }
}
