using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Compet;
using Compet.Models;

namespace Compet.Pages.ResultsCompetition
{
    public class CreateModel : PageModel
    {
        private readonly Compet.ApplicationContext _context;

        public CreateModel(Compet.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DisciplineId"] = new SelectList(_context.Discipline, "Id", "Name");
        ViewData["ParticipantId"] = new SelectList(_context.Participant, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public ResultsCompititions ResultsCompititions { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ResultsCompititions == null || ResultsCompititions == null)
            {
                return Page();
            }

            _context.ResultsCompititions.Add(ResultsCompititions);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
