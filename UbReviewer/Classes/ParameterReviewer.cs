using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UbStandardObjects;
using UbStandardObjects.Objects;

namespace UbReviewer.Classes
{
    internal class ParameterReviewer : Parameters
    {
        public short TranslationIdLeft { get; set; } = 0;

        public short TranslationIdMiddle { get; set; } = 143;

        public short TranslationIdRight { get; set; } = 34;

        public short LastPaperShown { get; set; } = 0;

        public string LastParagraphShown { get; set; } = "0:0-0";


        public Translation TranslationLeft { get; set; } = null;

        public Translation TranslationMiddle { get; set; } = null;

        public Translation TranslationRight { get; set; } = null;

        public string BashPath = @"C:\Program Files\Git\bin\bash.exe";

        public string PowershellPath = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";

        public string LastSecondBranchUsed = "";


        /// <summary>
        /// Add a string to list to be saved with parameters
        /// Keep a control local string updated
        /// Remove duplicates
        /// </summary>
        /// <param name="paramStringList"></param>
        /// <param name="controlStringList"></param>
        /// <param name="indexEntry"></param>
        public void AddEntry(List<string> paramStringList, ObservableCollection<string> controlStringList, string indexEntry)
        {
            // Just avoid duplicates
            if (paramStringList.Contains(indexEntry, StringComparer.OrdinalIgnoreCase))
            {
                return;
            }
            if (paramStringList.Count == MaxExpressionsStored)
            {
                controlStringList.RemoveAt(controlStringList.Count - 1);
                paramStringList.RemoveAt(paramStringList.Count - 1);
            }
            controlStringList.Insert(0, indexEntry);
            paramStringList.Insert(0, indexEntry);
        }


        /// <summary>
        /// Serialize the parameters instance
        /// </summary>
        /// <param name="p"></param>
        /// <param name="pathParameters"></param>
        public static void Serialize(ParameterReviewer p, string pathParameters)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    AllowTrailingCommas = true,
                    WriteIndented = true,
                };
                var jsonString = JsonSerializer.Serialize<ParameterReviewer>(p, options);
                File.WriteAllText(pathParameters, jsonString);
            }
            catch { }
        }

        /// <summary>
        /// Deserialize the parameters instance
        /// </summary>
        /// <param name="pathParameters"></param>
        /// <returns></returns>
        public static ParameterReviewer Deserialize(string pathParameters)
        {
            try
            {
                StaticObjects.Logger.Info("»»»» Deserialize Parameters");
                var jsonString = File.ReadAllText(pathParameters);
                return StaticObjects.DeserializeObject<ParameterReviewer>(jsonString);
            }
            catch
            {
                StaticObjects.Logger.Info("»»»» Deserialize Parameters creating default");
                return new ParameterReviewer();
            }
        }

    }
}
