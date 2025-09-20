using Microsoft.AspNetCore.Mvc;
using SENATIAPI.Model;
using SENATIAPI.Services;
using SENATIAPI.Infrastructure;

namespace SENATIAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<IEnumerable<Cliente>> Get()
        => await _clienteService.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> Get(int id)
    {
        var cliente = await _clienteService.GetByIdAsync(id);
        if (cliente == null) return NotFound();
        return cliente;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Cliente cliente)
    {
        await _clienteService.AddAsync(cliente);
        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] Cliente cliente)
    {
        if (id != cliente.Id) return BadRequest();
        await _clienteService.UpdateAsync(cliente);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _clienteService.DeleteAsync(id);
        return NoContent();
    }
}
