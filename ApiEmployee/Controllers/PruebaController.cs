using ApiEmployee.Dtos.Employee;
using Application.Commands;
using AutoMapper;
using Domain.Models.Commands;
using Domain.Ports.In.Commands;
using Microsoft.AspNetCore.Mvc;
using Shared.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        private readonly ICreateEmployeeCommandHandler _createEmployeeCommandHandler;
        private readonly IMapper _mapper;

        public PruebaController(ICreateEmployeeCommandHandler createEmployeeCommandHandler, IMapper mapper)
        {
            _createEmployeeCommandHandler = createEmployeeCommandHandler;
            _mapper = mapper;
        }

        // GET: api/<PruebaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PruebaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PruebaController>
        [HttpPost]
        public void Post([FromBody] CreateEmployeeDTO dto)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(dto);
           _createEmployeeCommandHandler.Execute(command);
        }

        // PUT api/<PruebaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PruebaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
