using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace VmgPortal.Library.Controls
{
    public class PagingGridViewRepair: GridView
    {
        public PagingGridViewRepair()
            : base()
        {
            this.AllowPaging = true;
            this.AllowSorting = true;
            this.PagerSettings.Mode = PagerButtons.Numeric;//.NumericFirstLast;
        }

        #region Custom properties
        [Browsable(true), Category("NewDynamic")]
        [Description("Set the virtual item count for this grid")]
        public int VirtualItemCount
        {
            get 
            {
                if (ViewState["pgv_vitemcount"] == null)
                    ViewState["pgv_vitemcount"] = -1;
                return Convert.ToInt32(ViewState["pgv_vitemcount"]);
            }
            set
            {
                ViewState["pgv_vitemcount"] = value;
            }
        }
        public override object DataSource
        {
            get
            {
                return base.DataSource;
            }
            set
            {
                base.DataSource = value;
                // we store the page index here so we dont lost it in databind
                CurrentPageIndex = PageIndex;
            }
        }
        private int CurrentPageIndex
        {
            get
            {
                if (ViewState["pgv_pageindex"] == null)
                    ViewState["pgv_pageindex"] = 0;
                return Convert.ToInt32(ViewState["pgv_pageindex"]);
            }
            set
            {
                ViewState["pgv_pageindex"] = value;
            }
        }
        private bool CustomPaging
        {
            get
            {
                return (VirtualItemCount != -1);
            }
        }
        #endregion
       
        #region Overriding the parent methods

        protected override void InitializePager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            // This method is called to initialise the pager on the grid. We intercepted this and override
            // the values of pagedDataSource to achieve the custom paging using the default pager supplied
            if (CustomPaging)
            {
                pagedDataSource.AllowCustomPaging = true;
                pagedDataSource.VirtualCount = VirtualItemCount;
                pagedDataSource.CurrentPageIndex = CurrentPageIndex;
            }
            base.InitializePager(row, columnSpan, pagedDataSource);
        }
        
        #endregion 
    }
}
