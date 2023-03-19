using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Compet;
using Compet.Models;

namespace Compet.Pages.Participant
{
    public class DetailsModel : PageModel
    {
        private readonly Compet.ApplicationContext _context;

        public DetailsModel(Compet.ApplicationContext context)
        {
            _context = context;
        }

      public Compet.Models.Participant Participant { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Participant == null)
            {
                return NotFound();
            }

            var participant = await _context.Participant.FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }
            else 
            {
                Participant = participant;
            }
            return Page();
        }
    }
}
