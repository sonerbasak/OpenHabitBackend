using Microsoft.EntityFrameworkCore;
using OpenHabitBackend.Core.Entities;

namespace OpenHabitBackend.Data.Context
{
    public class HabitDbContext : DbContext
    {
        public HabitDbContext(DbContextOptions<HabitDbContext> options) : base(options)
        {
        }

        public DbSet<Habit> Habits { get; set; }
    }
}