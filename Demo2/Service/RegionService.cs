using AutoMapper;
using Demo2.Entity;
using Demo2.Repository;
using System.Reflection.Metadata.Ecma335;

namespace Demo2.Service
{
    public interface IRegionService
    {
        public Task<ICollection<Region>> GetRegions();
        public Task CreateRegion(Region region);

        public Task UpdateRegion(Region region);

        public Task DeleteRegion(Region region);
        public bool RegionExists(int regionId);
        public Task<Region> GetRegionById(int regionId);
    }
    public class RegionService : IRegionService
    {
        private readonly IMapper _mapper;
        private readonly RegionRepository _regionRepository;

        public RegionService(RegionRepository regionRepository, IMapper mapper) 
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        public async Task CreateRegion(Region region)
        {
            await _regionRepository.Add(region);
        }

        public async Task DeleteRegion(Region region)
        {
            await _regionRepository.Delete(region);
        }

        public async Task<ICollection<Region>> GetRegions()
        {
            var region = await _regionRepository.GetAll();
            return  region.ToList();
        }

        public async Task UpdateRegion(Region region)
        {
            await _regionRepository.Update(region);
        }
        public bool RegionExists(int regionId)
        {
            return _regionRepository.RegionExists(regionId);
        }
        public async Task<Region> GetRegionById(int regionId)
        {
            return await _regionRepository.GetByIntId(regionId);
        }
    }
}
