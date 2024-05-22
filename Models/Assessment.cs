using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Backend_TeaTech.Enum;

namespace Backend_TeaTech.Models
{
    [Table("assessments")]
    public class Assessment
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("assessment")]
        [StringLength(100)]
        public string? ChildAssessment { get; set; }

        [Column("status_code")]
        [StringLength(20)]
        public StatusCode StatusCode { get; set; }

        [ForeignKey("fk_child_assisted_id")]
        public ChildAssisted? ChildAssisted { get; set; }

        [ForeignKey("fk_employee_id")]
        public Employee? Employee { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Assessment()
        {
            StatusCode = StatusCode.Pending;
        }

        public Assessment(ChildAssisted childAssisted)
        {
            ChildAssisted = childAssisted;
            StatusCode = StatusCode.Pending;
        }

        public Assessment(Guid id, string? childAssessment, StatusCode statusCode, ChildAssisted? childAssisted, Employee? employee)
        {
            Id = id;
            ChildAssessment = childAssessment;
            StatusCode = statusCode;
            ChildAssisted = childAssisted;
            Employee = employee;
        }
    }
}
