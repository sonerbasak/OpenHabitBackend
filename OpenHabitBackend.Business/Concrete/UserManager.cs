using OpenHabitBackend.Business.Abstract;
using OpenHabitBackend.Core.DTOs;
using OpenHabitBackend.Core.Entities;
using OpenHabitBackend.Data.Context;

namespace OpenHabitBackend.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly HabitDbContext _context;

        public UserManager(HabitDbContext context)
        {
            _context = context;
        }

        public List<UserResponseDto> GetAllUsers() => _context.Users.Select(u => new UserResponseDto
        {
            Id = u.Id,
            Username = u.Username,
            Email = u.Email,
            CreatedDate = u.CreatedDate
        }).ToList();

        public UserResponseDto? GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return null;
            return new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedDate = user.CreatedDate
            };
        }

        public void Register(UserRegisterDto registerDto)
        {
            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = "hashed_" + registerDto.Password // Basit simülasyon
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(int id, UserRegisterDto updateDto)
        {
            var existingUser = _context.Users.Find(id);
            if (existingUser != null)
            {
                existingUser.Username = updateDto.Username;
                existingUser.Email = updateDto.Email;
                existingUser.PasswordHash = "hashed_" + updateDto.Password;
                _context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}