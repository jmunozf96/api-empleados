using Abp.Domain.Entities;
using AutoMapper;
using Domain.Entities;
using Domain.Ports.Out;
using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepositoryAdapter : UserRepositoryPort
    {
        private readonly IEmployeeDbContext Context;
        private readonly IMapper Mapper;

        public UserRepositoryAdapter(IEmployeeDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        private UserEntity Find(int id)
        {
            return Context.Users.Find(id) ?? throw new EntityNotFoundException($"User with ID {id} not found.");
        }

        public User Create(User user)
        {
            var entity = Mapper.Map<UserEntity>(user);
            Context.Users.Add(entity);
            Context.SaveChanges();
            return Mapper.Map<User>(entity);
        }

        public void Delete(int id)
        {
            var user = Find(id);
            Context.Users.Remove(user);
            Context.SaveChanges();
        }

        public User GetById(int id)
        {
            var user = Find(id);
            return Mapper.Map<User>(user);
        }

        public User GetByEmail(string email)
        {
            var user = Context.Users
                .Include(x => x.UserRoles).ThenInclude(r => r.Role)
                .FirstOrDefault(u => u.Email == email) ?? throw new EntityNotFoundException($"User with email {email} not found.");
            return Mapper.Map<User>(user);
        }

        public void Update(User user)
        {
            var entity = Mapper.Map<UserEntity>(user);
            Context.Users.Update(entity);
            Context.SaveChanges();
        }
    }
}
