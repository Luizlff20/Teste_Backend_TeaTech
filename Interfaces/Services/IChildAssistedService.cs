using Backend_TeaTech.DTO.ChildAssisteds;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Services
{
    public interface IChildAssistedService
    {
        ChildAssisted CreateChild(ChildAssisted childAssisted);
        void DeleteChildById(Guid id);
        ListChildAssistedDTO FilterByData(string data, int pageNumber, int pageSize, string orderBy, string orderDirection);
        ChildAssistedDTO GetChildById(Guid id);

    }
}
