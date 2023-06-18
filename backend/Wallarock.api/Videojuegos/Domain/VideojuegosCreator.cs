using System.Threading.Tasks;
using License.viewer.api.Models;
using License.viewer.api.Videojuegos.Infrastructure;

namespace License.viewer.api.Videojuegos.Application
{
    using Videojuegos = License.viewer.api.Models.Videojuegos;

    public class VideojuegosCreator
    {
        private readonly IVideojuegosRepository _videojuegosRepository;

        public VideojuegosCreator(IVideojuegosRepository videojuegosRepository)
        {
            _videojuegosRepository = videojuegosRepository;
        }

        public async Task CreateVideojuego(Videojuegos videojuego)
        {
            // Aquí puedes realizar validaciones adicionales o lógica de negocio antes de guardar el videojuego

            await _videojuegosRepository.AddVideojuego(videojuego);
        }
    }
}
