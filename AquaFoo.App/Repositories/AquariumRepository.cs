using AquaFoo.App.Data;
using AquaFoo.App.Models;
using GG.DataAccess.Repositories;

namespace AquaFoo.App.Repositories
{
  public class AquariumRepository : ResourceRepository<Aquarium>
    {
        public AquariumRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}