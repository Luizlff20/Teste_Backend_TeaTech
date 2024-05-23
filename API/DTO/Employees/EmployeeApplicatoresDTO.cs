namespace Backend_TeaTech.DTO.Employees
{
    public class EmployeeApplicatoresDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public EmployeeApplicatoresDTO() { }
        public EmployeeApplicatoresDTO(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
