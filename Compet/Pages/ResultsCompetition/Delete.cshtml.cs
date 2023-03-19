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
    public class DeleteModel : PageModel
    {
        private readonly Compet.ApplicationContext _context;

        public DeleteModel(Compet.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ResultsCompititions == null)
            {
                return NotFound();
            }
            var resultscompititions = await _context.ResultsCompititions.FindAsync(id);

            if (resultscompititions != null)
            {
                ResultsCompititions = resultscompititions;
                _context.ResultsCompititions.Remove(ResultsCompititions);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
