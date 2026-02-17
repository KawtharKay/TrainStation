using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts.Settings
{
    public class JwtSettings
    {
        public string SecreteKey { get; set; } = default!;
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public int ExpiryMinute { get; set; }
    }
}
