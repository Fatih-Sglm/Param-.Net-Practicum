namespace Param_.Net_Practicum.Core.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
