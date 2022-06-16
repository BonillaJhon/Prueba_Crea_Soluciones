using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication24.Models
{
    public class Productos
    {
        [Key]
        public string Nombre { get; set; }
        public string SKU { get; set; }
        public string Descripcion  { get; set; }
        public int valor { get; set; }
        public int Tienda { get; set; }
        public string Imagen { get; set; }
    }
}
