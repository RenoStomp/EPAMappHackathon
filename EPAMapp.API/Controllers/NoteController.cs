using EPAMapp.Domain.Models.Entities;
using EPAMapp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourProject.Services;

namespace EPAMapp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IAsyncBaseService<Note> _services;
        public NoteController(IAsyncBaseService<Note> services)
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

        [HttpGet]
        [Route("export-to-excel")]
        public IActionResult ExportToExcel()
        {
            var response = _services.GetAll();
            if (response.Data == null) return NotFound(response);
            var excelBytes = ExcelService.ExportToExcel(response.Data);
            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyEntities.xlsx");
        }

        [HttpPost]
        public async Task Post(Note model)
        {
            await _services.Create(model);
        }

        [HttpPut("{id}")]
        public async Task Put(Note model)
        {
            await _services.Update(model);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Note model)
        {
            await _services.Delete(model);
        }



    }
}
