using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreWithRepository.Data.Entities
{
    [Table("Categories")]
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
