using AccountingForPersonalFinances.Domain.Models;
using AccountingForPersonalFinances.Domain.Models.Enums;

namespace AccountingForPersonalFinances.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(AccountingForPersonalFinancesDbContext context)
        {
            if (context.Wallets.Any())
                return;

            var wallets = new[]
            {
                new Wallet
                {
                    ID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Name = "Кошелёк 1",
                    Сurrency = "Рубль",
                    InitialBalance = 70000.0m
                },
                new Wallet
                {
                    ID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Name = "Кошелёк 2",
                    Сurrency = "Доллар США",
                    InitialBalance = 50056.0m
                }
            };

            var transactions = new[]
            {
                new Transaction
                {
                    ID = Guid.Parse("EA277492-9BBC-4168-BE3C-C2505535DDE2"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 10, 12, 17, 12, 0),
                    Amount = 1377.99m,
                    Type = TransactionType.Expense,
                    Description = "Продукты"
                },
                new Transaction
                {
                    ID = Guid.Parse("86EBB0C6-6E08-40AC-A497-39DBD685A4B0"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 10, 17, 9, 25, 0),
                    Amount = 2000.0m,
                    Type = TransactionType.Income,
                    Description = "Переводы"
                },
                new Transaction
                {
                    ID = Guid.Parse("944458E7-FCFA-4507-A3FA-F5F5D8F3D2CE"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 10, 21, 13, 46, 0),
                    Amount = 450.0m,
                    Type = TransactionType.Expense,
                    Description = "Связь, интернет и ТВ"
                },
                new Transaction
                {
                    ID = Guid.Parse("6352A8A3-CE6C-4CC1-AC9B-F0F4562FAFD0"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 10, 22, 21, 7, 0),
                    Amount = 1759.5m,
                    Type = TransactionType.Expense,
                    Description = "Прочие расходы"
                },
                new Transaction
                {
                    ID = Guid.Parse("254DBBDF-D8F9-4FBC-957B-E40EC9C209A5"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 11, 2, 10, 35, 0),
                    Amount = 7000.0m,
                    Type = TransactionType.Income,
                    Description = "Пополнения"
                },
                new Transaction
                {
                    ID = Guid.Parse("79C838C4-1DA1-4879-B8F9-22C406AE9D9A"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 10, 29, 15, 15, 0),
                    Amount = 29999.99m,
                    Type = TransactionType.Expense,
                    Description = "Техника"
                },
                new Transaction
                {
                    ID = Guid.Parse("B798953D-5328-4B32-A6C4-6DE96B43CAD9"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 11, 3, 22, 16, 0),
                    Amount = 120000.0m,
                    Type = TransactionType.Income,
                    Description = "Зарплата"
                },
                new Transaction
                {
                    ID = Guid.Parse("F5C66313-D11F-44CE-879E-84EDB10E93C6"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 11, 4, 20, 0, 0),
                    Amount = 5000.0m,
                    Type = TransactionType.Income,
                    Description = "Переводы"
                },
                new Transaction
                {
                    ID = Guid.Parse("1CB3629D-1924-4C9F-87E5-B0223F62E1C8"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 11, 1, 15, 10, 0),
                    Amount = 1000.0m,
                    Type = TransactionType.Expense,
                    Description = "Связь, интернет и ТВ"
                },
                new Transaction
                {
                    ID = Guid.Parse("1D6670E9-89E8-412B-AEBA-B9513774FEF7"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 11, 1, 22, 11, 0),
                    Amount = 456.99m,
                    Type = TransactionType.Expense,
                    Description = "Дом и ремонт"
                },
                new Transaction
                {
                    ID = Guid.Parse("77D7C9EE-757F-4352-826D-C64E2194BE8B"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 11, 3, 12, 6, 0),
                    Amount = 750.0m,
                    Type = TransactionType.Expense,
                    Description = "Связь, интернет и ТВ"
                },
                new Transaction
                {
                    ID = Guid.Parse("CFA33E77-73C4-4C9B-B8C8-2E451C5C47D1"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 10, 10, 18, 30, 0),
                    Amount = 1450.0m,
                    Type = TransactionType.Income,
                    Description = "Возврат от покупок"
                },
                new Transaction
                {
                    ID = Guid.Parse("A9C21A18-18E7-4FBA-AE97-5733E702C88A"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 10, 25, 19, 45, 0),
                    Amount = 2300.0m,
                    Type = TransactionType.Income,
                    Description = "Премия"
                },
                new Transaction
                {
                    ID = Guid.Parse("CB52497C-65F8-4A71-B865-8D4B0A7B8C62"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 10, 15, 11, 0, 0),
                    Amount = 860.0m,
                    Type = TransactionType.Expense,
                    Description = "Кафе и рестораны"
                },
                new Transaction
                {
                    ID = Guid.Parse("5F97164E-F4EE-493A-9E32-9864CFCB3D8E"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 10, 27, 20, 30, 0),
                    Amount = 1800.0m,
                    Type = TransactionType.Expense,
                    Description = "Подписки и сервисы"
                },
                new Transaction
                {
                    ID = Guid.Parse("82E9E7AF-8AB8-4D1C-84B7-111EC773A7F4"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 11, 6, 13, 40, 0),
                    Amount = 2100.0m,
                    Type = TransactionType.Income,
                    Description = "Возврат налога"
                },
                new Transaction
                {
                    ID = Guid.Parse("7699ED19-06D0-48D8-B2D3-95A1AEF7D125"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 11, 7, 9, 15, 0),
                    Amount = 3500.0m,
                    Type = TransactionType.Income,
                    Description = "Перевод от друга"
                },
                new Transaction
                {
                    ID = Guid.Parse("8C56B56A-598C-4F94-B9C8-BA31203D6C55"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 11, 8, 16, 30, 0),
                    Amount = 980.0m,
                    Type = TransactionType.Expense,
                    Description = "Аптека и здоровье"
                },
                new Transaction
                {
                    ID = Guid.Parse("4E827F0C-03E3-4A62-911E-5E3E5B96F0D0"),
                    WalletID = Guid.Parse("417F1094-9FAC-40F9-91F4-64C7434FD563"),
                    Date = new DateTime(2025, 11, 9, 18, 45, 0),
                    Amount = 450.0m,
                    Type = TransactionType.Expense,
                    Description = "Транспорт"
                },
                new Transaction
                {
                    ID = Guid.Parse("BAE8897D-AB56-4AB5-B146-8889AD78B92F"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 10, 28, 18, 45, 0),
                    Amount = 1890.50m,
                    Type = TransactionType.Expense,
                    Description = "Продукты и бытовые товары"
                },
                new Transaction
                {
                    ID = Guid.Parse("C6663C27-5608-42E5-9BB8-2C648C695F23"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 11, 3, 10, 12, 0),
                    Amount = 1800.00m,
                    Type = TransactionType.Income,
                    Description = "Перевод от друзей"
                },
                new Transaction
                {
                    ID = Guid.Parse("B08394E4-B4F3-4784-88CC-E9B0042127D4"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 11, 5, 11, 40, 0),
                    Amount = 1250.00m,
                    Type = TransactionType.Income,
                    Description = "Пополнение наличными"
                },
                new Transaction
                {
                    ID = Guid.Parse("ADDCA16C-DDED-4B18-8B91-01E57EA3F530"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 11, 1, 9, 10, 0),
                    Amount = 118500.00m,
                    Type = TransactionType.Income,
                    Description = "Зарплата за октябрь"
                },
                new Transaction
                {
                    ID = Guid.Parse("ACD26848-8584-4732-93F3-D6FC4E22A857"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 11, 2, 14, 40, 0),
                    Amount = 890.0m,
                    Type = TransactionType.Expense,
                    Description = "Связь, интернет и ТВ"
                },
                new Transaction
                {
                    ID = Guid.Parse("5B890887-5DC2-4571-BC77-FB72BB5C36D2"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 11, 4, 21, 0, 0),
                    Amount = 750.0m,
                    Type = TransactionType.Expense,
                    Description = "Подписки и связь"
                },
                new Transaction
                {
                    ID = Guid.Parse("E7E53BFA-B7E3-4E63-AF24-3BA8B34DAB4C"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 10, 11, 14, 20, 0),
                    Amount = 2400.0m,
                    Type = TransactionType.Income,
                    Description = "Возврат долга"
                },
                new Transaction
                {
                    ID = Guid.Parse("B2F2D1B4-F72C-48C8-89B5-E67B8C8E0FCF"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 10, 24, 17, 10, 0),
                    Amount = 1300.0m,
                    Type = TransactionType.Income,
                    Description = "Кэшбэк"
                },
                new Transaction
                {
                    ID = Guid.Parse("F8A1475A-09A1-4D5B-83C1-54BA19AE9408"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 10, 16, 9, 50, 0),
                    Amount = 780.0m,
                    Type = TransactionType.Expense,
                    Description = "Транспорт"
                },
                new Transaction
                {
                    ID = Guid.Parse("CF69043E-86C0-4E0D-875E-2FAE858C037F"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 10, 29, 20, 0, 0),
                    Amount = 2100.0m,
                    Type = TransactionType.Expense,
                    Description = "Одежда и обувь"
                },
                new Transaction
                {
                    ID = Guid.Parse("B17AB75B-91F1-40A1-8E54-FAE3F17A3731"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 11, 6, 10, 45, 0),
                    Amount = 3900.0m,
                    Type = TransactionType.Income,
                    Description = "Подработка"
                },
                new Transaction
                {
                    ID = Guid.Parse("74B3B93E-2B5A-47BA-AD31-05B8EE03104B"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 11, 8, 9, 30, 0),
                    Amount = 2200.0m,
                    Type = TransactionType.Income,
                    Description = "Перевод от семьи"
                },
                new Transaction
                {
                    ID = Guid.Parse("63BA55C9-4E86-4F80-A8AB-7B8E820AACF3"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 11, 7, 18, 50, 0),
                    Amount = 890.0m,
                    Type = TransactionType.Expense,
                    Description = "Продукты"
                },
                new Transaction
                {
                    ID = Guid.Parse("7CEBF0C7-7F3F-4DA2-A9C3-2B28C0E1456F"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 11, 9, 13, 25, 0),
                    Amount = 450.0m,
                    Type = TransactionType.Expense,
                    Description = "Кафе и рестораны"
                },
                new Transaction
                {
                    ID = Guid.Parse("0D418C1B-CEB9-48A4-91B4-5BE32B6EAB2E"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 10, 10, 12, 30, 0),
                    Amount = 14500.00m,
                    Type = TransactionType.Income,
                    Description = "Зарплата за октябрь"
                },
                new Transaction
                {
                    ID = Guid.Parse("F7A9D502-9C17-4EE2-BC04-BDFA1128C9F2"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 10, 25, 17, 10, 0),
                    Amount = 3200.00m,
                    Type = TransactionType.Income,
                    Description = "Перевод от друга"
                },
                new Transaction
                {
                    ID = Guid.Parse("7AE91D16-5EE8-4A65-A622-AC50848C1D52"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 10, 14, 19, 45, 0),
                    Amount = 1800.50m,
                    Type = TransactionType.Expense,
                    Description = "Продукты и бытовые товары"
                },
                new Transaction
                {
                    ID = Guid.Parse("A514C20E-6C4A-4B02-92A2-932DA5328359"),
                    WalletID = Guid.Parse("61CE7353-F161-49D1-B9F0-79538C845E01"),
                    Date = new DateTime(2025, 10, 22, 20, 10, 0),
                    Amount = 650.00m,
                    Type = TransactionType.Expense,
                    Description = "Транспорт и проезд"
                }
            };

            context.Wallets.AddRange(wallets);
            context.Transactions.AddRange(transactions);
            context.SaveChanges();
        }
    }
}