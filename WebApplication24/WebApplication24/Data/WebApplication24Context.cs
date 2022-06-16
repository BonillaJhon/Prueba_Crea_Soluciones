using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication24.Models;

namespace WebApplication24.Data
{
    public class WebApplication24Context : DbContext
    {
        public WebApplication24Context (DbContextOptions<WebApplication24Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication24.Models.Tienda> Tienda { get; set; }

        public DbSet<WebApplication24.Models.Productos> Productos { get; set; }
    }
}
