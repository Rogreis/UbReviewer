using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbStandardObjects;
using UbStandardObjects.Objects;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UbReviewer.Classes
{
    internal class ParagraphFromRepo : Paragraph
    {

        public ParagraphFromRepo(string filePath)
        {
            char[] separators = { '_' };
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string[] parts = fileName.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Paper = Convert.ToInt16(parts[1]);
            Section = Convert.ToInt16(parts[2]);
            ParagraphNo = Convert.ToInt16(parts[3]);
            Text = File.ReadAllText(filePath);
        }
    }
}
