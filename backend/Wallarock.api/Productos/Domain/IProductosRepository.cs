using License.viewer.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace License.viewer.api.Productos.Infrastructure
{
    using Productos = License.viewer.api.Models.Productos;

    public interface IProductosRepository
    {
        Task<List<Productos>> GetAllProductos();
        Task AddProducto(Productos producto);

    }
}
