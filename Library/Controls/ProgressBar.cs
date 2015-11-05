using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VmgPortal.Library.Controls
{
	public class ProgressBar : WebControl
	{
		private int percentage = 0;
		private int cellCount = 20;
		private string fillImageUrl = "";
		private string barImageUrl = "";
		private string imageGeneratorUrl = "";


		public ProgressBar()
		{
			// Set up some defaults
			//
			BackColor = Color.LightGray;
			ForeColor = Color.Blue;
			BorderColor = Color.Empty;

			base.Width = Unit.Pixel(100);
			base.Height = Unit.Pixel(16);
		}

		public int PercentageStep
		{
			get { return 100 / cellCount; }

			set
			{
				if ((100 % value) != 0)
				{
					throw new ArgumentException("The percentage step value must be divisible by 100");
				}

				cellCount = 100 / value;
			}
		}

		public string FillImageUrl
		{
			get { return fillImageUrl; }
			set { fillImageUrl = value; }

		}

		public string BarImageUrl
		{
			get { return barImageUrl; }
			set { barImageUrl = value; }
		}

		public string ImageGeneratorUrl
		{
			get { return imageGeneratorUrl; }
			set { imageGeneratorUrl = value; }
		}


		// Set the percentage of progress
		//
		public int Percentage
		{
			get { return percentage; }

			set
			{
				// Ensure it falls in the correct bounds
				//
				if (value > 100) // Greater than 100 is still 100
				{
					percentage = 100;
				}
				else if (value < 0) // Less than 0 is stil 0
				{
					percentage = 0;
				}
				else
				{
					percentage = value;
				}
			}
		}

		// Render the progress bar
		//
		protected override void Render(HtmlTextWriter output)
		{
			if (Width.Type != UnitType.Pixel)
				throw new ArgumentException("The width must be in pixels");

			int width = (int)Width.Value;

			if (ImageGeneratorUrl != "")
			{
				// a image generate on the fly
				string borderColor = "";
				if (BorderColor != Color.Empty)
					borderColor = "&bc=" + ColorTranslator.ToHtml(BorderColor);

				output.Write(string.Format("<img src='{0}?w={1}&h={2}&p={3}&fc={4}&bk={5}{6}' border='0' width='{1}' height='{2}'>",
																	 ImageGeneratorUrl,
																	 width,
																	 Height.ToString(),
																	 Percentage,
																	 ColorTranslator.ToHtml(ForeColor),
																	 ColorTranslator.ToHtml(BackColor),
																	 borderColor));


			}
			else
			{
				// border ??
				if (BorderColor != Color.Empty)
				{
					output.Write("<table border='0' cellspacing='0' cellpadding='1' bgColor='" +
						ColorTranslator.ToHtml(BorderColor) + "'><tr><td>");
				}

				if (BarImageUrl == "")
				{
					// We render a table
					//
					output.Write("<table border='0' cellspacing='0' cellpadding='0' height='" + Height + "' bgColor='" + ColorTranslator.ToHtml(BackColor) + "'><tr>");

					int cellWidth = width / cellCount;
					int curPercentage = 0;
					int percentageStep = PercentageStep;
					string cellColor;

					string cellValue = "";
					if (Page.Request.Browser.Browser.ToUpper() == "NETSCAPE")
					{
						if (FillImageUrl != "")
						{
							cellValue = "<img src='" + FillImageUrl + "' border='0' width='" + cellWidth + "'>";
						}
						else
						{
							cellValue = "&nbsp;";
						}
					}


					// Create the cells
					for (int i = 0; i < cellCount; i++, curPercentage += percentageStep)
					{
						if (curPercentage < percentage)
						{
							cellColor = " bgColor='" + ColorTranslator.ToHtml(ForeColor) + "'";
						}
						else
						{
							cellColor = "";
						}


						if (i == 0)
						{
							output.Write("<td height='" + Height + "' width='" + cellWidth + "'" + cellColor + ">" + cellValue + "</td>");
						}
						else
						{
							output.Write("<td width='" + cellWidth + "'" + cellColor + ">" + cellValue + "</td>");
						}
					}

					output.Write("</tr></table>");

				}
				else
				{
					// Use a image as the bar 
					int imageWidth = (int)((percentage / 100.0) * width);

					output.Write("<table border='0' cellpadding='0' cellSpacing='0' bgColor='" + ColorTranslator.ToHtml(BackColor) + "'><tr><td width='" + width + "'>");
					output.Write("<img src='" + BarImageUrl + "' width='" + imageWidth + "' height='" + Height + "'>");
					output.Write("</td></tr></table>");
				}

				if (BorderColor != Color.Empty)
				{
					output.Write("</td></tr></table>");
				}
			}

		}
	}
}
