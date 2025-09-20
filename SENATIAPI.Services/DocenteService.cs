using SENATIAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using SENATIAPI.Repository;

namespace SENATIAPI.Services;

public interface IDocenteService
{
    Task<IEnumerable<Docente>> GetAllAsync();
    Task<Docente?> GetByIdAsync(int id);
    Task AddAsync(Docente docente);
    Task UpdateAsync(Docente docente);
    Task DeleteAsync(int id);
}

public class DocenteService : IDocenteService
{
    private readonly IDocenteRepository _repository;

    // Constructor donde se inyecta el repositorio de Docente
    public DocenteService(IDocenteRepository repository)
    {
        _repository = repository;
    }

    // Obtener todos los docentes
    public async Task<IEnumerable<Docente>> GetAllAsync()
        => await _repository.GetAllAsync();

    // Obtener un docente por ID
    public async Task<Docente?> GetByIdAsync(int id)
        => await _repository.GetByIdAsync(id);

    // Agregar un nuevo docente
    public async Task AddAsync(Docente docente)
        => await _repository.AddAsync(docente);

    // Actualizar un docente existente
    public async Task UpdateAsync(Docente docente)
        => await _repository.UpdateAsync(docente);

    // Eliminar un docente por ID
    public async Task DeleteAsync(int id)
        => await _repository.DeleteAsync(id);
}
