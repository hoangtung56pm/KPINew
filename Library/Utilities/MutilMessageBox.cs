using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VmgPortal.Library.Utilities
{

    [ToolboxData("<{0}:MessageBox runat=\"server\"></{0}:MessageBox>")]
    public sealed class MutillMessageBox : PlaceHolder 
    {
        public void Show(string _message)
        {

            Message = _message;
        }

       
        public void Show(string _message, string _redirectUrl)
        {

            Message = _message;
            RedirectUrl = _redirectUrl;
        }


        public void Show(string _message, bool _isReloadUrl)
        {

            Message = _message;
            IsReloadUrl = _isReloadUrl;
        }

        public bool IsReloadUrl
        {
            get
            {
                object _o=ViewState["IsReloadUrl"];
                if (_o!=null)
                {
                    return (bool) _o;

                }
                return false;
            }
            set
            {
                ViewState["IsReloadUrl"] = value;
            }


        }

        public string RedirectUrl
        {
            get
            {
                return (string)ViewState["RedirectUrl"];
            }
            set
            {
                ViewState["RedirectUrl"] = value;
            }

        }

        public string Message
        {
            get
            {
                return (string)ViewState["Message"];
            }
            set
            {
                ViewState["Message"] = value;

            }
        }

        protected override void Render(HtmlTextWriter output)
        {
            if (!string.IsNullOrEmpty(Message))
            {
                string _msg = Message.Replace("\n", "\\n");
                _msg.Replace("\\", "\\\\");
                _msg.Replace("'", "\'");
                StringBuilder _sb = new StringBuilder();
                _sb.Append("<script type=\"text/javascript\">");
                _sb.Append("alert(\"" + _msg + "\");");


                if (IsReloadUrl)
                {

                    _sb.Append("location=window.location.href;");
                }
                else
                {
                    if (!string.IsNullOrEmpty(RedirectUrl))
                    {
                        string _url = RedirectUrl.Replace("\\", "/");
                        _sb.AppendFormat("location='{0}';", _url);
                    }
                    
                }


              
                _sb.Append("</script>");

                output.Write(_sb.ToString());

            }



        }
    }
}
