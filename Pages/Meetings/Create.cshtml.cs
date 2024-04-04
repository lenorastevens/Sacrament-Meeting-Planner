using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sacrament_Meeting_Planner.Data;
using Sacrament_Meeting_Planner.Models;

namespace Sacrament_Meeting_Planner.Pages.Meetings
{
    public class CreateModel : PageModel
    {
        private readonly Sacrament_Meeting_PlannerContext _context;

        public CreateModel(Sacrament_Meeting_PlannerContext context)
        {
            _context = context;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Meeting Meeting { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync([Bind("Date,Presiding,Conducting,OpeningHymn,Invocation,SacramentHymn,IntermediateHymn,ClosingHymn,Benediction,SpeakerSubject")] Meeting meeting, string speakers)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Add the meeting to the database
            _context.Meetings.Add(meeting);
            await _context.SaveChangesAsync();

            // Add speakers
            var speakersList = new List<Speaker>();
            if (!string.IsNullOrEmpty(speakers))
            {
                var speakerNames = speakers.Split(',').Select(s => s.Trim());
                foreach (var name in speakerNames)
                {
                    speakersList.Add(new Speaker { Name = name, MeetingId = meeting.Id });
                }
            }

            // Add speakers to the database
            _context.Speakers.AddRange(speakersList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
