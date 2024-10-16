using StaffixAPI.Entities;
using StaffixAPI.Models;

namespace StaffixAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(CreateUserDto dto);
        Task<User> GetByIdAsync(int id);
    }

}