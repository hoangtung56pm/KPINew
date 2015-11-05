using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace VmgPortal.FilePicker
{
    public class Ultils: System.Web.UI.Page
    {
        public string AddCharInTheEndIfNotPresent(String ch, string str)
        {
            if (str.LastIndexOf(ch) != str.Length - 1)
            {
                str += ch.ToString();
            }
            return str;
        }
        public  string AddSlashInTheEndIfNotPresent(string str)
        {
            return AddCharInTheEndIfNotPresent("/", str);
        }

        public  string AddBackSlashInTheEndIfNotPresent(string str)
        {
            return AddCharInTheEndIfNotPresent("\\", str);
        }

        public string GetParentDirectory(string RelativePath)
        {
            if (RelativePath == "")
            {
                return "";
            }
            else
            {
                if (RelativePath.LastIndexOf("/") == RelativePath.Length - 1)
                {
                    RelativePath = RelativePath.Remove(RelativePath.LastIndexOf("/"), (RelativePath.Length - RelativePath.LastIndexOf("/")));
                }
                try
                {
                    //'Remove the characters after the last occurence of / in the string. => parent directory
                    RelativePath = RelativePath.Remove(RelativePath.LastIndexOf("/"), (RelativePath.Length - RelativePath.LastIndexOf("/")));

                    return (RelativePath);
                }
                catch
                {
                    return("");//' default to root;
                }               
            }
        }

        public string FormatFileSize(long FileSize)
        {
           int Size = 0;
            Size = Convert.ToInt32(FileSize / 1024);
            if(Size == 0 )
            {
                return "1 " + "" + (string)this.GetGlobalResourceObject("Lang", "LOC_LABEL_KB");
            }
            else
            {
                return (String.Format("{0:###,###,###}", Size) + " " + (string)this.GetGlobalResourceObject("Lang","LOC_LABEL_KB"));
            }
        }        
    }
}
