using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace License.viewer.api.Productos.Infrastructure
{
    using License.viewer.api.Models;
    using License.viewer.api.Productos.Application;

    [ApiController]
    [Route("productos")]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosSearcher _searcher;
        private readonly ProductosCreator _creator;

        public ProductosController(ProductosSearcher searcher, ProductosCreator creator)
        {
            _searcher = searcher;
            _creator = creator;
        }

        [ProducesResponseType(typeof(List<Productos>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> SearchProductos()
        {
            List<Productos> productos = await _searcher.SearchProductos();
            return Ok(productos);
        }

        [ProducesResponseType(typeof(Productos), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] Productos producto)
        {
            if (producto == null)
            {
                return BadRequest();
            }

            // Lógica para crear el nuevo producto
            await _creator.CreateProducto(producto);

            return CreatedAtAction(nameof(SearchProductos), producto);
        }
    }
}
