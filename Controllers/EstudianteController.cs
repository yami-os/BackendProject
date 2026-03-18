using Api_Becas.Models;
using Api_Becas.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Becas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : Controller
    {
        private readonly IEstudianteService _estudianteService;

        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_estudianteService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var estudiante = _estudianteService.GetById(id);

            if (estudiante == null)
                return NotFound();

            return Ok(estudiante);
        }

        [HttpPost]
        public IActionResult InsertEstudiante([FromBody] EstudianteModel estudiante)
        {
            var id = _estudianteService.InsertEstudiante(estudiante);
            return Ok(new { id });
        }

        [HttpPut]
        public IActionResult UpdateEstudiante([FromBody] EstudianteModel estudiante)
        {
            _estudianteService.UpdateEstudiante(estudiante);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEstudiante(int id)
        {
            _estudianteService.DeleteEstudiante(id);
            return Ok();
        }
    }
}


