namespace License.viewer.api.Users.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using License.viewer.api.Models;
    using MySqlConnector;

    public class MySqlUserRepository : IUserRepository
    {
        private readonly MySqlConnection _connection;

        public MySqlUserRepository(MySqlConnection connection)
        {
            this._connection = connection;
        }

        public async Task Save(User user)
        {
            await this._connection.OpenAsync();

            using MySqlCommand command = new MySqlCommand("INSERT INTO users (nameuser, password, Name, Email, rol, address, phone, birthdate) VALUES (@nameuser, @password, @Name, @Email, @rol, @address, @phone, @birthdate)", this._connection);
            command.Parameters.AddWithValue("@nameuser", user.NameUser);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@rol", user.Rol);
            command.Parameters.AddWithValue("@address", user.Address);
            command.Parameters.AddWithValue("@phone", user.Phone);
            command.Parameters.AddWithValue("@birthdate", user.BirthDate);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<User>> Search(string? name = null, string? email = null, string? role = null)
        {
            await this._connection.OpenAsync();

            List<User> users = new List<User>();

            using MySqlCommand command = new MySqlCommand($"SELECT * FROM users WHERE nameuser = '{name}';", this._connection);
            using MySqlDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                int userId = reader.GetInt32(0);
                string nameUser = reader.GetString(1);
                string password = reader.GetString(2);
                string Name = reader.GetString(3);
                string Email = reader.GetString(4);
                string rol = reader.GetString(5);
                string address = reader.GetString(6);
                int phone = reader.GetInt32(7);
                DateTime birthDate = reader.GetDateTime(8);

                User user = new User(userId.ToString(), nameUser, password, Name, Email, rol,address,phone.ToString(),birthDate);
                users.Add(user);
            }

            return users;
        }

    }

}
