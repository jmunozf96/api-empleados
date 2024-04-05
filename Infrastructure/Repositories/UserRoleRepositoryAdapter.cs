using Domain.Ports.Out;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class UserRoleRepositoryAdapter(IEmployeeDbContext context) : UserRoleRepositoryPort
    {
        private readonly IEmployeeDbContext Context = context;

        public void DeleteByUserId(int id)
        {
            var entities = Context.UserRoles.Where(c => c.UserId == id).ToList();
            Context.UserRoles.RemoveRange(entities);
            Context.SaveChanges();
        }
    }
}
