using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrganicBit.Zip;
using Telerik.WebControls;

namespace VmgPortal.FilePicker
{
    public enum MessageType
    {
        InfoMsg,
        ErrorMsg
    }
    public enum FileManagerView
    {
        Explorer,
        RecycleBin
    }

    public partial class FilePicker : System.Web.UI.Page
    {
       
        protected System.Resources.ResourceManager rm;//resource manager to access resources
        protected string deleteConfirmation;//Localized confirmation for deleting files (set in LocalizeControls() ) 

        private string rootPath = "";//root path; always has "/" in the end.
        private string currentPath = "";//current path: relative path to web server (not upload folder!) root directory. Always has "/" in the end.
        private ArrayList foundFiles;//list of files found with the Search feature
        private string rowToSelect = "";//nathis of the selected file in the grid
        private string pathCopy = "";//path from where we copy files
        private string operation = "";//operation being completed (copy, move, etc)
        private ArrayList fileList;//generic list of files (e.g. selected files for copying)
        private string rootPathAux = "";//copy of rootPath value 
        private string currentPathAux = "";//copy of current path
        private string fileToRename = "";//name of file being renamed
        private string sortField = "";//sorting field 
        private string sortDirection = "";//sorting direction

        private string fPTextBoxID = "";//clientID of FilePicker;//s textbox
        private bool allowUpload;//is upload allowed?
        private bool allowCreateDirs;//is creating dirs allowed?
        private bool allowDelete;//is deletion dirs allowed?
        private bool allowRename;//is renaming dirs allowed?
        private bool allowChangeLanguage;//is changing language of UI is allowed?
        private bool allowCopy;//is copying files allowed?
        private bool allowMove;//is moving files allowed?
        private bool useAppRelPath;//Return path relative to web root rather than to upload folder
        private string allowedUploadFileExts = "";//A comma-delimited list of permitted file types (extensions)
        private Int64 uploadSizeLimit;//Max size of file which can be uploaded 
        private bool showThumbnails;


        public string imagesPath = "Images/";
        public string iconsPath = "Images/" + "Icons/";
        public string thumbPath = "_thumbs/";
        public string _thumbPath = "_thumbs";
        public string tempPath = "_temp/";
        protected string lblTitle = "";
        protected string lblLabelBottom = "";
        protected string lblLabelTop = "";
        protected string lblLabelPleaseWaith = "";
        protected string lblLabelInfo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string currentPhysPath;
            LoadStateData();
            LocalizeControls();

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["value"] != String.Empty)
                {
                    currentPath = Request.QueryString["value"];

                    if (!useAppRelPath)
                    {
                        currentPath = rootPath + currentPath +"Thang_" + DateTime.Now.Month + "/Ngay_" + DateTime.Now.Day + "/";
                    }

                    currentPhysPath = Server.MapPath(currentPath);

                    if (currentPath != null)
                    {
                        if (Directory.Exists(currentPhysPath))
                        {
                            currentPath = new Ultils().AddSlashInTheEndIfNotPresent(currentPath);
                        }
                        else if (File.Exists(currentPhysPath))
                        {
                            currentPath = new Ultils().AddSlashInTheEndIfNotPresent(new Ultils().GetParentDirectory(currentPath));
                        }
                        else
                        {
                            currentPath = rootPath + "Thang_" + DateTime.Now.Month + "/Ngay_" + DateTime.Now.Day + "/";
                        }
                    }
                    else
                    {
                        currentPath = rootPath + "Thang_" + DateTime.Now.Month + "/Ngay_" + DateTime.Now.Day + "/";
                    }
                }
                else
                {
                    currentPath = rootPath + "Thang_" + DateTime.Now.Month + "/Ngay_" + DateTime.Now.Day + "/";
                }

                Trace.Warn("rootPath=" + rootPath);
                Trace.Warn("currentPath=" + currentPath);
                Trace.Warn("UseAppRelPath=" + useAppRelPath.ToString());

                Reload();

                ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_LABEL_LAUNCHED"));
            }
        }  
        //Moi
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BindValidResults();
            BindInvalidResults();
           
            //Remove this line if you do not want to delete the files
            //in the location where they have been saved
            //DeleteFiles();
        }       
        private void BindValidResults()
        {
            if (upload1.UploadedFiles.Count > 0)
            {
                foreach (UploadedFile validFile in upload1.UploadedFiles)
                {
                    string strPath = Server.MapPath(currentPath);
                    string FileName = new Ultils().AddBackSlashInTheEndIfNotPresent(strPath) + validFile.GetName();

                    //'Delete the file if already exists but overwriting is not
                    //'disabled
                    if (File.Exists(FileName))
                    {
                        if (chkOverwrite.Checked)
                        {
                            FileInfo fi = new FileInfo(FileName);
                            fi.Delete();
                        }
                        else
                        {
                            ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang", "LOC_ERROR_UPLOAD_FILEEXISTS"), validFile.GetName()), MessageType.ErrorMsg);
                            return;
                        }
                    }
                    validFile.SaveAs(FileName, true);
                    if (FileName.ToLower().IndexOf(".zip") > 0)
                    {
                        ZipUtil.UnZipFiles(FileName, strPath, "", true);
                    }
                }

                labelNoResults.Visible = false;
                repeaterValidResults.Visible = true;
                repeaterValidResults.DataSource = upload1.UploadedFiles;
                repeaterValidResults.DataBind();
                Reload();
            }
            else
            {
                labelNoResults.Visible = true;
                repeaterValidResults.Visible = false;
            }
        }
        private void BindInvalidResults()
        {
            if (upload1.InvalidFiles.Count > 0)
            {
                labelNoInvalidResults.Visible = false;
                repeaterInvalidResults.Visible = true;
                repeaterInvalidResults.DataSource = upload1.InvalidFiles;
                repeaterInvalidResults.DataBind();
            }
            else
            {
                labelNoInvalidResults.Visible = true;
                repeaterInvalidResults.Visible = false;
            }
        }
        private void DeleteFiles()
        {
            string strPath = Server.MapPath(currentPath);
            string targetFolder = new Ultils().AddBackSlashInTheEndIfNotPresent(strPath);

            DirectoryInfo targetDir = new DirectoryInfo(targetFolder);

            try
            {
                foreach (FileInfo file in targetDir.GetFiles())
                {
                    if ((file.Attributes & FileAttributes.ReadOnly) == 0)
                    {
                        file.Delete();
                    }
                }
            }
            catch (IOException e)
            {
            }
        }
        //End moi

        public string ReturnText(string strKey)
        {
            return (string)this.GetGlobalResourceObject("Lang",strKey);
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Application["fpRm"] == null)
            {
                rm = new ResourceManager(Server.MapPath("FilePicker") + ".Lang", Assembly.GetExecutingAssembly());
                Application["fpRm"] = rm;
            }
            else
            {
                rm = (System.Resources.ResourceManager)Application["fpRm"];
            }

            string cultureCode;
            try
            {
                cultureCode = Request.Cookies["UserLanguage"].Value;
                if (cultureCode == "")
                {
                    cultureCode = Request.UserLanguages[0];
                }
            }
            catch (Exception ex)
            {
                cultureCode = Request.UserLanguages[0];
            }

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureCode);

            }
            catch (Exception ex)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            }

            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }
        protected string DirectoryAlign(Object Type)
        {
            string src;

            if ((string)Type == "D")
            {
                src = "AlignLeft";
            }
            else
            {
                src = "AlignRight";
            }

            return src;
        }
        protected bool TypeIsD(string type)
        {
            if (type == "D")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected string GetFileDirPictureUrl(Object type, Object fileDirName)
        {

            bool isDirectory = TypeIsD((string)type);
            string extention = "";
            string ImageSrc;

            if (!isDirectory)
            {
                extention = Path.GetExtension((string)fileDirName).ToLower();
            }

            if (isDirectory)
            {
                ImageSrc = "Folder.gif";
            }
            else
            {
                switch (extention)
                {
                    case ".bat":
                        ImageSrc = "Bat.gif";
                        break;
                    case ".gif":
                    case ".png":
                        ImageSrc = "Gif.gif";
                        break;
                    case ".js":
                    case ".txt":
                    case ".css":
                    case ".asp":
                    case ".aspx":
                    case ".log":
                    case ".vb":
                        ImageSrc = "Text.gif";
                        break;
                    case ".doc":
                    case ".dot":
                        ImageSrc = "Doc.gif";
                        break;
                    case ".ini":
                        ImageSrc = "Ini.gif";
                        break;
                    case ".msi":
                        ImageSrc = "Msi.gif";
                        break;
                    case ".zip":
                        ImageSrc = "Zip.gif";
                        break;
                    case ".bmp":
                        ImageSrc = "Bmp.gif";
                        break;
                    case ".pdf":
                        ImageSrc = "Pdf.gif";
                        break;
                    case ".html":
                    case ".htm":
                        ImageSrc = "Html.gif";
                        break;
                    case ".psp":
                        ImageSrc = "Psp.gif";
                        break;
                    case ".mdb":
                        ImageSrc = "Mdb.gif";
                        break;
                    case ".xls":
                    case ".xlt":
                        ImageSrc = "Xls.gif";
                        break;
                    case ".vsd":
                        ImageSrc = "Vsd.gif";
                        break;
                    case ".snp":
                        ImageSrc = "Snp.gif";
                        break;
                    case ".jpg":
                        ImageSrc = "Jpg.gif";
                        break;
                    case ".ttf":
                        ImageSrc = "Ttf.gif";
                        break;
                    case ".mp3":
                        ImageSrc = "Mp3.gif";
                        break;
                    case ".wma":
                        ImageSrc = "Wma.gif";
                        break;
                    case ".wmv":
                        ImageSrc = "Wma.gif";
                        break;
                    default:
                        ImageSrc = "Unknown.gif";
                        break;
                }
            }
            ImageSrc = iconsPath + ImageSrc;

            if (showThumbnails)
            {
                if (!isDirectory)
                {
                    if ((extention == ".gif") || (extention == ".jpg") || (extention == ".jpeg") || (extention == ".tif") || (extention == ".png") || (extention == ".bmp"))
                    {
                        ImageSrc = GenerateThumbnail((string)fileDirName);
                    }
                }
            }

            return ImageSrc;
        }
        protected string _TypeIsD(string type)
        {
            if (type == "D")
            {
                return "DownloadFolder.gif";
            }
            else
            {
                return "DownloadFile.gif";
            }
        }
        protected string GetDownloadImageUrl(Object Type)
        {
            return imagesPath + (string)(_TypeIsD((string)Type));
        }
        protected void NavigateHome(Object sender, ImageClickEventArgs e)
        {

            //'Leave the edit mode if we're there
            dgExplorer.EditItemIndex = -1;

            //'Make current path the root path
            currentPath = rootPath;

            //'Show the directories and files
            Reload();

            //'Show the last action to user
            ShowInfo((string)this.GetGlobalResourceObject("Lang", "LOC_LABEL_MOVEDTOROOT"));
        }
        protected void NavigateDown(Object sender, CommandEventArgs e)
        {
            dgExplorer.EditItemIndex = -1;
            if (sender.GetType().ToString().ToUpper() == "SYSTEM.WEB.UI.WEBCONTROLS.LINKBUTTON")
            {
                NavigateDown(((LinkButton)sender).Text, e.CommandName);
            }
            else
            {
                NavigateDown(((ImageButton)sender).AlternateText, e.CommandName);
            }
        }
        protected void NavigateDown(string FileFolderName, string CommandName)
        {

            dgExplorer.EditItemIndex = -1;

            if (CommandName == "D")
            {

                string proposedCurrentPath = currentPath + FileFolderName + "/";

                currentPath = proposedCurrentPath;

                Reload();

                ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_LABEL_MOVEDONEFOLDERDOWN"));
            }
            else
            {

                SelectFile(FileFolderName);
            }
        }
        protected void NavigateUp(Object sender, ImageClickEventArgs e)
        {
            string proposedCurrentPath;

            dgExplorer.EditItemIndex = -1;

            if (currentPath != rootPath)
            {
                proposedCurrentPath = new Ultils().GetParentDirectory(currentPath);
                proposedCurrentPath = new Ultils().AddSlashInTheEndIfNotPresent(proposedCurrentPath);
                if (proposedCurrentPath == String.Empty)
                {
                    proposedCurrentPath = rootPath;
                }
                currentPath = proposedCurrentPath;
            }

            Reload();

            ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_LABEL_MOVEDONEFOLDERUP"));
        }        
        protected void Copy(Object sender, ImageClickEventArgs e)
        {
            ArrayList AllFiles;
            AllFiles = new ArrayList();

            int i;

            if (allowCopy)
            {
                if (dgExplorer.EditItemIndex == -1)
                {
                    i = 0;

                    foreach (DataGridItem dgItem in dgExplorer.Items)
                    {
                        CheckBox chk = (CheckBox)(dgItem.FindControl("chkSelected"));
                        if (chk.Checked)
                        {
                            AllFiles.Add(((LinkButton)dgItem.FindControl("Name")).Text);
                            i += 1;
                        }
                    }

                    if (AllFiles.Count > 0)
                    {
                        pathCopy = currentPath;
                        operation = "Copy";
                        fileList = AllFiles;
                    }


                    ShowInfo(i.ToString() + " " + (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILESCOPIED"));
                }
                else
                {
                    ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_LABEL_EDITMODEWARNING"), MessageType.ErrorMsg);
                }
            }
        }
        protected void CopyDirectory(string PathFrom, string PathTo)
        {
            string ParentPathTo;
            ParentPathTo = Path.GetDirectoryName(PathTo);

            if (Directory.Exists(PathTo))
            {
                int i;
                i = 0;
                while (Directory.Exists(PathTo))
                {
                    i += 1;
                    PathTo = ParentPathTo + "\\" + Path.GetFileName(PathFrom) + " " + (string)this.GetGlobalResourceObject("Lang","LOC_PREFIX_THECOPY") + " (" + i + ")";
                }
            }

            Directory.CreateDirectory(PathTo);

            foreach (string fileName in Directory.GetFiles(PathFrom))
            {
                File.Copy(fileName, PathTo + "\\" + Path.GetFileName(fileName));
            }

            foreach (string dir in Directory.GetDirectories(PathFrom))
            {
                CopyDirectory(dir, PathTo + "\\" + Path.GetFileName(dir));

            }
        }
        private bool IsRecursive(string PathFrom, string PathTo)
        {
            if (PathTo == PathFrom)
            {
                return false;
            }

            if (PathFrom.IndexOf(PathTo) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        void PasteCopyFiles()
        {
            long k;
            k = 0;

            foreach (string Item in fileList)
            {
                string PathFrom;
                PathFrom = new Ultils().AddBackSlashInTheEndIfNotPresent(Server.MapPath(pathCopy)) + Item;

                string PathTo;
                PathTo = new Ultils().AddBackSlashInTheEndIfNotPresent(Server.MapPath(currentPath)) + Item;
                Trace.Warn("PathFrom = " + PathFrom);
                Trace.Warn("PathTo = " + PathTo);

                if (!IsRecursive(PathFrom, PathTo))
                {
                    if (File.Exists(PathFrom))
                    {
                        if (!File.Exists(PathTo))
                        {
                            try
                            {
                                File.Copy(PathFrom, PathTo);
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_COPY_FILE_ACCESSDENIED"), Item), MessageType.ErrorMsg);
                                return;
                            }

                            catch (Exception ex)
                            {
                                ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_COPY_FILE"), Item) + " " + ex.Message, MessageType.ErrorMsg);
                                return;
                            }
                        }
                        else
                        {

                            int i = 0;
                            while (File.Exists(PathTo))
                            {
                                i += 1;
                                PathTo = Server.MapPath(currentPath) + Path.GetFileNameWithoutExtension(Item) + " " + (string)this.GetGlobalResourceObject("Lang","LOC_PREFIX_THECOPY") + " (" + i + ")" + Path.GetExtension(Item);
                            }

                            try
                            {
                                File.Copy(PathFrom, PathTo);
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_COPY_FILE_ACCESSDENIED"), Item), MessageType.ErrorMsg);
                                return;
                            }
                            catch (Exception ex)
                            {
                                ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_COPY_FILE"), Item) + " " + ex.Message, MessageType.ErrorMsg);
                                return;
                            }
                        }
                    }
                    if (Directory.Exists(PathFrom))
                    {
                        try
                        {
                            CopyDirectory(PathFrom, PathTo);
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_COPY_DIRECTORY_ACCESSDENIED"), Item), MessageType.ErrorMsg);
                            return;
                        }
                        catch (Exception ex)
                        {
                            ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_COPY_DIRECTORY"), Item) + " " + ex.Message, MessageType.ErrorMsg);
                            return;
                        }
                    }
                    k += 1;
                }
            }
            ShowInfo(k.ToString() + " " + (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILESPASTED"));
        }
        void PasteCutFiles()
        {

            int k = 0;

            foreach (string Item in fileList)
            {

                string PathFrom = new Ultils().AddBackSlashInTheEndIfNotPresent(Server.MapPath(pathCopy)) + Item;

                string PathTo = new Ultils().AddBackSlashInTheEndIfNotPresent(Server.MapPath(currentPath)) + Item;


                if (PathFrom == PathTo)
                {
                    return;
                }


                if (File.Exists(PathFrom))
                {

                    try
                    {
                        if (File.Exists(PathTo))
                        {
                            File.Delete(PathTo);
                        }

                        File.Move(PathFrom, PathTo);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_MOVE_FILE_ACCESSDENIED"), Item), MessageType.ErrorMsg);
                        return;
                    }
                    catch (Exception ex)
                    {
                        ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_MOVE_FILE"), Item) + " " + ex.Message, MessageType.ErrorMsg);
                        return;
                    }
                }
                else
                {



                    if (Directory.Exists(PathFrom))
                    {

                        try
                        {

                            bool Continue = true;

                            if (Directory.Exists(PathTo))
                            {
                                if (!IsRecursive(PathTo, PathFrom))
                                {
                                    Directory.Delete(PathTo, true);
                                }
                                else
                                {
                                    Continue = false;
                                    k -= 1;
                                }
                            }
                            if (Continue)
                            {

                                Directory.Move(PathFrom, PathTo);

                            }
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_MOVE_DIRECTORY_ACCESSDENIED"), Item), MessageType.ErrorMsg);
                            return;
                        }
                        catch (Exception ex)
                        {
                            ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_MOVE_DIRECTORY"), Item) + " " + ex.Message, MessageType.ErrorMsg);
                            return;
                        }
                    }
                }
                k += 1;
            }


            ShowInfo(k.ToString() + " " + (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILESPASTED"));
        }
        private void LoadStateData()
        {

            fPTextBoxID = Request.QueryString["TextBoxID"];

            if (!Page.IsPostBack)
            {

                if (Session[fPTextBoxID + "fpUploadDir"] == null)
                {
                    Response.Write("<script language='JavaScript'>alert('" + ((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_SESSIONEMPTY")).Replace("'", "\'") + "');window.close();</script>");
                    Response.Flush();
                    Response.End();
                }

                if (Session[fPTextBoxID + "fpAllowedUploadFileExts"] != null) allowedUploadFileExts = Convert.ToString(Session[fPTextBoxID + "fpAllowedUploadFileExts"]);
                if (Session[fPTextBoxID + "fpUploadSizeLimit"] != null) uploadSizeLimit = Convert.ToInt64(Session[fPTextBoxID + "fpUploadSizeLimit"]);
                if (Session[fPTextBoxID + "fpAllowUpload"] != null) allowUpload = Convert.ToBoolean(Session[fPTextBoxID + "fpAllowUpload"]);
                if (Session[fPTextBoxID + "fpAllowCreateDirs"] != null) allowCreateDirs = Convert.ToBoolean(Session[fPTextBoxID + "fpAllowCreateDirs"]);
                if (Session[fPTextBoxID + "fpAllowDelete"] != null) allowDelete = Convert.ToBoolean(Session[fPTextBoxID + "fpAllowDelete"]);
                if (Session[fPTextBoxID + "fpAllowRename"] != null) allowRename = Convert.ToBoolean(Session[fPTextBoxID + "fpAllowRename"]);
                if (Session[fPTextBoxID + "fpAllowChangeLanguage"] != null) allowChangeLanguage = Convert.ToBoolean(Session[fPTextBoxID + "fpAllowChangeLanguage"]);
                if (Session[fPTextBoxID + "fpAllowCopy"] != null) allowCopy = Convert.ToBoolean(Session[fPTextBoxID + "fpAllowCopy"]);
                if (Session[fPTextBoxID + "fpAllowMove"] != null) allowMove = Convert.ToBoolean(Session[fPTextBoxID + "fpAllowMove"]);
                if (Session[fPTextBoxID + "fpUseAppRelPath"] != null) useAppRelPath = Convert.ToBoolean(Session[fPTextBoxID + "fpUseAppRelPath"]);
                if (Session[fPTextBoxID + "fpUploadDir"] != null) rootPath = Convert.ToString(Session[fPTextBoxID + "fpUploadDir"]);
            }
            else
            {
                allowedUploadFileExts = Convert.ToString(ViewState["fpAllowedUploadFileExts"]);
                uploadSizeLimit = Convert.ToInt32(ViewState["fpUploadSizeLimit"]);
                allowUpload = Convert.ToBoolean(ViewState["fpAllowUpload"]);
                allowCreateDirs = Convert.ToBoolean(ViewState["fpAllowCreateDirs"]);
                allowDelete = Convert.ToBoolean(ViewState["fpAllowDelete"]);
                allowRename = Convert.ToBoolean(ViewState["fpAllowRename"]);
                allowChangeLanguage = Convert.ToBoolean(ViewState["fpAllowChangeLanguage"]);
                allowCopy = Convert.ToBoolean(ViewState["fpAllowCopy"]);
                allowMove = Convert.ToBoolean(ViewState["fpAllowMove"]);
                useAppRelPath = Convert.ToBoolean(ViewState["fpUseAppRelPath"]);

            }

            if (Page.IsPostBack)
            {
                if (ViewState["rootPath"] != null) rootPath = (string)(ViewState["rootPath"]);
                if (ViewState["currentPath"] != null) currentPath = (string)(ViewState["currentPath"]);

                if (ViewState["rowToSelect"] != null) rowToSelect = (string)(ViewState["rowToSelect"]);
                if (ViewState["foundFiles"] != null) foundFiles = (ArrayList)(ViewState["foundFiles"]);
                if (ViewState["pathCopy"] != null) pathCopy = (string)(ViewState["pathCopy"]);
                if (ViewState["operation"] != null) operation = (string)(ViewState["operation"]);
                if (ViewState["fileList"] != null) fileList = (ArrayList)(ViewState["fileList"]);
                if (ViewState["currentPathAux"] != null) currentPathAux = (string)(ViewState["currentPathAux"]);
                if (ViewState["rootPathAux"] != null) rootPathAux = (string)(ViewState["rootPathAux"]);
                if (ViewState["fileToRename"] != null) fileToRename = (string)(ViewState["fileToRename"]);
                if (ViewState["sortField"] != null) sortField = (string)(ViewState["sortField"]);
                if (ViewState["sortDirection"] != null) sortDirection = (string)(ViewState["sortDirection"]);
                if (ViewState["showThumbnails"] != null) showThumbnails = Convert.ToBoolean(ViewState["showThumbnails"]);
            }

            if (rootPath == null || rootPath == String.Empty)
            {
                rootPath = "/";
            }
            rootPath = new Ultils().AddSlashInTheEndIfNotPresent(rootPath);

            if (currentPath == null || currentPath == String.Empty)
            {
                currentPath = rootPath;
            }

            if (sortField == null || sortField == String.Empty)
            {
                sortField = "Name";
            }

            if (sortDirection == null || sortDirection == String.Empty)
            {
                sortDirection = "ASC";
            }

            allowedUploadFileExts = allowedUploadFileExts.Trim();
        }
        private void LocalizeControls()
        {
            this.btnRoot.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_TOOLBAR_ROOT");
            this.btnNavigateUp.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_TOOLBAR_UP");
            this.btnCopy.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_TOOLBAR_COPY");
            this.btnCut.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_TOOLBAR_CUT");
            this.btnPaste.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_TOOLBAR_PASTE");
            this.btnNewFolder.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_TOOLBAR_NEWFOLDER");
            this.btnDelete.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_TOOLBAR_DELETE");
            this.btnRefresh.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_TOOLBAR_REFRESH");
            this.btnReserverCheck.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_TOOLBAR_REVERSECHECK");
            this.btnToggleThumbnails.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_TOOLBAR_SEETHUMBNAILS");
            this.btnUpload.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_TOOLBAR_UPLOAD");

            //'Localize the file list grid
            this.dgExplorer.Columns[0].HeaderText = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILELIST_CHECK");
            this.dgExplorer.Columns[1].HeaderText = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILELIST_NAthis");
            this.dgExplorer.Columns[2].HeaderText = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILELIST_LENGTH");
            this.dgExplorer.Columns[3].HeaderText = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILELIST_UPDATED");
            this.dgExplorer.Columns[4].HeaderText = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_ACTION");

            //'Localize upload options rblUploadOptions
            this.rblUploadOptions.Items[0].Text = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_UPLOAD_UNZIPANDDELETE");
            this.rblUploadOptions.Items[1].Text = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_UPLOAD_UNZIPANDRETAIN");
            this.rblUploadOptions.Items[2].Text = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_UPLOAD_DONOTHING");
            this.chkOverwrite.Text = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_UPLOAD_OVERWRITE");
            this.chkSelectUponUpload.Text = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_UPLOAD_SELECTUPONUPLOAD");

            //'Localize delete confirmation
            deleteConfirmation = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_DELETECONFIRM");

            //'Localize Path textbox tooltip
            txtCurrentPath.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_PATH");

            //'Localize the upload note
            this.lblUploadNote.Text = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_UPLOAD_UPLOADNOTE");

            lblTitle = ReturnText("LOC_LABEL_SELECTAFILE");
            lblLabelBottom = ReturnText("LOC_LABEL_BOTTOM");
            lblLabelTop = ReturnText("LOC_LABEL_TOP");
            lblLabelPleaseWaith = ReturnText("LOC_LABEL_PLEASEWAIT");
            lblLabelInfo = ReturnText("LOC_LABEL_INFO");
        }
        void Reload()
        {
            Explorer Expl;
            string FullPhysThumbPath = "";

            //'Delete temporary directory
            string TempPhysPath = new Ultils().AddBackSlashInTheEndIfNotPresent(Server.MapPath(rootPath)) + tempPath;
            if (Directory.Exists(TempPhysPath))
            {
                Directory.Delete(TempPhysPath, true);
            }

            //'Create thumbnail direcotry if thumbnails enabled
            if (showThumbnails)
            {
                FullPhysThumbPath = Request.MapPath(new Ultils().AddSlashInTheEndIfNotPresent(currentPath) + thumbPath);

                if (!Directory.Exists(FullPhysThumbPath))
                {
                    try
                    {
                        Directory.CreateDirectory(FullPhysThumbPath);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_CREATE_THUMBNAIL_ACCESSDENIED"), MessageType.ErrorMsg);
                        return;
                    }
                    catch (Exception ex)
                    {
                        ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_CREATE_THUMBNAIL") + " " + ex.Message, MessageType.ErrorMsg);
                        return;
                    }
                }
            }

            //'Prepare path to display
            string DisplayPath = currentPath;

            //'Hide root (upload folder) path 
            //'Don't let remove all slashes from the path string 
            //'if root path is the web server root [/] 
            if (rootPath.Trim() == "/")
            {
                DisplayPath = DisplayPath.Replace(rootPath, String.Empty);
            }

            //'Ensure that a slash is present in the beginning of the path to display
            if (DisplayPath == String.Empty)
            {
                DisplayPath = "/";
            }
            else
            {
                if (!DisplayPath.StartsWith("/"))
                {
                    DisplayPath = "/" + DisplayPath;
                }
            }

            //'Show the current path
            txtCurrentPath.Text = DisplayPath;

            //'Read the Directories and Files and show them in the datagrid
            try
            {
                Expl = new Explorer(currentPath);
                Expl.Files.DefaultView.Sort = sortField + " " + sortDirection;
                dgExplorer.DataSource = Expl.Files.DefaultView;
                dgExplorer.DataBind();
            }
            catch (UnauthorizedAccessException ex)
            {
                ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_READLIST_ACCESSDENIED"), MessageType.ErrorMsg);
            }
            catch (Exception ex)
            {
                ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_READLIST") + " " + ex.Message, MessageType.ErrorMsg);
            }


        }
        void ShowInfo(string msg)
        {
            //'Show information message by default
            ShowInfo(msg, MessageType.InfoMsg);
        }
        void ShowInfo(string msg, MessageType msgType)
        {
            string Path = System.Web.HttpContext.Current.Server.MapPath(currentPath);

            //if(!Directory.Exists(Path))
            //{
            //    Directory.CreateDirectory(Path);
            //}
            DirectoryInfo DirInfo = new DirectoryInfo(Path);

            int NumDir = 0;
            int NumFiles = 0;
            long size = 0;
            String Total = "";
            String message = "";

            foreach (DirectoryInfo directory in DirInfo.GetDirectories())
            {
                NumDir += 1;
            }

            foreach (FileInfo file in DirInfo.GetFiles())
            {
                NumFiles += 1;
                size += file.Length;
            }

            if (size < 1)
            {
                if (NumFiles > 0)
                {
                    size = 1;
                }
                else
                {
                    size = 0;
                }
            }

            if (size == 0)
            {
                Total = "0 " + (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_KB");
            }
            else
            {
                Total = new Ultils().FormatFileSize(size);
            }

            //'Build full version of info string
            message = msg;

            if (message != "")
            {
                message = message + "<BR>";
            }

            switch (msgType)
            {
                case MessageType.InfoMsg:
                    message = "<b>" + (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_ACTION") + ":</b> " + message + " ";
                    break;
                case MessageType.ErrorMsg:
                    message = "<font class='ErrorMessage'><b>" + (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_ERROR") + ":</b> " + message + "</font>";
                    break;
            }
            Info.Text = message + "<b>" + (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_DIRS") + "</b> " + NumDir + " | <b>" + (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILES") + ":</b> " +
                                 NumFiles + " | <b>" + (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_TOTAL") + "</b> " + Total;

            //'If show an error, show also a message box
            if (msgType == MessageType.ErrorMsg)
            {
                wmbMessage.Enabled = true;
                wmbMessage.MessageBoxTitle = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_ERROR");
                //'Because the Web MessageBox component emits code in VBScript,
                //'we need to prevent double quotes from being considered as 
                //'language elements. So, replace them with single quotes. 
                wmbMessage.MessageBoxText = msg.Replace("\"\"", "'");
            }
        }
        private string GenerateThumbnail(string fileName)
        {  
            string FullName = "";
            string ThumbName = "";
            string FullPhysThumbPath = "";
            double ratio = 0;

            FullName = Request.MapPath(currentPath + fileName);

            FullPhysThumbPath = Request.MapPath(new Ultils().AddSlashInTheEndIfNotPresent(currentPath) + thumbPath);
            //'Thumbnails directory should be created in the Reload procedure
            //'that is always called earlier than this one. 

            System.Drawing.Image.GetThumbnailImageAbort dummyCallBack;
            dummyCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbNailCallback);

            System.Drawing.Image fullSizeImg;
            fullSizeImg = System.Drawing.Image.FromFile(FullName);

            int w = fullSizeImg.Width;
            int h = fullSizeImg.Height;

            //'Wider than higher
            if ((w > 100 || h > 100))
            {
                if ((w > h))
                {
                    ratio = w / h;
                    w = 100;
                    h = Convert.ToInt32(100 / ratio);

                    //'Higher than wider
                }
                else if (w < h)
                {

                    ratio = w / h;
                    h = 100;
                    w = Convert.ToInt32(100 * ratio);

                    //'Square but greater than 100
                }
                else if (w > 100)
                {
                    w = 100;
                    h = 100;
                }
            }

            //Bitmap myBitmap = new Bitmap(w, h, PixelFormat.Format32bppRgb);
            //System.Drawing.Image orImg = System.Drawing.Image.FromFile(FullName);
            //myBitmap.SetResolution(orImg.HorizontalResolution, orImg.VerticalResolution);

            //Graphics grImage = Graphics.FromImage(myBitmap);
            //grImage.Clear(Color.White);
            //grImage.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //grImage.DrawImage(orImg, new Rectangle(0, 0, w, h), new Rectangle(0, 0, orImg.Width, orImg.Height), GraphicsUnit.Pixel);
            //grImage.Dispose();

            //myBitmap.Save(FullPhysThumbPath + "\\" + fileName);

            System.Drawing.Image ThumbNailImg = fullSizeImg.GetThumbnailImage(w, h, dummyCallBack, IntPtr.Zero);

            ThumbName = Path.GetFileNameWithoutExtension(fileName) + ".jpg";
            try
            {
                ThumbNailImg.Save(FullPhysThumbPath + "\\" + ThumbName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (UnauthorizedAccessException ex)
            {
                ShowInfo((string)this.GetGlobalResourceObject("Lang", "LOC_ERROR_CREATE_THUMBNAIL_ACCESSDENIED"), MessageType.ErrorMsg);
                return "";
            }
            catch (Exception ex)
            {
                ShowInfo((string)this.GetGlobalResourceObject("Lang", "LOC_ERROR_CREATE_THUMBNAIL") + " " + ex.Message, MessageType.ErrorMsg);
                return "";
            }

            ThumbNailImg.Dispose();
            fullSizeImg.Dispose();

            return currentPath + thumbPath + ThumbName;
        }
        private void SelectFile(string FileName)
        {
            if (useAppRelPath)
            {
                //'return file path relative to the web root folder
                FileName = currentPath + FileName;
            }
            else
            {
                //'Return file path relative to the working (upload) folder 
                FileName = currentPath.Replace(rootPath, "") + FileName;
            }

            StringBuilder strjscript = new StringBuilder("<script language='javascript'>" + "\n", 2000);
            strjscript.Append("if (window.opener == null) ");
            strjscript.Append("  { window.close(); }" + "\n");
            strjscript.Append("else " + "\n");
            strjscript.Append("{" + "\n");
            strjscript.Append("  var vCallerDocument = window.opener.document; " + "\n" + " var vItem;" + "\n");
            strjscript.Append("  vItem = vCallerDocument.getElementById('" + fPTextBoxID + "');" + "\n");
            strjscript.Append("  vItem.value = '" + FileName + "';" + "\n");
            strjscript.Append("}" + "\n");
            strjscript.Append("window.close();" + "\n");
            strjscript.Append("\n" + "</script>");

            Page.RegisterStartupScript("UpdateCaller", strjscript.ToString());
        }
        protected void Paste(Object sender, ImageClickEventArgs e)
        {
            //'Leave the edit mode if we're there
            dgExplorer.EditItemIndex = -1;

            //'Exit if there was no Copy or Cut operation
            if (operation == "")
            {
                return;
                ShowInfo("There are no files or folders to paste. Select necessary files and click Copy or Cut button on the toolbar.");
            }

            if (operation == "Copy")
            {
                PasteCopyFiles();
            }
            else
            {
                PasteCutFiles();
            }

            //'Show directories and files in the DataGrid
            Reload();
        }
        protected void Cut(Object sender, ImageClickEventArgs e)
        {
            ArrayList AllFiles;
            AllFiles = new ArrayList();


            CheckBox chk;
            int i = 0;

            if (allowMove)
            {

                if (dgExplorer.EditItemIndex == -1)
                {

                    i = 0;
                    //'Loop through rows of the DataGrid looking for checked files or folders
                    foreach (DataGridItem dgItem in dgExplorer.Items)
                    {
                        chk = (CheckBox)dgItem.FindControl("chkSelected");
                        if (chk.Checked)
                        {
                            LinkButton lnk = (LinkButton)dgItem.FindControl("Name");
                            AllFiles.Add(lnk.Text);
                            i += 1;
                        }
                    }

                    //'Save list of files and directories to copy in state bag
                    if (AllFiles.Count > 0)
                    {
                        pathCopy = currentPath;
                        operation = "Cut";
                        fileList = AllFiles;
                    }

                    //'Show the last action to user
                    ShowInfo(i.ToString() + " " + (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILESCUT"));
                }
                else
                {
                    ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_LABEL_EDITMODEWARNING"), MessageType.ErrorMsg);
                }
            }
        }
        protected void NewFolder(Object sender, ImageClickEventArgs e)
        {
            //'Leave the edit mode if we're there
            dgExplorer.EditItemIndex = -1;

            if (allowCreateDirs)
            {
                string Path = "";
                Path = Server.MapPath(currentPath) + "\\" + (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_NEWFOLDER");

                int i = 0;
                while (Directory.Exists(Path))
                {
                    i += 1;
                    Path = Server.MapPath(currentPath) + "\\" + (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_NEWFOLDER") + " (" + i + ")";
                }

                //'Create a folder
                try
                {
                    Directory.CreateDirectory(Path);
                }
                catch (UnauthorizedAccessException ex)
                {
                    ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_CREATE_DIRECTORY_ACCESSDENIED"), MessageType.ErrorMsg);
                    return;
                }
                catch (Exception ex)
                {
                    ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_CREATE_DIRECTORY") + " " + ex.Message, MessageType.ErrorMsg);
                    return;
                }
                //'Show directories and files in the DataGrid
                Reload();

                //'Show the last action to user
                ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_LABEL_1NEWFOLDERCREATED"));
            }
        }
        protected  void Delete(Object sender, ImageClickEventArgs e)
        {

            string path = "";
            int i = 0;
            string name = "";

            if (dgExplorer.EditItemIndex == -1)
            {

                if (allowDelete)
                {
                    //'Loop through the items of the DataGrid
                    foreach (DataGridItem dgItem in dgExplorer.Items)
                    {
                        CheckBox chk = (CheckBox)(dgItem.FindControl("chkSelected"));
                        if (chk.Checked)
                        {
                            i += 1;
                            LinkButton lnk = (LinkButton)dgItem.FindControl("Name");
                            name = lnk.Text;
                            path = currentPath + name;
                            path = Server.MapPath(path);
                            //'Delete a file is exist
                            if (File.Exists(path))
                            {
                                FileInfo fi = new FileInfo(path);
                                try
                                {
                                    fi.Delete();
                                }
                                catch (UnauthorizedAccessException ex)
                                {
                                    ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_DELETE_FILE_ACCESSDENIED"), name), MessageType.ErrorMsg);
                                    return;
                                }
                                catch (Exception ex)
                                {
                                    ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_DELETE_FILE"), name) + " " + ex.Message, MessageType.ErrorMsg);
                                    return;
                                }
                            }
                            else if (Directory.Exists(path))
                            {
                                //'Delete a directory and its contents is exist
                                DirectoryInfo di = new DirectoryInfo(path);
                                try
                                {
                                    di.Delete(true);
                                }
                                catch (UnauthorizedAccessException ex)
                                {
                                    ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_DELETE_DIRECTORY_ACCESSDENIED"), name), MessageType.ErrorMsg);
                                    return;
                                }
                                catch (Exception ex)
                                {
                                    ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_DELETE_DIRECTORY_FILE"), name) + " " + ex.Message, MessageType.ErrorMsg);
                                    return;
                                }
                            }
                        }
                    }

                    //'Show files and directories in the DataGrid
                    Reload();

                    //'Show the last action to user
                    ShowInfo(i.ToString() + " " + (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILESDELETED"));
                }
                else
                {
                    ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_LABEL_EDITMODEWARNING"), MessageType.ErrorMsg);
                }
            }
        }
        protected void Refresh(Object sender, ImageClickEventArgs e)
        {
            dgExplorer.EditItemIndex = -1;

            Reload();

            ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_LABEL_REFRESHED"));
        }
        protected void ReverseCheck(Object sender, ImageClickEventArgs e)
        {

            int i = 0;
            //'Loop through the rows of the DataGrid
            foreach (DataGridItem dgItem in dgExplorer.Items)
            {
                CheckBox chk = (CheckBox)dgItem.FindControl("chkSelected");
                chk.Checked = !chk.Checked;
                if (chk.Checked)
                {
                    i += 1;
                }
            }

            //'Show the last action to user
            ShowInfo(i.ToString() + " " + (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILESCHECKED"));
        }        
        protected void ToggleThumbnails(Object sender, ImageClickEventArgs e)
        {

            showThumbnails = !showThumbnails;

            //'Apply changes
            Reload();
        }
        protected void UnZipHere(Object sender, EventArgs e)
        {
            ArrayList AllFiles = new ArrayList();

            int i = 0;
            int k = 0;
            //'Loop through rows of the DataGrid looking for checked items
            foreach (DataGridItem dgItem in dgExplorer.Items)
            {
                CheckBox chk = (CheckBox)dgItem.FindControl("chkSelected");
                //'If checked
                if (chk.Checked)
                {
                    LinkButton lnk = (LinkButton)(dgItem.FindControl("Name"));
                    string FileName = lnk.Text;
                    //'If not a directory
                    Label lbl = (Label)dgItem.FindControl("Length");
                    if (lbl.Text != "Dir")
                    {
                        //'If extension is .zip
                        if ((Path.GetExtension(FileName)).ToLower() == ".zip")
                        {
                            i += 1;
                            k += UnZip(Server.MapPath(currentPath) + "\\" + FileName, false);
                        }
                    }
                }
            }

            Reload();

            //'Show the last action to user
            ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILESUNZIPPED"), i.ToString(), k.ToString()));
        }
        protected void UnZip(Object sender, EventArgs e)
        {
            int i = 0;
            int k = 0;
            //'Loop through rows of the DataGrid looking for checked Items
            foreach (DataGridItem dgItem in dgExplorer.Items)
            {
                CheckBox chk = (CheckBox)dgItem.FindControl("chkSelected");
                //'If checked
                if (chk.Checked)
                {
                    LinkButton lnk = (LinkButton)(dgItem.FindControl("Name"));
                    string FileName = lnk.Text;
                    //'If not a directory
                    if (FileName != "Dir")
                    {
                        //'If extension is .zip
                        if ((Path.GetExtension(FileName)).ToLower() == ".zip")
                        {
                            i += 1;
                            k += UnZip(Server.MapPath(currentPath) + "\\" + FileName, true);
                        }
                    }
                }
            }
            Reload();

            //'Show the last action to user
            ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILESUNZIPPED"), i.ToString(), k.ToString()));
        }        
        protected int UnZip(string ZipFileName, bool CreateDir)
        {

            ZipReader reader = null;
            int i = 0;

            //'Figure out new directory name for the uncompressed files
            string NewPath = "";
            NewPath = ZipFileName.Replace(Path.GetExtension(ZipFileName), "");

            //'Make a directory with the name of the zip file. Overwritten if exists.
            if (CreateDir == true)
            {
                Directory.CreateDirectory(NewPath);
            }
            else
            {
                NewPath = Path.GetDirectoryName(NewPath);
            }

            try
            {
                //'Open a zip file
                reader = new ZipReader(ZipFileName);
                //'Process all files inside the archive
                while (reader.MoveNext())
                {
                    i += 1;
                    //'Create a Zip object
                    ZipEntry entry = reader.Current;

                    if (!entry.IsDirectory)
                    {
                        //'It's a file
                        string FileName = entry.Name.Replace("/", "\\");
                        //'If entry is Directory, create it
                        if (FileName.IndexOf("\\") > 0)
                        {
                            //'If Directory exists, it is not overwritten
                            try
                            {
                                Directory.CreateDirectory(NewPath + "\\" + Path.GetDirectoryName(FileName));
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_CREATE_DIRECTORY_ACCESSDENIED"), MessageType.ErrorMsg);
                                return 0;
                            }
                            catch (Exception ex)
                            {
                                ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_CREATE_DIRECTORY") + " " + ex.Message, MessageType.ErrorMsg);
                                return 0;
                            }
                        }

                        //'Uncompress the file if its type is not forbidden
                        //'for upload
                        if (IsAllowedFileType(Path.GetExtension(FileName)))
                        {
                            FileStream Writer = null;
                            try
                            {
                                Writer = File.Open(NewPath + "\\" + FileName, FileMode.Create);

                                Byte[] buffer = new Byte[4096];
                                int byteCount = 0;

                                //'Read file from the archive and write it to the disk 
                                byteCount = reader.Read(buffer, 0, buffer.Length);
                                while (byteCount > 0)
                                {
                                    Writer.Write(buffer, 0, byteCount);
                                    byteCount = reader.Read(buffer, 0, buffer.Length);
                                }
                            }
                            finally
                            {
                                //'Close the file        
                                Writer.Close();
                            }
                        }
                    }
                }
            }

            catch (UnauthorizedAccessException ex)
            {
                ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_ZIP_CANNOTEXTRACT_ACCESSDENIED"), MessageType.ErrorMsg);
                return i;
            }
            catch (Exception ex)
            {
                ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_COPY_CANNOTEXTRACT") + " " + ex.Message, MessageType.ErrorMsg);
                return i;
            }
            finally
            {
                //'Close the Zip file
                reader.Close();
            }


            //'Return the number of files produced
            return i;
        }
        private void SaveStateData()
        {
            ViewState["rootPath"] = rootPath;
            ViewState["currentPath"] = currentPath;
            ViewState["rowToSelect"] = rowToSelect;
            ViewState["pathCopy"] = pathCopy;
            ViewState["operation"] = operation;
            ViewState["currentPathAux"] = currentPathAux;
            ViewState["rootPathAux"] = rootPathAux;
            ViewState["fileToRename"] = fileToRename;
            ViewState["sortField"] = sortField;
            ViewState["sortDirection"] = sortDirection;
            ViewState["showThumbnails"] = showThumbnails;

            if (!Page.IsPostBack)
            {
                //'The first load: save configuration variables read from Session 
                //'variables into the ViewState (see the explanation above, in the 
                //'sub LoadStateData) 
                ViewState["fpAllowedUploadFileExts"] = allowedUploadFileExts;
                ViewState["fpUploadSizeLimit"] = uploadSizeLimit;
                ViewState["fpAllowUpload"] = allowUpload;
                ViewState["fpAllowCreateDirs"] = allowCreateDirs;
                ViewState["fpAllowDelete"] = allowDelete;
                ViewState["fpAllowRename"] = allowRename;
                ViewState["fpAllowChangeLanguage"] = allowChangeLanguage;
                ViewState["fpAllowCopy"] = allowCopy;
                ViewState["fpAllowMove"] = allowMove;
                ViewState["fpUseAppRelPath"] = useAppRelPath;
            }

            if (foundFiles != null) ViewState["foundFiles"] = foundFiles;
            if (fileList != null) ViewState["fileList"] = fileList;
        }
        void SaveUploadedFile()
        {
            if (!(inputFileName.PostedFile == null))
            {
                try
                {
                    string strPath = Server.MapPath(currentPath);

                    string FileName = new Ultils().AddBackSlashInTheEndIfNotPresent(strPath) + Path.GetFileName(inputFileName.PostedFile.FileName);

                    //'Delete the file if already exists but overwriting is not
                    //'disabled
                    if (File.Exists(FileName))
                    {
                        if (chkOverwrite.Checked)
                        {
                            FileInfo fi = new FileInfo(FileName);
                            fi.Delete();
                        }
                        else
                        {
                            ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_UPLOAD_FILEEXISTS"), inputFileName.PostedFile.FileName), MessageType.ErrorMsg);
                            return;
                        }
                    }

                    //'Save the uploaded file          
                    inputFileName.PostedFile.SaveAs(FileName);

                    //'Get the file extension
                    string Extension = (Path.GetExtension(FileName)).ToLower();

                    //'If extension is .zip then extract the archive
                    if (Extension == ".zip")
                    {
                        int i = 0;

                        switch (rblUploadOptions.SelectedIndex)
                        {
                            case 0:
                                //'Unzip + Delete
                                i = UnZip(FileName, true);
                                File.Delete(FileName);
                                //'Show the last action on server
                                ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang", "LOC_LABEL_1FILEUPLOADEDWITHFILES"), i.ToString()));
                                break;
                            case 1:
                                //'Unzip the file
                                i = UnZip(FileName, true);
                                //'Show the last action on server
                                ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang", "LOC_LABEL_1FILEUPLOADEDWITHFILES"), i.ToString()));
                                break;
                            case 2:
                                //'Only upload
                                //'Show the last action to user
                                ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_LABEL_1FILEUPLOADED"));

                                //'Select the file and close the window if user
                                //'needs it 
                                if (chkSelectUponUpload.Checked)
                                {
                                    SelectFile(Path.GetFileName(inputFileName.PostedFile.FileName));
                                }
                                break;
                        }
                    }
                    else
                    {
                        //'Show the last action to user
                        ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_LABEL_1FILEUPLOADED"));

                        //'Select the file and close the window if user
                        //'needs it 
                        if (chkSelectUponUpload.Checked)
                        {
                            SelectFile(Path.GetFileName(inputFileName.PostedFile.FileName));
                        }
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_UPLOAD_ACCESSDENIED"), MessageType.ErrorMsg);
                }
                catch (Exception ex)
                {
                    ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_UPLOAD") + " " + ex.Message, MessageType.ErrorMsg);
                }
            }
        }
        protected void uploadFile(Object sender, EventArgs e)
        {
            if (allowUpload)
            {
                //'Leave the edit mode if we're there
                dgExplorer.EditItemIndex = -1;

                //'Check if the file belongs to one of allowed types and its size
                //'doesn't exceed max size permitted
                if (IsAllowedFileType(Path.GetExtension(inputFileName.PostedFile.FileName)))
                {
                    if (IsFileSizeOk())
                    {
                        SaveUploadedFile();
                        Reload();
                    }
                    else
                    {
                        ShowInfo(String.Format((string)this.GetGlobalResourceObject("Lang", "LOC_ERROR_TOOLARGEFILE"), new Ultils().FormatFileSize(uploadSizeLimit)), MessageType.ErrorMsg);
                    }
                }
                else
                {
                    ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_INVALIDEXTENSION"), MessageType.ErrorMsg);

                }
            }
        }
        private bool IsFileSizeOk()
        {

            if (uploadSizeLimit > 0 && inputFileName.PostedFile.ContentLength > uploadSizeLimit )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected void ShowUpload(Object sender, ImageClickEventArgs e)
        {

            PanelUpload.Visible = !PanelUpload.Visible;
        }        
        protected void ShowDownload(Object sender, ImageClickEventArgs e)
        {
            PanelUpload.Visible = false;
        }
        protected void Created(Object sender, DataGridItemEventArgs e)
        {

            //'Adjust appearance and behavior of the file list 
            if (rowToSelect != "" && rowToSelect != null)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    //'Try to cast the item to a datarowview. It's not always possible.

                    DataRowView rowview = (DataRowView)e.Item.DataItem;
                    if (rowToSelect == Convert.ToString(rowview["Name"]))
                    {
                        //'Set the background color
                        e.Item.Attributes.Add("bgcolor", "#FEDC8C");

                        rowToSelect = "";

                        string scriptString = "";
                        string Link = "";
                        Link = Convert.ToString(dgExplorer.DataKeys[e.Item.ItemIndex]);
                        scriptString = "<script language=JavaScript>" +
                                       "location.href='#" + Link + "'" +
                                       "</script>";
                        RegisterStartupScript("SelectRow", scriptString);
                    }
                    else
                    {
                        if (e.Item.ItemType == ListItemType.AlternatingItem)
                        {
                            e.Item.Attributes.Add("bgcolor", "LightYellow");
                        }
                    }

                }
            }
            else
            {
                if (e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    e.Item.Attributes.Add("bgcolor", "LightYellow");
                }
            }

            //'Localize Download and Renaming buttons (rename, update + cancel)           
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton imgButton1 = (ImageButton)e.Item.Cells[4].FindControl("btnRename");
                if (imgButton1 != null)
                {
                    imgButton1.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILELIST_RENAME");
                }

                ImageButton imgButton2 = (ImageButton)e.Item.Cells[4].FindControl("btnDownload");
                if (imgButton2 != null)
                {
                    //'Set appropriate tool tip text for files and folder
                    if ((string)(DataBinder.Eval(e.Item.DataItem, "Type")) == "D")
                    {
                        //'Set tool tip text for folders
                        imgButton2.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILELIST_DOWNLOADFOLDER");
                    }
                    else
                    {
                        //'Set tool tip text for files
                        imgButton2.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILELIST_DOWNLOADFILE");
                    }
                }
            }
            else if (e.Item.ItemType == ListItemType.EditItem)
            {
                ImageButton imgButton3 = (ImageButton)e.Item.Cells[4].FindControl("btnRenameOk");
                if (imgButton3 != null)
                {
                    imgButton3.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILELIST_UPDATE");
                }

                ImageButton imgButton4 = (ImageButton)e.Item.Cells[4].FindControl("btnRenameCancel");
                if (imgButton4 != null)
                {
                    imgButton4.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILELIST_CANCEL");
                }
            }

            //'Localize the "Select All" checkbox
            if (e.Item.ItemType == ListItemType.Header)
            {
                CheckBox chkAll = (CheckBox)e.Item.FindControl("chkSelectAll");
                chkAll.ToolTip = (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_FILELIST_SELECTALL");
            }
        }
        protected void ItemCommand(Object sender, DataGridCommandEventArgs e)
        {
            if(e.CommandName == "Download" )
            {
                LinkButton lnk = (LinkButton)e.Item.FindControl("Name");
                DownloadItem(lnk.Text);
            }
        }
        void DownloadItem(string Filename)
        {
            String PhysFilePath = "";
            String ZipFileName = "";
            String PhysZipFileName = "";
            ArrayList FileList = new ArrayList();

            //'Figure out the full path for the file/folder
            string CurrentPhysPath = Server.MapPath(currentPath);
            CurrentPhysPath = new Ultils().AddBackSlashInTheEndIfNotPresent(CurrentPhysPath);
            PhysFilePath = CurrentPhysPath + Filename;

            //'Check what we're downloading -- a file or a folder
            if (File.Exists(PhysFilePath))
            {
                //'Download a file
                //'Send the file to the client
                SendFileToClient(PhysFilePath);
            }
            else if (Directory.Exists(PhysFilePath))
            {
                //'Download a folder
                //'Zip (compress) the folder and all the subfolders and send the 
                //'archive to the client
                FileList.AddRange(GetFileList(PhysFilePath, "*.*"));
                ZipFileName = Filename + ".zip";
                PhysZipFileName = ZipFiles(FileList, CurrentPhysPath + tempPath, ZipFileName);
                if (FileList.Count > 0)
                {
                    if (PhysZipFileName != string.Empty)
                    {
                        //'Send the Zip file to user
                        SendFileToClient(PhysZipFileName);
                    }
                }
                else
                {
                    ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_NOFILESTOCOMPRESS"), MessageType.ErrorMsg);
                }
            }
        }
        void SendFileToClient(string PhysFilePath)
        {
            FileInfo myFile = new FileInfo(PhysFilePath);
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Length", myFile.Length.ToString());
            Response.AppendHeader("content-disposition", "attachment; filename=" + System.IO.Path.GetFileName(PhysFilePath));
            Response.WriteFile(PhysFilePath);
            Response.End();
        }
        protected void Edit(Object sender, DataGridCommandEventArgs e)
        {
            //'Turn the DataGrid into the edit mode
            dgExplorer.EditItemIndex = (int)(e.Item.ItemIndex);

            //'Get the name of the directory or file and save it into the state bag,
            //'so we know what file to rename.
            LinkButton lnk = (LinkButton)e.Item.FindControl("Name");
            fileToRename = lnk.Text;
            //TextBox name = (TextBox)e.Item.FindControl("Name");
            //fileToRename = name.Text;

            //'Get the client Id of file name edit control
            string clientEdit = "";
            clientEdit = lnk.ClientID;
            //clientEdit = name.ClientID;
            //'Focus it and select the current filename
            string scriptString = "";
            scriptString = "<script language=JavaScript>" +
                          "formExplorer." + clientEdit + ".focus();" +
                          "formExplorer." + clientEdit + ".select();" +
                          "</script>";

            RegisterStartupScript("Startup", scriptString);

            Reload();
        }        
        protected void Cancel(Object sender, DataGridCommandEventArgs e)
        {
            //'Leave the edit mode
            dgExplorer.EditItemIndex = -1;

            //'Show the Directories and Files in the DataGrid
            Reload();
        }        
        protected void Update(Object sender, DataGridCommandEventArgs e)
        {

            if( allowRename )
            {
                //'Get the new name
                string NewName = "";
                TextBox txtName = (TextBox) e.Item.FindControl("Name");
                NewName = txtName.Text.ToLower();

                //'Make a list with forbidden names in Windows
                string ForbiddenNames = "";
                ForbiddenNames = "aux;con;com1;com2;com3;com4;prn;lpt1;lpt2;";

                //'If the new name is in the forbidden list, do nothing  
                //'and exit the procedure
                if( ForbiddenNames.IndexOf(NewName + ";") > 0 )
                {
                    dgExplorer.EditItemIndex = -1;
                    ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_NOTVALIDNAME"), MessageType.ErrorMsg);
                    Reload();
                    return;
                }

                //'Get the current path
                string Path = "";
                Path = Server.MapPath(currentPath);

                //'Get the old file or directory name

                string OldName = new Ultils().AddBackSlashInTheEndIfNotPresent(Path) + fileToRename;

                //'Figure out the full path for the new name
                NewName = new Ultils().AddBackSlashInTheEndIfNotPresent(Path) + txtName.Text;

                //'Check if the file extension is in the list of forbidden 
                //'extensions
                if( File.Exists(OldName) )
                { 
                        //'ensure this is a file, not a folder
                    if(!IsAllowedFileType(System.IO.Path.GetExtension(NewName)) )
                    {
                        dgExplorer.EditItemIndex = -1;
                        ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_INVALIDEXTENSION"), MessageType.ErrorMsg);
                        Reload();
                        return;
                    }
                }

                //'If the directory or the file exists, try to change the name
                if( File.Exists(OldName) )
                {
                    try
                    {
                        File.Move(OldName, NewName);
                        ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_LABEL_1FILERENAMED"));
                    }
                    catch(UnauthorizedAccessException ex)
                    {
                        ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_RENAME_FILE_ACCESSDENIED"), MessageType.ErrorMsg);
                    }
                    catch(Exception ex)
                    {
                        ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_RENAMINGFILE") + " " + ex.Message, MessageType.ErrorMsg);
                    }
                }
                else if (Directory.Exists(OldName) )
                {
                    try
                    {

                        Directory.Move(OldName, NewName);
                        ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_LABEL_1DIRECTORYRENAMED"));
                    }
                    catch(UnauthorizedAccessException exception)
                    {
                        ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_RENAME_DIRECTORY_ACCESSDENIED"), MessageType.ErrorMsg);
                    }
                    catch(Exception ex)
                    {
                        ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_RENAME_DIRECTORY") + " " + ex.Message, MessageType.ErrorMsg);
                    }
                }
            }

            //'Leave edit mode
            dgExplorer.EditItemIndex = -1;
            Reload();
        }        
        public string ZipFiles(ArrayList FileList, string PhysZipPath, string ZipFileName)
        {
            //'If there are no checked files then return

            string PhysZipFilePath = "";

            if (FileList.Count == 0)
            {
                return String.Empty;
            }

            //'If the directory to place Zip file doesn't exist, create it
            if (!Directory.Exists(PhysZipPath))
            {
                Directory.CreateDirectory(PhysZipPath);
            }

            //'Figure out full file name and path for the Zip file
            if (ZipFileName == String.Empty)
            {
                //'If name of the Zip file is not provided
                PhysZipFilePath = new Ultils().AddBackSlashInTheEndIfNotPresent(PhysZipPath) + Path.GetFileNameWithoutExtension(Convert.ToString(FileList[0])) + ".zip";
                int i = 0;
                //'If this name already exists, create an unique name
                while (File.Exists(PhysZipFilePath))
                {
                    i += 1;
                    PhysZipFilePath = new Ultils().AddBackSlashInTheEndIfNotPresent(PhysZipFilePath) + Path.GetFileNameWithoutExtension(Convert.ToString(FileList[0]) + "(" + i + ")" + ".zip");
                }
            }
            else
            {
                //'If name of the Zip file is provided, 
                //'just construct physical path for the file
                PhysZipFilePath = new Ultils().AddBackSlashInTheEndIfNotPresent(PhysZipPath) + ZipFileName;
            }

            //'Create an empty zip file
            ZipWriter writer = new ZipWriter(PhysZipFilePath);

            //'Prepare a buffer to write       
            Byte[] buffer = new Byte[4096];
            int byteCount = 0;
            FileStream reader = null;
            string filezipstore = "";
            ZipEntry entry;

            int k = 0;

            try
            {
                foreach (string Item in FileList)
                {
                    k += 1;
                    filezipstore = Item.Replace(Server.MapPath(currentPath), "");
                    entry = new ZipEntry(filezipstore);
                    entry.ModifiedTime = File.GetLastWriteTime(Item);
                    writer.AddEntry(entry);

                    try
                    {
                        reader = File.OpenRead(Item);

                        //'Read from file until the end and write it into zip file
                        byteCount = reader.Read(buffer, 0, buffer.Length);

                        while (byteCount > 0)
                        {
                            //'Write to file compress bytes
                            writer.Write(buffer, 0, byteCount);
                            byteCount = reader.Read(buffer, 0, buffer.Length);
                        }
                    }
                    finally
                    {
                        //'Close the file        
                        reader.Close();
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_ZIP_CANNOTCREATE_ACCESSDENIED"), MessageType.ErrorMsg);
                return "";
            }
            catch (ArgumentException ex)
            {
                ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_ZIP_CANNOTCREATE_WRONGNAME"), MessageType.ErrorMsg);
                return "";
            }
            catch (Exception ex)
            {
                ShowInfo((string)this.GetGlobalResourceObject("Lang","LOC_ERROR_COPY_CANNOTCREATE") + " " + ex.Message, MessageType.ErrorMsg);
                return "";
            }
            finally
            {
                //'Close the zip file 
                writer.Close();
            }

            return PhysZipFilePath;
        }
        protected override void  OnPreRender(EventArgs e)
        {
 	         base.OnPreRender(e);
             SaveStateData();
            DisableForbiddenActions();
        }        
        protected void Sort(Object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {

            if (sortField == Convert.ToString(e.SortExpression))
            {
                if (sortDirection == "ASC")
                {
                    sortDirection = "DESC";
                }
                else
                {
                    sortDirection = "ASC";
                }
            }
            else
            {
                sortField = Convert.ToString(e.SortExpression);
            }


            Reload();
        }
        private bool IsAllowedFileType(String fileExt)
        {
            if (allowedUploadFileExts != String.Empty)
            {
                //'get an array of allowed exts
                string[] AllowedExts = allowedUploadFileExts.Split(',');

                //'Check if the file extension conforms the restrictions
                //'Remove a dot from the file extension
                fileExt = fileExt.Replace(".", "");
                fileExt = fileExt.Trim();
                foreach (String ext in AllowedExts)
                {
                    //'Remove a dot form a restricting extension (if is)
                    string CleanExtension = ext.Replace(".", "");
                    CleanExtension = CleanExtension.Trim();
                    if (fileExt.ToLower() == CleanExtension.ToLower())
                    {
                        return true;
                    }
                }
            }
            else
            {
                return true;
            }

            return false;
        }
        ArrayList GetFileList(string Path, String Mask)
        {

            ArrayList AllFiles = new ArrayList();

            //'Add files in the directory to ArrayList             
            foreach (string filename in Directory.GetFiles(Path, Mask))
            {
                AllFiles.Add(filename);
            }

            //'Add files in the subfolders
            foreach (string directoryname in Directory.GetDirectories(Path))
            {
                AllFiles.AddRange(GetFileList(directoryname, Mask));
            }

            //'Return the list
            return AllFiles;
        }        
        private void DisableForbiddenActions()
        {
            if (!allowCreateDirs)
            {
                btnNewFolder.Enabled = false;
                btnNewFolder.ImageUrl = "Images/NewFolderOff.gif";
            }

            if (!allowDelete)
            {
                btnDelete.Enabled = false;
                btnDelete.ImageUrl = "Images/DeleteOff.gif";
            }

            if (!allowUpload)
            {
                btnUpload.Enabled = false;
                btnUpload.ImageUrl = "Images/UploadOff.gif";
            }

            if (!allowCopy)
            {
                btnCopy.Enabled = false;
                btnCopy.ImageUrl = "Images/CopyOff.gif";
            }

            if (!allowMove)
            {
                btnCut.Enabled = false;
                btnCut.ImageUrl = "Images/CutOff.gif";
            }

            if (!allowMove && !allowCopy)
            {
                btnPaste.Enabled = false;
                btnPaste.ImageUrl = "Images/PasteOff.gif";
            }

            phLanguageSelector.Visible = allowChangeLanguage;

            //'Apply securiry setting for renaming
            this.dgExplorer.Columns[4].Visible = allowRename;
        }        
        private bool ThumbNailCallback()
        {
            return false;
        }
      
    }  
}
