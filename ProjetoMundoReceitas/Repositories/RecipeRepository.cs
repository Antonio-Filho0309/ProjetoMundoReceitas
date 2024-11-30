using Microsoft.EntityFrameworkCore;
using ProjetoMundoReceitas.Data;
using ProjetoMundoReceitas.Models;
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

        public async Task Update(Recipe recipe)
        {
            _context.Update(recipe);
            await _context.SaveChangesAsync();
        }
    }
}
