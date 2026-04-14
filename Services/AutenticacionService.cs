using Api_Becas.Data;
using Api_Becas.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Api_Becas.Services
{
    public class AutenticacionService : IAutenticacionService
    {
        private readonly BecasDbContext _context;

        public AutenticacionService(BecasDbContext context)
        {
            _context = context;
        }

        public object Login(string correo, string contra)
        {
            var estudiante = _context.Estudiantes
                .FirstOrDefault(e => e.Est_Correo == correo && e.Est_Contra == contra);

            if (estudiante != null)
            {
                return new
                {
                    Id = estudiante.Est_Id,
                    Nombre = estudiante.Est_Nombre,
                    Correo = estudiante.Est_Correo,
                    rol = "estudiante"
                };
            }

            var administrador = _context.Administrador
                .FirstOrDefault(a => a.Adm_Correo == correo && a.Adm_Contra == contra);

            if (administrador != null)
            {
                return new
                {
                    Id = administrador.Adm_Id,
                    Nombre = administrador.Adm_Nombre,
                    Correo = administrador.Adm_Correo,
                    rol = "administrador"
                };
            }

            return null; 

           
        }
        public bool Register(string correo, string contra, string nombre)
        {
            var existe = _context.Estudiantes
                .FirstOrDefault(e => e.Est_Correo == correo);

            var existeAdmin = _context.Administrador
                .FirstOrDefault(a => a.Adm_Correo == correo);

            if (existe != null || existeAdmin != null)
            {
                return false;
            }

            var estudiante = new EstudianteModel
            {
                Est_Nombre = nombre,
                Est_Correo = correo,
                Est_Contra = contra,
                Est_Carrera = "",
                Est_Telefono = "",
                Est_Direccion = ""
            };

             _context.Estudiantes.Add(estudiante);
            _context.SaveChanges();

            return true;    
        }
    }
}