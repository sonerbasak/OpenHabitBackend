using OpenHabitBackend.Core.DTOs;
using OpenHabitBackend.Core.Entities;

namespace OpenHabitBackend.Business.Abstract
{
    public interface IUserService
    {
        List<UserResponseDto> GetAllUsers();        
        UserResponseDto? GetUserById(int id);        
        void Register(UserRegisterDto registerDto);
        void UpdateUser(int id, UserRegisterDto updateDto);
        void DeleteUser(int id);
    }
}