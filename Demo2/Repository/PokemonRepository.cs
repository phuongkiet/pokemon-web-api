using Demo2.Entity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Demo2.Repository
{
    public class PokemonRepository : BaseRepository<Pokemon>
    {
        public bool PokemonExist(int id)
        {
            return _context.Pokemon.Any(p => p.Id == id);
        }

        public async Task CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owner.Where(a => a.Id == ownerId).FirstOrDefault();
            var category = _context.Category.Where(a => a.Id == categoryId).FirstOrDefault();

            var pokemonOwner = new PokemonOwners()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon,
            };

            await _context.Set<PokemonOwners>().AddAsync(pokemonOwner);
            
            var pokemonCategory = new PokemonCategories()
            {
                Category = category,
                Pokemon = pokemon,
            };

            await _context.Set<PokemonCategories>().AddAsync(pokemonCategory);
            
            await _context.Set<Pokemon>().AddAsync(pokemon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePokemon(int ownerId, int cateId, Pokemon pokemon)
        {
            await this.Update(pokemon);
        }
    }
}
