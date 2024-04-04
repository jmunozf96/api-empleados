using AutoMapper;
using Domain.Entities;
using Domain.Models.Commands;
using Domain.Ports.In.Commands;
using Domain.Ports.Out;

namespace Application.Commands
{
    public class UpdateEmployeeCommandHandler : IUpdateEmployeeCommandHandler
    {
        private readonly EmployeeRepositoryPort _repositoryPort;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(EmployeeRepositoryPort  repositoryPort, IMapper mapper)
        {
            _repositoryPort = repositoryPort;
            _mapper = mapper;
        }

        public void Execute(UpdateEmployeeCommand command)
        {
            var employee = _mapper.Map<Employee>(command);
            _repositoryPort.Update(command.Id, employee);
        }
    }
}
