using Backend_TeaTech.DTO.Responsibles;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Backend_TeaTech.Test.ServicesTest
{
    public class ResponsibleServiceTest
    {
        [Fact]
        public void CreateResponsible_ValidResponsible_ReturnsResponsible()
        {
            // Arrange
            var mockResponsibleRepository = new Mock<IResponsibleRepository>();
            var responsibleService = new ResponsibleService(mockResponsibleRepository.Object);
            var responsibleToAdd = new Responsible();

            // Setup mock repository to return a valid Responsible instance when Add is called
            mockResponsibleRepository.Setup(repo => repo.Add(It.IsAny<Responsible>())).Returns(responsibleToAdd);

            // Act
            var result = responsibleService.CreateResponsible(responsibleToAdd);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Responsible>(result);
        }

        [Fact]
        public void DeleteResponsibleById_ExistingResponsible_DeletesResponsible()
        {
            // Arrange
            var mockResponsibleRepository = new Mock<IResponsibleRepository>();
            var responsibleService = new ResponsibleService(mockResponsibleRepository.Object);
            var responsibleId = Guid.NewGuid();
            var existingResponsible = new Responsible { Id = responsibleId };

            mockResponsibleRepository.Setup(repo => repo.GetById(responsibleId)).Returns(existingResponsible);

            // Act
            responsibleService.DeleteResponsibleById(responsibleId);

            // Assert
            mockResponsibleRepository.Verify(repo => repo.DeleteById(responsibleId), Times.Once);
        }

        [Fact]
        public void GetResponsibleById_ExistingResponsible_ReturnsResponsibleDTO()
        {
            // Arrange
            var mockResponsibleRepository = new Mock<IResponsibleRepository>();
            var responsibleService = new ResponsibleService(mockResponsibleRepository.Object);
            var responsibleId = Guid.NewGuid();
            var existingResponsible = new Responsible
            {
                Id = responsibleId,
                NameResponsibleOne = "Test Responsible",
                // Fill other properties as needed
            };

            mockResponsibleRepository.Setup(repo => repo.GetById(responsibleId)).Returns(existingResponsible);

            // Act
            var result = responsibleService.GetResponsibleById(responsibleId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ResponsibleDTO>(result);
            Assert.Equal(existingResponsible.Id, result.Id);
            Assert.Equal(existingResponsible.NameResponsibleOne, result.NameResponsibleOne);
            // Assert other properties as needed
        }

        // Add more test methods as needed for other functionalities
    }
}
