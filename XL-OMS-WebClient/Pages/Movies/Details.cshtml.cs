using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using XL_OMS_WebClient.Data;
using XL_OMS_WebClient.Models;

namespace XL_OMS_WebClient.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly XL_OMS_WebClient.Data.XL_OMS_WebClientContext _context;

        public DetailsModel(XL_OMS_WebClient.Data.XL_OMS_WebClientContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
