using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using UbStandardObjects;
using UbStandardObjects.Objects;

namespace UbReviewer.Classes
{
    internal class TranslationFromRepo: Translation
    {
        private ParameterReviewer Parameters = ((ParameterReviewer)StaticObjects.Parameters);

        private PaperFromRepo GetPaper(short paperNo)
        {
            FormatTable table= StaticObjects.Book.GetFormatTable();
            PaperFromRepo paper = new PaperFromRepo();
            paper.Paragraphs = new List<Paragraph>();
            Translation EnglishTranslation = StaticObjects.Book.GetTranslation(0);
            string folderPaper = Path.Combine(Parameters.LocalRepositoryFolder, $"Doc{paperNo:000}");
            foreach(string filePath in Directory.GetFiles(folderPaper, "*.md"))
            {
                ParagraphFromRepo paragraph = new ParagraphFromRepo(filePath);
                paragraph.FormatInt= EnglishTranslation.GetFormat(paragraph);
                paper.Paragraphs.Add(paragraph);
            }
            return paper;
        }


        public override Paper Paper(short paperNo)
        {
            return GetPaper(paperNo);
        }

    }
}
