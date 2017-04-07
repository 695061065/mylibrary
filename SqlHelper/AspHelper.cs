using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mylibrary
{
    class AspHelper
    {
        /// <summary>
        /// 获取内容中第一张图片
        /// </summary>
        /// <param name="htmlText"></param>
        /// <returns></returns>
        public static string GetFirstImages(string htmlText)
        {
            const string pattern = "<img [^~]*?>";
            const string pattern1 = "src\\s*=\\s*((\"|\')?)(?<url>\\S+)(\"|\')?[^>]*";
            string s = null;
            Match match = Regex.Match(htmlText, pattern, RegexOptions.IgnoreCase);  //找到img标记
            if (match.Success)
            {
                string img = match.Value;
                string imgsrc = Regex.Match(img, pattern1, RegexOptions.IgnoreCase).Result("${url}");
                imgsrc = Regex.Replace(imgsrc, "\"|\'|\\>", "", RegexOptions.IgnoreCase);
                s = imgsrc;
            }
            return s;
        }
    }
}
