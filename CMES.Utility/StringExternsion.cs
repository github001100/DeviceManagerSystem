using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CMES.Utility 
{
    public static class StringExternsion
    {
        public static string Left(this String s, int count)
        {
            if (0 >= count)
                return string.Empty;

            if (count > s.Length)
                return s;

            return s.Substring(0, count);
        }

        public static string Right(this String s, int count)
        {
            if (0 >= count)
                return string.Empty;

            if (count > s.Length)
                return s;

            int pos = s.Length - count;
            return s.Substring(pos, count);
        }

        /// <summary>
        /// 转成整形数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(this String s, int def)
        {
            try
            {
                int v = Convert.ToInt32(s);
                return v;
            }
            catch
            {
                return def;
            }
        }

        /// <summary>
        /// 转成浮点数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static float ToFloat(this String s, float def)
        {
            try
            {
                float v = Convert.ToSingle(s);
                return v;
            }
            catch
            {
                return def;
            }
        }
    }
}
