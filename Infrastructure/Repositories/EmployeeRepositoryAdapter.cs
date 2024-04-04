using Abp.Domain.Entities;
using AutoMapper;
using Domain.Entities;
using Domain.Ports.Out;
using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public class EmployeeRepositoryAdapter : EmployeeRepositoryPort
    {
        private readonly IEmployeeDbContext Context;
        private readonly IMapper Mapper;

        public EmployeeRepositoryAdapter(IEmployeeDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        private EmployeeEntity Find(int id)
        {
            return Context.Employees.Find(id) ?? throw new EntityNotFoundException($"Employee with ID {id} not found.");
        }

        public Employee Create(Employee employee)
        {
            var entity = Mapper.Map<EmployeeEntity>(employee);
            Context.Employees.Add(entity);
            Context.SaveChanges();
            return Mapper.Map<Employee>(entity);
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            Context.Employees.Remove(entity);
            Context.SaveChanges();
        }

        public Employee GetById(int id)
        {
            var entity = Find(id);
            return Mapper.Map<Employee>(entity);
        }

        public void Update(Employee employee)
        {
            var entity = Mapper.Map<EmployeeEntity>(employee);
            Context.Employees.Update(entity);
            Context.SaveChanges();
        }
    }
}
