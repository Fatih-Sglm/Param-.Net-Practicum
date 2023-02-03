using System.ComponentModel.DataAnnotations;

namespace Param_.Net_Practicum.Core.Applicaiton.Dtos
{
    public class UpdateProductPriceDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
