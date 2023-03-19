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
    public class DetailsModel : PageModel
    {
        private readonly Compet.ApplicationContext _context;

        public DetailsModel(Compet.ApplicationContext context)
        {
            _context = context;
        }

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
    }
}
