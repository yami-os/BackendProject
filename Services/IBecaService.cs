using Api_Becas.Models;

namespace Api_Becas.Services
{
    public interface IBecaService
    {
        List<BecaModel> GetAll();
        BecaModel GetById(int id);
        int Insert(BecaModel becaModel);
        void Update(BecaModel becaModel);
        void Delete(int id);
    }
}
