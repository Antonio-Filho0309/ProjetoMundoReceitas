﻿using Microsoft.EntityFrameworkCore;
using ProjetoMundoReceitas.Helpers;
using ProjetoMundoReceitas.Models;

namespace ProjetoMundoReceitas.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public async Task<PageList<User>> GetUsersAsync(
           PageParams pageParams )
        {
            IQueryable<User> query = _context.Users;


            query = query.AsNoTracking().OrderBy(a=> a.Id);
            return await PageList<User>.CreateAsync(query,pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<Recipe[]> GetRecipesAsync(bool includeUser)
        {
            IQueryable<Recipe> query = _context.Recipers;

            if (includeUser)
            {
                query = query.Include(a => a.User);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);
            return  await query.ToArrayAsync();
        }

      
    }
}
