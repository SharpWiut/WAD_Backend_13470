﻿using Microsoft.EntityFrameworkCore;

namespace SPI.Repositories
{
    public interface IRepository <T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIDAsync(int it);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<int> CountAsync();
        Task UpdateQuantityAsync(int id, int quantityDelta);

    }
}
