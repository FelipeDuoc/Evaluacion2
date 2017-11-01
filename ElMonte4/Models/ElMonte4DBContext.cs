using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ElMonte4.Models
{
    public class ElMonte4DBContext:DbContext
    {
        public DbSet<Condena> Condenas { get; set; }
        public DbSet<CondenaDelito> CondenaDelitos { get; set; }
        public DbSet<Delito> Delitos { get; set; }
        public DbSet<Juez> Juezs { get; set; }
        public DbSet<Preso> Presos { get; set; }

    }
}