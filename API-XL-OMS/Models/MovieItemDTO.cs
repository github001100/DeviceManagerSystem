﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_XL_OMS.Models
{
    public class MovieItemDTO
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public decimal? Price { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Title { get; set; }

    }
}
