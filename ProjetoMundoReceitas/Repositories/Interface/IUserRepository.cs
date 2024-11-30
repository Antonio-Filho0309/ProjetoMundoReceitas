using ProjetoMundoReceitas.Helpers;
using ProjetoMundoReceitas.Models;
using ProjetoMundoReceitas.Models.FilterDb;
using ProjetoMundoReceitas.Pagination;

namespace ProjetoMundoReceitas.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        Task Update(User user);
        Task<ICollection<User>> GetAllUsers();

        Task<User> GetUserById(int id);


    }
}
