using System.Threading.Tasks;
using License.viewer.api.Models;
using License.viewer.api.Productos.Infrastructure;

namespace License.viewer.api.Productos.Application
{
    using Productos = License.viewer.api.Models.Productos;

    public class ProductosCreator
    {
        private readonly IProductosRepository _productosRepository;

        public ProductosCreator(IProductosRepository productosRepository)
        {
            _productosRepository = productosRepository;
        }

        public async Task CreateProducto(Productos producto)
        {
            // Aquí puedes realizar validaciones adicionales o lógica de negocio antes de guardar el producto

            await _productosRepository.AddProducto(producto);
        }
    }
}
