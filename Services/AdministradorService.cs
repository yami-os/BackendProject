namespace Api_Becas.Services
{
    public class AdministradorService : IAdministradorService
    {
        private readonly string _connection;

        public AdministradorService(IConfiguration config)
        {
            _connection = config.GetConnectionString("DefaultConnection");
        }
    }
}
