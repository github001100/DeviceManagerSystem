using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CMES.Utility
{
    public static class MathUtils
    {
        /// <summary>
        /// 判断两个浮点数是否相等      
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        static public bool Equal(float f1, float f2)
        {
            float prec = 0.1F;
            return Math.Abs(f1 - f2) < prec;
        }

        /// <summary>
        /// 角度值转弧度值
        /// </summary>
        /// <param name="degree">角度值，单位 °</param>
        /// <returns></returns>
        static public float DegreeToRadian(float degree)
        {
            // double d = 3.1415926535897932384626433832795 / 180;
            // d = 0.01745329251994329576923690768489;
            return degree * 0.01745329251994329576923690768489F;
        }
    }
}
