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
    }
}
