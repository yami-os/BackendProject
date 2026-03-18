using Api_Becas.Models;

namespace Api_Becas.Services
{
    public interface IEstudianteService
    {
        List<EstudianteModel> GetAll();
        EstudianteModel GetById(int id);
        int InsertProducts(EstudianteModel estudiantemodel);
        void UpdateProducts(EstudianteModel estudiantemodel);
        void DeleteProducts(int id);
    }
}
