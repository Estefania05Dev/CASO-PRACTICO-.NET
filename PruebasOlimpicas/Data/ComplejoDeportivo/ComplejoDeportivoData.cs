using System.Data.SqlClient;
using System.Data;
using PruebasOlimpicas.Models.ComplejoDeportivo;

namespace PruebasOlimpicas.Data.ComplejoDeportivo
{
    public class ComplejoDeportivoData
    {
        public List<ComplejoDeportivoModel> ListarComplejoDeport()
        {

            var ListaComplejoDeport = new List<ComplejoDeportivoModel>();

            var cn = new ConexionData();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarComplejoDeport", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        ListaComplejoDeport.Add(new ComplejoDeportivoModel()
                        {
                            IdComplejoDeport = Convert.ToInt32(dr["IdComplejoDeport"]),
                            DescripComplejoDeport = dr["DescripComplejoDeport"].ToString(),
                            AreaTotal = Convert.ToInt32(dr["AreaTotal"]),
                            Localizacion = dr["Localizacion"].ToString(),
                            JefeOrga = dr["JefeOrga"].ToString(),
                            IdSede = Convert.ToInt32(dr["IdSede"]),
                            DescripSede = dr["DescripSede"].ToString(),
                        });
                    }
                }
            }

            return ListaComplejoDeport;
        }

        public ComplejoDeportivoModel ObtenerComplejoDeport(int IdComplejoDeport)
        {

            var ComplejoDeport = new ComplejoDeportivoModel();

            var cn = new ConexionData();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerComplejoDeport", conexion);
                cmd.Parameters.AddWithValue("IdComplejoDeport", IdComplejoDeport);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        ComplejoDeport.IdComplejoDeport = Convert.ToInt32(dr["IdComplejoDeport"]);
                        ComplejoDeport.DescripComplejoDeport = dr["DescripComplejoDeport"].ToString();
                        ComplejoDeport.AreaTotal = Convert.ToInt32(dr["AreaTotal"]);
                        ComplejoDeport.Localizacion = dr["Localizacion"].ToString();
                        ComplejoDeport.JefeOrga = dr["JefeOrga"].ToString();
                        ComplejoDeport.IdSede = Convert.ToInt32(dr["IdSede"]);
                        ComplejoDeport.DescripSede = dr["DescripSede"].ToString();
                    }
                }

                return ComplejoDeport;
            }
        }

        public bool GuardarComplejoDeport(ComplejoDeportivoModel ComplejoDeportivo)
        {
            bool rpta;

            try
            {
                var cn = new ConexionData();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarComplejoDeport", conexion);
                    cmd.Parameters.AddWithValue("DescripComplejoDeport", ComplejoDeportivo.DescripComplejoDeport);
                    cmd.Parameters.AddWithValue("AreaTotal", ComplejoDeportivo.AreaTotal);
                    cmd.Parameters.AddWithValue("Localizacion", ComplejoDeportivo.Localizacion);
                    cmd.Parameters.AddWithValue("JefeOrga", ComplejoDeportivo.JefeOrga);
                    cmd.Parameters.AddWithValue("IdSede", ComplejoDeportivo.IdSede);
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

        public bool EditarComplejoDeport(ComplejoDeportivoModel ComplejoDeportivo)
        {
            bool rpta;

            try
            {
                var cn = new ConexionData();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarComplejoDeport", conexion);
                    cmd.Parameters.AddWithValue("IdComplejoDeport", ComplejoDeportivo.IdComplejoDeport);
                    cmd.Parameters.AddWithValue("DescripComplejoDeport", ComplejoDeportivo.DescripComplejoDeport);
                    cmd.Parameters.AddWithValue("AreaTotal", ComplejoDeportivo.AreaTotal);
                    cmd.Parameters.AddWithValue("Localizacion", ComplejoDeportivo.Localizacion);
                    cmd.Parameters.AddWithValue("JefeOrga", ComplejoDeportivo.JefeOrga);
                    cmd.Parameters.AddWithValue("IdSede", ComplejoDeportivo.IdSede);
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

        public bool EliminarComplejoDeport(int IdComplejoDeport)
        {
            bool rpta;

            try
            {
                var cn = new ConexionData();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarComplejoDeport", conexion);
                    cmd.Parameters.AddWithValue("IdComplejoDeport", IdComplejoDeport);
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
