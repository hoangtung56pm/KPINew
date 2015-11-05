using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Components.Security;
using Newtonsoft.Json;
using System.Data;
using VmgPortal.Library.Utilities;
using VmgPortal.Modules.KPIData.Library.DotDanhGia;

namespace VmgPortal.Administrator
{
    public class Event
    {
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _start;
        public string start
        {
            get { return _start; }
            set { _start = value; }
        }

        private string _end;
        public string end
        {
            get { return _end; }
            set { _end = value; }
        }

        private string _backgroundColor;
        public string backgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        private string _url;
        public string url
        {
            get { return _url; }
            set { _url = value; }
        }
        private bool _allDay;
        public bool allDay
        {
            get { return _allDay; }
            set { _allDay = value; }
        }

    }

    public partial class LichCaNhan : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtCongViec = DotDanhGiaController.GetAllCongViecGiaoChoNhanVienTheoNgay(CurrentUser.UserID, 0);

            string[] color = new string[10];
            color[0] = "#FFB848";
            color[1] = "#852B99";
            color[2] = "#E02222";
            color[3] = "#69A4E0";
            color[4] = "#35AA47";
            color[5] = "#FFB848";
            color[6] = "#852B99";
            color[7] = "#E02222";
            color[8] = "#69A4E0";
            color[9] = "#35AA47";

            Event[] arrEvent = new Event[dtCongViec.Rows.Count];
            int i = 0;
            int colorIndex = 0;
            foreach (DataRow item in dtCongViec.Rows)
            {
                Event objEvent = new Event();
                objEvent.title = item["CongViecCha"].ToString().TrimStart() + " > " + item["Ten"].ToString().Trim();
                objEvent.start = item["NgayBatDau"].ToString();
                objEvent.end = item["NgayKetThuc"].ToString();
                if (colorIndex > 9) colorIndex = 0;
                objEvent.backgroundColor = color[colorIndex];
                objEvent.url = "";
                objEvent.allDay = false;

                arrEvent[i] = objEvent;
                i++;
                colorIndex++;
            }

            string json = JsonConvert.SerializeObject(arrEvent);

            Response.Write(json);
        }
    }
}