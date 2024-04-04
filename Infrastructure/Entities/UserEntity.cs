using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    [Table("Users")]
    public class UserEntity : BaseEntity
    {
        public UserEntity()
        {
            UserRoles = [];
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required, Key]
        public int Id { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public required String Email { get; set; }

        public required String Name { get; set; }

        public required String LastName { get; set; }

        public required String Password { get; set; }

        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
