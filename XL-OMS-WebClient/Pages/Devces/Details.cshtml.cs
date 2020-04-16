using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using XL_OMS_WebClient.Data;
using XL_OMS_WebClient.Models;

namespace XL_OMS_WebClient.Pages.Devces
{
    public class DetailsModel : PageModel
    {
        private readonly XL_OMS_WebClient.Data.XL_OMS_WebClientContext _context;

        public DetailsModel(XL_OMS_WebClient.Data.XL_OMS_WebClientContext context)
        {
            _context = context;
        }

        public Device Device { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Device = await _context.Device.FirstOrDefaultAsync(m => m.Id == id);

            if (Device == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
