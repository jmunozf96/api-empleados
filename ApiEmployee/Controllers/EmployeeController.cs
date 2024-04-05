using ApiEmployee.Dtos.Employee;
using ApiEmployee.Dtos.Employees;
using AutoMapper;
using Domain.Models.Commands;
using Domain.Ports.In.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Utils;


namespace ApiEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [Authorize(Roles = RolesUtil.Admin + "," + RolesUtil.Employee)]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Authorize(Roles = RolesUtil.Admin + "," + RolesUtil.Employee)]
        [HttpGet("{id}")]
        public EmployeeReadDTO Get(int id)
        {
            var employee = _service.GetById(id);
            return _mapper.Map<EmployeeReadDTO>(employee);
        }

        [Authorize(Roles = RolesUtil.Admin)]
        [HttpPost]
        public EmployeeReadDTO Post([FromBody] EmployeeCreateDTO dto)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(dto);
            var employee = _service.Create(command);
            return _mapper.Map<EmployeeReadDTO>(employee);
        }

        [Authorize(Roles = RolesUtil.Admin)]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeUpdateDTO dto)
        {
            dto.Id = id;
            var command = _mapper.Map<UpdateEmployeeCommand>(dto);
            _service.Update(command);
        }

        [Authorize(Roles = RolesUtil.Admin)]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
