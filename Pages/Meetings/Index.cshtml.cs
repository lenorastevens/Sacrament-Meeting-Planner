using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly Sacrament_Meeting_Planner.Data.Sacrament_Meeting_PlannerContext _context;

        public IndexModel(Sacrament_Meeting_Planner.Data.Sacrament_Meeting_PlannerContext context)
        {
            _context = context;
        }

        public IList<Meeting> Meeting { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Meeting = await _context.Meeting.ToListAsync();
        }
    }
}
