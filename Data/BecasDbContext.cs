using Api_Becas.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api_Becas.Data
{
    public class BecasDbContext : DbContext
    {
        public BecasDbContext(DbContextOptions<BecasDbContext> options)
            : base(options)
        {
        }

        public DbSet<AdministradorModel> Administrador { get; set; }
        public DbSet<EstudianteModel> Estudiantes { get; set; }
        public DbSet<BecaModel> Beca { get; set; }
        public DbSet<ConvocatoriaModel> Convocatoria { get; set; }
        public DbSet<SolicitudModel> Solicitud { get; set; }
    }
}
