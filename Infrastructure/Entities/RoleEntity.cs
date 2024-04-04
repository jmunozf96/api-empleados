using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    [Table("Roles")]
    public class RoleEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required, Key]
        public int Id { get; set; }

        public required String Code { get; set; }

        public String? Description { get; set; }
    }
}
