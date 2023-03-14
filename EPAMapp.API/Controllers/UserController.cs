using EPAMapp.Domain.Models.Entities;
using EPAMapp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPAMapp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAsyncBaseService<User> _services;
        public UserController(IAsyncBaseService<User> services)
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
        public  IResult Get(int id)
        {
            var response =  _services.GetModelById(id);
            return Results.Ok(response.Data);
        }

        [HttpPost]
        public async Task Post(User model)
        {
            await _services.Create(model);
        }

        [HttpPut("{id}")]
        public async Task Put( User model) 
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
