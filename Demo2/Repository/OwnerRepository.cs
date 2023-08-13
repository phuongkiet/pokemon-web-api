using Demo2.Entity;
using Microsoft.EntityFrameworkCore;

namespace Demo2.Repository
{
    public class OwnerRepository : BaseRepository<Owner>
    {
        public bool OwnerExist(int id)
        {
            return _context.Owner.Any(o => o.Id == id);
        }

        public async Task<ICollection<Pokemon>> GetPokemonByOwner(int ownerId)
        {
            var pokemonByOwner =  _context.PokemonOwners.Where(p => p.OwnerId == ownerId).Select(p => p.Pokemon);
            return pokemonByOwner.ToList();
        }

        public async Task CreateOwner(int regionId, Owner owner)
        {
            var ownerRegion = _context.Region.Where(r => r.Id == regionId).FirstOrDefault();

            owner = new Owner()
            {
                Id = owner.Id,
                Name = owner.Name,
                Gym = owner.Gym,
                Region = ownerRegion
            };

            await this.Add(owner);
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<Owner>> GetOwnersV2()
        {
            var owners = await _context.Owner.ToListAsync();
            var regions = await _context.Region.ToListAsync();
            var result = (
                from owner in owners
                join region in regions on owner.Region.Id equals region.Id
                select new Owner()
                {
                    Id = owner.Id,
                    Name = owner.Name,
                    Gym = owner.Gym,
                    Region = new Region()
                    {
                        Id = region.Id,
                        Name = region.Name,
                    }
                }).ToList();

            return result;
        }

        public async Task<ICollection<Owner>> GetOwnersV3()
        {
            var result = _context.Owner.Include(r => r.Region);
            return result.ToList();
        }
    }
}
