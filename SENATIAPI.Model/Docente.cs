namespace SENATIAPI.Model;

public class Docente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string? Direccion { get; set; }
    public bool? Enabled { get; set; }
}

