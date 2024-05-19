using Game.Model;
using Google.Authenticator;
using System;

namespace Game.Common
{
    public sealed class GoogleHelp
    {
        /// <summary>
        /// 生产邮件验证码
        /// </summary>
        /// <returns></returns>
        internal static string RandomEmail()
        {
            string str = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {

                str += random.Next(9);
            }
            return str;

        }
        /// <summary>
        /// google验证其
        /// </summary>
        /// <param name="ym"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        internal static RtnGoogle SetCode(string ym, string userName,out string key)

        {
            key= Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            SetupCode setupInfo = tfa.GenerateSetupCode(ym, userName, key, false, 3);
          
            return new RtnGoogle()
            {
                ImgSrc = setupInfo.QrCodeSetupImageUrl.Split(',')[1],
                GoogleSg = setupInfo.ManualEntryKey,
            };
        }
        /// <summary>
        /// 校验谷歌验证码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        internal static bool CheckCode(string code,string Googlekey)
        {

            return new TwoFactorAuthenticator().ValidateTwoFactorPIN(Googlekey, code);
        }
    }
}
