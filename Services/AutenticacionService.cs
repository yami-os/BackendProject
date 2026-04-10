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
        public bool Register(string correo, string contra, string nombre, string rol)
        {
            var estudianteExistente = _context.Estudiantes
                .FirstOrDefault(e => e.Est_Correo == correo);

            var existeAdministrador = _context.Administrador
                .FirstOrDefault(a => a.Adm_Correo == correo);

            if (estudianteExistente != null || existeAdministrador != null)
            {
                return false;
            }

            if (rol == "estudiante")
            {
                var estudiante = new EstudianteModel
                {
                    Est_Nombre = nombre,
                    Est_Correo = correo,
                    Est_Contra = contra
                };

                _context.Estudiantes.Add(estudiante);
            }
            else if (rol == "administrador")
            {
                var administrador = new AdministradorModel
                {
                    Adm_Nombre = nombre,
                    Adm_Correo = correo,
                    Adm_Contra = contra
                };
                _context.Administrador.Add(administrador);
            }
            else
            {
                return false;
            }

            _context.SaveChanges();
            return true;


        }
    }
}