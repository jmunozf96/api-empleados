using ApiEmployee.Dtos.Users;
using Domain.Entities;

namespace ApiEmployee.Dtos.Employees
{
    public class EmployeeReadDTO
    {
        public int Id { get; set; }

        public required String Position { get; set; }

        public required String Address { get; set; }

        public required String Phone { get; set; }

        public required UserReadDTO User { get; set; }
    }
}
