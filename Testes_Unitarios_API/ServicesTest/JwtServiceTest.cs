using Backend_TeaTech.DTO.Users;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Backend_Teatech.Test.ServicesTest
{
    public class JwtServiceTest
    {
        // Definindo Enum UserType
        public enum UserType
        {
            Employee,
            Responsible
        }

        [Fact]
        public void GenerateToken_EmployeeUser_ReturnsValidToken()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();
            configuration.Setup(c => c["Jwt:SecretKey"]).Returns("mySecretKey123456789012345678901234567890"); // Chave com 40 caracteres, totalizando 320 bits

            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            var mockChildAssistedRepository = new Mock<IChildAssistedRepository>();
            var mockResponsibleRepository = new Mock<IResponsibleRepository>();

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserType = (Backend_TeaTech.Enum.UserType)UserType.Employee // Definindo o UserType como Employee
            };

            var jwtService = new JwtService(configuration.Object, mockEmployeeRepository.Object, mockChildAssistedRepository.Object, mockResponsibleRepository.Object);

            // Act
            var token = jwtService.GenerateToken(user);

            // Assert
            Assert.NotNull(token);

            // Adicione mais asserções conforme necessário
        }



        [Fact]
        public void GenerateToken_ResponsibleUserWithChild_ReturnsValidToken()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();
            configuration.Setup(c => c["Jwt:SecretKey"]).Returns("mySecretKey12345678901234567890123456789012"); // Chave com 42 caracteres, totalizando 336 bits

            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            var mockChildAssistedRepository = new Mock<IChildAssistedRepository>();
            var mockResponsibleRepository = new Mock<IResponsibleRepository>();

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserType = (Backend_TeaTech.Enum.UserType)UserType.Responsible // Definindo o UserType como Responsible
            };

            // Simulando a existência de um responsável e um filho associado a ele
            var responsible = new Responsible
            {
                Id = Guid.NewGuid()
            };

            var childAssisted = new ChildAssisted
            {
                Id = Guid.NewGuid()
            };

            mockResponsibleRepository.Setup(repo => repo.GetByIdUser(user.Id)).Returns(responsible);
            mockChildAssistedRepository.Setup(repo => repo.GetChildByResponsibleId(responsible.Id)).Returns(childAssisted);

            var jwtService = new JwtService(configuration.Object, mockEmployeeRepository.Object, mockChildAssistedRepository.Object, mockResponsibleRepository.Object);

            // Act
            var token = jwtService.GenerateToken(user);

            // Assert
            Assert.NotNull(token);

            // Adicione mais asserções conforme necessário
        }


    }
}
