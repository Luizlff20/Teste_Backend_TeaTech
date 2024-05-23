using Backend_TeaTech.DTO.Users;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Services
{
    public interface IUserService
    {
        User CreateUserResponsible(User user);
        User CreateUserEmployee(User user);
        string Login(string email, string password);
        List<UserDTO> ListAllUser();
        void DeleteUserById(Guid id);
        UserDTO GetUserById(Guid id);
    }
}

