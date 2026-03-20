using Api_Becas.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api_Becas.Services
{
    public class SolicitudService : ISolicitudService
    {
        private readonly string _connection;
        public SolicitudService(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        public List<SolicitudModel> GetAll()
        {
            var list = new List<SolicitudModel>();

            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("GetAll_Solicitud", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new SolicitudModel
                {
                    Sol_Id = Convert.ToInt32(reader["Sol_Id"]),
                    Sol_Fecha = Convert.ToDateTime(reader["Sol_Fecha"]),
                    Sol_Estado = reader["Sol_Estado"].ToString(),
                    Sol_Comentarios = reader["Sol_Comentarios"].ToString(),
                    Sol_CorreoEstudiante = reader["Sol_CorreoEstudiante"].ToString(),
                    Sol_CrearContra = reader["Sol_CrearContra"].ToString(),
                    Sol_TelefonoEstudiante = Convert.ToInt32(reader["Sol_TelefonoEstudiante"]),
                    Sol_DireccionEstudiante = reader["Sol_DireccionEstudiante"].ToString()
                });
            }
            return list;
        }
        public SolicitudModel GetById(int Sol_Id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Get_By_Id_Solicitud", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Sol_Id", Sol_Id);
            conn.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new SolicitudModel
                {
                    Sol_Id = Convert.ToInt32(reader["Sol_Id"]),
                    Sol_Fecha = Convert.ToDateTime(reader["Sol_Fecha"]),
                    Sol_Estado = reader["Sol_Estado"].ToString(),
                    Sol_Comentarios = reader["Sol_Comentarios"].ToString(),
                    Sol_CorreoEstudiante = reader["Sol_CorreoEstudiante"].ToString(),
                    Sol_CrearContra = reader["Sol_CrearContra"].ToString(),
                    Sol_TelefonoEstudiante = Convert.ToInt32(reader["Sol_TelefonoEstudiante"]),
                    Sol_DireccionEstudiante = reader["Sol_DireccionEstudiante"].ToString()
                };
            }
            return null;
        }

        public int Insert(SolicitudModel solicitudModel)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Insert_Solicitud", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Sol_Id", solicitudModel.Sol_Id);
            cmd.Parameters.AddWithValue("@Sol_Fecha", solicitudModel.Sol_Fecha);
            cmd.Parameters.AddWithValue("@Sol_Estado", solicitudModel.Sol_Estado);
            cmd.Parameters.AddWithValue("@Sol_Comentarios", solicitudModel.Sol_Comentarios);
            cmd.Parameters.AddWithValue("@Sol_CorreoEtudiante", solicitudModel.Sol_CorreoEstudiante);
            cmd.Parameters.AddWithValue("@Sol_CrearContra", solicitudModel.Sol_CrearContra);
            cmd.Parameters.AddWithValue("@Sol_TelefonoEstudiante", solicitudModel.Sol_TelefonoEstudiante);
            cmd.Parameters.AddWithValue("@Sol_DireccionEstudiante", solicitudModel.Sol_DireccionEstudiante);

            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Update(SolicitudModel solicitudModel)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Update_Solicitud", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Sol_Id", solicitudModel.Sol_Id);
            cmd.Parameters.AddWithValue("@Sol_Fecha", solicitudModel.Sol_Fecha);
            cmd.Parameters.AddWithValue("@Sol_Estado", solicitudModel.Sol_Estado);
            cmd.Parameters.AddWithValue("@Sol_Comentarios", solicitudModel.Sol_Comentarios);
            cmd.Parameters.AddWithValue("@Sol_CorreoEtudiante", solicitudModel.Sol_CorreoEstudiante);
            cmd.Parameters.AddWithValue("@Sol_CrearContra", solicitudModel.Sol_CrearContra);
            cmd.Parameters.AddWithValue("@Sol_TelefonoEstudiante", solicitudModel.Sol_TelefonoEstudiante);
            cmd.Parameters.AddWithValue("@Sol_DireccionEstudiante", solicitudModel.Sol_DireccionEstudiante);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
        public void Delete(int Sol_Id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Delete_Solicitud", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Sol_Id",Sol_Id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        SolicitudModel ISolicitudService.GetById(int Sol_Id)
        {
            throw new NotImplementedException();
        }
    }
}
