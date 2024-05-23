using System;
using Backend_TeaTech.DTO.ChildAssisteds;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Moq;
using Xunit;

namespace Backend_Teatech.Test.ServicesTest
{
    public class ChildAssistedServiceTest
    {
        [Fact]
        public void CreateChild_ValidChild_ReturnsCreatedChild()
        {
            // Arrange
            var mockChildAssistedService = new Mock<IChildAssistedService>();
            var childToCreate = new ChildAssisted();
            var expectedChild = new ChildAssisted();

            mockChildAssistedService.Setup(service => service.CreateChild(It.IsAny<ChildAssisted>())).Returns(expectedChild);

            // Act
            var createdChild = mockChildAssistedService.Object.CreateChild(childToCreate);

            // Assert
            Assert.NotNull(createdChild);
            Assert.Same(expectedChild, createdChild);
        }

        [Fact]
        public void DeleteChildById_ExistingId_DeletesChild()
        {
            // Arrange
            var mockChildAssistedService = new Mock<IChildAssistedService>();
            var childId = Guid.NewGuid();

            mockChildAssistedService.Setup(service => service.DeleteChildById(childId));

            // Act
            mockChildAssistedService.Object.DeleteChildById(childId);

            // Assert
            mockChildAssistedService.Verify(service => service.DeleteChildById(childId), Times.Once);
        }

        [Fact]
        public void FilterByData_ValidData_ReturnsChildAssistedDTO()
        {
            // Arrange
            var mockChildAssistedService = new Mock<IChildAssistedService>();

            mockChildAssistedService.Setup(service => service.FilterByData(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ListChildAssistedDTO());

            // Act
            var result = mockChildAssistedService.Object.FilterByData("2024-01-01", 1, 10, "Name", "Asc");

            // Assert
            Assert.NotNull(result);
            // Add more assertions as needed
        }

        [Fact]
        public void GetChildById_ValidId_ReturnsChildAssistedDTO()
        {
            // Arrange
            var mockChildAssistedService = new Mock<IChildAssistedService>();
            var childId = Guid.NewGuid();

            mockChildAssistedService.Setup(service => service.GetChildById(childId)).Returns(new ChildAssistedDTO());

            // Act
            var result = mockChildAssistedService.Object.GetChildById(childId);

            // Assert
            Assert.NotNull(result);
            // Add more assertions as needed
        }
    }
}
