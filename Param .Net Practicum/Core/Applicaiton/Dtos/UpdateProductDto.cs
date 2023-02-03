using System.ComponentModel.DataAnnotations;

namespace Param_.Net_Practicum.Core.Applicaiton.Dtos
{
    public class UpdateProductDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
