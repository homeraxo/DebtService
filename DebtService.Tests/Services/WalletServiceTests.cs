using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtService.Data;
using DebtService.DTOs;
using DebtService.Models;
using DebtService.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DebtService.Tests.Services
{
    public class WalletServiceTests
    {
        private ApplicationDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Genera un nuevo nombre de base de datos en memoria para cada prueba
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task GetWalletByEmailAsync_WalletExists_ReturnsWalletDto()
        {
            // Arrange
            var dbContext = CreateInMemoryDbContext();
            var wallet = new Wallet
            {
                WalletId = 1,
                BalanceAmount = 100.50m,
                Status = "Active",
                CreatedAt = DateTime.UtcNow,
                User = new User { UserId = 1, Email = "test@example.com", Fullname = "Test User" }
            };
            dbContext.Wallets.Add(wallet);
            dbContext.SaveChanges();

            var walletService = new WalletService(dbContext);

            // Act
            var result = await walletService.GetWalletByEmailAsync("test@example.com");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(wallet.WalletId, result.WalletId);
            Assert.Equal(wallet.BalanceAmount, result.BalanceAmount);
            Assert.Equal(wallet.Status, result.Status);
        }

        [Fact]
        public async Task GetWalletByEmailAsync_WalletDoesNotExist_ReturnsNull()
        {
            // Arrange
            var dbContext = CreateInMemoryDbContext();
            var walletService = new WalletService(dbContext);

            // Act
            var result = await walletService.GetWalletByEmailAsync("nonexistent@example.com");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetCurrentBalanceByEmailAsync_WalletExists_ReturnsBalance()
        {
            // Arrange
            var dbContext = CreateInMemoryDbContext();
            var wallet = new Wallet
            {
                WalletId = 1,
                BalanceAmount = 200.75m,
                Status = "Activa",
                User = new User { UserId = 1, Email = "test@example.com", Fullname = "Test User" }
            };
            dbContext.Wallets.Add(wallet);
            dbContext.SaveChanges();

            var walletService = new WalletService(dbContext);

            // Act
            var result = await walletService.GetCurrentBalanceByEmailAsync("test@example.com");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(wallet.BalanceAmount, result);
        }

        [Fact]
        public async Task GetTransactionHistoryAsync_WalletExists_ReturnsTransactionList()
        {
            // Arrange
            var dbContext = CreateInMemoryDbContext();
            var wallet = new Wallet
            {
                WalletId = 1,
                Status = "Activa",
                User = new User { UserId = 1, Email = "test@example.com", Fullname = "Test User" },
                Transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        TransactionId = 1,
                        Amount = 50.00m,
                        Description = "Test Transaction",
                        TransactionDate = DateTime.UtcNow
                    }
                }
            };
            dbContext.Wallets.Add(wallet);
            dbContext.SaveChanges();

            var walletService = new WalletService(dbContext);

            // Act
            var result = await walletService.GetTransactionHistoryAsync("test@example.com");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(wallet.Transactions.First().Amount, result.First().Amount);
            Assert.Equal(wallet.Transactions.First().Description, result.First().Description);
        }
    }
}