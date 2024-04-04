using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports.Out
{
    public interface EmployeeRepositoryPort
    {
        Employee GetById(int id);

        Employee Create(Employee employee);

        void Update(Employee employee);

        void Delete(int id);
    }
}
