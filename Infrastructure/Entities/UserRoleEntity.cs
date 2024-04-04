namespace Infrastructure.Entities
{
    public class UserRoleEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        // Otras propiedades específicas de UserRole

        public virtual UserEntity? User { get; set; }
        public virtual RoleEntity? Role { get; set; }
    }
}
