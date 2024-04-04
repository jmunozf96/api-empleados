using Shared.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    [Table("Users")]
    public class UserEntity : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required, Key]
        public int Id { get; set; }

        [DataType(DataType.EmailAddress)]
        public required String Email { get; set; }

        public required String Name { get; set; }

        public required String LastName { get; set; }

        public required String Password { get; set; }
    }
}
