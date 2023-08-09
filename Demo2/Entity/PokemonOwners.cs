using System.ComponentModel.DataAnnotations.Schema;

namespace Demo2.Entity
{
    [Table("PokemonOwners")]
    public class PokemonOwners
    {
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Owner Owner { get; set; }

    }
}
