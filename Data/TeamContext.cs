using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComputProject.Models;

    public class TeamContext : DbContext
    {
        public TeamContext (DbContextOptions<TeamContext> options)
            : base(options)
        {
        }

        public DbSet<ComputProject.Models.Documento> Documento { get; set; }

        public DbSet<ComputProject.Models.Figura> Figura { get; set; }

        public DbSet<ComputProject.Models.Cliente> Cliente { get; set; }
    }
