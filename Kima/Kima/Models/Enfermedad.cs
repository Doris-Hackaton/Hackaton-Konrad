using System;
using System.ComponentModel.DataAnnotations;

namespace Kima.Models
{

    public class Enfermedad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre completo")]
        public string nombre { get; set; }
        [Display(Name = "Fecha de diágnostico")]
        public Nullable<System.DateTime> fecha_diagnostico { get; set; }
        [Display(Name = "Fecha del último evento de la enfermedad")]
        public Nullable<System.DateTime> ultimo_evento { get; set; }
        [Display(Name = "Tipo de la enfermedad (Crónico o no crónico)")]
        public string tipo { get; set; }

    }
}
