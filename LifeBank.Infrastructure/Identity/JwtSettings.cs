using System;

namespace LifeBank.Infrastructure.Identity
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}
