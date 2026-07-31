using Microsoft.AspNetCore.Mvc;
using OpenHabitBackend.Business.Abstract;
using OpenHabitBackend.Core.Entities;

namespace OpenHabitBackend.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly IHabitService _habitService;

        public HabitsController(IHabitService habitService)
        {
            _habitService = habitService;
        }

        [HttpGet]
        public IActionResult GetHabits()
        {
            var habits = _habitService.GetAllHabits();
            return Ok(habits);
        }

        [HttpPost]
        public IActionResult AddHabit([FromBody] Habit habit)
        {
            _habitService.AddHabit(habit);
                        return Ok(new { message = "Habit added successfully!", habit });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHabit(int id, [FromBody] Habit habit)
        {
            var existingHabit = _habitService.GetAllHabits().FirstOrDefault(h => h.Id == id);
            if (existingHabit == null)
            {
                return NotFound(new { message = "Habit not found!" });
            }

            _habitService.UpdateHabit(habit);
            return Ok(new { message = "Habit updated successfully!", habit });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHabit(int id)
        {
            var existingHabit = _habitService.GetAllHabits().FirstOrDefault(h => h.Id == id);
            if (existingHabit == null)
            {
                return NotFound(new { message = "Habit not found!" });
            }

            _habitService.DeleteHabit(existingHabit);
            return Ok(new { message = "Habit deleted successfully!" });
        }
    }
}