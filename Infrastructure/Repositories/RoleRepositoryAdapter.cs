using Abp.Domain.Entities;
using AutoMapper;
using Domain.Entities;
using Domain.Ports.Out;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class RoleRepositoryAdapter : RoleRepositoryPort
    {
        private readonly IEmployeeDbContext Context;
        private readonly IMapper Mapper;

        public RoleRepositoryAdapter(IEmployeeDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public Role GetByCode(string code)
        {
            var role = Context.Roles
                .FirstOrDefault(u => u.Code == code) ?? throw new EntityNotFoundException($"Role with code {code} not found.");
            return Mapper.Map<Role>(role);
        }
    }
}
