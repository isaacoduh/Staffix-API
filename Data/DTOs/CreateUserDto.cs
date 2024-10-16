using System.ComponentModel.DataAnnotations;

namespace StaffixAPI.Models 
{
    public class CreateUserDto 
    {
        public CreateUserDto()
        {
            DateOfBirth = new DateTime(1900, 1, 1);
        }
        public required string Name {get; set;}
        public required string LastName {get; set;}
        public required string Email {get; set;}
        public required string Password {get; set;}
        public string? ConfirmPassword {get; set;}
        public string? ContactNumber {get; set;}
        public bool? Gender {get; set;}
        public DateTime? DateOfBirth {get; set;}
        public int RoleId {get; set;} = 3;
    }
}