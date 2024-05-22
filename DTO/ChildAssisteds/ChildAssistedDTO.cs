using Backend_TeaTech.Enum;
using Backend_TeaTech.Models;
using System.Xml.Linq;

namespace Backend_TeaTech.DTO.ChildAssisteds
{
    public class ChildAssistedDTO
    {
            public Guid? Id { get; set; }
            public string? Name { get; set; }
            public string? Email { get; set; }
            public string? Contact { get; set; }
            public string? Photo { get; set; }
            public DateTime? BirthDate { get; set; }
            public string? NameResponsible   { get; set; }
            public string? CpfResponsible { get; set; }
            public string? FoodSelectivity { get; set; }
            public string? Aversions { get; set; }
            public string? Preferences { get; set; }
            public string? ProposedActivity { get; set; }
            public string? IdentifiedSkills { get; set; }
            public string? Protocol { get; set; }
            public string? FinalDuration { get; set; }
            public string? ChildAssessment { get; set; }
            public Guid? AssessmentId { get; set; }
            public Guid? PreAnalysisId { get; set; }
            public StatusCode? PreAnalysisStatusCode { get; set; }

        public ChildAssistedDTO()
        {
        }

        public ChildAssistedDTO(ChildAssisted childAssisted, PreAnalysis? preAnalysis, Responsible? responsible, Assessment? assessment)
        {
            Id = childAssisted?.Id;
            Name = childAssisted?.Name;
            Email = childAssisted?.Responsible?.User?.Email;
            Contact = childAssisted?.Responsible?.ContactOne;
            Photo = childAssisted?.Photo;
            BirthDate = childAssisted?.BirthDate;
            NameResponsible = responsible?.NameResponsibleOne;
            CpfResponsible = responsible?.ResponsibleCpfOne;
            PreAnalysisId = preAnalysis?.Id;
            PreAnalysisStatusCode = preAnalysis?.StatusCode;
            FinalDuration = preAnalysis?.FinalDuration;
            Protocol = preAnalysis?.Protocol;
            IdentifiedSkills = preAnalysis?.IdentifiedSkills;
            ProposedActivity = preAnalysis?.ProposedActivity;
            Aversions = childAssisted?.Aversions;
            Preferences = childAssisted?.Preferences;
            FoodSelectivity = childAssisted?.FoodSelectivity;
            ChildAssessment = assessment?.ChildAssessment;
            AssessmentId = assessment?.Id;
        }

        public ChildAssistedDTO(Guid? id, string? name)
        {
            Id = id;
            Name = name;
        }
    }
}
