using AccountingForPersonalFinances.Domain.Models;
using AccountingForPersonalFinances.Domain.Models.Enums;
using AccountingForPersonalFinances.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AccountingForPersonalFinances.Tests.Common
{
    public static class AccountingForPersonalFinancesContextFactory
    {
        public static Guid WalletAID = Guid.NewGuid();
        public static Guid WalletBID = Guid.NewGuid();

        public static AccountingForPersonalFinancesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AccountingForPersonalFinancesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new AccountingForPersonalFinancesDbContext(options);
            context.Database.EnsureCreated();
            
            context.Wallets.AddRange(
                new Wallet
                {
                    ID = WalletAID,
                    Name = "Кошелёк 1",
                    Сurrency = "Рубль",
                    InitialBalance = 70000.0m
                },
                new Wallet
                {
                    ID = WalletBID,
                    Name = "Кошелёк 2",
                    Сurrency = "Доллар США",
                    InitialBalance = 50056.0m
                }
            );

            context.Transactions.AddRange(
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 10, 12, 17, 12, 0),
                    Amount = 1377.99m,
                    Type = TransactionType.Expense,
                    Description = "Продукты"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 10, 17, 9, 25, 0),
                    Amount = 2000.0m,
                    Type = TransactionType.Income,
                    Description = "Переводы"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 10, 21, 13, 46, 0),
                    Amount = 450.0m,
                    Type = TransactionType.Expense,
                    Description = "Связь, интернет и ТВ"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 10, 22, 21, 7, 0),
                    Amount = 1759.5m,
                    Type = TransactionType.Expense,
                    Description = "Прочие расходы"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 11, 2, 10, 35, 0),
                    Amount = 7000.0m,
                    Type = TransactionType.Income,
                    Description = "Пополнения"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 10, 29, 15, 15, 0),
                    Amount = 29999.99m,
                    Type = TransactionType.Expense,
                    Description = "Техника"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 11, 3, 22, 16, 0),
                    Amount = 120000.0m,
                    Type = TransactionType.Income,
                    Description = "Зарплата"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 11, 4, 20, 0, 0),
                    Amount = 5000.0m,
                    Type = TransactionType.Income,
                    Description = "Переводы"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 11, 1, 15, 10, 0),
                    Amount = 1000.0m,
                    Type = TransactionType.Expense,
                    Description = "Связь, интернет и ТВ"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 11, 1, 22, 11, 0),
                    Amount = 456.99m,
                    Type = TransactionType.Expense,
                    Description = "Дом и ремонт"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 11, 3, 12, 6, 0),
                    Amount = 750.0m,
                    Type = TransactionType.Expense,
                    Description = "Связь, интернет и ТВ"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 10, 10, 18, 30, 0),
                    Amount = 1450.0m,
                    Type = TransactionType.Income,
                    Description = "Возврат от покупок"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 10, 25, 19, 45, 0),
                    Amount = 2300.0m,
                    Type = TransactionType.Income,
                    Description = "Премия"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 10, 15, 11, 0, 0),
                    Amount = 860.0m,
                    Type = TransactionType.Expense,
                    Description = "Кафе и рестораны"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 10, 27, 20, 30, 0),
                    Amount = 1800.0m,
                    Type = TransactionType.Expense,
                    Description = "Подписки и сервисы"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 11, 6, 13, 40, 0),
                    Amount = 2100.0m,
                    Type = TransactionType.Income,
                    Description = "Возврат налога"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 11, 7, 9, 15, 0),
                    Amount = 3500.0m,
                    Type = TransactionType.Income,
                    Description = "Перевод от друга"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 11, 8, 16, 30, 0),
                    Amount = 980.0m,
                    Type = TransactionType.Expense,
                    Description = "Аптека и здоровье"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletBID,
                    Date = new DateTime(2025, 11, 9, 18, 45, 0),
                    Amount = 450.0m,
                    Type = TransactionType.Expense,
                    Description = "Транспорт"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 10, 28, 18, 45, 0),
                    Amount = 1890.50m,
                    Type = TransactionType.Expense,
                    Description = "Продукты и бытовые товары"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 11, 3, 10, 12, 0),
                    Amount = 1800.00m,
                    Type = TransactionType.Income,
                    Description = "Перевод от друзей"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 11, 5, 11, 40, 0),
                    Amount = 1250.00m,
                    Type = TransactionType.Income,
                    Description = "Пополнение наличными"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 11, 1, 9, 10, 0),
                    Amount = 118500.00m,
                    Type = TransactionType.Income,
                    Description = "Зарплата за октябрь"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 11, 2, 14, 40, 0),
                    Amount = 890.0m,
                    Type = TransactionType.Expense,
                    Description = "Связь, интернет и ТВ"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 11, 4, 21, 0, 0),
                    Amount = 750.0m,
                    Type = TransactionType.Expense,
                    Description = "Подписки и связь"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 10, 11, 14, 20, 0),
                    Amount = 2400.0m,
                    Type = TransactionType.Income,
                    Description = "Возврат долга"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 10, 24, 17, 10, 0),
                    Amount = 1300.0m,
                    Type = TransactionType.Income,
                    Description = "Кэшбэк"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 10, 16, 9, 50, 0),
                    Amount = 780.0m,
                    Type = TransactionType.Expense,
                    Description = "Транспорт"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 10, 29, 20, 0, 0),
                    Amount = 2100.0m,
                    Type = TransactionType.Expense,
                    Description = "Одежда и обувь"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 11, 6, 10, 45, 0),
                    Amount = 3900.0m,
                    Type = TransactionType.Income,
                    Description = "Подработка"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 11, 8, 9, 30, 0),
                    Amount = 2200.0m,
                    Type = TransactionType.Income,
                    Description = "Перевод от семьи"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 11, 7, 18, 50, 0),
                    Amount = 890.0m,
                    Type = TransactionType.Expense,
                    Description = "Продукты"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 11, 9, 13, 25, 0),
                    Amount = 450.0m,
                    Type = TransactionType.Expense,
                    Description = "Кафе и рестораны"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 10, 10, 12, 30, 0),
                    Amount = 14500.00m,
                    Type = TransactionType.Income,
                    Description = "Зарплата за октябрь"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 10, 25, 17, 10, 0),
                    Amount = 3200.00m,
                    Type = TransactionType.Income,
                    Description = "Перевод от друга"
                },

                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 10, 14, 19, 45, 0),
                    Amount = 1800.50m,
                    Type = TransactionType.Expense,
                    Description = "Продукты и бытовые товары"
                },
                new Transaction
                {
                    ID = Guid.NewGuid(),
                    WalletID = WalletAID,
                    Date = new DateTime(2025, 10, 22, 20, 10, 0),
                    Amount = 650.00m,
                    Type = TransactionType.Expense,
                    Description = "Транспорт и проезд"
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(AccountingForPersonalFinancesDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}