using FestFlow.Backend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestFlow.Backend.Core.IServices
{
    public interface IJwtService
    {
        Task<string> GenerateToken(User user);
    }
}
