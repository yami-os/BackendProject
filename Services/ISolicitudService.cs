using Api_Becas.Models;

namespace Api_Becas.Services
{
    public interface ISolicitudService
    {
        List<SolicitudModel> GetAll();
        SolicitudModel GetById(int id);
        int InsertProducts(SolicitudModel solicitudmodel);
        void UpdateProducts(SolicitudModel solicitudmodel);
        void DeleteProducts(int id);
    }
}
