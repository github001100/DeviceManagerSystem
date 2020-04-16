using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace XL_OMS_WebClient.Pages
{
    public class LDKPModel : PageModel
    {
        private readonly ILogger<LDKPModel> _logger;

        public LDKPModel(ILogger<LDKPModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
