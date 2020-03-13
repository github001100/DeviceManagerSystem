//=====================================================================================
// All Rights Reserved , Copyright © KYJJ.MES 2018
//=====================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace CMES.Util
{
    /// <summary>
    /// MD5加密帮助类
    /// 版本：2.0
    /// <author>
    ///		<name>CAYA</name>
    ///		<date>2018.09.27</date>
    /// </author>
    /// </summary>
    public class Md5Helper
    {
        #region "MD5加密"
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">加密字符</param>
        /// <param name="code">加密位数16/32</param>
        /// <returns></returns>
        //public static string MD5(string str, int code)
        //{
        //    string strEncrypt = string.Empty;
        //    if (code == 16)
        //    {
        //        strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(8, 16);
        //    }

        //    if (code == 32)
        //    {
        //        strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        //    }

        //    return strEncrypt;
        //}
        /// <summary>		
        /// MD5加密类
        /// </summary>
        /// <param name="clearText">未加密的字符串</param>
        /// <param name="encryptedText">加密过的字符串</param>
        public static void MD5Encrypt(string clearText, ref string encryptedText)
        {
            try
            {
                if (clearText == null)
                    clearText = "";
                MD5CryptoServiceProvider o_MD5 = new MD5CryptoServiceProvider();
                byte[] bytesEncrypt = Encoding.Default.GetBytes(clearText);
                byte[] bytesEncrypted = o_MD5.ComputeHash(bytesEncrypt, 0, bytesEncrypt.Length);
                encryptedText = "";
                for (int i = 0; i < bytesEncrypted.Length; i++)
                {
                    encryptedText += bytesEncrypted[i].ToString("x").PadLeft(2, '0');
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// MD5加密，返回加密后的文本
        /// </summary>
        /// <param name="clearText">明文</param>
        /// <returns>加密后文本</returns>         
        public static string MD5Encrypt(string clearText)
        {
            string encryptedString = "";
            MD5Encrypt(clearText, ref encryptedString);
            return encryptedString;
        }
        #endregion
    }
}
