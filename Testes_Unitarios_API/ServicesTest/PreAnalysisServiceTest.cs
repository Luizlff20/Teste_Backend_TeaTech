using Backend_TeaTech.DTO.ChildAssisteds;
using Backend_TeaTech.DTO.Employees;
using Backend_TeaTech.DTO.PreAnalysiss;
using Backend_TeaTech.Enum;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Models;
using Backend_TeaTech.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Backend_TeaTech.Test.ServicesTest
{
    public class PreAnalysisServiceTest
    {
        [Fact]
        public void CreatePreAnalysis_ValidPreAnalysis_ReturnsPreAnalysis()
        {
            // Arrange
            var mockPreAnalysisRepository = new Mock<IPreAnalysisRepository>();
            var preAnalysisService = new PreAnalysisService(mockPreAnalysisRepository.Object, null);
            var preAnalysisToAdd = new PreAnalysis();

            // Setup mock repository to return a valid PreAnalysis instance when Add is called
            mockPreAnalysisRepository.Setup(repo => repo.Add(It.IsAny<PreAnalysis>())).Returns(preAnalysisToAdd);

            // Act
            var result = preAnalysisService.CreatePreAnalysis(preAnalysisToAdd);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PreAnalysis>(result);
        }


        [Fact]
        public void UpdatePreAnalysis_ValidPreAnalysis_ReturnsUpdatedPreAnalysis()
        {
            // Arrange
            var mockPreAnalysisRepository = new Mock<IPreAnalysisRepository>();
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            var preAnalysisService = new PreAnalysisService(mockPreAnalysisRepository.Object, mockEmployeeRepository.Object);
            var preAnalysisId = Guid.NewGuid();
            var preAnalysisRequest = new PreAnalysisRequestDTO();
            var employeeId = Guid.NewGuid();
            var existingPreAnalysis = new PreAnalysis { Id = preAnalysisId };
            var existingEmployee = new Employee { Id = employeeId };

            mockPreAnalysisRepository.Setup(repo => repo.GetById(preAnalysisId)).Returns(existingPreAnalysis);
            mockEmployeeRepository.Setup(repo => repo.GetByIdUser(employeeId)).Returns(existingEmployee);

            // Act
            var result = preAnalysisService.UpdatePreAnalysis(preAnalysisId, preAnalysisRequest, employeeId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(existingPreAnalysis, result);
            Assert.Equal(StatusCode.Completed, result.StatusCode);
            mockPreAnalysisRepository.Verify(repo => repo.Update(existingPreAnalysis), Times.Once);
        }

        [Fact]
        public void DeletePreAnalysisById_ExistingPreAnalysis_DeletesPreAnalysis()
        {
            // Arrange
            var mockPreAnalysisRepository = new Mock<IPreAnalysisRepository>();
            var preAnalysisService = new PreAnalysisService(mockPreAnalysisRepository.Object, null);
            var preAnalysisId = Guid.NewGuid();
            var existingPreAnalysis = new PreAnalysis { Id = preAnalysisId };

            mockPreAnalysisRepository.Setup(repo => repo.GetById(preAnalysisId)).Returns(existingPreAnalysis);

            // Act
            preAnalysisService.DeletePreAnalysisById(preAnalysisId);

            // Assert
            mockPreAnalysisRepository.Verify(repo => repo.DeleteById(preAnalysisId), Times.Once);
        }

        [Fact]
        public void GetPreAnalysisById_ExistingPreAnalysis_ReturnsPreAnalysisDTO()
        {
            // Arrange
            var mockPreAnalysisRepository = new Mock<IPreAnalysisRepository>();
            var mockEmployeeRepository = new Mock<IEmployeeRepository>(); // Adicione um mock para IEmployeeRepository
            var preAnalysisService = new PreAnalysisService(mockPreAnalysisRepository.Object, mockEmployeeRepository.Object);
            var preAnalysisId = Guid.NewGuid();
            var existingPreAnalysis = new PreAnalysis
            {
                Id = preAnalysisId,
                ProposedActivity = "Test Activity",
                FinalDuration = "10", // Corrigido para "10" de acordo com o tipo de dados
                IdentifiedSkills = "Test Skills",
                Protocol = "Test Protocol",
                StatusCode = StatusCode.Pending,
                Employee = new Employee { Id = Guid.NewGuid(), Name = "Test Employee" },
                ChildAssisted = new ChildAssisted
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Child",
                    Responsible = new Responsible
                    {
                        ContactOne = "123456789",
                        User = new User { Email = "test@example.com" } // Corrigido para atribuir o email corretamente
                    }
                }
            };

            mockPreAnalysisRepository.Setup(repo => repo.GetById(preAnalysisId)).Returns(existingPreAnalysis);
            // Configurar o mock para o EmployeeRepository
            mockEmployeeRepository.Setup(repo => repo.GetByIdUser(It.IsAny<Guid>())).Returns(existingPreAnalysis.Employee);

            // Act
            var result = preAnalysisService.GetPreAnalysisById(preAnalysisId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PreAnalysisDTO>(result);
            Assert.Equal(existingPreAnalysis.Id, result.Id);
            Assert.Equal(existingPreAnalysis.ProposedActivity, result.ProposedActivity);
            Assert.Equal(existingPreAnalysis.FinalDuration, result.FinalDuration);
            Assert.Equal(existingPreAnalysis.IdentifiedSkills, result.IdentifiedSkills);
            Assert.Equal(existingPreAnalysis.Protocol, result.Protocol);
            Assert.Equal(existingPreAnalysis.StatusCode, result.StatusCode);
            Assert.NotNull(result.Employee);
            Assert.Equal(existingPreAnalysis.Employee.Id, result.Employee.Id);
            Assert.NotNull(result.ChildAssisted);
            Assert.Equal(existingPreAnalysis.ChildAssisted.Id, result.ChildAssisted.Id);
            Assert.Equal(existingPreAnalysis.ChildAssisted.Responsible.ContactOne, result.ChildAssisted.Contact);
            Assert.Equal(existingPreAnalysis.ChildAssisted.Responsible.User.Email, result.ChildAssisted.Email);
        }


    }

}
