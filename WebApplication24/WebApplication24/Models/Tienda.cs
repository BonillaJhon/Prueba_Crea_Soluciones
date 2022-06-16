using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication24.Models
{
    public class Tienda
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime FECHADEAPERTURA { get; set; }
    }
}
