using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Compet.Models;

using Microsoft.EntityFrameworkCore;

namespace Compet.Pages.Search
{
    public class BasicModel : PageModel
    {
        private readonly ApplicationContext _context;

        public BasicModel(ApplicationContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string searchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string value { get; set; }
        public IList<Compet.Models.Participant> Participants { get; set; }
        public IList<Compet.Models.Event> Events { get; set; }
        public bool IsNull { get; set; } = false;
        public int? count { get; set; }
        public void OnGet()
        {
            if (value == "Participients")
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    var participants = _context.Participant.Include(a => a.Category).Where(a => a.Name.Contains(searchString)).ToList();
                    Participants = participants;
                }
            }
            else if (value == "Events")
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    var events = _context.Event.Include(a => a.Discipline).Where(n => n.Discipline.Name.Contains(searchString)).ToList();
                    if (!events.Any())
                    {
                        IsNull = true;
                    }
                    Events = events;
                }
            }
        }
    }
}
