using NetCoreWithRepository.Data.Entities;

namespace NetCoreWithRepository.Data.Model.Request
{
    public class CategoryRequestModel:BaseEntity
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
    }
}
