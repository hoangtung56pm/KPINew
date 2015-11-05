using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Web;

namespace VmgPortal.Library.Utilities
{
	public class MultimediaUtility
	{
		private static bool ThumbnailCallback()
		{
			return false;
		}
     
        private static Image Crop(Image p, int width, int height)
        {
            var b = new Bitmap(p);
            var imgCropped = new Bitmap(width, height);
            Graphics objGraphic = Graphics.FromImage(imgCropped);
            const int intStartTop = 0;
            const int intStartLeft = 0;

            objGraphic.CompositingQuality = CompositingQuality.HighQuality;

            objGraphic.SmoothingMode = SmoothingMode.HighQuality;

            objGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

            objGraphic.DrawImage(b, intStartLeft, intStartTop);
            b.Dispose();
            objGraphic.Dispose();

            return imgCropped;
        }
        public static bool SetThumbnail(string filePath, string newPath, int iThumbWidth, int iThumbHeight)
        {
            try
            {

                var image = Image.FromFile(filePath);
                var fileInfo = new FileInfo(filePath);
                var newWidth = iThumbWidth;

                var newHeight = (iThumbWidth*image.Height)/image.Width;

                var thumbnailBitmap = new Bitmap(newWidth, newHeight);

                var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);

                thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;

                thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;

                thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);

                thumbnailGraph.DrawImage(image, imageRectangle);

                Image newImage = thumbnailBitmap;
                if (newHeight > iThumbHeight)
                {
                    newImage = Crop(thumbnailBitmap, iThumbWidth, iThumbHeight);
                }

                newImage.Save(newPath + "thumb_" + iThumbWidth + "_" + iThumbHeight + "_" + fileInfo.Name.Replace(".png", ".jpg"),
                    image.RawFormat);

                thumbnailGraph.Dispose();

                thumbnailBitmap.Dispose();

                image.Dispose();

                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public static string GetAvatarThumbnail(string avatar, int iThumbWidth, int iThumbHeight)
        {
            try
            {

                int splitIndex = avatar.LastIndexOf("/");

                if (splitIndex > -1)
                {
                    string fileName = avatar.Substring(splitIndex + 1);
                    string filePath = avatar.Substring(0, splitIndex) + "/Avatar/" + "thumb_" + iThumbWidth + "_" + iThumbHeight + "_" + fileName.Replace(".png", ".jpg");
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(avatar.Substring(0, splitIndex) + "/Avatar/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(avatar.Substring(0, splitIndex) + "/Avatar/"));
                    }
                    if (File.Exists(HttpContext.Current.Server.MapPath(filePath)))
                    {
                        return filePath;
                    }
                    SetAvatarThumbnail(HttpContext.Current.Server.MapPath(avatar), iThumbWidth, iThumbHeight);
                    return avatar.Substring(0, splitIndex) + "/Avatar/" + "thumb_" + iThumbWidth + "_" + iThumbHeight + "_" + fileName.Replace(".png", ".jpg");
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static bool SetThumbnailWallpaper(string filePath, string newPath, int iThumbWidth, int iThumbHeight)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists) return false;
            try
            {
                if (!Directory.Exists(newPath)) Directory.CreateDirectory(newPath);

                Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                Bitmap myBitmap = new Bitmap(fileInfo.FullName);

                if ((iThumbHeight == 0) && (iThumbWidth == 0)) return false;
                else if ((iThumbHeight != 0) && (iThumbWidth == 0))
                    iThumbWidth = (int)(iThumbHeight * myBitmap.Width) / myBitmap.Height;
                else if ((iThumbHeight == 0) && (iThumbWidth != 0))
                    iThumbHeight = (int)(iThumbWidth * myBitmap.Height) / myBitmap.Width;

                Image myThumbnail = myBitmap.GetThumbnailImage(iThumbWidth, iThumbHeight, myCallback, IntPtr.Zero);
                myThumbnail.Save(newPath + "Thumb_" + fileInfo.Name, ImageFormat.Jpeg);
                myBitmap.Dispose();
                myThumbnail.Dispose();
                GC.Collect();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool SetThumbnailGame110(string filePath, string newPath, int iThumbWidth, int iThumbHeight)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists) return false;
            try
            {
                if (!Directory.Exists(newPath)) Directory.CreateDirectory(newPath);

                Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                Bitmap myBitmap = new Bitmap(fileInfo.FullName);

                if ((iThumbHeight == 0) && (iThumbWidth == 0)) return false;
                else if ((iThumbHeight != 0) && (iThumbWidth == 0))
                    iThumbWidth = (int)(iThumbHeight * myBitmap.Width) / myBitmap.Height;
                else if ((iThumbHeight == 0) && (iThumbWidth != 0))
                    iThumbHeight = (int)(iThumbWidth * myBitmap.Height) / myBitmap.Width;

                Image myThumbnail = myBitmap.GetThumbnailImage(iThumbWidth, iThumbHeight, myCallback, IntPtr.Zero);
                myThumbnail.Save(newPath + "Thumb_110_" + fileInfo.Name, ImageFormat.Jpeg);
                myBitmap.Dispose();
                myThumbnail.Dispose();
                GC.Collect();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool SetThumbnailGame(string filePath, string newPath, int iThumbWidth, int iThumbHeight)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists) return false;
            try
            {
                if (!Directory.Exists(newPath)) Directory.CreateDirectory(newPath);

                Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                Bitmap myBitmap = new Bitmap(fileInfo.FullName);

                if ((iThumbHeight == 0) && (iThumbWidth == 0)) return false;
                else if ((iThumbHeight != 0) && (iThumbWidth == 0))
                    iThumbWidth = (int)(iThumbHeight * myBitmap.Width) / myBitmap.Height;
                else if ((iThumbHeight == 0) && (iThumbWidth != 0))
                    iThumbHeight = (int)(iThumbWidth * myBitmap.Height) / myBitmap.Width;

                Image myThumbnail = myBitmap.GetThumbnailImage(iThumbWidth, iThumbHeight, myCallback, IntPtr.Zero);
                myThumbnail.Save(newPath + "Thumb_" + fileInfo.Name, ImageFormat.Jpeg);
                myBitmap.Dispose();
                myThumbnail.Dispose();
                GC.Collect();
            }
            catch
            {
                return false;
            }
            return true;
        }
        #region get and set Thumbnail with Gallery
        public static bool SetAvatarGalleryThumbnail(string filePath, int iThumbWidth, int iThumbHeight)
        {
            FileInfo fileInfo = new FileInfo(HttpContext.Current.Server.MapPath(filePath));
            if (!fileInfo.Exists) return false;
            SetThumbnail(HttpContext.Current.Server.MapPath(filePath), fileInfo.Directory + "\\AvatarThumbnail\\", 75, 0);
            return SetThumbnailList(HttpContext.Current.Server.MapPath(filePath), fileInfo.Directory + "\\Avatar\\", fileInfo.Directory.ToString() + "\\AvatarThumbnail\\", iThumbWidth, iThumbWidth);
            //else
            //    return false;
        }

        public static string GetGalleryAvatar(string avatar)
        {
            int splitIndex = avatar.LastIndexOf("/");
            if (splitIndex != -1)
                return avatar.Substring(0, splitIndex) + "/Avatar" + avatar.Substring(splitIndex, avatar.Length - splitIndex);
            else return string.Empty;

        }
        #endregion
        
        #region get and set Thumbnail with Picture
        public static bool SetAvatarPictureThumbnail(string filePath, int iThumbWidth, int iThumbHeight)
        {
            FileInfo fileInfo = new FileInfo(HttpContext.Current.Server.MapPath(filePath));
            if (!fileInfo.Exists) return false;
            SetThumbnail(HttpContext.Current.Server.MapPath(filePath), fileInfo.Directory + "\\Avatar\\", 75, 0);
            return SetThumbnailList(HttpContext.Current.Server.MapPath(filePath), fileInfo.Directory + "\\ListAvatar\\", fileInfo.Directory.ToString() + "\\Avatar\\", iThumbWidth, iThumbWidth);
            //else
            //    return false;
        }

        public static string GetPictureAvatar(string avatar)
        {
            int splitIndex = avatar.LastIndexOf("/");
            if (splitIndex != -1)
                return avatar.Substring(0, splitIndex) + "/Avatar" + avatar.Substring(splitIndex, avatar.Length - splitIndex);
            else return string.Empty;

        }
        #endregion

        #region get and set Thumbnail Music Album
        public static bool SetAvatarAlbumThumbnail(string filePath, int iThumbWidth, int iThumbHeight)
        {
            FileInfo fileInfo = new FileInfo(HttpContext.Current.Server.MapPath(filePath));
            if (!fileInfo.Exists) return false;
            return SetThumbnail(HttpContext.Current.Server.MapPath(filePath), fileInfo.Directory + "\\Avatar\\", iThumbWidth, 0);

        }
        public static bool SetAlbumAvatarListThumbnail(string filePath, int iThumbWidth, int iThumbHeight)
        {
            FileInfo fileInfo = new FileInfo(HttpContext.Current.Server.MapPath(filePath));
            if (!fileInfo.Exists)
                return false;
            return SetThumbnail(HttpContext.Current.Server.MapPath(filePath), fileInfo.Directory + "\\ListAvatar\\", iThumbWidth, 0);
        }
        public static string GetAlbumAvatar(string avatar)
        {
            int splitIndex = avatar.LastIndexOf("/");
            if (splitIndex != -1)
                return avatar.Substring(0, splitIndex) + "/Avatar" + avatar.Substring(splitIndex, avatar.Length - splitIndex);
            else return string.Empty;

        }
        #endregion

        public static bool SetAvatarThumbnailWallpaper(string filePath, int iThumbWidth, int iThumbHeight)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists) return false;
            return SetThumbnailWallpaper(filePath, fileInfo.Directory + "\\", iThumbWidth, iThumbHeight);
        }
        public static bool SetAvatarThumbnailGame(string filePath, int iThumbWidth, int iThumbHeight)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists) return false;
            return SetThumbnailGame(filePath, fileInfo.Directory + "\\", iThumbWidth, iThumbHeight);
        }
        public static bool SetAvatarThumbnailGame110(string filePath, int iThumbWidth, int iThumbHeight)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists) return false;
            return SetThumbnailGame110(filePath, fileInfo.Directory + "\\", iThumbWidth, iThumbHeight);
        }
        public static bool SetAvatarThumbnail(string filePath, int iThumbWidth, int iThumbHeight)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists) return false;

            return SetThumbnail(filePath, fileInfo.Directory + "\\Avatar\\", iThumbWidth, iThumbHeight);
        }

        public static bool SetThumbnailList(string filePath, string newPath, string avatarPath, int width, int height)
        {
            if (!Directory.Exists(newPath))
                Directory.CreateDirectory(newPath);
            FileInfo fileInfo = new FileInfo(filePath);
            Image orImgeCrop = Crop(Image.FromFile(avatarPath + fileInfo.Name), width, height);
            orImgeCrop.Save(newPath + fileInfo.Name);
            orImgeCrop.Dispose();
            GC.Collect();
            return true;
        }
        public static bool SetAvatarListThumbnail(string filePath, int iThumbWidth, int iThumbHeight)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
                return false;
            return SetThumbnailList(filePath, fileInfo.Directory + "\\ListAvatar\\", fileInfo.Directory + "\\Avatar\\", iThumbWidth, iThumbHeight);
        }
        public static string GetAvatarWallpaper(string avatar)
        {
            int splitIndex = avatar.LastIndexOf("/");
            if (splitIndex != 0)
                return avatar.Substring(0, splitIndex) + "/" + "thumb_" + avatar.Substring(splitIndex, avatar.Length - splitIndex).Replace("/", "");
            else return string.Empty;

        }
		public static string GetAvatar(string avatar)
		{
			int splitIndex = avatar.LastIndexOf("/");
			if (splitIndex != 0)
				return avatar.Substring(0, splitIndex) + "/Avatar/" + avatar.Substring(splitIndex, avatar.Length - splitIndex);
			else return string.Empty;

		}
		public static string strInitImage(string image, int width, int height)
		{
			string retVal = "<img src=\"" + image + "\"";
			if (width > 0) retVal += " width=\"" + width + "px\" ";
			if (height > 0) retVal += " height=\"" + height + "px\" ";
			retVal += ">";
			return retVal;
		}
        public static string strInitFlashWithActiveContent(string fileName, int width, int height, string _align)
        {
            string retVal = "<script type=\"text/javascript\">";
            retVal += "AC_FL_RunContent( 'codebase','http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0','width','" + width + "','height','" + height + "','id','" + fileName + "','align','" + _align + "','src','" + fileName + "','quality','high','bgcolor','','name','" + fileName + "','allowscriptaccess','sameDomain','pluginspage','http://www.macromedia.com/go/getflashplayer','movie','" + fileName + "' );";
            retVal += "</script>";
            return retVal;
        }
        public static string strInitFlash(string flashURL, int width, int height)
        {
            string retVal = "<EMBED align=baseline src='" + flashURL + "'";
            if (width != 0) retVal += " width=" + width;
            if (height != 0) retVal += " height=" + height;

            retVal += " type=audio/x-pn-realaudio-plugin autostart=\"true\" controls=\"ControlPanel\" console=\"Clip1\" border=\"0\">";
            return retVal;
        }
		public static string strInitMultimedia(string mediaPath, int width, int height)
		{
			string retVal = "<EMBED pluginspage='http://www.microsoft.com/Windows/Downloads/Contents/Products/MediaPlayer/' ";
			if (width != 0) retVal += " width=" + width;
			if (height != 0) retVal += " height=" + height;

			retVal += " src='" + mediaPath + "' type='application/x-mplayer2' ShowStatusBar='1' AutoStart='true' ShowControls='1'></embed>";
			return retVal;
		}

        #region Get and set thumbnail with Clip
        public static bool SetAvatarClipThumbnail(string filePath, int iThumbWidth, int iThumbHeight)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists) return false;
            return SetThumbnail(filePath, fileInfo.Directory + "\\ListAvatar\\", iThumbWidth, iThumbHeight);
        }        

        public static string GetClipAvatar(string avatar)
        {
            int splitIndex = avatar.LastIndexOf("/");
            if (splitIndex != -1)
                return avatar.Substring(0, splitIndex) + "/Avatar" + avatar.Substring(splitIndex, avatar.Length - splitIndex);
            else return string.Empty;

        }
        #endregion
	}
}