namespace License.viewer.api.Controllers
{
    using License.viewer.api.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("devices_list")]

    public class DevicesController : ControllerBase
    {
        [HttpGet]
        public dynamic listarCliente()
        {
        List<Devices> devices = new List<Devices>
            {
                new Devices(
                    "000000-001",
                    "1234",
                    "452343",
                    "000000-1",
                    "000000-2",
                    "000000-3",
                    "000000-4",
                    "000000-5",
                    "000000-6",
                    "TEST"
                ),

                new Devices(
                    "000000-001",
                    "1234",
                    "452343",
                    "000000-1",
                    "000000-2",
                    "000000-3",
                    "000000-4",
                    "000000-5",
                    "000000-6",
                    "PROD"
                ),
                new Devices(
                    "000000-003",
                    "1234",
                    "452343",
                    "000000-1",
                    "000000-2",
                    "000000-3",
                    "000000-4",
                    "000000-5",
                    "000000-6",
                    "PROD"
                ),
                new Devices(
                    "000000-004",
                    "1234",
                    "452343",
                    "000000-1",
                    "000000-2",
                    "000000-3",
                    "000000-4",
                    "000000-5",
                    "000000-6",
                    "TEST"
                ),
            };
            return devices;
    }
}
}
