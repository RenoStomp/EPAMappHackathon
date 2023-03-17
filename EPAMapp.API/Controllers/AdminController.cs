using EPAMapp.Domain.Models.DTO.Common;
using EPAMapp.Domain.Models.DTO.Create;
using EPAMapp.Domain.Models.Entities;
using EPAMapp.Domain.Models.Interfaces;
using EPAMapp.Services.DTO.Update;
using EPAMapp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Zameshhauripsicititki.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAsyncBaseService<BaseDTO, Admin> _services;
        private readonly IAsyncLoginService<Admin, DTOAccountHolder> _loginService;

        public AdminController(IAsyncBaseService<BaseDTO, Admin> services
            , IAsyncLoginService<Admin, DTOAccountHolder> loginService)
        {
            _services = services;
            _loginService = loginService;
        }
        public async Task<ActionResult<IBaseResponse<Admin>>> Login(DTOAccountHolder model)
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
        public async Task Post(DTOCreateAdmin model)
        {
            await _services.Create(model);
        }

        [HttpPut]
        public async Task Put(DTOCreateAdmin model)
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
