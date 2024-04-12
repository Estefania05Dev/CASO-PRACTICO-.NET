using System.ComponentModel.DataAnnotations;

namespace PruebasOlimpicas.Models.LoginModel
{
    public class LoginModel
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = " El campo Correo es obligatorio")]
        public string Correo { get; set; } = default!;
        [Required(ErrorMessage = " El campo clave es obligatorio")]
        public string Clave { get; set; } = default!;
        [Required(ErrorMessage = " El campo confirmar clave es obligatorio")]
        public string ConfirmarClave { get; set; } = default!;
    }
}
