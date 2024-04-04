﻿namespace ApiEmployee.Dtos.Employee
{
    public class EmployeeCreateDTO
    {
        public required string Email { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }

        public required string Position { get; set; }

        public required string Address { get; set; }

        public required string Phone { get; set; }
    }
}
