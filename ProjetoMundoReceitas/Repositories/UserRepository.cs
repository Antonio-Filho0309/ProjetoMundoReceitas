using Microsoft.EntityFrameworkCore;
using ProjetoMundoReceitas.Data;
using ProjetoMundoReceitas.Helpers;
using ProjetoMundoReceitas.Models;
using ProjetoMundoReceitas.Models.FilterDb;
using ProjetoMundoReceitas.Pagination;
using ProjetoMundoReceitas.Repositories.Interface;

namespace ProjetoMundoReceitas.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Update(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

     

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PageBaseResponse<User>> GetPagedAsync(FilterDb request)
        {
            var query = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(u => u.Name.Contains(request.Name));
            }

            var result = await PageBaseResponseHelper.GetResponseAsync<PageBaseResponse<User>, User>(query, request);
            return result;
        }
    }
}
