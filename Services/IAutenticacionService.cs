using Api_Becas.Models;

namespace Api_Becas.Services
{
    public interface IAutenticacionService
    {
        object Login (string correo, string contra);

        bool Register(string correo, string contra, string nombre, string Rol);
    }
}
