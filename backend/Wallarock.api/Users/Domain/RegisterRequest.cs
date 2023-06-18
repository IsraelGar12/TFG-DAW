namespace License.viewer.api.Models;


public sealed class RegisterRequest
{
    public string NameUser { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Address { get; set; }     // Nuevo campo: dirección
    public string Phone { get; set; }       // Nuevo campo: teléfono
    public DateTime BirthDate { get; set; } // Nuevo campo: fecha de nacimiento
}
