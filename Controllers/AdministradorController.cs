using Api_Becas.Models;
using Api_Becas.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Becas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : Controller
    {
        private readonly IAdministradorService _administradorService;

        public AdministradorController(IAdministradorService administradorService)
        {
            _administradorService = administradorService;
        }

        // LISTAR TODOS
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_administradorService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var administrador = _administradorService.GetById(id);

            if (administrador == null)
                return NotFound();

            return Ok(administrador);
        }

        
        [HttpPost]
        public IActionResult InsertAdministrador([FromBody] AdministradorModel administrador)
        {
            var id = _administradorService.InsertAdministrador(administrador);
            return Ok(new { id });
        }

        
        [HttpPut]
        public IActionResult UpdateAdministrador([FromBody] AdministradorModel administrador)
        {
            _administradorService.UpdateAdministrador(administrador);
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteAdministrador(int id)
        {
            _administradorService.DeleteAdministrador(id);
            return Ok();
        }
    }
}