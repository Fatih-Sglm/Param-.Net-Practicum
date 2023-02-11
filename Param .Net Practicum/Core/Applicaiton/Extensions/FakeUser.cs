using Param_.Net_Practicum.Core.Domain.Entities;

namespace Param_.Net_Practicum.Core.Applicaiton.Extensions
{
    /// <summary>
    /// Fake User Creator Class
    /// </summary>
    public static class FakeUser
    {
        public static User user = new() { UserName = "User1", Name = "Fatih", SurName = "SAĞLAM", Password = "user123" };
    }

    public static class TokenDto
    {
        public static string? Token;
        public static DateTime ExpireDate = DateTime.Now.AddMinutes(5);
    }
}
