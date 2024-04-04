using Shared.Entities;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            UserRoles = [];
        }

        public int Id { get; set; }

        public required string Email { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }

        public string FullName { get; set; } = "";

        public string Password { get; set; } = "";

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
