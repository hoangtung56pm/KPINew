using System;
using System.Data;
using System.Web.UI.WebControls;
using VmgPortal.Library.Components.Commands;
using VmgPortal.Library.Components.Modules;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Utilities;
using VmgPortal.Library;
using VmgPortal.Library.Components.Lang;
using ComponentArt.Web.UI;
using log4net;

namespace VmgPortal.Administrator.Commands
{
    public partial class CommandDefinition : AuthenticatedControl
    {
        string nodePath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUpdateStatus.Text = string.Empty;
            if (!CurrentUser.IsSuperAdmin) Response.Redirect(AppEnv.ADMIN_CMD);
            if (!Page.IsPostBack)
            {
                MiscUtility.FillIndex(dropIndex, 30, 1);
                DataTable dtPortalByLang = null;

                dgrNameFollowLang.DataSource = builddata(dtPortalByLang);
                dgrNameFollowLang.DataBind();
            }

        }
        public DataTable builddata(DataTable dt)
        {
            DataTable dtRebuildData = new DataTable();

            dtRebuildData.Columns.Add("CommandID", typeof(String));
            dtRebuildData.Columns.Add("Lang", typeof(String));
            dtRebuildData.Columns.Add("Language_Name", typeof(String));
            dtRebuildData.Columns.Add("CommandName", typeof(String));
            try
            {

                DataTable dtLang = MainLanguagesController.GetAll();
                int intdtRowsCount = dtLang.Rows.Count;
                for (int i = 0; i < intdtRowsCount; i++)
                {
                    DataRow dr = dtRebuildData.NewRow();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (i <= dt.Rows.Count)
                        {
                            dr["CommandID"] = txtID.Text;
                            dr["Lang"] = dtLang.Rows[i]["Language_Culture"];
                            dr["Language_Name"] = dtLang.Rows[i]["Language_Name"];
                            dr["CommandName"] = dt.Rows[i]["CommandName"];
                        }
                        else
                        {
                            dr["CommandID"] = txtID.Text;
                            dr["Lang"] = dtLang.Rows[i]["Language_Culture"];
                            dr["Language_Name"] = dtLang.Rows[i]["Language_Name"];
                            dr["CommandName"] = "";
                        }
                    }
                    else
                    {
                        dr["CommandID"] = 0;
                        dr["Lang"] = dtLang.Rows[i]["Language_Culture"];
                        dr["Language_Name"] = dtLang.Rows[i]["Language_Name"];
                        dr["CommandName"] = "";
                    }
                    dtRebuildData.Rows.Add(dr);
                }
                return dtRebuildData;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            DataTable dtCommands = CommandController.GetCommands();
            LoadForTreeView(dtCommands);
            LoadForParentItems(dtCommands);
            LoadCommandKeys();
            LoadCommandData();
        }
        private void LoadCommandData()
        {
            if (txtID.Text != string.Empty)
            {
                CommandInfo curCommand = CommandController.GetCommandByLang(ConvertUtility.ToInt32(txtID.Text));
                if (curCommand != null)
                {
                    txtID.Text = curCommand.CommandID.ToString();

                    txtParams.Text = curCommand.CommandParams;
                    //txtName.Text = curCommand.CommandName;
                    txtUrl.Text = curCommand.CommandUrl;
                    MiscUtility.SelectItemFromList(dropParent, curCommand.CommandParentID.ToString());
                    MiscUtility.SelectItemFromList(dropCommandKeys, curCommand.CommandKey);
                    MiscUtility.SelectItemFromList(dropIndex, curCommand.CommandOrder.ToString());
                    chkEnable.Checked = curCommand.CommandEnable;
                    chkVisble.Checked = curCommand.CommandVisible;
                    chkIsSuperUser.Checked = curCommand.IsSuperUser;

                    DataTable dtCommandByLang = CommandController.GetCommandByCmdId(ConvertUtility.ToInt32(txtID.Text));
                    dgrNameFollowLang.DataSource = builddata(dtCommandByLang);
                    dgrNameFollowLang.DataBind();
                }
            }
        }
        private void LoadCommandKeys()
        {
            dropCommandKeys.Items.Clear();
            dropCommandKeys.DataSource = ModuleControlController.GetModuleControlsForCommand();
            dropCommandKeys.DataBind();
            dropCommandKeys.Items.Insert(0, new ListItem("None", " "));
        }
        private void LoadForParentItems(DataTable dtCommands)
        {
            dropParent.Items.Clear();
            CommandController.FillToListBox(dropParent.Items, dtCommands, 0, CurrentUser.IsSuperAdmin);
        }
        private void LoadForTreeView(DataTable dtCommands)
        {
            nodePath = "|";
            TreeViewNode focusNode = tvwCmds.SelectedNode;
            if (focusNode != null)
            {
                while (true)
                {
                    if (focusNode.ParentNode == null) break;
                    else
                    {
                        focusNode = focusNode.ParentNode;
                        nodePath += focusNode.ID + "|";
                    }
                }
            }

            tvwCmds.Nodes.Clear();
            TreeViewNode topRoot = new TreeViewNode();
            topRoot.Text = "Root";
            topRoot.ID = "0";
            tvwCmds.Nodes.Add(topRoot);
            //dtCommands = CommandController.GetCommands();
            DataRow[] drRoots = dtCommands.Select("CommandParentID = 0");
            foreach (DataRow row in drRoots)
            {
                TreeViewNode rootNode = new TreeViewNode();
                rootNode.Text = row["CommandName"].ToString();
                rootNode.Value = row["CommandKey"].ToString();
                rootNode.ID = row["CommandID"].ToString();
                if (nodePath.IndexOf("|" + rootNode.ID + "|") >= 0) rootNode.Expanded = true;
                tvwCmds.Nodes.Add(rootNode);
                LoadForCurCommand(rootNode, dtCommands);
            }
        }
        private void LoadForCurCommand(TreeViewNode curNode, DataTable source)
        {
            int curCommandId = ConvertUtility.ToInt32(curNode.ID);
            DataRow[] drChildCommands = source.Select("CommandParentID = " + curCommandId);

            foreach (DataRow row in drChildCommands)
            {
                TreeViewNode childNode = new TreeViewNode();
                childNode.Text = row["CommandName"].ToString();
                childNode.Value = row["CommandKey"].ToString();
                childNode.ID = row["CommandID"].ToString();
                if (nodePath.IndexOf("|" + childNode.ID + "|") >= 0) childNode.Expanded = true;
                curNode.Nodes.Add(childNode);
                LoadForCurCommand(childNode, source);
            }
        }
        protected void tvwCmds_NodeSelected(object sender, TreeViewNodeEventArgs e)
        {
            txtID.Text = tvwCmds.SelectedNode.ID;
            lblUpdateStatus.Text = string.Empty;
        }
        protected void cmdUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                int commandId = ConvertUtility.ToInt32(txtID.Text);
                CommandInfo command = CommandController.GetCommand(commandId);

                if (command == null)
                {
                    command = CommandController.GetCommandWithoutControlPath(commandId);
                }

                command.CommandParams = txtParams.Text;
                command.CommandUrl = txtUrl.Text;
                command.CommandParentID = ConvertUtility.ToInt32(dropParent.SelectedValue);
                command.CommandKey = dropCommandKeys.SelectedValue;
                command.CommandOrder = ConvertUtility.ToInt32(dropIndex.SelectedValue);
                command.CommandEnable = chkEnable.Checked;
                command.CommandVisible = chkVisble.Checked;
                command.IsSuperUser = chkIsSuperUser.Checked;
                CommandController.UpdateCommand(command);
                int i = 0;
                foreach (DataGridItem item in dgrNameFollowLang.Items)
                {
                    CommandInfo _commandInfo = new CommandInfo();

                    TextBox txtName = (TextBox)item.FindControl("txtName");
                    _commandInfo.CommandName = txtName.Text;

                    _commandInfo.CommandID = commandId;

                    CommandController.UpdateCommandByLang(_commandInfo, item.Cells[1].Text);
                    i++;
                }

                lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;
            }
            catch (Exception ex)
            {
                lblUpdateStatus.Text = ex.Message;
            }
        }
        protected void cmdAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                CommandInfo command = new CommandInfo();
                command.CommandParams = txtParams.Text;
                command.CommandUrl = txtUrl.Text;
                command.CommandParentID = ConvertUtility.ToInt32(dropParent.SelectedValue);
                command.CommandKey = dropCommandKeys.SelectedValue;
                command.CommandOrder = ConvertUtility.ToInt32(dropIndex.SelectedValue);
                command.CommandEnable = chkEnable.Checked;
                command.CommandVisible = chkVisble.Checked;
                command.IsSuperUser = false;

                int commandId = CommandController.AddCommand(command);
                int i = 0;
                foreach (DataGridItem item in dgrNameFollowLang.Items)
                {
                    CommandInfo _commandInfo = new CommandInfo();

                    TextBox txtName = (TextBox)item.FindControl("txtName");
                    _commandInfo.CommandName = txtName.Text;

                    _commandInfo.CommandID = commandId;

                    CommandController.AddCommandByLang(_commandInfo, item.Cells[1].Text);
                    i++;
                }
                lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;
            }
            catch (Exception ex)
            {
                lblUpdateStatus.Text = ex.Message;
            }
        }
        //protected void cmdEmpty_Click(object sender, EventArgs e)
        //{
        //    txtID.Text = string.Empty;
        //    txtParams.Text = string.Empty;
        //    dgrNameFollowLang.DataSource = null;
        //    dgrNameFollowLang.DataBind();  
        //    txtUrl.Text = string.Empty;
        //    chkEnable.Checked = false;
        //    chkVisble.Checked = false;

        //}
        protected void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int commandId = ConvertUtility.ToInt32(txtID.Text);
                CommandController.DeleteCommand(commandId);
                lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;
            }
            catch (Exception ex)
            {
                lblUpdateStatus.Text = ex.Message;
            }
        }
    }
}