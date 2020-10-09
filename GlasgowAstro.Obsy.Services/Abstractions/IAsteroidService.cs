using GlasgowAstro.Obsy.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Services.Abstractions
{
    public interface IAsteroidService
    {
        Task<AsteroidResponse> FindAsteroidByNameAsync(string name);
    }
}
