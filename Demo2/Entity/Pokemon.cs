using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo2.Entity
{
    [Table("Pokemon")]
    public class Pokemon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public bool IsShiny { get; set; }
        public ICollection<PokemonOwners> PokemonOwners { get; set; }
        public ICollection<PokemonCategories> PokemonCategories { get; set; }
    }
}
