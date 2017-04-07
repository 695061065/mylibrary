using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mylibrary
{
    /// <summary>
    /// 网络类
    /// </summary>
    public static class NetHelper
    {


        #region 是否联网
        /// <summary>
        /// 网络是否通畅（Ping Baidu）
        /// </summary>
        /// <returns>通畅为真</returns>
        public static bool IfConnect()
        {
            System.Net.NetworkInformation.Ping ping;
            System.Net.NetworkInformation.PingReply res;
            ping = new System.Net.NetworkInformation.Ping();
            try
            {
                res = ping.Send("www.baidu.com");
                if (res.Status != System.Net.NetworkInformation.IPStatus.Success)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion


    }
}
