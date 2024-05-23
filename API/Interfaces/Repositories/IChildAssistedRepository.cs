using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Repositories
{
    public interface IChildAssistedRepository
    {
        ChildAssisted Add(ChildAssisted childAssisted);
        List<ChildAssisted> GetAll();
        void DeleteById(Guid id);
        ChildAssisted? GetById(Guid id);
        ChildAssisted Update(ChildAssisted childAssisted);
        int CountAllChildAssisted();
        List<ChildAssisted> GetByData(string data, int pageNumber, int pageSize, string orderBy, string orderDirection);
        ChildAssisted GetChildByResponsibleId(Guid responsibleId);
    }
}
