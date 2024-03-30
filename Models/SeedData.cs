using Sacrament_Meeting_Planner.Data;
using Microsoft.EntityFrameworkCore;

namespace Sacrament_Meeting_Planner.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Sacrament_Meeting_PlannerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Sacrament_Meeting_PlannerContext>>()))
            {
                if (context == null || context.Meeting == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Meeting.Any())
                {
                    return;   // DB has been seeded
                }

                context.Meeting.AddRange(
                    new Meeting
                    {
                        Date = DateTime.Now,
                        Presiding = "President Smith",
                        Conducting = "Bishop Severson",
                        OpeningHymn = 2,
                        Invocation = "Brother Romero",
                        SacramentHymn = 0194,
                        IntermediateHymn = 304,
                        ClosingHymn = 302,
                        Benediction = "Sister Gilmore",
                        SpeakerSubject = "Walk In The Light",
                        Speakers = ["Elijah Neighman", "Sister McComas", "Brother Spears"]
                    },

                    new Meeting
                    {
                        Date = DateTime.Now,
                        Presiding = "President Stout",
                        Conducting = "Bishop Severson",
                        OpeningHymn = 3,
                        Invocation = "Brother Stevens",
                        SacramentHymn = 198,
                        IntermediateHymn = 54,
                        ClosingHymn = 220,
                        Benediction = "Sister Robinson",
                        SpeakerSubject = "Procastination",
                        Speakers = ["Alex Stevens", "Sister Romero", "Brother Cole"]
                    },

                    new Meeting
                    {
                        Date = DateTime.Now,
                        Presiding = "President Whiting",
                        Conducting = "Brother Severson",
                        OpeningHymn = 19,
                        Invocation = "Sister Williams",
                        SacramentHymn = 189,
                        IntermediateHymn = 219,
                        ClosingHymn = 26,
                        Benediction = "Brother Kilgore",
                        SpeakerSubject = "Expect Miracles",
                        Speakers = ["Evan Shreeve", "Wyatt Simpson", "Elder Lucas"]
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
