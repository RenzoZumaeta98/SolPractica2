using Microsoft.EntityFrameworkCore;
using SolPractica2.DataAccess.Entities;

namespace SolPractica2.DataAccess
{
    public class NotasAlumnoContext : DbContext
    {
        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Notas> Notas { get; set; }

        public NotasAlumnoContext(DbContextOptions<NotasAlumnoContext> option) : base(option)
        {
        }
    }
}
