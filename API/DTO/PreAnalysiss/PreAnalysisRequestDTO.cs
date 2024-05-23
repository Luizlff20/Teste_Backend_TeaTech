using Backend_TeaTech.Enum;

namespace Backend_TeaTech.DTO.PreAnalysiss
{
    public class PreAnalysisRequestDTO
    {
        public string ProposedActivity { get; set; }
        public string FinalDuration { get; set; }
        public string IdentifiedSkills { get; set; }
        public string Protocol { get; set; }
        public PreAnalysisRequestDTO() { }
        public PreAnalysisRequestDTO(string proposedActivity, string finalDuration, string identifiedSkills, string protocol)
        {
            ProposedActivity = proposedActivity;
            FinalDuration = finalDuration;
            IdentifiedSkills = identifiedSkills;
            Protocol = protocol; 
        }
    }
}
