using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace UbReviewerLibrary
{
    public class RevParagraph
    {


        private class Rootobject
        {
            public Paragraphsnumber[] ParagraphsNumber { get; set; }
        }

        private class Paragraphsnumber
        {
            public int Paper { get; set; }
            public int Section { get; set; }
            public int ParagraphNumber { get; set; }
        }

        private List<Paragraphsnumber> ParagraphsNumber = null;

        public RevParagraph(string appPath)
        {
            string pathFile = Path.Combine(appPath, @"DataFiles\ParagraphsNumber.json");
            string jsonString = File.ReadAllText(pathFile);
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true
            };
            //Rootobject root = JsonSerializer.Deserialize<Rootobject>(jsonString, options);
            //ParagraphsNumber = new List<Paragraphsnumber>(root.ParagraphsNumber);
        }

        public List<int> PapersPartI()
        {
            return ParagraphsNumber.Select(p => p.Paper).ToList().FindAll(p => p >= 0 && p < 32).Distinct().ToList();
        }
        public List<int> PapersPartII()
        {
            return ParagraphsNumber.Select(p => p.Paper).ToList().FindAll(p => p >= 32 && p < 57).Distinct().ToList();
        }
        public List<int> PapersPartIII()
        {
            return ParagraphsNumber.Select(p => p.Paper).ToList().FindAll(p => p >= 57 && p < 120).Distinct().ToList();
        }
        public List<int> PapersPartIV()
        {
            return ParagraphsNumber.Select(p => p.Paper).ToList().FindAll(p => p >= 120).Distinct().ToList();
        }
    }
}
