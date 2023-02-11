﻿using System.ComponentModel.DataAnnotations;

namespace Param_.Net_Practicum.Core.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
