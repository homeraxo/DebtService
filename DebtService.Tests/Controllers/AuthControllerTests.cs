using System.Threading.Tasks;
using DebtService.Controllers;
using DebtService.DTOs;
using DebtService.Models;
using DebtService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace DebtService.Tests.Controllers
{
    public class AuthControllerTests
    {
        [Fact]
        public async Task Login_UserNotFound_ReturnsUnauthorized()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var configurationMock = new Mock<IConfiguration>();

            //userServiceMock
            //    .Setup(service => service.GetByEmailAsync(It.IsAny<string>()))
            //    .ReturnsAsync((User?)null);
            userServiceMock
                .Setup(service => service.GetByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult<User?>(null));

            var controller = new AuthController(userServiceMock.Object, configurationMock.Object);

            var loginRequest = new LoginRequestDto { Email = "test@example.com" };

            // Act
            var result = await controller.Login(loginRequest);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal("Usuario no encontrado", unauthorizedResult.Value);
        }

        [Fact]
        public async Task Login_ValidUser_ReturnsToken()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var configurationMock = new Mock<IConfiguration>();

            var user = new User
            {
                UserId = 1,
                Email = "test@example.com",
                Fullname = "Test User"
            };

            //userServiceMock
            //    .Setup(service => service.GetByEmailAsync(It.IsAny<string>()))
            //    .ReturnsAsync(user);
            userServiceMock
                   .Setup(service => service.GetByEmailAsync(It.IsAny<string>()))
                   .Returns(Task.FromResult(user));

            configurationMock
                .Setup(config => config["Jwt:Secret"])
                .Returns("TU_CLAVE_SUPER_SECRETA_LARGA_Y_SEGURA_1234567890!");
            configurationMock
                .Setup(config => config["Jwt:ExpiresInMinutes"])
                .Returns("60");

            var controller = new AuthController(userServiceMock.Object, configurationMock.Object);

            var loginRequest = new LoginRequestDto { Email = "test@example.com" };

            // Act
            var result = await controller.Login(loginRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<LoginResponseDto>(okResult.Value);
            Assert.False(string.IsNullOrEmpty(response.Token));
        }
    }
}
