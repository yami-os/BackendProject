using Api_Becas.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api_Becas.Services
{
    public class ConvocatoriaService : IConvocatoriaService
    {
        private readonly string _connection;
        public ConvocatoriaService(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        public List<ConvocatoriaModel> GetAll()
        {
            var list = new List<ConvocatoriaModel>();

            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("GetAll_Convocatoria", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new ConvocatoriaModel
                {
                    Con_Id = Convert.ToInt32(reader["Con_Id"]),
                    Con_Tipo = reader["Con_Tipo"].ToString(),
                    Con_Fecha = Convert.ToDateTime(reader["Con_Fecha"])
                });
            }
            return list;
        }
        public ConvocatoriaModel GetById(int Con_id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Get_By_ID_Convocatoria", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Con_id", Con_id);
            conn.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new ConvocatoriaModel
                {
                    Con_Id = Convert.ToInt32(reader["Con_Id"]),
                    Con_Tipo = reader["Con_Tipo"].ToString(),
                    Con_Fecha = Convert.ToDateTime(reader["Con_Fecha"])
                };
            }
            return null;
        }

        public int Insert(ConvocatoriaModel convocatoriaModel)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Insert_Convocatoria", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Con_Id", convocatoriaModel.Con_Id);
            cmd.Parameters.AddWithValue("@Con_Tipo", convocatoriaModel.Con_Tipo);
            cmd.Parameters.AddWithValue("@Con_Fecha", convocatoriaModel.Con_Fecha);

            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Update(ConvocatoriaModel convocatoriaModel)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Update_Convocatoria", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Con_Id", convocatoriaModel.Con_Id);
            cmd.Parameters.AddWithValue("@Con_Tipo", convocatoriaModel.Con_Tipo);
            cmd.Parameters.AddWithValue("@Con_Fecha", convocatoriaModel.Con_Fecha);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
        public void Delete(int Con_Id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Delete_Convocatoria", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Con_Id", Con_Id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
