using Backend_TeaTech.DTO.Users;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
