using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbStandardObjects.Objects;

namespace UbReviewer.Classes
{
    internal class HtmlFormatParametersReviewer : HtmlFormatParameters
    {
        /// <summary>
        /// Provide the html background color for a paragraph
        /// </summary>
        /// <param name="ParagraphStatus"></param>
        /// <returns></returns>
        public override string statusBackgroundColor(ParagraphStatus ParagraphStatus)
        {
            switch (ParagraphStatus)
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
