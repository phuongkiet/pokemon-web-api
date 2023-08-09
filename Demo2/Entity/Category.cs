using System.ComponentModel.DataAnnotations.Schema;

namespace Demo2.Entity
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PokemonCategories> PokemonCategories { get; set; }
    }
}
