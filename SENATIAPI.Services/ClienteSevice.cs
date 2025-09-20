using SENATIAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using SENATIAPI.Repository;

namespace SENATIAPI.Services;

public interface IClienteService
{
    Task<IEnumerable<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(int id);
    Task AddAsync(Cliente cliente);
    Task UpdateAsync(Cliente cliente);
    Task DeleteAsync(int id);
}

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<Cliente?> GetByIdAsync(int id)
        => await _repository.GetByIdAsync(id);

    public async Task AddAsync(Cliente cliente)
        => await _repository.AddAsync(cliente);

    public async Task UpdateAsync(Cliente cliente)
        => await _repository.UpdateAsync(cliente);

    public async Task DeleteAsync(int id)
        => await _repository.DeleteAsync(id);
}
