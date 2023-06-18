using License.viewer.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace License.viewer.api.Servicios.Application
{
    using License.viewer.api.Servicios.Infrastructure;
    using Servicios = License.viewer.api.Models.Servicios;

    public class ServiciosSearcher
    {
        private readonly IServiciosRepository _repository;

        public ServiciosSearcher(IServiciosRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Servicios>> SearchServicios()
        {
            List<Servicios> servicios = await _repository.GetAllServicios();
            return servicios;
        }
    }
}
