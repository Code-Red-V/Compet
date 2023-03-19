using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Compet;
using Compet.Models;

namespace Compet.Pages.Participant
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
        ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Compet.Models.Participant Participant { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Participant == null || Participant == null)
            {
                return Page();
            }

            _context.Participant.Add(Participant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
