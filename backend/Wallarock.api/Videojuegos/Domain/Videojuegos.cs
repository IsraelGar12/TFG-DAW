namespace License.viewer.api.Models
{
    public sealed class Videojuegos
    {
        public Videojuegos(
            string idvideo,
            string nombreprod,
            string categoria,
            string fechacreacion,
            string localizacion,
            string nombrevend,
            string estado,
            string precio)
        {
            this.Idvideo = idvideo;
            this.Nombreprod = nombreprod;
            this.Categoria = categoria;
            this.Fechacreacion = fechacreacion;
            this.Localizacion = localizacion;
            this.Nombrevend = nombrevend;
            this.Estado = estado;
            this.Precio = precio;
        }

        public string Idvideo { get; }
        public string Nombreprod { get; }
        public string Categoria { get; }
        public string Fechacreacion { get; }
        public string Localizacion { get; }
        public string Nombrevend { get; }
        public string Estado { get; }
        public string Precio { get; }
    }
}
