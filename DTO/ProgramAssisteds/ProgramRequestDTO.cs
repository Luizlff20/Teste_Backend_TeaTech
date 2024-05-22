using Backend_TeaTech.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend_TeaTech.DTO.ProgramAssisteds
{
    public class ProgramRequestDTO
    {
        public string ActivityDescription { get; set; }
        public string StimuliUsed { get; set; }
        public Guid idApplicator { get; set; }
        public ProtocolType ProtocolType { get; set; }
        public ProgramType ProgramType { get; set; }
        public ProgramRequestDTO() { }
        public ProgramRequestDTO(string activityDescription, string stimuliUsed, Guid idApplicator, ProtocolType protocolType, ProgramType programType)
        {
            ActivityDescription = activityDescription;
            StimuliUsed = stimuliUsed;
            this.idApplicator = idApplicator;
            ProtocolType = protocolType;
            ProgramType = programType;
        }
    }
}
