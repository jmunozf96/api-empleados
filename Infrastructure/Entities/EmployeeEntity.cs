using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Shared.Entities;

namespace Infrastructure.Entities
{
    [Table("Employees")]
    public class EmployeeEntity : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required, Key]
        public int Id { get; set; }

        public required string Position { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public required int UserId { get; set; } 
        public required UserEntity User { get; set; }
    }
}
