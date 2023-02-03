using System.ComponentModel.DataAnnotations;

namespace Param_.Net_Practicum.Core.Applicaiton.Dtos
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
