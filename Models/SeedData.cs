using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sacrament_Meeting_Planner.Models;

namespace Sacrament_Meeting_Planner.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Sacrament_Meeting_PlannerContext(
                serviceProvider.GetRequiredService<DbContextOptions<Sacrament_Meeting_PlannerContext>>()))
            {
                if (context.Meetings.Any())
                {
                    return;   // DB has been seeded
                }

                context.Meetings.AddRange(
                    new Meeting
                    {
                        Date = new DateTime(2024, 03, 17),
                        Presiding = "Bishop Severson",
                        Conducting = "Rex Petersen",
                        OpeningHymn = "#81 Press Forward Saints",
                        Invocation = "Kwan McComas",
                        SacramentHymn = "#195 How Great the Wisdom and the Love",
                        IntermediateHymn = "#277 As I Search the Holy Scriptures",
                        ClosingHymn = "#14 Sweet is the Peace the Gosple Brings",
                        Benediction = "Steven Hall",
                        SpeakerSubject = "Blessings of the Book of Mormon",
                        Speakers = new List<Speaker>
                        {
                            new Speaker { Name = "June Barclay" },
                            new Speaker { Name = "Judy Parnell" },
                            new Speaker { Name = "Elaine Gilmore" }
                        }
                    },
                    new Meeting
                    {
                        Date = new DateTime(2024, 03, 23),
                        Presiding = "President Smith",
                        Conducting = "Bishop Severson",
                        OpeningHymn = "#239 Choose the Right",
                        Invocation = "Mark Hilton",
                        SacramentHymn = "#183 In Remembrance of Thy Suffering",
                        IntermediateHymn = "#304 Teach Me to Walk in the Light",
                        ClosingHymn = "#106 God Speed the Right",
                        Benediction = "Tom Stevens",
                        SpeakerSubject = "Ward Conference",
                        Speakers = new List<Speaker>
                        {
                            new Speaker { Name = "Bishop Severson" },
                            new Speaker { Name = "President Smith" },
                        }
                    },
                    new Meeting
                    {
                        Date = new DateTime(2024, 03, 31),
                        Presiding = "Bishop Severson",
                        Conducting = "Rex Petersen",
                        OpeningHymn = "#193 I Stand All Amazed",
                        Invocation = "Laurie McGrath",
                        SacramentHymn = "#192 Hed Died! The Great Redeemer Died",
                        IntermediateHymn = "#193 I Stand All Amazed",
                        ClosingHymn = "#199 He Is Risen",
                        Benediction = "Aly Smith",
                        SpeakerSubject = "Easter",
                        Speakers = new List<Speaker>
                        {
                            new Speaker { Name = "Truman Carroll" },
                            new Speaker { Name = "Jeri Pennock" },
                            new Speaker { Name = "Ruth Gardiner" }
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
