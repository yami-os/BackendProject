using Api_Becas.Models;

namespace Api_Becas.Services
{
    public interface IAdministradorService
    {
        List<AdministradorModel> GetAll();
        AdministradorModel GetById(int id);
        int Insert(AdministradorModel administradormodel);
        void Update(AdministradorModel administradormodel);
        void Delete(int id);
    }
}
