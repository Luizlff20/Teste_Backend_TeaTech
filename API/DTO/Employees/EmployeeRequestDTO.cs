using Backend_TeaTech.Enum;

namespace Backend_TeaTech.DTO.Employees
{
    public class EmployeeRequestDTO
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public OccupationType OccupationType { get; set; }
        public EmployeeRequestDTO() { }
        public EmployeeRequestDTO(string name, string cpf, string email, OccupationType occupationType)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            OccupationType = occupationType;
        }
    }
}
