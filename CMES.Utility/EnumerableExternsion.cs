using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CMES.Utility
{
    public static class EnumerableExternsion
    {
        /// <summary>
        /// 获取集合众某元素的索引
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this IEnumerable<T> source, T  value)
        {           
            for (int i = 0; i < source.Count(); i++)
            {
                if (value.Equals( source.ElementAt(i)) )
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// 取集合中最后几个值
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="lastCount"></param>
        /// <returns></returns>
        public static List<TSource> TakeLast<TSource>(this IEnumerable<TSource> source, int lastCount)
        {
            if (null == source || source.Count() == 0 )
                return null;

           return  new List<TSource>( source.Skip(source.Count() - lastCount) );
        }

        /// <summary>
        /// 取集合中的一段数值。
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Sub<TSource>(this IEnumerable<TSource> source, int startIndex, int count)
        {
            if (null == source)
                return null;

            return source.Skip(startIndex).Take(count);
        }

        /// <summary>
        /// 对数据分组
        /// </summary>
        /// <param name="source"></param>
        /// <param name="groupSize"></param>
        /// <returns></returns>
        public static List< List<TSource> > DivideGroup<TSource>(this IEnumerable<TSource> source, int groupSize)
        {
            int sourceCount = source.Count();
            int gourpCount = sourceCount / groupSize;

            List<List<TSource>> subs = new List<List<TSource>>();
            for (int i = 0; i < gourpCount; i++)
            {
                 List<TSource> sub = new List<TSource>(  source.Sub(i * groupSize, groupSize) );
                subs.Add(sub);
            }

            return subs;
        }
    }   
}
