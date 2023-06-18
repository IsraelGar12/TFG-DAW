using System.Collections.Generic;
using System.Threading.Tasks;
using License.viewer.api.Models;
using MySqlConnector;

namespace License.viewer.api.Productos.Infrastructure
{
    using Productos = License.viewer.api.Models.Productos;

    public class MySqlProductosRepository : IProductosRepository
    {
        private readonly MySqlConnection _connection;

        public MySqlProductosRepository(MySqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Productos>> GetAllProductos()
        {
            await _connection.OpenAsync();

            List<Productos> productos = new List<Productos>();

            string query = "SELECT * FROM productos";

            await using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                await using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        int idprod = reader.GetInt32(0);
                        string nombreprod = reader.GetString(1);
                        string categoria = reader.GetString(2);
                        DateTime fechacreacion = reader.GetDateTime(3);
                        string localizacion = reader.GetString(4);
                        int nombrevend = reader.GetInt32(5);
                        string estado = reader.GetString(6);
                        string precio = reader.GetString(7);

                        Productos producto = new Productos(idprod.ToString(), nombreprod, categoria, fechacreacion.ToString(), localizacion, nombrevend.ToString(), estado, precio);
                        productos.Add(producto);
                    }
                }
            }

            return productos;
        }

        public async Task AddProducto(Productos producto)
        {
            await _connection.OpenAsync();

            using MySqlCommand command = new MySqlCommand("INSERT INTO productos (nombreprod, categoria, fechacreacion, localizacion, nombrevend, estado, precio) VALUES (@nombreprod, @categoria, @fechacreacion, @localizacion, @nombrevend, @estado, @precio)", _connection);
            command.Parameters.AddWithValue("@nombreprod", producto.Nombreprod);
            command.Parameters.AddWithValue("@categoria", producto.Categoria);
            command.Parameters.AddWithValue("@fechacreacion", producto.Fechacreacion);
            command.Parameters.AddWithValue("@localizacion", producto.Localizacion);
            command.Parameters.AddWithValue("@nombrevend", producto.Nombrevend);
            command.Parameters.AddWithValue("@estado", producto.Estado);
            command.Parameters.AddWithValue("@precio", producto.Precio);

            await command.ExecuteNonQueryAsync();
        }
    }
}
