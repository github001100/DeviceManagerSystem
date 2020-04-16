using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XL_OMS_WebClient.Models;

namespace XL_OMS_WebClient.Data
{
    public class XL_OMS_WebClientContext : DbContext
    {
        public XL_OMS_WebClientContext (DbContextOptions<XL_OMS_WebClientContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }

        public DbSet<XL_OMS_WebClient.Models.Device> Device { get; set; }

        public DbSet<XL_OMS_WebClient.Models.Plan> Plan { get; set; }
    }
}
