using Api_Becas.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api_Becas.Services
{
    public class AdministradorService : IAdministradorService
    {
        private readonly string _connection;

        public AdministradorService(IConfiguration config)
        {
            _connection = config.GetConnectionString("DefaultConnection");
        }

        public List<AdministradorModel> GetAll()
        {
            var list = new List<AdministradorModel>();

            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("GetAll_Administrador", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new AdministradorModel
                {
                    Adm_Id = Convert.ToInt32(reader["Adm_Id"]),
                    Adm_Nombre = reader["Adm_Nombre"].ToString(),
                    Adm_Correo = reader["Adm_Correo"].ToString(),
                    Adm_Contra = reader["Adm_Contra"].ToString()
                });
            }
            return list;
        }
        public AdministradorModel GetById(int Adm_Id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Get_By_ID_Administrador", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Adm_Id", Adm_Id);
            conn.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new AdministradorModel
                {
                    Adm_Id = Convert.ToInt32(reader["Adm_Id"]),
                    Adm_Nombre = reader["Adm_Nombre"].ToString(),
                    Adm_Correo = reader["Adm_Correo"].ToString(),
                    Adm_Contra = reader["Adm_Contra"].ToString()
                };
            }
            return null;
        }

        public int Insert(AdministradorModel administradorModel)
        { 
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Insert_Administrador", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Adm_Id", administradorModel.Adm_Id);
            cmd.Parameters.AddWithValue("@Adm_Nombre", administradorModel.Adm_Nombre);
            cmd.Parameters.AddWithValue("@Adm_Correo", administradorModel.Adm_Correo);
            cmd.Parameters.AddWithValue("@Adm_Contra", administradorModel.Adm_Contra);

            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Update(AdministradorModel administradorModel)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Update_Administrador", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Adm_Id", administradorModel.Adm_Id);
            cmd.Parameters.AddWithValue("@Adm_Nombre", administradorModel.Adm_Nombre);
            cmd.Parameters.AddWithValue("@Adm_Correo", administradorModel.Adm_Correo);
            cmd.Parameters.AddWithValue("@Adm_Contra", administradorModel.Adm_Contra);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
        public void Delete(int Adm_Id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Delete_Administrador", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Adm_Id", Adm_Id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
