using Api_Becas.Models;
using Api_Becas.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Becas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly ISolicitudService _service;

        public SolicitudController(ISolicitudService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll_Solicitud()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get_By_Id_Solicitud(int id)
        {
            var data = _service.GetById(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public IActionResult Insert_Solicitud([FromBody] SolicitudModel solicitud)
        {
            //solicitud.Sol_Fecha = DateTime.Now;

            if (string.IsNullOrEmpty(solicitud.Sol_Estado))
                solicitud.Sol_Estado = "Pendiente";

            if (string.IsNullOrEmpty(solicitud.Sol_Comentarios))
                solicitud.Sol_Comentarios = "";

            var id = _service.Insert(solicitud);

            return Ok(new { id });
        }

        [HttpPut]
        public IActionResult Update_Solicitud([FromBody] SolicitudModel solicitud)
        {
            _service.Update(solicitud);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete_Solicitud(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}