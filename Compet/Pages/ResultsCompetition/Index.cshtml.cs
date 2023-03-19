using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Compet;
using Compet.Models;

namespace Compet.Pages.ResultsCompetition
{
    public class IndexModel : PageModel
    {
        private readonly Compet.ApplicationContext _context;

        public IndexModel(Compet.ApplicationContext context)
        {
            _context = context;
        }

        public IList<ResultsCompititions> ResultsCompititions { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ResultsCompititions != null)
            {
                ResultsCompititions = await _context.ResultsCompititions
                .Include(r => r.Discipline)
                .Include(r => r.Participant).ToListAsync();
            }
        }
    }
}
