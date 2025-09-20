using Microsoft.AspNetCore.Mvc;
using SENATIAPI.Model;
using SENATIAPI.Services;
using SENATIAPI.Infrastructure;

namespace SENATIAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocenteController : ControllerBase
{
    private readonly IDocenteService _docenteService;

    // Constructor para inyectar el servicio de Docente
    public DocenteController(IDocenteService docenteService)
    {
        _docenteService = docenteService;
    }

    // Obtener todos los docentes
    [HttpGet]
    public async Task<IEnumerable<Docente>> Get()
        => await _docenteService.GetAllAsync();

    // Obtener un docente por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Docente>> Get(int id)
    {
        var docente = await _docenteService.GetByIdAsync(id);
        if (docente == null) return NotFound();
        return docente;
    }

    // Crear un nuevo docente
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Docente docente)
    {
        await _docenteService.AddAsync(docente);
        return CreatedAtAction(nameof(Get), new { id = docente.Id }, docente);
    }

    // Actualizar un docente existente
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] Docente docente)
    {
        if (id != docente.Id) return BadRequest();
        await _docenteService.UpdateAsync(docente);
        return NoContent();
    }

    // Eliminar un docente por ID
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _docenteService.DeleteAsync(id);
        return NoContent();
    }
}
