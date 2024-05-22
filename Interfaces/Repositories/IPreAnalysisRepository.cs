using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Repositories
{
    public interface IPreAnalysisRepository
    {
        PreAnalysis Add(PreAnalysis preAnalysis);
        PreAnalysis Update(PreAnalysis preAnalysis);
        void DeleteById(Guid id);
        PreAnalysis GetById(Guid id);
        List<PreAnalysis> GetAll();
        PreAnalysis? GetByChildAssistedId(Guid id);

    }
}
