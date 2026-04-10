using Microsoft.AspNetCore.Mvc;
using Api_Becas.Services;
using Api_Becas.Models;


namespace Api_Becas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacionController : ControllerBase
    {
        private readonly IAutenticacionService _autenticacionService;

        public AutenticacionController(IAutenticacionService autenticacionService)
        {
            _autenticacionService = autenticacionService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {

            var usuario = _autenticacionService.Login(login.Correo, login.Contra);

            if (usuario == null)
            {
                return Unauthorized("Correo o contraseña incorrectos");
            }
            else
            {
                return Ok(usuario);
            }
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Registro registro)
        {
            var resultado = _autenticacionService.Register(
                registro.Correo,
                registro.Contra,
                registro.Nombre, 
                registro.Rol);

            if (resultado == null)
            {
                return BadRequest("Error al registrar el usuario");
            }
            return Ok("Registro exitoso");

        }
    }
}
