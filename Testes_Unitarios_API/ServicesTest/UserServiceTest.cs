using Xunit;
using Moq;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Services;
using Backend_TeaTech.Models;
using System;
using System.Collections.Generic;

namespace Backend_TeaTech.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public void CreateUserResponsible_UserDoesNotExist_ReturnsCreatedUser()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var jwtServiceMock = new Mock<IJwtService>();
            var userService = new UserService(userRepositoryMock.Object, jwtServiceMock.Object);
            var newUser = new User { Email = "newuser@example.com", Password = "password" };
            userRepositoryMock.Setup(repo => repo.GetByEmail(newUser.Email)).Returns((User)null);
            userRepositoryMock.Setup(repo => repo.Add(newUser)).Returns(newUser);

            // Act
            var createdUser = userService.CreateUserResponsible(newUser);

            // Assert
            Assert.NotNull(createdUser);
            Assert.Equal(Enum.UserType.Responsible, createdUser.UserType);
            // Add more assertions if needed...
        }

        [Fact]
        public void CreateUserResponsible_UserExists_ThrowsException()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var jwtServiceMock = new Mock<IJwtService>();
            var userService = new UserService(userRepositoryMock.Object, jwtServiceMock.Object);
            var existingUser = new User { Email = "existinguser@example.com", Password = "password" };
            userRepositoryMock.Setup(repo => repo.GetByEmail(existingUser.Email)).Returns(existingUser);

            // Act & Assert
            Assert.Throws<Exception>(() => userService.CreateUserResponsible(existingUser));
        }

        // Add more test cases for CreateUserEmployee, ListAllUser, Login, DeleteUserById, GetUserById methods...

    }
}
