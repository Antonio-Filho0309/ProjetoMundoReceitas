namespace ProjetoMundoReceitas.Models
{
    public class User
    {
        public User() { }


        public User(int id, string email, string password, string name) {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.Name = name;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
    }
}
