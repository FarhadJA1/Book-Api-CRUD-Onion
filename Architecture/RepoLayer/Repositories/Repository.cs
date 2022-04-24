using DomainLayer.Common;
using Microsoft.EntityFrameworkCore;
using RepoLayer.Data;
using RepoLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T:BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> entities;
        public Repository(AppDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();
            await entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> entityList= await entities.ToListAsync();
            if (entityList is null) throw new NullReferenceException();
            return entityList;
        }
        public async Task<T> GetAsync(int id)
        {
            T entity = await entities.FirstOrDefaultAsync(m => m.Id == id);

            if (entity is null) throw new NullReferenceException();

            return entity;
        }
        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await entities.FirstOrDefaultAsync(predicate);

        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await entities.AsQueryable().Where(predicate).ToListAsync();

        }
        
        public async Task SoftDeleteAsync(T entity)
        {
            T dbEntity = await entities.FirstOrDefaultAsync(m => m.Id == entity.Id);
            if (dbEntity is null) throw new NullReferenceException();
            dbEntity.SoftDelete = true;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();
            entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();
            entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        
    }
}
