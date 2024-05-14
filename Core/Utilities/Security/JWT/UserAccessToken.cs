using System;

namespace Core.Utilities.Security.JWT
{
    public class UserAccessToken
    {
        public string? UserId { get; set; }
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
