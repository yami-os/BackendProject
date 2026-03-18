namespace Api_Becas.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly string _connection;

        public EstudianteService(IConfiguration config)
        {
            _connection = config.GetConnectionString("DefaultConnection");
        }
    }
}
