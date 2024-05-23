using Backend_TeaTech.DTO.ChildAssisteds;
using Backend_TeaTech.DTO.Employees;
using Backend_TeaTech.Models;
using Backend_TeaTech.Enum;

namespace Backend_TeaTech.DTO.PreAnalysiss
{
    public class PreAnalysisDTO
    {
        public Guid Id { get; set; }
        public string ProposedActivity { get; set; }
        public string FinalDuration { get; set; }
        public string IdentifiedSkills { get; set; }
        public string Protocol { get; set; }
        public StatusCode StatusCode { get; set; }
        public EmployeeDTO Employee { get; set; }
        public ChildAssistedDTO ChildAssisted { get; set; }
        public PreAnalysisDTO() { }

        public PreAnalysisDTO(Guid id, string proposedActivity, string finalDuration, string identifiedSkills, string protocol, StatusCode statusCode, EmployeeDTO employee, ChildAssistedDTO childAssisted)
        {
            Id = id;
            ProposedActivity = proposedActivity;
            FinalDuration = finalDuration;
            IdentifiedSkills = identifiedSkills;
            Protocol = protocol;
            StatusCode = statusCode;
            Employee = employee;
            ChildAssisted = childAssisted;
        }
    }
}
