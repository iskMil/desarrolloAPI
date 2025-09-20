using Microsoft.EntityFrameworkCore;
using SENATIAPI.Model;

namespace SENATIAPI.Infrastructure;

public class SENATIDbContext : DbContext
{
    public SENATIDbContext(DbContextOptions<SENATIDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }

    // Puedes agregar más entidades aquí
    public DbSet<Docente> Docentes { get; set; }


    public DbSet<Curso> Cursos { get; set; }
}
