using System.ComponentModel.DataAnnotations;

namespace Parcial1LISBETH.Models
{
    public class Prestamo
    {
        [Key]
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Lo sentimos! El concepto es obligatorio")]
        public string Concepto { get; set; }


        [Required(ErrorMessage = "Lo sentimos! El monto es obligatorio")]
        [Range(1, 1000000.00, ErrorMessage = "El monto debe ser entre {1} y {2}")]
        public float Monto { get; set; }


        [Required(ErrorMessage = "Lo sentimos!! El Balance es obligatorio")]
        [Range(1, 2000000.00, ErrorMessage = "El Balance debe ser entre {1} y {2}")]
        public float Balance { get; set; }
    }
}
