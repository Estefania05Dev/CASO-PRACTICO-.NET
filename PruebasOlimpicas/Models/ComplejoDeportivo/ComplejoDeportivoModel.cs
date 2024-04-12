using System.ComponentModel.DataAnnotations;

namespace PruebasOlimpicas.Models.ComplejoDeportivo
{
    public class ComplejoDeportivoModel
    {
        public int IdComplejoDeport { get; set; }

        [Required(ErrorMessage = " El campo Nombre es obligatorio")]
        public string DescripComplejoDeport { get; set; } = default!;

        [Required(ErrorMessage = " El campo Area es obligatorio")]
        public int AreaTotal { get; set; }

        [Required(ErrorMessage = " El campo Localización es obligatorio")]
        public string Localizacion { get; set; } = default!;

        [Required(ErrorMessage = " El campo jefe es obligatorio")]
        public string JefeOrga { get; set; } = default!;

        [Required(ErrorMessage = " El campo sede es obligatorio")]
        public int IdSede { get; set; } = default!;
        public string? DescripSede { get; set; }
    }
}
