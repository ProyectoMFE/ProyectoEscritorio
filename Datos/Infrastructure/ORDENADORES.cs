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
    
    public partial class ORDENADORES
    {
        public string NUM_SERIE { get; set; }
        public string PROCESADOR { get; set; }
        public string RAM { get; set; }
        public string DISCO_PRINCIPAL { get; set; }
        public string DISCO_SECUNDARIO { get; set; }
    
        public virtual DISPOSITIVOS DISPOSITIVOS { get; set; }
    }
}
