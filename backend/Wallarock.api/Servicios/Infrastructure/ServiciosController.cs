using License.viewer.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace License.viewer.api.Servicios.Infrastructure
{
    using License.viewer.api.Servicios.Application;
    using Servicios = License.viewer.api.Models.Servicios;

    [ApiController]
    [Route("servicios")]
    public class ServiciosController : ControllerBase
    {
        private readonly ServiciosSearcher _searcher;

        public ServiciosController(ServiciosSearcher searcher)
        {
            _searcher = searcher;
        }

        [ProducesResponseType(typeof(List<Servicios>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> SearchServicios()
        {
            List<Servicios> servicios = await _searcher.SearchServicios();
            return Ok(servicios);
        }
    }
}
