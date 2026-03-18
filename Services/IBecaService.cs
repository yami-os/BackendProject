using Api_Becas.Models;

namespace Api_Becas.Services
{
    public interface IBecaService
    {
        List<BecaModel> GetAll();
        BecaModel GetById(int id);
        int InsertProducts(BecaModel becamodel);
        void UpdateProducts(BecaModel becamodel);
        void DeleteProducts(int id);
    }
}
