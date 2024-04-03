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
                        Date = DateTime.Now,
                        Presiding = "President Smith",
                        Conducting = "Bishop Severson",
                        OpeningHymn = "2", 
                        Invocation = "Brother Romero",
                        SacramentHymn = "194", 
                        IntermediateHymn = "304", 
                        ClosingHymn = "302", 
                        Benediction = "Sister Gilmore",
                        SpeakerSubject = "Walk In The Light",
                        Speakers = new List<Speaker>
                        {
                            new Speaker { Name = "Elijah Neighman" },
                            new Speaker { Name = "Sister McComas" },
                            new Speaker { Name = "Brother Spears" }
                        }
                    },
                    new Meeting
                    {
                        Date = DateTime.Now,
                        Presiding = "President Stout",
                        Conducting = "Bishop Severson",
                        OpeningHymn = "3", 
                        Invocation = "Brother Stevens",
                        SacramentHymn = "198", 
                        IntermediateHymn = "54", 
                        ClosingHymn = "220", 
                        Benediction = "Sister Robinson",
                        SpeakerSubject = "Procrastination",
                        Speakers = new List<Speaker>
                        {
                            new Speaker { Name = "Alex Stevens" },
                            new Speaker { Name = "Sister Romero" },
                            new Speaker { Name = "Brother Cole" }
                        }
                    },
                    new Meeting
                    {
                        Date = DateTime.Now,
                        Presiding = "President Whiting",
                        Conducting = "Brother Severson",
                        OpeningHymn = "19", 
                        Invocation = "Sister Williams",
                        SacramentHymn = "189", 
                        IntermediateHymn = "219", 
                        ClosingHymn = "26", 
                        Benediction = "Brother Kilgore",
                        SpeakerSubject = "Expect Miracles",
                        Speakers = new List<Speaker>
                        {
                            new Speaker { Name = "Evan Shreeve" },
                            new Speaker { Name = "Wyatt Simpson" },
                            new Speaker { Name = "Elder Lucas" }
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
