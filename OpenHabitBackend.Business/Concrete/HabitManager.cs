using OpenHabitBackend.Business.Abstract;
using OpenHabitBackend.Core.Entities;
using OpenHabitBackend.Data.Context;

namespace OpenHabitBackend.Business.Concrete
{
    public class HabitManager : IHabitService
    {
        private readonly HabitDbContext _context;

        public HabitManager(HabitDbContext context)
        {
            _context = context;
        }

        public List<Habit> GetAllHabits()
        {
            return _context.Habits.ToList();
        }

        public void AddHabit(Habit habit)
        {
            _context.Habits.Add(habit);
            _context.SaveChanges(); 
        }

        public void UpdateHabit(Habit habit)
        {
            var existingHabit = _context.Habits.Find(habit.Id);
            if (existingHabit != null)
            {
                existingHabit.Title = habit.Title;
                existingHabit.Description = habit.Description;
                existingHabit.IsCompleted = habit.IsCompleted;
                existingHabit.UpdatedDate = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void DeleteHabit(Habit habit)
        {
            _context.Habits.Remove(habit);
            _context.SaveChanges();
        }
    }
}