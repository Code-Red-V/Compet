using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Compet;
using Compet.Models;

namespace Compet.Pages.ResultsCompetition
{
    public class EditModel : PageModel
    {
        private readonly Compet.ApplicationContext _context;

        public EditModel(Compet.ApplicationContext context)
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

            var resultscompititions =  await _context.ResultsCompititions.FirstOrDefaultAsync(m => m.Id == id);
            if (resultscompititions == null)
            {
                return NotFound();
            }
            ResultsCompititions = resultscompititions;
           ViewData["DisciplineId"] = new SelectList(_context.Discipline, "Id", "Name");
           ViewData["ParticipantId"] = new SelectList(_context.Participant, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ResultsCompititions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultsCompititionsExists(ResultsCompititions.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ResultsCompititionsExists(int id)
        {
          return (_context.ResultsCompititions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
