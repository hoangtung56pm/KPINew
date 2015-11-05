using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using VmgPortal.Library;
using VmgPortal.Library.Components.Security;
using VmgPortal.Library.Components.Users;
using VmgPortal.Library.Utilities;
using System.Drawing;
using VmgPortal.Modules.KPIData.Library.BoPhan;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;

namespace VmgPortal.Administrator.Users
{
	public partial class UserManagement : AuthenticatedControl
	{
        protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
                ViewState["DropDownPageItems"] = 10;

                //dropDotDanhGia.DataSource = DotDanhGiaController.GetAll(1);
                //dropDotDanhGia.DataBind();

                dropTrungTam.DataSource = BoPhanController.GetAll();
                dropTrungTam.DataBind();
                dropTrungTam.Items.Insert(0, new ListItem("----All----","0"));

                if (!CurrentUser.IsAdmin && !CurrentUser.IsSuperAdmin)
                {
                    btnDeleteSelected.Visible = false;
                    //btnUpdatePhongBan.Visible = false;
                    dtgUsers.Columns[3].Visible = false;
                    dtgUsers.Columns[8].Visible = false;
                    dtgUsers.Columns[9].Visible = false;
                    dropTrungTam.Enabled = false;                    
                }
                dropTrungTam.SelectedValue = CurrentUser.IDTrungTam.ToString();
			}
		}
        private void rptLetters_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lnkLetter = (LinkButton)e.Item.FindControl("lnkLetter");
                lnkLetter.Text = e.Item.DataItem.ToString();
                lnkLetter.CommandArgument = e.Item.DataItem.ToString();

                if (ConvertUtility.ToString(ViewState["Alphabet"]) == e.Item.DataItem.ToString())
                {
                    lnkLetter.Font.Underline = true;
                    lnkLetter.ForeColor = Color.Blue;
                }
            }
        }
        public void rptLetters_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Alpha")
            {
                if (ConvertUtility.ToString(e.CommandArgument) != "All")
                {
                    ViewState["Alphabet"] = e.CommandArgument;
                }
                else
                {
                    ViewState["Alphabet"] = "";
                }
               
            }
        }

        protected string GetTrangThai(object trangthai)
        { 
            if(ConvertUtility.ToInt32(trangthai) == 0) return "Nghỉ việc";
            if(ConvertUtility.ToInt32(trangthai) == 1) return "Chính thức";
            if(ConvertUtility.ToInt32(trangthai) == 2) return "Thời vụ";
            if(ConvertUtility.ToInt32(trangthai) == 3) return "Thử việc";
            if(ConvertUtility.ToInt32(trangthai) == 4) return "Nghỉ chế độ";
            if(ConvertUtility.ToInt32(trangthai) == 5) return "Đào tạo";
            else return "";
        }

        protected void dtgUsers_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
                ImageButton btnImgDeleteUser = (ImageButton)e.Row.FindControl("btnImgDeleteUser");
			    ImageButton btnImgManageProfile = (ImageButton)e.Row.FindControl("btnImgManageProfile");
                ImageButton btnImgManagePassword = (ImageButton)e.Row.FindControl("btnImgManagePassword");
                ImageButton btnImgUserPermision = (ImageButton)e.Row.FindControl("btnImgUserPermision");
                Label lblKey = (Label)e.Row.FindControl("lblKey");
                DropDownList dropPhong = (DropDownList)e.Row.FindControl("dropPhong");

                btnImgDeleteUser.OnClientClick = MiscUtility.MSG_DELETE_CONFIRM;
                btnImgManageProfile.OnClientClick = "javascript:window.open('" + AppEnv.AdminUrlParams("createuser") + "&uid=" + lblKey.Text + "', target='_blank'); return false;";
				DataRowView curData = (DataRowView)e.Row.DataItem;
                               
                //if (e.Row.RowState == DataControlRowState.Alternate)
                //{
                //    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
                //    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#f7fff8';");
                //}
                //else
                //{
                //    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#EEFF00';");
                //    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#eefef0';");
                //}

                dropPhong.DataSource = DotDanhGiaController.GetAllPhongBan(ConvertUtility.ToInt32(dropTrungTam.SelectedValue));
                dropPhong.DataBind();
                dropPhong.Items.Insert(0, new ListItem("----------Lựa chọn----------", "0"));
                dropPhong.SelectedValue = curData["IDPhong"].ToString();
			}
		}
		protected void dtgUsers_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			int userId = ConvertUtility.ToInt32(e.CommandArgument);
			switch (e.CommandName)
			{
				case "manageprofile":
                    Response.Redirect(AppEnv.AdminUrlParams("createuser") + "&uid=" + userId);
					break;
				case "managepassword":
                    Response.Redirect(AppEnv.AdminUrlParams("managepassword") + "&uid=" + userId);
					break;
				case "userpermision":
                    Response.Redirect(AppEnv.AdminUrlParams("userpermision") + "&uid=" + userId);
					break;
				case "deleteuser":
					try
					{
						UserController.DeleteUser(userId);
						this.lblUpdateStatus.Text = MiscUtility.MSG_UPDATE_SUCCESS;
					}
					catch (Exception ex)
					{
						this.lblUpdateStatus.Text = ex.Message;
					}
					break;
				default:
					break;
			}
		}
		protected void btnAddUser_Click(object sender, EventArgs e)
		{
            Response.Redirect(AppEnv.AdminUrlParams("createuser"));
		}

        private void BuildAlphabet()
        {
            ArrayList arrLetters = new ArrayList();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                arrLetters.Add(c.ToString());
            }
            arrLetters.Add("All");
            rptLetters.DataSource = arrLetters;
            rptLetters.ItemDataBound += new RepeaterItemEventHandler(rptLetters_ItemDataBound);
            rptLetters.DataBind();
        }

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

            BuildAlphabet();

            DataTable dtUsers = UserController.GetUsers(txtKeyword.Text, dropSearchBy.SelectedValue, ConvertUtility.ToString(ViewState["Alphabet"]), ConvertUtility.ToInt32(AppEnv.PortalId()), ConvertUtility.ToInt32(dropTrungTam.SelectedValue), ConvertUtility.ToInt32(dropTrangThai.SelectedValue), ConvertUtility.ToInt32(dropGender.SelectedValue));
           
            //-------sort----------
            DataView dv = new DataView(dtUsers);
            if (ViewState["sortExpression"] != null && ViewState["sortExpression"].ToString() != string.Empty)
            {
                dv.Sort = ViewState["sortExpression"].ToString();
            }


            if (ViewState["sortDirection"] != null && ViewState["sortDirection"].ToString() == "Desc")
            {
                dv.Sort = ViewState["sortExpression"].ToString() + " " + ViewState["sortDirection"].ToString();
            }
            //--------sort-------------

            dtgUsers.DataSource = dv;
			dtgUsers.RowDataBound += new GridViewRowEventHandler(dtgUsers_RowDataBound);
			dtgUsers.DataBind();

            lblTotalTop.Text = lblTotalBottom.Text = dtUsers.Rows.Count.ToString();
		}
        protected void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gv in dtgUsers.Rows)
            {
                CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("DeleteThis");
                if (deleteChkBxItem.Checked)
                {
                    string strTemp = ((Label)gv.FindControl("lblKey")).Text.ToString();
                    UserController.DeleteUser(Convert.ToInt32(strTemp.ToString()));
                    dtgUsers.DataBind();
                }
            }
        }
        protected void dtgUsers_Sorting(object sender, GridViewSortEventArgs e)
        {
          if (ViewState["sortDirection"] == null || ViewState["sortDirection"].ToString()=="")
            {
                ViewState["sortDirection"] = "Desc";
            }
            else if (ViewState["sortDirection"].ToString() == "Desc")
            {
                ViewState["sortDirection"] = "";
            }
            ViewState["sortExpression"] = e.SortExpression;
           
        }
        protected void dtgUsers_PreRender(object sender, EventArgs e)
        {
            if (dtgUsers.BottomPagerRow != null)
            {
                ((Label)dtgUsers.BottomPagerRow.FindControl("lbTotalPages")).Text = dtgUsers.PageCount.ToString();

                //This makes the first and last button disappear when on the first and last pages.
                ((LinkButton)dtgUsers.BottomPagerRow.FindControl("lbtnFirst")).Visible = dtgUsers.PageIndex != 0;
                ((LinkButton)dtgUsers.BottomPagerRow.FindControl("lbtnLast")).Visible = dtgUsers.PageCount != (dtgUsers.PageIndex + 1);

                DropDownList ddlistPageof = (DropDownList)dtgUsers.BottomPagerRow.FindControl("ddlPageItems");
                ddlistPageof.SelectedIndex = ddlistPageof.Items.IndexOf(ddlistPageof.Items.FindByValue(ViewState["DropDownPageItems"].ToString()));
                DropDownList ddlistPageno = (DropDownList)dtgUsers.BottomPagerRow.FindControl("ddlNumberPages");
                ddlistPageno.Items.Clear();
                for (int i = 1; i <= dtgUsers.PageCount; i++)
                {
                    ListItem liTemp = new ListItem();
                    liTemp.Text = i.ToString();
                    liTemp.Value = i.ToString();
                    ddlistPageno.Items.Add(liTemp);
                }
                if (dtgUsers.PageCount != 0)
                {
                    ddlistPageno.SelectedIndex = dtgUsers.PageIndex;
                    ddlistPageno.DataBind();
                }
            }
        }
        protected void ddlNumberPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlistPageno = (DropDownList)dtgUsers.BottomPagerRow.FindControl("ddlNumberPages");
            dtgUsers.PageIndex = Convert.ToInt32(ddlistPageno.SelectedValue) - 1;

        }
        protected void dtgUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgUsers.PageIndex = e.NewPageIndex;
        }
        protected void ddlPageItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pageItems = Convert.ToInt32(((DropDownList)sender).SelectedValue);
            this.dtgUsers.PageSize = pageItems;
            ViewState["DropDownPageItems"] = pageItems;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        //protected void btnUpdatePhongBan_Click(object sender, EventArgs e)
        //{
        //    foreach (GridViewRow gv in dtgUsers.Rows)
        //    {
        //        DropDownList dropPhong = (DropDownList)gv.FindControl("dropPhong");
        //        string strTemp = ((Label)gv.FindControl("lblKey")).Text.ToString();
        //        BoPhanController.UpdatePhongBan(ConvertUtility.ToInt32(strTemp), ConvertUtility.ToInt32(dropPhong.SelectedValue), ConvertUtility.ToInt32(dropDotDanhGia.SelectedValue));
        //    }
        //}
	}
}