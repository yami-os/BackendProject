using Api_Becas.Models;

namespace Api_Becas.Services
{
    public interface ISolicitudService
    {
        List<SolicitudModel> GetAll();
        SolicitudModel GetById(int id);
        int Insert(SolicitudModel solicitudmodel);
        void Update(SolicitudModel solicitudmodel);
        void Delete(int id);
    }
}
