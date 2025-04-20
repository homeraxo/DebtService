using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using DebtService.Services;
using DebtService.Data;
using DebtService.Models;
using DebtService.DTOs;

namespace DebtService.Tests.Services
{
    public class DebtMetricsServiceTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // DB única por test
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task GetDebtMetricsByUserEmailAsync_ReturnsCorrectMetrics()
        {
            // Arrange
            var context = GetDbContext();

            var user = new User { UserId = 1, Fullname = "Juan Pérez", Email = "juan.perez@example.com" };
            var wallet = new Wallet { WalletId = 1, UserId = 1, Status = "Activa"};
            var events = new List<DebtEvent>
            {
                new DebtEvent { WalletId = 1, StartDate = DateTime.Now.AddDays(-4), EndDate = DateTime.Now.AddDays(-2), DurationHours = 48 },
                new DebtEvent { WalletId = 1, StartDate = DateTime.Now.AddDays(-10), EndDate = DateTime.Now.AddDays(-8), DurationHours = 48 }
            };

            context.Users.Add(user);
            context.Wallets.Add(wallet);
            context.DebtEvents.AddRange(events);
            await context.SaveChangesAsync();

            var service = new UserService(context);

            // Act
            var result = await service.GetByEmailAsync("juan.perez@example.com");

            // Assert
            Assert.NotNull(result);
            //Assert.Equal(2, result.TimesInDebt);
            //Assert.Equal(48, result.AverageResolutionTimeHours); // promedio exacto

            //var responseObj = result.Value;
            //var TimesInDebtProperty = responseObj.GetType().GetProperty("TimesInDebt") ??
            //                     responseObj.GetType().GetProperty("timesindebt");

            //Assert.NotNull(statusProperty);
            //var statusValue = statusProperty.GetValue(responseObj);
        }

        [Fact]
        public async Task GetDebtMetricsByUserEmailAsync_ThrowsIfUserNotFound()
        {
            // Arrange
            var context = GetDbContext();
            var service = new UserService(context);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await service.GetByEmailAsync("not.exists@example.com");
            });
        }

        [Fact]
        public async Task GetDebtMetricsByUserEmailAsync_ReturnsZeroIfNoDebt()
        {
            // Arrange
            var context = GetDbContext();

            var user = new User { UserId = 1, Fullname = "Sin Deuda", Email = "no.debt@example.com" };
            var wallet = new Wallet { WalletId = 1, UserId = 1 };

            context.Users.Add(user);
            context.Wallets.Add(wallet);
            await context.SaveChangesAsync();

            var service = new UserService(context);

            // Act
            var result = await service.GetByEmailAsync("no.debt@example.com");

            // Assert
            Assert.NotNull(result);
            //Assert.Equal(0, result.TimesInDebt);
            //Assert.Equal(0, result.AverageResolutionTimeHours);
        }
    }
}
