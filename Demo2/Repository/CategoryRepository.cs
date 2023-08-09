using Demo2.Entity;

namespace Demo2.Repository
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public bool CategoryExists(int id)
        {
            return _context.Category.Any(c => c.Id == id);
        }
    }
}
