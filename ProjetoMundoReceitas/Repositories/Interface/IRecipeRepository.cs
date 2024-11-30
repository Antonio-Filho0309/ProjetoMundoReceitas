using ProjetoMundoReceitas.Models;

namespace ProjetoMundoReceitas.Repositories.Interface
{
    public interface IRecipeRepository
    {
        Task<Recipe> Add(Recipe recipe);
        Task Update(Recipe recipe);

        Task Delete(Recipe recipe);
        Task<ICollection<Recipe>> GetAllRecipers();

        Task<Recipe> GeRecipersById(int id);
    }
}
