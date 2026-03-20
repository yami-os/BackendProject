using Api_Becas.Models;

namespace Api_Becas.Services
{
    public interface IEstudianteService
    {
        List<EstudianteModel> GetAll();
        EstudianteModel GetById(int id);
        int Insert(EstudianteModel estudiantemodel);
        void Update(EstudianteModel estudiantemodel);
        void Delete(int id);
    }
}
