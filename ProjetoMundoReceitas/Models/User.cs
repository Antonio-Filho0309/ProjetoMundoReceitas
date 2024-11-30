namespace ProjetoMundoReceitas.Models
{
    public class User
    {
        public User() { }


        public User(int id, string email, string password, string name) {
            Id = id;
            Email = email;
            Password = password;
            Name = name;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

    }
}
