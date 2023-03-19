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
    public class DetailsModel : PageModel
    {
        private readonly Compet.ApplicationContext _context;

        public DetailsModel(Compet.ApplicationContext context)
        {
            _context = context;
        }

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
}
}
