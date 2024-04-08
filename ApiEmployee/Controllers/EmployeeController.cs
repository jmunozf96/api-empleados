using ApiEmployee.Dtos.Employee;
using ApiEmployee.Dtos.Employees;
using AutoMapper;
using Domain.Models.Commands;
using Domain.Ports.In.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Utils;


namespace ApiEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(
        IEmployeeService service,
        IMapper mapper,
        IValidator<EmployeeCreateDTO> create,
        IValidator<EmployeeUpdateDTO> update
        ) : ControllerBase
    {
        private readonly IEmployeeService _service = service;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<EmployeeCreateDTO> _create = create;
        private readonly IValidator<EmployeeUpdateDTO> _update = update;

        [Authorize(Roles = RolesUtil.Admin + "," + RolesUtil.Employee)]
        [HttpGet]
        public Paginated<EmployeeReadDTO> Get(int page = 1, int pageSize = 10)
        {
            var employees = _service.GetAll(page, pageSize);
            var data = employees.Items.Select(c => _mapper.Map<EmployeeReadDTO>(c)).ToList();   
            return new Paginated<EmployeeReadDTO>(data, employees.PageIndex, employees.TotalPages); 
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
        public IActionResult Post([FromBody] EmployeeCreateDTO dto)
        {
            var validation = _create.Validate(dto);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var command = _mapper.Map<CreateEmployeeCommand>(dto);
            var employee = _service.Create(command);
            return Ok(_mapper.Map<EmployeeReadDTO>(employee));
        }

        [Authorize(Roles = RolesUtil.Admin)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeUpdateDTO dto)
        {
            var validation = _update.Validate(dto);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            dto.Id = id;
            var command = _mapper.Map<UpdateEmployeeCommand>(dto);
            _service.Update(command);

            return NoContent();
        }

        [Authorize(Roles = RolesUtil.Admin)]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
