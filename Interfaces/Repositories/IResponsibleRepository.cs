using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Repositories
{
    public interface IResponsibleRepository
    {
        Responsible Add(Responsible responsible);
        List<Responsible> GetAll();
        void DeleteById(Guid id);
        Responsible? GetById(Guid id);
        Responsible Update(Responsible responsible);
        Responsible GetByIdUser(Guid id);
    }
}
