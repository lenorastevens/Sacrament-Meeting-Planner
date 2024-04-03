using Microsoft.EntityFrameworkCore;
using Sacrament_Meeting_Planner.Models;

namespace Sacrament_Meeting_Planner.Data
{
    public class Sacrament_Meeting_PlannerContext : DbContext
    {
        public Sacrament_Meeting_PlannerContext(DbContextOptions<Sacrament_Meeting_PlannerContext> options)
            : base(options)
        {
        }

        public DbSet<Meeting> Meetings
        {
            get; set;
        }
        public DbSet<Speaker> Speakers
        {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speaker>()
                .HasOne(s => s.Meeting)
                .WithMany(m => m.Speakers)
                .HasForeignKey(s => s.MeetingId);
        }
    }
}
