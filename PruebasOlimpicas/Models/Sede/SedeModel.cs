using System.ComponentModel.DataAnnotations;

namespace PruebasOlimpicas.Models.Sede
{
    public class SedeModel
    {
        public int IdSede { get; set; }
        [Required(ErrorMessage = " El campo Nombre es obligatorio")]
        public string DescripSede { get; set; } = default!;

        [Required(ErrorMessage = " El campo presupuesto es obligatorio")]
        public int Presupuesto { get; set; }

        [Required(ErrorMessage = " El campo numero de complejos es obligatorio")]
        public int NroComplejos { get; set; }

    }
}
