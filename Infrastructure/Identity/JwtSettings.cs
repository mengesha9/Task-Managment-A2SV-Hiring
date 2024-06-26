using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class JwtSettings
    {
        public string Issuer { get; set; } = "";

        public string Audience { get; set; } = "";

        public string Key { get; set; } = "";

        public int DurationInMinutes { get; set; }
    }
}