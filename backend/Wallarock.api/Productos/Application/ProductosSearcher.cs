using License.viewer.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace License.viewer.api.Productos.Application
{
    using License.viewer.api.Productos.Infrastructure;
    using Productos = License.viewer.api.Models.Productos;

    public class ProductosSearcher
    {
        private readonly IProductosRepository _repository;

        public ProductosSearcher(IProductosRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Productos>> SearchProductos()
        {
            List<Productos> productos = await _repository.GetAllProductos();
            return productos;
        }
    }
}
