using System;
namespace VmgPortal.Library.Components.Users
{
	public class UserOnlineInfo
	{
		private int userId;
		private int tabId;
		private string userAgent;
		private string userIp;
		private DateTime createTime;
		private DateTime lastAccessTime;
		public int UserID
		{
			get { return this.userId; }
			set { this.userId = value; }
		}
		public int TabID
		{
			get { return this.tabId; }
			set { this.tabId = value; }
		}
		public string UserAgent
		{
			get { return this.userAgent; }
			set { this.userAgent = value; }
		}
		public string UserIP
		{
			get { return this.userIp; }
			set { this.userIp = value; }
		}
		public DateTime CreateTime
		{
			get { return this.createTime; }
			set { this.createTime = value; }
		}
		public DateTime LastAccessTime
		{
			get { return this.lastAccessTime; }
			set { this.lastAccessTime = value; }
		}
	}
}