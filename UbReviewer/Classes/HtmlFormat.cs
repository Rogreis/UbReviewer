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
		// Data used to help columns page
		private double percent = 0;

		ParameterReviewer Param = null;


		public HtmlFormat(ParameterReviewer parameters)
		{
			Param = parameters;

		}

		#region Styles

		private void paragraphStyle(StringBuilder sb, ParagraphStatus ParagraphStatus)
		{
			sb.AppendLine("." + statusStyleName(ParagraphStatus));
			sb.AppendLine("{  ");
			sb.AppendLine(" font-family: " + Param.FontFamily + ";");
			sb.AppendLine(" font-size: " + Param.FontSize.ToString() + ";  ");
			sb.AppendLine(" background-color: " + statusBackgroundColor(ParagraphStatus) + ";");
			sb.AppendLine(" padding: 16px; ");
			sb.AppendLine("}  ");
		}


		private void javaScript(StringBuilder sb)
		{
			sb.AppendLine("<script> ");
			sb.AppendLine(" ");
			sb.AppendLine("function changeStyleHigh(id) {  ");
			sb.AppendLine("  var el_up = document.getElementById(id);  ");
			sb.AppendLine("  el_up.style[\"border\"] = '3px dotted #66FF33';");
			sb.AppendLine("  el_up.style[\"mix-blend-mode\"] = 'difference';");
			sb.AppendLine("}          ");
			sb.AppendLine(" ");
			sb.AppendLine("function changeStyleNormal(id) {  ");
			sb.AppendLine("  var el_up = document.getElementById(id);  ");
			sb.AppendLine("  el_up.style[\"border\"] = '0px';  ");
			sb.AppendLine("}          ");
			sb.AppendLine("        ");
			sb.AppendLine("</script> ");
			sb.AppendLine(" ");
		}

		private void ItalicBoldStyles(StringBuilder sb)
		{
			sb.AppendLine("i, b, em  {  ");
			sb.AppendLine(" font-family: " + Param.FontFamily + ";");
			sb.AppendLine(" font-size: " + Param.FontSize.ToString() + ";  ");
			sb.AppendLine(" color: #FF33CC;  ");
			sb.AppendLine(" font-weight: bold;  ");
			sb.AppendLine("}  ");
		}

		private void HeaderStyle(StringBuilder sb, int header, float size)
		{
			sb.AppendLine($"h{header} {{");
			sb.AppendLine($"font-family: {Param.FontFamily};");
			sb.AppendLine($"font-size: {size}px;");
			sb.AppendLine("text-align: center;");
			sb.AppendLine("font-weight: bold;  ");
			sb.AppendLine("background-color: #0000FF;  ");
			sb.AppendLine("color: #FFFF00;  ");
			sb.AppendLine("}");
		}

		protected void Styles(StringBuilder sb)
		{

			float size = Param.FontSize;

			sb.AppendLine("<style type=\"text/css\">  ");
			sb.AppendLine("  ");

			// Body and Table
			sb.AppendLine($"body {{font-family: {Param.FontFamily}; font-size: {size + 4}px; color: #000000;}}");
			sb.AppendLine("table {  ");
			sb.AppendLine("    border: 1px solid #CCC;  ");
			sb.AppendLine("    border-collapse: collapse;  ");
			sb.AppendLine("}  ");
			sb.AppendLine($"td   {{font-family: {Param.FontFamily}; padding: 10px; font-size: {size + 4}px; color: #000000; text-align: left; font-style: none; text-transform: none; font-weight: none; border: none;}}");

			// Sup
			sb.AppendLine($"sup  {{font-size: {size - 1}px;  color: #666666;}}");


			// Title
			HeaderStyle(sb, 1, size + 6);
			HeaderStyle(sb, 2, size + 4);
			HeaderStyle(sb, 3, size + 2);


			paragraphStyle(sb, ParagraphStatus.Started);
			paragraphStyle(sb, ParagraphStatus.Working);
			paragraphStyle(sb, ParagraphStatus.Doubt);
			paragraphStyle(sb, ParagraphStatus.Ok);
			paragraphStyle(sb, ParagraphStatus.Closed);

			ItalicBoldStyles(sb);
			sb.AppendLine("  ");

			// Links
			sb.AppendLine(" ");
			sb.AppendLine("/* unvisited link */ ");
			sb.AppendLine("a:link { ");
			sb.AppendLine("  color: black; ");
			sb.AppendLine("  text-decoration: none; ");
			sb.AppendLine(" } ");
			sb.AppendLine(" ");
			sb.AppendLine("/* visited link */ ");
			sb.AppendLine("a:visited { ");
			sb.AppendLine("  color: gray; ");
			sb.AppendLine("  text-decoration: none; ");
			sb.AppendLine("} ");
			sb.AppendLine(" ");
			sb.AppendLine("/* mouse over link */ ");
			sb.AppendLine("a:hover { ");
			//sb.AppendLine("  color: blue; ");
			//sb.AppendLine("  text-decoration: none; ");
			sb.AppendLine("  font-weight: bold; ");
			sb.AppendLine("} ");
			sb.AppendLine(" ");
			sb.AppendLine("/* selected link */ ");
			sb.AppendLine("a:active { ");
			sb.AppendLine("  color: blue; ");
			sb.AppendLine("  text-decoration: none; ");
			//sb.AppendLine("  font-weight: bold; ");
			sb.AppendLine("} ");
			sb.AppendLine(" ");

			// Italic
			//sb.AppendLine($".ColItal {{font-family: {Param.FontFamily}; font-size: {size}px; color: #663333; font-style: italic;}}");
			//sb.AppendLine(".Colored {font-family: " + Param.FontFamily + "; font-size: 14px; color: #663333;}");
			//sb.AppendLine(".ppg     {font-family: " + Param.FontFamily + "; font-size: 9px;  color: #999999;  vertical-align:top;}");
			//sb.AppendLine(".super   {font-family: " + Param.FontFamily + "; font-size: 9px;  color: #000000;  vertical-align:top;}");

			sb.AppendLine("</style>  ");
		}

		private string statusBackgroundColor(ParagraphStatus ParagraphStatus)
		{
			switch (ParagraphStatus)
			{
				case ParagraphStatus.Started:
					return System.Drawing.ColorTranslator.ToHtml(Param.BackgroundStarted).Trim();
				case ParagraphStatus.Working:
					return System.Drawing.ColorTranslator.ToHtml(Param.BackgroundWorking).Trim();
				case ParagraphStatus.Doubt:
					return System.Drawing.ColorTranslator.ToHtml(Param.BackgroundDoubt).Trim();
				case ParagraphStatus.Ok:
					return System.Drawing.ColorTranslator.ToHtml(Param.BackgroundOk).Trim();
				case ParagraphStatus.Closed:
					return System.Drawing.ColorTranslator.ToHtml(Param.BackgroundClosed).Trim();
			}
			return System.Drawing.ColorTranslator.ToHtml(Param.BackgroundStarted).Trim();
		}

		private string statusStyleName(ParagraphStatus ParagraphStatus)
		{
			return "stPar" + ParagraphStatus.ToString();
		}
		private string statusStyleHighlightedName(ParagraphStatus ParagraphStatus)
		{
			return "stParHigh" + ParagraphStatus.ToString();
		}

		/// <summary>
		/// Calculate the text direction for a translation
		/// </summary>
		/// <param name="translation"></param>
		/// <returns></returns>
		private string TextDirection(Translation translation)
		{
			return translation.RightToLeft ? " dir=\"rtl\" " : "dir=\"ltr\"";
		}


		#endregion


		#region Html Start and End
		private void pageStart(StringBuilder sb, int paperNo, bool compareStyles = false)
		{
			sb.AppendLine("<HTML>");
			sb.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1252\">");
			sb.AppendLine("<title>Paper " + paperNo.ToString() + "</title>");
			javaScript(sb);
			Styles(sb);
			sb.AppendLine("<BODY>");
		}

		private void pageEnd(StringBuilder sb)
		{
			sb.AppendLine("</BODY>");
			sb.AppendLine("</HTML>");
		}

		#endregion

		private Translation GetParagraphTranslation(Paragraph p)
		{
			if (p.TranslationId == Param.TranslationIdMiddle)
			{
				return Param.TranslationMiddle;
			}

			if (p.TranslationId == Param.TranslationIdLeft)
			{
				return Param.TranslationLeft;
			}
			return Param.TranslationRight;
		}

        #region Working with DIV's
        private string DivName(Paragraph p)
		{
			string divLetter = "";
			if (p.TranslationId == Param.TranslationIdMiddle)
			{
				divLetter = "m";
			}
			else if (p.TranslationId == Param.TranslationIdLeft)
			{
				divLetter = "l";
			}
			else if (p.TranslationId == Param.TranslationIdRight)
			{
				divLetter = "r";
			}
			else
			{
				divLetter = "c";
			}
			return $"div{divLetter}{p.ParaIdent}";
		}


		private string makeDIV(Paragraph p, bool selected= false)
		{
			string TextClass = (selected) ? "class=\"" + statusStyleHighlightedName(p.Status) + "\"" : "class=\"" + statusStyleName(p.Status) + "\"";
			string textDirection = TextDirection(GetParagraphTranslation(p));

			// Define div name
			string openStyle = "", closeStyle = "";
			switch (p.Format)
			{
				case ParagraphHtmlType.BookTitle:
					openStyle = "<h1>";
					closeStyle = "</h1>";
					break;
				case ParagraphHtmlType.PaperTitle:
					openStyle = "<h2>";
					closeStyle = "</h2>";
					break;
				case ParagraphHtmlType.SectionTitle:
					openStyle = "<h3>";
					closeStyle = "</h3>";
					break;
				case ParagraphHtmlType.NormalParagraph:
					openStyle = $"<p>{p.Identification}";
					closeStyle = "</p>";
					break;
				case ParagraphHtmlType.IdentedParagraph:
					openStyle = $"<p><bloquote>{p.Identification}";
					closeStyle = "</bloquote></p>";
					break;
			}

			string htmlLink = $"<a href=\"about:ident\" ident=\"{p.Identification}\">{openStyle} {p.Text}</a>";
			// This is a link</a>

			return $"<div id=\"{DivName(p)}\" {textDirection}>{htmlLink}{closeStyle}</div>";
		}
		#endregion


		//private string HtmlCompare(Paragraph p, FullPaperCompareTranslation fullPaperCompareTranslation)
		//{
		//	try
		//	{
		//		Merger merger = null;
		//		switch (fullPaperCompareTranslation)
		//		{
		//			case FullPaperCompareTranslation.Left:
		//				merger = new Merger(p.HtmlTextLeft, p.HtmlTextRight);
		//				break;
		//			case FullPaperCompareTranslation.Middle:
		//				merger = new Merger(p.HtmlTextMiddle, p.HtmlTextRight);
		//				break;
		//			default:
		//				return "";
		//		}
		//		return "<div id=\"divmerge_" + p.ParaIdent + "\" class=\"" + statusStyleName(ParagraphStatus.Started) + "\">" + merger.merge() + "</div>";
		//	}
		//	catch (Exception)
		//	{
		//		return "<div id=\"divmerge_" + p.ParaIdent + "\" class=\"" + statusStyleName(ParagraphStatus.Started) + "\">&nbsp;</div>";
		//	}
		//}


		private string ShowErrorMessage(string Message)
		{
			return "<P>" + Message + "</P>";
		}


		//private void titleLine(StringBuilder sb)
		//{
		//	sb.AppendLine("<div class=\"titleDiv\"><tr>");
		//	sb.AppendLine("<table border=\"1\" width=\"100%\" id=\"table1\" cellspacing=\"4\" cellpadding=\"0\">");

		//	if (percentFullPaperLeftColumn > 0)
		//	{
		//		TranslationToShow trans = User.GetTranslationData(Param.FullPageLeftTranslationId);
		//		if (trans != null)
		//			sb.AppendLine("<td width= \"" + percent.ToString("0.00") + "%\" valign=\"top\">" + trans.Description + "</td>");
		//		else
		//			sb.AppendLine("<td width= \"" + percent.ToString("0.00") + "%\" valign=\"top\">Left Translation</td>");
		//	}

		//	if (percentFullPaperColumnMiddle > 0)
		//	{
		//		percentFullPaperColumnMiddle = 1;
		//		TranslationToShow trans = User.GetTranslationData(Param.FullPageMiddleTranslationId);
		//		if (trans != null)
		//			sb.AppendLine("<td width= \"" + percent.ToString("0.00") + "%\" valign=\"top\">" + trans.Description + "</td>");
		//		else
		//			sb.AppendLine("<td width= \"" + percent.ToString("0.00") + "%\" valign=\"top\">Middle Translation</td>");
		//	}

		//	if (percentFullPaperColumnRight > 0)
		//		sb.AppendLine("<td width= \"" + percent.ToString("0.00") + "%\" valign=\"top\">Working text</td>");

		//	if (percentColumnMerge > 0)
		//		sb.AppendLine("<td width= \"" + percent.ToString("0.00") + "%\" valign=\"top\">Compare</td>");

		//	sb.AppendLine("</tr></table></div>");
		//}


		//private void formatFullPageLine(Paragraph p, StringBuilder sb, FullPaperCompareTranslation fullPaperCompareTranslation)
		//{
		//	sb.AppendLine("<tr>");
		//	if (percentFullPaperLeftColumn > 0)
		//		sb.AppendLine("<td width= \"" + percent.ToString("0.00") + "%\" valign=\"top\">" + makeLeftDIV(p) + "</td>");

		//	if (percentFullPaperColumnMiddle > 0)
		//		sb.AppendLine("<td width= \"" + percent.ToString("0.00") + "%\" valign=\"top\">" + makeMiddleDIV(p, false) + "</td>");

		//	if (percentFullPaperColumnRight > 0)
		//		sb.AppendLine("<td width= \"" + percent.ToString("0.00") + "%\" valign=\"top\">" + makeRightDIV(p, false) + "</td>");

		//	if (percentColumnMerge > 0)
		//		sb.AppendLine("<td width= \"" + percent.ToString("0.00") + "%\" valign=\"top\">" + HtmlCompare(p, fullPaperCompareTranslation) + "</td>");

		//	sb.AppendLine("</tr>");
		//}

		//private string PlainText(SearchDataResult s)
		//{
		//	var document = new HtmlDocument();
		//	document.LoadHtml(s.Text);
		//	return HtmlEntity.DeEntitize(document.DocumentNode.InnerText);
		//}


		//private void formatSearchPageLine(SearchDataResult s, StringBuilder sb)
		//{
		//	string HtmlLink = "<a target=\"_blank\" href=\"about:blank\" id=\"" + s.ParaIdent + "\">" + s.Identification + " " + PlainText(s) + "</a>";
		//	sb.AppendLine("<li>" + HtmlLink + "</li> ");
		//}



		//private void GenerateFullWorkHtmlPage(List<Paragraph> workFullPageParagraphs, FullPaperCompareTranslation fullPaperCompareTranslation)
		//{
		//	// Shows up to 4 columns paper document
		//	CalcColumnsSize();
		//	StringBuilder sb = new StringBuilder();
		//	try
		//	{
		//		pageStart(sb, Param.PaperId);
		//		titleLine(sb);
		//		sb.AppendLine("<table border=\"1\" width=\"100%\" id=\"table1\" cellspacing=\"4\" cellpadding=\"0\">");

		//		foreach (Paragraph p in workFullPageParagraphs)
		//			formatFullPageLine(p, sb, fullPaperCompareTranslation);

		//		sb.AppendLine("</table>");
		//		pageEnd(sb);

		//		HtmlPage = sb.ToString();
		//	}
		//	catch (Exception ex)
		//	{
		//		HtmlPage = ShowErrorMessage(ex.Message);
		//	}
		//}


		//private void GenerateSearchHtmlPage(List<SearchDataResult> searchdataResults)
		//{
		//	// Shows up to 4 columns paper document
		//	CalcColumnsSize();
		//	StringBuilder sb = new StringBuilder();
		//	try
		//	{
		//		pageStart(sb, Param.PaperId);
		//		sb.AppendLine("<p><b>Query results:</b></p>");
		//		sb.AppendLine("<ol>");
		//		foreach (SearchDataResult s in searchdataResults)
		//			formatSearchPageLine(s, sb);
		//		sb.AppendLine("</ol>");
		//		pageEnd(sb);

		//		HtmlPage = sb.ToString();
		//	}
		//	catch (Exception ex)
		//	{
		//		HtmlPage = ShowErrorMessage(ex.Message);
		//	}

		//}


		//public virtual bool Format(List<Paragraph> workFullPageParagraphs, FullPaperCompareTranslation fullPaperCompareTranslation)
		//{
		//	if (workFullPageParagraphs == null)
		//	{
		//		return false;
		//	}
		//	try
		//	{
		//		GenerateFullWorkHtmlPage(workFullPageParagraphs, fullPaperCompareTranslation);
		//		return true;
		//	}
		//	catch (Exception ex)
		//	{
		//		HtmlPage = ShowErrorMessage(ex.Message);
		//		return false;
		//	}
		//}

		//public bool FormatSearchHtmlPaper(List<SearchDataResult> searchdataResults)
		//{
		//	try
		//	{
		//		GenerateSearchHtmlPage(searchdataResults);
		//		return true;
		//	}
		//	catch (Exception ex)
		//	{
		//		HtmlPage = ShowErrorMessage(ex.Message);
		//		return false;
		//	}
		//}

		//public bool FormatComparePage(List<Paragraph> workFullPageParagraphs)
		//{
		//	if (workFullPageParagraphs == null)
		//	{
		//		return false;
		//	}
		//	try
		//	{
		//		GenerateComparePage(workFullPageParagraphs);
		//		return true;
		//	}
		//	catch (Exception ex)
		//	{
		//		HtmlPage = ShowErrorMessage(ex.Message);
		//		return false;
		//	}
		//}


		#region Private format routines
		private void HtmlFomatPage(StringBuilder sb, short paperNo, List<Paragraph> rightTranslation, List<Paragraph> middleTranslation = null, List<Paragraph> leftTranslation = null, bool showCompare = false)
		{
			try
			{
				pageStart(sb, paperNo, true);
				//titleLine(sb);
				sb.AppendLine("<table border=\"1\" width=\"100%\" id=\"table1\" cellspacing=\"4\" cellpadding=\"0\">");

				for (int i = 0; i < rightTranslation.Count; i++)
				{
					sb.AppendLine("<tr>");
					sb.AppendLine("<td width= \"" + percent.ToString("0.00") + "%\" valign=\"top\">" + makeDIV(rightTranslation[i]) + "</td>");
					if (middleTranslation != null)
					{
						sb.AppendLine("<td width= \"" + percent.ToString("0.00") + "%\" valign=\"top\">" + makeDIV(middleTranslation[i]) + "</td>");
					}
					if (leftTranslation != null)
					{
						sb.AppendLine("<td width= \"" + percent.ToString("0.00") + "%\" valign=\"top\">" + makeDIV(leftTranslation[i]) + "</td>");
					}
					if (showCompare)
					{
						//sb.AppendLine("<td width= \"" + percent.ToString("0.00") + "%\" valign=\"top\">" + HtmlCompare(p, FullPaperCompareTranslation.Middle) + "</td>");
					}
					sb.AppendLine("</tr>");
				}

				sb.AppendLine("</table>");
				pageEnd(sb);

			}
			catch (Exception ex)
			{
				sb.AppendLine(ShowErrorMessage(ex.Message));
			}
		}


		/// <summary>
		/// Calculate the number of columns as a poercent to split the page
		/// </summary>
		/// <param name="rightTranslation"></param>
		/// <param name="middleTranslation"></param>
		/// <param name="leftTranslation"></param>
		/// <param name="showCompare"></param>
		private void CalcColumnsSize(List<Paragraph> rightTranslation, List<Paragraph> middleTranslation = null, List<Paragraph> leftTranslation = null, bool showCompare = false)
		{

			int fator = 1;
			if (middleTranslation != null)
			{
				fator++;
			}

			if (leftTranslation != null)
			{
				fator++;
			}

			if (showCompare)
			{
				fator++;
			}
			percent = 100.0 / fator;
		}
        #endregion


        //public void FormatPageWithErrorMessage(string message)
        //{
        //	StringBuilder sb = new StringBuilder();
        //	pageStart(sb, Param.PaperId);
        //	sb.AppendLine("<p><b>" + message + "</b></p>");
        //	pageEnd(sb);
        //	HtmlPage = sb.ToString();
        //}

        public string FormatPaper(short paperNo, List<Paragraph> rightTranslation, List<Paragraph> middleTranslation = null, List<Paragraph> leftTranslation = null, bool showCompare = false)
		{
			CalcColumnsSize(rightTranslation, middleTranslation, leftTranslation, showCompare);
			StringBuilder sb = new StringBuilder();
			pageStart(sb, paperNo);

			HtmlFomatPage(sb, paperNo, rightTranslation, middleTranslation, leftTranslation, showCompare);

			pageEnd(sb);
			return sb.ToString();
		}




	}
}
