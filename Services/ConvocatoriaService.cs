namespace Api_Becas.Services
{
    public class ConvocatoriaService : IConvocatoriaService
    {
        private readonly string _connection;

        public ConvocatoriaService(IConfiguration config)
        {
            _connection = config.GetConnectionString("DefaultConnection");
        }
    }
}
