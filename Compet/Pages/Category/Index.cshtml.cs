using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Compet;
using Compet.Models;

namespace Compet.Pages.Categorys
{
    public class IndexModel : PageModel
    {
        private readonly Compet.ApplicationContext _context;

        public IndexModel(Compet.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Compet.Models.Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Category != null)
            {

                Category = await _context.Category.ToListAsync();
            }
        }
    }
}
