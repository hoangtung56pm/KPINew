using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.IO;
/// <summary>
/// Summary description for Sercurity
/// </summary>
///
namespace VmgPortal.Library.Components.Security
{
    public class SSOSecurity
    {
        public SSOSecurity()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string Encrypt(string Data, byte[] Key, byte[] IV)
        {
            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                // Convert the passed string to a byte array.
                byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();


                return Convert.ToBase64String(ret);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }

        }

        public static string Decrypt(string Data, byte[] Key, byte[] IV)
        {
            try
            {


                MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(Data));

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[Data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                string ReturnValue = new ASCIIEncoding().GetString(fromEncrypt);
                if (ReturnValue.Contains("\0\0\0"))
                {
                    ReturnValue = ReturnValue.Remove(ReturnValue.IndexOf("\0\0\0"));
                }
                return ReturnValue;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        public static string EncryptMd5(string YourString)
        {
            byte[] MyByte = new byte[16];
            MyByte = MD5.Create().ComputeHash(Encoding.Default.GetBytes(YourString));
            string MyEncryptString = string.Empty;
            for (int i = 0; i < 16; i++)
            {
                MyEncryptString += MyByte[i].ToString("x2");
            }
            return MyEncryptString;

        }

        public static string ConvertToString(byte[] YourByte)
        {
            StringBuilder MyString = new StringBuilder();

            for (int i = 0; i < YourByte.Length; i++)
            {

                MyString.Append(YourByte[i]);


            }
            return MyString.ToString();

        }
      
    }
}
