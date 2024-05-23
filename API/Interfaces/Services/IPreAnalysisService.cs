using Backend_TeaTech.DTO.PreAnalysiss;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Services
{
    public interface IPreAnalysisService
    {
        PreAnalysis CreatePreAnalysis (PreAnalysis preAnalysis);
        PreAnalysis UpdatePreAnalysis (Guid id, PreAnalysisRequestDTO preAnalysis, Guid employeeId);
        void DeletePreAnalysisById (Guid id);
        List<PreAnalysisDTO> ListAllPreAnalysis();
        PreAnalysisDTO GetPreAnalysisById (Guid id);

    }
}
