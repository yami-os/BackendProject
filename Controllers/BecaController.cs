using Api_Becas.Models;
using Api_Becas.Services;
using Microsoft.AspNetCore.Mvc;


namespace Api_Becas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BecaController : Controller
    {
        private readonly IBecaService _service;

        public BecaController(IBecaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll_Beca()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get_By_Id_Beca(int id)
        {
            var data = _service.GetById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Insert_Beca([FromBody] BecaModel beca)
        {
            var id = _service.Insert(beca);
            return Ok(new { id });
        }

        [HttpPut]
        public IActionResult Update_Beca([FromBody] BecaModel beca)
        {
            _service.Update(beca);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete_Beca(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
