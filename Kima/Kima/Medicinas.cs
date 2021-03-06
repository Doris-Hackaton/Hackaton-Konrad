//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kima
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Medicinas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicinas()
        {
            this.Enfermedads = new HashSet<Enfermedad>();
            this.Eventoes = new HashSet<Evento>();
        }
    
        public int Id { get; set; }
        [Display(Name = "Nombre Medicina")]
        public string nombre { get; set; }
        [Display(Name = "Detalles")]
        public string detalles { get; set; }
        [Display(Name = "Dosis cantidad")]
        public string dosis { get; set; }
        [Display(Name = "Frecuencia Dosis")]
        public string frecuencia { get; set; }
        [Display(Name = "Tipo")]
        public string tipo { get; set; }
        [Display(Name = "Información precio/lugar")]
        public string info_compra { get; set; }
    
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Enfermedad> Enfermedads { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evento> Eventoes { get; set; }
    }
}
