using Domain.Models.Commands;
using Shared.Entities;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public int Id { get; set; }

        public required string Position { get; set; }

        public required string Address { get; set; }

        public required string Phone { get; set; }

        public required User User { get; set; }
    }
}
