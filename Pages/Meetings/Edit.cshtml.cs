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

        public async Task<IActionResult> OnPostAsync(int MeetingId)
        {
            if (MeetingId == null)
            {
                return NotFound();
            }

            var meetingToUpdate = await _context.Meetings
                .FirstOrDefaultAsync(s => s.Id == MeetingId);

            if (meetingToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Meeting>(
                meetingToUpdate,
                "meeting",
                m => m.Date, m => m.Presiding, m => m.Conducting,
                m => m.OpeningHymn, m => m.Invocation, m => m.SacramentHymn,
                m => m.IntermediateHymn, m => m.ClosingHymn, m => m.Benediction,
                m => m.SpeakerSubject))
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                try
                {
                    // Save changes to the meeting first
                    await _context.SaveChangesAsync();

                    // Now create and save speakers if needed
                    if (!string.IsNullOrEmpty(NewSpeaker))
                    {
                        var speakerName = NewSpeaker.Trim();
                        var speaker = new Speaker { Name = speakerName, MeetingId = MeetingId };
                        _context.Speakers.Add(speaker);
                        await _context.SaveChangesAsync();
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
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
         */
        public async Task<IActionResult> OnPostRemoveSpeakerAsync(int speakerId)
        {
            var speakerToRemove = await _context.Speakers.FindAsync(speakerId);

            if (speakerToRemove == null)
            {
                return NotFound();
            }

            _context.Speakers.Remove(speakerToRemove);
            await _context.SaveChangesAsync();

            // Redirect back to the same page or wherever appropriate
            return RedirectToPage("./Edit", new { id = speakerToRemove.MeetingId });
        }


    }
}
