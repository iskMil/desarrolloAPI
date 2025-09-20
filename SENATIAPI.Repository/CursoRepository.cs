using Microsoft.EntityFrameworkCore;
using SENATIAPI.Model;
using SENATIAPI.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SENATIAPI.Repository;

public interface ICursoRepository
{
    Task<IEnumerable<Curso>> GetAllAsync();
    Task<Curso?> GetByIdAsync(int id);
    Task AddAsync(Curso Curso);
    Task UpdateAsync(Curso Curso);
    Task DeleteAsync(int id);
}

public class CursoRepository : ICursoRepository
{
    private readonly SENATIDbContext _context;

    public CursoRepository(SENATIDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Curso>> GetAllAsync()
    {
        return await _context.Cursos.Include(x=> x.Docente).ToListAsync();
    }

    public async Task<Curso?> GetByIdAsync(int id)
    {
        return await _context.Cursos.FindAsync(id);
    }

    public async Task AddAsync(Curso Curso)
    {
        await _context.Cursos.AddAsync(Curso);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Curso Curso)
    {
        _context.Cursos.Update(Curso);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var Curso = await _context.Cursos.FindAsync(id);
        if (Curso != null)
        {
            _context.Cursos.Remove(Curso);
            await _context.SaveChangesAsync();
        }
    }
}
