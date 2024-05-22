using Backend_TeaTech.DTO.Employees;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Services
{
    public interface IEmployeeService
    {
        Employee CreateEmployee(Employee employee);
        void DeleteEmployeeById(Guid id);
        List<EmployeeDTO> ListAllEmployee();
        EmployeeDTO GetEmployeeById(Guid id);
        List<EmployeeApplicatoresDTO> ListAllEmployeeApplicatores();
    }
}
