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
        public IActionResult GetAll_Administrador()
        {
            return Ok(_administradorService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get_By_Id_Administrador(int id)
        {
            var administrador = _administradorService.GetById(id);

            if (administrador == null)
                return NotFound();

            return Ok(administrador);
        }

        
        [HttpPost]
        public IActionResult Insert_Administrador([FromBody] AdministradorModel administrador)
        {
            var id = _administradorService.Insert(administrador);
            return Ok(new { id });
        }

        
        [HttpPut]
        public IActionResult Update_Administrador([FromBody] AdministradorModel administrador)
        {
            _administradorService.Update(administrador);
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete_Administrador(int id)
        {
            _administradorService.Delete(id);
            return Ok();
        }
    }
}