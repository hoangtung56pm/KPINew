using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using VmgPortal.Library.Components.Commands;
using VmgPortal.Library.Components.Modules;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Utilities;
using VmgPortal.Library;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Text;
namespace Administrator
{
    public partial class _Default : AdminPage
    {
        private string cmd = string.Empty;
        private string _path = string.Empty;
        private int portalid = 0;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            LoadForCurCommand();
        }
        protected override void InitializeCulture()
        {
            if (true)
            {
                String selectedLanguage = "en-US";
                UICulture = selectedLanguage;
                Culture = selectedLanguage;

                Thread.CurrentThread.CurrentCulture =
                    CultureInfo.CreateSpecificCulture(selectedLanguage);
                Thread.CurrentThread.CurrentUICulture = new
                    CultureInfo(selectedLanguage);
            }
            base.InitializeCulture();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoadForCurCommand()
        {
            Control control = null;
            string controlPath = string.Empty;
            cmd = ConvertUtility.ToString(Request.QueryString["cmd"]);
            CommandInfo command = null;
            if (cmd != string.Empty)
            {
                command = CommandController.GetCommand(cmd);
                if (command != null)
                {
                    lbcmd.Text = command.CommandName;
                    //lblTitle.Text = command.CommandName;
                }
            }
            if (command == null)
            {
                controlPath = "/UserControls/WelCome.ascx";
            }
            else if (!CurrentUser.IsSuperAdmin && !CommandController.IsAvailableForUser(command.CommandID, CurrentUser.UserID, ConvertUtility.ToInt32(Request.QueryString["portalid"])))
            {
                controlPath = "/UserControls/AccessDeny.ascx";
            }
            else if (File.Exists(Server.MapPath(command.ControlPath)))
            {
                control = LoadAdminControl(command.CommandKey);
            }

            if (controlPath != string.Empty)
            {
                control = LoadControl(controlPath);
            }
            if (control != null)
            {
                this.placeControls.Controls.Add(control);
            }
            else
            {
                lblErrorMessage.Text = "Không tìm thấy module !";
            }
        }

        protected ModuleControlBase LoadAdminControl(string controlKey)
        {
            ModuleControlInfo moduleControl = ModuleControlController.GetModuleControl(controlKey);
            if (moduleControl != null)
            {
                if (File.Exists(Server.MapPath(moduleControl.ControlPath)))
                {
                    try
                    {
                        ModuleControlBase controlToLoad = (ModuleControlBase)LoadControl(moduleControl.ControlPath);
                        controlToLoad.ControlID = moduleControl.ControlID;
                        return controlToLoad;
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }
            }
            return null;
        }

    }
}
