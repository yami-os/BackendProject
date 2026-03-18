using Api_Becas.Models;

namespace Api_Becas.Services
{
    public interface IAdministradorService
    {
        List<AdministradorModel> GetAll();
        AdministradorModel GetById(int id);
        int InsertProducts(AdministradorModel administradormodel);
        void UpdateProducts(AdministradorModel administradormodel);
        void DeleteProducts(int id);
    }
}
