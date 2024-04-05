using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shared.Entities;
using Shared.Options;
using Shared.Utils;
using System.Data;

namespace ApiEmployee.Contexts
{
    public class PruebaDbContext(DbContextOptions<PruebaDbContext> options, IOptionsSnapshot<DefaultValue> snapshot) : DbContext(options), IEmployeeDbContext
    {
        private readonly DefaultValue _snapshot = snapshot.Value;

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { Id = 1, Code = RolesUtil.Admin },
                new RoleEntity { Id = 2, Code = RolesUtil.Employee }
            );

            modelBuilder.Entity<UserRoleEntity>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRoleEntity>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRoleEntity>()
                .HasOne(ur => ur.Role)
                .WithMany()
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<EmployeeEntity>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<EmployeeEntity>()
                .HasOne(e => e.User)
                .WithOne()
                .HasForeignKey<EmployeeEntity>(e => e.UserId)
                .IsRequired();

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = 1,
                    Email = "admin@example.com",
                    Name = "Admin",
                    LastName = "User",
                    Password = _snapshot.AdminPassword,
                    CreatedAt = DateTime.UtcNow,
                }
            );

            modelBuilder.Entity<UserRoleEntity>().HasData(
               new UserRoleEntity { UserId = 1, RoleId = 1 }
           );

            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }


        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
}
