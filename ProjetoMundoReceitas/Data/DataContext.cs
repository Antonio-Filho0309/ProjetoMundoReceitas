using Microsoft.EntityFrameworkCore;
using ProjetoMundoReceitas.Models;

namespace ProjetoMundoReceitas.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new List<User>(){
                    new User(1, "Lauro@gmail.com" , "1234", "Lauro"),
                   new User(1, "Antonio@gmail.com" , "1234", "Antonio"),
                     new User(1, "Batman@gmail.com" , "1234", "Batman"),
                     new User(1, "Miguel@gmail.com" , "1234", "Miguel"),
                    new User(1, "Lucas@gmail.com" , "1234", "Lucas"),
                });

            builder.Entity<Recipe>()
               .HasData(new List<Recipe>
               {
                   new Recipe(1, "Bolo da Negona", "Custo medio", "MUITO GOSTOSO", "TESTE TESTE TESTE TESTE", "TESTE TESTE TESTE", "TESTE", 1),
                   new Recipe(2, "Bolo da Negona", "Custo medio", "MUITO GOSTOSO", "TESTE TESTE TESTE TESTE", "TESTE TESTE TESTE", "TESTE", 1),
                   new Recipe(3, "Bolo da Negona", "Custo medio", "MUITO GOSTOSO", "TESTE TESTE TESTE TESTE", "TESTE TESTE TESTE", "TESTE", 1),
               });
        }
    }
}

