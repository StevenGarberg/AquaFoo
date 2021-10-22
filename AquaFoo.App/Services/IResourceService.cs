using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GG.DataAccess.Models;

namespace AquaFoo.App.Services
{
    public interface IResourceService<T> where T : ResourceBase
    {
        Task<T> GetAsync(string resourceId);
        Task<List<T>> GetAllAsync(string ownerId);
        Task<T> PostAsync(string userId, T data);
        Task<T> PutAsync(string userId, string resourceId, T data);
        Task DeleteAsync(string userId, string resourceId);
    }
}