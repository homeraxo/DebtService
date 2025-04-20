using DebtService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace DebtService.Tests.Controllers
{
    public class HealthControllerTests
    {
        [Fact]
        public void Get_ReturnsOkResultWithExpectedStatus()
        {
            // Arrange
            var controller = new HealthController();

            // Act
            var result = controller.Get() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var responseObj = result.Value;
            var statusProperty = responseObj.GetType().GetProperty("status") ??
                                 responseObj.GetType().GetProperty("Status");

            Assert.NotNull(statusProperty);
            var statusValue = statusProperty.GetValue(responseObj);
            Assert.Equal("Servicio corriendo", statusValue);
        }
    }
}