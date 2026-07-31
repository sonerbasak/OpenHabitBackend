using OpenHabitBackend.Core.Entities;

namespace OpenHabitBackend.Business.Abstract
{
    public interface IHabitService
    {
        List<Habit> GetAllHabits();
        void AddHabit(Habit habit);
        void UpdateHabit(Habit habit);
        void DeleteHabit(Habit habit);
    }
}