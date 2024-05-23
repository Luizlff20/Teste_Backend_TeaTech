using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend_TeaTech.Models
{
    [Table("child_assisteds")]
    public class ChildAssisted
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("name")]
        [StringLength(100)]
        public string? Name { get;  set; }

        [Column("birth_date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get;  set; }

        [Column("food_selectivity")]
        [StringLength(100)]
        public string? FoodSelectivity { get;  set; }

        [Column("aversions")]
        [StringLength(100)]
        public string? Aversions { get;  set; }

        [Column("preferences")]
        [StringLength(100)]
        public string? Preferences { get;  set; }

        [Column("medical_record")]
        [StringLength(100)]
        public string? MedicalRecord { get;  set; }

        [ForeignKey("fk_responsible_id")]
        public Responsible? Responsible { get; set; }

        [Column("photo")]
        [StringLength(100)]
        public string? Photo { get;  set; }

        public ChildAssisted()
        {

        }
        public ChildAssisted(string name, DateTime birthDate, string foodSelectivity, string aversions, string preferences, string medicalRecord, string photo, Responsible responsible)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.FoodSelectivity = foodSelectivity;
            this.Aversions = aversions;
            this.Preferences = preferences;
            this.MedicalRecord = medicalRecord;
            this.Photo = photo;
            this.Responsible = responsible;
        }
    }
}
