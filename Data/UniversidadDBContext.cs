using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Universidad.Models;

namespace Universidad.Data
{
    public class UniversidadDBContext : DbContext
    {
        public UniversidadDBContext (DbContextOptions<UniversidadDBContext> options)
            : base(options)
        {
        }

        public DbSet<Universidad.Models.Curso> Curso { get; set; } = default!;

        public DbSet<Universidad.Models.Estudiante> Estudiante { get; set; }

        public DbSet<Universidad.Models.Inscripcion> Inscripcion { get; set; }
    }
}
