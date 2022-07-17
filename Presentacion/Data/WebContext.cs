using Microsoft.EntityFrameworkCore;
using FrontEndProyecto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEndProyecto1.Data
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        //internal void SaveChanges() => throw new NotImplementedException();
    }
}
