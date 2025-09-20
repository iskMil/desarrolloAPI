using SENATIAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using SENATIAPI.Repository;

namespace SENATIAPI.Services;

public interface ICursoService
{
    Task<IEnumerable<Curso>> GetAllAsync();
    Task<Curso?> GetByIdAsync(int id);
    Task AddAsync(Curso Curso);
    Task UpdateAsync(Curso Curso);
    Task DeleteAsync(int id);
}

public class CursoService : ICursoService
{
    private readonly ICursoRepository _repository;

    // Constructor donde se inyecta el repositorio de Curso
    public CursoService(ICursoRepository repository)
    {
        _repository = repository;
    }

    // Obtener todos los Cursos
    public async Task<IEnumerable<Curso>> GetAllAsync()
        => await _repository.GetAllAsync();

    // Obtener un Curso por ID
    public async Task<Curso?> GetByIdAsync(int id)
        => await _repository.GetByIdAsync(id);

    // Agregar un nuevo Curso
    public async Task AddAsync(Curso Curso)
        => await _repository.AddAsync(Curso);

    // Actualizar un Curso existente
    public async Task UpdateAsync(Curso Curso)
        => await _repository.UpdateAsync(Curso);

    // Eliminar un Curso por ID
    public async Task DeleteAsync(int id)
        => await _repository.DeleteAsync(id);
}
