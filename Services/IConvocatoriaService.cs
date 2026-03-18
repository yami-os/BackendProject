using Api_Becas.Models;

namespace Api_Becas.Services
{
    public interface IConvocatoriaService
    {
        List<ConvocatoriaModel> GetAll();
        ConvocatoriaModel GetById(int id);
        int InsertProducts(ConvocatoriaModel convocatoriamodel);
        void UpdateProducts(ConvocatoriaModel convocatoriamodel);
        void DeleteProducts(int id);
    }
}
