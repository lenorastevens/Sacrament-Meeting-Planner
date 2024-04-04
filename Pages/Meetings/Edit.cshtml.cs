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

            // Find the meeting by its ID
            var meetingToUpdate = Meeting;
            if (meetingToUpdate == null)
            {
                return NotFound();
            }

            // Update the meeting properties
            if (await TryUpdateModelAsync<Meeting>(
                meetingToUpdate,

                "",
                m => m.Date, m => m.Presiding, m => m.Conducting,
                m => m.OpeningHymn, m => m.Invocation, m => m.SacramentHymn,
                m => m.IntermediateHymn, m => m.ClosingHymn, m => m.Benediction,
                m => m.SpeakerSubject))
            {
                // If NewSpeaker is not empty, add the new speaker to the meeting
                //var newSpeakerNames = Meeting.NewSpeakerNames?.Split(',');
                var speakersList = new List<Speaker>();
         
                if (NewSpeaker != null && NewSpeaker.Length > 0)
                {
                    // Add each new speaker to the Speakers table
                    var speakerName = NewSpeaker.Trim();
                   
                    
                    speakersList.Add(new Speaker { Name = speakerName, MeetingId =Meeting.Id });
                    
                }
                try
                {
                    _context.Speakers.AddRange(speakersList);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateException)
                {
                    // Log the error or handle as needed
                    ModelState.AddModelError("", "Unable to save changes. Please try again.");
                    return Page();
                }
            }

            return Page(); // Return the current page if model binding fails
        }

        /*
        public async Task<IActionResult> OnPostAddSpeakerAsync(string newSpeaker)
        {
            if (Meeting.Speakers == null)
            {
                Meeting.Speakers = new List<Speaker>();
            }





            var speaker = new Speaker { Name = newSpeaker }; // Create a new Speaker object from the newSpeaker string
            Meeting.Speakers.Add(speaker);

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
        */
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
