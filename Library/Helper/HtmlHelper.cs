using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Collections.Generic;

using Sgml;

namespace VmgPortal.Library.Helper
{
	/// <summary>
	/// Descrizione di riepilogo per HtmlHelper.
	/// </summary>
	public class HtmlHelper
	{
		public static string FilterHtml(string orig)
		{
			string html = orig.Trim();
			if (html.ToUpper() == "&NBSP;")
			{
				html = string.Empty;
				return html;
			}

			html = html.Replace("&nbsp; ", " ");
			html = html.Replace("&ndash;", "-");
			html = html.Replace("&rsquo;", "'");
			html = html.Replace("&lsquo;", "'");
			html = html.Replace("&ldquo;", "\"");
			html = html.Replace("&rdquo;", "\"");

			return html;
		}
		static public string ToXhtml(string html)
		{
			SgmlReader reader = new SgmlReader();
			reader.CaseFolding = CaseFolding.ToLower;
			reader.DocType = "HTML";
			reader.InputStream = new StringReader(html);

			StringWriter sw = new StringWriter();
			XmlTextWriter writer = new XmlTextWriter(sw);
			writer.Formatting = Formatting.Indented;
			reader.WhitespaceHandling = WhitespaceHandling.None;
			while (!reader.EOF)
			{
				writer.WriteNode(reader, true);
			}
			writer.Close();
			return sw.ToString();
		}

		static public string ReplaceEntities(string text)
		{
			string res = text.Replace("è", "&#232;");
			res = text.Replace("é", "&#233;");
			return res;
		}

		static public string HtmlSubstr(string htmlString, int maxLength)
		{
			bool isText = true;
			StringBuilder r = new StringBuilder();
			int i = 0;

			char currentChar = ' ';
			int lastSpacePosition = -1;
			char lastChar = ' ';

			//			var tagsArray = new Array();
			Dictionary<int, string> tagsArray = new Dictionary<int, string>();
			string currentTag = "";
			int tagLevel = 0;

			int noTagLength = 0;
			int j = 0;

			// Calculate string length without tags
			for (j = 0; j < htmlString.Length; j++)
			{
				currentChar = htmlString[j];
				if (currentChar == '<')
				{
					isText = false;
				}
				if (isText)
				{
					noTagLength++;
				}
				if (currentChar == '>')
				{
					isText = true;
				}
			}

			// Parser loop
			for (j = 0; j < htmlString.Length; j++)
			{
				currentChar = htmlString[j];
				r.Append(currentChar);

				// Lesser than event
				if (currentChar == '<')
				{
					isText = false;
				}

				// Character handler
				if (isText)
				{
					// Memorize last space position
					if (currentChar == ' ')
					{
						lastSpacePosition = j;
					}
					else
					{
						lastChar = currentChar;
					}
					i++;
				}
				else
				{
					currentTag += currentChar;
				}

				// Greater than event
				if (currentChar == '>')
				{
					isText = true;

					// Opening tag handler
					if (currentTag.IndexOf("<") != -1 && currentTag.IndexOf("/>") == -1 && currentTag.IndexOf("</") == -1)
					{

						// Tag has attribute(s)
						if (currentTag.IndexOf(" ") != -1)
						{
							currentTag = currentTag.Substring(1, currentTag.IndexOf(" ") - 1);
						}
						else
						{
							// Tag doesn't have attribute(s)
							currentTag = currentTag.Substring(1, currentTag.Length - 2);
						}

						tagsArray[tagLevel] = currentTag;
						tagLevel++;

					}
					else if (currentTag.IndexOf("</") != -1)
					{

						// Closing tag handler
						tagsArray[tagLevel - 1] = null;
						tagLevel--;
					}

					currentTag = "";
				}

				if (i == maxLength) { break; }
			}

			// Cut HTML string at last space position
			if (maxLength < noTagLength)
			{
				if (lastSpacePosition != -1)
				{
					r = new StringBuilder(htmlString.Substring(0, lastSpacePosition));
				}
				else
				{
					r = new StringBuilder(htmlString.Substring(0, j));
				}
			}

			// Close broken XHTML elements
			for (int a = tagsArray.Count - 1; a >= 0; a--)
			{
				if (tagsArray[a] != null)
				{
					r.Append("</" + tagsArray[a] + ">");
				}
			}

			if (maxLength < noTagLength)
			{
				if (lastChar != '.')
				{
					r.Append("...");
				}
				else
				{
					r.Append("..");
				}
			}

			return r.ToString();
        }
        static public string RemoveHTML(string html)
        {
            // Use Regular Expression to remove HTML Tags
            return Regex.Replace(html, @"<(.|\n)*?>", "");
        }

	}
}
