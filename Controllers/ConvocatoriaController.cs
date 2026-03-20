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
        public IActionResult GetAll_Convocatoria()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get_By_Id_Convocatoria(int id)
        {
            var data = _service.GetById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Insert_Convocatoria([FromBody] ConvocatoriaModel convocatoria)
        {
            var id = _service.Insert(convocatoria);
            return Ok(new { id });
        }

        [HttpPut]
        public IActionResult Update_Convocatoria([FromBody] ConvocatoriaModel convocatoria)
        {
            _service.Update(convocatoria);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete_Convocatoria(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
