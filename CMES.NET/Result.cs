using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMES.NET
{
    /// <summary>
    /// 返回信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T>
    {
        public int Total { get; set; }

        public List<T> Datas { get; set; }
    }
}
