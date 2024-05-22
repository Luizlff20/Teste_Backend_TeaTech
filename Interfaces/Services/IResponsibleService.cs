
using Backend_TeaTech.DTO.Responsibles;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Services
{
    public interface IResponsibleService
    {
        Responsible CreateResponsible(Responsible responsible);
        List<ResponsibleDTO> ListAllResponsible();
        void DeleteResponsibleById(Guid id);
        ResponsibleDTO GetResponsibleById(Guid id);
    }
}
