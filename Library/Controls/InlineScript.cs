using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Web.UI;

namespace VmgPortal.Library.Controls
{
    public class InlineScript : Control
    {

        protected override void Render(HtmlTextWriter writer)
        {

            ScriptManager sm = ScriptManager.GetCurrent(Page);

            if (sm.IsInAsyncPostBack)
            {

                StringBuilder sb = new StringBuilder();

                base.Render(new HtmlTextWriter(new StringWriter(sb)));

                string script = sb.ToString();

                ScriptManager.RegisterStartupScript(this, typeof(InlineScript), UniqueID, script, false);

            }

            else
            {

                base.Render(writer);

            }

        }

    }
}
