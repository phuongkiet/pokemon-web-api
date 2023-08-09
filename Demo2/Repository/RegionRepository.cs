using Demo2.Entity;

namespace Demo2.Repository
{
    public class RegionRepository : BaseRepository<Region>
    {
        public bool RegionExists(int id)
        {
            return _context.Region.Any(c => c.Id == id);
        }

        public async Task<Region> GetRegion(int id)
        {
            return  _context.Region.Where(r => r.Id == id).FirstOrDefault();
        }
    }
}
