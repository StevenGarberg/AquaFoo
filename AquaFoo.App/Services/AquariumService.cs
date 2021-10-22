using AquaFoo.App.Models;
using GG.DataAccess.Repositories.Interfaces;

namespace AquaFoo.App.Services
{
    public class AquariumService : ResourceService<Aquarium>
    {
        public AquariumService(IResourceRepository<Aquarium> resourceRepository) : base(resourceRepository)
        {
        }
    }
}