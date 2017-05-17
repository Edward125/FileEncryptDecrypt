using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Windows.Forms;

namespace Edward
{
    /// <summary>
    /// 其他一些常用操作
    /// </summary>
   public static class Other
    {

        #region DeleteMyself
		 
        /// <summary>
        /// delete myselef
        /// </summary>
        public static void DelMe()
        {
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "remove.bat");

            StreamWriter bat = new StreamWriter(fileName, false, Encoding.Default);
            bat.WriteLine(string.Format("del \"{0}\" /q", Application.ExecutablePath));
            bat.WriteLine(string.Format("del \"{0}\" /q", fileName));
            bat.Close();
            File.SetAttributes(fileName, FileAttributes.Hidden);
            ProcessStartInfo info = new ProcessStartInfo(fileName);
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info);
            Environment.Exit(0);
        }

        #endregion

    }
}
