using Demo2.Entity;

namespace Demo2.Models.ResponseModel
{
    public class OwnerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gym { get; set; }

        public Region Region { get; set; }
    }
}
