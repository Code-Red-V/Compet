using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Compet;
using Compet.Models;

namespace Compet.Pages.Events
{
    public class DeleteModel : PageModel
    {
        private readonly Compet.ApplicationContext _context;

        public DeleteModel(Compet.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Compet.Models.Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }

            var EventCheck = await _context.Event.FirstOrDefaultAsync(m => m.Id == id);

            if (EventCheck == null)
            {
            return NotFound();
        }
            else 
            {
            Event = EventCheck;
        }
            return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null || _context.Event == null)
        {
            return NotFound();
        }
        var EventCheck = await _context.Event.FindAsync(id);

        if (EventCheck != null)
            {
            Event = EventCheck;
            _context.Event.Remove(Event);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
}
