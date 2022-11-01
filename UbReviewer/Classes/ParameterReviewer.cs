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

        public short LastSectionShown { get; set; } = 0;

        public short LastParagraphShown { get; set; } = 0;

        public Translation TranslationLeft { get; set; } = null;

        public Translation TranslationMiddle { get; set; } = null;

        public Translation TranslationRight { get; set; } = null;

        public string GitHubUserName { get; set; } = null;

        // Last paragraph identification used in mdi form
        public string LastIdentParagraphUsed { get; set; } = "";

        public Size EditWindowSize { get; set; } = new Size(1157, 839);
        public Point EditWindowLocation { get; set; } = new Point(0, 0);

        [JsonIgnore]
        public string PowershellPath = "";

        [JsonIgnore]
        public string LastSecondBranchUsed = "";

        [JsonIgnore]
        public string BashPath = @"C:\Program Files\Git\bin\bash.exe";

        /// <summary>
        /// Repositories needs to be checked just once per UbReviewer instance
        /// </summary>
        [JsonIgnore]
        public bool RespositoriesChecked = false;



        #region Color
        // Colors
        // Color code source: https://rgbcolorcode.com/color/FFB3B3
        [JsonPropertyName("ForegroundColor")]
        public int _foregroundColor { get; set; } = Color.Black.ToArgb();

        [JsonIgnore]
        public Color ForegroundColor
        {
            get { return Color.FromArgb(_foregroundColor); }
            set { _foregroundColor = value.ToArgb(); }
        }

        // Colors
        // Color code source: https://rgbcolorcode.com/color/FFB3B3
        [JsonPropertyName("ItalicForegroundColor")]
        public int _italicforegroundColor { get; set; } = Color.Magenta.ToArgb();

        [JsonIgnore]
        public Color ItalicForegroundColor
        {
            get { return Color.FromArgb(_italicforegroundColor); }
            set { _italicforegroundColor = value.ToArgb(); }
        }


        [JsonPropertyName("BackgroundStarted")]
        public int _backgroundStarted = Color.White.ToArgb();

        [JsonIgnore]
        public Color BackgroundStarted
        {
            get { return Color.FromArgb(_backgroundStarted); }
            set { _backgroundStarted = value.ToArgb(); }
        }

        [JsonPropertyName("BackgroundWorking")]
        public int _backgroundWorking = Color.FromArgb(238, 255, 204).ToArgb();

        [JsonIgnore]
        public Color BackgroundWorking
        {
            get { return Color.FromArgb(_backgroundWorking); }
            set { _backgroundWorking = value.ToArgb(); }
        }

        [JsonPropertyName("BackgroundDoubt")]
        public int _backgroundDoubt = Color.FromArgb(255, 179, 179).ToArgb();

        [JsonIgnore]
        public Color BackgroundDoubt
        {
            get { return Color.FromArgb(_backgroundDoubt); }
            set { _backgroundDoubt = value.ToArgb(); }
        }

        [JsonPropertyName("BackgroundOk")]
        public int _backgroundOk = Color.FromArgb(204, 255, 230).ToArgb();

        [JsonIgnore]
        public Color BackgroundOk
        {
            get { return Color.FromArgb(_backgroundOk); }
            set { _backgroundOk = value.ToArgb(); }
        }

        [JsonPropertyName("BackgroundClosed")]
        public int _backgroundClosed = Color.FromArgb(212, 212, 212).ToArgb();

        [JsonIgnore]
        public Color BackgroundClosed
        {
            get { return Color.FromArgb(_backgroundClosed); }
            set { _backgroundClosed = value.ToArgb(); }
        }

        #endregion



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

        /// <summary>
        /// Provide the html background color for a paragraph
        /// </summary>
        /// <param name="Paragraph"></param>
        /// <returns></returns>
        public override string BackgroundParagraphColor(ParagraphStatus paragraphStatus)
        {
            switch (paragraphStatus)
            {
                case ParagraphStatus.Started:
                    return System.Drawing.ColorTranslator.ToHtml(BackgroundStarted).Trim();
                case ParagraphStatus.Working:
                    return System.Drawing.ColorTranslator.ToHtml(BackgroundWorking).Trim();
                case ParagraphStatus.Doubt:
                    return System.Drawing.ColorTranslator.ToHtml(BackgroundDoubt).Trim();
                case ParagraphStatus.Ok:
                    return System.Drawing.ColorTranslator.ToHtml(BackgroundOk).Trim();
                case ParagraphStatus.Closed:
                    return System.Drawing.ColorTranslator.ToHtml(BackgroundClosed).Trim();
            }
            return System.Drawing.ColorTranslator.ToHtml(BackgroundStarted).Trim();
        }


    }
}
