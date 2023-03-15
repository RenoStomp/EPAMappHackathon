using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.DTO.Common;
using EPAMapp.Domain.Models.DTO.Create;
using EPAMapp.Domain.Models.Entities;
using EPAMapp.Domain.Models.Interfaces;
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
        private readonly IAsyncLoginService<User> _loginService;

        public UserController(IAsyncBaseService<BaseDTO, User> services
            , IAsyncLoginService<User> loginService)
        {
            _services = services;
            _loginService = loginService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<IBaseResponse<User>>> Register(User model)
        {
            var result = await _loginService.Register(model);
            if (result.Description != null) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<IBaseResponse<User>>> Login(User model)
        {
            var result = await _loginService.Login(model);
            if (result.Description != null) return BadRequest(result);
            return Ok(result);
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
            await _services.Delete(id);
        }

    }
}
