using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Repositories
{
    public interface IAssessmentRepository
    {
        Assessment Add(Assessment assessment);
        Assessment Update(Assessment assessment);
        void DeleteById(Guid id);
        Assessment GetById(Guid id);
        List<Assessment> GetAll();
        Assessment? GetByChildAssistedId(Guid id);
    }
}
