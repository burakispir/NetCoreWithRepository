using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreWithRepository.Data.Entities
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
