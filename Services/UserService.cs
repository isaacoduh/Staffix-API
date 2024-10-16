using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StaffixAPI.Data;
using StaffixAPI.Entities;
using StaffixAPI.Exceptions;
using StaffixAPI.Models;
using StaffixAPI.Services.Interfaces;
using StaffixAPI.Utils;

namespace StaffixAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher passwordHasher;
        private readonly AppDbContext dbContext;

        public UserService(AppDbContext dbContext, IPasswordHasher passwordHasher)
        {
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user ?? throw new NotFoundException("User not found!");
        }

        public async Task<User> CreateUserAsync(CreateUserDto dto)
        {
            var passwordHash = passwordHasher.Hash(dto.Password);
            var newUser = new User
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = passwordHash,
                RoleId = dto.RoleId
            };
            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();
            return newUser;
        }

        
    }
}