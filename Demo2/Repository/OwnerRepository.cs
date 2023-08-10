using Demo2.Entity;

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
    }
}
