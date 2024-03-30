using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sacrament_Meeting_Planner.Models;

namespace Sacrament_Meeting_Planner.Data
{
    public class Sacrament_Meeting_PlannerContext : DbContext
    {
        public Sacrament_Meeting_PlannerContext (DbContextOptions<Sacrament_Meeting_PlannerContext> options)
            : base(options)
        {
        }

        public DbSet<Sacrament_Meeting_Planner.Models.Meeting> Meeting { get; set; } = default!;
    }
}
