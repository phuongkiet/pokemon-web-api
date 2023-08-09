using System.ComponentModel.DataAnnotations.Schema;

namespace Demo2.Entity
{
    [Table("PokemonCategories")]
    public class PokemonCategories
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Category Category { get; set; }
    }
}
