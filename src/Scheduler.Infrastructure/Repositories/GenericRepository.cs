﻿using Microsoft.EntityFrameworkCore;
using Scheduler.Domain.Repositories;
using Scheduler.Infrastructure.Persistence;

namespace Scheduler.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> 
        where T : class
    {
        protected readonly SchedulerDbContext _context;
        public GenericRepository(SchedulerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
