using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiEmployee.Contexts
{
    public class PruebaDbContext(DbContextOptions<PruebaDbContext> options) : DbContext(options), IEmployeeContext
    {
        public DbSet<UserEntity> Users { get; set; }
    }
}
