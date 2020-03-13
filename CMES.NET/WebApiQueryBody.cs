using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMES.NET
{
    public class WebApiQueryBody
    {
        /// <summary>
        /// 跳过多少个
        /// </summary>
        public int Skip { get; set; } = 0;

        /// <summary>
        /// 返回的最大数量
        /// </summary>
        public int Limit { get; set; } = 50;

        /// <summary>
        /// 查询条件
        /// { "加工数量": 1, "设备": { $gt: "2" } }
        /// </summary>
        public Dictionary<string, object> Filter { get; set; }

        /// <summary>
        /// 返回数据
        /// 1是包含，0是不包含
        /// { "测量值2": 1, "测量值1": 0}
        /// </summary>
        public Dictionary<string, int> Projection { get; set; }

        /// <summary>
        /// 排序
        /// 1是升序，-1是降序
        /// {"参数1", 1, "参数2":,-1}
        /// </summary>
        public Dictionary<string, int> Sort { get; set; }
    }
}
