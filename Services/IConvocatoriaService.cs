using Api_Becas.Models;

namespace Api_Becas.Services
{
    public interface IConvocatoriaService
    {
        List<ConvocatoriaModel> GetAll();
        ConvocatoriaModel GetById(int id);
        int Insert(ConvocatoriaModel convocatoriamodel);
        void Update(ConvocatoriaModel convocatoriamodel);
        void Delete(int id);
    }
}
