using AutoMapper;
using Demo2.Entity;
using Demo2.Interfaces;
using Demo2.Models.RequestModel;
using Demo2.Models.ResponseModel;
using Demo2.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Demo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPokemonService _pokemonService;
        public PokemonController(IPokemonService pokemonService, IMapper mapper)
        {
            _pokemonService = pokemonService;
            _mapper = mapper;
        }

        [HttpGet("pokemons")]
        public async Task<IActionResult> GetPokemons()
        {
            var result = await _pokemonService.GetPokemons();
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<PokemonResponse>>(result));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePokemon([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonCreateRequest pokemonCreate)
        {
            if (pokemonCreate == null)
                return BadRequest(ModelState);

            /*var pokemons = _pokemonRepository.GetPokemonTrimToUpper(pokemonCreate);

            if (pokemons != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }*/

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemonMap = _mapper.Map<Pokemon>(pokemonCreate);


            if (_pokemonService.CreatePokemon(ownerId, catId, pokemonMap).Equals(null))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{pokeId}")]
        public async Task<IActionResult> UpdatePokemon(int pokeId,
            [FromQuery] int ownerId, [FromQuery] int catId,
            [FromBody] PokemonResponse updatedPokemon)
        {
            if (updatedPokemon == null)
                return BadRequest(ModelState);

            if (pokeId != updatedPokemon.Id)
                return BadRequest(ModelState);

            if (!_pokemonService.PokemonExist(pokeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var pokemonMap = _mapper.Map<Pokemon>(updatedPokemon);

            if (_pokemonService.UpdatePokemon(ownerId, catId, pokemonMap).Equals(null))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{pokeId}")]
        public async Task<IActionResult> DeletePokemon(int pokeId)
        {
            if (!_pokemonService.PokemonExist(pokeId))
                return NotFound();

            var pokemonToDelete = await _pokemonService.GetPokemonById(pokeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_pokemonService.DeletePokemon(pokemonToDelete).Equals(null))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
            }

            return NoContent();
        }
    }
}
