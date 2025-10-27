namespace AppContactos.Models;

public class Contacto
{
    public string TipoIdentificacion { get; set; }
    public string Identificacion { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Correo { get; set; }
    public double Salario { get; set; }
}
