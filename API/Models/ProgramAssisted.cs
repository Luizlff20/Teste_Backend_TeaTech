using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Backend_TeaTech.Enum;

namespace Backend_TeaTech.Models
{
    [Table("programs")]
    public class ProgramAssisted
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("activity_description")]
        [StringLength(100)]
        public string? ActivityDescription { get; set; }

        [Column("stimuli_used")]
        [StringLength(100)]
        public string? StimuliUsed { get; set; }

        [Column("protocol_type")]
        [StringLength(20)]
        public ProtocolType? ProtocolType { get; set; }

        [Column("program_type")]
        [StringLength(20)]
        public ProgramType? ProgramType { get; set; }

        [Column("status_code")]
        [StringLength(20)]
        public StatusCode StatusCode { get; set; }

        [ForeignKey("fk_child_assisted_id")]
        public ChildAssisted? ChildAssisted { get; set; }

        [ForeignKey("fk_employee_id")]
        public Employee? Employee { get; set; }

        public ProgramAssisted()
        {
            StatusCode = StatusCode.Pending;
        }

        public ProgramAssisted(ChildAssisted childAssisted)
        {
            ChildAssisted = childAssisted;
            StatusCode = StatusCode.Pending;
        }

        public ProgramAssisted(Guid id, string activityDescription, string stimuliUsed, ProtocolType protocolType, ProgramType programType, StatusCode statusCode, ChildAssisted? childAssisted, Employee? employee)
        {
            Id = id;
            ActivityDescription = activityDescription;
            StimuliUsed = stimuliUsed;
            ProtocolType = protocolType;
            ProgramType = programType;
            StatusCode = statusCode;
            ChildAssisted = childAssisted;
            Employee = employee;
        }
    }
}
