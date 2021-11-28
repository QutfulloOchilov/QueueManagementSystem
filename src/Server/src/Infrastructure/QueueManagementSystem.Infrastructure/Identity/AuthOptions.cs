namespace QueueManagementSystem.Infrastructure.Identity
{
    public class AuthOptions
    {
        public string TokenAudience { get; set; }
        public int AccessTokenLifeTime { get; set; }
        public string TokenIssuer { get; set; }
    }
}