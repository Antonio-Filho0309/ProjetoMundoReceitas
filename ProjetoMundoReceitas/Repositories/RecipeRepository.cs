using Microsoft.EntityFrameworkCore;
using ProjetoMundoReceitas.Data;
using ProjetoMundoReceitas.Helpers;
using ProjetoMundoReceitas.Models;
using ProjetoMundoReceitas.Models.FilterDb;
using ProjetoMundoReceitas.Pagination;
using ProjetoMundoReceitas.Repositories.Interface;

namespace ProjetoMundoReceitas.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
     
        private readonly DataContext _context;

        public RecipeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Recipe> Add(Recipe recipe)
        {
            _context.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }

        public async Task Delete(Recipe recipe)
        {
            _context.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<Recipe> GeRecipersById(int id)
        {
            return await _context.Recipers.Include(r => r.User)
                               .FirstOrDefaultAsync(r => r.Id == id);
        }

        public  async Task<ICollection<Recipe>> GetAllRecipers()
        {
            return await _context.Recipers.Include(u => u.User).ToListAsync();
        }

        public async Task<PageBaseResponse<Recipe>> GetPagedAsync(FilterDb request)
        {
            var query = _context.Recipers.AsQueryable();
            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(u => u.RecipeName.Contains(request.Name));
            }

            var result = await PageBaseResponseHelper.GetResponseAsync<PageBaseResponse<Recipe>, Recipe>(query, request);
            return result;
        }

        public async Task Update(Recipe recipe)
        {
            _context.Update(recipe);
            await _context.SaveChangesAsync();
        }
    }
}
