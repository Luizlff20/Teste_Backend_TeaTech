using Backend_TeaTech.DTO.Employees;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Backend_Teatech.Test.ServicesTest
{
    public class EmployeeServiceTest
    {
        [Fact]
        public void CreateEmployee_ValidEmployee_ReturnsCreatedEmployee()
        {
            // Arrange
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();

            var employeeToCreate = new Employee();
            var expectedEmployee = new Employee();

            mockEmployeeRepository.Setup(repo => repo.Add(employeeToCreate)).Returns(expectedEmployee);

            var service = new EmployeeService(mockEmployeeRepository.Object);

            // Act
            var createdEmployee = service.CreateEmployee(employeeToCreate);

            // Assert
            Assert.NotNull(createdEmployee);
            Assert.Same(expectedEmployee, createdEmployee);
        }

        [Fact]
        public void DeleteEmployeeById_ExistingId_DeletesEmployee()
        {
            // Arrange
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            var existingEmployee = new Employee();
            mockEmployeeRepository.Setup(repo => repo.GetByID(existingEmployee.Id)).Returns(existingEmployee);
            mockEmployeeRepository.Setup(repo => repo.DeleteByID(existingEmployee.Id));
            var service = new EmployeeService(mockEmployeeRepository.Object);

            // Act & Assert
            service.DeleteEmployeeById(existingEmployee.Id);

            // Assert
            mockEmployeeRepository.Verify(repo => repo.DeleteByID(existingEmployee.Id), Times.Once);
        }

        [Fact]
        public void GetEmployeeById_ValidId_ReturnsEmployeeDTO()
        {
            // Arrange
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            var employeeId = Guid.NewGuid();
            var expectedEmployee = new Employee
            {
                Id = employeeId,
                User = new User() // Populando a propriedade User para evitar NullReferenceException
            };
            mockEmployeeRepository.Setup(repo => repo.GetByID(employeeId)).Returns(expectedEmployee);
            var service = new EmployeeService(mockEmployeeRepository.Object);

            // Act
            var result = service.GetEmployeeById(employeeId);

            // Assert
            Assert.NotNull(result);
            // Add more assertions as needed
        }


        [Fact]
        public void ListAllEmployee_ReturnsListOfEmployeeDTO()
        {
            // Arrange
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            var employees = new List<Employee>
            {
            new Employee { User = new User() }, // Populando a propriedade User para evitar NullReferenceException
            new Employee { User = new User() }  // Populando a propriedade User para evitar NullReferenceException
            };
            mockEmployeeRepository.Setup(repo => repo.GetAll()).Returns(employees);
            var service = new EmployeeService(mockEmployeeRepository.Object);

            // Act
            var result = service.ListAllEmployee();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(employees.Count, result.Count);
            // Add more assertions as needed
        }


        [Fact]
        public void ListAllEmployeeApplicatores_ReturnsListOfEmployeeApplicatoresDTO()
        {
            // Arrange
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            var employeesApplicatores = new List<Employee> { new Employee(), new Employee() };
            mockEmployeeRepository.Setup(repo => repo.GetAllApplicatores()).Returns(employeesApplicatores);
            var service = new EmployeeService(mockEmployeeRepository.Object);

            // Act
            var result = service.ListAllEmployeeApplicatores();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(employeesApplicatores.Count, result.Count);
            
        }
    }
}
