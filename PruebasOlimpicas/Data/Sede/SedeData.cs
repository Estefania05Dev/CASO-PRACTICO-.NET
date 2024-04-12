using System.Data.SqlClient;
using System.Data;
using PruebasOlimpicas.Models.Sede;

namespace PruebasOlimpicas.Data.Sede
{
    public class SedeData
    {
        public List<SedeModel> ListarSedes()
        {

            var ListaSede = new List<SedeModel>();

            var cn = new ConexionData();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarSede", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        ListaSede.Add(new SedeModel()
                        {
                            IdSede = Convert.ToInt32(dr["IdSede"]),
                            DescripSede = dr["DescripSede"].ToString(),
                            Presupuesto = Convert.ToInt32(dr["Presupuesto"]),
                            NroComplejos = Convert.ToInt32(dr["NroComplejos"])
                        });

                    }
                }
            }

            return ListaSede;
        }

        public SedeModel ObtenerSede(int IdSede)
        {

            var Sede = new SedeModel();

            var cn = new ConexionData();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerSede", conexion);
                cmd.Parameters.AddWithValue("IdSede", IdSede);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        Sede.IdSede = Convert.ToInt32(dr["IdSede"]);
                        Sede.DescripSede = dr["DescripSede"].ToString();
                        Sede.Presupuesto = Convert.ToInt32(dr["Presupuesto"]);
                        Sede.NroComplejos = Convert.ToInt32(dr["NroComplejos"]);
                    }
                }
            }

            return Sede;
        }

        public bool GuardarSede(SedeModel sede)
        {
            bool rpta;

            try
            {
                var cn = new ConexionData();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarSede", conexion);
                    cmd.Parameters.AddWithValue("DescripSede", sede.DescripSede);
                    cmd.Parameters.AddWithValue("Presupuesto", sede.Presupuesto);
                    cmd.Parameters.AddWithValue("NroComplejos", sede.NroComplejos);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool EditarSede(SedeModel sede)
        {
            bool rpta;

            try
            {
                var cn = new ConexionData();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarSede", conexion);
                    cmd.Parameters.AddWithValue("IdSede", sede.IdSede);
                    cmd.Parameters.AddWithValue("DescripSede", sede.DescripSede);
                    cmd.Parameters.AddWithValue("Presupuesto", sede.Presupuesto);
                    cmd.Parameters.AddWithValue("NroComplejos", sede.NroComplejos);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool EliminarSede(int IdSede)
        {
            bool rpta;

            try
            {
                var cn = new ConexionData();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarSede", conexion);
                    cmd.Parameters.AddWithValue("IdSede", IdSede);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}

