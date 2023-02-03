using System.ComponentModel.DataAnnotations;

namespace Param_.Net_Practicum.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
    }
}
