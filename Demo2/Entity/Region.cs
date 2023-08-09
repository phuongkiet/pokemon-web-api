using System.ComponentModel.DataAnnotations.Schema;

namespace Demo2.Entity
{
    [Table("Region")]
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
}
