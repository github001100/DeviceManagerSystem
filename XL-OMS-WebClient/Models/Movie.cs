using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace XL_OMS_WebClient.Models
{
    public partial class Movie
    {
        public int ID { get; set; }
        [DisplayName("轮轴序列")]

        public string Genre { get; set; }
        [DisplayName("备用")]

        public decimal? Price { get; set; }
        [DisplayName("收入日期")]
        public DateTime? ReleaseDate { get; set; }
        [DisplayName("二维码")]
        public string Title { get; set; }
    }
}
