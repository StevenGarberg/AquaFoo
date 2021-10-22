using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GG.DataAccess.Models;
using GG.DataAccess.Repositories.Interfaces;
using GG.Errors.Exceptions;

namespace AquaFoo.App.Services
{
    public class ResourceService<T> : IResourceService<T> where T : ResourceBase
    {
        protected readonly IResourceRepository<T> _resourceRepository;
        
        public ResourceService(IResourceRepository<T> resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public async Task<T> GetAsync(string resourceId)
        {
            return await _resourceRepository.GetByIdAsync(resourceId);
        }
        
        public async Task<List<T>> GetAllAsync(string ownerId)
        {
            return await _resourceRepository.GetByOwnerAsync(ownerId);
        }

        public async Task<T> PostAsync(string userId, T data)
        {
            data.OwnerId = userId;
            return await _resourceRepository.CreateResourceAsync(data);
        }

        public async Task<T> PutAsync(string userId, string resourceId, T data)
        {
            var resource = await _resourceRepository.GetByIdAsync(resourceId);
            if (resource.OwnerId != userId)
                throw new ForbiddenException();
            return await _resourceRepository.UpdateResourceAsync(data);
        }

        public async Task DeleteAsync(string userId, string resourceId)
        {
            var resource = await _resourceRepository.GetByIdAsync(resourceId);
            if (resource.OwnerId != userId)
                throw new ForbiddenException();
            resource.Deleted = true;
            await _resourceRepository.UpdateResourceAsync(resource);
        }
    }
}