//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaTecnica
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCTOS
    {
        public string NOMBRE { get; set; }
        public string SKU { get; set; }
        public string DESCRIPCION { get; set; }
        public int VALOR { get; set; }
        public int TIENDA { get; set; }
        public string IMAGEN { get; set; }
    
        public virtual TIENDA TIENDA1 { get; set; }
    }
}
