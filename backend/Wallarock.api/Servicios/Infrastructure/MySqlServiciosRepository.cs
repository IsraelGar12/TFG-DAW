using License.viewer.api.Models;
using MySqlConnector;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace License.viewer.api.Servicios.Infrastructure
{
    using Servicios = License.viewer.api.Models.Servicios;

    public class MySqlServiciosRepository : IServiciosRepository
    {
        private readonly MySqlConnection _connection;

        public MySqlServiciosRepository(MySqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Servicios>> GetAllServicios()
        {
            await _connection.OpenAsync();

            List<Servicios> servicios = new List<Servicios>();

            string query = "SELECT * FROM servicios";

            await using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                await using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        int idserv = reader.GetInt32(0);
                        string nombreserv = reader.GetString(1);
                        string categoria = reader.GetString(2);
                        DateTime fechacreacion = reader.GetDateTime(3);
                        string localizacion = reader.GetString(4);
                        int nombrevend = reader.GetInt32(5);
                        string valoracion = reader.GetString(6);
                        int precio = reader.GetInt32(7);

                        Servicios servicio = new Servicios(idserv.ToString(), nombreserv, categoria, fechacreacion.ToString(), localizacion, nombrevend.ToString(), valoracion, precio.ToString());
                        servicios.Add(servicio);
                    }
                }
            }

            return servicios;
        }
    }
}
