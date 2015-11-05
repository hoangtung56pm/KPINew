using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using VmgPortal.Library.Components.Security;
using Image=System.Drawing.Image;

namespace VmgPortal.Administrator.Controls
{
    public partial class FilePicker : AdminPage
    {
        // Fields
        private bool _AllowCreateDirs = true;
        private bool _AllowDelete = true;
        private bool _AllowRename = true;
        private bool _AllowUpload = true;
        private bool _CheckImage = false;
        private int _ImageHeightLimit = 0;
        private int _ImageWidthLimit = 0;
        private bool _ShowImageAsIcon = false;
        private int _TotalSizeLimit = 0;
        private string _UploadDir = "";
        private bool _UseAppRelPath = true;
        private string FPTextBoxID = "";

        protected Image imgFSObject;

        protected TextBox setRootTxt;


        // Methods
        private string AddSlashIfNotExist(string str)
        {
            if (str.LastIndexOf("/") != (str.Length - 1))
            {
                str = str + "/";
            }
            return str;
        }

        private void ChangePath(string Direction)
        {
            if (Direction == "/")
            {
                this.ViewState["fpUploadFolderRelativePath"] = "";
            }
            else if (Direction == "../")
            {
                this.ViewState["fpUploadFolderRelativePath"] = this.getParentDirectory(this.ViewState["fpUploadFolderRelativePath"].ToString());
            }
            else
            {
                this.ViewState["fpUploadFolderRelativePath"] = this.ViewState["fpUploadFolderRelativePath"].ToString() + Direction + "/";
            }
        }

        private string DateFolder()
        {
            //return (DateTime.Now.Year.ToString() + ((DateTime.Now.Month > 9) ? DateTime.Now.Month.ToString() : ("0" + DateTime.Now.Month.ToString())) + ((DateTime.Now.Day > 9) ? DateTime.Now.Day.ToString() : ("0" + DateTime.Now.Day.ToString())));
            return "";
        }

        private void dgFSList_ItemCommand(object sender, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "FSOClick")
            {
                string direction = ((LinkButton)e.Item.FindControl("lbFileName")).Text;
                string width = ((Label)e.Item.FindControl("lblWidth")).Text;
                string height = ((Label)e.Item.FindControl("lblHeight")).Text;
                this.ViewState["fpUploadFolderRelativePath"] = this.AddSlashIfNotExist(this.ViewState["fpUploadFolderRelativePath"].ToString());
                string str = e.Item.Attributes["FSOType"];
                if (str != null)
                {
                    str = string.IsInterned(str);
                    if (str == "Folder")
                    {
                        this.ChangePath(direction);
                        this.showFiles();
                        return;
                    }
                    if (str == "File")
                    {
                        this.SelectFile(this.ViewState["fpUploadFolderRelativePath"].ToString() + direction, width, height);
                    }
                    return;
                }
                return;
            }
            if (!(e.CommandName == "Del"))
            {
                if (e.CommandName == "Rename")
                {
                    this.ViewState["PrevFileFolderName"] = ((LinkButton)e.Item.Cells[1].Controls[1]).Text;
                    this.ViewState["EditItemIndex"] = e.Item.ItemIndex;
                    this.ViewState["FSOType"] = e.Item.Attributes["FSOType"];
                    this.dgFSList.EditItemIndex = e.Item.ItemIndex;
                    this.showFiles();
                    return;
                }
                if (e.CommandName == "Update")
                {
                    string path = ((TextBox)e.Item.Cells[1].Controls[1]).Text;
                    string str6 = this.ViewState["PrevFileFolderName"].ToString();
                    path = this._UploadDir + this.ViewState["fpUploadFolderRelativePath"].ToString() + "/" + path;
                    str6 = this._UploadDir + this.ViewState["fpUploadFolderRelativePath"].ToString() + "/" + str6;
                    path = base.Server.MapPath(path);
                    str6 = base.Server.MapPath(str6);
                    try
                    {
                        switch (this.ViewState["FSOType"].ToString())
                        {
                            case "File":
                                File.Move(str6, path);
                                break;

                            case "Folder":
                                Directory.Move(str6, path);
                                break;
                        }
                    }
                    catch (IOException exception)
                    {
                        this.ReportError("Lỗi khi đổi t\x00ean tệp (thư mục)", "Lỗi: " + exception.Message + ". Kiểm tra xem c\x00f3 tệp (thư mục) n\x00e0o đ\x00e3 tồn tại trước đ\x00f3.", true);
                    }
                    catch (Exception exception2)
                    {
                        this.ReportError("Lỗi khi đổi t\x00ean tệp (thư mục)", "Lỗi: " + exception2.Message + ". H\x00e3y chắc chắn rằng bạn c\x00f3 quyền ghi.", true);
                    }
                    this.dgFSList.EditItemIndex = -1;
                    this.ViewState["EditItemIndex"] = -1;
                    this.showFiles();
                    return;
                }
                if (e.CommandName == "Cancel")
                {
                    this.dgFSList.EditItemIndex = -1;
                    this.ViewState["EditItemIndex"] = -1;
                    this.showFiles();
                }
                return;
            }
            string text = ((LinkButton)e.Item.FindControl("lbFileName")).Text;
            switch (e.Item.Attributes["FSOType"])
            {
                case "File":
                    {
                        FileInfo info = new FileInfo(base.Server.MapPath(this._UploadDir + this.ViewState["fpUploadFolderRelativePath"].ToString() + text));
                        try
                        {
                            info.Delete();
                        }
                        catch
                        {
                            this.ReportError("Kh\x00f4ng thể x\x00f3a file.", "File đang được sử dụng bởi một ứng dụng kh\x00e1c \\nhoặc bạn kh\x00f4ng c\x00f3 đủ quyền với thư mục hoặc ch\x00ednh file n\x00e0y.", true);
                        }
                        break;
                    }
                case "Folder":
                    try
                    {
                        new DirectoryInfo(base.Server.MapPath(this._UploadDir + this.ViewState["fpUploadFolderRelativePath"].ToString() + text)).Delete(true);
                    }
                    catch
                    {
                        this.ReportError("Kh\x00f4ng thể x\x00f3a thư mục.", "H\x00e3y kiểm tra sự tồn tại của thư mục v\x00e0 bạn \\nc\x00f3 quyền ghi cho thư mục đ\x00f3.", true);
                    }
                    goto Label_0222;
            }
        Label_0222:
            this.showFiles();
        }

        private void dgFSList_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
            {
                if (e.Item.ItemType != ListItemType.EditItem)
                {
                    ((LinkButton)e.Item.FindControl("lbFileName")).Text = ((DataRowView)e.Item.DataItem)["FileName"].ToString();
                    ((LinkButton)e.Item.FindControl("imbDel")).Visible = this._AllowDelete;
                    ((LinkButton)e.Item.FindControl("imbRen")).Visible = this._AllowRename;
                    this.ViewState["fpUploadFolderRelativePath"] = this.AddSlashIfNotExist(this.ViewState["fpUploadFolderRelativePath"].ToString());
                    string str2 = this._UploadDir + this.ViewState["fpUploadFolderRelativePath"].ToString() + ((DataRowView)e.Item.DataItem)["FileName"].ToString();
                    ((HyperLink)e.Item.FindControl("hlView")).NavigateUrl = str2;
                    ((HyperLink)e.Item.FindControl("lnkEditImage")).NavigateUrl = "/Controls/ImageEditor.aspx?img=" + str2;
                    LinkButton button = (LinkButton)e.Item.FindControl("imbDel");
                    button.Attributes["onclick"] = "return confirm('Do you want to proceed?');";
                }
                ((Label)e.Item.FindControl("lbModified")).Text = ((DataRowView)e.Item.DataItem)["Modified"].ToString();
                ((Label)e.Item.FindControl("lblWidth")).Text = ((DataRowView)e.Item.DataItem)["imgWidth"].ToString();
                ((Label)e.Item.FindControl("lblHeight")).Text = ((DataRowView)e.Item.DataItem)["imgHeight"].ToString();

                System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgFSObject");
                DataRowView curData = (DataRowView) e.Item.DataItem;
                bool check = (bool)curData["isFile"];
                int ischeck = 0;
                if (check)
                {
                    ischeck = 1;
                }
                switch (ischeck)
                {
                    case 0:
                        image.ImageUrl = "/Images/Icons/folder.gif";
                        image.AlternateText = "Folder";
                        ((Label)e.Item.FindControl("lblSize")).Text = "Dir";
                        e.Item.Attributes.Add("FSOType", "Folder");
                        return;

                    case 1:
                        if (!this._ShowImageAsIcon)
                        {
                            image.ImageUrl = "/Images/Icons/File.gif";
                            break;
                        }
                        image.ImageUrl = this._UploadDir + this.ViewState["fpUploadFolderRelativePath"].ToString() + ((DataRowView)e.Item.DataItem)["FileName"].ToString();
                        break;

                    default:
                        return;
                }
                image.AlternateText = "File";
                string fileSize = this.GetFileSize((long)((int)((DataRowView)e.Item.DataItem)["Size"]));
                ((Label)e.Item.FindControl("lblSize")).Text = fileSize;
                e.Item.Attributes.Add("FSOType", "File");
            }
        }

        private void dgFSList_PageChaged(object sender, DataGridPageChangedEventArgs e)
        {
            this.Session[this.FPTextBoxID + "CurrentPageIndex"] = e.NewPageIndex;
            this.dgFSList.CurrentPageIndex = e.NewPageIndex;
            this.showFiles();
        }

        private void dgFSList_SortCommand(object sender, DataGridSortCommandEventArgs e)
        {
            if (this.ViewState["SortColumn"].ToString() == e.SortExpression)
            {
                if (this.ViewState["SortOrder"].ToString() == "ASC")
                {
                    this.ViewState["SortOrder"] = "DESC";
                }
                else
                {
                    this.ViewState["SortOrder"] = "ASC";
                }
            }
            else
            {
                this.ViewState["SortColumn"] = e.SortExpression;
            }
            this.showFiles();
        }

        private void GenerateThumbnailImage(string dir, string name)
        {
            string path = Path.Combine(dir, name);
            Image image = Image.FromFile(base.Server.MapPath(path));
            ImageFormat rawFormat = image.RawFormat;
            int width = image.Width;
            int height = image.Height;
            int maxThumbnailSize = GetMaxThumbnailSize();
            double num4 = Math.Min((double)(((double)maxThumbnailSize) / ((double)width)), (double)(((double)maxThumbnailSize) / ((double)height)));
            if (num4 < 1.0)
            {
                width = (int)Math.Floor((double)(num4 * width));
                height = (int)Math.Floor((double)(num4 * height));
            }
            Image image2 = image.GetThumbnailImage(width, height, null, IntPtr.Zero);
            if (rawFormat.Equals(ImageFormat.Gif))
            {
                image2.Save(base.Server.MapPath(dir) + "thumb_" + Path.GetFileNameWithoutExtension(path) + ".gif", ImageFormat.Gif);
            }
            else
            {
                image2.Save(base.Server.MapPath(dir) + "thumb_" + Path.GetFileNameWithoutExtension(path) + ".jpg", ImageFormat.Jpeg);
            }
            image.Dispose();
            image2.Dispose();
        }

        public static long GetDirectorySize(string path)
        {
            long num = 0L;
            DirectoryInfo info = new DirectoryInfo(path);
            foreach (FileInfo info2 in info.GetFiles())
            {
                num += info2.Length;
            }
            foreach (DirectoryInfo info3 in info.GetDirectories())
            {
                num += GetDirectorySize(info3.FullName);
            }
            return num;
        }

        private string GetFileSize(long Lenght)
        {
            long num;
            if (Lenght > 0xf4240L)
            {
                num = Lenght / 0xf4240L;
                return (num.ToString() + " Mb");
            }
            if (Lenght > 0x3e8L)
            {
                num = Lenght / 0x3e8L;
                return (num.ToString() + " Kb");
            }
            return (Lenght.ToString() + " b");
        }

        public static int GetMaxThumbnailSize()
        {
            return int.Parse("150");
        }

        private string getParentDirectory(string RelativePath)
        {
            if (RelativePath == "./")
            {
                return "../";
            }
            if (RelativePath == "")
            {
                return "";
            }
            if (RelativePath.LastIndexOf("/") == (RelativePath.Length - 1))
            {
                RelativePath = RelativePath.Remove(RelativePath.LastIndexOf("/"), RelativePath.Length - RelativePath.LastIndexOf("/"));
            }
            try
            {
                RelativePath = RelativePath.Remove(RelativePath.LastIndexOf("/"), RelativePath.Length - RelativePath.LastIndexOf("/"));
                return RelativePath;
            }
            catch
            {
                return "";
            }
        }

        private void GoRoot_Click(object sender, ImageClickEventArgs e)
        {
            this.ChangePath("/");
            this.showFiles();
        }

        private void InitializeComponent()
        {
            this.UploadBtn.Click += new EventHandler(this.UploadBtn_Click);
            this.NewFolderBtn.Click += new EventHandler(this.NewFolderBtn_Click);
            this.UpBtn.Click += new ImageClickEventHandler(this.UpBtn_Click);
            this.GoRoot.Click += new ImageClickEventHandler(this.GoRoot_Click);
            this.dgFSList.ItemCommand += new DataGridCommandEventHandler(this.dgFSList_ItemCommand);
            this.dgFSList.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgFSList_PageChaged);
            this.dgFSList.SortCommand += new DataGridSortCommandEventHandler(this.dgFSList_SortCommand);
            this.dgFSList.ItemDataBound += new DataGridItemEventHandler(this.dgFSList_ItemDataBound);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void NewFolderBtn_Click(object sender, EventArgs e)
        {
            if (this.NewFolderText.Text == "")
            {
                this.ReportError("Thư mục mới chưa c\x00f3 t\x00ean.", "H\x00e3y đặt t\x00ean cho thư mục mới.", true);
            }
            else
            {
                try
                {
                    new DirectoryInfo(base.Server.MapPath(this._UploadDir + this.ViewState["fpUploadFolderRelativePath"].ToString() + "/" + this.NewFolderText.Text)).Create();
                    this.showFiles();
                }
                catch
                {
                    this.ReportError("Kh\x00f4ng thể tạo thư mục mới: " + this.NewFolderText.Text.ToString(), "H\x00e3y chắc rằng bạn c\x00f3 quyền ghi v\x00e0o thư mục hiện tại", true);
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.FPTextBoxID = base.Request.QueryString["TextBoxID"];
            if (this.Session[this.FPTextBoxID + "fpUploadDir"] == null)
            {
                this._UploadDir = "/Upload";
            }
            else
            {
                this._UploadDir = (string)this.Session[this.FPTextBoxID + "fpUploadDir"];
            }
            this._UploadDir = this.AddSlashIfNotExist(this._UploadDir);
            if (this.Session[this.FPTextBoxID + "fpAllowUpload"] != null)
            {
                this._AllowUpload = Convert.ToBoolean(this.Session[this.FPTextBoxID + "fpAllowUpload"]);
            }
            if (this.Session[this.FPTextBoxID + "fpAllowCreateDirs"] != null)
            {
                this._AllowCreateDirs = Convert.ToBoolean(this.Session[this.FPTextBoxID + "fpAllowCreateDirs"]);
            }
            if (this.Session[this.FPTextBoxID + "fpAllowDelete"] != null)
            {
                this._AllowDelete = Convert.ToBoolean(this.Session[this.FPTextBoxID + "fpAllowDelete"]);
            }
            if (this.Session[this.FPTextBoxID + "fpAllowRename"] != null)
            {
                this._AllowRename = Convert.ToBoolean(this.Session[this.FPTextBoxID + "fpAllowRename"]);
            }
            if (this.Session[this.FPTextBoxID + "fpCheckImage"] != null)
            {
                this._CheckImage = Convert.ToBoolean(this.Session[this.FPTextBoxID + "fpCheckImage"]);
            }
            if (this.Session[this.FPTextBoxID + "fpImageHeightLimit"] != null)
            {
                this._ImageHeightLimit = Convert.ToInt32(this.Session[this.FPTextBoxID + "fpImageHeightLimit"]);
            }
            if (this.Session[this.FPTextBoxID + "fpImageWidthLimit"] != null)
            {
                this._ImageWidthLimit = Convert.ToInt32(this.Session[this.FPTextBoxID + "fpImageWidthLimit"]);
            }
            if (this.Session[this.FPTextBoxID + "fpTotalSizeLimit"] != null)
            {
                this._TotalSizeLimit = Convert.ToInt32(this.Session[this.FPTextBoxID + "fpTotalSizeLimit"]);
            }
            if (this.Session[this.FPTextBoxID + "fpShowImageAsIcon"] != null)
            {
                this._ShowImageAsIcon = Convert.ToBoolean(this.Session[this.FPTextBoxID + "fpShowImageAsIcon"]);
            }
            this.UploadArea.Visible = this._AllowUpload;
            this.CreateDirArea.Visible = this._AllowCreateDirs;
            if (this.Session[this.FPTextBoxID + "fpUseAppRelPath"] != null)
            {
                this._UseAppRelPath = Convert.ToBoolean(this.Session[this.FPTextBoxID + "fpUseAppRelPath"]);
            }
            if (this.ViewState["SortColumn"] == null)
            {
                this.ViewState["SortColumn"] = "Modified";
            }
            if (this.ViewState["SortOrder"] == null)
            {
                this.ViewState["SortOrder"] = "DESC";
            }
            if (!base.IsPostBack)
            {
                this.ViewState["fpUploadFolderRelativePath"] = this.DateFolder();
                if (this.Session[this.FPTextBoxID + "CurrentPageIndex"] == null)
                {
                    this.Session[this.FPTextBoxID + "CurrentPageIndex"] = 0;
                }
                if ((base.Request.QueryString["value"] != null) && (base.Request.QueryString["value"].ToString() != ""))
                {
                    string str2;
                    string str = this.getParentDirectory(base.Request.QueryString["value"].ToString());
                    str = this.AddSlashIfNotExist(str);
                    if (this._UseAppRelPath)
                    {
                        if (str.Length > this._UploadDir.Length)
                        {
                            str2 = str.Substring(this._UploadDir.Length);
                        }
                        else
                        {
                            str2 = string.Empty;
                        }
                    }
                    else
                    {
                        str2 = str;
                    }
                    DirectoryInfo info = new DirectoryInfo(base.Server.MapPath(this._UploadDir + str2));
                    if (info.Exists)
                    {
                        this.ViewState["fpUploadFolderRelativePath"] = str2;
                    }
                }
            }
            this.showFiles();
        }

        private void ReportError(string problem, string suggestion, bool isClose)
        {
            StringBuilder builder = new StringBuilder("<script language='javascript'>\n");
            builder.Append("var Msg='C\x00f3 vấn đề: \\n';\n");
            builder.Append("Msg +='" + problem + "\\n';\n");
            builder.Append("Msg +='Gợi \x00fd: \\n" + suggestion + "\\n';\n");
            builder.Append("alert(Msg);\n");
            if (isClose)
            {
                builder.Append("window.close();\n");
            }
            builder.Append("</script>");
            base.Response.Write(builder.ToString());
        }

        public void SelectFile(string FileName, string Width, string Height)
        {
            if (this._UseAppRelPath)
            {
                FileName = this._UploadDir + FileName;
            }
            if (!this.Page.IsStartupScriptRegistered("UpdateCaller"))
            {
                StringBuilder builder = new StringBuilder("<script language='javascript'>\n", 0x7d0);
                builder.Append("if (window.opener == null) ");
                builder.Append("  { window.close(); }\n");
                builder.Append("else \n");
                builder.Append("{\n");
                builder.Append("  var vCallerDocument = window.opener.document;\n  var vItem;\n");
                builder.Append("  vItem = vCallerDocument.getElementById('" + base.Request.QueryString["TextBoxID"] + "');\n");
                builder.Append("  vItem.value = '" + FileName + "';\n");
                if ((base.Request.QueryString["wTextBoxID"] != "") && (base.Request.QueryString["hTextBoxID"] != ""))
                {
                    builder.Append("  vItem = vCallerDocument.getElementById('" + base.Request.QueryString["wTextBoxID"] + "');\n");
                    builder.Append("  vItem.value = '" + Width + "';\n");
                    builder.Append("  vItem = vCallerDocument.getElementById('" + base.Request.QueryString["hTextBoxID"] + "');\n");
                    builder.Append("  vItem.value = '" + Height + "';\n");
                }
                builder.Append("}\n");
                builder.Append("window.close();\n");
                builder.Append("\n</script>");
                this.Page.RegisterStartupScript("UpdateCaller", builder.ToString());
            }
        }

        private void showFiles()
        {
            if (this.ViewState["fpUploadFolderRelativePath"] == null)
            {
                this.ViewState["fpUploadFolderRelativePath"] = "";
            }
            if (this.ViewState["fpUploadFolderRelativePath"].ToString() != "")
            {
                this.Header.Text = "C\x00e1c file bạn đ\x00e3 tải l\x00ean trong <b>" + this.ViewState["fpUploadFolderRelativePath"].ToString() + "</b>.";
                this.UpBtn.Visible = true;
                this.GoRoot.Visible = true;
            }
            else
            {
                this.Header.Text = "Xem nội dung <B>thư mục gốc.</b>";
                this.UpBtn.Visible = false;
                this.GoRoot.Visible = false;
            }
            DirectoryInfo info = this.ValidatePath(this._UploadDir + ((string)this.ViewState["fpUploadFolderRelativePath"]));
            if (info != null)
            {
                if (this.Session[this.FPTextBoxID + "CurrentPageIndex"] != null)
                {
                    float num = ((float)info.GetFileSystemInfos().Length) / ((float)this.dgFSList.PageSize);
                    int num2 = (int)num;
                    if (num2 < num)
                    {
                        num2++;
                    }
                    if (((int)this.Session[this.FPTextBoxID + "CurrentPageIndex"]) < num2)
                    {
                        this.dgFSList.CurrentPageIndex = (int)this.Session[this.FPTextBoxID + "CurrentPageIndex"];
                    }
                    else
                    {
                        this.dgFSList.CurrentPageIndex = 0;
                    }
                }
                FileSystemInfo[] fileSystemInfos = info.GetFileSystemInfos();
                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn("IsFile", Type.GetType("System.Boolean")));
                table.Columns.Add(new DataColumn("FileName", Type.GetType("System.String")));
                table.Columns.Add(new DataColumn("Size", Type.GetType("System.Int32")));
                table.Columns.Add(new DataColumn("imgWidth", Type.GetType("System.Int32")));
                table.Columns.Add(new DataColumn("imgHeight", Type.GetType("System.Int32")));
                table.Columns.Add(new DataColumn("Modified", Type.GetType("System.DateTime")));
                foreach (FileSystemInfo info2 in fileSystemInfos)
                {
                    DataRow row = table.NewRow();
                    string str = info2.ToString();
                    row["FileName"] = info2.ToString();
                    string path = this._UploadDir + this.ViewState["fpUploadFolderRelativePath"].ToString() + "/" + str.Remove(0, str.LastIndexOf(@"\") + 1);
                    try
                    {
                        Image image = Image.FromFile(base.Server.MapPath(path));
                        row["imgWidth"] = Convert.ToInt32(image.Width);
                        row["imgHeight"] = Convert.ToInt32(image.Height);
                        image.Dispose();
                    }
                    catch
                    {
                        row["imgWidth"] = 0;
                        row["imgHeight"] = 0;
                    }
                    row["Modified"] = info2.LastWriteTime;
                    switch (info2.GetType().ToString())
                    {
                        case "System.IO.DirectoryInfo":
                            row["IsFile"] = false;
                            break;

                        case "System.IO.FileInfo":
                            row["IsFile"] = true;
                            row["Size"] = ((FileInfo)info2).Length;
                            break;
                    }
                    table.Rows.Add(row);
                }
                DataView defaultView = table.DefaultView;
                defaultView.Sort = ((string)this.ViewState["SortColumn"]) + " " + ((string)this.ViewState["SortOrder"]);
                this.dgFSList.DataSource = defaultView;
                if (this.ViewState["EditItemIndex"] != null)
                {
                    this.dgFSList.EditItemIndex = (int)this.ViewState["EditItemIndex"];
                }
                this.dgFSList.DataBind();
            }
        }

        private void UpBtn_Click(object sender, ImageClickEventArgs e)
        {
            this.ChangePath("../");
            this.showFiles();
        }

        private void UploadBtn_Click(object sender, EventArgs e)
        {
            string str;
            bool flag = false;
            if (this.Session[this.FPTextBoxID + "fpAllowedUploadFileExts"] != null)
            {
                str = this.Session[this.FPTextBoxID + "fpAllowedUploadFileExts"].ToString();
            }
            else
            {
                str = "gif,jpg,jpeg,png,bmp";
            }
            int num = 0;
            for (int i = 0; i < base.Request.Files.Count; i++)
            {
                HttpPostedFile file = base.Request.Files[i];
                if (file.FileName == "")
                {
                    num++;
                    if (num == base.Request.Files.Count)
                    {
                        this.ReportError("Kh\x00f4ng c\x00f3 tệp n\x00e0o được chọn để tải l\x00ean.", "H\x00e3y nhấn v\x00e0o Browse v\x00e0 chọn tệp bản muốn tải l\x00ean.", true);
                    }
                }
                else
                {
                    try
                    {
                        string fileName = file.FileName;
                        long contentLength = file.ContentLength;
                        if (str != "")
                        {
                            char[] separator = new char[] { ',' };
                            string[] strArray = str.Split(separator);
                            if (Path.HasExtension(fileName))
                            {
                                string str3 = Path.GetExtension(fileName).Replace(".", "").Trim();
                                foreach (string str4 in strArray)
                                {
                                    string str5 = str4.Replace(".", "").Trim();
                                    if (str3.ToLower() == str5.ToLower())
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            flag = true;
                        }
                        if (!flag)
                        {
                            this.ReportError("Xin lỗi, định dạng tệp n\x00e0y kh\x00f4ng được hỗ trợ.", @"Bạn chỉ được tải tệp với những định dạng sau:\n" + str, true);
                        }
                        if (flag && this._CheckImage)
                        {
                            try
                            {
                                flag = true;
                                Image image = Image.FromStream(this.fileToUpload1.PostedFile.InputStream);
                                if ((this._ImageHeightLimit != 0) && (image.Height > this._ImageHeightLimit))
                                {
                                    flag = false;
                                }
                                if ((this._ImageWidthLimit != 0) && (image.Width > this._ImageWidthLimit))
                                {
                                    flag = false;
                                }
                                image.Dispose();
                                if (this.fileToUpload2.PostedFile.FileName != "")
                                {
                                    image = Image.FromStream(this.fileToUpload2.PostedFile.InputStream);
                                    if ((this._ImageHeightLimit != 0) && (image.Height > this._ImageHeightLimit))
                                    {
                                        flag = false;
                                    }
                                    if ((this._ImageWidthLimit != 0) && (image.Width > this._ImageWidthLimit))
                                    {
                                        flag = false;
                                    }
                                    image.Dispose();
                                }
                                if (this.fileToUpload3.PostedFile.FileName != "")
                                {
                                    image = Image.FromStream(this.fileToUpload3.PostedFile.InputStream);
                                    if ((this._ImageHeightLimit != 0) && (image.Height > this._ImageHeightLimit))
                                    {
                                        flag = false;
                                    }
                                    if ((this._ImageWidthLimit != 0) && (image.Width > this._ImageWidthLimit))
                                    {
                                        flag = false;
                                    }
                                    image.Dispose();
                                }
                            }
                            catch
                            {
                                flag = false;
                            }
                            if (!flag)
                            {
                                this.ReportError("Kh\x00f4ng nhận dạng được tệp ảnh hoặc k\x00edch thước kh\x00f4ng ph\x00f9 hợp.", string.Format("Bạn h\x00e3y kiểm tra lại tệp tải l\x00ean, k\x00edch thước tối đa cao {0} x rộng {1}.", this._ImageHeightLimit, this._ImageWidthLimit), true);
                            }
                        }
                        if (this.Session[this.FPTextBoxID + "fpFileSizeLimit"] != null)
                        {
                            long lenght = Convert.ToInt32(this.Session[this.FPTextBoxID + "fpFileSizeLimit"]);
                            if ((lenght > 0L) && (contentLength > lenght))
                            {
                                base.Response.Write("<script>alert(\"Tệp qu\x00e1 lớn. K\x00edch cỡ tối đa của tệp l\x00e0 " + this.GetFileSize(lenght) + ".\"); </script>");
                                flag = false;
                            }
                        }
                        if (flag)
                        {
                            if (this._TotalSizeLimit > 0)
                            {
                                long num5 = GetDirectorySize(base.Server.MapPath(this._UploadDir)) + contentLength;
                                if (num5 > this._TotalSizeLimit)
                                {
                                    flag = false;
                                }
                            }
                            if (!flag)
                            {
                                this.ReportError("Vượt qu\x00e1 tổng dung lượng cho ph\x00e9p để tải ảnh l\x00ean.", "Bạn h\x00e3y kiểm tra lại thư mục ảnh của m\x00ecnh.", true);
                            }
                        }
                        if (flag)
                        {
                            this.GetFileSize(contentLength);
                            string path = this._UploadDir + this.ViewState["fpUploadFolderRelativePath"].ToString() + "/" + fileName.Remove(0, fileName.LastIndexOf(@"\") + 1);
                            file.SaveAs(base.Server.MapPath(path));
                            if (this.chkThumbnail.Checked)
                            {
                                this.GenerateThumbnailImage(this._UploadDir + this.ViewState["fpUploadFolderRelativePath"].ToString(), fileName.Remove(0, fileName.LastIndexOf(@"\") + 1));
                            }
                            this.showFiles();
                        }
                    }
                    catch
                    {
                        this.ReportError("Tải tệp bị lỗi.", "Tệp qu\x00e1 lớn hoặc \\nkh\x00f4ng được quyền truy cập thư mục upload.", true);
                    }
                }
            }
        }

        private DirectoryInfo ValidatePath(string Path)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(base.Server.MapPath(Path));
                if (info.Exists)
                {
                    return info;
                }
                info.Create();
            }
            catch (DirectoryNotFoundException exception)
            {
                this.ReportError("Kh\x00f4ng t\x00ecm thấy đường dẫn.", "H\x00e3y thử quay lại thư mục gốc.", true);
                exception.ToString();
            }
            catch (SecurityException exception2)
            {
                this.ReportError("Bạn kh\x00f4ng c\x00f3 quyền xem thư mục n\x00e0y.", "H\x00e3y li\x00ean hệ với dịch vụ hỗ trợ", true);
                exception2.ToString();
            }
            catch (ArgumentException exception3)
            {
                this.ReportError("Đường dẫn c\x00f3 những k\x00ed tự kh\x00f4ng hợp lệ.", "H\x00e3y đổi t\x00ean tệp v\x00e0 loại bỏ những k\x00ed tự kh\x00f4ng chuẩn.", true);
                exception3.ToString();
            }
            catch (Exception exception4)
            {
                this.ReportError("Kh\x00f4ng thể lấy th\x00f4ng tin từ thư mục.", "H\x00e3y thử đổi t\x00ean thư mục gốc th\x00e0nh ./", true);
                exception4.ToString();
            }
            return null;
        }
    }


}
