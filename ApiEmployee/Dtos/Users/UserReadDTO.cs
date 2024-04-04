namespace ApiEmployee.Dtos.Users
{
    public class UserReadDTO
    {
        public int Id { get; set; }

        public required String Email { get; set; }

        public required String Name { get; set; }

        public required String LastName { get; set; }

        public String FullName { get; set; } = "";
    }
}
