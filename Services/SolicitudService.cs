namespace Api_Becas.Services
{
    public class SolicitudService : ISolicitudService
    {
        private readonly string _connection;

        public SolicitudService(IConfiguration config)
        {
            _connection = config.GetConnectionString("DefaultConnection");
        }
    }
}
