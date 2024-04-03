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
    public class EditModel : PageModel
    {
        private readonly Sacrament_Meeting_PlannerContext _context;

        public EditModel(Sacrament_Meeting_PlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meeting Meeting
        {
            get; set;
        }

        [BindProperty]
        public string NewSpeaker
        {
            get; set;
        }

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Meeting).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostAddSpeakerAsync()
        {
            if (Meeting.Speakers == null)
            {
                Meeting.Speakers = new List<Speaker>();
            }

            var newSpeaker = new Speaker
            {
                Name = NewSpeaker
            };

            Meeting.Speakers.Add(newSpeaker);
            NewSpeaker = "";

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveSpeakerAsync(int id)
        {
            var speakerToRemove = await _context.Speakers.FindAsync(id);

            if (speakerToRemove != null)
            {
                _context.Speakers.Remove(speakerToRemove);
                await _context.SaveChangesAsync();
            }

            // Refresh Meeting object to reflect changes
            Meeting = await _context.Meetings
                .Include(m => m.Speakers)
                .FirstOrDefaultAsync(m => m.Id == Meeting.Id);

            return Page();
        }
    }
}
