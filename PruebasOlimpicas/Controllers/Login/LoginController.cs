using Microsoft.AspNetCore.Mvc;
using System.Text;
using PruebasOlimpicas.Models.LoginModel;
using PruebasOlimpicas.Data.Login;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PruebasOlimpicas.Controllers.Login
{
    public class LoginController : Controller
    {
        LoginData _LoginData = new LoginData();

        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registrar(LoginModel login)
        {
            bool registrado;
            string mensaje;

            if (login.Clave == login.ConfirmarClave)
            {

                login.Clave = ConvertirSha256(login.Clave);
            }
            else
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            var respuesta = _LoginData.RegistrarUsuario(login);

            ViewData["Mensaje"] = respuesta.Substring(1);
            ViewData["MensajeRegistro"] = respuesta.Substring(0, 1);


            if (respuesta.Substring(0, 1) == "0")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if(!string.IsNullOrEmpty(login.Clave))
            login.Clave = ConvertirSha256(login.Clave);

            int respuesta = _LoginData.ValidarUsuario(login);

            if (respuesta != 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }


        }


        public static string ConvertirSha256(string texto)
        {
         
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }


    }
}
