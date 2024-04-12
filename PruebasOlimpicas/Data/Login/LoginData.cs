using System.Data.SqlClient;
using System.Data;
using PruebasOlimpicas.Models.LoginModel;

namespace PruebasOlimpicas.Data.Login
{
    public class LoginData
    {
        public int ValidarUsuario(LoginModel login)
        {
            try
            {
                var cn = new ConexionData();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", conexion);
                    cmd.Parameters.AddWithValue("Correo", login.Correo);
                    cmd.Parameters.AddWithValue("Clave", login.Clave);

                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = cmd.ExecuteScalar();
                    return (result != null) ? Convert.ToInt32(result) : 0;
                }
               
            }
            catch (Exception e)
            {
                string error = e.Message;
                return 0;
            }         
        }
        public string RegistrarUsuario(LoginModel login)
        {
            bool rpta;
            bool registrado;
            string mensaje;

            try
            {
                var cn = new ConexionData();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", conexion);
                    cmd.Parameters.AddWithValue("Correo", login.Correo);
                    cmd.Parameters.AddWithValue("Clave", login.Clave);
                    //cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    
                    SqlParameter registradoParam = new SqlParameter("@Registrado", SqlDbType.Bit);
                    registradoParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(registradoParam);

                    SqlParameter mensajeParam = new SqlParameter("@Mensaje", SqlDbType.VarChar, 100);
                    mensajeParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(mensajeParam);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    return mensajeParam.Value.ToString();
                    //registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                    //mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                //rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return error;
            }

            //return rpta;
        }
    }
}

