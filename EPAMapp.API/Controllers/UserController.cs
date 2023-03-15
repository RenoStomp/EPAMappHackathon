using EPAMapp.Domain.Models.DTO.Common;
using EPAMapp.Domain.Models.DTO.Create;
using EPAMapp.Domain.Models.Entities;
using EPAMapp.Services.DTO.Update;
using EPAMapp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EPAMapp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAsyncBaseService<BaseDTO, User> _services;
        public UserController(IAsyncBaseService<BaseDTO, User> services)
        {
            _services = services;
        }

        [HttpGet]
        public IResult Get()
        {
            var response = _services.GetAll();
            return Results.Ok(response.Data);
        }
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var response = _services.GetModelById(id);
            return Results.Ok(response.Data);
        }

        [HttpPost]
        public async Task Post(DTOCreateUser model)
        {
            await _services.Create(model);
        }

        [HttpPut]
        public async Task Put(DTOUpdateUser model)
        {
            await _services.Update(model);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _services.DeleteById(id);
        }
    }
}
