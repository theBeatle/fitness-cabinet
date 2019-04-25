﻿using System.Security.Claims;
using System.Threading.Tasks;

namespace FitnessApp.Auth
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
        ClaimsIdentity GenerateClaimsIdentity(string userName, int id);
    }
}
