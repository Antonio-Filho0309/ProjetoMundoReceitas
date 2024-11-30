using ProjetoMundoReceitas.Dto.Recipe;
using ProjetoMundoReceitas.Dto.User;
using ProjetoMundoReceitas.Models;

namespace ProjetoMundoReceitas.Service.Interfaces
{
    public interface IRecipeService
    {
        Task<ResultService<CreateRecipeDto>> CreateAsync(CreateRecipeDto createRecipeDto);
        Task<ResultService<ICollection<Recipe>>> GetAllAsync();
        Task<ResultService> UpdateAsync(UpdateRecipeDto updateRecipeDto);

        Task<ResultService> Delete(int id);
    }
}
