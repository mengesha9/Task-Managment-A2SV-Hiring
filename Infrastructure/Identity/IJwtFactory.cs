using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entites;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity
{
    public interface IJwtFactory
    {
        Task<SecurityToken> GenerateToken(AppUser user);

    }
}