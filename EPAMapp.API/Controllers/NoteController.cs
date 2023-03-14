using EPAMapp.Domain.Models.DTO.Common;
using EPAMapp.Domain.Models.Entities;
using EPAMapp.Services.DTO.Update;
using EPAMapp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using YourProject.Services;

namespace EPAMapp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IAsyncBaseService<BaseDTO, Note> _services;
        public NoteController(IAsyncBaseService<BaseDTO, Note> services)
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
        [Route("{id}/ExporToExcel")]
        public async Task<IActionResult> ExportToExcel()
        {
            var response = await _services.GetAllAsync();
            if (response.Data == null) return NotFound(response);
            var excelBytes = ExcelService.ExportToExcel(response.Data);

            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyNotes.xlsx");
        }
        [HttpGet]
        [Route("{id}/LastWeekReport")]

        public async Task<IActionResult> GetLastWeekNotes()
        {
            DateTime lastWeekDate = DateTime.Today.AddDays(-7);

            var response = await _services.GetAllAsync();
            if (response.Data == null) return NotFound();
            var notes = response.Data.Where(n =>
                n.CreatedAt >= lastWeekDate && n.CreatedAt < DateTime.Today && n.CurrentReport != null)
                .ToList();

            return Ok(notes);
        }

        [HttpPost]
        public async Task Post(Note model)
        {//TODO: CREATEDTONOTE
            await _services.Create(model);
        }

        [HttpPut]
        public async Task Put(DTOUpdateNote model)
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
