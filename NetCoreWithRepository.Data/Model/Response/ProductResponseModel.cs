﻿using NetCoreWithRepository.Data.Entities;

namespace NetCoreWithRepository.Data.Model.Response
{
    public class ProductResponseModel:BaseEntity
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public int CategoryId { get; set; }
    }
}
