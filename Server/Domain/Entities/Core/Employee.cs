using System.ComponentModel.DataAnnotations;

namespace Server.Domain.Entities.Core
{
    public class Employee: BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public int DepartmentId { get; set; }        
    }
}
