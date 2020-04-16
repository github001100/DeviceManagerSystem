using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using XL_OMS_WebClient.Data;
using XL_OMS_WebClient.Models;

namespace XL_OMS_WebClient.Pages.Devces
{
    public class CreateModel : PageModel
    {
        private readonly XL_OMS_WebClient.Data.XL_OMS_WebClientContext _context;

        public CreateModel(XL_OMS_WebClient.Data.XL_OMS_WebClientContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Device Device { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Device.Add(Device);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
