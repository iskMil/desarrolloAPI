namespace SENATIAPI.Model;

public class Cliente
{
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string? Dni { get; set; }
    public string? Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string mensaje { get; set; }
}
