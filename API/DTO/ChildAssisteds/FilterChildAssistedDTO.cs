using Backend_TeaTech.Enum;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.DTO.ChildAssisteds
{
    public class FilterChildAssistedDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
        public StatusCode? PreAnalysisStatusCode { get; set; }
        public Guid? PreAnalysisId { get; set; }

        public FilterChildAssistedDTO() { }
        public FilterChildAssistedDTO(ChildAssisted childAssisted, PreAnalysis? preAnalysis, Responsible responsible)
        {
            Id = childAssisted.Id;
            Name = childAssisted?.Name;
            Email = childAssisted?.Responsible?.User?.Email;
            Contact = childAssisted?.Responsible?.ContactOne;
            PreAnalysisStatusCode = preAnalysis?.StatusCode;
            PreAnalysisId = preAnalysis?.Id;
        }
    }
}
