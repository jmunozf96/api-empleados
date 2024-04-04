using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public int Id { get; set; }

        public required String Position { get; set; }

        public required String Address { get; set; }

        public required String Phone { get; set; }

        public required User User { get; set; }
    }
}
