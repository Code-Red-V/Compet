using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Compet;
using Compet.Models;

namespace Compet.Pages.Disciplines
{
    public class DeleteModel : PageModel
    {
        private readonly Compet.ApplicationContext _context;

        public DeleteModel(Compet.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Compet.Models.Discipline Discipline { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Discipline == null)
            {
                return NotFound();
            }

            var discipline = await _context.Discipline.FirstOrDefaultAsync(m => m.Id == id);

            if (discipline == null)
            {
                return NotFound();
            }
            else 
            {
                Discipline = discipline;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Discipline == null)
            {
                return NotFound();
            }
            var discipline = await _context.Discipline.FindAsync(id);

            if (discipline != null)
            {
                Discipline = discipline;
                _context.Discipline.Remove(Discipline);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
