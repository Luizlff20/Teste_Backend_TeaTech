using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend_TeaTech.Enum;

namespace Backend_TeaTech.Models
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("name")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Column("cpf")]
        [StringLength(100)]
        public string? Cpf { get; set; }

        [Column("occupation_type")]
        [StringLength(20)]
        public OccupationType OccupationType { get; set; }

        [ForeignKey("fk_user_id")]
        public User? User { get; set; }

        public Employee()
        {
        }

        public Employee(string name, string cpf, OccupationType occupationType, User userEmployee)
        {
            this.Name = name;
            this.Cpf = cpf;
            this.OccupationType = occupationType;
            this.User = userEmployee;
        }
    }
}