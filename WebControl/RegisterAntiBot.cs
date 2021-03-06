using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Library.Utilities;
namespace VmgPortal.WebControls
{
    [ToolboxData("<{0}:AntiBotImage runat=server></{0}:AntiBotImage>")]
    public class AntiBotImage : System.Web.UI.WebControls.Image
    {

        private static string _key;

        public string Code
        {
            get
            {
                return _key;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            AlternateText = "Bí số đăng ký";
            ImageUrl = "~/Painter.aspx";
            if (!Page.IsPostBack)
            {
                Random r = new Random(unchecked((int)DateTime.Now.Ticks));
                _key = RandomActiveCode.Generate(8,8);// Convert.ToString(r.Next(0x8000000), 16);
                HttpContext.Current.Cache[RegisterAntiBot.SessionName] = _key;
                //Page.Session.Add(RegisterAntiBot.SessionName, _key);
            }
            else
                _key = (string)HttpContext.Current.Cache[RegisterAntiBot.SessionName];// (Page.Session[RegisterAntiBot.SessionName]);
        }
    }

    [ToolboxData("<{0}:AntiBotImageValidator runat=server></{0}:AntiBotImageValidator>")]
    public class AntiBotImageValidator : BaseCompareValidator //CompareValidator//
    {

        private string _key;
        private string _controlToCompare;

        [Bindable(false), Category("Behavior")]
        public string ControlToCompare
        {
            get { return _controlToCompare; }
            set { _controlToCompare = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            _key = (string)HttpContext.Current.Cache[RegisterAntiBot.SessionName];// Page.Session[RegisterAntiBot.SessionName];
            base.OnInit(e);
        }

        protected override bool ControlPropertiesValid()
        {
            Control c = FindControl(ControlToCompare);
            Control v = FindControl(ControlToValidate);
            if ((c != null) && (v != null))
            {
                return (c is AntiBotImage && v is TextBox);
            }
            return false;
        }

        protected override bool EvaluateIsValid()
        {
            AntiBotImage c = (AntiBotImage)FindControl(ControlToCompare);
            TextBox v = (TextBox)FindControl(ControlToValidate);
            return (c.Code == v.Text);
        }
    }

    public class RegisterAntiBot
    {

        private const string SESSION_NAME = "AntiBotKey";

        public static void GeneratePicture(System.Web.UI.Page page, Color backColor, Color foreColor)
        {
            page.Response.Clear();

            int fontWidth = 20;
            int width = (8 * fontWidth);
            int height = 35;

            Bitmap codeBitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(codeBitmap);
            g.SmoothingMode = SmoothingMode.Default;//.AntiAlias;

            Random rnd = new Random (unchecked ((int)DateTime.Now.Ticks));
            HatchStyle hStyle ;
            do
            {
                hStyle = (HatchStyle)rnd.Next (53);
            }
            while (
                ((int)hStyle == 12) || ((int)hStyle == 13) || ((int)hStyle == 14) ||
                ((int)hStyle == 15) || ((int)hStyle == 16) || ((int)hStyle == 17) ||
                ((int)hStyle == 20) || ((int)hStyle == 21) || ((int)hStyle == 41) ||
                ((int)hStyle == 46) || ((int)hStyle == 47) || ((int)hStyle == 50) ||
                ((int)hStyle == 52)
            ); // bad hatchstyle
            //foreColor
            g.FillRectangle(
                new HatchBrush(hStyle, Color.Cyan, backColor),
                0, 0, width - 1, height - 1
                );

            g.DrawString(
                (string)HttpContext.Current.Cache[SessionName],// page.Session[SessionName],
                new Font(FontFamily.GenericSansSerif, fontWidth, FontStyle.Bold),
                new SolidBrush(foreColor),
                new Point(10, 0)
                );

            codeBitmap.Save(page.Response.OutputStream, ImageFormat.Gif);
            page.Response.End();
        }

        internal static string SessionName
        {
            get
            {
                return SESSION_NAME;
            }
        }

    } 
}
