using Backend_TeaTech.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_TeaTech.Models
{
    [Table("pre_analysiss")]
    public class PreAnalysis
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("proposed_activity")]
        [StringLength(100)]
        public string? ProposedActivity { get; set; }

        [Column("final_duration")]
        [StringLength(50)]
        public string? FinalDuration { get; set; }

        [Column("identified_skill")]
        [StringLength(100)]
        public string? IdentifiedSkills { get; set; }

        [Column("protocol")]
        [StringLength(50)]
        public string? Protocol { get; set; }

        [Column("status_code")]
        [StringLength(20)]
        public StatusCode StatusCode { get; set; }

        [ForeignKey("fk_employee_id")]
        public Employee? Employee { get; set; }

        [ForeignKey("fk_child_assisted_id")]
        public ChildAssisted? ChildAssisted { get; set; }

        public PreAnalysis()
        {
            StatusCode = StatusCode.Pending;
        }

        public PreAnalysis(ChildAssisted childAssisted)
        {
            ChildAssisted = childAssisted;
            StatusCode = StatusCode.Pending;
        }

        public PreAnalysis(string proposedActivity, string finalDuration, string identifiedSkills, string protocol, StatusCode statusCode, Employee? employee, ChildAssisted? childAssisted)
        {
            this.ProposedActivity = proposedActivity;
            this.FinalDuration = finalDuration;
            this.IdentifiedSkills = identifiedSkills;
            this.Protocol = protocol;
            this.StatusCode = statusCode;
            this.Employee = employee;
            this.ChildAssisted = childAssisted;
        }
    }
}
