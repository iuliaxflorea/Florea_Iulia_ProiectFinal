using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Florea_Iulia_ProiectFinal.Models;

namespace Florea_Iulia_ProiectFinal.Data
{
    public class Florea_Iulia_ProiectFinalContext : DbContext
    {
        public Florea_Iulia_ProiectFinalContext (DbContextOptions<Florea_Iulia_ProiectFinalContext> options)
            : base(options)
        {
        }

        public DbSet<Florea_Iulia_ProiectFinal.Models.Camera> Camera { get; set; }

        public DbSet<Florea_Iulia_ProiectFinal.Models.Store> Store { get; set; }

        public DbSet<Florea_Iulia_ProiectFinal.Models.Category> Category { get; set; }
    }
}
