using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenHabitBackend.Core.Entities;

namespace OpenHabitBackend.Data.Context
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HabitDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<HabitDbContext>>()))
            {
                if (context.Habits.Any())
                {
                    return;
                }

                context.Habits.AddRange(
                    new Habit { Id = 1, Title = "Kitap Okumak", Description = "Günde 20 sayfa", IsCompleted = false, CreatedDate = DateTime.Now, UpdatedDate = null },
                    new Habit { Id = 2, Title = "Spor Yapmak", Description = "30 dakika yürüyüş", IsCompleted = true, CreatedDate = DateTime.Now, UpdatedDate = null }
                );
                
                context.SaveChanges();
            }
        }
    }
}