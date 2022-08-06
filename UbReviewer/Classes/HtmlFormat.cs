using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbStandardObjects.Objects;

namespace UbReviewer.Classes
{
	/// <summary>
	/// Format html to be shown
	/// </summary>
    internal class HtmlFormat
    {

		private string Styles()
		{
			return "<style type=\"text/css\"> " + Environment.NewLine +
							 " " + Environment.NewLine +
							 ".stPar " + Environment.NewLine +
							 "{ " + Environment.NewLine +
							 " font-family: Verdana; " + Environment.NewLine +
							 " font-size: small; " + Environment.NewLine +
							 " background-color: #FFFFCC; " + Environment.NewLine +
							 "} " + Environment.NewLine +
							 " " + Environment.NewLine +
							 ".stSection " + Environment.NewLine +
							 "{ " + Environment.NewLine +
							 " font-family: Verdana; " + Environment.NewLine +
							 " font-size: small; " + Environment.NewLine +
							 " background-color: #0000FF; " + Environment.NewLine +
							 " font-weight: bold; " + Environment.NewLine +
							 " color: #FFFF00; " + Environment.NewLine +
							 "} " + Environment.NewLine +

							 ".stParHighlighted {  border: thin dotted #66FF33;  font-family: Verdana;  font-size: small;  background-color: #FFFF66; }" + Environment.NewLine +
							 ".stSectionHighlighted { border: thin dotted #00FF00; font-family: Verdana; font-size: small; background-color: #993300; font-weight: bold; color: #FFFF00;}" + Environment.NewLine +

							 "i { " + Environment.NewLine +
							 " font-family: Verdana; " + Environment.NewLine +
							 " font-size: small; " + Environment.NewLine +
							 " color: #FF33CC; " + Environment.NewLine +
							 " font-weight: bold; " + Environment.NewLine +
							 "} " + Environment.NewLine +

							 "em { " + Environment.NewLine +
							 " font-family: Verdana; " + Environment.NewLine +
							 " font-size: small; " + Environment.NewLine +
							 " color: #FF33CC; " + Environment.NewLine +
							 " font-weight: bold; " + Environment.NewLine +
							 "} " + Environment.NewLine +


							 "</style> " + Environment.NewLine +
							 " " + Environment.NewLine;
		}

		private string ShowHtml(short paperNo, List<Paragraph> paragraphs, bool showMiddleCOlumn= true, bool ShowCompareColumn= false)
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("<HTML>");
			sb.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1252\">");
			sb.AppendLine($"<title>Paper {paperNo}</title>");
			sb.AppendLine(Styles());
			sb.AppendLine("<BODY>");

			try
			{

				// http://winrus.com/cpage_e.htm


				sb.AppendLine("<table border=\"1\" width=\"100%\" id=\"table1\" cellspacing=\"10\" cellpadding=\"4\">");

				//foreach (ParagraphTexts p in listPara) p.MakeLine(sb, ShowCompareColumn);

				return sb.ToString();
			}
			catch (Exception ex)
			{
				sb.AppendLine($"<h1>Error while formatting html page: {ex.Message}</h1>");
			}

			sb.AppendLine("</table>");
			sb.AppendLine("</P></BODY>");
			sb.AppendLine("</HTML>");
			return sb.ToString();
		}

	}
}
