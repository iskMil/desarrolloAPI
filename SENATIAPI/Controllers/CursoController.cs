using Microsoft.AspNetCore.Mvc;
using SENATIAPI.Model;
using SENATIAPI.Services;
using SENATIAPI.Infrastructure;

namespace SENATIAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursoController : ControllerBase
{
    private readonly ICursoService _CursoService;

    // Constructor para inyectar el servicio de Curso
    public CursoController(ICursoService CursoService)
    {
        _CursoService = CursoService;
    }

    // Obtener todos los Cursos
    [HttpGet]
    public async Task<IEnumerable<Curso>> Get()
        => await _CursoService.GetAllAsync();

    // Obtener un Curso por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Curso>> Get(int id)
    {
        var Curso = await _CursoService.GetByIdAsync(id);
        if (Curso == null) return NotFound();
        return Curso;
    }

    // Crear un nuevo Curso
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Curso Curso)
    {
        await _CursoService.AddAsync(Curso);
        return CreatedAtAction(nameof(Get), new { id = Curso.Id }, Curso);
    }

    // Actualizar un Curso existente
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] Curso Curso)
    {
        if (id != Curso.Id) return BadRequest();
        await _CursoService.UpdateAsync(Curso);
        return NoContent();
    }

    // Eliminar un Curso por ID
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _CursoService.DeleteAsync(id);
        return NoContent();
    }
}
