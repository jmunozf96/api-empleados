namespace Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public required String Code { get; set; }

        public String? Description { get; set; }
    }
}
