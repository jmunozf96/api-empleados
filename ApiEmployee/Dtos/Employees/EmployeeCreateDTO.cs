﻿namespace ApiEmployee.Dtos.Employee
{
    public class EmployeeCreateDTO
    {
        public required string Email { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }

        public required string Position { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }
    }
}
