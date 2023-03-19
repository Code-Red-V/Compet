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
    public class IndexModel : PageModel
    {
        private readonly Compet.ApplicationContext _context;

        public IndexModel(Compet.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Compet.Models.Participant> Participant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Participant != null)
            {
                Participant = await _context.Participant
                .Include(p => p.Category).ToListAsync();
            }
        }
    }
}
