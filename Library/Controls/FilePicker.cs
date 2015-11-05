using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace VmgPortal.Library.Controls
{
	[ToolboxData("<{0}:FilePicker runat=\"server\"></{0}:FilePicker>")]
	public class FilePicker : TextBox, INamingContainer
	{
		// Fields
		private bool _AllowCreateDirs = true;
		private bool _AllowDelete = true;
		private string _AllowedUploadFileExts = "gif,jpg,jpeg,png,bmp";
		private bool _AllowRename = true;
		private bool _AllowUpload = true;
		private bool _CheckImage = false;
		private long _FileSizeLimit;
		private string _hTextBoxID = "";
		private HyperLink _HyperLink = null;
		private int _ImageHeightLimit = 0;
		private int _ImageLeftOffset = 1;
		private int _ImageTopOffset = 2;
		private string _ImageURL = "/Images/Icons/Browse.gif";
		private int _ImageWidthLimit = 0;
		private int _PopupHeight = 500;
		private int _PopupLeftOffset = 0;
		private int _PopupTopOffset = -75;
		private string _PopupURL = "/Controls/FilePicker.aspx";
		private int _PopupWidth = 450;
		private bool _ShowImageAsIcon;
		private int _TotalSizeLimit = 0;
		private string _UploadDir = "/Uploaded";
		private bool _UseAppRelPath = true;
		private string _wTextBoxID = "";
		protected bool IsInDesignMode = false;

		// Methods
		protected override void CreateChildControls()
		{
			this._HyperLink = new HyperLink();
			this._HyperLink.EnableViewState = false;
			this.Controls.Add(this._HyperLink);
			string clientID = this._HyperLink.ClientID;
			this._HyperLink.Attributes["ID"] = clientID;
		}

		protected override void OnPreRender(EventArgs e)
		{
			HttpContext.Current.Session[this.ClientID + "fpUploadDir"] = this._UploadDir;
			HttpContext.Current.Session[this.ClientID + "fpAllowUpload"] = this._AllowUpload;
			HttpContext.Current.Session[this.ClientID + "fpAllowCreateDirs"] = this._AllowCreateDirs;
			HttpContext.Current.Session[this.ClientID + "fpAllowDelete"] = this._AllowDelete;
			HttpContext.Current.Session[this.ClientID + "fpAllowRename"] = this._AllowRename;
			HttpContext.Current.Session[this.ClientID + "fpCheckImage"] = this._CheckImage;
			HttpContext.Current.Session[this.ClientID + "fpImageHeightLimit"] = this._ImageHeightLimit;
			HttpContext.Current.Session[this.ClientID + "fpImageWidthLimit"] = this._ImageWidthLimit;
			HttpContext.Current.Session[this.ClientID + "fpTotalSizeLimit"] = this._TotalSizeLimit;
			HttpContext.Current.Session[this.ClientID + "fpShowImageAsIcon"] = this._ShowImageAsIcon;
			HttpContext.Current.Session[this.ClientID + "fpAllowedUploadFileExts"] = this._AllowedUploadFileExts;
			HttpContext.Current.Session[this.ClientID + "fpFileSizeLimit"] = this._FileSizeLimit;
			HttpContext.Current.Session[this.ClientID + "fpUseAppRelPath"] = this._UseAppRelPath;
			this._HyperLink.Visible = this.Visible;
			if (this._HyperLink.Visible)
			{
				Image child = new Image();
				child.ImageUrl = this._ImageURL;
				child.ToolTip = "...";
				child.Style["POSITION"] = "relative";
				child.Style["TOP"] = this._ImageTopOffset.ToString() + "px";
				child.Style["LEFT"] = this._ImageLeftOffset.ToString() + "px";
				this._HyperLink.Enabled = this.Enabled;
				child.Enabled = this.Enabled;
				this._HyperLink.Controls.Add(child);
			}
			if (!this.IsInDesignMode)
			{
				this.RegisterPopupScript();
				this._HyperLink.NavigateUrl = "javascript:PopupWindow('" + this.ClientID + "', '" + this._wTextBoxID + "', '" + this._hTextBoxID + "', '" + this._HyperLink.ClientID + "');";
				this.RegisterGetAttribute();
				base.Attributes["Custom_PopupWidth"] = this._PopupWidth.ToString();
				base.Attributes["Custom_PopupHeight"] = this._PopupHeight.ToString();
				base.Attributes["Custom_PopupPath"] = this._PopupURL;
				base.Attributes["Custom_PopupTopOffset"] = this._PopupTopOffset.ToString();
				base.Attributes["Custom_PopupLeftOffset"] = this._PopupLeftOffset.ToString();
			}
		}

		protected void RegisterGetAttribute()
		{
			if (!this.Page.IsClientScriptBlockRegistered("GetAttribute"))
			{
				StringBuilder builder = new StringBuilder(0x3e8);
				builder.Append("<script language=javascript>\n");
				builder.Append("function GetAttribute(pElement, pAttributeName, pDefaultValue) \n");
				builder.Append("{\n");
				builder.Append("  var vResult = pElement.getAttribute(pAttributeName, 0);\n");
				builder.Append("\tif (vResult == null)\n");
				builder.Append("\t\tvResult = pDefaultValue; \n");
				builder.Append("  return vResult; \n");
				builder.Append("} // GetAttribute()\n\n");
				builder.Append("</script>\n");
				this.Page.RegisterClientScriptBlock("GetAttribute", builder.ToString());
			}
		}

		protected void RegisterPopupScript()
		{
			if (!this.Page.IsClientScriptBlockRegistered("SetupPopup"))
			{
				StringBuilder builder = new StringBuilder(0x7d0);
				builder.Append("<script language=javascript>\n");
				builder.Append("function PopupWindow(pTextBoxID,pwTextBoxID,phTextBoxID,pButtonID) \n");
				builder.Append("{\n");
				builder.Append("  var vTextBox = document.getElementById(pTextBoxID);\n");
				builder.Append("  var vFileName;\n");
				builder.Append("  var vButton = document.getElementById(pButtonID);\n");
				builder.Append("  var vTopPos = 0;\n");
				builder.Append("  var vLeftPos = 0;\n");
				builder.Append("  var vScreenWidth;\n   var vScreenHeight;\n");
				builder.Append("  var vPopupWidth = eval(GetAttribute(vTextBox, 'Custom_PopupWidth', 136));\n");
				builder.Append("  var vPopupHeight = eval(GetAttribute(vTextBox, 'Custom_PopupHeight', 138));\n");
				builder.Append("  if ((document.all != null) && (window.screenTop != null)) // IE except Mac\n");
				builder.Append("  {\n");
				builder.Append("    vScreenWidth = screen.availWidth;\n    vScreenHeight = screen.availHeight;\n");
				builder.Append("    if (vButton != null)\n");
				builder.Append("    {\n");
				builder.Append("       vTopPos = vButton.offsetTop - document.body.scrollTop + window.screenTop;\n");
				builder.Append("       vLeftPos = vButton.offsetLeft - document.body.scrollLeft + window.screenLeft;\n");
				builder.Append("       vParent = vButton.offsetParent;\n");
				builder.Append("    }\n");
				builder.Append("    else // no Browse button. Position to the right of the edit box. \n");
				builder.Append("    {\n");
				builder.Append("       vTopPos = vTextBox.offsetTop - document.body.scrollTop + window.screenTop;\n");
				builder.Append("       vLeftPos = vTextBox.offsetLeft + vTextBox.offsetWidth - document.body.scrollLeft + window.screenLeft;\n");
				builder.Append("       vParent = vTextBox.offsetParent;\n");
				builder.Append("    }\n");
				builder.Append("    while (vParent != null)\n");
				builder.Append("    {\n");
				builder.Append("       vTopPos = vTopPos + vParent.offsetTop;\n");
				builder.Append("       vLeftPos = vLeftPos + vParent.offsetLeft;\n");
				builder.Append("       vParent = vParent.offsetParent;\n");
				builder.Append("    }\n");
				builder.Append("    vTopPos = vTopPos + eval(GetAttribute(vTextBox, 'Custom_PopupTopOffset', -75));\n");
				builder.Append("    vLeftPos = vLeftPos + eval(GetAttribute(vTextBox, 'Custom_PopupLeftOffset', 0));\n");
				builder.Append("  // if offscreen, shift left or up\n");
				builder.Append("    if (vLeftPos + vPopupWidth > vScreenWidth)\n");
				builder.Append("       vLeftPos = vScreenWidth - vPopupWidth;\n");
				builder.Append("    if (vTopPos + vPopupHeight > vScreenHeight)\n");
				builder.Append("       vTopPos = vScreenHeight - vPopupHeight;\n");
				builder.Append("  }\n   else  // Netscape and IE Mac \n");
				builder.Append("  {\n");
				builder.Append("    vTopPos = (window.screen.availHeight - vPopupHeight) / 2;\n");
				builder.Append("    vLeftPos =(window.screen.availWidth - vPopupWidth) / 2;\n");
				builder.Append("  }\n");
				builder.Append("  var vValueParam = '';\n");
				builder.Append("  if (vTextBox.value != '')\n");
				builder.Append("    vValueParam = '&value=' + vTextBox.value.toString();\n");
				builder.Append("  var vPopupPath = GetAttribute(vTextBox, 'Custom_PopupPath', 'FilePicker.aspx');\n");
				builder.Append("  fp_window=window.open(vPopupPath+ '?TextBoxID=");
				builder.Append("' + pTextBoxID + '&wTextBoxID=' + pwTextBoxID + '&hTextBoxID=' + phTextBoxID + vValueParam,\n");
				builder.Append("  'fp_window','top='+vTopPos+', left='+vLeftPos+', width='+vPopupWidth+',height='+vPopupHeight+'");
				builder.Append(",menubar=no,resizable=yes,scrollbars=yes,toolbar=no,location=no');\n");
				builder.Append("  fp_window.focus();\n");
				builder.Append("} // PopupWindow()\n\n");
				builder.Append("</script>\n");
				this.Page.RegisterClientScriptBlock("SetupPopup", builder.ToString());
			}
		}

		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);
			this.RenderChildren(writer);
		}

		// Properties
		[Category("Data"), Bindable(true), Description("Selected file name.")]
		public string FileName
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		[Description("Whether allow user to create directories."), DefaultValue(true), Category("Behavior")]
		public bool fpAllowCreateDirs
		{
			get
			{
				return this._AllowCreateDirs;
			}
			set
			{
				this._AllowCreateDirs = value;
			}
		}

		[Category("Behavior"), Description("Whether allow user to delete files and directories."), DefaultValue(true)]
		public bool fpAllowDelete
		{
			get
			{
				return this._AllowDelete;
			}
			set
			{
				this._AllowDelete = value;
			}
		}

		[Description("File extensions allowed for upload (delimited with comma)."), DefaultValue("gif,jpg,jpeg,png,bmp"), Category("Behavior")]
		public string fpAllowedUploadFileExts
		{
			get
			{
				return this._AllowedUploadFileExts;
			}
			set
			{
				this._AllowedUploadFileExts = value;
			}
		}

		[Category("Behavior"), DefaultValue(true), Description("Whether allow user to rename files and directories.")]
		public bool fpAllowRename
		{
			get
			{
				return this._AllowRename;
			}
			set
			{
				this._AllowRename = value;
			}
		}

		[Category("Behavior"), Description("Whether allow user to upload files or not."), DefaultValue(true)]
		public bool fpAllowUpload
		{
			get
			{
				return this._AllowUpload;
			}
			set
			{
				this._AllowUpload = value;
			}
		}

		[Category("Behavior"), Description("Check for real image file."), DefaultValue(false)]
		public bool fpCheckImage
		{
			get
			{
				return this._CheckImage;
			}
			set
			{
				this._CheckImage = value;
			}
		}

		[Description("If set, restricts size of files that can be uploaded (in bytes)."), DefaultValue(false), Category("Behavior")]
		public long fpFileSizeLimit
		{
			get
			{
				return this._FileSizeLimit;
			}
			set
			{
				this._FileSizeLimit = value;
			}
		}

		[Category("Behavior"), Description("Check image height limitation."), DefaultValue(0)]
		public int fpImageHeightLimit
		{
			get
			{
				return this._ImageHeightLimit;
			}
			set
			{
				this._ImageHeightLimit = value;
			}
		}

		[Description("Shifts the left edge of the image button."), DefaultValue(1), Category("Appearance")]
		public int fpImageLeftOffset
		{
			get
			{
				return this._ImageLeftOffset;
			}
			set
			{
				this._ImageLeftOffset = value;
			}
		}

		[DefaultValue(2), Description("Shifts the top edge of the image button."), Category("Appearance")]
		public int fpImageTopOffset
		{
			get
			{
				return this._ImageTopOffset;
			}
			set
			{
				this._ImageTopOffset = value;
			}
		}

		[DefaultValue("/Images/Icons/Browse.gif"), Description("The URL of the image shown to the right of the edit box."), Editor(typeof(ImageUrlEditor), typeof(UITypeEditor)), Category("Behavior")]
		public string fpImageURL
		{
			get
			{
				return this._ImageURL;
			}
			set
			{
				this._ImageURL = value;
			}
		}

		[Category("Behavior"), DefaultValue(0), Description("Check image width limitation.")]
		public int fpImageWidthLimit
		{
			get
			{
				return this._ImageWidthLimit;
			}
			set
			{
				this._ImageWidthLimit = value;
			}
		}

		[Description("The height of the popup window in pixels."), Category("Appearance"), DefaultValue(500)]
		public int fpPopupHeight
		{
			get
			{
				return this._PopupHeight;
			}
			set
			{
				this._PopupHeight = value;
			}
		}

		[DefaultValue(0), Description("Shifts the initial left position of the select file dialog. (IE Browsers only.)"), Category("Appearance")]
		public int fpPopupLeftOffset
		{
			get
			{
				return this._PopupLeftOffset;
			}
			set
			{
				this._PopupLeftOffset = value;
			}
		}

		[Category("Appearance"), Description("Shifts the initial top position of the popup the select file dialog. (IE Browsers only.)"), DefaultValue(-75)]
		public int fpPopupTopOffset
		{
			get
			{
				return this._PopupTopOffset;
			}
			set
			{
				this._PopupTopOffset = value;
			}
		}

		[Description("The URL of the file opened within the popup window."), Editor(typeof(UrlEditor), typeof(UITypeEditor)), DefaultValue("/Controls/FilePicker.aspx"), Category("Behavior")]
		public string fpPopupURL
		{
			get
			{
				return this._PopupURL;
			}
			set
			{
				this._PopupURL = value;
			}
		}

		[Description("The width of the popup window in pixels."), DefaultValue(450), Category("Appearance")]
		public int fpPopupWidth
		{
			get
			{
				return this._PopupWidth;
			}
			set
			{
				this._PopupWidth = value;
			}
		}

		[Category("Behavior"), DefaultValue(false), Description("Show image as icon.")]
		public bool fpShowImageAsIcon
		{
			get
			{
				return this._ShowImageAsIcon;
			}
			set
			{
				this._ShowImageAsIcon = value;
			}
		}

		[DefaultValue(0), Category("Behavior"), Description("Max total size of uploaded files.")]
		public int fpTotalSizeLimit
		{
			get
			{
				return this._TotalSizeLimit;
			}
			set
			{
				this._TotalSizeLimit = value;
			}
		}

		[DefaultValue("~/Uploaded/"), Description("Base directory for uploaded files."), Editor(typeof(UrlEditor), typeof(UITypeEditor)), Category("Behavior")]
		public string fpUploadDir
		{
			get
			{
				return this._UploadDir;
			}
			set
			{
				this._UploadDir = value;
			}
		}

		[Description("Specifies whether application-relative path (True) or upload directory relative path (False) must be returned. "), Category("Behavior"), DefaultValue(true)]
		public bool fpUseAppRelPath
		{
			get
			{
				return this._UseAppRelPath;
			}
			set
			{
				this._UseAppRelPath = value;
			}
		}

		[Category("Data"), Description("The ID of the Height Text Box."), DefaultValue("")]
		public string HTextBoxID
		{
			get
			{
				return this._hTextBoxID;
			}
			set
			{
				this._hTextBoxID = value;
			}
		}

		[Browsable(false)]
		public override int Rows
		{
			get
			{
				return base.Rows;
			}
		}

		[Browsable(false)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		[Browsable(false)]
		public override TextBoxMode TextMode
		{
			get
			{
				return TextBoxMode.SingleLine;
			}
		}

		[Browsable(false)]
		public override bool Wrap
		{
			get
			{
				return base.Wrap;
			}
			set
			{
				base.Wrap = true;
			}
		}

		[Description("The ID of the Width Text Box."), DefaultValue(""), Category("Data")]
		public string WTextBoxID
		{
			get
			{
				return this._wTextBoxID;
			}
			set
			{
				this._wTextBoxID = value;
			}
		}
	}


}

