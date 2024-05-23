using Backend_TeaTech.DTO.Assessments;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Services;
using Moq;
using System;
using Xunit;

namespace Backend_Teatech.Test.ServicesTest
{
    public class AssessmentServiceTest
    {
        [Fact]
        public void CreateAssessment_ValidAssessment_ReturnsCreatedAssessment()
        {
            // Arrange
            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();

            var assessmentToCreate = new Assessment();
            var expectedAssessment = new Assessment();

            mockAssessmentRepository.Setup(repo => repo.Add(It.IsAny<Assessment>())).Returns(expectedAssessment);

            var service = new AssessmentService(mockAssessmentRepository.Object, mockEmployeeRepository.Object);

            // Act
            var createdAssessment = service.CreateAssessment(assessmentToCreate);

            // Assert
            Assert.NotNull(createdAssessment);
            Assert.Same(expectedAssessment, createdAssessment);
        }

        [Fact]
        public void UpdateAssessment_ValidIdAndAssessment_ReturnsUpdatedAssessment()
        {
            // Arrange
            var mockAssessmentRepository = new Mock<IAssessmentRepository>();
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();

            var existingAssessment = new Assessment();
            var updatedAssessmentDto = new AssessmentRequestDTO();
            var employeeId = Guid.NewGuid();

            mockAssessmentRepository.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(existingAssessment);
            mockEmployeeRepository.Setup(repo => repo.GetByIdUser(It.IsAny<Guid>())).Returns(new Employee());

            var service = new AssessmentService(mockAssessmentRepository.Object, mockEmployeeRepository.Object);

            // Act
            var updatedAssessment = service.UpdateAssessment(Guid.NewGuid(), updatedAssessmentDto, employeeId);

            // Assert
            Assert.NotNull(updatedAssessment);
        }
    }
}
