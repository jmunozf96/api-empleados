using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
