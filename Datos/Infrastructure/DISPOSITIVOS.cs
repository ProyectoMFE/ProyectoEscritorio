//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos.Infrastructure
{
    using System;
    using System.Collections.Generic;
    
    public partial class DISPOSITIVOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DISPOSITIVOS()
        {
            this.SOLICITUDES = new HashSet<SOLICITUDES>();
        }
    
        public string NUM_SERIE { get; set; }
        public int ID_CATEGORIA { get; set; }
        public string MARCA { get; set; }
        public string MODELO { get; set; }
        public string LOCALIZACION { get; set; }
        public string ESTADO { get; set; }
    
        public virtual CATEGORIAS CATEGORIAS { get; set; }
        public virtual HW_RED HW_RED { get; set; }
        public virtual ORDENADORES ORDENADORES { get; set; }
        public virtual PANTALLAS PANTALLAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLICITUDES> SOLICITUDES { get; set; }
    }
}
