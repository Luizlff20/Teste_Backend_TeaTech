using Backend_TeaTech.DTO.Assessments;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Services
{
    public interface IAssessmentService
    {
        Assessment CreateAssessment(Assessment assessment);
        Assessment UpdateAssessment(Guid id, AssessmentRequestDTO assessment, Guid employeeId);
    }
}
