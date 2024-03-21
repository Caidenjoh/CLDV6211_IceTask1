using System.ComponentModel.DataAnnotations;

namespace PartyOutfitRental.Models
{
    public class PartyOutfit
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Size { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public bool Availability { get; set; } = true;
    }
}
