using Backend_TeaTech.DTO.Users;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend_TeaTech.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IChildAssistedRepository _childAssistedRepository;
        private readonly IResponsibleRepository _responsibleRepository;
        public JwtService(IConfiguration configuration, IEmployeeRepository employeeRepository, IChildAssistedRepository childAssistedRepository, IResponsibleRepository responsibleRepository)
        {
            _configuration = configuration;
            _employeeRepository = employeeRepository;
            _childAssistedRepository = childAssistedRepository;
            _responsibleRepository = responsibleRepository;
        }

        public string GenerateToken(User user)
        {
            string role = string.Empty;
            Guid childId = Guid.Empty;
            List<Claim> claims = [new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())];
            if (user.UserType == Enum.UserType.Employee) {

                Employee employee = _employeeRepository.GetByIdUser(user.Id);
                role = $"{Enum.UserType.Employee.ToString()}:{employee.OccupationType.ToString()}";
                claims.Add(new Claim(ClaimTypes.Role, role));

            }
            else if(user.UserType == Enum.UserType.Responsible)
            {
                Responsible responsible = _responsibleRepository.GetByIdUser(user.Id);
                ChildAssisted childAssisted = _childAssistedRepository.GetChildByResponsibleId(responsible.Id);
                if (childAssisted != null)
                {
                    childId = childAssisted.Id;
                    role = Enum.UserType.Responsible.ToString();
                    claims.Add(new Claim("ChildId", childId.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }              
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"] ?? string.Empty));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            return token;
        }
    }
}
