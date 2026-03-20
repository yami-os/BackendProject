using Api_Becas.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Api_Becas.Services
{
    public class BecaService : IBecaService
    {
        private readonly string _connection;

        public BecaService(IConfiguration config)
        {
            _connection = config.GetConnectionString("DefaultConnection");
        }
        public List<BecaModel> GetAll()
        {
            var list = new List<BecaModel>();

            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("GetAll_Beca", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new BecaModel
                {
                    Bec_Id = Convert.ToInt32(reader["Bec_Id"]),
                    Bec_NombreConvocatoria = reader["Bec_NombreConvocatoria"].ToString(),
                    Bec_NombreEstudiante = reader["Bec_NombreEstudiante"].ToString(),
                    Bec_CorreoEstudiante = reader["Bec_CorreoEstudiante"].ToString(),
                    Bec_ContraEstudiante = reader["Bec_ContraEstudiante"].ToString(),
                    Bec_CarreraEstudiante = reader["Bec_CarreraEstudiante"].ToString(),
                    Bec_TelefonoEstudiante = Convert.ToInt32(reader["Bec_TelefonoEstudiante"]),
                    Bec_DirreccionEstudiante = reader["Bec_DirreccionEstudiante"].ToString()
                });
            }
            return list;
        }
        public BecaModel GetById(int Bec_Id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Get_By_Id_Beca", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Bec_Id", Bec_Id);
            conn.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new BecaModel
                {
                    Bec_Id = Convert.ToInt32(reader["Bec_Id"]),
                    Bec_NombreConvocatoria = reader["Bec_NombreConvocatoria"].ToString(),
                    Bec_NombreEstudiante = reader["Bec_NombreEstudiante"].ToString(),
                    Bec_CorreoEstudiante = reader["Bec_CorreoEstudiante"].ToString(),
                    Bec_ContraEstudiante = reader["Bec_ContraEstudiante"].ToString(),
                    Bec_CarreraEstudiante = reader["Bec_CarreraEstudiante"].ToString(),
                    Bec_TelefonoEstudiante = Convert.ToInt32(reader["Bec_TelefonoEstudiante"]),
                    Bec_DirreccionEstudiante = reader["Bec_DirreccionEstudiante"].ToString()
                };
            }
            return null;
        }

        public int Insert(BecaModel becaModel)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Insert_Beca", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Bec_Id", becaModel.Bec_Id);
            cmd.Parameters.AddWithValue("@Bec_NombreConvocatoria", becaModel.Bec_NombreConvocatoria);
            cmd.Parameters.AddWithValue("@Bec_NombreEstudiante", becaModel.Bec_NombreEstudiante);
            cmd.Parameters.AddWithValue("@Bec_CorreoEstudiante", becaModel.Bec_CorreoEstudiante);
            cmd.Parameters.AddWithValue("@Bec_ContraEstudiante", becaModel.Bec_ContraEstudiante);
            cmd.Parameters.AddWithValue("@Bec_CarreraEstudiante", becaModel.Bec_CarreraEstudiante);
            cmd.Parameters.AddWithValue("@Bec_TelefonoEstudiante", becaModel.Bec_TelefonoEstudiante);
            cmd.Parameters.AddWithValue("@Bec_DirreccionEstudiante", becaModel.Bec_DirreccionEstudiante);

            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Update(BecaModel becaModel)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Update_Beca", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Bec_Id", becaModel.Bec_Id);
            cmd.Parameters.AddWithValue("@Bec_NombreConvocatoria", becaModel.Bec_NombreConvocatoria);
            cmd.Parameters.AddWithValue("@Bec_NombreEstudiante", becaModel.Bec_NombreEstudiante);
            cmd.Parameters.AddWithValue("@Bec_CorreoEstudiante", becaModel.Bec_CorreoEstudiante);
            cmd.Parameters.AddWithValue("@Bec_ContraEstudiante", becaModel.Bec_ContraEstudiante);
            cmd.Parameters.AddWithValue("@Bec_CarreraEstudiante", becaModel.Bec_CarreraEstudiante);
            cmd.Parameters.AddWithValue("@Bec_TelefonoEstudiante", becaModel.Bec_TelefonoEstudiante);
            cmd.Parameters.AddWithValue("@Bec_DirreccionEstudiante", becaModel.Bec_DirreccionEstudiante);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
        public void Delete(int Bec_Id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Delete_Beca", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Bec_Id", Bec_Id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
