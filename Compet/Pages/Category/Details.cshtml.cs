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
    public class DetailsModel : PageModel
    {
        private readonly Compet.ApplicationContext _context;

        public DetailsModel(Compet.ApplicationContext context)
        {
            _context = context;
        }

      public Compet.Models.Category Category { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            else 
            {
                Category = category;
            }
            return Page();
        }
    }
}
