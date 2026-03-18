using Api_Becas.Models;
using Api_Becas.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Becas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvocatoriaController : Controller
    {
        private readonly IConvocatoriaService _service;

        public ConvocatoriaController(IConvocatoriaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _service.GetById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] ConvocatoriaModel convocatoria)
        {
            var id = _service.InsertConvocatoria(convocatoria);
            return Ok(new { id });
        }

        [HttpPut]
        public IActionResult Update([FromBody] ConvocatoriaModel convocatoria)
        {
            _service.UpdateConvocatoria(convocatoria);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteConvocatoria(id);
            return Ok();
        }
    }
}
