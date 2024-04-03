using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sacrament_Meeting_Planner.Data;
using Sacrament_Meeting_Planner.Models;

namespace Sacrament_Meeting_Planner.Pages.Meetings
{
    public class IndexModel : PageModel
    {
        private readonly Sacrament_Meeting_PlannerContext _context;

        public IndexModel(Sacrament_Meeting_PlannerContext context)
        {
            _context = context;
        }

        public IList<Meeting> Meetings { get; set; } = new List<Meeting>();

        public async Task OnGetAsync()
        {
            Meetings = await _context.Meetings
            .Include(m => m.Speakers) 
            .ToListAsync();
        }
    }
}
