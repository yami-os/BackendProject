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
            using SqlCommand cmd = new SqlCommand("sp_ListarBeca", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new BecaModel
                {
                    Bec_Id = Convert.ToInt32(reader["Id"]),
                    Bec_NombreConv = reader["NombreConv"].ToString(),
                    Bec_NombreEst = reader["NombreEst"].ToString(),
                    Bec_CorreoEst = reader["CorreoEst"].ToString(),
                    Bec_ContraseñaEst = reader["ContraseñaEst"].ToString(),
                    Bec_CarreraEst = reader["CarreraEst"].ToString(),
                    Bec_TelefonoEst = reader["TelefonoEst"].ToString(),
                    Bec_DirreccionEst = reader["DirreccionEst"].ToString()
                });
            }
            return list;
        }
        public BecaModel GetById(int id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("sp_BuscarBeca", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new BecaModel
                {
                    Bec_Id = Convert.ToInt32(reader["Id"]),
                    Bec_NombreConv = reader["NombreConv"].ToString(),
                    Bec_NombreEst = reader["NombreEst"].ToString(),
                    Bec_CorreoEst = reader["CorreoEst"].ToString(),
                    Bec_ContraseñaEst = reader["ContraseñaEst"].ToString(),
                    Bec_CarreraEst = reader["CarreraEst"].ToString(),
                    Bec_TelefonoEst = reader["TelefonoEst"].ToString(),
                    Bec_DirreccionEst = reader["DirreccionEst"].ToString()
                };
            }
            return null;
        }

        public int InsertProducts(BecaModel becamodel)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Ins_Beca", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Bec_NombreConv", becamodel.Bec_NombreConv);
            cmd.Parameters.AddWithValue("@Bec_NombreEst", becamodel.Bec_NombreEst);
            cmd.Parameters.AddWithValue("@Bec_Id", becamodel.Bec_NombreEst);
            cmd.Parameters.AddWithValue("@Bec_NombreEst", becamodel.Bec_NombreEst);
            cmd.Parameters.AddWithValue("@Bec_NombreEst", becamodel.Bec_NombreEst);
            cmd.Parameters.AddWithValue("@Bec_NombreEst", becamodel.Bec_NombreEst);
            cmd.Parameters.AddWithValue("@Bec_NombreEst", becamodel.Bec_NombreEst);
            cmd.Parameters.AddWithValue("@Bec_NombreEst", becamodel.Bec_NombreEst);
            cmd.Parameters.AddWithValue("@Bec_NombreEst", becamodel.Bec_NombreEst);
            cmd.Parameters.AddWithValue("@Bec_NombreEst", becamodel.Bec_NombreEst);


            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void UpdateProducts(BecaModel becamodel)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Act_Beca", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", becamodel.Id);
            cmd.Parameters.AddWithValue("@Name", becamodel.Name);
            cmd.Parameters.AddWithValue("@Price", becamodel.Price);
            cmd.Parameters.AddWithValue("@Stock", becamodel.Stock);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
        public void DeleteProducts(int id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Del_Beca", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
