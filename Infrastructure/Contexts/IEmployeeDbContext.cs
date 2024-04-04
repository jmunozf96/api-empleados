using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Contexts
{
    public interface IEmployeeDbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public EntityEntry Entry(object entity);
        public int SaveChanges();
    }
}
