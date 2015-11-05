using System;
using System.Text;

namespace VmgPortal.Library.Utilities
{
	public class UnicodeUtility
	{
		private const string uniChars =
			"àáảãạâầấẩẫậăằắẳẵặèéẻẽẹêềếểễệđìíỉĩịòóỏõọôồốổỗộơờớởỡợùúủũụưừứửữựỳýỷỹỵÀÁẢÃẠÂẦẤẨẪẬĂẰẮẲẴẶÈÉẺẼẸÊỀẾỂỄỆĐÌÍỈĨỊÒÓỎÕỌÔỒỐỔỖỘƠỜỚỞỠỢÙÚỦŨỤƯỪỨỬỮỰỲÝỶỸỴÂĂĐÔƠƯ";

		private const string KoDauChars =
			"aaaaaaaaaaaaaaaaaeeeeeeeeeeediiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAAEEEEEEEEEEEDIIIOOOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYAADOOU";

		public static int UnicodeToUTF8(byte[] dest, int maxDestBytes, string source, int sourceChars)
		{
			int i, count;
			int c, result;

			result = 0;
			if ((source != null && source.Length == 0))
				return result;
			count = 0;
			i = 0;
			if (dest != null)
			{
				while ((i < sourceChars) && (count < maxDestBytes))
				{
					c = (int) source[i++];
					if (c <= 0x7F)
						dest[count++] = (byte) c;
					else if (c > 0x7FF)
					{
						if ((count + 3) > maxDestBytes)
							break;
						dest[count++] = (byte) (0xE0 | (c >> 12));
						dest[count++] = (byte) (0x80 | ((c >> 6) & 0x3F));
						dest[count++] = (byte) (0x80 | (c & 0x3F));
					}
					else
					{
						//  0x7F < source[i] <= 0x7FF
						if ((count + 2) > maxDestBytes)
							break;
						dest[count++] = (byte) (0xC0 | (c >> 6));
						dest[count++] = (byte) (0x80 | (c & 0x3F));
					}
				}
				if (count >= maxDestBytes)
					count = maxDestBytes - 1;
				dest[count] = (byte) (0);
			}
			else
			{
				while (i < sourceChars)
				{
					c = (int) (source[i++]);
					if (c > 0x7F)
					{
						if (c > 0x7FF)
							count++;
						count++;
					}
					count++;
				}
			}
			result = count + 1;
			return result;
		}


		public static int UTF8ToUnicode(char[] dest, int maxDestChars, byte[] source, int sourceBytes)
		{
			int i, count;
			int c, result;
			int wc;

			if (source == null)
			{
				result = 0;
				return result;
			}
			result = (int) (-1);
			count = 0;
			i = 0;
			if (dest != null)
			{
				while ((i < sourceBytes) && (count < maxDestChars))
				{
					wc = (int) (source[i++]);
					if ((wc & 0x80) != 0)
					{
						if (i >= sourceBytes)
							return result;
						wc = wc & 0x3F;
						if ((wc & 0x20) != 0)
						{
							c = (byte) (source[i++]);
							if ((c & 0xC0) != 0x80)
								return result;
							if (i >= sourceBytes)
								return result;
							wc = (wc << 6) | (c & 0x3F);
						}
						c = (byte) (source[i++]);
						if ((c & 0xC0) != 0x80)
							return result;
						dest[count] = (char) ((wc << 6) | (c & 0x3F));
					}
					else
						dest[count] = (char) wc;
					count++;
				}
				if (count > maxDestChars)
					count = maxDestChars - 1;
				dest[count] = (char) (0);
			}
			else
			{
				while (i < sourceBytes)
				{
					c = (byte) (source[i++]);
					if ((c & 0x80) != 0)
					{
						if (i >= sourceBytes)
							return result;
						c = c & 0x3F;
						if ((c & 0x20) != 0)
						{
							c = (byte) (source[i++]);
							if ((c & 0xC0) != 0x80)
								return result;
							if (i >= sourceBytes)
								return result;
						}
						c = (byte) (source[i++]);
						if ((c & 0xC0) != 0x80)
							return result;
					}
					count++;
				}
			}
			result = count + 1;
			return result;
		}


		public static byte[] UTF8Encode(string ws)
		{
			int l;
			byte[] temp, result;

			result = null;
			if ((ws != null && ws.Length == 0))
				return result;
			temp = new byte[ws.Length*3];
			l = UnicodeToUTF8(temp, temp.Length + 1, ws, ws.Length);
			if (l > 0)
			{
				result = new byte[l - 1];
				Array.Copy(temp, 0, result, 0, l - 1);
			}
			else
			{
				result = new byte[ws.Length];
				for (int i = 0; i < result.Length; i++)
					result[i] = (byte) (ws[i]);
			}
			return result;
		}


		public static string UTF8Decode(byte[] s)
		{
			int l;
			char[] temp;
			string result;

			result = String.Empty;
			if (s == null)
				return result;
			temp = new char[s.Length + 1];
			l = UTF8ToUnicode(temp, temp.Length, s, s.Length);
			if (l > 0)
			{
				result = "";
				for (int i = 0; i < l - 1; i++)
					result += temp[i];
			}
			else
			{
				result = "";
				for (int i = 0; i < s.Length; i++)
					result += (char) (s[i]);
			}
			return result;
		}

        public static string RemoveSpecialCharacter(string orig)
        {
            string rv;

            // replacing with space allows the camelcase to work a little better in most cases.
            rv = orig.Replace("\\", " ");
            rv = rv.Replace("(", " ");
            rv = rv.Replace(")", " ");
            rv = rv.Replace("/", " ");
            rv = rv.Replace("-", " ");
            rv = rv.Replace(",", " ");
            rv = rv.Replace(">", " ");
            rv = rv.Replace("<", " ");           
            rv = rv.Replace("&", " ");
            rv = rv.Replace("!", " ");
            rv = rv.Replace("@", " ");
            rv = rv.Replace("#", " ");
            rv = rv.Replace("$", " ");
            rv = rv.Replace("%", " ");
            rv = rv.Replace("^", " ");
            rv = rv.Replace("*", " ");
            rv = rv.Replace("+", " ");
            rv = rv.Replace("|", " ");
            rv = rv.Replace("[", " ");
            rv = rv.Replace("]", " ");
            rv = rv.Replace("{", " ");
            rv = rv.Replace("}", " ");
            rv = rv.Replace(":", " ");
            rv = rv.Replace(";", " ");
            rv = rv.Replace("?", " ");
            rv = rv.Replace("~", " ");
            rv = rv.Replace(",", " ");
            //rv = rv.Replace(".", " ");
            rv = rv.Replace("\"", "");
            // single quotes shouldn't result in CamelCase variables like Patient's -> PatientS
            // "smart" forward quote
            rv = rv.Replace("'", "");

            // make sure to get rid of double spaces.
            rv = rv.Replace("   ", " ");
            rv = rv.Replace("  ", " ");
            rv = rv.Replace(" ", "");
            rv = rv.Trim(' '); // Remove leading and trailing spaces.

            return (rv);
        }

        private static string ConvertToUnSign(string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }

		public static string UnicodeToKoDau(string s)
		{
			string retVal = String.Empty;
			if (s == null)
				return retVal;
			int pos;
			for (int i = 0; i < s.Length; i++)
			{
				pos = uniChars.IndexOf(s[i].ToString());
				if (pos >= 0)
					retVal += KoDauChars[pos];
				else
					retVal += s[i];
			}

            string input = retVal;
            input = input.Replace("Ð", "D");//.ToLower();
            input = input.Replace("\n", "");//.ToLower();
            input = input.Replace("ã", "a").Replace("á", "a").Replace("ạ", "a").Replace("a´", "a").Replace("a`", "a").Replace("a?", "a").Replace("à", "a").Replace("ả", "a");
            input = input.Replace("é", "e").Replace("e?", "e").Replace("e´", "e").Replace("e`", "e").Replace("e?", "e").Replace("e~", "e").Replace("ẹ", "e").Replace("ẽ", "e");
            input = input.Replace("ọ", "o").Replace("ò", "o").Replace("ó", "o").Replace("o´", "o").Replace("o`", "o").Replace("o?", "o").Replace("ỏ", "o").Replace("o~", "o").Replace("õ", "o");
            input = input.Replace("ụ", "u").Replace("ù", "u").Replace("ủ", "u").Replace("u´", "u").Replace("u`", "u").Replace("u?", "u").Replace("u~", "u").Replace("ũ", "u");
            input = input.Replace("ì", "i").Replace("í", "i").Replace("i´", "i").Replace("i`", "i").Replace("i?", "i").Replace("i~", "i").Replace("ĩ", "i");
            input = input.Replace("ỷ", "y").Replace("y`", "y").Replace("y?", "i").Replace("y~", "y").Replace("y?", "y").Replace("ỳ", "y");
            input = input.Replace("`", "").Replace("?", "").Replace("~", "").Replace("´", "").Replace("`", "");
		    input = input.Replace("…", "...");
            input = input.Replace(" ", "");
            input = input.Replace("'", "");
            input = input.Replace(":", "");
            input = input.Replace("“", "_");
            input = input.Replace("”", "");
		    retVal = input;

			return retVal;
		}
        public static string UnicodeToKoDauIncludeSpace(string s)
        {
            string retVal = String.Empty;
            if (s == null)
                return retVal;
            int pos;
            for (int i = 0; i < s.Length; i++)
            {
                pos = uniChars.IndexOf(s[i].ToString());
                if (pos >= 0)
                    retVal += KoDauChars[pos];
                else
                    retVal += s[i];
            }

            string input = retVal;
            input = input.Replace("Ð", "D");//.ToLower();
            input = input.Replace("\n", "");//.ToLower();
            input = input.Replace("ã", "a").Replace("á", "a").Replace("ạ", "a").Replace("a´", "a").Replace("a`", "a").Replace("a?", "a").Replace("à", "a").Replace("ả", "a");
            input = input.Replace("é", "e").Replace("e?", "e").Replace("e´", "e").Replace("e`", "e").Replace("e?", "e").Replace("e~", "e").Replace("ẹ", "e").Replace("ẽ", "e");
            input = input.Replace("ọ", "o").Replace("ò", "o").Replace("ó", "o").Replace("o´", "o").Replace("o`", "o").Replace("o?", "o").Replace("ỏ", "o").Replace("o~", "o").Replace("õ", "o");
            input = input.Replace("ụ", "u").Replace("ù", "u").Replace("ủ", "u").Replace("u´", "u").Replace("u`", "u").Replace("u?", "u").Replace("u~", "u").Replace("ũ", "u");
            input = input.Replace("ì", "i").Replace("í", "i").Replace("i´", "i").Replace("i`", "i").Replace("i?", "i").Replace("i~", "i").Replace("ĩ", "i");
            input = input.Replace("ỷ", "y").Replace("y`", "y").Replace("y?", "i").Replace("y~", "y").Replace("y?", "y").Replace("ỳ", "y");
            input = input.Replace("`", "").Replace("?", "").Replace("~", "").Replace("´", "").Replace("`", "");
            input = input.Replace("…", "...");
            input = input.Replace("'", "");
            retVal = input;

            return retVal;
        }
		public static string UnicodeToWindows1252(string s)
		{
			string retVal = String.Empty;
			for (int i = 0; i < s.Length; i++)
			{
				int ord = (int) s[i];
				if (ord > 191)
					retVal += "&#" + ord.ToString() + ";";
				else
					retVal += s[i];
			}
			return retVal;
		}

		public static string UnicodeToISO8859(string src)
		{
			Encoding iso = Encoding.GetEncoding("iso8859-1");
			Encoding unicode = Encoding.UTF8;
			byte[] unicodeBytes = unicode.GetBytes(src);
			return iso.GetString(unicodeBytes);
		}

		public static string ISO8859ToUnicode(string src)
		{
			Encoding iso = Encoding.GetEncoding("iso8859-1");
			Encoding unicode = Encoding.UTF8;
			byte[] isoBytes = iso.GetBytes(src);
			return unicode.GetString(isoBytes);
		}

        public static string UnicodeToPlain(object _unicodeText)
        {

            return UnicodeToPlain(_unicodeText.ToString(), false);
        }


        public static string ToPlainText(object _input)
        {
            return UnicodeToPlain(_input.ToString(), true) + System.Configuration.ConfigurationManager.AppSettings["Extension"];
        }

        public static string ToPlainTextNew(object _input)
        {
            return UnicodeToPlain1(_input.ToString(), true) + System.Configuration.ConfigurationManager.AppSettings["Extension"];
        }

        public static string UnicodeToPlain(string _unicodeText, bool removeChar)
        {
            if (string.IsNullOrEmpty(_unicodeText)) return string.Empty;

            int _length = _unicodeText.Length;

            StringBuilder _sb = new StringBuilder(_length);

            for (int i = 0; i < _length; i++)
            {

                char _char = _unicodeText[i];
                // char _charTemp;

                switch (_char)
                {

                    case 'đ':
                        _sb.Append('d');
                        break;
                    case 'Đ':
                        _sb.Append('D');
                        break;
                    case 'à':
                    case 'á':
                    case 'ạ':
                    case 'ả':
                    case 'ã':
                    case 'ă':
                    case 'ằ':
                    case 'ắ':
                    case 'ẳ':
                    case 'ặ':
                    case 'ẵ':
                    case 'â':
                    case 'ầ':
                    case 'ấ':
                    case 'ẩ':
                    case 'ẫ':
                    case 'ậ':
                        _sb.Append('a');
                        break;
                    case 'À':
                    case 'Á':
                    case 'Ạ':
                    case 'Ả':
                    case 'Ã':
                    case 'Ă':
                    case 'Ằ':
                    case 'Ắ':
                    case 'Ẳ':
                    case 'Ặ':
                    case 'Ẵ':
                    case 'Â':
                    case 'Ầ':
                    case 'Ấ':
                    case 'Ẩ':
                    case 'Ẫ':
                    case 'Ậ':
                        _sb.Append('A');
                        break;
                    case 'è':
                    case 'é':
                    case 'ẹ':
                    case 'ẻ':
                    case 'ẽ':
                    case 'ê':
                    case 'ề':
                    case 'ế':
                    case 'ể':
                    case 'ệ':
                    case 'ễ':
                        _sb.Append('e');
                        break;
                    case 'È':
                    case 'É':
                    case 'Ẹ':
                    case 'Ẻ':
                    case 'Ẽ':
                    case 'Ê':
                    case 'Ề':
                    case 'Ế':
                    case 'Ể':
                    case 'Ệ':
                    case 'Ễ':
                        _sb.Append('E');
                        break;

                    case 'ò':
                    case 'ó':
                    case 'ọ':
                    case 'ỏ':
                    case 'õ':
                    case 'ơ':
                    case 'ờ':
                    case 'ớ':
                    case 'ở':
                    case 'ợ':
                    case 'ỡ':
                    case 'ô':
                    case 'ồ':
                    case 'ố':
                    case 'ổ':
                    case 'ộ':
                    case 'ỗ':
                        _sb.Append('o');
                        break;
                    case 'Ò':
                    case 'Ó':
                    case 'Ọ':
                    case 'Ỏ':
                    case 'Õ':
                    case 'Ơ':
                    case 'Ờ':
                    case 'Ớ':
                    case 'Ở':
                    case 'Ợ':
                    case 'Ỡ':
                    case 'Ô':
                    case 'Ồ':
                    case 'Ố':
                    case 'Ổ':
                    case 'Ộ':
                    case 'Ỗ':
                        _sb.Append('O');
                        break;
                    case 'ù':
                    case 'ú':
                    case 'ụ':
                    case 'ủ':
                    case 'ũ':
                    case 'ư':
                    case 'ừ':
                    case 'ứ':
                    case 'ử':
                    case 'ự':
                    case 'ữ':
                        _sb.Append('u');
                        break;
                    case 'Ù':
                    case 'Ú':
                    case 'Ụ':
                    case 'Ủ':
                    case 'Ũ':
                    case 'Ư':
                    case 'Ừ':
                    case 'Ứ':
                    case 'Ử':
                    case 'Ự':
                    case 'Ữ':
                        _sb.Append('U');
                        break;
                    case 'ỳ':
                    case 'ý':
                    case 'ỵ':
                    case 'ỷ':
                    case 'ỹ':
                        _sb.Append('y');
                        break;
                    case 'Ỳ':
                    case 'Ý':
                    case 'Ỵ':
                    case 'Ỷ':
                    case 'Ỹ':
                        _sb.Append('Y');
                        break;
                    case 'ì':
                    case 'í':
                    case 'ị':
                    case 'ỉ':
                    case 'ĩ':
                        _sb.Append('i');
                        break;
                    case 'Ì':
                    case 'Í':
                    case 'Ị':
                    case 'Ỉ':
                    case 'Ĩ':
                        _sb.Append('I');
                        break;
                    default:
                        _sb.Append(_char);
                        break;
                }

            }

            if (removeChar)
            {
                _sb.Replace(" ", "-");
                _sb.Replace("&", "-");
                _sb.Replace("+", "-");
                _sb.Replace("/", "-");
                _sb.Replace(":", "-");
                _sb.Replace("?", String.Empty);
                _sb.Replace(",", String.Empty);
                _sb.Replace(".", String.Empty);
                _sb.Replace("\"", String.Empty);
                _sb.Replace("*", String.Empty);
                _sb.Replace("%", String.Empty);
                _sb.Replace(">", String.Empty);
                _sb.Replace("<", String.Empty);
                _sb.Replace("`", String.Empty);
                _sb.Replace("|", String.Empty);
                _sb.Replace("'", String.Empty);
                _sb.Replace("#", String.Empty);
                _sb.Replace("”", String.Empty);
                _sb.Replace("“", String.Empty);
                _sb.Replace(")", String.Empty);
                _sb.Replace("(", String.Empty);
                _sb.Replace("}", String.Empty);
                _sb.Replace("{", String.Empty);




            }

            return RemoveExtraHyphen(_sb.ToString());
        }

        public static string UnicodeToPlain1(string _unicodeText, bool removeChar)
        {
            if (string.IsNullOrEmpty(_unicodeText)) return string.Empty;

            int _length = _unicodeText.Length;

            StringBuilder _sb = new StringBuilder(_length);

            for (int i = 0; i < _length; i++)
            {

                char _char = _unicodeText[i];
                // char _charTemp;

                switch (_char)
                {

                    case 'đ':
                        _sb.Append('d');
                        break;
                    case 'Đ':
                        _sb.Append('D');
                        break;
                    case 'à':
                    case 'á':
                    case 'ạ':
                    case 'ả':
                    case 'ã':
                    case 'ă':
                    case 'ằ':
                    case 'ắ':
                    case 'ẳ':
                    case 'ặ':
                    case 'ẵ':
                    case 'â':
                    case 'ầ':
                    case 'ấ':
                    case 'ẩ':
                    case 'ẫ':
                    case 'ậ':
                        _sb.Append('a');
                        break;
                    case 'À':
                    case 'Á':
                    case 'Ạ':
                    case 'Ả':
                    case 'Ã':
                    case 'Ă':
                    case 'Ằ':
                    case 'Ắ':
                    case 'Ẳ':
                    case 'Ặ':
                    case 'Ẵ':
                    case 'Â':
                    case 'Ầ':
                    case 'Ấ':
                    case 'Ẩ':
                    case 'Ẫ':
                    case 'Ậ':
                        _sb.Append('A');
                        break;
                    case 'è':
                    case 'é':
                    case 'ẹ':
                    case 'ẻ':
                    case 'ẽ':
                    case 'ê':
                    case 'ề':
                    case 'ế':
                    case 'ể':
                    case 'ệ':
                    case 'ễ':
                        _sb.Append('e');
                        break;
                    case 'È':
                    case 'É':
                    case 'Ẹ':
                    case 'Ẻ':
                    case 'Ẽ':
                    case 'Ê':
                    case 'Ề':
                    case 'Ế':
                    case 'Ể':
                    case 'Ệ':
                    case 'Ễ':
                        _sb.Append('E');
                        break;

                    case 'ò':
                    case 'ó':
                    case 'ọ':
                    case 'ỏ':
                    case 'õ':
                    case 'ơ':
                    case 'ờ':
                    case 'ớ':
                    case 'ở':
                    case 'ợ':
                    case 'ỡ':
                    case 'ô':
                    case 'ồ':
                    case 'ố':
                    case 'ổ':
                    case 'ộ':
                    case 'ỗ':
                        _sb.Append('o');
                        break;
                    case 'Ò':
                    case 'Ó':
                    case 'Ọ':
                    case 'Ỏ':
                    case 'Õ':
                    case 'Ơ':
                    case 'Ờ':
                    case 'Ớ':
                    case 'Ở':
                    case 'Ợ':
                    case 'Ỡ':
                    case 'Ô':
                    case 'Ồ':
                    case 'Ố':
                    case 'Ổ':
                    case 'Ộ':
                    case 'Ỗ':
                        _sb.Append('O');
                        break;
                    case 'ù':
                    case 'ú':
                    case 'ụ':
                    case 'ủ':
                    case 'ũ':
                    case 'ư':
                    case 'ừ':
                    case 'ứ':
                    case 'ử':
                    case 'ự':
                    case 'ữ':
                        _sb.Append('u');
                        break;
                    case 'Ù':
                    case 'Ú':
                    case 'Ụ':
                    case 'Ủ':
                    case 'Ũ':
                    case 'Ư':
                    case 'Ừ':
                    case 'Ứ':
                    case 'Ử':
                    case 'Ự':
                    case 'Ữ':
                        _sb.Append('U');
                        break;
                    case 'ỳ':
                    case 'ý':
                    case 'ỵ':
                    case 'ỷ':
                    case 'ỹ':
                        _sb.Append('y');
                        break;
                    case 'Ỳ':
                    case 'Ý':
                    case 'Ỵ':
                    case 'Ỷ':
                    case 'Ỹ':
                        _sb.Append('Y');
                        break;
                    case 'ì':
                    case 'í':
                    case 'ị':
                    case 'ỉ':
                    case 'ĩ':
                        _sb.Append('i');
                        break;
                    case 'Ì':
                    case 'Í':
                    case 'Ị':
                    case 'Ỉ':
                    case 'Ĩ':
                        _sb.Append('I');
                        break;
                    default:
                        _sb.Append(_char);
                        break;
                }

            }

            if (removeChar)
            {
                _sb.Replace(" ", "-");
            }

            return RemoveExtraHyphen(_sb.ToString());
        }

        private static string RemoveExtraHyphen(string text)
        {
            const string replace = "--";
            if (text.Contains(replace))
            {
                text = text.Replace(replace, "-");
                return RemoveExtraHyphen(text);
            }

            return text;
        }
	}
}