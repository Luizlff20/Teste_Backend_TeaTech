namespace Backend_TeaTech.DTO.Assessments
{
    public class AssessmentRequestDTO
    {
        public string? ChildAssessment { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public AssessmentRequestDTO() { }
        public AssessmentRequestDTO(string? childAssessment)
        {
            ChildAssessment = childAssessment;
        }
    }
}
