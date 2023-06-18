using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace License.viewer.api.Videojuegos.Infrastructure
{
    using License.viewer.api.Models;
    using License.viewer.api.Videojuegos.Application;

    [ApiController]
    [Route("videojuegos")]
    public class VideojuegosController : ControllerBase
    {
        private readonly VideojuegosSearcher _searcher;
        private readonly VideojuegosCreator _creator;

        public VideojuegosController(VideojuegosSearcher searcher, VideojuegosCreator creator)
        {
            _searcher = searcher;
            _creator = creator;
        }

        [ProducesResponseType(typeof(List<Videojuegos>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> SearchVideojuegos()
        {
            List<Videojuegos> videojuegos = await _searcher.SearchVideojuegos();
            return Ok(videojuegos);
        }

        [ProducesResponseType(typeof(Videojuegos), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateVideojuego([FromBody] Videojuegos videojuego)
        {
            if (videojuego == null)
            {
                return BadRequest();
            }

            // Lógica para crear el nuevo videojuego
            await _creator.CreateVideojuego(videojuego);

            return CreatedAtAction(nameof(SearchVideojuegos), videojuego);
        }
    }
}
