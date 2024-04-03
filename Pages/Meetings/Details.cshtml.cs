using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sacrament_Meeting_Planner.Data;
using Sacrament_Meeting_Planner.Models;

namespace Sacrament_Meeting_Planner.Pages.Meetings
{
    public class DetailsModel : PageModel
    {
        private readonly Sacrament_Meeting_PlannerContext _context;

        public DetailsModel(Sacrament_Meeting_PlannerContext context)
        {
            _context = context;
        }

        public Meeting Meeting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meeting = await _context.Meetings
                .Include(m => m.Speakers) 
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Meeting == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
