using Backend_TeaTech.DTO.ProgramAssisteds;
using Backend_TeaTech.Enum;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Services;
using Moq;
using System;
using Xunit;

namespace Backend_TeaTech.Test.ServicesTest
{
    public class ProgramAssistedServiceTest
    {
        [Fact]
        public void CreateProgram_ValidProgram_ReturnsProgram()
        {
            // Arrange
            var mockProgramRepository = new Mock<IProgramAssistedRepository>();
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            var programAssistedService = new ProgramAssistedService(mockProgramRepository.Object, mockEmployeeRepository.Object);
            var programToAdd = new ProgramAssisted();

            // Setup mock repository to return a valid ProgramAssisted instance when Add is called
            mockProgramRepository.Setup(repo => repo.Add(It.IsAny<ProgramAssisted>())).Returns(programToAdd);

            // Act
            var result = programAssistedService.CreateProgram(programToAdd);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ProgramAssisted>(result);
        }

        [Fact]
        public void UpdateProgram_ValidProgram_ReturnsUpdatedProgram()
        {
            // Arrange
            var mockProgramRepository = new Mock<IProgramAssistedRepository>();
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            var programAssistedService = new ProgramAssistedService(mockProgramRepository.Object, mockEmployeeRepository.Object);
            var programId = Guid.NewGuid();
            var programRequest = new ProgramRequestDTO();
            var userId = Guid.NewGuid();
            var existingProgram = new ProgramAssisted { Id = programId };
            var existingEmployeeApplicador = new Employee { Id = programRequest.idApplicator, OccupationType = Enum.OccupationType.Applicator };
            var existingEmployee = new Employee { Id = userId };

            mockProgramRepository.Setup(repo => repo.GetById(programId)).Returns(existingProgram);
            mockEmployeeRepository.Setup(repo => repo.GetByID(programRequest.idApplicator)).Returns(existingEmployeeApplicador);
            mockEmployeeRepository.Setup(repo => repo.GetByIdUser(userId)).Returns(existingEmployee);

            // Act
            var result = programAssistedService.UpdateProgram(programId, programRequest, userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(existingProgram, result);
            Assert.Equal(StatusCode.Completed, result.StatusCode);
            mockProgramRepository.Verify(repo => repo.Update(existingProgram), Times.Once);
        }
    }
}
