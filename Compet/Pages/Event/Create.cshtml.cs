using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Compet;
using Compet.Models;

namespace Compet.Pages.Events
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
            return Page();
        }

        [BindProperty]
        public Compet.Models.Event Event { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Event == null || Event == null)
            {
                return Page();
            }

            _context.Event.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
