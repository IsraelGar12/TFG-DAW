using License.viewer.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace License.viewer.api.Videojuegos.Infrastructure
{
    using Videojuegos = License.viewer.api.Models.Videojuegos;

    public interface IVideojuegosRepository
    {
        Task<List<Videojuegos>> GetAllVideojuegos();
        Task AddVideojuego(Videojuegos videojuego);
    }
}
