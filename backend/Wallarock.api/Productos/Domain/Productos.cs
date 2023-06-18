namespace License.viewer.api.Models;

public sealed class Productos
{
    public Productos(
        string idprod,
        string nombreprod,
        string categoria,
        string fechacreacion,
        string localizacion,
        string nombrevend,
        string estado,
        string precio
    )
    {
        this.Idprod = idprod;
        this.Nombreprod = nombreprod;
        this.Categoria = categoria;
        this.Fechacreacion = fechacreacion;
        this.Localizacion = localizacion;
        this.Nombrevend = nombrevend;
        this.Estado = estado;
        this.Precio = precio;

    }

    public string Idprod { get; }
    public string Nombreprod { get; }
    public string Categoria { get; }
    public string Fechacreacion { get; }
    public string Localizacion { get; }
    public string Nombrevend { get; }
    public string Estado { get; }
    public string Precio { get; }

}
