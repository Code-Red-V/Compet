using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Compet;
using Compet.Models;

namespace Compet.Pages.ResultsCompetition
{
    public class DetailsModel : PageModel
    {
        private readonly Compet.ApplicationContext _context;

        public DetailsModel(Compet.ApplicationContext context)
        {
            _context = context;
        }

      public ResultsCompititions ResultsCompititions { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ResultsCompititions == null)
            {
                return NotFound();
            }

            var resultscompititions = await _context.ResultsCompititions.FirstOrDefaultAsync(m => m.Id == id);
            if (resultscompititions == null)
            {
                return NotFound();
            }
            else 
            {
                ResultsCompititions = resultscompititions;
            }
            return Page();
        }
    }
}
