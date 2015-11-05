using System;
using System.Collections.Generic;
using System.Text;
using VmgPortal.Library.Utilities;

namespace VmgPortal.Library
{
	public class Definition
	{
        private const string CONFIG_FILENAME = "/Module_Control/CMS/CMS.config";
	    
		public const string Portal_SiteName = "Portal.SiteName";
        public const string Portal_Portal = "Portal_Portal";
        public const string Portal_Home = "Portal_Home";
        public const string Portal_Sport = "Portal_Sport";
        public const string Portal_Music = "Portal_Music";
        public const string Portal_NhacCho = "Portal_NhacCho";
        public const string Portal_Ringtones = "Portal_Ringtones";
        public const string Portal_Pic = "Portal_Pic";
        public const string Portal_Games = "Portal_Games";
        public const string Portal_Video = "Portal_Video";
        public const string Portal_Software = "Portal_Software";
        public const string Portal_Xzone = "Portal.Xzone";
        public const string Portal_VPOD = "Portal.VPOD";
        public const string Portal_SMS = "Portal.SMS";

		public const string Portal_Home_Tab = "Portal.Home.Tab";
		public const string Portal_Search_Tab = "Portal.Search.Tab";
        public const string Portal_Content_Tab = "Portal.Content.Tab";
        public const string Portal_Zone_Tab = "Portal.Zone.Tab";
        public const string Portal_Zone_Active = "Portal.Zone.Active";
        public const string Portal_Product_Page = "Portal.Product.Page";
        public const string Portal_Default_Role = "Portal.Default_Role";
        
        public const string Portal_Admin_Cookie = "VmgPortal.Portal.Cookie_Admin_VMG";
        public const string Portal_Cookie = "VmgPortal.Portal.Cookie_VMG";
		public const string Portal_Contact_Mail = "Portal.Contact.Mail";
		public const string Portal_Mail_Server = "Portal.Mail.Server";
        public const string Portal_Mail_User = "Portal.Mail.User";
        public const string Portal_Mail_Password = "Portal.Mail.Password";
		public const string Portal_CopyRight = "Portal.CopyRight";
		public const string Portal_Hit_Counter = "Portal.Hit.Counter";
        public const string Portal_Style = "Portal.Style";
        public const string CMS_Viewed_Cookie_Name = "CMS.Viewed_Cookie_Name";
        public const string Portal_Active = "Portal.Active";
      
        public static double CacheTime
		{
			get { return ConvertUtility.ToDouble(AppEnv.GetAppSetting("CacheExpire_Zone", CONFIG_FILENAME)); }
		}

		public static string UploadPath
		{
			get { return AppEnv.GetAppSetting("UploadPath", CONFIG_FILENAME); }
		}
	}
}
