using AutoMapper;
using Demo2.Entity;
using Demo2.Models.RequestModel;
using Demo2.Models.ResponseModel;
using Demo2.Service;
using Microsoft.AspNetCore.Mvc;

namespace Demo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRegionService _regionService;
        public RegionController(IRegionService regionService, IMapper mapper)
        {
            _regionService = regionService;
            _mapper = mapper;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _regionService.GetRegions();
            if (!result.Any())
                return NotFound();

            return Ok(_mapper.Map<List<RegionResponse>>(result));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] RegionResponse regionCreated)
        {
            if (regionCreated == null)
                return BadRequest(ModelState);

            if (_regionService.CreateRegion(_mapper.Map<Region>(regionCreated)).Equals(null))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok("Successfully Added");
        }
        [HttpPut("{regionId}")]
        public async Task<IActionResult> UpdateRegion(int regionId, [FromBody] RegionResponse regionUpdated)
        {
            if (regionUpdated == null)
                return BadRequest(ModelState);

            if (regionId != regionUpdated.Id)
                return BadRequest(ModelState);

            if (!_regionService.RegionExists(regionId))
                return NotFound();

            try
            {
                // Map CategoryUpdateRequest to Category entity
                Region regionToUpdate = _mapper.Map<Region>(regionUpdated);

                // Update the category through the service
                await _regionService.UpdateRegion(regionToUpdate);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }
        [HttpDelete("{regionId}")]
        public async Task<IActionResult> DeleteRegion(int regionId)
        {
            if (!_regionService.RegionExists(regionId))
                return NotFound();

            var categoryToDelete = await _regionService.GetRegionById(regionId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_regionService.DeleteRegion(categoryToDelete).Equals(null))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
            }

            return NoContent();
        }
    }
}
