using System.ComponentModel.DataAnnotations.Schema;

namespace Demo2.Entity
{
    [Table("Owner")]
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gym { get; set; }

        public Region Region { get; set; }

        public ICollection<PokemonOwners> PokemonOwners { get; set; }
    }


}
