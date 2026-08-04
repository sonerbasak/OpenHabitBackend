namespace OpenHabitBackend.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; } // Güvenlik için şifrenin hashlenmiş hali tutulmalıdır
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}