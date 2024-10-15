using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;


using StaffixAPI.Entities;

namespace StaffixAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {}

        public DbSet<Role> Roles {get; set;}
    }
}