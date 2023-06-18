using License.viewer.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace License.viewer.api.Servicios.Infrastructure
{
    using Servicios = License.viewer.api.Models.Servicios;

    public interface IServiciosRepository
    {
        Task<List<Servicios>> GetAllServicios();
    }
}
