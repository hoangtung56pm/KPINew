using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrganicBit.Zip;
using System.IO;

namespace VmgPortal.FilePicker
{
    public class Explorer : System.Web.UI.Page
    {
        private string _Path;
        private DataTable _Files;
        //private System.Resources.ResourceManager _rm;

        public Explorer(string path)
        {
            //_rm = (System.Resources.ResourceManager)HttpContext.Current.Application["fpRm"];
                        
            SetPath(path);
            GetFiles();
        }
        
        public string Path
		{
            get
            {
                return _Path;
            }		
            set 
            {
                _Path = value; 
            }				
		}

        public DataTable Files
		{
            get
            {
                return _Files; 	
            }		
            set 
            {
                _Files = value; 
            }						
		}    

        public void SetPath(string Path)
        {
             _Path = Path;
            _Files = new DataTable("Files");

            DataColumn myColumn;
            myColumn = new DataColumn("Id", typeof(Int32));
            myColumn.AutoIncrement = true;
            _Files.Columns.Add(myColumn);

            myColumn = new DataColumn("Chk", typeof(Boolean));
            _Files.Columns.Add(myColumn);

            myColumn = new DataColumn("Type", typeof(System.String));
            _Files.Columns.Add(myColumn);

            myColumn = new DataColumn("Name", typeof(System.String));
            _Files.Columns.Add(myColumn);

            myColumn = new DataColumn("Length", typeof(System.String));
            _Files.Columns.Add(myColumn);

            myColumn = new DataColumn("Updated", typeof(System.String));
            _Files.Columns.Add(myColumn);
        }

        public void GetFiles()
        {
            string Path = System.Web.HttpContext.Current.Server.MapPath(_Path);
            DirectoryInfo DirInfo = new DirectoryInfo(Path);
            
            foreach (DirectoryInfo directory in DirInfo.GetDirectories())
            {
                if(directory.Name != "_thumbs")
                AddDirectory(directory);
            }
           
            foreach(FileInfo file in DirInfo.GetFiles())
            {
                 AddFile(file);
            }
        }
        public void AddDirectory(DirectoryInfo Dir)
       {
            DataRow dr;
            dr = _Files.NewRow();
            dr["Chk"] = false;
            dr["Type"] = "D";
            dr["Name"] = Dir.Name;
            dr["Length"] = this.GetGlobalResourceObject("Lang","LOC_LABEL_DIR");// _rm.GetString("LOC_LABEL_DIR");
            dr["Updated"] = Dir.LastWriteTime;

            _Files.Rows.Add(dr);
       }

        public void AddFile(FileInfo file)
        {
            DataRow dr;

            dr = _Files.NewRow();
            dr["Chk"] = false;
            dr["Type"] = "F";
            dr["Name"] = file.Name;
            dr["Length"] = new Ultils().FormatFileSize(file.Length);
            dr["Updated"] = file.LastWriteTime;

            _Files.Rows.Add(dr);
        }        
    }
}
