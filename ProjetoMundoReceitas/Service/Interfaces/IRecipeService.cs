using ProjetoLivrariaAPI.Models.Dtos;
using ProjetoMundoReceitas.Dto.Recipe;
using ProjetoMundoReceitas.Dto.User;
using ProjetoMundoReceitas.Models;
using ProjetoMundoReceitas.Models.FilterDb;

namespace ProjetoMundoReceitas.Service.Interfaces
{
    public interface IRecipeService
    {
        Task<ResultService<CreateRecipeDto>> CreateAsync(CreateRecipeDto createRecipeDto);
        Task<ResultService<ICollection<Recipe>>> GetAllAsync();
        Task<ResultService> UpdateAsync(UpdateRecipeDto updateRecipeDto);
        Task<ResultService<PagedBaseResponseDto<Recipe>>> GetPagedAsync(FilterDb filterDb);
        Task<ResultService> Delete(int id);
    }
}
