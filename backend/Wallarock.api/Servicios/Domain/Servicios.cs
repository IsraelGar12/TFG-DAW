namespace License.viewer.api.Models;

public sealed class Servicios
{
    public Servicios(
        string idserv,
        string nombreserv,
        string categoria,
        string fechacreacion,
        string localizacion,
        string nombrevend,
        string valoracion,
        string precio
    )
    {
        this.Idserv = idserv;
        this.Nombreserv = nombreserv;
        this.Categoria = categoria;
        this.Fechacreacion = fechacreacion;
        this.Localizacion = localizacion;
        this.Nombrevend = nombrevend;
        this.Valoracion = valoracion;
        this.Precio = precio;

    }

    public string Idserv { get; }
    public string Nombreserv { get; }
    public string Categoria { get; }
    public string Fechacreacion { get; }
    public string Localizacion { get; }
    public string Nombrevend { get; }
    public string Valoracion { get; }
    public string Precio { get; }

}
