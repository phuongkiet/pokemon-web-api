using AutoMapper;
using Demo2.Entity;
using Demo2.Repository;

namespace Demo2.Interfaces
{
    public interface IPokemonService
    {
        public Task<ICollection<Pokemon>> GetPokemons();
        public Task CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);

        public Task DeletePokemon(Pokemon pokemon);
        public Task UpdatePokemon(int ownerId, int cateId, Pokemon pokemon);

        public Task<Pokemon> GetPokemonById(int id);
        public bool PokemonExist(int pokeId);

    }

    public class PokemonService : IPokemonService
    {
        private readonly PokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public PokemonService(IMapper mapper ,PokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<Pokemon>> GetPokemons()
        {
            var pokemon = await _pokemonRepository.GetAll();
            return pokemon.ToList();
        }

        public async Task CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            await _pokemonRepository.CreatePokemon(ownerId, categoryId, pokemon);
        }

        public async Task DeletePokemon(Pokemon pokemon)
        {
            await _pokemonRepository.Delete(pokemon);
        }

        public async Task UpdatePokemon(int ownerId, int cateId, Pokemon pokemon)
        {
            await _pokemonRepository.UpdatePokemon(ownerId, cateId, pokemon);
        }

        public async Task<Pokemon> GetPokemonById(int id)
        {
            return await _pokemonRepository.GetByIntId(id);
        }

        public bool PokemonExist(int pokeId)
        {
            return _pokemonRepository.PokemonExist(pokeId);
        }
    }
}
