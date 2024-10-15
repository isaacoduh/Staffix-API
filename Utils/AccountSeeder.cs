using StaffixAPI.Data;
using StaffixAPI.Entities;

namespace StaffixAPI.Utils
{
    public class AccountSeeder
    {
        private readonly AppDbContext _db;
        public AccountSeeder(AppDbContext db)
        {
            _db = db;
        }

        public void SeedRoles() 
        {
            if(_db.Database.CanConnect()) {
                if(!_db.Roles.Any())
                {
                    var roles = GetRoles();
                    _db.Roles.AddRange(roles);
                    _db.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>() {
                new Role() 
                {
                    Id = 1,
                    Name = "Admin",
                    Description = "admin"                
                },
                new Role()
                {
                    Id = 2,
                    Name = "Manager",
                    Description = "Manager"
                },
                new Role()
                {
                    Id = 3,
                    Name = "Employee",
                    Description = "Employee"
                }
            };
            return roles;
        }
    }

}