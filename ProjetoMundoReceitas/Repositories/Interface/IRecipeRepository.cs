using ProjetoMundoReceitas.Models;
using ProjetoMundoReceitas.Models.FilterDb;
using ProjetoMundoReceitas.Pagination;

namespace ProjetoMundoReceitas.Repositories.Interface
{
    public interface IRecipeRepository
    {
        Task<Recipe> Add(Recipe recipe);
        Task Update(Recipe recipe);

        Task Delete(Recipe recipe);
        Task<ICollection<Recipe>> GetAllRecipers();

        Task<PageBaseResponse<Recipe>> GetPagedAsync(FilterDb request);

        Task<Recipe> GeRecipersById(int id);
    }
}
