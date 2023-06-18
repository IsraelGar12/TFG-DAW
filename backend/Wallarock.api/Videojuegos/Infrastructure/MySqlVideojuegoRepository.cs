namespace License.viewer.api.Videojuegos.Infrastructure
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using License.viewer.api.Models;
    using MySqlConnector;

    public class MySqlVideojuegosRepository : IVideojuegosRepository
    {
        private readonly MySqlConnection _connection;

        public MySqlVideojuegosRepository(MySqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Videojuegos>> GetAllVideojuegos()
        {
            await _connection.OpenAsync();

            List<Videojuegos> videojuegos = new List<Videojuegos>();

            using MySqlCommand command = new MySqlCommand("SELECT * FROM videojuegos", _connection);
            using MySqlDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                string nombreprod = reader.GetString(1);
                string categoria = reader.GetString(2);
                DateTime fechacreacion = reader.GetDateTime(3);
                string localizacion = reader.GetString(4);
                int nombrevend = reader.GetInt32(5);
                string estado = reader.GetString(6);
                string precio = reader.GetString(7);

                Videojuegos videojuego = new Videojuegos(id.ToString(), nombreprod, categoria, fechacreacion.ToString(), localizacion, nombrevend.ToString(), estado, precio);
                videojuegos.Add(videojuego);
            }

            return videojuegos;
        }

        public async Task AddVideojuego(Videojuegos videojuego)
        {
            await _connection.OpenAsync();

            using MySqlCommand command = new MySqlCommand("INSERT INTO videojuegos (nombreprod, categoria, fechacreacion, localizacion, nombrevend, estado, precio) VALUES (@nombreprod, @categoria, @fechacreacion, @localizacion, @nombrevend, @estado, @precio)", _connection);
            command.Parameters.AddWithValue("@nombreprod", videojuego.Nombreprod);
            command.Parameters.AddWithValue("@categoria", videojuego.Categoria);
            command.Parameters.AddWithValue("@fechacreacion", videojuego.Fechacreacion);
            command.Parameters.AddWithValue("@localizacion", videojuego.Localizacion);
            command.Parameters.AddWithValue("@nombrevend", videojuego.Nombrevend);
            command.Parameters.AddWithValue("@estado", videojuego.Estado);
            command.Parameters.AddWithValue("@precio", videojuego.Precio);

            await command.ExecuteNonQueryAsync();
        }
    }
}
