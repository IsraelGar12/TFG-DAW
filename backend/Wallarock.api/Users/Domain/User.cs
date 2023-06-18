namespace License.viewer.api.Models
{
    public sealed class User
    {

        public User(
            string iduser,
            string nameuser,
            string password,
            string name,
            string email,
            string rol,
            string address,
            string phone,
            DateTime birthDate)
        {
            this.IdUser = iduser;
            this.NameUser = nameuser;
            this.Password = password;
            this.Name = name;
            this.Email = email;
            this.Rol = rol;
            this.Address = address;
            this.Phone = phone;
            this.BirthDate = birthDate;
        }

        public string IdUser { get; private set; }
        public string NameUser { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Rol { get; private set; }

        public string Address { get; private set; }

        public string Phone { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
