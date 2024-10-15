using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffixAPI.Entities
{
    public class Role 
    {
        public int Id {get; set;}
        public required string Name {get; set;}
        public string? Description {get; set;}
    }
}