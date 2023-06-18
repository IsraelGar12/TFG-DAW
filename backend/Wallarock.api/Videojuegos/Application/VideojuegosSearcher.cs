using License.viewer.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace License.viewer.api.Videojuegos.Application
{
    using License.viewer.api.Videojuegos.Infrastructure;
    using Videojuegos = License.viewer.api.Models.Videojuegos;

    public class VideojuegosSearcher
    {
        private readonly IVideojuegosRepository _repository;

        public VideojuegosSearcher(IVideojuegosRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Videojuegos>> SearchVideojuegos()
        {
            List<Videojuegos> videojuegos = await _repository.GetAllVideojuegos();
            return videojuegos;
        }
    }
}
