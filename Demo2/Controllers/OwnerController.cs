﻿using AutoMapper;
using Demo2.Entity;
using Demo2.Models.RequestModel;
using Demo2.Models.ResponseModel;
using Demo2.Repository;
using Demo2.Service;
using Microsoft.AspNetCore.Mvc;

namespace Demo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOwnerService _ownerService;
        private readonly IRegionService _regionService;

        public OwnerController(IOwnerService ownerService, IMapper mapper, IRegionService regionService)
        {
            _ownerService = ownerService;
            _mapper = mapper;
            _regionService = regionService;
        }

        [HttpGet("owners")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public async Task<IActionResult> GetOwners()
        {
            var result = await _ownerService.GetOwners();
            if (!result.Any())
                return NotFound();

            return Ok(_mapper.Map<List<OwnerResponse>>(result));
        }
        [HttpGet("get-pokemons-by-owner")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPokemonByOwner([FromQuery] int ownerId)
        {
            var result = await _ownerService.GetPokemonByOwner(ownerId);
            if(!result.Any())
                return NotFound();
            return Ok(_mapper.Map<List<PokemonResponse>>(result));
        }

        [HttpGet("getOwnersV2")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetOwnersV2()
        {
            var result = await _ownerService.GetOwnersV2();
            if (!result.Any())
                return NotFound();

            return Ok(_mapper.Map<List<OwnerResponse>>(result));
        }

        [HttpGet("getOwnersV3")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetOwnersV3()
        {
            var result = await _ownerService.GetOwnersV3();
            if (!result.Any())
                return NotFound();

            return Ok(_mapper.Map<List<OwnerResponse>>(result));
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateOwner([FromQuery] int regionId, [FromBody] OwnerResponse ownerCreate)
        {
            if (ownerCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ownerMap = _mapper.Map<Owner>(ownerCreate);

/*            ownerMap.Region = await _regionService.GetRegionById(regionId);
*/
            var ownerToCreate = _ownerService.CreateOwner(regionId, ownerMap);

            if (ownerToCreate == null)
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{ownerId}")]
        
        public async Task<IActionResult> UpdateOwner(int ownerId,
            [FromBody] OwnerResponse updatedOwner)
        {
            if (updatedOwner == null)
                return BadRequest(ModelState);

            if (ownerId != updatedOwner.Id)
                return BadRequest(ModelState);

            if (!_ownerService.OwnerExists(ownerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var ownerMap = _mapper.Map<Owner>(updatedOwner);

            if (_ownerService.UpdateOwner(ownerMap).Equals(null))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{ownerId}")]
        public async Task<IActionResult> DeleteOwner(int ownerId)
        {
            if (!_ownerService.OwnerExists(ownerId))
                return NotFound();

            var ownerToDelete = await _ownerService.GetOwnerById(ownerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_ownerService.DeleteOwner(ownerToDelete).Equals(null))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
            }

            return NoContent();
        }
    }
}
