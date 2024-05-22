using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Add(User user);
        User GetByEmail(string email);
        void DeleteById(Guid id);
        User? GetById(Guid id);
        User Update(User user);

    }
}
