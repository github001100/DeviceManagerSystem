using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using XL_OMS_WebClient.Data;
using XL_OMS_WebClient.Models;

namespace XL_OMS_WebClient.Pages.Plans
{
    public class IndexModel : PageModel
    {
        private readonly XL_OMS_WebClient.Data.XL_OMS_WebClientContext _context;

        public IndexModel(XL_OMS_WebClient.Data.XL_OMS_WebClientContext context)
        {
            _context = context;
        }

        public IList<Plan> Plan { get;set; }

        public async Task OnGetAsync()
        {
            Plan = await _context.Plan.ToListAsync();
        }
    }
}
