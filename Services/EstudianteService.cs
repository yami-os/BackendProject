using Api_Becas.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api_Becas.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly string _connection;

        public EstudianteService(IConfiguration config)
        {
            _connection = config.GetConnectionString("DefaultConnection");
        }

        public List<EstudianteModel> GetAll()
        {
            var list = new List<EstudianteModel>();

            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("GetAll_Estudiante", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new EstudianteModel
                {
                    Est_Id = Convert.ToInt32(reader["Id"]),
                    Est_Nombre = reader["Nombre"].ToString(),
                    Est_Correo = reader["Correo"].ToString(),
                    Est_Contra = reader["Contra"].ToString(),
                    Est_Carrera = reader["Carrera"].ToString(),
                    Est_Telefono = Convert.ToInt32(reader["Telefono"]),
                    Est_Direccion = reader["Direccion"].ToString()
                });
            }
            return list;
        }
        public EstudianteModel GetById(int Est_Id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Get_By_Id_Estudiante", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Est_Id", Est_Id);
            conn.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new EstudianteModel
                {
                    Est_Id = Convert.ToInt32(reader["Id"]),
                    Est_Nombre = reader["Nombre"].ToString(),
                    Est_Correo = reader["Correo"].ToString(),
                    Est_Contra = reader["Contra"].ToString(),
                    Est_Carrera = reader["Carrera"].ToString(),
                    Est_Telefono = Convert.ToInt32(reader["Telefono"]),
                    Est_Direccion = reader["Direccion"].ToString()
                };
            }
            return null;
        }

        public int Insert(EstudianteModel estudianteModel)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Insert_Estudiante", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Est_Id", estudianteModel.Est_Id);
            cmd.Parameters.AddWithValue("@Est_Nombre", estudianteModel.Est_Nombre);
            cmd.Parameters.AddWithValue("@Est_Correo", estudianteModel.Est_Correo);
            cmd.Parameters.AddWithValue("@Est_Carrera", estudianteModel.Est_Carrera);
            cmd.Parameters.AddWithValue("@Est_Telefono", estudianteModel.Est_Telefono);
            cmd.Parameters.AddWithValue("@Est_Direccion", estudianteModel.Est_Direccion);

            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Update(EstudianteModel estudianteModel)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Update_Estudiante", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Est_Id", estudianteModel.Est_Id);
            cmd.Parameters.AddWithValue("@Est_Nombre", estudianteModel.Est_Nombre);
            cmd.Parameters.AddWithValue("@Est_Correo", estudianteModel.Est_Correo);
            cmd.Parameters.AddWithValue("@Est_Carrera", estudianteModel.Est_Carrera);
            cmd.Parameters.AddWithValue("@Est_Telefono", estudianteModel.Est_Telefono);
            cmd.Parameters.AddWithValue("@Est_Direccion", estudianteModel.Est_Direccion);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
        public void Delete(int Est_Id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Delete_Estudiante", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Est_Id", Est_Id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
