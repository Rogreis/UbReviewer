using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbReviewer.Classes
{

    internal enum GitActions
    {
        Clone,
        Checkout,
        Stage,
        Commit,
        Pull,
        Push
    }


    internal class GitData
    {
        public string Branch = "";

        public bool IsRepository = true;

        public bool IsToBeCommited = false;

        public bool IsToBeStaged = false;

        public bool IsUpToDate = false;

        public bool HasNonPushedCommits = false;

        public bool NeedsPull = false;

        public List<string> ToBeCommited = new List<string>();

        public List<string> ToBeStaged = new List<string>();

        public List<GitActions> GitInitializationsActionsNeeded(string branch)
        {
            List<GitActions> list = new List<GitActions>();

            if (!IsRepository)
            {
                list.Add(GitActions.Clone);
                //list.Add(GitActions.Pull);
                return list;
            }

            //if (IsToBeStaged) list.Add(GitActions.Stage);
            //if (IsToBeCommited) list.Add(GitActions.Commit);
            //if (HasNonPushedCommits) list.Add(GitActions.Push);
            if (!IsUpToDate) list.Add(GitActions.Pull);
            if (Branch != branch)
            {
                list.Add(GitActions.Checkout);
                list.Add(GitActions.Pull);
            }
            return list;
        }


    }


}
