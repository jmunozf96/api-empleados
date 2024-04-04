namespace Domain.Entities
{
    public class UserRole
    {
        public virtual User? User { get; set; }
        public virtual required Role Role { get; set; }
    }
}
