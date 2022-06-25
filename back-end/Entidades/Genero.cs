using back_end.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Entidades
{
    public class Genero: IValidatableObject
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength:10)]
        //[PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        [Range(10, 120)]
        public int Edad { get; set; }

        [CreditCard]
        public string TarjetaCredito { get; set; }
        
        [Url]
        public string Url { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                var primerLetra = Nombre[0].ToString();

                if(primerLetra != primerLetra.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe ser mayuscula",
                        new string[] { nameof(Nombre) });
                }
            }
        }
    }
}
