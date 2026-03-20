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
        public IActionResult GetAll_Estudiante()
        {
            return Ok(_estudianteService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get_By_Id_Estudiante(int id)
        {
            var estudiante = _estudianteService.GetById(id);

            if (estudiante == null)
                return NotFound();

            return Ok(estudiante);
        }

        [HttpPost]
        public IActionResult Insert_Estudiante([FromBody] EstudianteModel estudiante)
        {
            var id = _estudianteService.Insert(estudiante);
            return Ok(new { id });
        }

        [HttpPut]
        public IActionResult Update_Estudiante([FromBody] EstudianteModel estudiante)
        {
            _estudianteService.Update(estudiante);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete_Estudiante(int id)
        {
            _estudianteService.Delete(id);
            return Ok();
        }
    }
}


