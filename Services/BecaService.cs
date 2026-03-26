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
                    Bec_Nombreconv = reader["Bec_Nombreconv"].ToString(),
                    Bec_NombreEst = reader["Bec_NombreEst"].ToString(),
                    Bec_CorreoEst = reader["Bec_CorreoEst"].ToString(),
                    Bec_ContraEst = reader["Bec_ContraEst"].ToString(),
                    Bec_CarreraEst = reader["Bec_CarreraEst"].ToString(),
                    Bec_TelefonoEst = reader["Bec_TelefonoEst"].ToString(),
                    Bec_DireccionEst = reader["Bec_DireccionEst"].ToString()
                });
            }
            return list;
        }
        public BecaModel GetById(int Bec_Id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Get_By_ID_Beca", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Bec_Id", Bec_Id);
            conn.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new BecaModel
                {
                    Bec_Id = Convert.ToInt32(reader["Bec_Id"]),
                    Bec_Nombreconv = reader["Bec_Nombreconv"].ToString(),
                    Bec_NombreEst = reader["Bec_NombreEst"].ToString(),
                    Bec_CorreoEst = reader["Bec_CorreoEst"].ToString(),
                    Bec_ContraEst = reader["Bec_ContraEst"].ToString(),
                    Bec_CarreraEst = reader["Bec_CarreraEst"].ToString(),
                    Bec_TelefonoEst = reader["Bec_TelefonoEst"].ToString(),
                    Bec_DireccionEst= reader["Bec_DireccionEst"].ToString()
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
            cmd.Parameters.AddWithValue("@Bec_Nombreconv", becaModel.Bec_Nombreconv);
            cmd.Parameters.AddWithValue("@Bec_NombreEst", becaModel.Bec_NombreEst);
            cmd.Parameters.AddWithValue("@Bec_CorreoEst", becaModel.Bec_CorreoEst);
            cmd.Parameters.AddWithValue("@Bec_ContraEst", becaModel.Bec_ContraEst);
            cmd.Parameters.AddWithValue("@Bec_CarreraEst", becaModel.Bec_CarreraEst);
            cmd.Parameters.AddWithValue("@Bec_TelefonoEst", becaModel.Bec_TelefonoEst);
            cmd.Parameters.AddWithValue("@Bec_DireccionEst", becaModel.Bec_DireccionEst);

            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Update(BecaModel becaModel)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Update_Beca", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Bec_Id", becaModel.Bec_Id);
            cmd.Parameters.AddWithValue("@Bec_Nombreconv", becaModel.Bec_Nombreconv);
            cmd.Parameters.AddWithValue("@Bec_NombreEst", becaModel.Bec_NombreEst);
            cmd.Parameters.AddWithValue("@Bec_CorreoEst", becaModel.Bec_CorreoEst);
            cmd.Parameters.AddWithValue("@Bec_ContraEst", becaModel.Bec_ContraEst);
            cmd.Parameters.AddWithValue("@Bec_CarreraEst", becaModel.Bec_CarreraEst);
            cmd.Parameters.AddWithValue("@Bec_TelefonoEst", becaModel.Bec_TelefonoEst);
            cmd.Parameters.AddWithValue("@Bec_DireccionEst", becaModel.Bec_DireccionEst);

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
