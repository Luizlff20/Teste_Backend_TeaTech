using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend_TeaTech.Models
{
    [Table("responsibles")]
    public class Responsible
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("name_responsible_one")]
        [StringLength(100)]
        public string? NameResponsibleOne { get; set; }

        [Column("responsible_kinship_one")]
        [StringLength(10)]
        public string? ResponsibleKinshipOne { get; set; }

        [Column("responsible_cpf_one")]
        [StringLength(20)]
        public string? ResponsibleCpfOne { get;  set; }

        [Column("name_responsible_two")]
        [StringLength(100)]
        public string? NameResponsibleTwo { get;  set; }

        [Column("responsible_kinship_two")]
        [StringLength(10)]
        public string? ResponsibleKinshipTwo { get;  set; }

        [Column("resposible_cpf_two")]
        [StringLength(20)]
        public string? ResponsibleCpfTwo { get;  set; }

        [Column("contact_one")]
        [StringLength(20)]
        public string? ContactOne { get; set; }

        [Column("contact_two")]
        [StringLength(20)]
        public string? ContactTwo { get; set; }

        [ForeignKey("fk_user_id")]
        public User? User { get; set; }

        public Responsible(string nameResponsibleOne, string responsibleKinshipOne, string responsibleCpfOne, string nameResponsibleTwo, string responsibleKinshipTwo, string responsibleCpfTwo, string contactOne, string contactTwo ,User userResponsible)
        {
            this.NameResponsibleOne = nameResponsibleOne;
            this.ResponsibleKinshipOne = responsibleKinshipOne;
            this.ResponsibleCpfOne = responsibleCpfOne;
            this.NameResponsibleTwo = nameResponsibleTwo;
            this.ResponsibleKinshipTwo = responsibleKinshipTwo;
            this.ResponsibleCpfTwo = responsibleCpfTwo;
            this.ContactOne = contactOne;
            this.ContactTwo = contactTwo;
            this.User = userResponsible;
        }

        public Responsible()
        {
        }

    }
}
