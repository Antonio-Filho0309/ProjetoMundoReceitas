using ProjetoMundoReceitas.Helpers;
using ProjetoMundoReceitas.Models;

namespace ProjetoMundoReceitas.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Usuário
        Task<PageList<User>> GetUsersAsync(
             PageParams pageParams);

        //receita
        Task<Recipe[]> GetRecipesAsync(bool includeUser);
    }
}
