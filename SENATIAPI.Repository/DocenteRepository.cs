using Microsoft.EntityFrameworkCore;
using SENATIAPI.Model;
using SENATIAPI.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SENATIAPI.Repository;

public interface IDocenteRepository
{
    Task<IEnumerable<Docente>> GetAllAsync();
    Task<Docente?> GetByIdAsync(int id);
    Task AddAsync(Docente Docente);
    Task UpdateAsync(Docente Docente);
    Task DeleteAsync(int id);
}

public class DocenteRepository : IDocenteRepository
{
    private readonly SENATIDbContext _context;

    public DocenteRepository(SENATIDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Docente>> GetAllAsync()
    {
        return await _context.Docentes.ToListAsync();
    }

    public async Task<Docente?> GetByIdAsync(int id)
    {
        return await _context.Docentes.FindAsync(id);
    }

    public async Task AddAsync(Docente Docente)
    {
        await _context.Docentes.AddAsync(Docente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Docente Docente)
    {
        _context.Docentes.Update(Docente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var Docente = await _context.Docentes.FindAsync(id);
        if (Docente != null)
        {
            _context.Docentes.Remove(Docente);
            await _context.SaveChangesAsync();
        }
    }
}
